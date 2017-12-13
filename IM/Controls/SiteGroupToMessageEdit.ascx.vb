Public Partial Class SiteGroupToMessageEdit
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


    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
        lbMsg.Visible = False
        IsUserAlreadyPutSearch = False
        btnAdd.Enabled = False
        lbMsg.Visible = False
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Select Case True
            Case TabContainer1.ActiveTab Is TabPanel1
                lbMsg.Visible = False
                Me.GridView1.DataBind() : Me.GridView1.SelectedIndex = -1
                Me.GridView2.DataBind() : Me.GridView2.SelectedIndex = -1
            Case TabContainer1.ActiveTab Is TabPanel2
                Me.GridView3.DataBind()
        End Select
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
        Dim Result As IQueryable(Of CompanyLINQDB.Message) = From A In DBDataContext.Message Select A
        Dim SiteGroupSelectValue As String = GridView1.SelectedValue
        If Not IsNothing(SiteGroupSelectValue) AndAlso Not String.IsNullOrEmpty(SiteGroupSelectValue) Then
            Result = From A In Result Where Not (From B In DBDataContext.SiteGroupToMessage Where B.FK_SiteGroupID = SiteGroupSelectValue Select B.FK_MessageID).Contains(A.ID) Select A
        End If
        If Not String.IsNullOrEmpty(Me.TextBox2.Text) Then
            Result = From A In Result Where A.MsgText Like Me.TextBox2.Text & "*" Select A
        End If
        e.Result = Result
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged, GridView2.SelectedIndexChanged
        btnAdd.Enabled = Not IsNothing(GridView1.SelectedValue) AndAlso Not IsNothing(GridView2.SelectedValue)
        lbMsg.Visible = False
        If sender Is GridView1 Then
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        If IsNothing(GridView1.SelectedValue) Then
            lbMsg.Text = "請選擇站台群組!"
            lbMsg.Visible = True
            Exit Sub
        End If
        If IsNothing(GridView2.SelectedValue) Then
            lbMsg.Text = "請選擇訊息!"
            lbMsg.Visible = True
            Exit Sub
        End If
        Dim InsertItem As New SiteGroupToMessage
        With InsertItem
            .FK_MessageID = GridView2.SelectedValue
            .FK_SiteGroupID = GridView1.SelectedValue
            .ReadWriteMode = CType(RadioButtonList1.SelectedValue, Integer)
        End With
        Try
            DBDataContext.SiteGroupToMessage.InsertOnSubmit(InsertItem)
            DBDataContext.SubmitChanges()
            lbMsg.Text = "已成功加入一筆資料!"
        Catch ex As Exception
            lbMsg.Text = "加入一筆資料失敗! 訊息:" & ex.ToString
        End Try
        Me.GridView1.SelectedIndex = -1
        Me.GridView2.SelectedIndex = -1
        lbMsg.Visible = True
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch OrElse TabContainer1.ActiveTab Is TabPanel1 Then
            e.Cancel = Not IsUserAlreadyPutSearch
            Exit Sub
        End If
        Dim Result As IQueryable(Of SiteGroupToMessage) = From A In DBDataContext.SiteGroupToMessage Select A
        If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
            Dim SiteGroupQryID As List(Of String) = (From A In DBDataContext.SiteGroup Where A.GroupName Like Me.TextBox1.Text & "*" Select A.ID).ToList
            Result = From A In Result Where SiteGroupQryID.Contains(A.FK_SiteGroupID) Select A
        End If
        If Not String.IsNullOrEmpty(Me.TextBox2.Text) Then
            Dim MessageQryID As List(Of String) = (From A In DBDataContext.Message Where A.MsgText Like Me.TextBox2.Text & "*" Select A.ID).ToList
            Result = From A In Result Where MessageQryID.Contains(A.FK_MessageID) Select A
        End If
        e.Result = Result
    End Sub

End Class