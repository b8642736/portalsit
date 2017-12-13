Public Class MasterStock
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    'Shared Function Search1(ByVal SQLString1 As String, ByVal SQLString2 As String) As List(Of SLS300LB.MasterStockRow)

    'End Function
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal SQLString As String, ByVal OutFormat As String) As SLS300LB.MasterStockDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.MasterStockDataTable
        End If
        Dim ReturnValue As New SLS300LB.MasterStockDataTable
        Dim SearchResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery
        Dim SearchSubResult As List(Of DataRow) = Nothing
        For Each EachCustomer As String In (From A In SearchResult Select CType(A.Item("ORDERFIELD"), String) Distinct).ToList
            Dim EachCustomerTemp As String = EachCustomer
            SearchSubResult = (From A In SearchResult Where CType(A.Item("ORDERFIELD"), String) = EachCustomerTemp Select A).ToList
            If OutFormat = "DETAIL" Then
                For Each EachStockType As String In (From A In SearchSubResult Select CType(A.Item("IsCompanyStock"), String) Distinct).ToList
                    Dim EachStockTypeTemp As String = EachStockType
                    Dim AddItemDatas As List(Of DataRow) = (From A In SearchSubResult Where CType(A.Item("IsCompanyStock"), String) = EachStockTypeTemp Select A).ToList
                    AddSumGroupItemsOrItemOnly(ReturnValue, AddItemDatas, False, Nothing)
                    AddSumGroupItemsOrItemOnly(ReturnValue, AddItemDatas, True, EachCustomerTemp & "," & EachStockTypeTemp)
                Next
            End If
            AddSumGroupItemsOrItemOnly(ReturnValue, (From A In SearchResult Where CType(A.Item("ORDERFIELD"), String) = EachCustomerTemp Select A).ToList, True, EachCustomerTemp)
        Next
        AddSumGroupItemsOrItemOnly(ReturnValue, (From A In SearchResult Select A).ToList, True, Nothing)

        Return ReturnValue
    End Function

    Private Sub AddSumGroupItemsOrItemOnly(ByVal ReturnValue As DataTable, ByVal SourceGroupDatas As List(Of DataRow), ByVal IsGroupData As Boolean, ByVal GroupKeys As String)
        If SourceGroupDatas.Count = 0 Then
            Exit Sub
        End If
        Dim GroupKey() As String = Nothing
        If Not String.IsNullOrEmpty(GroupKeys) Then
            GroupKey = GroupKeys.Split(",")
        End If


        Dim StockTypeString As String = "--"
        If IsGroupData AndAlso Not IsNothing(GroupKey) AndAlso GroupKey.Length < 2 Then
            Dim StockTypes As List(Of Integer) = (From A In SourceGroupDatas Select CType(A.Item("IsCompanyStock"), Integer) Distinct).ToList
            Select Case True
                Case StockTypes.Count = 1
                    StockTypeString = IIf(StockTypes(0) = 1, "--(庫存)", "--(寄庫)")
                Case StockTypes.Count = 2
                    StockTypeString = "--(庫存/寄庫)"
            End Select
        End If

        Dim AddItem As SLS300LB.MasterStockRow = Nothing
        Select Case True
            Case Not IsGroupData
                For Each EachItem As DataRow In SourceGroupDatas
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .客戶編號 = CType(EachItem.Item("CIA04"), String).Substring(0, 3)
                        .客戶名稱 = CompanyORMDB.SLS300LB.SL2CUAPF.GetShortName(.客戶編號)
                        .客戶名稱 &= IIf(CType(EachItem.Item("CIA34"), String) = " ", "(內銷)", "(外銷)")
                        .庫存或寄庫 = IIf(CType(EachItem.Item("IsCompanyStock"), Boolean), "庫存", "寄庫")
                        .鋼捲號碼 = CType(EachItem.Item("CIA02"), String) & CType(EachItem.Item("CIA03"), String)
                        .重量 = Format(CType(EachItem.Item("CIA13"), Double), "#,#")
                        .寄放天數 = Format(Now.Subtract((New CompanyORMDB.AS400DateConverter(CType(EachItem.Item("CIA58"), Integer))).DateValue).Days, "#,#.#")
                    End With
                    ReturnValue.Rows.Add(AddItem)
                Next
            Case IsGroupData AndAlso IsNothing(GroupKey)
                AddItem = ReturnValue.NewRow
                With AddItem
                    .客戶編號 = "合計:"
                    .客戶名稱 = ""
                    .庫存或寄庫 = StockTypeString ' "--"
                    .鋼捲號碼 = "--"
                    .重量 = Format((From A In SourceGroupDatas Select CType(A.Item("CIA13"), Double)).Sum, "#,#")
                    .寄放天數 = Format((From A In SourceGroupDatas Select Now.Subtract((New CompanyORMDB.AS400DateConverter(CType(A.Item("CIA58"), Integer))).DateValue).Days).Average, "#,#.#")
                End With
                ReturnValue.Rows.Add(AddItem)
            Case IsGroupData AndAlso GroupKey.Length = 1
                AddItem = ReturnValue.NewRow
                With AddItem
                    .客戶編號 = GroupKey(0) ' CType(SourceGroupDatas(0).Item("CIA04"), String).Substring(0, 3)
                    .客戶名稱 = CompanyORMDB.SLS300LB.SL2CUAPF.GetShortName(.客戶編號)
                    .客戶名稱 &= IIf(CType(SourceGroupDatas(0).Item("CIA34"), String) = " ", "(內銷)", "(外銷)")
                    .庫存或寄庫 = StockTypeString ' "--"
                    .鋼捲號碼 = "--"
                    .重量 = Format((From A In SourceGroupDatas Select CType(A.Item("CIA13"), Double)).Sum, "#,#")
                    .寄放天數 = Format((From A In SourceGroupDatas Select Now.Subtract((New CompanyORMDB.AS400DateConverter(CType(A.Item("CIA58"), Integer))).DateValue).Days).Average, "#,#.#")
                End With
                ReturnValue.Rows.Add(AddItem)
            Case IsGroupData AndAlso GroupKey.Length = 2
                AddItem = ReturnValue.NewRow
                With AddItem
                    .客戶編號 = GroupKey(0) ' CType(SourceGroupDatas(0).Item("CIA04"), String).Substring(0, 3)
                    .客戶名稱 = CompanyORMDB.SLS300LB.SL2CUAPF.GetShortName(.客戶編號)
                    .客戶名稱 &= IIf(CType(SourceGroupDatas(0).Item("CIA34"), String) = " ", "(內銷)", "(外銷)")
                    .庫存或寄庫 = IIf(CType(GroupKey(1), Boolean), "庫存", "寄庫")
                    .鋼捲號碼 = "--"
                    .重量 = Format((From A In SourceGroupDatas Select CType(A.Item("CIA13"), Double)).Sum, "#,#")
                    .寄放天數 = Format((From A In SourceGroupDatas Select Now.Subtract((New CompanyORMDB.AS400DateConverter(CType(A.Item("CIA58"), Integer))).DateValue).Days).Average, "#,#.#")
                End With
                ReturnValue.Rows.Add(AddItem)
        End Select
    End Sub

