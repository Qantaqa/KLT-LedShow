Imports System.Windows.Forms
Imports System.Drawing

Module Sliders

    ' ****************************************************************************************
    '  GenerateSlidersForSelectedFixture
    '  Genereert sliders voor elke LED in het geselecteerde device, vult met bestaande data.
    ' ****************************************************************************************
    Public Sub GenerateSlidersForSelectedFixture()
        StopDDPStream()
        FrmMain.SplitContainer_Devices.Panel2.Controls.Clear()

        If FrmMain.DG_Devices.CurrentRow Is Nothing Then Exit Sub
        Dim ledCount As Integer = Convert.ToInt32(FrmMain.DG_Devices.CurrentRow.Cells("colLedCount").Value)
        Dim existingData As Byte() = TryCast(FrmMain.DG_Devices.CurrentRow.Cells("colDDPData").Value, Byte())

        Dim sliderBreedte As Integer = 40
        Dim sliderHoogte As Integer = 150
        Dim padding As Integer = 10
        Dim sliderTop As Integer = 40
        Dim labelHoogte As Integer = 20

        For i As Integer = 0 To ledCount - 1
            Dim r = 0, g = 0, b = 0
            If existingData IsNot Nothing AndAlso existingData.Length >= (i + 1) * 3 Then
                r = existingData(i * 3)
                g = existingData(i * 3 + 1)
                b = existingData(i * 3 + 2)
            End If

            Dim baseLeft As Integer = i * (3 * sliderBreedte + padding)
            Dim ledColor As Color = Color.FromArgb(r, g, b)

            ' Label met LED-nummer en gecombineerde kleur
            Dim lbl As New Label() With {
                .Text = $"LED {i}",
                .BackColor = ledColor,
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = 3 * sliderBreedte,
                .Height = labelHoogte,
                .Left = baseLeft,
                .Top = sliderTop - labelHoogte
            }
            FrmMain.SplitContainer_Devices.Panel2.Controls.Add(lbl)

            Dim rSlider As New TrackBar() With {
                .Orientation = Orientation.Vertical,
                .Minimum = 0,
                .Maximum = 255,
                .TickFrequency = 32,
                .Height = sliderHoogte,
                .Left = baseLeft,
                .Top = sliderTop,
                .Tag = $"LED_{i}_R",
                .Value = r,
                .BackColor = Color.FromArgb(r, 0, 0)
            }
            AddHandler rSlider.Scroll, AddressOf Slider_Scroll
            FrmMain.SplitContainer_Devices.Panel2.Controls.Add(rSlider)

            Dim gSlider As New TrackBar() With {
                .Orientation = Orientation.Vertical,
                .Minimum = 0,
                .Maximum = 255,
                .TickFrequency = 32,
                .Height = sliderHoogte,
                .Left = baseLeft + sliderBreedte,
                .Top = sliderTop,
                .Tag = $"LED_{i}_G",
                .Value = g,
                .BackColor = Color.FromArgb(0, g, 0)
            }
            AddHandler gSlider.Scroll, AddressOf Slider_Scroll
            FrmMain.SplitContainer_Devices.Panel2.Controls.Add(gSlider)

            Dim bSlider As New TrackBar() With {
                .Orientation = Orientation.Vertical,
                .Minimum = 0,
                .Maximum = 255,
                .TickFrequency = 32,
                .Height = sliderHoogte,
                .Left = baseLeft + 2 * sliderBreedte,
                .Top = sliderTop,
                .Tag = $"LED_{i}_B",
                .Value = b,
                .BackColor = Color.FromArgb(0, 0, b)
            }
            AddHandler bSlider.Scroll, AddressOf Slider_Scroll
            FrmMain.SplitContainer_Devices.Panel2.Controls.Add(bSlider)
        Next

        StartDDPStream()
        UpdateWLEDFromSliders_DDP()
    End Sub

    ' ****************************************************************************************
    '  GetSliderValue
    ' ****************************************************************************************
    Public Function GetSliderValue(ledIndex As Integer, kleur As String) As Integer
        For Each ctrl In FrmMain.SplitContainer_Devices.Panel2.Controls
            If TypeOf ctrl Is TrackBar AndAlso ctrl.Tag?.ToString() = $"LED_{ledIndex}_{kleur}" Then
                Return CType(ctrl, TrackBar).Value
            End If
        Next
        Return 0
    End Function

    ' ****************************************************************************************
    '  Slider_Scroll
    ' ****************************************************************************************
    Private Sub Slider_Scroll(sender As Object, e As EventArgs)
        Dim changedSlider = CType(sender, TrackBar)
        Dim tag = changedSlider.Tag.ToString() ' voorbeeld: "LED_3_R"
        Dim parts = tag.Split("_"c)
        If parts.Length <> 3 Then Exit Sub

        Dim ledIndex As Integer = Integer.Parse(parts(1))

        ' Lees RGB waarden van alle drie sliders
        Dim r = GetSliderValue(ledIndex, "R")
        Dim g = GetSliderValue(ledIndex, "G")
        Dim b = GetSliderValue(ledIndex, "B")

        ' Update kleur van sliders
        For Each ctrl In FrmMain.SplitContainer_Devices.Panel2.Controls
            If TypeOf ctrl Is TrackBar Then
                Dim ctrlTag = ctrl.Tag?.ToString()
                If ctrlTag = $"LED_{ledIndex}_R" Then
                    ctrl.BackColor = Color.FromArgb(r, 0, 0)
                ElseIf ctrlTag = $"LED_{ledIndex}_G" Then
                    ctrl.BackColor = Color.FromArgb(0, g, 0)
                ElseIf ctrlTag = $"LED_{ledIndex}_B" Then
                    ctrl.BackColor = Color.FromArgb(0, 0, b)
                End If
            ElseIf TypeOf ctrl Is Label AndAlso ctrl.Text = $"LED {ledIndex}" Then
                ctrl.BackColor = Color.FromArgb(r, g, b)
            End If
        Next

        ' Verstuur update
        UpdateWLEDFromSliders_DDP()
    End Sub

    ' ****************************************************************************************
    '  UpdateWLEDFromSliders_DDP
    ' ****************************************************************************************
    Public Sub UpdateWLEDFromSliders_DDP()
        If FrmMain.DG_Devices.CurrentRow Is Nothing Then Exit Sub

        Dim row As DataGridViewRow = FrmMain.DG_Devices.CurrentRow
        Dim ipAddress As String = row.Cells("colIPAddress").Value.ToString()
        Dim ledCount As Integer = CInt(row.Cells("colLedCount").Value)
        If ledCount <= 0 Then Exit Sub

        Dim rgbBuffer(ledCount * 3 - 1) As Byte

        For i As Integer = 0 To ledCount - 1
            rgbBuffer(i * 3) = CByte(GetSliderValue(i, "R"))
            rgbBuffer(i * 3 + 1) = CByte(GetSliderValue(i, "G"))
            rgbBuffer(i * 3 + 2) = CByte(GetSliderValue(i, "B"))
        Next

        row.Cells("colDDPData").Value = rgbBuffer
        SendDDP(ipAddress, rgbBuffer)
    End Sub

End Module
