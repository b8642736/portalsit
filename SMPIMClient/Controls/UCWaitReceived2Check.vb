Public Class UCWaitReceived2Check

#Region "重新取得待確認訊息 函式:ReGETWaitCheckMessage"
    Public Event ReGETWaitCheckMessagedEvent(ByVal ReGetDatas As List(Of MessageToSiteUsers))
    ''' <summary>
    ''' 重新取得待確認訊息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReGETWaitCheckMessage()

        Me.TreeView1.Nodes.Clear()

        Dim SiteUserDataCache As List(Of SiteUser) = SiteUser.GetALLSiteUsers((New SiteUser).CDBCurrentUseSQLQueryAdapter)
        Dim ReadDBWaitReceived2CheckMessages As List(Of MessageToSiteUsers) = SMPMessageNotice.ReadDBWaitReceived2CheckMessage
        For Each EachItem As MessageToSiteUsers In ReadDBWaitReceived2CheckMessages
            Me.TreeView1.Nodes.Add(New MessageToSiteUserWindowNode(EachItem, SiteUserDataCache))
        Next
        MessageToSiteUserWindowNode.RefreshAllNodesIcon(Me.TreeView1.Nodes)

        CheckSelectedButtonEnabledRefresh()
        RaiseEvent ReGETWaitCheckMessagedEvent(ReadDBWaitReceived2CheckMessages)

        'If Me.TreeView1.Nodes.Count > 0 AndAlso (Not TabControl1.SelectedTab Is Me.TPReceiveMsg) Then
        '    TabControl1.SelectedTab = Me.TPReceiveMsg
        'End If

    End Sub

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
        tsslMessage.Text = "資料更新中!" : Application.DoEvents()
        If IsNothing(TreeView1.SelectedNode) OrElse Not TypeOf TreeView1.SelectedNode Is MessageToSiteUserWindowNode Then
            Exit Sub
        End If
        Dim SelectNode As MessageToSiteUserWindowNode = TreeView1.SelectedNode
        Dim SelectObject As MessageToSiteUsers = SelectNode.OrginMessageToSiteUsers
        SelectObject.WaitReceived2CheckIP = Nothing
        If SelectObject.CDBSave > 0 Then
            tsslMessage.Text = SelectObject.MsgText.Trim & " 單筆確認完成!"
            Me.TreeView1.Nodes.Remove(SelectNode)
        Else
            tsslMessage.Text = SelectObject.MsgText.Trim & " 單筆確認失敗!"
        End If

        Call ReGETWaitCheckMessage()

    End Sub
#End Region
#Region "確認所有選擇訊息 函式:CheckAllSelectMessage"
    ''' <summary>
    ''' 確認所有選擇訊息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckAllSelectMessage()
        tsslMessage.Text = "資料更新中!" : Application.DoEvents()
        Dim CheckSuccessCount As Integer = 0
        For Each EachNode As MessageToSiteUserWindowNode In Me.TreeView1.Nodes
            Dim SelectObject As MessageToSiteUsers = EachNode.OrginMessageToSiteUsers
            If EachNode.Checked Then
                SelectObject.WaitReceived2CheckIP = Nothing
                CheckSuccessCount += SelectObject.CDBSave()
            End If
        Next
        tsslMessage.Text = "所有資料(共" & CheckSuccessCount & "筆)確認完成!"
        Call ReGETWaitCheckMessage()
    End Sub
#End Region

#Region "重整選取確認讀取按鈕 函式:CheckSelectedButtonEnabledRefresh"
    ''' <summary>
    ''' 重整選取確認讀取按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckSelectedButtonEnabledRefresh()
        tsbCheckSelected.Enabled = False
        For Each EachRootNode As TreeNode In TreeView1.Nodes
            If EachRootNode.Checked Then
                tsbCheckSelected.Enabled = True
                Exit Sub
            End If
        Next
    End Sub
#End Region


    Private Sub UCWaitReceived2Check_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolStrip2.Visible = True
        ReGETWaitCheckMessage()
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
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

    Private Sub tsnReReadNOCheckMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsnReReadNOCheckMessage.Click
        Me.ReGETWaitCheckMessage()
    End Sub

    Private Sub tsbCheckOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCheckOne.Click
        CheckReadCurrentShowMessage()
    End Sub

    Private Sub tsbCheckSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCheckSelected.Click
        If MsgBox("是否確認所有選取訊息?", MsgBoxStyle.YesNo, "是否確認所有選取訊息?") = MsgBoxResult.No Then
            Exit Sub
        End If
        CheckAllSelectMessage()
    End Sub
End Class
