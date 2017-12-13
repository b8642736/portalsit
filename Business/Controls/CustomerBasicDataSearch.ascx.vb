Public Partial Class CustomerBasicDataSearch
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal CustomerName As String, ByVal CustomerAddress As String) As List(Of CompanyORMDB.SLS300LB.SL2CUAPF)
        Dim WhereString As String = Nothing
        If Not String.IsNullOrEmpty(CustomerName) AndAlso CustomerName.Trim.Length > 0 Then
            WhereString &= " CUA02 LIKE '%" & CustomerName.Trim.Replace("'", Nothing) & "%'"
        End If
        If Not String.IsNullOrEmpty(CustomerAddress) AndAlso CustomerAddress.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), "", " AND ")
            WhereString &= "(CUA05 LIKE '%" & CustomerAddress.Trim.Replace("'", Nothing) & "%' OR CUA08 LIKE '%" & CustomerAddress.Trim.Replace("'", Nothing) & "%')"
        End If
        Dim SQLString As String = "Select * from @#SLS300LB.SL2CUAPF " & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CUAPF) = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2CUAPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        Return SearchResult
    End Function

#End Region

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

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
        Me.IsUserAlreadyPutSearch = False
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub
End Class