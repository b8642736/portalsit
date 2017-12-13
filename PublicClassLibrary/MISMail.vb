Imports System.Net.Mail

Public Class MISMail

#Region "SMTP用戶端 屬性:SMTPClient"
    Private _RunSMTPClient As SmtpClient
    ''' <summary>
    ''' SMTP用戶端
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunSMTPClient() As SmtpClient
        Get
            If IsNothing(_RunSMTPClient) Then
                _RunSMTPClient = New SmtpClient("mail.tangeng.com.tw", 25)
                _RunSMTPClient.Credentials = New System.Net.NetworkCredential("mis", "1j4@vu.4")
            End If
            Return _RunSMTPClient
        End Get
        Set(ByVal value As SmtpClient)
            _RunSMTPClient = value
        End Set
    End Property

#End Region
#Region "Mail訊息 屬性:RunMailMessage"
    Private _RunMailMessage As MailMessage
    ''' <summary>
    ''' Mail訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunMailMessage() As MailMessage
        Get
            If IsNothing(_RunMailMessage) Then
                _RunMailMessage = New MailMessage
                _RunMailMessage.IsBodyHtml = False
            End If
            Return _RunMailMessage
        End Get
        Set(ByVal value As MailMessage)
            _RunMailMessage = value
        End Set
    End Property


#End Region
#Region "寄件位置 屬性:FromMailAddress"
    Private _FromMailAddress As MailAddress
    ''' <summary>
    ''' 寄件位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FromMailAddress() As MailAddress
        Get
            If IsNothing(_FromMailAddress) Then
                _FromMailAddress = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            End If
            Return _FromMailAddress
        End Get
        Set(ByVal value As MailAddress)
            _FromMailAddress = value
        End Set
    End Property

#End Region
#Region "收件位置 屬性:ToMailAddress"
    Private _ToMailAddress As New List(Of MailAddress)
    ''' <summary>
    ''' 收件位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToMailAddress() As List(Of MailAddress)
        Get
            Return _ToMailAddress
        End Get
        Set(ByVal value As List(Of MailAddress))
            _ToMailAddress = value
        End Set
    End Property

#End Region

    Sub New()

    End Sub

    Sub New(ByVal setToAddress As List(Of MailAddress))
        Me.ToMailAddress = setToAddress
    End Sub

#Region "傳送Email 方法:SendMail"
    ''' <summary>
    ''' 傳送Email
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Body"></param>
    ''' <param name="ToAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMail(ByVal Subject As String, ByVal Body As String, ByVal ToAddress As List(Of MailAddress)) As Integer
        Me.ToMailAddress = ToMailAddress
        If ToMailAddress.Count = 0 Then
            Return 0
        End If
        SendMail(Subject, Body)
    End Function
    ''' <summary>
    '''  傳送Email
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Body"></param>
    ''' <param name="ToAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMail(ByVal Subject As String, ByVal Body As String, ByVal ToAddress() As MailAddress) As Integer
        For Each EachItem As MailAddress In ToAddress
            Me.ToMailAddress.Add(EachItem)
        Next
        If ToMailAddress.Count = 0 Then
            Return 0
        End If
        SendMail(Subject, Body)
    End Function

    ''' <summary>
    ''' 傳送Email
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Body"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMail(ByVal Subject As String, ByVal Body As String) As Integer
        If ToMailAddress.Count = 0 Then
            Return 0
        End If
        For Each EachItem As MailAddress In ToMailAddress
            Me.RunMailMessage.To.Add(EachItem)
        Next
        Me.RunMailMessage.From = Me.FromMailAddress
        Me.RunMailMessage.Subject = Subject
        Me.RunMailMessage.Body = Body
        Me.RunSMTPClient.Send(RunMailMessage)
    End Function
#End Region

#Region "快速傳Email 函式:QuickSendMail"
    ''' <summary>
    ''' 快速傳Email
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Body"></param>
    ''' <param name="ToAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function QuickSendMail(ByVal Subject As String, ByVal Body As String, ParamArray ToAddress() As String) As Integer
        Dim SendAddress As New List(Of MailAddress)
        For Each EachItem As String In ToAddress
            SendAddress.Add(New MailAddress(EachItem))
        Next
        Dim SendMailObject As New MISMail(SendAddress)
        SendMailObject.SendMail(Subject, Body, SendAddress)
    End Function
    ''' <summary>
    ''' 快速傳Email
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Body"></param>
    ''' <param name="ToAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function QuickSendMail(ByVal Subject As String, ByVal Body As String, ToAddress() As MailAddress) As Integer
        Dim SendMailObject As New MISMail()
        Dim ToMailAddress1 As New List(Of MailAddress)
        For Each Eachitem As MailAddress In ToAddress
            ToMailAddress1.Add(Eachitem)
        Next
        SendMailObject.SendMail(Subject, Body, ToMailAddress1)
    End Function
#End Region

End Class
