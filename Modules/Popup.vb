Module Popup

    ' Dictionary om de actieve meldingsformulieren bij te houden (we hebben de timer niet per se nodig voor het tekenen)
    Private ActieveMeldingForms As New Dictionary(Of Form, Boolean) ' Boolean is placeholder

    Public Sub ToonFlashBericht(ByVal bericht As String, ByVal duurInSeconden As Integer)
        ' Maak een nieuw, eenvoudig formulier voor de melding
        Dim meldingForm As New Form()
        meldingForm.Text = "" ' Geen titelbalk
        meldingForm.FormBorderStyle = FormBorderStyle.None
        meldingForm.ShowInTaskbar = False
        meldingForm.StartPosition = FormStartPosition.CenterScreen ' Of een andere gewenste positie
        meldingForm.BackColor = Color.MidnightBlue ' Achtergrondkleur
        meldingForm.Opacity = 0.8 ' Maak het eventueel semi-transparant
        meldingForm.Padding = New Padding(5) ' Ruimte voor de border

        ' Voeg het formulier toe aan de dictionary
        ActieveMeldingForms.Add(meldingForm, True) ' Boolean is niet relevant

        ' Voeg de Paint event handler toe (verwijst nu naar de losse sub)
        AddHandler meldingForm.Paint, AddressOf MeldingForm_Paint

        ' Maak een label op het meldingsformulier om het bericht weer te geven
        Dim lblBericht As New Label()
        lblBericht.Text = bericht
        lblBericht.AutoSize = True
        lblBericht.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblBericht.ForeColor = Color.White ' Witte tekst
        lblBericht.BackColor = Color.Transparent ' Zodat de achtergrond van het formulier zichtbaar is
        lblBericht.Location = New Point(10 + meldingForm.Padding.Left, 10 + meldingForm.Padding.Top) ' Houd rekening met de padding
        meldingForm.Controls.Add(lblBericht)

        ' Pas de grootte van het formulier aan het label aan (plus de padding)
        meldingForm.ClientSize = New Size(lblBericht.Width + 20 + meldingForm.Padding.Horizontal, lblBericht.Height + 20 + meldingForm.Padding.Vertical)

        ' Maak een lokale Timer programmatisch
        Dim tmrVerdwijn As New Timer()
        tmrVerdwijn.Interval = duurInSeconden * 1000
        tmrVerdwijn.Enabled = True
        tmrVerdwijn.Tag = meldingForm ' Sla het formulier op in de Tag van de timer

        ' Voeg de event handler toe (verwijst nu naar de losse sub)
        AddHandler tmrVerdwijn.Tick, AddressOf TimerVerdwijn_Tick

        ' Toon het meldingsformulier niet-modaal
        meldingForm.Show()

    End Sub

    ' Losse Sub voor het tekenen van de formulier border
    Private Sub MeldingForm_Paint(sender As Object, pe As PaintEventArgs)
        Dim frm As Form = DirectCast(sender, Form)
        Dim g As Graphics = pe.Graphics
        Dim rect As Rectangle = frm.ClientRectangle
        rect.Inflate(-frm.Padding.All, -frm.Padding.All) ' Trek de padding af
    End Sub

    ' Losse Sub voor de Timer Tick event
    Private Sub TimerVerdwijn_Tick(sender As Object, e As EventArgs)
        Dim timer As Timer = DirectCast(sender, Timer)
        Dim frm As Form = TryCast(timer.Tag, Form) ' Haal het formulier op uit de Tag van de timer

        If frm IsNot Nothing Then
            ' Verwijder het formulier uit de dictionary
            If ActieveMeldingForms.ContainsKey(frm) Then
                ActieveMeldingForms.Remove(frm)
            End If

            ' Stop de timer en dispose hem
            timer.Stop()
            timer.Dispose()

            ' Sluit het meldingsformulier en dispose het
            frm.Close()
            frm.Dispose()
        End If
    End Sub

End Module