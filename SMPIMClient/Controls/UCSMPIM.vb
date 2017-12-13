Public Class UCSMPIM

    WithEvents SMPMessageNoticeObjectEvent As SMPMessageNotice

    Dim WSAdapter As New CompanyORMDB.WSDBSQLQueryAdapter(True)

#Region "訊息傳送接收物件 屬性:SMPMessageNoticeObject"

    Private _SMPMessageNoticeObject As SMPMessageNotice

    ''' <summary>
    ''' 訊息傳送接收物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SMPMessageNoticeObject() As SMPMessageNotice
        Get
            Return _SMPMessageNoticeObject
        End Get
        Set(ByVal value As SMPMessageNotice)
            _SMPMessageNoticeObject = value
            SMPMessageNoticeObjectEvent = value
        End Set
    End Property
#End Region

#Region "啟動訊息傳送接收物件 函式:StartSMPMessageNoticeObject"
    ''' <summary>
    ''' 啟動訊息傳送接收物件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartSMPMessageNoticeObject() As Boolean
        Try
            SMPMessageNoticeObject = New SMPMessageNotice
            SMPMessageNoticeObject = SMPMessageNoticeObject.StartUseOrCreateUseLocalRemoteServer.AboutRemoteClient.RemoteClientProxyObject
            Return Not IsNothing(SMPMessageNoticeObject)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
#End Region

#Region "現在檢示之MessageToSiteUserWindowNode 屬性:CurrentShowMessageToSiteUserWindowNode"

    Private _CurrentShowMessageToSiteUserWindowNode As MessageToSiteUserWindowNode
    ''' <summary>
    ''' 現在檢示之MessageToSiteUserWindowNode
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentShowMessageToSiteUserWindowNode() As MessageToSiteUserWindowNode
        Get
            Return _CurrentShowMessageToSiteUserWindowNode
        End Get
        Private Set(ByVal value As MessageToSiteUserWindowNode)
            _CurrentShowMessageToSiteUserWindowNode = value
            tsbCheckOne.Enabled = Not IsNothing(_CurrentShowMessageToSiteUserWindowNode)
            lbMsgText.Text = "<訊息名稱>"
            lbSendTime.Text = "<發送時間>"
            lbSenderInfo.Text = "<發送訊息來源>"
            lbSeceiverInfo.Text = "<訊息接收者資訊>"
            RichTextBox1.Text = Nothing
            lbSenderInfo.ForeColor = Color.Black
            lbSeceiverInfo.ForeColor = Color.Black
            If Not IsNothing(_CurrentShowMessageToSiteUserWindowNode) Then
                With _CurrentShowMessageToSiteUserWindowNode
                    lbMsgText.Text = .OrginMessageToSiteUsers.MsgText
                    lbSendTime.Text = .OrginMessageToSiteUsers.SendTime
                    lbSenderInfo.Text = .OrginMessageToSiteUsers.SenderInformation
                    lbSeceiverInfo.Text = .OrginMessageToSiteUsers.ReceiverInformation
                    RichTextBox1.Text = .OrginMessageToSiteUsers.AddMsgContent
                End With
                If TypeOf (_CurrentShowMessageToSiteUserWindowNode) Is MessageToSiteUserWindowNode Then
                    If _CurrentShowMessageToSiteUserWindowNode.Parent.Name = "NewNode" Then
                        lbSenderInfo.ForeColor = Color.Red
                    Else
                        lbSeceiverInfo.ForeColor = Color.Red
                    End If
                End If
            End If
        End Set
    End Property

