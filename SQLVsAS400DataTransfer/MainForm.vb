Public Class MainForm

#Region "PPS100TransControl 屬性:PPS100TransControl"
    Private _PPS100TransControl As PPS100LB_PPSSHAPFToSQLServer
    Public ReadOnly Property PPS100TransControl() As PPS100LB_PPSSHAPFToSQLServer
        Get
            If IsNothing(_PPS100TransControl) Then
                _PPS100TransControl = New PPS100LB_PPSSHAPFToSQLServer
                Panel1.Controls.Add(_PPS100TransControl)
                _PPS100TransControl.Visible = False
            End If
            Return _PPS100TransControl
        End Get
    End Property

#End Region
#Region "CoilElementTransControl  屬性:CoilElementTransControl"
    Private _CoilElementTransControl As CoilElementTrans
    Public ReadOnly Property CoilElementTransControl As CoilElementTrans
        Get
            If IsNothing(_CoilElementTransControl) Then
                _CoilElementTransControl = New CoilElementTrans
                Panel1.Controls.Add(_CoilElementTransControl)
                _CoilElementTransControl.Visible = False
            End If
            Return _CoilElementTransControl
        End Get
    End Property
#End Region

#Region "顯示轉換控制項 函式:DisplayTransControl"
    ''' <summary>
    ''' 顯示轉換控制項
    ''' </summary>
    ''' <param name="ShowType"></param>
    ''' <remarks></remarks>
    Private Sub DisplayTransControl(ByVal ShowType As DisplayTransControlEnum)
        Dim ShowControl As Control = Nothing
        For Each EachItem As ToolStripMenuItem In SQLServer與AS400資料轉換ToolStripMenuItem.DropDownItems
            EachItem.Checked = False
        Next
        For Each EachControl As Control In Panel1.Controls
            EachControl.Visible = False
        Next
        Select Case ShowType
            Case DisplayTransControlEnum.無
            Case DisplayTransControlEnum.軋鋼排程轉SQLServer
                軋鋼排程轉SQLServerToolStripMenuItem.Checked = True
                ShowControl = PPS100TransControl
            Case DisplayTransControlEnum.煉鋼成份轉AS400
                煉鋼成份轉AS400ToolStripMenuItem.Checked = True
                ShowControl = CoilElementTransControl
        End Select
        If Not IsNothing(ShowControl) Then
            ShowControl.Visible = True
            ShowControl.Dock = DockStyle.Fill
        End If
    End Sub
    Private Enum DisplayTransControlEnum
        無 = 0
        軋鋼排程轉SQLServer = 1
        煉鋼成份轉AS400 = 2
    End Enum
#End Region

#Region "設定系統開機自動啟動程式 函式:SetOSStartRunAPP"
    ''' <summary>
    ''' 設定系統開機自動啟動程式
    ''' </summary>
    ''' <param name="AppName"></param>
    ''' <param name="ApplicationFullPath"></param>
    ''' <remarks></remarks>
    Private Sub SetOSStartRunAPP(ByVal AppName As String, ByVal ApplicationFullPath As String)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", AppName, ApplicationFullPath)
        My.Computer.Registry.LocalMachine.Close()
    End Sub
#End Region

#Region "發送Email 函式:SendEamil"
    ''' <summary>
    ''' 發送Email
    ''' </summary>
    ''' <param name="ReceiveAddress"></param>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Private Sub SendMail(ByVal ReceiveAddress As String, ByVal Subject As String, ByVal Message As String)
        Dim mySmtpClient As New System.Net.Mail.SmtpClient("mail.tangeng.com.tw")
        mySmtpClient.UseDefaultCredentials = True
        Dim mail As MailMessage = New MailMessage
        mail.From = New MailAddress("kuku@mail.tangeng.com.tw", "網站通知")
        For Each EachItem As String In ReceiveAddress.Split(";")
            mail.To.Add(New MailAddress(EachItem))
        Next
        mail.Subject = Subject
        mail.Body = Message
        mail.IsBodyHtml = False
        mail.Priority = MailPriority.High
        mySmtpClient.Send(mail)
    End Sub
#End Region


    Public Shared ProgramOpenCount As Integer = 0

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SendMail("kuku@mail.tangeng.com.tw", "鋼肧化學成份傳送AS400轉檔伺服器關閉 訊息! 時間:" & Format(Now, "yyyy/MM/dd HH:mms:ss"), "鋼肧化學成份傳送AS400轉檔伺服器已關閉 時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss"))
        'If MsgBox("是否確定停止此程式並不執行排程資料轉換?", MsgBoxStyle.YesNo, "注意!") = MsgBoxResult.No Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SendMail("kuku@mail.tangeng.com.tw", "鋼肧化學成份傳送AS400轉檔伺服器開啟 訊息! 時間:" & Format(Now, "yyyy/MM/dd HH:mms:ss"), "鋼肧化學成份傳送AS400轉檔伺服器已開啟 時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss"))
        SetOSStartRunAPP("SQLVsAS400DataTransfer", Application.ExecutablePath)
        If System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Application.ExitThread()
        End If
        ProgramOpenCount += 1
        Call 全部啟動_Click(Nothing, Nothing)
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MainForm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub 軋鋼排程轉SQLServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 軋鋼排程轉SQLServerToolStripMenuItem.Click
        DisplayTransControl(DisplayTransControlEnum.軋鋼排程轉SQLServer)
    End Sub

    Private Sub 煉鋼成份轉AS400ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 煉鋼成份轉AS400ToolStripMenuItem.Click
        DisplayTransControl(DisplayTransControlEnum.煉鋼成份轉AS400)
    End Sub

    Private Sub 全部啟動_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全部啟動.Click
        DisplayTransControl(DisplayTransControlEnum.無)
        Me.PPS100TransControl.StartRun()
        Me.CoilElementTransControl.StartRun()
    End Sub

End Class
