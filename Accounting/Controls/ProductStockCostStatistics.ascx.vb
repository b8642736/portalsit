Public Class ProductStockCostStatistics
    Inherits System.Web.UI.UserControl

    Private C_DateVer_Ver1 As String = "Ver1"
    Private C_DateVer_Ver2a As String = "Ver2a"
    Private C_DateVer_Ver2b As String = "Ver2b"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbEndDate.Text = Format(DateAdd(DateInterval.Day, -1, CDate(Format(Now, "yyyy/MM/01"))), "yyyy/MM/dd")
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

        Dim queryDataTable As DataTable = Search(Me.hfSQL.Value, Me.hfDateVer.Value)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "製成品淨變現價值統計_" & Me.hfDateVer.Value & "_" & Me.hfSearchEndDate.Value & ".xls")
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
    Private Function MakeSQL1String(ByVal fromType As Integer, ByVal fromEndDate As String) As String
        Dim ReturnSQL1 As New StringBuilder
        Dim SQL4Of5DataAdjustment As String = "0.0000001"
        'Note:在某些欄位上在四捨五入前要先加上一個不會影響結果值的數字(ex:0.0000001),否則在四捨五入情況下會有問題

        ReturnSQL1.Append("		SELECT '" & fromType.ToString & "' BREAKLVL,YM,CH205,CIA05 " & vbNewLine)
        ReturnSQL1.Append("			  ,CIA36,CIA34,CIA06,CHAR(CIA1301) CIA1301 " & vbNewLine)
        ReturnSQL1.Append("			  ,CHAR(DEC(ROUND(cost01/cia1301*1000 + " & SQL4Of5DataAdjustment & ",0))) COST " & vbNewLine)
        ReturnSQL1.Append("			  ,CHAR(DEC(ROUND(costa01/cia1301*1000 + " & SQL4Of5DataAdjustment & ",0))) COSTA " & vbNewLine)
        ReturnSQL1.Append("		FROM ( " & vbNewLine)
        If fromType = 0 Then
            ReturnSQL1.Append("				SELECT ''ym,''ch205,''cia05,''cia36,''cia34,''cia06 " & vbNewLine)
        ElseIf fromType = 3 Then
            ReturnSQL1.Append("				SELECT ym,ch205,cia05,cia36,''cia34,''cia06 " & vbNewLine)
        End If
        ReturnSQL1.Append("					  ,SUM(cia13) cia1301,SUM(cost) cost01,SUM(costa) costa01 " & vbNewLine)
        ReturnSQL1.Append("				FROM ( " & vbNewLine)
        ReturnSQL1.Append("						SELECT substr(digits(cia58),1,5) ym,t01.ch205,t01.cia05,t01.cia36,t01.cia34,t01.cia06 " & vbNewLine)
        ReturnSQL1.Append("							  ,t01.cia33,t01.cia07,t01.thk " & vbNewLine)
        ReturnSQL1.Append("							  ,t01.cia02,t01.cia03,t01.cia13 " & vbNewLine)
        ReturnSQL1.Append("							  ,ROUND(skb09/skb08*cia13/1000 + " & SQL4Of5DataAdjustment & ",3) cost " & vbNewLine)
        ReturnSQL1.Append("							  ,ROUND(skb25/skb08*cia13/1000 + " & SQL4Of5DataAdjustment & ",3) costa " & vbNewLine)
        ReturnSQL1.Append("							  ,t02.skb08,t02.skb09,t02.skb25,t02.skb11 " & vbNewLine)
        ReturnSQL1.Append("						FROM ( " & vbNewLine)
        ReturnSQL1.Append("								SELECT  " & vbNewLine)
        ReturnSQL1.Append("									t01.cia04,t03.ch205,t01.cia05,t01.cia36,t01.cia06  " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia34,t01.cia33,t01.cia07,t01.cia08,t01.cia10  " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia02,t01.cia03,t01.cia16,t01.cia13,t01.cia58 " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia59 " & vbNewLine)
        ReturnSQL1.Append("									,SUBSTR(cia59,1,2) || '.' ||   SUBSTR(cia59,3,2) thk       " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia45,t01.cia46,t01.cia47,t01.cia48 " & vbNewLine)
        ReturnSQL1.Append("								FROM @#pps100lb.ppscialj t01 " & vbNewLine)
        ReturnSQL1.Append("								  LEFT JOIN sls300lb.sl2ch2pf t03 ON ch201=cia06 " & vbNewLine)
        ReturnSQL1.Append("								WHERE 1=1 " & vbNewLine)
        ReturnSQL1.Append("								  AND cia58>= 1 AND cia58<=" & fromEndDate & "  " & vbNewLine)
        ReturnSQL1.Append("								  AND ch202<> 'Y'  " & vbNewLine)
        ReturnSQL1.Append("								   " & vbNewLine)
        ReturnSQL1.Append("								UNION " & vbNewLine)
        ReturnSQL1.Append(" " & vbNewLine)
        ReturnSQL1.Append("								SELECT  " & vbNewLine)
        ReturnSQL1.Append("									t01.cia04,t03.ch205,t01.cia05,t01.cia36,t01.cia06  " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia34,t01.cia33,t01.cia07,t01.cia08,t01.cia10  " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia02,t01.cia03,t01.cia16,t01.cia13,t01.cia58 " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia59 " & vbNewLine)
        ReturnSQL1.Append("									,SUBSTR(cia59,1,2) || '.' ||   SUBSTR(cia59,3,2) thk       " & vbNewLine)
        ReturnSQL1.Append("									,t01.cia45,t01.cia46,t01.cia47,t01.cia48 " & vbNewLine)
        ReturnSQL1.Append("								FROM @#pps100lb.ppsciapf t01 " & vbNewLine)
        ReturnSQL1.Append("								  LEFT JOIN sls300lb.sl2ch2pf t03 ON ch201=cia06 " & vbNewLine)
        ReturnSQL1.Append("								WHERE 1=1 " & vbNewLine)
        ReturnSQL1.Append("								  AND cia58>= 1 AND cia58<=" & fromEndDate & "  " & vbNewLine)
        ReturnSQL1.Append("								  AND ch202<> 'Y'  " & vbNewLine)
        ReturnSQL1.Append("								  AND cia63>" & fromEndDate & "   " & vbNewLine)
        ReturnSQL1.Append("						) t01   " & vbNewLine)
        ReturnSQL1.Append("							 LEFT JOIN @#ACS300LB.ACSSKBPF.SUM t02 ON skb01=cia05 AND skb02=ch205 AND skb04=thk AND skb05=cia06 AND skb13=cia34 AND skb12=cia33 " & vbNewLine)
        ReturnSQL1.Append("						WHERE 1=1 " & vbNewLine)
        ReturnSQL1.Append("						  AND skb00='00'  " & vbNewLine)
        ReturnSQL1.Append("				) V     " & vbNewLine)

        If fromType = 0 Then
            ReturnSQL1.Append("				GROUP BY 0 " & vbNewLine)
        ElseIf fromType = 3 Then
            ReturnSQL1.Append("				GROUP BY ym,ch205,cia05,cia36 " & vbNewLine)
        End If
        ReturnSQL1.Append("		) V " & vbNewLine)

        Return ReturnSQL1.ToString
    End Function

    Private Function MakeSQL2String(ByVal fromType As Integer, ByVal fromEEEMM As String, ByVal fromDateType As String) As String
        Dim ReturnSQL2 As New StringBuilder
        Dim W_Column_Date As String = "skh0" & fromDateType

        ReturnSQL2.Append("		SELECT '" & fromType.ToString & "' BREAKLVL " & vbNewLine)
        If fromType = 0 Then
            'ReturnSQL2.Append("				,'' skh0a, '' skh10, '' skh01, '' skh01a, '' skh04, '' skh02  " & vbNewLine)
            ReturnSQL2.Append("				, '' " & W_Column_Date & " , '' skh10, '' skh01, '' skh01a, '' skh04, '' skh02  " & vbNewLine)
        ElseIf fromType = 3 Then
            'ReturnSQL2.Append("				,skh0a, skh10, skh01, skh01a, '' skh04, '' skh02  " & vbNewLine)
            ReturnSQL2.Append("				," & W_Column_Date & " , skh10, skh01, skh01a, '' skh04, '' skh02  " & vbNewLine)
        End If
        ReturnSQL2.Append("					 ,SUM(skh11) skh11S, SUM(skh21) skh21S, SUM(skh22) skh22S " & vbNewLine)
        ReturnSQL2.Append("				FROM @#ACS300LB.ACSSKHPF " & vbNewLine)
        ReturnSQL2.Append("				WHERE 1=1" & vbNewLine)
        ReturnSQL2.Append("				     AND skh00='" & fromEEEMM & "' " & vbNewLine)


        If fromType = 0 Then
            ReturnSQL2.Append("				GROUP BY 0 " & vbNewLine)
        ElseIf fromType = 3 Then
            'ReturnSQL2.Append("				GROUP BY skh0a, skh10, skh01, skh01a " & vbNewLine)
            ReturnSQL2.Append("				GROUP BY " & W_Column_Date & ", skh10, skh01, skh01a " & vbNewLine)
        End If


        Return ReturnSQL2.ToString
    End Function

    Private Sub MakerSQLStringToControl()
        Dim EndDate As String = New CompanyORMDB.AS400DateConverter(Me.tbEndDate.Text).TwSixCharsTypeData

        If Not ((EndDate.Length = 6 Or EndDate.Length = 7)) Then
            Me.hfSQL.Value = ""
            Me.hfSQL.Value = ""
            Me.hfDateVer.Value = ""
            Exit Sub
        End If

        Dim EEEMM As String = EndDate.Substring(0, (EndDate.Length - 2))

        Dim ReturnSQL As New StringBuilder


        Select Case Me.ddDateVer.SelectedValue
            Case C_DateVer_Ver1
                Me.hfSearchEndDate.Value = EndDate

                ReturnSQL.Append("SELECT * " & vbNewLine)
                ReturnSQL.Append("FROM ( " & vbNewLine)
                ReturnSQL.Append(MakeSQL1String(3, EndDate) & " " & vbNewLine)
                ReturnSQL.Append("		UNION " & vbNewLine)
                ReturnSQL.Append(MakeSQL1String(0, EndDate) & " " & vbNewLine)
                ReturnSQL.Append(") V " & vbNewLine)
                ReturnSQL.Append("ORDER BY BREAKLVL desc,YM,CH205,CIA05,CIA36 " & vbNewLine)

            Case C_DateVer_Ver2a, C_DateVer_Ver2b
                Me.hfSearchEndDate.Value = EEEMM
                Dim W_Date_Type As String = IIf(Me.ddDateVer.SelectedValue = C_DateVer_Ver2a, "a", "b")

                ReturnSQL.Append("SELECT * " & vbNewLine)
                ReturnSQL.Append("FROM ( " & vbNewLine)
                ReturnSQL.Append(MakeSQL2String(3, EEEMM, W_Date_Type) & " " & vbNewLine)
                ReturnSQL.Append("		UNION " & vbNewLine)
                ReturnSQL.Append(MakeSQL2String(0, EEEMM, W_Date_Type) & " " & vbNewLine)
                ReturnSQL.Append(") V " & vbNewLine)
                ReturnSQL.Append("ORDER BY BREAKLVL desc,skh0" & W_Date_Type & ", skh10, skh01, skh01a " & vbNewLine)
        End Select

        Me.hfSQL.Value = ReturnSQL.ToString

        Me.hfDateVer.Value = Me.ddDateVer.SelectedValue

    End Sub
#End Region

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <param name="fromDateVer" ></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String, ByVal fromDateVer As String) As DataTable
        Dim ReturnDataTable As New DataTable

        If String.IsNullOrEmpty(fromSQL) Then
            Return ReturnDataTable
        End If

        Dim DateVerColumn As String = ""
        Dim ColumnList() As String = IIf(fromDateVer = C_DateVer_Ver1 _
                                           , New String() {"CIA1301", "COST", "COSTA"} _
                                          , New String() {"skh11S", "skh21S", "skh22S"})

        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        ReturnDataTable = Adapter.SelectQuery(fromSQL)


        For Each eachItemRow As DataRow In ReturnDataTable.Rows
            '3個數字加上1個逗號
            'eachItemRow.Item("CIA1301") = String.Format("{0:N0}", Integer.Parse(eachItemRow.Item("CIA1301")))
            'eachItemRow.Item("COST") = String.Format("{0:N0}", Integer.Parse(eachItemRow.Item("COST")))
            'eachItemRow.Item("COSTA") = String.Format("{0:N0}", Integer.Parse(eachItemRow.Item("COSTA")))

            For Each eachItemColumn As String In ColumnList

                If fromDateVer = C_DateVer_Ver1 Then
                    eachItemRow.Item(eachItemColumn) = String.Format("{0:N0}", Integer.Parse(eachItemRow.Item(eachItemColumn)))
                Else
                    eachItemRow.Item(eachItemColumn) = String.Format("{0:0,0.###}", Double.Parse(eachItemRow.Item(eachItemColumn)))
                End If
            Next
         
        Next

        'ReturnDataTable.Columns.Remove("BREAKLVL")

        'ReturnDataTable.Columns("YM").ColumnName = "年月"
        'ReturnDataTable.Columns("CH205").ColumnName = "CR / HR"
        'ReturnDataTable.Columns("CIA05").ColumnName = "鋼種"
        'ReturnDataTable.Columns("CIA36").ColumnName = "TYPE"
        'ReturnDataTable.Columns("CIA34").ColumnName = "外銷"
        'ReturnDataTable.Columns("CIA06").ColumnName = "表面"
        'ReturnDataTable.Columns("CIA1301").ColumnName = "重量"
        'ReturnDataTable.Columns("COST").ColumnName = "單位總成本"
        'ReturnDataTable.Columns("COSTA").ColumnName = "單位原料成本"


        'DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "YM", "skh0a")
        Select Case fromDateVer
            Case C_DateVer_Ver1
                DateVerColumn = "YM"
            Case C_DateVer_Ver2a
                DateVerColumn = "skh0a"
            Case C_DateVer_Ver2b
                DateVerColumn = "skh0b"
        End Select
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "年月"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CH205", "skh10")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "CR / HR"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CIA05", "skh01")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "鋼種"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CIA36", "skh01a")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "TYPE"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CIA34", "skh04")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "外銷"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CIA06", "skh02")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "表面"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "CIA1301", "skh11S")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = "重量"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "COST", "skh21S")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = IIf(fromDateVer = C_DateVer_Ver1, "單位", "") & "成本"  '"單位總成本"

        DateVerColumn = IIf(fromDateVer = C_DateVer_Ver1, "COSTA", "skh22S")
        ReturnDataTable.Columns(DateVerColumn).ColumnName = IIf(fromDateVer = C_DateVer_Ver1, "單位", "") & "原料成本"

        Return ReturnDataTable
    End Function

#End Region
End Class