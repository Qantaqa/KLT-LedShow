Public Class DetailLightSource

    ' OK-button sluit het formulier met DialogResult.OK
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


End Class