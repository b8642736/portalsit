Partial Public Class MessageToSiteUsers
    'Dim WebAPPAuthorityDBDataContext As New WebAPPAuthorityDataContext
    Dim DBDataContext As New IMDataContext
    Dim WebAPPAuthorityDataContext As New WebAPPAuthorityDataContext

#Region "發送訊息至電子郵件信箱 方法:SendMessageToEmail"
    ''' <summary>
    ''' 發送訊息至電子郵件信箱
    ''' </summary>
    ''' <param name="Subject"></param>
    ''' <param name="Content"></param>
    ''' <remarks></remarks>
    Public Sub SendMessageEmail(ByVal Subject As String, ByVal Content As String)
        If IsNothing(AboutSiteUser) Then
            Throw New Exception("無法找到站台使用者SiteUser!")
        End If
        Dim SendMailAddress As String = Nothing
        Select Case True
            Case AboutSiteUser.UserPKeyKind = 1
                If IsNothing(AboutSiteUser.AboutWebClientPCAccount) Then
                    Throw New Exception("無法找到用戶端PC帳號WebClientPCAccount!")
                End If
                SendMailAddress = AboutSiteUser.AboutWebClientPCAccount.Email
            Case AboutSiteUser.UserPKeyKind = 2
                If IsNothing(AboutSiteUser.AboutWebLoginAccount) Then
                    Throw New Exception("無法找到用戶端Windows登入帳號LoginAccount!")
                End If
                SendMailAddress = AboutSiteUser.AboutWebLoginAccount.Email
        End Select


        Dim FromMailAddress As New System.Net.Mail.MailAddress("kuku@mail.tangeng.com.tw", "廠內即時通訊系統系統管理員!")
        Dim ToMailAddress As New System.Net.Mail.MailAddress(SendMailAddress)
        Dim NewMail As New System.Net.Mail.MailMessage(FromMailAddress, ToMailAddress)
        NewMail.Subject = Subject
        NewMail.Body = Content
        Dim Smtp As New System.Net.Mail.SmtpClient("mail.tangeng.com.tw", 25)
        Smtp.Send(NewMail)
    End Sub
#End Region
#Region "相關SiteUser 屬性:AboutSiteUser"

    Private _AboutSiteUser As SiteUser = Nothing
    ''' <summary>
    ''' 相關SiteUser
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutSiteUser() As SiteUser
        Get
            If IsNothing(_AboutSiteUser) Then
                _AboutSiteUser = (From A In DBDataContext.SiteUser Where A.ID = Me.FK_ToSiteUsersID Select A).FirstOrDefault
            End If
            Return _AboutSiteUser
        End Get
        Private Set(ByVal value As SiteUser)
            _AboutSiteUser = value
        End Set
    End Property

#End Region

#Region "發送者資訊 屬性:SenderInformation"
    Shared _ALLWebLoginAccount As List(Of WebLoginAccount) = Nothing
    Shared _ALLWebClientPCAccount As List(Of WebClientPCAccount) = Nothing
    Private _SenderInformation As String = Nothing
    ''' <summary>
    ''' 發送者資訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SenderInformation() As String
        Get
            If IsNothing(_SenderInformation) Then
                If IsNothing(_ALLWebLoginAccount) Then
                    _ALLWebLoginAccount = (From A In WebAPPAuthorityDataContext.WebLoginAccount).ToList
                End If
                If IsNothing(_ALLWebClientPCAccount) Then
                    _ALLWebClientPCAccount = (From A In WebAPPAuthorityDataContext.WebClientPCAccount).ToList
                End If
                If Not String.IsNullOrEmpty(Me.FromWindowLoginName) AndAlso Me.FromWindowLoginName.Trim.Length > 0 Then
                    For Each EachItem As WebLoginAccount In _ALLWebLoginAccount
                        If EachItem.WindowLoginName.Trim = Me.FromWindowLoginName.Trim Then
                            _SenderInformation &= "Window 帳號:" & EachItem.WindowLoginName.Trim
                            If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                _SenderInformation &= "(" & EachItem.Memo1.Trim & ")"
                            End If
                            Exit For
                        End If
                    Next
                End If
                If Not String.IsNullOrEmpty(Me.FromClientIP) AndAlso Me.FromClientIP.Trim.Length > 0 AndAlso FromClientIP.Trim <> "127.0.0.1" Then
                    For Each EachItem As WebClientPCAccount In _ALLWebClientPCAccount
                        If EachItem.ClientIP.Trim = Me.FromClientIP.Trim Then
                            _SenderInformation &= IIf(IsNothing(_SenderInformation), Nothing, "/")
                            _SenderInformation &= "電腦IP:" & EachItem.ClientIP.Trim
                            If Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0 Then
                                _SenderInformation &= "(" & EachItem.Memo1.Trim & ")"
                            End If
                            Exit For
                        End If
                    Next

                End If
            End If
            Return _SenderInformation
        End Get
    End Property
#End Region

#Region "訊息接收者資訊 屬性:ReceiverInformation"
    Private _ReceiverInformation As String = Nothing
    Shared _AllSiteUser As List(Of SiteUser) = Nothing
    ''' <summary>
    ''' 訊息接收者資訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ReceiverInformation() As String
        Get
            If IsNothing(_ReceiverInformation) Then
                If IsNothing(_AllSiteUser) Then
                    _AllSiteUser = (From A In DBDataContext.SiteUser).ToList
                End If
                Dim FindAboutSiteUser As SiteUser = Nothing
                For Each EachItem As SiteUser In _AllSiteUser
                    If EachItem.ID = Me.FK_ToSiteUsersID Then
                        FindAboutSiteUser = EachItem
                        Exit For
                    End If
                Next
                If IsNothing(FindAboutSiteUser) Then
                    Return "未知 SiteUser=" & Me.FK_ToSiteUsersID
                End If
                If FindAboutSiteUser.UserPKeyKind = 1 Then
                    '使用IP
                    If IsNothing(_ALLWebClientPCAccount) Then
                        _ALLWebClientPCAccount = (From A In WebAPPAuthorityDataContext.WebClientPCAccount).ToList
                    End If
                    For Each EachItem As WebClientPCAccount In _ALLWebClientPCAccount
                        If EachItem.ClientIP.Trim = FindAboutSiteUser.UserPKey.Trim Then
                            _ReceiverInformation = "電腦" & EachItem.PCIPAndMemo1
                            Exit For
                        End If
                    Next
                Else
                    '使用WindowName
                    If IsNothing(_ALLWebLoginAccount) Then
                        _ALLWebLoginAccount = (From A In WebAPPAuthorityDataContext.WebLoginAccount).ToList
                    End If
                    For Each EachItem As WebLoginAccount In _ALLWebLoginAccount
                        If EachItem.WindowLoginName.Trim = FindAboutSiteUser.UserPKey.Trim Then
                            _ReceiverInformation = EachItem.WindowLoginNameAndMemo1
                            Exit For
                        End If
                    Next
                End If
            End If
            Return _ReceiverInformation
        End Get
    End Property
#End Region

End Class
