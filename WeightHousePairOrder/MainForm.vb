Public Class MainForm

    Private ShowControl As WeightHousePairOrder.WeightPair

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(ShowControl) Then
            ShowControl = New WeightHousePairOrder.WeightPair
            'MainControlEvent = ShowControl
            Me.Controls.Add(ShowControl)
            ShowControl.Dock = DockStyle.Fill

        End If
    End Sub
End Class
