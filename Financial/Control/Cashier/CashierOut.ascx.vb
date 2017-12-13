Public Partial Class CashierOut
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="PayStartDate"></param>
    ''' <param name="PayEndDate"></param>
    ''' <param name="IsFilterAccounItem"></param>
    ''' <param name="FilterAccounItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal PayStartDate As Date, ByVal PayEndDate As Date, ByVal IsFilterAccounItem As Boolean, ByVal FilterAccounItem As String) As CashierDataSet.CashOutDataTableDataTable

        Dim WhereString As String = Nothing

        Dim StartDate As String = Format(Format(PayStartDate, "yyyy") - 1911, "000") & Format(PayStartDate, "MMdd")
        Dim EndDate As String = Format(Format(PayEndDate, "yyyy") - 1911, "000") & Format(PayEndDate, "MMdd")
        WhereString &= " PAYDAT >= '" & StartDate & "' and PAYDAT <='" & EndDate & "'"
        If IsFilterAccounItem Then
            WhereString &= IIf(IsNothing(WhereString), "", " AND ")
            WhereString &= "ACITEM = '" & FilterAccounItem & "' "
        End If

        'Dim SQLString As String = "Select * from " & (New CompanyORMDB.CASH.CASH01PF).CDBFullAS400DBPath & " " & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString & " Order By ACITEM")
        Dim SQLString As String = "Select * from " & (New CompanyORMDB.CASH.CASH01PF).CDBFullAS400DBPath & " " & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString & " Order By ACITEM, SHTNOO")

        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchResult As List(Of CompanyORMDB.CASH.CASH01PF) = CompanyORMDB.CASH.CASH01PF.CDBSetDataTableToObjects(Of CompanyORMDB.CASH.CASH01PF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)

        Dim ReturnValue As New CashierDataSet.CashOutDataTableDataTable
        Dim AddRow As CashierDataSet.CashOutDataTableRow
        For Each EachGroupItem As String In (From A In SearchResult Select A.ACITEM).Distinct
            Dim EachGroupItemTemp As String = EachGroupItem
            Dim GourpDatas As List(Of CompanyORMDB.CASH.CASH01PF) = (From A In SearchResult Where A.ACITEM = EachGroupItemTemp Select A).ToList
            For Each EachItem As CompanyORMDB.CASH.CASH01PF In GourpDatas
                AddRow = ReturnValue.NewRow
                With AddRow
                    .支出科目 = EachItem.ACITEM
                    .傳票 = EachItem.SHTNOO
                    .用途 = EachItem.USEFOR
                    .支票金額 = EachItem.CHKAMT
                    .付款日 = EachItem.PAYDAT
                End With
                ReturnValue.Rows.Add(AddRow)
            Next
            AddRow = ReturnValue.NewRow
            With AddRow
                .支出科目 = EachGroupItem & " 小計"
                .支票金額 = (From A In GourpDatas Select A.CHKAMT).Sum
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        AddRow = ReturnValue.NewRow
        With AddRow
            .支出科目 = "總計:"
            .支票金額 = (From A In SearchResult Select A.CHKAMT).Sum
        End With
        ReturnValue.Rows.Add(AddRow)

        Return ReturnValue

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
        If Not IsPostBack Then
            ' TextBox2.Text = Format(Now.Date.AddDays(-1), "yyyy/MM/dd")
            TextBox2.Text = Format(Now.Date, "yyyy/MM/") & "01"
            TextBox3.Text = Format(Now.Date, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        IsUserAlreadyPutSearch = True
        Dim ExcelConvert As New DataConvertExcel(Me.Search(Me.TextBox2.Text, Me.TextBox3.Text, Me.CheckBox1.Checked, Me.TextBox1.Text), "出納支出" & Format(Now, "yyyyMMdd") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

End Class