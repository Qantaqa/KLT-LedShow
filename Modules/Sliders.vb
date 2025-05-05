Imports System.Windows.Forms
Imports System.Drawing

Module Sliders

    ' ****************************************************************************************
    '  GenerateSlidersForSelectedFixture
    '  Genereert sliders voor elke LED in het geselecteerde device, vult met bestaande data.
    ' ****************************************************************************************
    Public Sub GenerateSlidersForSelectedFixture(ByVal CurrentDevice As DataGridViewRow, ByVal TargetPanel As Panel)
        FrmMain.SplitContainer_Devices.Panel2.Controls.Clear()

        ' Also remove any old DataProvider set to  "DMX"
        For Each r In FrmMain.DG_Devices.Rows
            If Not r.IsNewRow AndAlso CStr(r.Cells("colDataProvider").Value) = "DMX" Then
                r.Cells("colDataProvider").Value = "Show"
            End If
        Next

        ' Check if the current device is valid
        If CurrentDevice Is Nothing Then Exit Sub

        ' Update the current device 
        Dim ledCount As Integer = Convert.ToInt32(CurrentDevice.Cells("colLedCount").Value)
        Dim existingData As Byte() = TryCast(CurrentDevice.Cells("colDDPData").Value, Byte())

        CurrentDevice.Cells("colDataProvider").Value = "DMX"

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
            TargetPanel.Controls.Add(lbl)

            ' Rode slider
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
            TargetPanel.Controls.Add(rSlider)

            ' Groene slider
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
            TargetPanel.Controls.Add(gSlider)

            ' Blauwe slider
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
            TargetPanel.Controls.Add(bSlider)
        Next

        ' Update de cellen in de DataGridView
        UpdateWLEDFromSliders_DDP(CurrentDevice)
    End Sub


    Public Sub GenerateSlidersForSelectedGroup(ByVal GroupRow As DataGridViewRow, ByVal TargetPanel As Panel)
        FrmMain.SplitContainer_Devices.Panel2.Controls.Clear()

        ' Ophalen groepsinfo
        Dim fixture = CStr(GroupRow.Cells("colGroupFixture").Value)
        Dim startLed = CInt(GroupRow.Cells("colGroupStartLedNr").Value) - 1
        Dim stopLed = CInt(GroupRow.Cells("colGroupStopLedNr").Value) - 1
        Dim ledRange = stopLed - startLed + 1

        ' Zoek bijbehorend device
        Dim deviceRow = FrmMain.DG_Devices.Rows.Cast(Of DataGridViewRow)().
        FirstOrDefault(Function(r) Not r.IsNewRow AndAlso CStr(r.Cells("colInstance").Value) = fixture)
        If deviceRow Is Nothing Then Exit Sub

        deviceRow.Cells("colDataProvider").Value = "DMX"
        Dim existingData As Byte() = TryCast(deviceRow.Cells("colDDPData").Value, Byte())

        ' Slider-UI instellen
        Dim sliderBreedte As Integer = 40
        Dim sliderHoogte As Integer = 150
        Dim padding As Integer = 10
        Dim sliderTop As Integer = 40
        Dim labelHoogte As Integer = 20

        For i As Integer = 0 To ledRange - 1
            Dim ledIndex = startLed + i
            Dim r = 0, g = 0, b = 0
            If existingData IsNot Nothing AndAlso existingData.Length >= (ledIndex + 1) * 3 Then
                r = existingData(ledIndex * 3)
                g = existingData(ledIndex * 3 + 1)
                b = existingData(ledIndex * 3 + 2)
            End If

            Dim baseLeft As Integer = i * (3 * sliderBreedte + padding)
            Dim ledColor As Color = Color.FromArgb(r, g, b)

            ' Label
            Dim lbl As New Label() With {
            .Text = $"LED {ledIndex}",
            .BackColor = ledColor,
            .ForeColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Width = 3 * sliderBreedte,
            .Height = labelHoogte,
            .Left = baseLeft,
            .Top = sliderTop - labelHoogte
        }
            TargetPanel.Controls.Add(lbl)

            ' Sliders (R, G, B)
            Dim kleuren = {"R", "G", "B"}
            Dim waarden = {r, g, b}
            For j = 0 To 2
                Dim slider As New TrackBar() With {
                .Orientation = Orientation.Vertical,
                .Minimum = 0,
                .Maximum = 255,
                .TickFrequency = 32,
                .Height = sliderHoogte,
                .Left = baseLeft + j * sliderBreedte,
                .Top = sliderTop,
                .Tag = $"LED_{ledIndex}_{kleuren(j)}",
                .Value = waarden(j)
            }
                slider.BackColor = Color.FromArgb(If(j = 0, waarden(j), 0),
                                              If(j = 1, waarden(j), 0),
                                              If(j = 2, waarden(j), 0))
                AddHandler slider.Scroll, AddressOf Slider_Scroll
                TargetPanel.Controls.Add(slider)
            Next
        Next

        ' Initieel versturen
        UpdateWLEDFromSliders_DDP(deviceRow)
    End Sub


    ' ****************************************************************************************
    '  GetSliderValue
    ' Get de waarde van een slider op basis van het LED-nummer en de kleur.
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
    '  Dit is de event-handler voor de sliders. Het update de kleuren van de sliders en labels
    ' ****************************************************************************************
    Private Sub Slider_Scroll(sender As Object, e As EventArgs)
        Dim changedSlider = CType(sender, TrackBar)
        Dim tag = changedSlider.Tag.ToString() ' bijv. "LED_3_R"
        Dim parts = tag.Split("_"c)
        If parts.Length <> 3 Then Exit Sub

        Dim ledIndex As Integer = Integer.Parse(parts(1))

        ' Lees RGB waarden van alle drie sliders
        Dim r = GetSliderValue(ledIndex, "R")
        Dim g = GetSliderValue(ledIndex, "G")
        Dim b = GetSliderValue(ledIndex, "B")

        ' Update sliderkleuren en labelkleur
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

        ' Directe update naar WLED (via DDP) voor elke device met DMX
        For Each row As DataGridViewRow In FrmMain.DG_Devices.Rows
            If Not row.IsNewRow AndAlso CStr(row.Cells("colDataProvider").Value) = "DMX" Then
                UpdateWLEDFromSliders_DDP(row)
            End If
        Next
    End Sub


    ' ****************************************************************************************
    '  UpdateWLEDFromSliders_DDP
    '  Update de RGB-waarden in de DataGridView en stuur ze naar de DDP-stream.
    ' ****************************************************************************************
    Public Sub UpdateWLEDFromSliders_DDP(ByVal CurrentRow As DataGridViewRow)
        If FrmMain.DG_Devices.CurrentRow Is Nothing Then Exit Sub

        Dim ipAddress As String = CurrentRow.Cells("colIPAddress").Value.ToString()
        Dim ledCount As Integer = CInt(CurrentRow.Cells("colLedCount").Value)
        If ledCount <= 0 Then Exit Sub

        Dim instance As String = CurrentRow.Cells("colInstance").Value.ToString()
        Dim totalBufferSize = ledCount * 3
        Dim deviceBuf = TryCast(CurrentRow.Cells("colDDPData").Value, Byte())
        If deviceBuf Is Nothing OrElse deviceBuf.Length <> totalBufferSize Then
            deviceBuf = New Byte(totalBufferSize - 1) {}
        End If

        Dim startLed As Integer = 0
        Dim stopLed As Integer = ledCount - 1

        ' Probeer eerst via actieve groep
        If FrmMain.CurrentGroupId >= 0 Then
            Dim targetGroup = FrmMain.DG_Groups.Rows.Cast(Of DataGridViewRow)().
            FirstOrDefault(Function(r) Not r.IsNewRow AndAlso
                                      CStr(r.Cells("colGroupFixture").Value) = instance AndAlso
                                      CInt(r.Cells("colGroupId").Value) = FrmMain.CurrentGroupId)
            If targetGroup IsNot Nothing Then
                startLed = CInt(targetGroup.Cells("colGroupStartLedNr").Value) - 1
                stopLed = CInt(targetGroup.Cells("colGroupStopLedNr").Value) - 1
            Else
                Debug.WriteLine("⚠️ Actieve groep niet gevonden voor device.")
                Exit Sub
            End If

        ElseIf FrmMain.CurrentDeviceId = instance Then
            ' Geen groep actief, maar wel devicebreed slidersysteem
            startLed = 0
            stopLed = ledCount - 1

        Else
            Debug.WriteLine("⚠️ Geen groep of device actief voor sliderdata.")
            Exit Sub
        End If

        ' RGB-data toepassen binnen het bereik
        Dim ledRange = stopLed - startLed + 1
        For i As Integer = 0 To ledRange - 1
            Dim r = CByte(GetSliderValue(startLed + i, "R"))
            Dim g = CByte(GetSliderValue(startLed + i, "G"))
            Dim b = CByte(GetSliderValue(startLed + i, "B"))

            Dim idx = (startLed + i) * 3
            If idx + 2 < deviceBuf.Length Then
                deviceBuf(idx) = r
                deviceBuf(idx + 1) = g
                deviceBuf(idx + 2) = b
            End If
        Next

        ' Schrijf buffer terug
        CurrentRow.Cells("colDDPData").Value = deviceBuf
        CurrentRow.Cells("colDDPOffset").Value = 0

        SendDDP(ipAddress, deviceBuf)
    End Sub




End Module
