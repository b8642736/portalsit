Public Class TestForm

    Private Sub TestForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Controls.Add(New UCWaitReceived2Check)
        Me.Controls.Add(New UCScheduleAndState)
        Me.Controls(0).Dock = DockStyle.Fill
    End Sub
End Class