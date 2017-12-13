Public Class MainForm

    Private Sub MainForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        For Each EachControl As Control In Me.Controls
            EachControl.Dispose()
        Next
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If TypeOf Me.Controls(0) Is StationClient Then
            CType(Me.Controls(0), StationClient).QuickKeyCallSpecialFunction(sender, e)
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("此程式程式請勿開啟兩次,請按確認後15程再重新啟動此程式!")
            For Each EachProcess In Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)
                If Not EachProcess Is Process.GetCurrentProcess Then
                    EachProcess.Kill()
                    EachProcess.Dispose()
                End If
            Next
            Application.Exit()
        End If
        Dim AddControl As New StationClient
        Me.Controls.Add(AddControl)
        AddControl.Dock = DockStyle.Fill
    End Sub

End Class