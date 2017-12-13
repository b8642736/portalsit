Public Class TLLForm

    Private Sub TLLForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Controls.Clear()
        Dim AddControl As New CoilScanAndMachineProcess
        Me.Controls.Add(AddControl)
        AddControl.Dock = DockStyle.Fill

    End Sub
End Class