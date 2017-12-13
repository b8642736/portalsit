Public Partial Class CasherIn
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As CashierDataSet.CashInDataTableDataTable

        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchResult As List(Of CompanyORMDB.COME.COME01PF) = CompanyORMDB.COME.COME01PF.CDBSetDataTableToObjects(Of CompanyORMDB.COME.COME01PF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)

        Dim ReturnValue As New CashierDataSet.CashInDataTableDataTable
        Dim AddRow As CashierDataSet.CashInDataTableRow
        For Each EachGroupItem As String In (From A In SearchResult Select A.INITEM).Distinct
            Dim EachGroupItemTemp As String = EachGroupItem
            Dim GourpDatas As List(Of CompanyORMDB.COME.COME01PF) = (From A In SearchResult Where A.INITEM Like EachGroupItemTemp & "*" Select A).ToList
            For Each EachItem As CompanyORMDB.COME.COME01PF In GourpDatas
                AddRow = ReturnValue.NewRow
                With AddRow
                    .收入項目 = EachItem.INITEM
                    .收入金額 = EachItem.DOLLAR
                    .財務收款日 = EachItem.COMEDT
                    .六聯單編號 = EachItem.SIXNO8
                    .摘要 = EachItem.MEMO26
                End With
                ReturnValue.Rows.Add(AddRow)
            Next
            AddRow = ReturnValue.NewRow
            With AddRow
                .收入項目 = EachGroupItem & " 小計"
                .收入金額 = (From A In GourpDatas Select A.DOLLAR).Sum
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        AddRow = ReturnValue.NewRow
        With AddRow
            .收入項目 = "總計:"
            .收入金額 = (From A In SearchResult Select A.DOLLAR).Sum
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


#Region "取得六聯單編號項目 方法:GetSixNO8Items"
    ''' <summary>
    ''' 取得六聯單編號項目
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSixNO8Items() As List(Of String)
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "Select DISTINCT SIXNO8 From " & (New CompanyORMDB.COME.COME01PF).CDBFullAS400DBPath & " Where TRIM(SIXNO8)<>'' AND LENGTH(TRIM(SIXNO8))=1 ")
        Dim ReturnValue As New List(Of String)
        For Each EachItem As DataRow In QryAdapter.SelectQuery.Rows
            ReturnValue.Add(EachItem.Item(0))
        Next
        Return ReturnValue
    End Function
#End Region
#Region "產生查詢字串至參數控制項 函式:MakeQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至參數控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        Dim WhereString As String = Nothing

        Dim CheckedItemString As String = Nothing
        Dim IsOtherAll As Boolean = False
        For Each EachItem As ListItem In Me.CheckBoxList1.Items
            If EachItem.Selected Then
                If EachItem.Value = "OtherALL" Then
                    IsOtherAll = True
                Else
                    CheckedItemString &= IIf(IsNothing(CheckedItemString), "'", ",'") & EachItem.Value & "'"
                End If
            End If
        Next
        WhereString &= " AND (SIXNO8 IN (" & IIf(IsNothing(CheckedItemString), "''", CheckedItemString) & ") " & IIf(Not IsOtherAll, ")", " OR LENGTH(TRIM(SIXNO8))>1 )")

        Dim ControlStartDate As Date = CType(TextBox2.Text, Date)
        Dim ControlEndDate As Date = CType(TextBox3.Text, Date)
        Dim StartDate As String = Format(Format(ControlStartDate, "yyyy") - 1911, "000") & Format(ControlStartDate, "MMdd")
        Dim EndDate As String = Format(Format(ControlEndDate, "yyyy") - 1911, "000") & Format(ControlEndDate, "MMdd")
        WhereString &= " AND COMEDT >= '" & StartDate & "' and COMEDT <='" & EndDate & "'"
        If CheckBox1.Checked Then
            WhereString &= " AND INITEM = '" & TextBox1.Text.Trim.Replace("'", Nothing) & "' "
        End If
        Me.HFSQLQry.Value = "Select * from " & (New CompanyORMDB.COME.COME01PF).CDBFullAS400DBPath & " " & IIf(IsNothing(WhereString), Nothing, " Where 1=1 " & WhereString & " Order By INITEM")
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'TextBox2.Text = Format(Now.Date.AddDays(-1), "yyyy/MM/dd")
            TextBox2.Text = Format(Now.Date, "yyyy/MM/") & "01"
            TextBox3.Text = Format(Now.Date, "yyyy/MM/dd")

            CheckBoxList1.Items.Clear()
            For Each EachItem As String In GetSixNO8Items()
                CheckBoxList1.Items.Add(New ListItem(EachItem.Trim, EachItem))
            Next
            CheckBoxList1.Items.Add(New ListItem("其它所有", "OtherALL"))
            For Each EachItem As ListItem In CheckBoxList1.Items
                EachItem.Selected = True
            Next
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.MakeQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        IsUserAlreadyPutSearch = True
        Me.MakeQryStringToControl()
        Dim ExcelConvert As New DataConvertExcel(Me.Search(Me.HFSQLQry.Value), "財務收入" & Format(Now, "yyyyMMdd") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class