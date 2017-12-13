Partial Public Class SiteUserEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.IMDataContext
    Dim AuthorityDBDataContext As New CompanyLINQDB.WebAPPAuthorityDataContext


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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Nothing
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Select Case True
            Case Me.TabContainer1.ActiveTab Is Me.TabPanel1
                GridView1.DataBind()
            Case Me.TabContainer1.ActiveTab Is Me.TabPanel2
                GridView2.DataBind()
            Case Me.TabContainer1.ActiveTab Is Me.TabPanel3
                GridView3.DataBind()
        End Select
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        IsUserAlreadyPutSearch = False
        Select Case True
            Case sender Is TabPanel1
                IsUserAlreadyPutSearch = True
                GridView1.DataBind()
            Case Else
        End Select
    End Sub

    Protected Sub btnSearchClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClear.Click
        TextBox1.Text = Nothing
    End Sub

    Protected Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView4.SelectedIndexChanged
        GridView3.Enabled = GridView4.SelectedIndex >= 0
        If Me.TextBox1.Text.Trim.Length = 0 OrElse Me.IsUserAlreadyPutSearch Then
            GridView3.DataBind()
        End If
    End Sub

    Protected Sub GridView5_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView5.SelectedIndexChanged
        GridView2.Enabled = GridView5.SelectedIndex >= 0
        If Me.TextBox1.Text.Trim.Length = 0 OrElse Me.IsUserAlreadyPutSearch Then
            GridView2.DataBind()
        End If
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        If GridView2.SelectedIndex >= 0 AndAlso GridView5.SelectedIndex >= 0 Then
            Dim AddItem As New CompanyLINQDB.SiteUser
            With AddItem
                .ID = Guid.NewGuid.ToString
                .UserPKeyKind = 2
                .UserPKey = GridView2.SelectedValue
                .FK_SiteID = GridView5.SelectedValue
                .DefaultUseServerIP = tbSetADDDefaultWebIP1.Text.Trim
            End With
            DBDataContext.SiteUser.InsertOnSubmit(AddItem)
            DBDataContext.SubmitChanges()
            GridView2.DataBind()
        End If

    End Sub

    Private Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        If GridView3.SelectedIndex >= 0 AndAlso GridView4.SelectedIndex >= 0 Then
            Dim AddItem As New CompanyLINQDB.SiteUser
            With AddItem
                .ID = Guid.NewGuid.ToString
                .UserPKeyKind = 1
                .UserPKey = GridView3.SelectedValue
                .FK_SiteID = GridView4.SelectedValue
                .DefaultUseServerIP = tbSetADDDefaultWebIP2.Text.Trim
            End With
            DBDataContext.SiteUser.InsertOnSubmit(AddItem)
            DBDataContext.SubmitChanges()
            GridView3.DataBind()
        End If

    End Sub

    Private Sub ldsSearchResult2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult2.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
        Dim AlreadyHaveDatas As IQueryable(Of SiteUser) = From A In DBDataContext.SiteUser Where A.UserPKeyKind = 2 Select A
        If Not IsNothing(GridView5.SelectedValue) Then
            AlreadyHaveDatas = From A In AlreadyHaveDatas Where A.FK_SiteID = CType(GridView5.SelectedValue, String) Select A
        End If
        Dim ReturnValue As IQueryable(Of WebLoginAccount) = From A In AuthorityDBDataContext.WebLoginAccount Where Not (From B In AlreadyHaveDatas Select B.UserPKey).ToList.Contains(A.WindowLoginName) Select A
        If Me.TextBox1.Text.Trim.Length > 0 Then
            Dim FindString As String = "*" & TextBox1.Text.Trim & "*"
            ReturnValue = From A In ReturnValue Where A.WindowLoginName Like FindString OrElse A.DisplayName Like FindString Select A
        End If
        e.Result = ReturnValue
    End Sub

    Private Sub ldsSearchResult3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult3.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
        Dim AlreadyHaveDatas As IQueryable(Of SiteUser) = From A In DBDataContext.SiteUser Where A.UserPKeyKind = 1 Select A
        If Not IsNothing(GridView4.SelectedValue) Then
            AlreadyHaveDatas = From A In AlreadyHaveDatas Where A.FK_SiteID = CType(GridView4.SelectedValue, String) Select A
        End If

        Dim ReturnValue As IQueryable(Of WebClientPCAccount) = From A In AuthorityDBDataContext.WebClientPCAccount Where Not (From B In AlreadyHaveDatas Select B.UserPKey).ToList.Contains(A.ClientIP) Select A
        If Me.TextBox1.Text.Trim.Length > 0 Then
            Dim FindString As String = "*" & TextBox1.Text.Trim & "*"
            ReturnValue = From A In ReturnValue Where A.ClientIP Like FindString OrElse A.PCName Like FindString Select A
        End If
        e.Result = ReturnValue
    End Sub

    Protected Sub ldsSearchResult1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult1.Selecting
        If Me.TextBox1.Text.Trim.Length > 0 Then
            Dim ReturnValue As IQueryable(Of SiteUser)
            Dim FindString As String = "*" & TextBox1.Text.Trim & "*"
            Dim AlreadyHaveDatas1 As List(Of WebLoginAccount) = (From A In AuthorityDBDataContext.WebLoginAccount Where A.WindowLoginName Like FindString OrElse A.DisplayName Like FindString Select A).ToList
            Dim AlreadyHaveDatas2 As List(Of WebClientPCAccount) = (From A In AuthorityDBDataContext.WebClientPCAccount Where A.ClientIP Like FindString OrElse A.PCName Like FindString Select A).ToList
            ReturnValue = From A In DBDataContext.SiteUser Where A.UserPKeyKind = 2 And (From B In AlreadyHaveDatas1 Select B.WindowLoginName).Contains(A.UserPKey) Select A
            ReturnValue = (From A In DBDataContext.SiteUser Where A.UserPKeyKind = 1 And (From B In AlreadyHaveDatas2 Select B.ClientIP).Contains(A.UserPKey) Select A).Union(ReturnValue)
            e.Result = ReturnValue
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class