#End Region
#Region "確認讀取目前顯示訊息 函式:CheckReadCurrentShowMessage"
    ''' <summary>
    ''' 確認讀取目前顯示訊息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckReadCurrentShowMessage()
        If IsNothing(TreeView1.SelectedNode) OrElse Not TypeOf TreeView1.SelectedNode Is MessageToSiteUserWindowNode Then
            Exit Sub
        End If
        Dim SelectNode As MessageToSiteUserWindowNode = TreeView1.SelectedNode
        Dim SelectParentNode As TreeNode = SelectNode.Parent
        Dim SelectObject As MessageToSiteUsers = SelectNode.OrginMessageToSiteUsers

        If SelectParentNode.Name.ToUpper = "NEWNODE" Then
            SelectObject.ReceiveTime = WSAdapter.GetServerTime
            SelectObject.IsReceived = True
        Else
            SelectObject.IsSenderReceiveNotSendReplye = True
            SelectObject.SenderReceivedNotSendReplyTime = WSAdapter.GetServerTime
        End If
        If SelectObject.CDBSave > 0 Then
            tsslMessage.Text = SelectObject.MsgText.Trim & " 已確認完成!"
            Me.TreeView1.Nodes.Remove(SelectNode)
        Else
            tsslMessage.Text = SelectObject.MsgText.Trim & " 確認失敗!"
        End If

        If SelectParentNode.Name.ToUpper = "NEWNODE" Then
            Call ReGETCannotSendCheckMessage()
        Else
            Call ReGETWaitCheckMessage(Nothing)
        End If
        Call ResetRefreshBackNodeTimer()

    End Sub
#End Region
#Region "確認所有選擇訊息 函式:CheckAllSelectMessage"
    ''' <summary>
    ''' 確認所有選擇訊息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckAllSelectMessage(ByVal IsTransforMsgToNextClass As Boolean)
        Dim NewSubNode() As TreeNode = TreeView1.Nodes.Find("NewNode", False)
        Dim BackSubNode() As TreeNode = TreeView1.Nodes.Find("BackNode", False)
        Dim ServerTime As DateTime = WSAdapter.GetServerTime
        'Dim SiteUserDataCache As List(Of SiteUser) = SiteUser.GetALLSiteUsers((New SiteUser).CDBCurrentUseSQLQueryAdapter)
        Dim WillCheckNodes As New List(Of MessageToSiteUserWindowNode)
        For Each EachNode As MessageToSiteUserWindowNode In NewSubNode(0).Nodes
            Dim SelectObject As MessageToSiteUsers = EachNode.OrginMessageToSiteUsers
            'If EachNode.Checked AndAlso (SelectObject.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.Receiver OrElse SelectObject.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.SenderAndReceiver) AndAlso SelectObject.ReceiverMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck Then
            'End If
            If EachNode.Checked Then
                SelectObject.ReceiveTime = ServerTime
                SelectObject.IsReceived = True
                'SelectObject.IsWaitReceived2Check = IsTransforMsgToNextClass
                SelectObject.WaitReceived2CheckIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
                WillCheckNodes.Add(EachNode)
            End If
        Next
        For Each EachNode As MessageToSiteUserWindowNode In BackSubNode(0).Nodes
            Dim SelectObject As MessageToSiteUsers = EachNode.OrginMessageToSiteUsers
            If EachNode.Checked Then
                SelectObject.IsSenderReceiveNotSendReplye = True
                SelectObject.SenderReceivedNotSendReplyTime = ServerTime
                'SelectObject.IsWaitReceived2Check = IsTransforMsgToNextClass
                SelectObject.WaitReceived2CheckIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
                WillCheckNodes.Add(EachNode)
            End If
        Next
        Dim CheckSuccessCount As Integer = 0
        Dim CheckFailCount As Integer = 0
        Dim ErrMsg As String = Nothing
        For Each EachNode As MessageToSiteUserWindowNode In WillCheckNodes
            Try
                If EachNode.OrginMessageToSiteUsers.CDBSave > 0 Then
                    CheckSuccessCount += 1
                End If
            Catch ex As Exception
                CheckFailCount += 1
                ErrMsg &= IIf(IsNothing(ErrMsg), Nothing, vbNewLine)
                ErrMsg &= ex.ToString
            End Try
        Next
        tsslMessage.Text = "有" & CheckSuccessCount & " 筆資料已確認完成!"
        If CheckFailCount > 0 Then
            tsslMessage.Text &= "(" & (WillCheckNodes.Count - CheckSuccessCount) & " 筆資料確認失敗!)"
            MsgBox(ErrMsg, MsgBoxStyle.OkOnly, "確認失敗錯誤訊息!")
        End If

        Call ReGETCannotSendCheckMessage()
        Call ReGETWaitCheckMessage(Nothing)
        Call ResetRefreshBackNodeTimer()
        TreeView1.SelectedNode = NewSubNode(0)
        tsbCheckOne.Enabled = False
    End Sub
