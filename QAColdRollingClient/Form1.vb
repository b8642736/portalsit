Public Class Form1

    WithEvents MainControlEvent As MainControl

    Private ShowControl As MainControl

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(ShowControl) Then
            ShowControl = New MainControl
            MainControlEvent = ShowControl
            Me.Controls.Add(ShowControl)
            ShowControl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            MainControlEvent.SaveAllControlDataToDB()
        Catch ex As Exception
            MsgBox("離開系統時存檔發生錯誤:" & ex.ToString)
        End Try
    End Sub

    Private Sub MainControlEvent_ExitSystem(Sender As MainControl) Handles MainControlEvent.ExitSystem
        Me.Close()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub
End Class
