Public Class ProductCashStatistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'tbOrderStartDate.Text = "2011/07"
            Dim W_OrderStartDate As Date = Now.AddMonths(-12)
            tbOrderStartDate.Text = W_OrderStartDate.ToString("yyyy/01")

            Dim W_TakeEndDate As Date = Date.Parse(Now.ToString("yyyy/MM") & "/01")
            tbTakeEndDate.Text = (W_TakeEndDate.AddDays(-1)).ToString("yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            '寬度
            For II As Integer = 0 To 9
                e.Row.Cells(II).Width = CType(IIf((II <= 6), 50, 90), Integer)
            Next

            '數字靠右對齊
            For II As Integer = 7 To 9
                e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            Next II
        End If
    End Sub

    Protected Sub btnDownToExcel_Click(sender As Object, e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim queryDataTable As DataTable = Search(Me.hfSQLF3.Value, Me.hfSQLF4.Value, Me.hfSQLF5.Value)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "製成品淨變現價值統計" & Me.hfSearchDateRange.Value & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Function MakeSQL1String(ByVal fromType As Integer, ByVal fromStartMonth As String, _
                                                                       ByVal fromMoneyX As String, ByVal fromMoney As String, ByVal fromTakeEndDate As String) As String
        Dim ReturnSQL1 As New StringBuilder
        Dim SQL4Of5DataAdjustment As String = "0.0000001"
        'Note:在某些欄位上在四捨五入前要先加上一個不會影響結果值的數字(ex:0.0000001),否則在四捨五入情況下會有問題

        ReturnSQL1.Append("SELECT breaklvl, ym, ch205, bol05, cia36, xo, bol06, CHAR(bol1401) bol1401  " & vbNewLine)
        ReturnSQL1.Append("               ,CHAR(DEC(ROUND(DOUBLE(bol2701)/bol1401+ " & SQL4Of5DataAdjustment & ",0))) PRICE " & vbNewLine)
        ReturnSQL1.Append("	           ,CHAR(DEC(ROUND(DOUBLE(amtn01)/bol1401+ " & SQL4Of5DataAdjustment & ",0))) PRICEN " & vbNewLine)
        ReturnSQL1.Append("	           ,OrderFlag " & vbNewLine)
        ReturnSQL1.Append("FROM ( " & vbNewLine)

        If fromType = 3 Then
            ReturnSQL1.Append("		SELECT 'F3' breaklvl,ym,ch205,bol05,cia36,' 'xo,'   'bol06, '2' OrderFlag " & vbNewLine)
        ElseIf fromType = 4 Then
            ReturnSQL1.Append("		SELECT 'F4' breaklvl,ym,ch205,bol05,cia36,xo,'   'bol06 , '1' OrderFlag" & vbNewLine)
        ElseIf fromType = 5 Then
            ReturnSQL1.Append("		SELECT 'F5' breaklvl,ym,ch205,bol05,cia36,xo,bol06 , '1' OrderFlag" & vbNewLine)
        End If

        ReturnSQL1.Append("		               ,SUM(bol14) bol1401,SUM(bol27) bol2701,SUM(amtn) amtn01 " & vbNewLine)
        ReturnSQL1.Append("		FROM ( " & vbNewLine)
        ReturnSQL1.Append("				SELECT V.*,DEC(ROUND( bol27-AMTNWeight*bol14 + " & SQL4Of5DataAdjustment & ",0))  amtn " & vbNewLine)
        ReturnSQL1.Append("				FROM ( " & vbNewLine)
        ReturnSQL1.Append("						SELECT substr(bol03,4,5) YM " & vbNewLine)
        ReturnSQL1.Append("							  ,t01.bol05,t03.cia36,t02.ch205 " & vbNewLine)
        ReturnSQL1.Append("							  ,REPLACE(REPLACE(BOL92,'O','X'),'E','X') XO " & vbNewLine)
        ReturnSQL1.Append("							  ,T01.bol06,t01.bol07,t01.bol14 " & vbNewLine)
        ReturnSQL1.Append("							  ,t01.bol27,t01.bol16,t01.bol17 " & vbNewLine)
        ReturnSQL1.Append("							  ,substr(cia59,1,2) || '.' ||  substr(cia59,3,2) thk " & vbNewLine)
        ReturnSQL1.Append("							  ,CASE BOL92 " & vbNewLine)
        ReturnSQL1.Append("									WHEN ' ' THEN " & vbNewLine)
        ReturnSQL1.Append("										CASE SUBSTR(bol03,4,5) " & vbNewLine)
        ReturnSQL1.Append("											WHEN '10110' THEN 5400 " & vbNewLine)
        'ReturnSQL1.Append("											ELSE 3800 " & vbNewLine)
        ReturnSQL1.Append("											ELSE " & fromMoney & " " & vbNewLine)
        ReturnSQL1.Append("										END " & vbNewLine)
        ReturnSQL1.Append("									ELSE " & vbNewLine)
        ReturnSQL1.Append("										CASE SUBSTR(bol03,4,5) " & vbNewLine)
        ReturnSQL1.Append("											WHEN '10110' THEN 2700 " & vbNewLine)
        ReturnSQL1.Append("											WHEN '10103' THEN 3000 " & vbNewLine)
        ReturnSQL1.Append("											WHEN '10105' THEN 3000 " & vbNewLine)
        ReturnSQL1.Append("											WHEN '10106' THEN 3000 " & vbNewLine)
        'ReturnSQL1.Append("											ELSE 1500 " & vbNewLine)
        ReturnSQL1.Append("											ELSE " & fromMoneyX & " " & vbNewLine)
        ReturnSQL1.Append("										END " & vbNewLine)
        ReturnSQL1.Append("							   END AMTNWeight " & vbNewLine)

        ReturnSQL1.Append("						FROM ( " & vbNewLine)
        ReturnSQL1.Append("														SELECT * " & vbNewLine)
        ReturnSQL1.Append("														FROM @#SLS300LB.SL2BOLPF t01  " & vbNewLine)
        ReturnSQL1.Append("														WHERE  SUBSTR(bol03,4,5)>='" & fromStartMonth & "'  " & vbNewLine)
        ReturnSQL1.Append("														     AND   DEC(bol01)  <= " & fromTakeEndDate & "  " & vbNewLine)

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Length > 0 Then
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            ReturnSQL1.Append("														   AND  bol05 IN  ('" & tbSteelKind.Text.Replace(",", "','") & "')  " & vbNewLine)
        End If


        ReturnSQL1.Append("						) T01 " & vbNewLine)

        ReturnSQL1.Append("							LEFT JOIN @#SLS300LB.SL2CH2PF t02 ON ch201=bol06 " & vbNewLine)
        ReturnSQL1.Append("							LEFT JOIN @#PPS100LB.PPSCIAPF t03 ON cia02=bol16 AND cia03=bol17 " & vbNewLine)
        ReturnSQL1.Append("						WHERE 1=1 " & vbNewLine)
        ReturnSQL1.Append("						  AND ch202<>'Y' " & vbNewLine)
        ReturnSQL1.Append("						  AND bol92 IN (' ','O','E') " & vbNewLine)
        ReturnSQL1.Append("				) V  " & vbNewLine)
        ReturnSQL1.Append("		) V   " & vbNewLine)

        If fromType = 3 Then
            ReturnSQL1.Append("		GROUP BY ym,ch205,bol05,cia36   " & vbNewLine)
        ElseIf fromType = 4 Then
            ReturnSQL1.Append("		GROUP BY ym,ch205,bol05,cia36,xo   " & vbNewLine)
        ElseIf fromType = 5 Then
            ReturnSQL1.Append("		GROUP BY ym,ch205,bol05,cia36,xo,bol06   " & vbNewLine)
        End If

        ReturnSQL1.Append(") V " & vbNewLine)

        Return ReturnSQL1.ToString
    End Function

    Private Sub MakerSQLStringToControl()
        Dim OrderStartDate As String = New CompanyORMDB.AS400DateConverter(Me.tbOrderStartDate.Text).TwSixCharsTypeData
        Dim TakeEndDate As String = New CompanyORMDB.AS400DateConverter(Me.tbTakeEndDate.Text).TwSixCharsTypeData

        If Not ((OrderStartDate.Length = 6 Or OrderStartDate.Length = 7) _
                      And (TakeEndDate.Length = 6 Or TakeEndDate.Length = 7) _
                      And (IsNumeric(tbMoneyX.Text) _
                           And IsNumeric(tbMoney.Text))) Then
            Me.hfSQLF3.Value = ""
            Me.hfSQLF4.Value = ""
            Me.hfSQLF5.Value = ""
            Me.hfSearchDateRange.Value = ""
            Exit Sub
        End If

        Dim StartMonth As String = OrderStartDate.Substring(0, OrderStartDate.Length - 2)

        Me.hfSQLF3.Value = MakeSQL1String(3, StartMonth, tbMoneyX.Text, tbMoney.Text, TakeEndDate)
        Me.hfSQLF4.Value = MakeSQL1String(4, StartMonth, tbMoneyX.Text, tbMoney.Text, TakeEndDate)
        If rdListBol06.SelectedValue = "Y" Then
            Me.hfSQLF5.Value = MakeSQL1String(5, StartMonth, tbMoneyX.Text, tbMoney.Text, TakeEndDate)
        End If

        Me.hfSearchDateRange.Value = StartMonth

    End Sub
#End Region

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromSQLF4"></param>
    ''' <param name="fromSQLF3"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQLF3 As String, ByVal fromSQLF4 As String, ByVal fromSQLF5 As String) As DataTable
        Dim ReturnDataTable As New DataTable

        If String.IsNullOrEmpty(fromSQLF4) OrElse String.IsNullOrEmpty(fromSQLF3) Then
            Return ReturnDataTable
        End If

        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        Dim QueryDataTableF3 As DataTable = Adapter.SelectQuery(fromSQLF3)  '小計
        Dim QueryDataTableF4 As DataTable = Adapter.SelectQuery(fromSQLF4)  '明細
        Dim QueryDataTableF5 As DataTable = Nothing
        If Not String.IsNullOrEmpty(fromSQLF5) Then QueryDataTableF5 = Adapter.SelectQuery(fromSQLF5) '表面

        Dim QueryDataTableAll As DataTable

        '複製結構 
        QueryDataTableAll = QueryDataTableF3.Clone()
        '複製資料 
        For Each eachItemRow As DataRow In QueryDataTableF3.Rows
            QueryDataTableAll.ImportRow(eachItemRow)
        Next
        For Each eachItemRow As DataRow In QueryDataTableF4.Rows
            QueryDataTableAll.ImportRow(eachItemRow)
        Next

        If Not QueryDataTableF5 Is Nothing Then
            For Each eachItemRow As DataRow In QueryDataTableF5.Rows
                QueryDataTableAll.ImportRow(eachItemRow)
            Next
        End If

        For Each eachItemRow As DataRow In QueryDataTableAll.Rows
            eachItemRow.Item("BOL1401") = ProductManufactureCostStatistics.StringFormatNumberOf3Symbol(eachItemRow.Item("BOL1401"))
            eachItemRow.Item("PRICE") = ProductManufactureCostStatistics.StringFormatNumberOf3Symbol(eachItemRow.Item("PRICE"))
            eachItemRow.Item("PRICEN") = ProductManufactureCostStatistics.StringFormatNumberOf3Symbol(eachItemRow.Item("PRICEN"))
        Next

        ReturnDataTable = (From A In QueryDataTableAll _
                                                Order By A.Item("ym"), A.Item("ch205"), A.Item("bol05") _
                                                                , Regex.Replace(A.Item("cia36"), "[0-9]", "Z"), A.Item("cia36") _
                                                                , A.Item("OrderFlag"), A.Item("xo") _
                                                                , IIf(A.Item("bol06").ToString.Trim = "", "ZZZ", Regex.Replace(A.Item("bol06"), "[0-9]", "Z")), A.Item("bol06") _
                                                 Select A).CopyToDataTable

        ReturnDataTable.Columns.Remove("OrderFlag")
        'ReturnDataTable.Columns.Remove("BreakLvl")

        ReturnDataTable.Columns("ym").ColumnName = "年月"
        ReturnDataTable.Columns("ch205").ColumnName = "CR / HR"
        ReturnDataTable.Columns("bol05").ColumnName = "鋼種"
        ReturnDataTable.Columns("cia36").ColumnName = "TYPE"
        ReturnDataTable.Columns("xo").ColumnName = "內外銷"
        ReturnDataTable.Columns("bol06").ColumnName = "表面"
        ReturnDataTable.Columns("bol1401").ColumnName = "重量"
        ReturnDataTable.Columns("price").ColumnName = "單價"
        ReturnDataTable.Columns("pricen").ColumnName = "淨售價"
        Return ReturnDataTable
    End Function

#End Region

End Class