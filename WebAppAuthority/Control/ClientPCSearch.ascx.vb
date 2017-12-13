Public Partial Class ClientPCSearch
    Inherits System.Web.UI.UserControl


    Dim DBDataContext As New ClassDBDataContext
    Public Event ClientPCSelectedEvent(ByVal SelectClientPCIP As String)    '選擇用戶端PC事件
    Public Event ClientPCSearchedEvent(ByVal SenderControl As ClientPCSearch)       '查詢戶端PC事件

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

#Region "選擇使用戶端IP 屬性:SelectedClientPCIP"
    ''' <summary>
    ''' 選擇使用戶端IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedClientPCIP() As String
        Get
            Return (ViewState("_SelectedClientPCIP"))
        End Get
        Set(ByVal value As String)
            ViewState("_SelectedClientPCIP") = value
        End Set
    End Property
#End Region

#Region "搜尋前篩選 屬性:BeforeSearchFilter"
    ''' <summary>
    ''' 搜尋前篩選
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BeforeSearchFilter() As IQueryable(Of CompanyLINQDB.WebClientPCAccount)
        Get
            Return Me.Session("_BeforeSearchFilter_" & MyClass.ToString)
        End Get
        Set(ByVal value As IQueryable(Of CompanyLINQDB.WebClientPCAccount))
            Me.Session("_BeforeSearchFilter_" & MyClass.ToString) = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.lblSelectCleintPCIP.Text = Nothing
        Me.SelectedClientPCIP = Nothing
        Me.IsUserAlreadyPutSearch = True
        GridView1.DataBind()
        RaiseEvent ClientPCSearchedEvent(Me)
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        Me.SelectedClientPCIP = Nothing
    End Sub

    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1_SelectedIndexChanged(GridView1, Nothing)
        lblSelectCleintPCIP.Text = Nothing
        SelectedClientPCIP = Nothing
        RaiseEvent ClientPCSearchedEvent(Me)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If IsNothing(GridView1.SelectedValue) Then
            Exit Sub
        End If
        Me.lblSelectCleintPCIP.Text = GridView1.SelectedRow.Cells(0).Text
        SelectedClientPCIP = GridView1.SelectedValue
        RaiseEvent ClientPCSelectedEvent(CType(GridView1.SelectedValue, String).Trim)
    End Sub

    Private Sub LDSWebUserLogin_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebClientPC.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.WebClientPCAccount) = IIf(IsNothing(BeforeSearchFilter), (From A In DBDataContext.WebClientPCAccount Select A), BeforeSearchFilter)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.ClientIP.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.PCName.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.Memo1.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result

    End Sub

End Class