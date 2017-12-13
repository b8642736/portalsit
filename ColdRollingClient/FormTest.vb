Public Class FormTest

#Region "L2訊號監控元件 屬性/事件:L2MessageWatchControl"
    WithEvents L2MessageWatchControlEvent As ReceiveL2Message
    Private _L2MessageWatchControl As ReceiveL2Message
    ''' <summary>
    ''' L2訊號監控元件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property L2MessageWatchControl() As ReceiveL2Message
        Get
            If IsNothing(_L2MessageWatchControl) Then
                _L2MessageWatchControl = New ReceiveL2Message("//10.1.4.30/WebRunning/WatchFolderTest/test1.txt")
                L2MessageWatchControlEvent = _L2MessageWatchControl
            End If
            Return _L2MessageWatchControl
        End Get
    End Property

#End Region


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Dim AddControl As New LabelPrint
        'Dim AddControl As New RemoteCoilScanner
        'Me.Controls.Add(AddControl)
        'AddControl.Dock = DockStyle.Fill

        'L2MessageWatchControl.StartWatch()
        MsgBox("start")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Controls.Clear()
        Dim AddControl As New StationClient
        Me.Controls.Add(AddControl)
        AddControl.Dock = DockStyle.Fill
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Controls.Clear()
        Dim AddControl As New LabelPrint
        Me.Controls.Add(AddControl)
        AddControl.Dock = DockStyle.Fill
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim WriteString As String = (New SendStateToL2("10.1.3.22")).ConvertStateToText
        My.Computer.FileSystem.WriteAllText("//10.1.4.30/WebRunning/WatchFolderTest/test2.txt", WriteString, False)
    End Sub

    Private Sub L2MessageWatchControlEvent_FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2Message As L2Message) Handles L2MessageWatchControlEvent.FileChangedEvent
        MsgBox("取得資料:" & L2Message.Message)
    End Sub

    Private Sub btnEmailTest_Click(sender As Object, e As EventArgs) Handles btnEmailTest.Click
        Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)
        Smtp.Credentials = New System.Net.NetworkCredential("mis", "1j4@vu.4")
        Dim SendMessage As New MailMessage
        SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
        SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
        SendMessage.Subject = "軋鋼訊號接收資料異常通知!"
        SendMessage.IsBodyHtml = False
        SendMessage.Body = "接收資料 Test"
        Smtp.Send(SendMessage)
    End Sub
End Class