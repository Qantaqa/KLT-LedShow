
Imports System.Drawing
Imports System.Windows.Forms
Imports KLT_LedShow.StageBase

Partial Public Module CustomEffects

    ' Compile sub voor het Twinkle effect
    Public Sub CompileCustomEffect_Twinkle(pDuration As Integer, pFPS As Integer)
        ' Toon popup met voortgang
        Try
            ' Referenties naar de EffectGrid en FrameGrid
            Dim meGrid = FrmMain.DG_MyEffects
            Dim framesGrid = FrmMain.DG_MyEffectsFrames

            If meGrid.CurrentRow Is Nothing Then
                MessageBox.Show("Selecteer eerst een effect in DG_MyEffect.", "Geen effect", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Return
            End If

            Dim effectId = CInt(meGrid.CurrentRow.Cells("colMEID").Value)

            ' Verwijder oude frames
            For i As Integer = framesGrid.Rows.Count - 1 To 0 Step -1
                framesGrid.Rows.RemoveAt(i)
            Next

            ' Parameters ophalen
            Dim duration = pDuration
            Dim fps = pFPS

            Dim totalFrames = duration * fps

            Dim rnd As New Random()

            ' Genereer frames
            For frameIndex As Integer = 0 To totalFrames - 1
                Dim newRow = framesGrid.Rows(framesGrid.Rows.Add())
                newRow.Cells("colFrameIndex").Value = frameIndex
                newRow.Cells("colFrameTime").Value = CInt(1000 * frameIndex / fps)
                newRow.Cells("colFrameData").Value = ""

                Dim frameData As New Dictionary(Of Integer, Color)

                ' Loop door alle lichtbronnen met effect "twinkle"
                For Each row As DataGridViewRow In FrmMain.DG_LightSources.Rows
                    If row.IsNewRow Then Continue For
                    If row.Cells("colEffect").Value?.ToString().ToLower() <> "twinkle" Then Continue For

                    Dim ledIndex = CInt(row.Cells("colLEDIndex").Value)
                    Dim baseColor = ColorTranslator.FromHtml(row.Cells("colColor").Value.ToString())

                    ' Willekeurige kans op twinkle
                    If rnd.NextDouble() < 0.1 Then
                        ' Twinkle naar wit
                        frameData(ledIndex) = Color.White
                    Else
                        frameData(ledIndex) = baseColor
                    End If
                Next

                ' Encodeer frameData naar string
                Dim encoded = EncodeFrame(frameData)
                newRow.Cells("colFrameData").Value = encoded
            Next

        Catch ex As Exception
            MessageBox.Show("Fout tijdens compilatie Twinkle: " & ex.Message)
        Finally
        End Try
    End Sub

    Public Function EncodeFrame(frameData As Dictionary(Of Integer, Color)) As String
        Return String.Join(";", frameData.Select(Function(kv) $"{kv.Key}:{kv.Value.R},{kv.Value.G},{kv.Value.B}"))
    End Function

End Module