#End Region

#Region "找尋樹狀節點 方法:FindTreeNode"
    ''' <summary>
    ''' 找尋樹狀節點
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindTreeNode(ByVal NodeName As String) As TreeNode
        For Each EachItme As TreeNode In Me.TreeView1.Nodes
            If EachItme.Name.ToUpper = NodeName.ToUpper Then
                Return EachItme
            End If
        Next
        Return Nothing
    End Function
#End Region

#Region "網頁更新 函式:WebRefresh"
    ''' <summary>
    ''' 網頁更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WebRefresh(Optional ByVal IsFormLoaded As Boolean = False)
        Static IsLoaded As Boolean = False
        If IsFormLoaded Then
            IsLoaded = True
        End If
        If IsLoaded = False Then
            Exit Sub
        End If

        Dim WebIsWindowAuthority As Boolean = rbSetAuthority2.Checked
        Dim MoniterPageURL As String = "Http://"
        Dim SendMessagePageURL As String = "Http://"
        Select Case True
            Case rbSebWebServer1.Checked
                MoniterPageURL &= "10.1.4.12/" & IIf(WebIsWindowAuthority, "SMP", "SMP_Anonymous") & "/ElementMoniterSingleForm.aspx"
                SendMessagePageURL &= "10.1.4.12/" & IIf(WebIsWindowAuthority, "IM", "IM_Anonymous") & "/MessageSenderSingleForm.aspx"
            Case rbSebWebServer2.Checked
                MoniterPageURL &= "10.1.4.6/" & IIf(WebIsWindowAuthority, "SMP", "SMP_Anonymous") & "/ElementMoniterSingleForm.aspx"
                SendMessagePageURL &= "10.1.4.6/" & IIf(WebIsWindowAuthority, "IM", "IM_Anonymous") & "/MessageSenderSingleForm.aspx"
            Case rbSebWebServer3.Checked
                Dim GetIP As String = MTBIP.Text.Replace(" ", Nothing)
                If Net.IPAddress.TryParse(GetIP, Nothing) = False Then
                    Exit Sub
                End If
                MoniterPageURL &= GetIP & "/" & IIf(WebIsWindowAuthority, "SMP", "SMP_Anonymous") & "/ElementMoniterSingleForm.aspx"
                SendMessagePageURL &= GetIP & "/" & IIf(WebIsWindowAuthority, "IM", "IM_Anonymous") & "/MessageSenderSingleForm.aspx"
        End Select
        WebBrowser1.Url = Nothing : WebBrowser2.Url = Nothing
        WebBrowser1.Refresh(WebBrowserRefreshOption.Completely) : WebBrowser2.Refresh(WebBrowserRefreshOption.Completely)
        WebBrowser1.Navigate(New Uri(MoniterPageURL)) : WebBrowser1.Refresh(WebBrowserRefreshOption.Completely)
        WebBrowser2.Navigate(New Uri(SendMessagePageURL)) : WebBrowser2.Refresh(WebBrowserRefreshOption.Completely)
    End Sub
#End Region

