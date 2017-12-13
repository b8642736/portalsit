Public Class OrderStatusStatisticsSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call InitFrom()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call InitFrom()
    End Sub

    Private Sub InitFrom()
        Dim W_Now As Date = Now
        tbStartMonth.Text = Format(New Date(W_Now.Year, 1, 1), "yyyy/MM")
        tbEndMonth.Text = Format(W_Now, "yyyy/MM")

        tbOrderMonth.Text = Format(W_Now, "yyyy/MM")
    End Sub

#Region "MakeQuerySQL"
    Private Sub MakeQuerySQL()
        Dim queryStartMonth As String = New AS400DateConverter(tbStartMonth.Text).TwSevenCharsTypeData
        Dim queryEndMonth As String = New AS400DateConverter(tbEndMonth.Text).TwSevenCharsTypeData
        Dim queryOrderMonth As String = New AS400DateConverter(tbOrderMonth.Text).TwSevenCharsTypeData
        queryStartMonth = Mid(queryStartMonth, 1, 5)
        queryEndMonth = Mid(queryEndMonth, 1, 5)
        queryOrderMonth = Mid(queryOrderMonth, 1, 5)

        Dim SQLSameCuc91 As New StringBuilder
        Dim SQL1Other As New StringBuilder
        Dim SQL2Order As New StringBuilder

        SQLSameCuc91.Append("                   CASE  IFNULL(b.cuc91, 'NULL') " & vbNewLine)
        SQLSameCuc91.Append("                               WHEN 'NULL' THEN " & vbNewLine)
        SQLSameCuc91.Append("		          CASE qtn29 " & vbNewLine)
        SQLSameCuc91.Append("			     WHEN 'E' THEN '國貿' " & vbNewLine)
        SQLSameCuc91.Append("			     WHEN 'O' THEN '長約外銷' " & vbNewLine)
        SQLSameCuc91.Append("			     ELSE  " & vbNewLine)
        SQLSameCuc91.Append("				CASE qtn01 " & vbNewLine)
        SQLSameCuc91.Append("				          WHEN 'E35' THEN '長約外銷' " & vbNewLine)
        SQLSameCuc91.Append("				          WHEN 'E79' THEN '長約外銷' " & vbNewLine)
        SQLSameCuc91.Append("				          ELSE '內銷' " & vbNewLine)
        SQLSameCuc91.Append("				END                       " & vbNewLine)
        SQLSameCuc91.Append("		          END  " & vbNewLine)
        SQLSameCuc91.Append(" " & vbNewLine)
        SQLSameCuc91.Append("                                ELSE " & vbNewLine)
        SQLSameCuc91.Append("                                          CASE b.cuc91 " & vbNewLine)
        SQLSameCuc91.Append("                                                     WHEN 'F0' THEN '長約外銷' " & vbNewLine)
        SQLSameCuc91.Append("                                                     WHEN 'E0' THEN '國貿' " & vbNewLine)
        SQLSameCuc91.Append("                                                     ELSE  '內銷' " & vbNewLine)
        SQLSameCuc91.Append("                                          END " & vbNewLine)
        SQLSameCuc91.Append("                   END cuc91 " & vbNewLine)


        SQL1Other.Append("SELECT cuc91,qtn03,ROUND(SUM(c00006),0) s00006,ROUND(SUM(c00007),0) s00007 ,'' Space " & vbNewLine)
        SQL1Other.Append("FROM ( " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("SELECT       " & vbNewLine)
        SQL1Other.Append(SQLSameCuc91.ToString)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("                   , SUBSTR(qtn03, 1, 3) qtn03 " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("                    ,CASE  " & vbNewLine)
        SQL1Other.Append("                              WHEN (qtn12-qtn21)>=3 then (qtn12-qtn21) " & vbNewLine)
        SQL1Other.Append("                              ELSE 0 " & vbNewLine)
        SQL1Other.Append("                     END C00006 " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("                   ,CASE qtn93 " & vbNewLine)
        SQL1Other.Append("                              WHEN ' ' THEN  " & vbNewLine)
        SQL1Other.Append("                                           CASE " & vbNewLine)
        SQL1Other.Append("                                                    WHEN (qtn12-qtn21-qtn22) >=3 THEN (qtn12-qtn21-qtn22) " & vbNewLine)
        SQL1Other.Append("                                                     ELSE 0 " & vbNewLine)
        SQL1Other.Append("                                           END " & vbNewLine)
        SQL1Other.Append("                              ELSE 0 " & vbNewLine)
        SQL1Other.Append("                     END C00007 " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("FROM @#SLS300LB.SL2QTNL1 A " & vbNewLine)
        SQL1Other.Append("          LEFT JOIN @#SLS300LB.SL2CUCPF B ON b.cuc01=a.qtn01 " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("WHERE SUBSTR(qtn02,1,5) BETWEEN '" & queryStartMonth & "' AND '" & queryEndMonth & "' " & vbNewLine)
        SQL1Other.Append("     AND qtn04 in (SELECT DISTINCT ch201 FROM SLS300LB.SL2CH2PF WHERE ch202<>'Y') " & vbNewLine)
        SQL1Other.Append("     AND qtn91= ' ' " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append(") V " & vbNewLine)
        SQL1Other.Append(" " & vbNewLine)
        SQL1Other.Append("GROUP BY cuc91,qtn03 " & vbNewLine)
        SQL1Other.Append("ORDER BY cuc91,qtn03 " & vbNewLine)



        SQL2Order.Append("SELECT cuc91,qtn03,ROUND(SUM(qtn12),0) sqtn12 ,'' Space " & vbNewLine)
        SQL2Order.Append("FROM ( " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append("SELECT       " & vbNewLine)
        SQL2Order.Append(SQLSameCuc91.ToString)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append("                   , SUBSTR(qtn03, 1, 3) qtn03 " & vbNewLine)
        SQL2Order.Append("                   ,qtn12 " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append("FROM @#SLS300LB.SL2QTNL1 A " & vbNewLine)
        SQL2Order.Append("          LEFT JOIN @#SLS300LB.SL2CUCPF B ON b.cuc01=a.qtn01 " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append("WHERE SUBSTR(qtn02,1,5) ='" & queryOrderMonth & "' " & vbNewLine)
        SQL2Order.Append("     AND qtn04 in (SELECT DISTINCT ch201 FROM SLS300LB.SL2CH2PF WHERE ch202<>'Y') " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append(") V " & vbNewLine)
        SQL2Order.Append(" " & vbNewLine)
        SQL2Order.Append("GROUP BY cuc91,qtn03 " & vbNewLine)
        SQL2Order.Append("ORDER BY cuc91,qtn03 " & vbNewLine)

        hfSQL1Other.Value = SQL1Other.ToString
        hfSQL2Order.Value = SQL2Order.ToString
        hfParam.Value = Left(queryOrderMonth, 3) & "/" & Right(queryOrderMonth, 2) & "|" & "( " _
                                          & Left(queryStartMonth, 3) & "/" & Right(queryStartMonth, 2) & " ~ " _
                                          & Left(queryEndMonth, 3) & "/" & Right(queryEndMonth, 2) & " )"
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQuerySQL()
    End Sub


    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQuerySQL()

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim QueryDataTable As DataTable = Search(Me.hfParam.Value, hfSQL1Other.Value, hfSQL2Order.Value)

        For Each eachItem As DataColumn In QueryDataTable.Columns
            eachItem.ColumnName = eachItem.ColumnName.Replace("類別", "　")
        Next

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "客戶訂單狀況查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub


#Region "查詢客戶訂單狀況：Search"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search(ByVal fromParam As String, ByVal fromSQL1Other As String, ByVal fromSQL2Order As String) As EISDataSet.OrderStatusStatisticsDataTable
        Dim retDatatable As EISDataSet.OrderStatusStatisticsDataTable = New EISDataSet.OrderStatusStatisticsDataTable
        Dim AddItem As EISDataSet.OrderStatusStatisticsRow = Nothing

        If String.IsNullOrEmpty(fromSQL1Other) OrElse String.IsNullOrEmpty(fromSQL2Order) OrElse String.IsNullOrEmpty(fromParam) Then
            Return retDatatable
        End If

        Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryNow As DataTable = Nothing
        Dim query1Other As DataTable = Adapter.SelectQuery(fromSQL1Other)
        Dim query2Order As DataTable = Adapter.SelectQuery(fromSQL2Order)

        For Each eachItem1 As String In New String() {"內銷", "國貿", "長約外銷", "合計"}
            AddItem = retDatatable.NewRow

            With AddItem
                .項目 = eachItem1
                If eachItem1 = "內銷" Then .備註 = fromParam.Split("|")(0) & "<BR>　　<BR>　　<BR>　　<BR>"

                For Each eachItem2 As String In New String() {"訂單量", "未交量", "落後量", "　　"}
                    queryNow = IIf(eachItem2 = "訂單量", query2Order, query1Other)

                    .類別 &= eachItem2 & "<BR>"
                    ._304 &= getQueryShowData(queryNow, eachItem1, eachItem2, "304") & "<BR>"
                    ._202 &= getQueryShowData(queryNow, eachItem1, eachItem2, "202") & "<BR>"
                    ._201 &= getQueryShowData(queryNow, eachItem1, eachItem2, "201") & "<BR>"
                    ._301 &= getQueryShowData(queryNow, eachItem1, eachItem2, "301") & "<BR>"
                    .其他 &= getQueryShowData(queryNow, eachItem1, eachItem2, "其他") & "<BR>"
                    .合計 &= getQueryShowData(queryNow, eachItem1, eachItem2, "合計") & "<BR>"
                Next

            End With

            retDatatable.Rows.Add(AddItem)
        Next

        Dim W_Now As Date = Now
        AddItem = retDatatable.NewRow
        AddItem.備註 &= fromParam.Split("|")(1) & "<BR>"
        AddItem.備註 &= "截止時間：" & Format(W_Now, "yyyy/MM/dd HH:mm") & "<BR>"
        AddItem.備註 &= "編製日期：" & Format(W_Now, "yyyy/MM/dd") & "<BR>"
        retDatatable.Rows.Add(AddItem)

        Return retDatatable
    End Function

    Private Shared Function getQueryShowData(ByRef fromQueryData As DataTable, ByVal from項目 As String, ByVal from類別 As String, ByVal from鋼種 As String) As String
        Dim SelectColumn As String = ""
        Dim retString As String = "　　"

        Select Case from類別
            Case "訂單量"
                SelectColumn = "sqtn12"
            Case "未交量"
                SelectColumn = "s00006"
            Case "落後量"
                SelectColumn = "s00007"
            Case Else
                SelectColumn = "Space"
                Return retString
        End Select


        Dim queryObj As Object = Nothing

        If from鋼種 = "合計" Then
            queryObj = (From A In fromQueryData _
                                                                  Where 1 = 1 _
                                                                  And IIf(from項目 = "合計", 2 = 2, A.Item("CUC91") = from項目) _
                                                                  And 2 = 2 _
                                                                  Select Single.Parse(A.Item(SelectColumn))).Sum

        ElseIf from鋼種 = "其他" Then
            queryObj = (From A In fromQueryData _
                                                      Where 1 = 1 _
                                                      And IIf(from項目 = "合計", 2 = 2, A.Item("CUC91") = from項目) _
                                                      And Not "304,202,201,301".Split(",").Contains(A.Item("QTN03")) _
                                                      Select Single.Parse(A.Item(SelectColumn))).Sum
        Else
            Dim queryTemp As List(Of Object)
            queryTemp = (From A In fromQueryData _
                                                                  Where 1 = 1 _
                                                                  And IIf(from項目 = "合計", 2 = 2, A.Item("CUC91") = from項目) _
                                                                  And A.Item("QTN03") = from鋼種 _
                                                                  Select A.Item(SelectColumn)).ToList

            If from項目 = "合計" Or from鋼種 = "合計" Then
                queryObj = (From A In queryTemp Select Single.Parse(A)).Sum
            Else
                queryObj = (From A In queryTemp Select A).FirstOrDefault
            End If
        End If

        If Not queryObj Is Nothing AndAlso IsNumeric(queryObj) = True Then
            retString = String.Format("{0:N0}", Integer.Parse(Single.Parse(CStr(queryObj))))
        End If

        If "其他,合計".Split(",").Contains(from鋼種) AndAlso retString = "0" Then retString = "　　"

        Return retString
    End Function

#End Region

#Region "GridView1排版：數字靠右"
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        '數字靠右對齊
        For II As Integer = 0 To GridView1.Columns.Count - 1
            Select Case GridView1.Columns(II).HeaderText
                Case "304", "202", "201", "301", "其他", "合計"
                    e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            End Select
        Next II
    End Sub
#End Region



End Class