#End Region

#Region "產生查詢至控製項 函式:MakeQryToControl"
    Private Sub MakeQryToControl()
        '有主存庫查詢  cia16=" " 代表為非正常品
        Dim SQLString1 As String = "Select LEFT(A.CIA04,3) AS ORDERFIELD , A.* , 1 AS IsCompanyStock from @#PPS100LB.PPSCIALJ AS A Where cia04<>'          '  and cia16<>' ' "

        '寄庫查詢(為無主存庫資料)  cia16=" " 代表為非正常品
        Dim SQLString2 As String = "Select  LEFT(B.CIA04,3) AS ORDERFIELD , B.* , 0 AS IsCompanyStock from @#PPS100LB.PPSCIAPF AS B Where cia04<>'          '  and cia16<>' ' and cia63>0 and cia64=0 and cia47<>'B' "

        Dim SubWhereString As String = " AND CIA58>=" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwIntegerTypeData & " AND CIA58<=" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwIntegerTypeData
        Select Case True
            Case RadioButtonList3.SelectedValue = "HOMESELL"
                SubWhereString &= " AND CIA34=' '"
            Case RadioButtonList3.SelectedValue = "EXTRASELL"
                SubWhereString &= " AND CIA34<>' '"
        End Select
        SQLString1 &= SubWhereString
        SQLString2 &= SubWhereString
        Select Case True
            Case RadioButtonList1.SelectedValue = "Y1"
                hfQry1.Value = SQLString1 & " Order by CIA34,ORDERFIELD"
            Case RadioButtonList1.SelectedValue = "Y2"
                hfQry1.Value = SQLString2 & " Order by CIA34,ORDERFIELD"
            Case Else
                hfQry1.Value = SQLString1 & " UNION " & SQLString2 & " Order by CIA34,ORDERFIELD, IsCompanyStock Desc"
        End Select
        hfOutFormat.Value = RadioButtonList2.SelectedValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddMonths(-1), "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        MakeQryToControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class