#Region "重新取得待確認訊息 函式:ReGETWaitCheckMessage"
    Delegate Sub SMPMessageDelegate(ByVal Sender As CompanyORMDB.SQLServer.IM.SMPMessageNotice)
    Delegate Sub NoticeChangedSystemConfigDeleggate(ByVal SetWebIP As String, ByVal SetAuthorityMode As Integer)
    ''' <summary>
    ''' 重新取得待確認訊息
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Private Sub ReGETWaitCheckMessage(ByVal Sender As CompanyORMDB.SQLServer.IM.SMPMessageNotice)

        Dim NewMessageNode As TreeNode = FindTreeNode("NewNode")
        If IsNothing(NewMessageNode) Then
            Exit Sub
        End If
        NewMessageNode.Nodes.Clear()
        NewMessageNode.Checked = False
        Dim SiteUserDataCache As List(Of SiteUser) = SiteUser.GetALLSiteUsers((New SiteUser).CDBCurrentUseSQLQueryAdapter) ' SiteUser.CDBSelect(Of SiteUser)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, "Select * from SiteUser ")
        For Each EachItem As MessageToSiteUsers In SMPMessageNotice.ReadDBNotCheckMessage
            If (EachItem.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.Receiver Or EachItem.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.SenderAndReceiver) AndAlso EachItem.ReceiverMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck Then
                NewMessageNode.Nodes.Add(New MessageToSiteUserWindowNode(EachItem, SiteUserDataCache))
            End If
        Next
        MessageToSiteUserWindowNode.RefreshAllNodesIcon(NewMessageNode.Nodes)
        'TreeView1.SelectedImageIndex = -1
        NewMessageNode.ExpandAll()
        If NewMessageNode.Nodes.Count > 0 AndAlso (Not TabControl1.SelectedTab Is Me.TPReceiveMsg) Then
            TabControl1.SelectedTab = Me.TPReceiveMsg
        End If
        CheckSelectedButtonEnabledRefresh()
    End Sub
#End Region
#Region "重新取得已傳送未回應待確認訊息 函式:ReGETCannotSendCheckMessage"
    Delegate Sub ReGETCannotSendCheckMessageDelegate()
    ''' <summary>
    ''' 重新取得已傳送未回應待確認訊息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReGETCannotSendCheckMessage()
        Dim BackMessageNode As TreeNode = FindTreeNode("BackNode")
        If IsNothing(BackMessageNode) Then
            Exit Sub
        End If
        Dim SiteUserDataCache As List(Of SiteUser) = SiteUser.GetALLSiteUsers((New SiteUser).CDBCurrentUseSQLQueryAdapter)
        BackMessageNode.Nodes.Clear()
        BackMessageNode.Checked = False
        For Each EachItem As MessageToSiteUsers In SMPMessageNotice.ReadDBNotCheckMessage
            If (EachItem.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.Sender Or EachItem.ReceiveMessageRole(SiteUserDataCache) = MessageToSiteUsers.ReceiveMessageRoleEnum.SenderAndReceiver) AndAlso EachItem.SenderMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck Then
                BackMessageNode.Nodes.Add(New MessageToSiteUserWindowNode(EachItem, SiteUser.GetALLSiteUsers((New SiteUser).CDBCurrentUseSQLQueryAdapter)))
            End If
        Next
        MessageToSiteUserWindowNode.RefreshAllNodesIcon(BackMessageNode.Nodes)
        'TreeView1.SelectedImageIndex = -1
        BackMessageNode.ExpandAll()
        If BackMessageNode.Nodes.Count > 0 AndAlso (Not TabControl1.SelectedTab Is Me.TPReceiveMsg) Then
            TabControl1.SelectedTab = Me.TPReceiveMsg
        End If
        CheckSelectedButtonEnabledRefresh()
    End Sub
