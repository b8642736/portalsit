Public Partial Class SiteGroupToSiteEdit
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

    Dim DBDataContext As New CompanyLINQDB.IMDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ldsSearchResult1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult1.Selecting
        If Not IsUserAlreadyPutSearch OrElse TabContainer1.ActiveTab Is TabPanel2 Then
            e.Cancel = Not IsUserAlreadyPutSearch
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
            e.Result = From A In DBDataContext.SiteGroup Where A.GroupName Like Me.TextBox1.Text & "*" Select A
        End If

    End Sub

    Protected Sub ldsSearchResult2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult2.Selecting
        If Not IsUserAlreadyPutSearch OrElse TabContainer1.ActiveTab Is TabPanel2 Then
            e.Cancel = Not IsUserAlreadyPutSearch
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.Site) = From A In DBDataContext.Site Select A
        Dim SiteGroupSelectValue As String = GridView1.SelectedValue
        If Not IsNothing(SiteGroupSelectValue) AndAlso Not String.IsNullOrEmpty(SiteGroupSelectValue) Then
            Result = From A In Result Where Not (From B In DBDataContext.SiteGroupToSite Where B.FK_SiteGroupID = SiteGroupSelectValue Select B.FK_SiteID).Contains(A.ID) Select A
        End If

        If Not String.IsNullOrEmpty(Me.TextBox2.Text) Then
            Result = From A In Result Where A.SiteName Like Me.TextBox2.Text & "*" Select A
        End If
        e.Result = Result
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        Me.GridView1.SelectedIndex = -1
        Me.GridView2.SelectedIndex = -1
        Me.IsUserAlreadyPutSearch = False
        Me.GridView2.Enabled = False
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        lbMsg.Visible = False
        Select Case True
            Case TabContainer1.ActiveTab Is TabPanel1
                Me.GridView1.DataBind() : Me.GridView1.SelectedIndex = -1
                Me.GridView2.DataBind() : Me.GridView2.SelectedIndex = -1
                Me.GridView2.Enabled = False
            Case TabContainer1.ActiveTab Is TabPanel2
                Me.GridView3.DataBind()
        End Select
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        If Not IsNothing(GridView1.SelectedValue) And Not IsNothing(GridView2.SelectedValue) Then
            Dim AddItem As New CompanyLINQDB.SiteGroupToSite
            With AddItem
                .FK_SiteGroupID = GridView1.SelectedValue
                .FK_SiteID = GridView2.SelectedValue
            End With
            Try
                DBDataContext.SiteGroupToSite.InsertOnSubmit(AddItem)
                DBDataContext.SubmitChanges()
                lbMsg.Text = "已成功加入一筆資料!"
            Catch ex As Exception
                lbMsg.Text = "加入一筆資料失敗! 訊息:" & ex.ToString
            End Try
            GridView2.DataBind()
            Me.GridView2.SelectedIndex = -1
            lbMsg.Visible = True
        End If
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.GridView2.Enabled = Not IsNothing(GridView1.SelectedValue)
        Me.GridView2.DataBind()
    End Sub

    Protected Sub ldsSearchResult3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult3.Selecting
        If Not IsUserAlreadyPutSearch OrElse TabContainer1.ActiveTab Is TabPanel1 Then
            e.Cancel = Not IsUserAlreadyPutSearch
            Exit Sub
        End If

        Dim Result As IQueryable(Of SiteGroupToSite) = From A In DBDataContext.SiteGroupToSite Select A
        If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
            Dim SiteGroupQryID As List(Of String) = (From A In DBDataContext.SiteGroup Where A.GroupName Like Me.TextBox1.Text & "*" Select A.ID).ToList
            Result = From A In Result Where SiteGroupQryID.Contains(A.FK_SiteGroupID) Select A
        End If
        If Not String.IsNullOrEmpty(Me.TextBox2.Text) Then
            Dim SiteQryID As List(Of String) = (From A In DBDataContext.Site Where A.SiteName Like Me.TextBox2.Text & "*" Select A.ID).ToList
            Result = From A In Result Where SiteQryID.Contains(A.FK_SiteID) Select A
        End If
        e.Result = Result

    End Sub



End Class