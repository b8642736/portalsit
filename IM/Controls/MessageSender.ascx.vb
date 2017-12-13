Public Partial Class MessageSender
    Inherits System.Web.UI.UserControl

    Dim SMPDataContext As New CompanyLINQDB.SMPDataContext

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region

#Region "預備傳送訊息 屬性:PreSendMessage"
    ''' <summary>
    ''' 預備傳送訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreSendMessage() As CompanyLINQDB.Message
        Get
            Return Me.Session("_PreSendMessage")
        End Get
        Set(ByVal value As CompanyLINQDB.Message)
            If IsNothing(value) OrElse Not (value Is Me.Session("_PreSendMessage")) Then
                SendMessageBatchNumber = Guid.NewGuid.ToString
            End If
            Me.Session("_PreSendMessage") = value
        End Set
    End Property

#End Region
#Region "傳送訊息批號 屬性:SendMessageBatchNumber"
    ''' <summary>
    ''' 傳送訊息批號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SendMessageBatchNumber() As String
        Get
            Return Me.Session("_SendMessageBatchNumber")
        End Get
        Private Set(ByVal value As String)
            Me.Session("_SendMessageBatchNumber") = value
        End Set
    End Property
#End Region


#Region "發送者SiteUser 屬性:SenderSiteUser"
    ''' <summary>
    ''' 發送者SiteUser
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SenderSiteUser() As List(Of SiteUser)
        Get
            Dim UserHostAddress As New List(Of String)
            UserHostAddress.Add(Request.ServerVariables("REMOTE_ADDR"))
            For Each EachIP As String In CompanyORMDB.DeviceInformation.GetLocalIPs
                If EachIP.Count > 0 AndAlso EachIP.Substring(0, 1) <> ":" Then
                    UserHostAddress.Add(EachIP)
                    Exit For
                End If
            Next
            Dim UserName As String = "D9F2AA6B-EAC8-4b0f-A287-B90F79F758D0"
            If Request.LogonUserIdentity.Name.Split("\").Count > 0 Then
                UserName = Request.LogonUserIdentity.Name.Split("\")(1)
            End If

            Return (From C In DBDataContext.SiteUser Where (C.UserPKeyKind = 2 And C.UserPKey = UserName) Or (C.UserPKeyKind = 1 And UserHostAddress.Contains(C.UserPKey)) Select C).ToList
        End Get
    End Property
#End Region
#Region "找尋訊息接收者(除發送者本身以外) 方法:FindMessageSiteUsers"
    ''' <summary>
    ''' 找尋訊息接收者(除發送者本身以外)
    ''' </summary>
    ''' <param name="FindMessageID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindMessageSiteUsers(ByVal FindMessageID As String) As List(Of SiteUser)
        Dim FindSiteGroupToMessage As IQueryable(Of SiteGroupToMessage) = From A In DBDataContext.SiteGroupToMessage Where A.FK_MessageID = FindMessageID And (A.ReadWriteMode = 0 Or A.ReadWriteMode = 2) Select A
        Dim FindSiteGroupToSite As IQueryable(Of SiteGroupToSite) = From A In DBDataContext.SiteGroupToSite Where (From B In FindSiteGroupToMessage Select B.FK_SiteGroupID).ToList.Contains(A.FK_SiteGroupID) Select A
        Return (From A In DBDataContext.SiteUser Where (Not SenderSiteUser.Contains(A)) And (From B In FindSiteGroupToSite Select B.FK_SiteID).ToList.Contains(A.FK_SiteID) Select A).ToList
    End Function


#End Region

#Region "已傳送成功之RemoteClient 屬性:SuccessSendedRemoteClients"
    ''' <summary>
    ''' 已傳送成功之RemoteClient
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SuccessSendedRemoteClients() As List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
        Get
            If IsNothing(Session("_SuccessSendedRemoteClients")) Then
                Session("_SuccessSendedRemoteClients") = New List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
            End If
            Return Session("_SuccessSendedRemoteClients")
        End Get
        Set(ByVal value As List(Of CompanyORMDB.SQLServer.IM.RemoteClient))
            Session("_SuccessSendedRemoteClients") = value
        End Set
    End Property

#End Region

#Region "將傳送訊息儲至資料庫 函式:SaveSendMessageToDB"
    ''' <summary>
    ''' 將傳送訊息儲至資料庫
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SaveSendMessageToDB() As List(Of MessageToSiteUsers)
        Dim ReturnValue As New List(Of MessageToSiteUsers)
        If Not IsNothing(PreSendMessage) Then
            Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
            Dim SendToUsers As List(Of SiteUser) = FindMessageSiteUsers(PreSendMessage.ID)
            'Dim AddItems As New List(Of MessageToSiteUsers)
            Dim SendTime As DateTime = WSAdapter.GetServerTime : SendTime = SendTime.AddMilliseconds(-SendTime.Millisecond)
            For Each EachItem As SiteUser In SendToUsers
                Dim AddItem As New MessageToSiteUsers
                With AddItem
                    .SendMessageBatchNumber = Me.SendMessageBatchNumber
                    .ReceiveTime = New Date(2000, 1, 1)     '給初始值
                    .FinalRecieveTime = .ReceiveTime        '給初始值
                    .NotSendReplyTime = .ReceiveTime        '給初始值
                    .SenderReceivedNotSendReplyTime = .ReceiveTime  '給初始值
                    .SystemFirstReceiveTime = .ReceiveTime  '給初始值
                    .SystemLastReceiveTime = .ReceiveTime   '給初始值

                    .FK_MessageID = PreSendMessage.ID
                    .FK_ToSiteID = EachItem.FK_SiteID
                    .FK_ToSiteUsersID = EachItem.ID
                    .SendTime = SendTime
                    .MsgText = tbMsgName.Text.Trim
                    .AddMsgContent = tbAddMessage.Text.Trim
                    Dim UserAddress As String = Page.Request.UserHostAddress.Trim
                    UserAddress = IIf(UserAddress.Substring(0, 1) = ":", "127.0.0.1", UserAddress)
                    If WebAppAuthority.CurrentLoginMode = WebAppAuthority.LoginAuthorityModeType.WindowsAuthority Then
                        .FromWindowLoginName = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
                        .FromClientIP = UserAddress
                    Else
                        .FromClientIP = UserAddress
                    End If

                    '.FromWindowLoginName = Request.UserHostName
                    '.FromClientIP = Request.UserHostAddress
                    .IsHaveFinalRecieveTime = PreSendMessage.IsHaveFinalRecieveTime
                    If .IsHaveFinalRecieveTime Then
                        .FinalRecieveTime = SendTime.AddMinutes(PreSendMessage.FinalRecieveMinuteSpan)
                    End If
                    .IsReceived = False
                    .IsHaveNotSendReplye = PreSendMessage.IsHaveNotSendReplyTime
                    If .IsHaveNotSendReplye Then
                        .NotSendReplyTime = SendTime.AddMinutes(PreSendMessage.NotSendReplyMinuteSpan)
                    End If
                    If PreSendMessage.IsNeedSendEmail Then
                        Select Case True
                            Case EachItem.UserPKeyKind = 1 AndAlso Not IsNothing(EachItem.AboutWebClientPCAccount)
                                .ToSendEmailAddress = EachItem.AboutWebClientPCAccount.Email
                            Case EachItem.UserPKeyKind = 2 AndAlso Not IsNothing(EachItem.AboutWebLoginAccount)
                                .ToSendEmailAddress = EachItem.AboutWebLoginAccount.Email
                        End Select
                    End If
                End With
                ReturnValue.Add(AddItem)
            Next
            Me.DBDataContext.MessageToSiteUsers.InsertAllOnSubmit(ReturnValue)
            Me.DBDataContext.SubmitChanges()
            Return ReturnValue
            Try
                If PreSendMessage.IsNeedSendEmail Then
                    For Each EachItem As MessageToSiteUsers In ReturnValue
                        EachItem.SendMessageEmail(EachItem.MsgText, EachItem.AddMsgContent)
                    Next
                End If
            Catch ex As Exception

            End Try

        End If
        Return ReturnValue
    End Function
#End Region

#Region "通知所有上線用戶接收端更新資料  函式:NoticeClientReceiveMessage"
    ''' <summary>
    ''' 通知所有上線用戶接收端更新資料
    ''' </summary>
    ''' <remarks>回傳已成功傳送之RemoteClient</remarks>
    Private Function NoticeClientReceiveMessage(ByVal IsReNoticeUnSendedMessage As Boolean) As List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
        Dim RetrunValue As New List(Of CompanyORMDB.SQLServer.IM.RemoteClient)
        CompanyORMDB.SQLServer.IM.SMPMessageNotice.ReLoadClientConnectToServersFromDB(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice))
        Dim ErrorMessage As String = Nothing
        Dim NoticeClients As List(Of CompanyORMDB.SQLServer.IM.RemoteClient) = CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServersOnline(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice), 3)
        If IsReNoticeUnSendedMessage Then
            If SuccessSendedRemoteClients.Count > 0 Then
                Dim SuccessSendedRemoteClientKeys As List(Of String) = (From A In SuccessSendedRemoteClients Select A.ConnectToRemoteServer.CPUNumber & A.ConnectToRemoteServer.RegisterClassName & A.ConnectToRemoteServer.Port & A.ConnectToRemoteServer.RemoteProtocol).ToList
                NoticeClients = (From A In NoticeClients Where Not SuccessSendedRemoteClientKeys.Contains(A.ConnectToRemoteServer.CPUNumber & A.ConnectToRemoteServer.RegisterClassName & A.ConnectToRemoteServer.Port & A.ConnectToRemoteServer.RemoteProtocol) Select A).ToList
            End If
        End If
        For Each EachItem As CompanyORMDB.SQLServer.IM.RemoteClient In NoticeClients
            Try
                Dim RemoteObject As CompanyORMDB.SQLServer.IM.SMPMessageNotice = EachItem.RemoteClientProxyObject
                RemoteObject.NoticeToReceiveDBMessage()
                RetrunValue.Add(EachItem)
            Catch ex As Exception
                ErrorMessage &= IIf(IsNothing(ErrorMessage), Nothing, vbNewLine) & ex.ToString
            End Try
        Next
        SuccessSendedRemoteClients.AddRange(RetrunValue)



        'Dim FailSendRemoteClients As New List(Of CompanyORMDB.SQLServer.IM.RemoteClient)

        'If IsNothing(NoticeRemoteClients) OrElse NoticeRemoteClients.Count = 0 Then
        '    FailRealTimeSendRemoteClients.Clear()
        '    'NoticeClients = CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServersOnline(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice), 3)
        '    Dim ALLRemoteClientConnectToServers As List(Of CompanyORMDB.SQLServer.IM.RemoteClient) = (From A In CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServers(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice))).ToList
        '    FailSendRemoteClients.AddRange((From A In CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServers(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice)) Where Not NoticeClients.Contains(A) Select A).ToList)
        'Else
        '    Dim OnlineClients As List(Of String) = (From A In CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServersOnline(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice), 3) Select A.ConnectToRemoteServer.CPUNumber).ToList
        '    NoticeClients = (From A In NoticeRemoteClients Where OnlineClients.Contains(A.ConnectToRemoteServer.CPUNumber) Select A).ToList
        '    FailSendRemoteClients.AddRange((From A In NoticeRemoteClients Where Not NoticeClients.Contains(A) Select A).ToList())
        'End If

        'For Each EachItem As CompanyORMDB.SQLServer.IM.RemoteClient In NoticeClients
        '    Try
        '        Dim RemoteObject As CompanyORMDB.SQLServer.IM.SMPMessageNotice = EachItem.RemoteClientProxyObject
        '        RemoteObject.NoticeToReceiveDBMessage()
        '        RetrunValue.Add(EachItem)
        '    Catch ex As Exception
        '        FailSendRemoteClients.Add(EachItem)
        '        ErrorMessage &= IIf(IsNothing(ErrorMessage), Nothing, vbNewLine) & ex.ToString
        '    End Try
        'Next

        'FailRealTimeSendRemoteClients = FailSendRemoteClients

        Return RetrunValue
    End Function