#End Region
#Region "重新設定下次已傳送未回應訊息偵測 函式:ResetRefreshBackNodeTimer"
    ''' <summary>
    ''' 重新設定下次已傳送未回應訊息偵測
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetRefreshBackNodeTimer()
        Dim BackNode() As TreeNode = TreeView1.Nodes.Find("BackNode", False)
        Dim TreeBackNode As TreeNode = Nothing
        If BackNode.Length > 0 Then
            TreeBackNode = BackNode(0)
            TreeBackNode.Text = "本機傳送未回應" : TreeBackNode.Tag = Nothing
        Else
            Exit Sub
        End If

        Dim PCIPQryString As String = Nothing
        For Each EachItem As String In CompanyORMDB.DeviceInformation.GetLocalIPs()
            If EachItem.Length > 3 AndAlso EachItem.Substring(0, 3) <> "127" Then
                PCIPQryString &= IIf(IsNothing(PCIPQryString), Nothing, ",") & EachItem.Trim
                PCIPQryString = PCIPQryString.Replace(",", "','")
            End If
        Next
        Dim WindowsLoginName As String = Nothing
        If Not String.IsNullOrEmpty(My.User.Name) AndAlso My.User.Name.Split("\").Length > 1 Then
            WindowsLoginName = My.User.Name.Split("\")(1).Trim
        End If
        If IsNothing(WindowsLoginName) AndAlso String.IsNullOrEmpty(PCIPQryString) Then
            Me.RefreshBackNodeTimer.Enabled = False
            Exit Sub
        End If
        Dim QryString As String = "Select * From " & GetType(MessageToSiteUsers).Name & " Where "
        QryString &= " (FromClientIP IN ('" & PCIPQryString & "') OR FromWindowLoginName ='" & WindowsLoginName & "') "
        QryString &= " AND IsHaveNotSendReplye=1 "
        QryString &= " AND IsSenderReceiveNotSendReplye=0 "
        QryString &= " AND (IsReceived=0 OR (IsReceived=1 AND ReceiveTime > NotSendReplyTime))"
        QryString &= " Order by NotSendReplyTime Asc "
        Dim GetNotCheckMessages As List(Of MessageToSiteUsers) = MessageToSiteUsers.CDBSelect(Of MessageToSiteUsers)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, QryString)

        '移除已顯示訊息
        Dim RemoveItems As New List(Of MessageToSiteUsers)
        For Each EachItem As MessageToSiteUserWindowNode In TreeBackNode.Nodes
            With EachItem.OrginMessageToSiteUsers
                Dim KeyValue As String = .FK_MessageID & .FK_ToSiteID & .FK_ToSiteUsersID & .FromClientIP & .SendTime.ToString
                For Each EachItem1 As MessageToSiteUsers In GetNotCheckMessages
                    Dim CompareKey As String = EachItem1.FK_MessageID & EachItem1.FK_ToSiteID & EachItem1.FK_ToSiteUsersID & EachItem1.FromClientIP & EachItem1.SendTime.ToString
                    If KeyValue = CompareKey Then
                        RemoveItems.Add(EachItem1)
                        Exit For
                    End If
                Next
            End With
        Next
        For Each EachItem As MessageToSiteUsers In RemoveItems
            GetNotCheckMessages.Remove(EachItem)
        Next


        TreeBackNode.Tag = IIf(GetNotCheckMessages.Count = 0, "無任何已傳送未回應顯示資料!", "有" & GetNotCheckMessages.Count & " 筆已傳送未回應顯示資料!")
        TreeBackNode.Text &= "(" & GetNotCheckMessages.Count & "個訊息等待中)"
        If GetNotCheckMessages.Count = 0 Then
            Me.RefreshBackNodeTimer.Enabled = False
            Exit Sub
        End If
        Dim NowServerTime As DateTime = WSAdapter.GetServerTime
        Dim NotSendReplyTime As DateTime = GetNotCheckMessages(0).NotSendReplyTime
        'Dim WaitMillSeconds As Double = (WSAdapter.GetServerTime.Subtract(GetNotCheckMessages(0).NotSendReplyTime).TotalSeconds + 1) * 1000
        Static RoopTime As Integer = 0
        If NotSendReplyTime < NowServerTime Then
            RoopTime += 1
            If RoopTime >= 5 Then
                Call Me.ReGETCannotSendCheckMessage()
                RoopTime = 0 : Me.RefreshBackNodeTimer.Enabled = False
                tsslMessage.Text = "發生系統錯誤請洽系統管理員!原因:傳送者取得收訊者無回應訊息造成無限循環!"
                RoopTime = 0
                Exit Sub
            End If
            Call Me.ReGETCannotSendCheckMessage()
            Application.DoEvents() : Threading.Thread.Sleep(1000)
            Call Me.ResetRefreshBackNodeTimer()
            RoopTime = 0
            Exit Sub
        End If
        RoopTime = 0
        Me.RefreshBackNodeTimer.Interval = NotSendReplyTime.Subtract(NowServerTime).TotalSeconds * 1000
        Me.RefreshBackNodeTimer.Enabled = True
    End Sub
#End Region

#Region "重整選取確認讀取按鈕 函式:CheckSelectedButtonEnabledRefresh"
    ''' <summary>
    ''' 重整選取確認讀取按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckSelectedButtonEnabledRefresh()
        tsbCheckSelected.Enabled = False
        tsbMsgToNextClass.Enabled = False
        For Each EachRootNode As TreeNode In TreeView1.Nodes
            For Each EachNodes As TreeNode In EachRootNode.Nodes
                If EachNodes.Checked Then
                    tsbCheckSelected.Enabled = True
                    tsbMsgToNextClass.Enabled = True
                    Exit Sub
                End If
            Next
        Next

    End Sub
#End Region



    Private Sub UCMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolStrip2.Visible = True
        tsslMessage.Text = "啟動被控端服務" & IIf(StartSMPMessageNoticeObject(), "成功", "失敗") & "!"
        CType(IIf(My.User.Name.Split("\")(0).ToUpper = "DOMAIN", rbSetAuthority2, rbSetAuthority1), RadioButton).Checked = True
        Dim GetWindowLoginName As String = Nothing
        Dim GetPCIP As String = Nothing
        Dim IsPCIPInSiteUser As Boolean = False
        Dim IsWindowLoginNameInSiteUser As Boolean = False
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.IM.SiteUser) = Nothing

        If CompanyORMDB.DeviceInformation.GetLocalIPs.Count > 0 Then
            GetPCIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
            SearchResult = CompanyORMDB.SQLServer.IM.SiteUser.CDBSelect(Of SiteUser)("Select * From SiteUser Where UserPKeyKind=1 AND UserPKey='" & GetPCIP & "'", (New CompanyORMDB.SQLServer.IM.SiteUser).SQLQueryAdapterByThisObject)
            IsPCIPInSiteUser = SearchResult.Count > 0
        End If
        If IsPCIPInSiteUser = False AndAlso My.User.Name.Split("\").Length > 1 AndAlso My.User.Name.Split("\")(0).ToUpper = "DOMAIN" Then
            GetWindowLoginName = My.User.Name.Split("\")(1).Trim
            SearchResult = CompanyORMDB.SQLServer.IM.SiteUser.CDBSelect(Of SiteUser)("Select * From SiteUser Where UserPKeyKind=2 AND UserPKey='" & GetWindowLoginName & "'", (New CompanyORMDB.SQLServer.IM.SiteUser).SQLQueryAdapterByThisObject)
            IsWindowLoginNameInSiteUser = SearchResult.Count > 0
        End If

        If IsNothing(SearchResult) OrElse SearchResult.Count = 0 Then
            MsgBox("系統授權失敗,請洽系統管理員告知您的IP為'" & GetPCIP & "'及Windows登入名稱為'" & GetWindowLoginName & "'")
        End If
        If SearchResult.Count > 0 Then
            Call NoticeChangedSystemConfigEventSub(SearchResult(0).DefaultUseServerIP, SearchResult(0).UserPKeyKind)
        End If
        WebRefresh(True)
        Me.ReGETWaitCheckMessage(Nothing)
        Me.ReGETCannotSendCheckMessage()
        Me.ResetRefreshBackNodeTimer()

        Me.TPSchedual.Controls.Add(New UCScheduleAndState)
        Me.TPSchedual.Controls(0).Dock = DockStyle.Fill

        Dim AddControl As UCWaitReceived2Check = New UCWaitReceived2Check
        Me.TPChangeClassMsg.Controls.Add(AddControl)
        AddControl.Dock = DockStyle.Fill

    End Sub


    Private Sub SMPMessageNoticeObjectEvent_NoticeChangedSystemConfigEvent(ByVal SetWebIP As String, ByVal SetAuthorityMode As Integer) Handles SMPMessageNoticeObjectEvent.NoticeChangedSystemConfigEvent
        Dim myDelegate As NoticeChangedSystemConfigDeleggate = AddressOf NoticeChangedSystemConfigEventSub
        Me.Invoke(myDelegate, SetWebIP, SetAuthorityMode)
    End Sub
    Private Sub NoticeChangedSystemConfigEventSub(ByVal SetWebIP As String, ByVal SetAuthorityMode As Integer)
        If (Not String.IsNullOrEmpty(SetWebIP)) AndAlso Net.IPAddress.TryParse(SetWebIP.Trim, Nothing) Then
            Dim SetIPValue As String = SetWebIP.Trim
            Select Case True
                Case SetIPValue = "10.1.4.12"
                    rbSebWebServer1.Checked = True
                Case SetIPValue = "10.1.4.6"
                    rbSebWebServer2.Checked = True
                Case Else
                    MTBIP.Text = SetIPValue
                    rbSebWebServer3.Checked = True
            End Select
        End If
        Select Case True
            Case SetAuthorityMode = 1
                rbSetAuthority1.Checked = True
            Case SetAuthorityMode = 2
                rbSetAuthority2.Checked = True
        End Select
        WebRefresh(True)
    End Sub


    Private Sub SMPMessageNoticeObjectEvent_NoticeToReceiveDBMessageEvent(ByVal Sender As CompanyORMDB.SQLServer.IM.SMPMessageNotice) Handles SMPMessageNoticeObjectEvent.NoticeToReceiveDBMessageEvent
        Dim myDelegate As SMPMessageDelegate = AddressOf SMPMessageNoticeObjectEventSub
        Me.Invoke(myDelegate, Sender)
    End Sub

    Private Sub SMPMessageNoticeObjectEventSub(ByVal Sender As CompanyORMDB.SQLServer.IM.SMPMessageNotice)
        Call ResetRefreshBackNodeTimer()
        If (Me.TabControl1.SelectedTab Is TPReceiveMsg) AndAlso Not IsNothing(Me.TreeView1.SelectedNode) AndAlso (TypeOf Me.TreeView1.SelectedNode Is MessageToSiteUserWindowNode) Then
            MsgBox("有一則新訊息送來,為不影響您目前正在閱讀的訊息" & vbNewLine & "請自行手動重新取得未讀取訊息!")
            Exit Sub
        End If
        Call ReGETWaitCheckMessage(Sender)
    End Sub


    Private Sub tsnReReadNOCheckMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsnReReadNOCheckMessage.Click
        Me.ReGETWaitCheckMessage(Nothing)
        Me.ReGETCannotSendCheckMessage()
        Me.ResetRefreshBackNodeTimer()
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        If e.Node.Name.ToUpper = "NEWNODE" OrElse e.Node.Name.ToUpper = "BACKNODE" Then
            For Each EachNode As TreeNode In e.Node.Nodes
                EachNode.Checked = e.Node.Checked
            Next
        End If
        CheckSelectedButtonEnabledRefresh()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        tsbCheckOne.Enabled = False

        If TypeOf TreeView1.SelectedNode Is MessageToSiteUserWindowNode Then
            CurrentShowMessageToSiteUserWindowNode = TreeView1.SelectedNode
            CurrentShowMessageToSiteUserWindowNode.Checked = True
            tsbCheckOne.Enabled = True
        Else
            CurrentShowMessageToSiteUserWindowNode = Nothing
        End If
    End Sub

    Private Sub tsbCheckOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCheckOne.Click
        CheckReadCurrentShowMessage()
        Dim BackNode() As TreeNode = TreeView1.Nodes.Find("BackNode", False)
        Dim NewNode() As TreeNode = TreeView1.Nodes.Find("NewNode", False)
        If NewNode.Length > 0 And BackNode.Length > 0 AndAlso NewNode(0).Nodes.Count = 0 AndAlso BackNode(0).Nodes.Count = 0 Then
            TabControl1.SelectedTab = TPMoniter
        End If
    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked
        tsslMessage.Text = "重新啟動被控端服務" & IIf(StartSMPMessageNoticeObject(), "成功", "失敗") & "!"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tsslMessage.Text = "重新啟動被控端服務" & IIf(StartSMPMessageNoticeObject(), "成功", "失敗") & "!"
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TPSchedual.Controls.Count > 0 Then
            CType(TPSchedual.Controls(0), UCScheduleAndState).ControlMode = UCScheduleAndState.ControlModeEnum.SleepMode
        End If
        Select Case True
            Case TabControl1.SelectedTab Is TPMoniter
                If Not IsNothing(Me.WebBrowser1.Url) Then
                    tsslMessage.Text = "連線網址:" & Me.WebBrowser1.Url.ToString
                End If
            Case TabControl1.SelectedTab Is TPMessageSendAndSearch
                If Not IsNothing(Me.WebBrowser2.Url) Then
                    tsslMessage.Text = "連線網址:" & Me.WebBrowser2.Url.ToString
                End If
            Case TabControl1.SelectedTab Is TPSchedual
                If CType(TPSchedual.Controls(0), UCScheduleAndState).ControlMode = UCScheduleAndState.ControlModeEnum.SleepMode Then
                    CType(TPSchedual.Controls(0), UCScheduleAndState).ControlMode = UCScheduleAndState.ControlModeEnum.MoniterMode
                End If
            Case TabControl1.SelectedTab Is TPChangeClassMsg
                CType(TabControl1.SelectedTab.Controls(0), UCWaitReceived2Check).ReGETWaitCheckMessage()
        End Select
        Me.CurrentShowMessageToSiteUserWindowNode = Nothing
    End Sub


    Private Sub rbSebWebServer1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSebWebServer1.CheckedChanged, rbSebWebServer2.CheckedChanged, rbSebWebServer3.CheckedChanged, rbSetAuthority1.CheckedChanged, rbSetAuthority2.CheckedChanged, btnRefreshWeb.Click
        WebRefresh()
    End Sub

    Private Sub MTBIP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTBIP.TextChanged
        If rbSebWebServer3.Checked Then
            WebRefresh()
        End If
    End Sub

    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated, WebBrowser2.Navigated
        Call TabControl1_SelectedIndexChanged(sender, Nothing)
    End Sub

    Private Sub RefreshBackNodeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshBackNodeTimer.Tick
        RefreshBackNodeTimer.Enabled = False
        ReGETCannotSendCheckMessage()
        ResetRefreshBackNodeTimer()
        TabControl1.SelectedTab = TPReceiveMsg
    End Sub

    Private Sub tsbCheckSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCheckSelected.Click, tsbMsgToNextClass.Click
        Dim MsgString As String = IIf(sender Is tsbMsgToNextClass, "是否確認所有選取訊息並移轉訊息至交接班?", "是否確認所有選取訊息?")
        If MsgBox(MsgString, MsgBoxStyle.YesNo, MsgString) = MsgBoxResult.No Then
            Exit Sub
        End If
        If sender Is tsbCheckSelected Then
            CheckAllSelectMessage(False)
        Else
            CheckAllSelectMessage(True)
        End If
        Dim BackNode() As TreeNode = TreeView1.Nodes.Find("BackNode", False)
        Dim NewNode() As TreeNode = TreeView1.Nodes.Find("NewNode", False)
        If NewNode.Length > 0 And BackNode.Length > 0 AndAlso NewNode(0).Nodes.Count = 0 AndAlso BackNode(0).Nodes.Count = 0 Then
            TabControl1.SelectedTab = TPMoniter
        End If

    End Sub
End Class
