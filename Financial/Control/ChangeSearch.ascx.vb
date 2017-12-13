Public Class ChangeSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As FinancialDataSet.ChangeSearchDataTable
        Dim ReturnValue As New FinancialDataSet.ChangeSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchResult As DataTable = QryAdapter.SelectQuery(SQLString)

        Dim AddItem As Financial.FinancialDataSet.ChangeSearchRow
        For Each EachRow As DataRow In SearchResult.Rows
            AddItem = ReturnValue.NewRow
            With AddItem
                .客戶編號 = EachRow.Item("CUA01")
                .客戶名稱 = EachRow.Item("CUA02")
                .統一編號 = EachRow.Item("CUA03")
                .押匯日期 = EachRow.Item("SU709")
                .匯票號碼 = EachRow.Item("SU702")
                .銀行別 = EachRow.Item("SU704")
                .金額 = EachRow.Item("SU703")
                .收款單 = EachRow.Item("SU701")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim StartDate As String = (New CompanyORMDB.AS400DateConverter(CType(tbStartDate.Text, Date))).TwSevenCharsTypeData
        Dim EndDate As String = (New CompanyORMDB.AS400DateConverter(CType(tbEndDate.Text, Date))).TwSevenCharsTypeData
        Dim SQLString As String = "Select A.* , B.CUA01,B.CUA02,B.CUA03 From  @#SGA600LB.SGAU07PF A LEFT OUTER JOIN @#SLS300LB.SL2CUAPF B ON A.SU705=B.CUA01  Where A.SU709>='" & StartDate & "' AND A.SU709<='" & EndDate & "' "

        If Not String.IsNullOrEmpty(tbCustIDs.Text) AndAlso tbCustIDs.Text.Trim.Length > 0 Then
            SQLString &= " AND A.SU705 IN ('" & tbCustIDs.Text.Replace(",", "','") & "') "
        End If

        If Not String.IsNullOrEmpty(tbCustCompanyIDs.Text) AndAlso tbCustCompanyIDs.Text.Trim.Length > 0 Then
            SQLString &= " AND B.CUA03 IN ('" & tbCustCompanyIDs.Text.Replace(",", "','") & "') "
        End If


        Me.hfSQLString.Value = SQLString & " Order by CUA02 "
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ExcelConvert As New DataConvertExcel(Search(Me.hfSQLString.Value), "國內押匯查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class