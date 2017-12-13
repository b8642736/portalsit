Public Partial Class WebMemberForWebGroup
    Inherits System.Web.UI.UserControl


    Dim DBDataContext As New ClassDBDataContext

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

#Region "清理Session查詢篩選條件 函式:ClearBeforeSearchFilterInSession"
    ''' <summary>
    ''' 清理Session查詢篩選條件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearBeforeSearchFilterInSession()
        Me.EmployeeSearch1.BeforeSearchFilter = Nothing
        Me.ClientPCSearch1.BeforeSearchFilter = Nothing
    End Sub

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GroupSearch1_GroupSearchedEvent(ByVal SenderControl As GroupSearch) Handles GroupSearch1.GroupSearchedEvent
        Me.TabPanel2.Enabled = False
        Me.TabPanel3.Enabled = False
        ClearBeforeSearchFilterInSession()
    End Sub

    Private Sub GroupSearch1_GroupSelectedEvent(ByVal SelectGroupCode As String) Handles GroupSearch1.GroupSelectedEvent
        Me.TabPanel2.Enabled = True
        Me.TabPanel3.Enabled = True
        Me.ClientPCSearch1.BeforeSearchFilter = From A In DBDataContext.WebClientPCAccount Where Not (From B In DBDataContext.WebClientPCAccountTOWebGroupAccount Where B.GroupCode = SelectGroupCode Select B.ClientIP).Contains(A.ClientIP) Select A
        Me.EmployeeSearch1.BeforeSearchFilter = From A In DBDataContext.WebLoginAccount Where Not (From B In DBDataContext.WebLoginAccountToWebGroupAccount Where B.GroupCode = SelectGroupCode Select B.WindowLoginName).Contains(A.WindowLoginName) Select A
    End Sub

    Private Sub LDSEmployee_Member_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEmployee_Member.Selecting
        If IsNothing(EmployeeSearch1.SelectedEmployeeNumber) And Me.TabContainer1.ActiveTabIndex <> 2 Then
            e.Cancel = True
            Exit Sub
        End If
        Dim IsAlreadyMembers As IQueryable(Of CompanyLINQDB.WebLoginAccountToWebGroupAccount) = From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.GroupCode = GroupSearch1.SelectedGroupCode Select A
        Dim Result As IQueryable(Of CompanyLINQDB.WebLoginAccount) = From A In DBDataContext.WebLoginAccount Where (From B In IsAlreadyMembers Select B.WindowLoginName).Contains(A.WindowLoginName) Select A
        e.Result = Result
    End Sub

    Private Sub LDSClientPC_Member_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSClientPC_Member.Selecting
        If IsNothing(GroupSearch1.SelectedGroupCode) And Me.TabContainer1.ActiveTabIndex <> 1 Then
            e.Cancel = True
            Exit Sub
        End If
        Dim IsAlreadyMembers As IQueryable(Of CompanyLINQDB.WebClientPCAccountTOWebGroupAccount) = From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Where A.GroupCode = GroupSearch1.SelectedGroupCode Select A
        Dim Result As IQueryable(Of CompanyLINQDB.WebClientPCAccount) = From A In DBDataContext.WebClientPCAccount Where (From B In IsAlreadyMembers Select B.ClientIP).Contains(A.ClientIP) Select A
        e.Result = Result
    End Sub

    Private Sub ClientPCSearch1_ClientPCSelectedEvent(ByVal SelectClientPCIP As String) Handles ClientPCSearch1.ClientPCSelectedEvent
        If IsNothing(GroupSearch1.SelectedGroupCode) OrElse IsNothing(SelectClientPCIP) Then
            Exit Sub
        End If
        Dim AddNewData As New CompanyLINQDB.WebClientPCAccountTOWebGroupAccount
        With AddNewData
            .ClientIP = SelectClientPCIP
            .GroupCode = GroupSearch1.SelectedGroupCode
            .Memo1 = "起始授權時間:" & Format(Now, "yyyy/MM/dd hh:mm:ss").ToString & ",授權者:" & ValidAuthorityModule.CurrentWindowsLoginName & "(" & ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber & ")"
        End With
        DBDataContext.WebClientPCAccountTOWebGroupAccount.InsertOnSubmit(AddNewData)
        DBDataContext.SubmitChanges()
        ClientPCSearch1.DataBind()
        Me.GridView2.DataBind()
    End Sub

    Private Sub EmployeeSearch1_EmployeeSelectedEvent(ByVal SelectEmployeeNumber As String) Handles EmployeeSearch1.EmployeeSelectedEvent
        If IsNothing(GroupSearch1.SelectedGroupCode) OrElse IsNothing(SelectEmployeeNumber) Then
            Exit Sub
        End If
        Dim AddNewData As New CompanyLINQDB.WebLoginAccountToWebGroupAccount
        With AddNewData
            .WindowLoginName = SelectEmployeeNumber
            .GroupCode = GroupSearch1.SelectedGroupCode
            .Memo1 = "起始授權時間:" & Format(Now, "yyyy/MM/dd hh:mm:ss").ToString & ",授權者:" & ValidAuthorityModule.CurrentWindowsLoginName & "(" & ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber & ")"
        End With
        DBDataContext.WebLoginAccountToWebGroupAccount.InsertOnSubmit(AddNewData)
        DBDataContext.SubmitChanges()
        EmployeeSearch1.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        If IsNothing(GroupSearch1.SelectedGroupCode) OrElse IsNothing(GridView2.SelectedValue) Then
            Exit Sub
        End If
        Dim DeleteData As CompanyLINQDB.WebClientPCAccountTOWebGroupAccount = (From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Where A.GroupCode = GroupSearch1.SelectedGroupCode And A.ClientIP = CType(GridView2.SelectedValue, String) Select A).FirstOrDefault
        If Not IsNothing(DeleteData) Then
            DBDataContext.WebClientPCAccountTOWebGroupAccount.DeleteOnSubmit(DeleteData)
            DBDataContext.SubmitChanges()
            ClientPCSearch1.DataBind()
            Me.GridView2.DataBind()
        End If
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If IsNothing(GroupSearch1.SelectedGroupCode) OrElse IsNothing(GridView1.SelectedValue) Then
            Exit Sub
        End If
        Dim DeleteData As CompanyLINQDB.WebLoginAccountToWebGroupAccount = (From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.GroupCode = GroupSearch1.SelectedGroupCode And A.WindowLoginName = CType(GridView1.SelectedValue, String) Select A).FirstOrDefault
        If Not IsNothing(DeleteData) Then
            DBDataContext.WebLoginAccountToWebGroupAccount.DeleteOnSubmit(DeleteData)
            DBDataContext.SubmitChanges()
            EmployeeSearch1.DataBind()
            Me.GridView1.DataBind()
        End If
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        Select Case True
            Case TabContainer1.ActiveTabIndex = 1
                Me.GridView2.DataBind()
            Case TabContainer1.ActiveTabIndex = 2
                Me.GridView1.DataBind()
        End Select
    End Sub
End Class