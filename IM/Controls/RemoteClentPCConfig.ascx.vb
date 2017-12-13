Public Partial Class RemoteClentPCConfig
    Inherits System.Web.UI.UserControl


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

#Region "選擇資料 屬性:SelectDatas"
    ''' <summary>
    ''' 選擇資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectDatas() As List(Of CompanyLINQDB.RemoteServer)
        Get
            Return Me.Session("_SelectDatas")
        End Get
        Set(ByVal value As List(Of CompanyLINQDB.RemoteServer))
            Me.Session("_SelectDatas") = value
        End Set
    End Property
#End Region

#Region "重整顯示btnSelectSet是否可用 函式:RefreshSetbtnSelectSetEnable"
    ''' <summary>
    ''' 重整顯示btnSelectSet是否可用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshSetbtnSelectSetEnable()
        If Me.MultiView1.ActiveViewIndex <> 0 Then
            Exit Sub
        End If
        btnSelectSet.Enabled = False
        For Each EachItem As GridViewRow In GridView1.Rows
            Dim myCheckBox As CheckBox = EachItem.Cells(0).FindControl("CheckBox1")
            If Not IsNothing(myCheckBox) AndAlso myCheckBox.Checked Then
                btnSelectSet.Enabled = True
                Exit Sub
            End If
        Next
    End Sub
#End Region