#End Region

#Region "重整顯示預計傳送或訊息接收狀態 函式:RefreshShowSendMessageToSiteUserState"
    ''' <summary>
    ''' 重整顯示預計傳送或訊息接收狀態
    ''' </summary>
    ''' <param name="IsShowSended"></param>
    ''' <remarks></remarks>
    Private Sub RefreshShowSendMessageToSiteUserState(ByVal IsShowSended As Boolean)
        tbPrepareReceiverUsers.ForeColor = Drawing.Color.Blue
        If IsNothing(PreSendMessage) Then
            tbPrepareReceiverUsers.Text = Nothing
            Exit Sub
        End If
        '取得此次傳送之所有所有MessageToSiteUser
        Dim ShowMessage As String = Nothing
        Dim GetAllMessageToSiteUser As List(Of MessageToSiteUsers) = Nothing

        btnReSendMessage.Enabled = False
        If IsShowSended Then
            lbReceiverState.Text = "無法接收者清單"
            GetAllMessageToSiteUser = (From A In DBDataContext.MessageToSiteUsers Where A.SendMessageBatchNumber = Me.SendMessageBatchNumber And A.SystemFirstReceiveTime <= (New Date(2000, 1, 1)) Select A).ToList
            For Each EachItem As MessageToSiteUsers In GetAllMessageToSiteUser
                ShowMessage &= IIf(IsNothing(ShowMessage), Nothing, vbNewLine)
                Dim AboutSiteUser As SiteUser = EachItem.AboutSiteUser
                If IsNothing(AboutSiteUser) Then
                    ShowMessage &= "未知(使者已被移除)!"
                Else
                    ShowMessage &= AboutSiteUser.PCNameOrUserName
                End If
            Next
            btnReSendMessage.Enabled = GetAllMessageToSiteUser.Count > 0
            tbPrepareReceiverUsers.ForeColor = Drawing.Color.Red
        Else
            lbReceiverState.Text = "接收者清單"
            GetAllMessageToSiteUser = (From A In DBDataContext.MessageToSiteUsers Where A.SendMessageBatchNumber = Me.SendMessageBatchNumber Select A).ToList
            For Each EachItem As MessageToSiteUsers In GetAllMessageToSiteUser
                ShowMessage &= IIf(IsNothing(ShowMessage), Nothing, vbNewLine)
                ShowMessage &= EachItem.AboutSiteUser.PCNameOrUserName
            Next
        End If
        tbPrepareReceiverUsers.Text = ShowMessage
    End Sub
#End Region

#Region "加入爐號之控制項 屬性:InsertStoveNumberControl"
    ''' <summary>
    ''' 插入爐號之控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InsertStoveNumberControl() As TextBox
        Get
            Return Session("_InsertStoveNumberControl")
        End Get
        Set(ByVal value As TextBox)
            Session("_InsertStoveNumberControl") = value
        End Set
    End Property
#End Region


    Dim DBDataContext As New CompanyLINQDB.IMDataContext
    Dim WebAPPAuthorityDataContext As New WebAPPAuthorityDataContext

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        lbMsg.Visible = False
        tbPrepareReceiverUsers.Text = Nothing
        SuccessSendedRemoteClients = Nothing
        RefreshShowSendMessageToSiteUserState(False)
        btnSendMsg.Enabled = False
        Dim GetMsgID As String = GridView1.SelectedValue
        If Not IsNothing(GetMsgID) Then
            Me.PreSendMessage = (From A In DBDataContext.Message Where A.ID = GetMsgID Select A).FirstOrDefault
            Me.tbMsgName.Text = PreSendMessage.MsgText.Trim
            Dim SendToUsers As List(Of SiteUser) = FindMessageSiteUsers(GetMsgID)
            Dim ReceiverMsg As String = Nothing
            For Each EachItem As CompanyLINQDB.SiteUser In SendToUsers
                ReceiverMsg &= IIf(IsNothing(ReceiverMsg), Nothing, vbNewLine)
                ReceiverMsg &= EachItem.PCNameOrUserName
            Next
            tbPrepareReceiverUsers.Text = ReceiverMsg
            btnSendMsg.Enabled = SendToUsers.Count > 0
            lbMsg.Text = IIf(SendToUsers.Count = 0, "無任何訊息接收者無法發送訊息!", "合計有 " & SendToUsers.Count & " 位訊息接收者!")
            lbMsg.Visible = True
        End If
    End Sub

    Protected Sub btnSendMsg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSendMsg.Click
        Dim SendMesageToSiteUsers As List(Of MessageToSiteUsers) = SaveSendMessageToDB()
        lbMsg.Text = "已成功發送" & SendMesageToSiteUsers.Count & " 則訊息等待接收!"
        lbMsg.Visible = True
        lbMsg.Text &= "(上線者含本機共:" & NoticeClientReceiveMessage(False).Count & "位)"
        Threading.Thread.Sleep(1000)
        RefreshShowSendMessageToSiteUserState(True)

        GridView1.SelectedIndex = -1
        btnSendMsg.Enabled = False
        tbAddMessage.Text = Nothing
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.tbMsg.Text = Nothing
        If Me.ddlReceiverWindowsLogin.Items.Count > 0 Then
            Me.ddlReceiverWindowsLogin.SelectedIndex = 0
        End If
        If Me.ddlRecieverPC.Items.Count > 0 Then
            Me.ddlRecieverPC.SelectedIndex = 0
        End If
        If Me.ddlSenderWindowsLogin.Items.Count > 0 Then
            Me.ddlSenderWindowsLogin.SelectedIndex = 0
        End If
        If Me.ddlSenderPC.Items.Count > 0 Then
            Me.ddlSenderPC.SelectedIndex = 0
        End If
        RadioButtonList1.SelectedIndex = 0
        Me.IsUserAlreadyPutSearch = False
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        Me.IsUserAlreadyPutSearch = False
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        Me.GridView2.DataBind()
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If
        Dim ReturnValue As IQueryable(Of MessageToSiteUsers) = From A In DBDataContext.MessageToSiteUsers Where A.SendTime >= CType(Me.tbStartDate.Text, DateTime) And A.SendTime < CType(Me.tbEndDate.Text, DateTime).AddDays(1) Select A
        If Not String.IsNullOrEmpty(tbMsg.Text) AndAlso tbMsg.Text.Trim.Length > 0 Then
            ReturnValue = From A In ReturnValue Where A.MsgText Like "*" & tbMsg.Text & "*" Select A
        End If
        If ddlSenderPC.SelectedValue <> "ALL" Then
            ReturnValue = From A In ReturnValue Where A.FromClientIP.Trim = ddlSenderPC.SelectedValue.Trim Select A
        End If
        If ddlSenderWindowsLogin.SelectedValue <> "ALL" Then
            ReturnValue = From A In ReturnValue Where A.FromWindowLoginName.Trim = ddlSenderWindowsLogin.SelectedValue.Trim Select A
        End If
        If ddlRecieverPC.SelectedValue <> "ALL" Then
            ReturnValue = From A In ReturnValue Where (From B In DBDataContext.SiteUser Where B.UserPKeyKind = 1 And B.UserPKey.Trim = ddlRecieverPC.SelectedValue.Trim Select B.ID).ToList.Contains(A.FK_ToSiteUsersID) Select A
        End If
        If ddlReceiverWindowsLogin.SelectedValue <> "ALL" Then
            ReturnValue = From A In ReturnValue Where (From B In DBDataContext.SiteUser Where B.UserPKeyKind = 2 And B.UserPKey.Trim = ddlReceiverWindowsLogin.SelectedValue.Trim Select B.ID).ToList.Contains(A.FK_ToSiteUsersID) Select A
        End If
        If RadioButtonList1.SelectedValue <> "ALL" Then
            ReturnValue = From A In ReturnValue Where A.IsReceived = RadioButtonList1.SelectedValue Select A
        End If
        e.Result = ReturnValue
    End Sub

    Protected Sub btnReSendMessage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReSendMessage.Click
        Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)
        lbMsg.Text = "重送訊息!(線上已接收者:" & NoticeClientReceiveMessage(True).Count & "位) 時間:" & WSAdapter.GetServerTime.ToString
        Threading.Thread.Sleep(1000)
        RefreshShowSendMessageToSiteUserState(True)
    End Sub

    Protected Sub ldsMessage_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsMessage.Selecting
        Dim FindSiteGroupToSite As IQueryable(Of SiteGroupToSite) = From A In DBDataContext.SiteGroupToSite Where (From B In SenderSiteUser Select B.FK_SiteID).ToList.Contains(A.FK_SiteID) Select A
        Dim FindSiteGroupToMessage As IQueryable(Of SiteGroupToMessage) = From A In DBDataContext.SiteGroupToMessage Where (From B In FindSiteGroupToSite Select B.FK_SiteGroupID).ToList.Contains(A.FK_SiteGroupID) And (A.ReadWriteMode = 0 Or A.ReadWriteMode = 1) Select A
        e.Result = From A In DBDataContext.Message Where (From B In FindSiteGroupToMessage Select B.FK_MessageID).ToList.Contains(A.ID) Select A
    End Sub

    Private Sub tbStartDate_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStartDate.PreRender, tbEndDate.PreRender
        If Not IsPostBack Then
            If String.IsNullOrEmpty(tbStartDate.Text) OrElse tbStartDate.Text.Trim.Length > 0 Then
                tbStartDate.Text = Format(Now.AddDays(-1), "yyyy/MM/dd")
            End If
            If String.IsNullOrEmpty(tbEndDate.Text) OrElse tbEndDate.Text.Trim.Length > 0 Then
                tbEndDate.Text = Format(Now, "yyyy/MM/dd")
            End If
        End If
    End Sub

    Protected Sub ldsSenderPC_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSenderPC.Selecting, ldsSenderPC0.Selecting
        If IsPostBack Then
            e.Cancel = True
            Exit Sub
        End If
        Dim ALLItem As New CompanyLINQDB.WebClientPCAccount
        ALLItem.ClientIP = "ALL"
        ALLItem.Memo1 = "全部"
        Dim AllSiteUserIP As List(Of String) = (From B In DBDataContext.SiteUser Where B.UserPKeyKind = 1 Select B.UserPKey.Trim).ToList
        Dim Result As List(Of CompanyLINQDB.WebClientPCAccount) = (From A In WebAPPAuthorityDataContext.WebClientPCAccount Where AllSiteUserIP.Contains(A.ClientIP.Trim) Select A).ToList
        Result.Insert(0, ALLItem)
        e.Result = Result
    End Sub

    Protected Sub ldsSenderWindowLoginUser_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSenderWindowLoginUser.Selecting, ldsSenderWindowLoginUser0.Selecting
        If IsPostBack Then
            e.Cancel = True
            Exit Sub
        End If
        Dim ALLItem As New CompanyLINQDB.WebLoginAccount
        ALLItem.WindowLoginName = "ALL"
        ALLItem.Memo1 = "全部"
        Dim AllSiteUserWindowLoginName As List(Of String) = (From B In DBDataContext.SiteUser Where B.UserPKeyKind = 2 Select B.UserPKey.Trim).ToList
        Dim Result As List(Of CompanyLINQDB.WebLoginAccount) = (From A In WebAPPAuthorityDataContext.WebLoginAccount Where AllSiteUserWindowLoginName.Contains(A.WindowLoginName.Trim) Select A).ToList
        Result.Insert(0, ALLItem)
        e.Result = Result
    End Sub

    Protected Sub btnReshAddStoveNumber_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReshAddStoveNumber.Click
        Me.GridView3.DataBind()
    End Sub

    Private Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        tbMsgName.Text &= GridView3.SelectedValue.ToString.Trim
        Me.Accordion1.SelectedIndex = 0
    End Sub

    Private Sub ldsSelectStoveNumber_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSelectStoveNumber.Selecting
        Dim SearchReslut As New List(Of 分析資料)
        For Each EachItem As 分析資料 In (From A In SMPDataContext.分析資料 Select A Take 50 Order By A.日期 Descending, A.時間 Descending).ToList
            If Not (From A In SearchReslut Select A.爐號).Contains(EachItem.爐號) Then
                SearchReslut.Add(EachItem)
                If SearchReslut.Count > 16 Then
                    Exit For
                End If
            End If
        Next
        e.Result = (From A In SearchReslut Order By A.爐號).ToList
    End Sub
End Class