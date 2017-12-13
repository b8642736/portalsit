Public Partial Class GroupSearch
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext
    Public Event GroupSelectedEvent(ByVal SelectGroupCode As String)    '選擇群組事件
    Public Event GroupSearchedEvent(ByVal SenderControl As GroupSearch)       '查詢群組事件

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

#Region "選擇群組代碼 屬性:SelectedGroupCode"
    ''' <summary>
    ''' 選擇群組代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedGroupCode() As String
        Get
            Return (ViewState("_SelectedGroupCode"))
        End Get
        Set(ByVal value As String)
            ViewState("_SelectedGroupCode") = value
        End Set
    End Property
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        lblSelectGroup.Text = Nothing
        Me.SelectedGroupCode = Nothing
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
        RaiseEvent GroupSearchedEvent(Me)
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        Me.SelectedGroupCode = Nothing
    End Sub


    Private Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        GridView1_SelectedIndexChanged(GridView1, Nothing)
        lblSelectGroup.Text = Nothing
        SelectedGroupCode = Nothing
        RaiseEvent GroupSearchedEvent(Me)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If IsNothing(GridView1.SelectedValue) Then
            Exit Sub
        End If
        lblSelectGroup.Text = GridView1.SelectedRow.Cells(0).Text
        SelectedGroupCode = GridView1.SelectedValue
        RaiseEvent GroupSelectedEvent(CType(GridView1.SelectedValue, String).Trim)
    End Sub

    Private Sub LDSEditDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEditDataSource.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.WebGroupAccount) = (From A In DBDataContext.WebGroupAccount Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.GroupCode.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.GroupName.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.Memo1.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result
    End Sub

End Class