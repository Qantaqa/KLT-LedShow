Imports System.Drawing
Imports System.Collections.Generic

Module CustomEffects_Twinkle

    ' Struct voor individuele twinkle data per LED
    Private Structure TwinkleEvent
        Public StartFrame As Integer
        Public Duration As Integer
        Public PeakBrightness As Single
    End Structure

    ' Map shape -> LED indexen -> lijst van twinkles
    Private TwinkleMap As New Dictionary(Of Integer, Dictionary(Of Integer, List(Of TwinkleEvent)))
    Private RandGen As New Random()

    ' Aanroep per Compile_EffectDesigner voor elke LED binnen shape
    Public Sub CompileCustomEffect_Twinkle(
        ByRef r As Byte,
        ByRef g As Byte,
        ByRef b As Byte,
        frameIndex As Integer,
        ledIndex As Integer,
        ledXmm As Single,
        ledYmm As Single,
        hitLeds As List(Of Integer),
        parameters As EffectParams,
        tickOffset As Integer
    )

        ' Unieke shape-ID afgeleid uit de lijst
        Dim shapeId As Integer = hitLeds.GetHashCode()
        If Not TwinkleMap.ContainsKey(shapeId) Then
            TwinkleMap(shapeId) = GenerateTwinklesForShape(hitLeds, parameters, shapeId)
        End If

        If Not TwinkleMap(shapeId).ContainsKey(ledIndex) Then Exit Sub

        Dim ledTwinkles = TwinkleMap(shapeId)(ledIndex)
        For Each tw In ledTwinkles
            If frameIndex >= tw.StartFrame AndAlso frameIndex <= tw.StartFrame + tw.Duration Then
                Dim localFrame = frameIndex - tw.StartFrame
                Dim fade = GetFadeBrightness(localFrame, tw.Duration)

                ' Haal kleuren uit parameters
                Dim colorStart As Color = parameters.Kleuren(2) ' kleur 3
                Dim colorPeak As Color = parameters.Kleuren(3)  ' kleur 4
                Dim colorEnd As Color = parameters.Kleuren(4)   ' kleur 5

                ' Interpoleer kleur tussen start, peak, end afhankelijk van fade-fase
                If fade < 0.5 Then
                    ' Fade-in van start naar peak
                    InterpolateColor(colorStart, colorPeak, fade * 2, r, g, b)
                Else
                    ' Fade-out van peak naar end
                    InterpolateColor(colorPeak, colorEnd, (fade - 0.5F) * 2, r, g, b)
                End If

                ' Pas globale helderheid aan
                ApplyBrightness(r, g, b, tw.PeakBrightness, parameters)
                Exit For ' 1 twinkle tegelijk per LED
            End If
        Next
    End Sub

    ' Genereert een twinkle-map voor alle leds in een shape
    Private Function GenerateTwinklesForShape(hitLeds As List(Of Integer), parameters As EffectParams, shapeId As Integer) As Dictionary(Of Integer, List(Of TwinkleEvent))
        Dim result As New Dictionary(Of Integer, List(Of TwinkleEvent))
        Dim durationFrames As Integer = Math.Max(10, parameters.Duration * parameters.FPS \ 1000)

        Dim ledCount = hitLeds.Count
        Dim dispersion = Math.Max(1, parameters.Dispersion)
        Dim intensity = Math.Max(1, parameters.Intensity)

        Dim totalTwinkles = Math.Min(hitLeds.Count * durationFrames \ dispersion, intensity * durationFrames)

        For i = 1 To totalTwinkles
            Dim ledIndex = hitLeds(RandGen.Next(0, ledCount))
            Dim startFrame = RandGen.Next(0, durationFrames)
            Dim twinkleLength = RandGen.Next(3, 8) ' 3–8 frames lang (0.6–1.6 sec)
            Dim peak = 0.4 + RandGen.NextDouble() * 0.6 ' tussen 0.4 en 1.0

            If Not result.ContainsKey(ledIndex) Then
                result(ledIndex) = New List(Of TwinkleEvent)
            End If
            result(ledIndex).Add(New TwinkleEvent With {
                .StartFrame = startFrame,
                .Duration = twinkleLength,
                .PeakBrightness = CSng(peak)
            })
        Next

        Return result
    End Function

    ' Simpele sinusvorm fade-in/fade-out (0.0–1.0)
    Private Function GetFadeBrightness(framePos As Integer, duration As Integer) As Single
        Dim phase = Math.PI * framePos / duration
        Return CSng(Math.Sin(phase)) ' 0–1–0 curve
    End Function

    ' Lineaire interpolatie tussen twee kleuren
    Private Sub InterpolateColor(startColor As Color, endColor As Color, t As Single, ByRef r As Byte, ByRef g As Byte, ByRef b As Byte)
        r = CByte(startColor.R + t * (endColor.R - startColor.R))
        g = CByte(startColor.G + t * (endColor.G - startColor.G))
        b = CByte(startColor.B + t * (endColor.B - startColor.B))
    End Sub

    ' Past helderheid toe op RGB waarden, respecteert BrightnessBaseline en BrightnessEffect
    Private Sub ApplyBrightness(ByRef r As Byte, ByRef g As Byte, ByRef b As Byte, brightnessFactor As Single, parameters As EffectParams)
        Dim effectBri = parameters.Brightness_Effect / 100.0F
        r = CByte(Math.Min(255, r * brightnessFactor * effectBri))
        g = CByte(Math.Min(255, g * brightnessFactor * effectBri))
        b = CByte(Math.Min(255, b * brightnessFactor * effectBri))
    End Sub

End Module