#Region "通知線使用者變更設定或重整 函式:NoticeOnLineUserChangeConfigOrRefreshOnly"
    ''' <summary>
    ''' 通知線使用者變更設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NoticeOnLineUserChangeConfigOrRefreshOnly(ByVal IsWillReSetConfig As Boolean)
        Dim SetIP As String = Nothing
        Dim SetAuthorityMode As Integer = -1
        If IsWillReSetConfig Then
            If cbSetWebIP2.Checked Then
                SetIP = tbSetDefaultWebServerIP2.Text.Trim
            End If
            If cbSetAuthority2.Checked Then
                SetAuthorityMode = CType(rblSetAuthority2.SelectedValue, Integer)
            End If
        End If
        For Each EachItem As CompanyORMDB.SQLServer.IM.RemoteClient In CompanyORMDB.SQLServer.IM.SMPMessageNotice.DBRemoteClientConnectToServersOnline(GetType(CompanyORMDB.SQLServer.IM.SMPMessageNotice), 3)
            'CType(EachItem.RemoteClientProxyObject, CompanyORMDB.SQLServer.IM.SMPMessageNotice).NoticeChangedSystemConfig(SetIP, SetAuthorityMode)
            Try
                Dim RemoteObject As CompanyORMDB.SQLServer.IM.SMPMessageNotice = EachItem.RemoteClientProxyObject
                RemoteObject.NoticeChangedSystemConfig(SetIP, SetAuthorityMode)
            Catch ex As Exception

            End Try

        Next
        'For Each EachItem As CompanyLINQDB.RemoteServer In (From A In SelectDatas Where A.IsOnLine Select A).ToList
        '    For Each EachProxyObjcet As CompanyORMDB.SQLServer.IM.SMPMessageNotice In (From A In EachItem.AllOnLineRemoteClient Select CType(A.RemoteClientProxyObject, CompanyORMDB.SQLServer.IM.SMPMessageNotice)).ToList
        '        EachProxyObjcet.NoticeChangedSystemConfig(SetIP, SetAuthorityMode)
        '    Next
        'Next

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub btnSearchClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClear.Click
        IsUserAlreadyPutSearch = False
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Protected Sub btnSelectItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        For Each EachItem As GridViewRow In GridView1.Rows
            Dim myCheckBox As CheckBox = EachItem.Cells(0).FindControl("CheckBox1")
            If Not IsNothing(myCheckBox) Then
                myCheckBox.Checked = Not myCheckBox.Checked
            End If
        Next
        RefreshSetbtnSelectSetEnable()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Protected Sub btnSelectSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectSet.Click
        Dim KeyColumnIndex As New Hashtable
        For Each EachColumn As DataControlField In GridView1.Columns
            If EachColumn.SortExpression = "CPUNumber" OrElse EachColumn.SortExpression = "RegisterClassName" OrElse EachColumn.SortExpression = "Port" OrElse EachColumn.SortExpression = "RemoteProtocol" Then
                KeyColumnIndex.Add(EachColumn.SortExpression, GridView1.Columns.IndexOf(EachColumn))
            End If
        Next
        Dim KeyValues As New List(Of String)
        For Each EachItem As GridViewRow In GridView1.Rows
            Dim myCheckBox As CheckBox = EachItem.Cells(0).FindControl("CheckBox1")
            If Not IsNothing(myCheckBox) AndAlso myCheckBox.Checked Then
                Dim KeyString As String = Nothing
                KeyString &= EachItem.Cells(CType(KeyColumnIndex("CPUNumber"), Integer)).Text.Trim
                KeyString &= EachItem.Cells(CType(KeyColumnIndex("RegisterClassName"), Integer)).Text.Trim
                KeyString &= EachItem.Cells(CType(KeyColumnIndex("Port"), Integer)).Text.Trim
                KeyString &= EachItem.Cells(CType(KeyColumnIndex("RemoteProtocol"), Integer)).Text.Trim
                KeyValues.Add(KeyString)
            End If
        Next

        Dim SetDatas As List(Of CompanyLINQDB.RemoteServer)
        SetDatas = (From A In (New CompanyLINQDB.IMDataContext).RemoteServer Where KeyValues.Contains(A.CPUNumber.Trim & A.RegisterClassName.Trim & A.Port.Trim & A.RemoteProtocol) Select A).ToList

        Me.SelectDatas = SetDatas
        If Me.SelectDatas.Count > 0 Then
            Me.MultiView1.SetActiveView(Me.View2)
        End If
    End Sub

    Protected Sub btnCancelAndBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelAndBack.Click
        Me.MultiView1.SetActiveView(Me.View1)
    End Sub

    Protected Sub btnSetAndBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetAndBack.Click
        Dim DBDataContext As New CompanyLINQDB.IMDataContext
        If cbSetWebIP1.Checked Then
            Dim WillChangeData As New List(Of CompanyLINQDB.SiteUser)
            WillChangeData = (From A In DBDataContext.SiteUser Where A.UserPKeyKind = 1 And (From B In SelectDatas Select B.IP.Trim).ToList.Contains(A.UserPKey.Trim) Select A).ToList
            Dim SelectedDataLoginNames As New List(Of String)
            For Each EachItem As String In From B In SelectDatas Select B.WindowLoginName
                If EachItem.Split("\").Length > 1 Then
                    SelectedDataLoginNames.Add(EachItem.Split("\")(1).Trim)
                Else
                    SelectedDataLoginNames.Add(EachItem.Trim)
                End If
            Next
            WillChangeData.AddRange((From A In DBDataContext.SiteUser Where A.UserPKeyKind = 2 And SelectedDataLoginNames.Contains(A.UserPKey.Trim) Select A).ToList)
            For Each EachItem As CompanyLINQDB.SiteUser In WillChangeData
                EachItem.DefaultUseServerIP = tbSetDefaultWebServerIP1.Text.Trim
            Next
            DBDataContext.SubmitChanges()
        End If
        NoticeOnLineUserChangeConfigOrRefreshOnly(True)
        MultiView1.SetActiveView(Me.View1)
    End Sub

    Protected Sub CheckBox1_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        RefreshSetbtnSelectSetEnable()
    End Sub

    Protected Sub cbSetWebIP1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbSetWebIP1.CheckedChanged, cbSetWebIP2.CheckedChanged, cbSetAuthority2.CheckedChanged
        btnSetAndBack.Enabled = cbSetWebIP1.Checked Or cbSetWebIP2.Checked Or cbSetAuthority2.Checked
    End Sub

End Class