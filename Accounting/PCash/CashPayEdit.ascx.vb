Public Partial Class CashPayEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.PCashDataContext

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


#Region "初始化查詢條件 函式:InitSearchCondiction"
    ''' <summary>
    ''' 初始化查詢條件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitSearchCondiction()
        Me.TextBox1.Text = Format(New DateTime(Now.Year, 1, 1), "yyyy/MM/dd")
        Me.TextBox2.Text = Format(Now, "yyyy/MM/dd")
        Me.TextBox3.Text = 1
        Me.TextBox4.Text = 99999
        TextBox5.Text = Nothing
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitSearchCondiction()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
        Me.MultiView1.SetActiveView(Me.SearchResultView)
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.PCash1) = (From A In DBDataContext.PCash1 Select A)
        Result = From A In Result Where A.RecDate >= CType(TextBox1.Text, DateTime) And A.RecDate <= CType(TextBox2.Text, DateTime).AddDays(1).AddSeconds(-1) Select A
        Result = From A In Result Where A.Number >= Val(TextBox3.Text) And A.Number <= Val(TextBox4.Text) Select A
        Result = IIf(String.IsNullOrEmpty(TextBox5.Text), Result, From A In Result Where A.Descript.Contains(TextBox5.Text.Trim) Select A)
        e.Result = Result
    End Sub

    Protected Sub LDSEditData_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEditData.Selecting
        If IsNothing(GridView1.SelectedDataKey) Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.PCash1) = (From A In DBDataContext.PCash1 Select A)
        Result = From A In Result Where A.RecDate = CType(GridView1.SelectedDataKey.Item(0), DateTime) Select A
        Result = From A In Result Where A.Number = CType(GridView1.SelectedDataKey.Values(1), Integer) Select A
        e.Result = Result
    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsert.Click
        Me.btnReturnSearchResultView.Visible = False
        Me.FormView2.ChangeMode(FormViewMode.ReadOnly)
        Me.FormView2.ChangeMode(FormViewMode.Insert)
        Me.MultiView1.SetActiveView(Me.EditView)
    End Sub

    Protected Sub btnReturnSearchResultView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturnSearchResultView.Click
        Me.FormView2.ChangeMode(FormViewMode.ReadOnly)
        Me.MultiView1.SetActiveView(Me.SearchResultView)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If Not IsNothing(Me.GridView1.SelectedRow) Then
            Me.btnReturnSearchResultView.Visible = True
            Me.FormView2.ChangeMode(FormViewMode.ReadOnly)
            Me.FormView2.DataBind()
            Me.MultiView1.SetActiveView(Me.EditView)
        End If

    End Sub

    Private Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView2.PreRender
        Select Case True
            Case FormView2.CurrentMode = FormViewMode.Insert AndAlso CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text.Trim.Length = 0
                CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
                Dim InsertDateTimeYear As DateTime = New DateTime(CType(CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text, DateTime).Year, 1, 1)
                Dim GetLastNumber As Integer = (From A In DBDataContext.PCash1 Where A.RecDate >= InsertDateTimeYear And A.RecDate < InsertDateTimeYear.AddYears(1) Select A.Number Order By Number Descending).FirstOrDefault
                CType(Me.FormView2.FindControl("NumberTextBox"), TextBox).Text = IIf(GetLastNumber = 0, 1, GetLastNumber + 1)
                CType(Me.FormView2.FindControl("SaveTimeTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
                CType(Me.FormView2.FindControl("PutMoneyTextBox"), TextBox).Text = 0
        End Select
    End Sub

    Protected Sub RecDateTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub RecDateTextBox_TextChanged1(ByVal sender As Object, ByVal e As EventArgs)
        Dim InsertDateTimeYear As DateTime = New DateTime(CType(CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text, DateTime).Year, 1, 1)
        Dim GetLastNumber As Integer = (From A In DBDataContext.PCash1 Where A.RecDate >= InsertDateTimeYear And A.RecDate < InsertDateTimeYear.AddYears(1) Select A.Number Order By Number Descending).FirstOrDefault
        CType(Me.FormView2.FindControl("NumberTextBox"), TextBox).Text = IIf(GetLastNumber = 0, 1, GetLastNumber + 1)
    End Sub

End Class