Public Class ProductLoseStatistics
    Inherits System.Web.UI.UserControl

    Const CfromSelectKind1 As String = "fromSelectKind1"
    Const CfromSelectKind2 As String = "fromSelectKind2"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(DateAdd(DateInterval.Month, -1, Now), "yyyy/MM/01")
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
            Dim weight As Integer
            For II As Integer = 0 To 9
                Select Case II
                    Case DataTable_Emum.鋼種
                        weight = 70
                    Case DataTable_Emum.分隔1
                        weight = 30
                    Case Else
                        weight = 80
                End Select
                e.Row.Cells(II).Width = weight
            Next

            '數字靠右對齊
            For II As Integer = 2 To 9
                e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            Next II
        End If
    End Sub

    Protected Sub btnDownToExcel_Click(sender As Object, e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim queryDataTable As DataTable = Search(Me.hfSQL1All.Value, Me.hfSQL1One.Value, Me.hfSQL2.Value, Me.hfSearchDateOfMoney.Value)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "產出損失統計" & Me.hfSearchDateRange.Value & ".xls")
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

    Private Function MakeSQL1String(ByVal fromSelectAllData As Boolean, ByVal fromSQL4Of5DataAdjustment As String, _
                                                            ByVal fromStartDate As String, ByVal fromEndDate As String, _
                                                            ByVal fromStartMonth As String, ByVal fromEndMonth As String) As String
        Dim ReturnSQL1A As New StringBuilder
        Dim ReturnSQL1B As New StringBuilder

        Dim SelectColumnSQL1A As String = "SUM(ci711) ci71101 , SUM(ci712) ci71201 , SUM(lose) lose01 , SUM(lose1) lose101 "

        ReturnSQL1A.Append("		SELECT t01.ci700, t01.ci701, t01.CH205, t01.ci701A " & vbNewLine)
        ReturnSQL1A.Append("					   , t01.ci702, t01.ci703, t01.ci704, t01.ci705 " & vbNewLine)
        ReturnSQL1A.Append("					   , t01.ci706, t01.ci711, t01.ci712, t01.ci713 " & vbNewLine)
        ReturnSQL1A.Append("					   , t01.P , t01.wt, t01.wt1 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					   , CASE COALESCE(BOL1401,0) " & vbNewLine)
        ReturnSQL1A.Append("								 WHEN 0 THEN " & vbNewLine)
        ReturnSQL1A.Append("											 0 " & vbNewLine)
        ReturnSQL1A.Append("								  ELSE " & vbNewLine)
        ReturnSQL1A.Append("										 ROUND( DOUBLE(wt)/1000* (DOUBLE(bol2701) / DOUBLE(bol1401) - DOUBLE(pr211) ),0) " & vbNewLine)
        ReturnSQL1A.Append("						END  LOSE " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					   , CASE COALESCE(BOL1401,0) " & vbNewLine)
        ReturnSQL1A.Append("								 WHEN 0 THEN " & vbNewLine)
        ReturnSQL1A.Append("											 0 " & vbNewLine)
        ReturnSQL1A.Append("								  ELSE " & vbNewLine)
        ReturnSQL1A.Append("										ROUND( DOUBLE(wt1)/1000* (DOUBLE(bol2701) / DOUBLE(bol1401)),0) " & vbNewLine)
        ReturnSQL1A.Append("						END  LOSE1 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					   , t02.YM, t02.BOL05, t02.BOL06, t02.ciA34 " & vbNewLine)
        ReturnSQL1A.Append("					   , COALESCE(t02.bol1401,0) bol1401 " & vbNewLine)
        ReturnSQL1A.Append("					   , COALESCE(t02.bol2701,0) bol2701 " & vbNewLine)
        ReturnSQL1A.Append("					   , COALESCE(t02.cia2301,0) cia2301 " & vbNewLine)
        ReturnSQL1A.Append("					   , COALESCE(t02.bol2101,0) bol2101 " & vbNewLine)
        ReturnSQL1A.Append("					   , t03.PR001, t03.PR003, t03.PR004, t03.PR201, t03.PR211 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("				FROM ( " & vbNewLine)
        ReturnSQL1A.Append("						SELECT ci700, ci701, ch205,SUBSTR(ci701,1,1) ci701a " & vbNewLine)
        ReturnSQL1A.Append("									   ,ci702,ci703,ci704,ci705,ci706 " & vbNewLine)
        ReturnSQL1A.Append("									   ,ci711,ci712,ci713 " & vbNewLine)
        ReturnSQL1A.Append("									   ,DOUBLE(ROUND(ci711/ci712,2)) p " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("									   ,CASE  ch205 " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'HR' THEN  ROUND( ci712 * DOUBLE( DOUBLE(1-DOUBLE(ROUND(ci711/ci712,2)))-0.006),0) " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'CR' THEN  ROUND( ci712 * DOUBLE( DOUBLE(1-DOUBLE(ROUND(ci711/ci712,2)))-0.01),0) " & vbNewLine)
        ReturnSQL1A.Append("									   END wtAS400 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("									   ,CASE  ch205 " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'HR' THEN  ROUND( ci712 * DOUBLE( DOUBLE(1-DOUBLE(ROUND(ci711/ci712,2)))-0.006)  + " & fromSQL4Of5DataAdjustment & " ,0) " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'CR' THEN  ROUND( ci712 * DOUBLE( DOUBLE(1-DOUBLE(ROUND(ci711/ci712,2)))-0.01)  + " & fromSQL4Of5DataAdjustment & " ,0) " & vbNewLine)
        ReturnSQL1A.Append("									   END wt " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("									   ,CASE  ch205 " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'HR' THEN DOUBLE(ROUND((ci712 * 0.006),0)) " & vbNewLine)
        ReturnSQL1A.Append("											 WHEN 'CR' THEN DOUBLE(ROUND((ci712 * 0.01),0)) " & vbNewLine)
        ReturnSQL1A.Append("									   END wt1 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("						FROM @#PPS100LB.PPSci7PF t01 " & vbNewLine)
        ReturnSQL1A.Append("								 LEFT JOIN @#SLS300LB.SL2CH2PF t02 ON t02.ch201=t01.ci703 " & vbNewLine)
        ReturnSQL1A.Append("						WHERE 1=1 " & vbNewLine)
        ReturnSQL1A.Append("						   AND  ci700>='" & fromStartMonth & "' AND  ci700<='" & fromEndMonth & "' " & vbNewLine)
        ReturnSQL1A.Append("						   AND ch205 IN( 'HR', 'CR') " & vbNewLine)
        ReturnSQL1A.Append("						   AND ci703 NOT IN ( 'BHR', 'BHP' ) " & vbNewLine)
        ReturnSQL1A.Append(IIf(fromSelectAllData = False, "						   AND ci701=" & CfromSelectKind1 & " AND ci703 IN(" & CfromSelectKind2 & ") ", "") & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("				) t01 " & vbNewLine)
        ReturnSQL1A.Append("					LEFT JOIN ( " & vbNewLine)
        ReturnSQL1A.Append("						SELECT SUBSTR(bol01,1,5) ym,bol05,bol06,cia34 " & vbNewLine)
        ReturnSQL1A.Append("									   ,ROUND( sum(bol14) ,3) bol1401 " & vbNewLine)
        ReturnSQL1A.Append("									   ,sum(bol27) bol2701 " & vbNewLine)
        ReturnSQL1A.Append("									   ,sum(cia23) cia2301 , sum(bol21) bol2101 " & vbNewLine)
        ReturnSQL1A.Append("                     From ( " & vbNewLine)
        ReturnSQL1A.Append("                                    SELECT * " & vbNewLine)
        ReturnSQL1A.Append("                                    FROM (" & vbNewLine)
        ReturnSQL1A.Append("						                                SELECT * " & vbNewLine)
        ReturnSQL1A.Append("						                                FROM @#SLS300LB.SL2BOLPF t01 " & vbNewLine)
        ReturnSQL1A.Append("			                			                WHERE 1=1 " & vbNewLine)
        ReturnSQL1A.Append(IIf(fromSelectAllData = True, "			                			                      AND bol01 >='" & fromStartDate & "' ", "") & vbNewLine)
        ReturnSQL1A.Append("			                			                      AND bol01 <='" & fromEndDate & "' " & vbNewLine)

        If fromSelectAllData = False Then
            ReturnSQL1A.Append("							                                  AND bol05=" & CfromSelectKind1 & " AND bol06 IN(" & CfromSelectKind2 & ") " & vbNewLine)
            ReturnSQL1A.Append("			                			              ORDER BY bol01 desc,bol02 desc " & vbNewLine)
            ReturnSQL1A.Append("			                			              FETCH FIRST 1 ROWS ONLY " & vbNewLine)
        End If
        ReturnSQL1A.Append("                                        ) v " & vbNewLine)
        ReturnSQL1A.Append("								                LEFT JOIN @#PPS100LB.PPSciAPF t02 ON   cia62=bol02 AND cia02=bol16 AND cia03=bol17 " & vbNewLine)
        ReturnSQL1A.Append("								                LEFT JOIN @#SLS300LB.SL2CH2PF t03 ON ch201=bol06 " & vbNewLine)
        ReturnSQL1A.Append("                                     WHERE ch202 <>'Y' " & vbNewLine)
        ReturnSQL1A.Append("                     ) v " & vbNewLine)
        ReturnSQL1A.Append("						GROUP BY SUBSTR(bol01,1,5),bol05,bol06,cia34 " & vbNewLine)
        ReturnSQL1A.Append("						ORDER BY SUBSTR(bol01,1,5),bol05,bol06,cia34 " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					) t02 ON 1=1 " & vbNewLine)
        ReturnSQL1A.Append(IIf(fromSelectAllData = True, "					                     AND t02.YM = t01.ci700  ", "") & vbNewLine)

        '1021015 by renhsin,查詢單筆時忽略銷售別
        'ReturnSQL1A.Append("					                     AND t02.BOL05=t01.ci701 AND t02.BOL06=t01.ci703 AND t02.ciA34=t01.ci705 " & vbNewLine)
        ReturnSQL1A.Append("					                     AND t02.BOL05=t01.ci701 AND t02.BOL06=t01.ci703 ")
        If fromSelectAllData = True Then
            ReturnSQL1A.Append("					                 AND t02.ciA34=t01.ci705 " & vbNewLine)
        End If

        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					LEFT JOIN ( " & vbNewLine)
        ReturnSQL1A.Append("						SELECT pr001,pr003,pr004,pr201,pr211 " & vbNewLine)
        ReturnSQL1A.Append("						FROM @#SLS300LB.SL2PR2PF " & vbNewLine)
        ReturnSQL1A.Append("						WHERE 1=1 " & vbNewLine)
        ReturnSQL1A.Append("							 AND pr001 >='" & fromStartMonth & "' AND pr001<='" & fromEndMonth & "' " & vbNewLine)
        ReturnSQL1A.Append("							 AND pr201='99' AND pr002=' ' " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("						UNION " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("						SELECT pr001,4 pr003,pr004,pr201,DOUBLE( ROUND( pr211*0.375 ,2)) pr211 " & vbNewLine)
        ReturnSQL1A.Append("						FROM @#SLS300LB.SL2PR2PF " & vbNewLine)
        ReturnSQL1A.Append("						WHERE 1=1 " & vbNewLine)
        ReturnSQL1A.Append("							 AND pr001 >='" & fromStartMonth & "' AND pr001<='" & fromEndMonth & "' " & vbNewLine)
        ReturnSQL1A.Append("							 AND pr201='99' AND pr002=' ' AND pr003='2' " & vbNewLine)
        ReturnSQL1A.Append(" " & vbNewLine)
        ReturnSQL1A.Append("					) t03 ON t03.PR001=t01.ci700 AND t03.PR003=t01.ci701A " & vbNewLine)


        ReturnSQL1B.Append("SELECT ci701,ci703 " & vbNewLine)
        ReturnSQL1B.Append("          ,ROUND(DOUBLE(ci71101) /1000,0)  wt " & vbNewLine)
        ReturnSQL1B.Append("          ,ROUND(DOUBLE(ci71101) / DOUBLE(ci71201) * 100,3) p " & vbNewLine)
        ReturnSQL1B.Append("          ,ROUND( ROUND(DOUBLE(ci71101) / DOUBLE(ci71201) * 100,3) + " & fromSQL4Of5DataAdjustment & " ,2) pExcel " & vbNewLine)
        ReturnSQL1B.Append("          ,ROUND(DOUBLE(lose01),0) LOS " & vbNewLine)
        ReturnSQL1B.Append("FROM ( " & vbNewLine)
        ReturnSQL1B.Append("		SELECT ci701,ci703," & SelectColumnSQL1A & " " & vbNewLine)
        ReturnSQL1B.Append("		from ( " & vbNewLine)
        ReturnSQL1B.Append("		               " & ReturnSQL1A.ToString & vbNewLine)
        ReturnSQL1B.Append("		) vDetail " & vbNewLine)
        ReturnSQL1B.Append("		GROUP BY ci701,ci703 " & vbNewLine)
        ReturnSQL1B.Append("          " & vbNewLine)

        If fromSelectAllData = True Then
            ReturnSQL1B.Append("        UNION  " & vbNewLine)
            ReturnSQL1B.Append("          " & vbNewLine)
            ReturnSQL1B.Append("		SELECT ci701,'小計' ci703," & SelectColumnSQL1A & " " & vbNewLine)
            ReturnSQL1B.Append("		from ( " & vbNewLine)
            ReturnSQL1B.Append("		               " & ReturnSQL1A.ToString & vbNewLine)
            ReturnSQL1B.Append("		) vStatistic " & vbNewLine)
            ReturnSQL1B.Append("		GROUP BY ci701 " & vbNewLine)
            ReturnSQL1B.Append("          " & vbNewLine)
            ReturnSQL1B.Append("        UNION  " & vbNewLine)
            ReturnSQL1B.Append("          " & vbNewLine)
            ReturnSQL1B.Append("		SELECT '總計' ci701,' ' ci703," & SelectColumnSQL1A & " " & vbNewLine)
            ReturnSQL1B.Append("		from ( " & vbNewLine)
            ReturnSQL1B.Append("		               " & ReturnSQL1A.ToString & vbNewLine)
            ReturnSQL1B.Append("		) vTotal " & vbNewLine)
        End If

        ReturnSQL1B.Append(") v " & vbNewLine)

        Return ReturnSQL1B.ToString
    End Function

    Private Sub MakerSQLStringToControl()
        Dim StartDate As String = New CompanyORMDB.AS400DateConverter(Me.tbStartDate.Text).TwSixCharsTypeData
        Dim EndDate As String = New CompanyORMDB.AS400DateConverter(Me.tbEndDate.Text).TwSixCharsTypeData

        If Not ((StartDate.Length = 6 Or StartDate.Length = 7) And (EndDate.Length = 6 Or EndDate.Length = 7)) Then
            Me.hfSQL1All.Value = ""
            Me.hfSQL2.Value = ""
            Me.hfSearchDateRange.Value = ""
            Exit Sub
        End If

        Dim ReturnSQL2A As New StringBuilder
        Dim ReturnSQL2B As New StringBuilder

        Dim SelectColumnSQL2A As String = "SUM(ci713) ci71301,SUM(ci711) ci71101 "
        Dim SQL4Of5DataAdjustment As String = "0.0000001"
        'Note:在某些欄位上在四捨五入前要先加上一個不會影響結果值的數字(ex:0.0000001),否則在四捨五入情況下會有問題
        '如下列SQL範例：同一個數字在不同型態(數字/字串)做四捨五入會有誤差
        'SELECT ROUND(ValueNum,1) ValueNumN , ROUND(DOUBLE(ValueText),1) ValueNumT, ROUND(DOUBLE(ValueText) + 0.000001,1) ValueNumT2
        'FROM (
        '              SELECT 92.650 ValueNum , '92.650' ValueText 
        '              FROM @#sysibm.sysdummy1
        ') V

        Dim StartMonth As String = StartDate.Substring(0, StartDate.Length - 2)
        Dim EndMonth As String = EndDate.Substring(0, EndDate.Length - 2)


        ReturnSQL2A.Append("			SELECT ci700, ci701,SUBSTR(ci701,1,1) ci701a " & vbNewLine)
        ReturnSQL2A.Append("						   ,ci702,ci703,ci704,ci705,ci706 " & vbNewLine)
        ReturnSQL2A.Append("						   ,ci711,ci712,ci713 " & vbNewLine)
        ReturnSQL2A.Append("						   , ROUND( ci712 * DOUBLE( DOUBLE(1-DOUBLE(ROUND(ci711/ci712,2)))-0.006),0) wt " & vbNewLine)
        ReturnSQL2A.Append("			FROM @#PPS100LB.PPSci7PF t01 " & vbNewLine)
        ReturnSQL2A.Append("					 LEFT JOIN @#SLS300LB.SL2CH2PF t02 ON t02.ch201=t01.ci703 " & vbNewLine)
        ReturnSQL2A.Append("			WHERE 1=1 " & vbNewLine)
        ReturnSQL2A.Append("			   AND  ci700>='" & StartMonth & "' AND  ci700<='" & EndMonth & "' " & vbNewLine)
        ReturnSQL2A.Append("			   AND ci703 NOT IN ( 'BHR', 'BHP' ) " & vbNewLine)

        ReturnSQL2B.Append("SELECT ci701,ci703, ROUND( DOUBLE(ci71301) / DOUBLE(ci71101) * 100 ,2) p " & vbNewLine)
        ReturnSQL2B.Append("FROM ( " & vbNewLine)
        ReturnSQL2B.Append("		SELECT ci701,ci703," & SelectColumnSQL2A & " " & vbNewLine)
        ReturnSQL2B.Append("		FROM ( " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("                         " & ReturnSQL2A.ToString & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("		) vDetail " & vbNewLine)
        ReturnSQL2B.Append("		GROUP BY ci701,ci703 " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("        UNION  " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("		SELECT ci701,'小計' ci703," & SelectColumnSQL2A & " " & vbNewLine)
        ReturnSQL2B.Append("		FROM ( " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("                         " & ReturnSQL2A.ToString & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("		) vStatistic " & vbNewLine)
        ReturnSQL2B.Append("		GROUP BY ci701 " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("        UNION  " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("		SELECT '總計' ci701,' ' ci703," & SelectColumnSQL2A & " " & vbNewLine)
        ReturnSQL2B.Append("		FROM ( " & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("                         " & ReturnSQL2A.ToString & vbNewLine)
        ReturnSQL2B.Append("          " & vbNewLine)
        ReturnSQL2B.Append("		) vTotal " & vbNewLine)
        ReturnSQL2B.Append(") v " & vbNewLine)
        ReturnSQL2B.Append("ORDER BY ci701,ci703 " & vbNewLine)

        Me.hfSQL1All.Value = MakeSQL1String(True, SQL4Of5DataAdjustment, StartDate, EndDate, StartMonth, EndMonth)
        Me.hfSQL1One.Value = MakeSQL1String(False, SQL4Of5DataAdjustment, StartDate, EndDate, StartMonth, EndMonth)
        Me.hfSQL2.Value = ReturnSQL2B.ToString
        Me.hfSearchDateRange.Value = StartDate & "~" & EndDate

        Me.hfSearchDateOfMoney.Value = Left(StartDate, Len(StartDate) - 2)

    End Sub
#End Region

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromSQL1All"></param>
    ''' <param name="fromSQL1One"></param>
    ''' <param name="fromSQL2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL1All As String, ByVal fromSQL1One As String, ByVal fromSQL2 As String, ByVal fromDateOfMoney As String) As DataTable
        Dim ReturnDataTable As DataTable = ReturnDataTableNew()


        If String.IsNullOrEmpty(fromSQL1All) OrElse String.IsNullOrEmpty(fromSQL2) Then
            Return ReturnDataTable
        End If

        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim QueryList1All As List(Of clsDisplay) = (From A In Adapter.SelectQuery(fromSQL1All) Select New clsDisplay(A)).ToList
        Dim QueryList1AllDisplay As List(Of clsDisplay) = (From A In QueryList1All Where Not (A.鋼種 = "總計" Or A.表面 = "小計") Select A).ToList
        Dim QueryList2 As List(Of cls一級品率) = (From A In Adapter.SelectQuery(fromSQL2) Select New cls一級品率(A)).ToList

        Dim TypeKind As String = ""
        Dim Surface As String = "小計"
        Dim OtherLosOne As Long = 0
        Dim OtherLosAll As Long = 0

        For Each EachItemClsDisplay As clsDisplay In QueryList1AllDisplay
            If TypeKind = "" Then TypeKind = EachItemClsDisplay.鋼種
            If TypeKind <> EachItemClsDisplay.鋼種 Then
                '小計
                OtherLosAll += OtherLosOne
                ReturnDataTableAddStatistic(ReturnDataTable, TypeKind, Surface, QueryList1All, QueryList2, OtherLosOne)

                TypeKind = EachItemClsDisplay.鋼種
                OtherLosOne = 0
            End If

            EachItemClsDisplay.一級品率 = (From A In QueryList2 Where A.鋼種 = EachItemClsDisplay.鋼種 And A.表面 = EachItemClsDisplay.表面 Select A.一級品率).FirstOrDefault

            If EachItemClsDisplay.產出損失 = "0" Then
                '抓之前最後一筆的提貨單檔,各鋼種的TR對應到SH
                Dim SQL1OneString As String = fromSQL1One.Replace(CfromSelectKind1, "'" & EachItemClsDisplay.鋼種 & "'") _
                                                                                .Replace(CfromSelectKind2, "'" & IIf(EachItemClsDisplay.表面.Trim = "TR", "TR','SH", EachItemClsDisplay.表面) & "'")
                Dim QueryList1One As List(Of clsDisplay) = (From A In Adapter.SelectQuery(SQL1OneString) Select New clsDisplay(A)).ToList

                Dim OtherLosClsDisplay As clsDisplay = (From A In QueryList1One Where A.產出損失 <> "0" Select A).FirstOrDefault
                If Not OtherLosClsDisplay Is Nothing Then
                    EachItemClsDisplay.產出損失 = OtherLosClsDisplay.產出損失
                    OtherLosOne += Long.Parse(EachItemClsDisplay.產出損失)
                End If
            End If

            ReturnDataTableAddRow(ReturnDataTable, EachItemClsDisplay)
        Next

        '小計-最後一筆資料
        ReturnDataTableAddStatistic(ReturnDataTable, TypeKind, Surface, QueryList1All, QueryList2)

        '總計
        TypeKind = "總計"
        Surface = " "
        ReturnDataTableAddStatistic(ReturnDataTable, TypeKind, Surface, QueryList1All, QueryList2, OtherLosAll)


        '1021118 by renhsin：牌價/廢料價
        ReturnDataTableAddMoney(ReturnDataTable, fromDateOfMoney)

        Return ReturnDataTable
    End Function

    Enum DataTable_Emum
        鋼種 = 0
        表面 = 1
        繳庫量 = 2
        產出率 = 3
        產出損失 = 4
        一級品率 = 5
        分隔1 = 6
        牌價 = 7
        廢料價 = 8
        產出損失2 = 9
    End Enum

    Private Function getDataDableName(ByVal fromDataTable_Enum As DataTable_Emum) As String
        Select Case fromDataTable_Enum
            Case DataTable_Emum.鋼種
                Return "鋼種"
            Case DataTable_Emum.表面
                Return "表面"
            Case DataTable_Emum.繳庫量
                Return "繳庫量"
            Case DataTable_Emum.產出率
                Return "產出率"
            Case DataTable_Emum.產出損失
                Return "產出損失"
            Case DataTable_Emum.一級品率
                Return "一級品率"
            Case DataTable_Emum.牌價
                Return "牌價"
            Case DataTable_Emum.廢料價
                Return "廢料價"
            Case DataTable_Emum.分隔1
                Return "　"
            Case DataTable_Emum.產出損失2
                Return "產出損失2"
            Case Else
                Return "XX"
        End Select
    End Function

    Private Function ReturnDataTableNew() As DataTable
        Dim ReturnDataTable As New DataTable

        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.鋼種))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.表面))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.繳庫量))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.產出率))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.產出損失))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.一級品率))

        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.分隔1))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.牌價))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.廢料價))
        ReturnDataTable.Columns.Add(getDataDableName(DataTable_Emum.產出損失2))

        Return ReturnDataTable
    End Function

    Private Sub ReturnDataTableAddRow(ByRef fromDataTable As DataTable, ByVal fromClsDisplay As clsDisplay)
        Dim AddRow As DataRow = fromDataTable.NewRow

        SetClsDisplayFormat(fromClsDisplay)

        AddRow.Item(getDataDableName(DataTable_Emum.鋼種)) = fromClsDisplay.鋼種
        AddRow.Item(getDataDableName(DataTable_Emum.表面)) = fromClsDisplay.表面
        AddRow.Item(getDataDableName(DataTable_Emum.產出率)) = fromClsDisplay.產出率
        AddRow.Item(getDataDableName(DataTable_Emum.一級品率)) = fromClsDisplay.一級品率
        AddRow.Item(getDataDableName(DataTable_Emum.繳庫量)) = fromClsDisplay.繳庫量
        AddRow.Item(getDataDableName(DataTable_Emum.產出損失)) = fromClsDisplay.產出損失

        fromDataTable.Rows.Add(AddRow)
    End Sub

    Private Sub SetClsDisplayFormat(ByRef fromClsDisplay As clsDisplay)
        Dim TempValue As String

        '百分比 小數補足兩碼
        If Not (String.IsNullOrEmpty(fromClsDisplay.產出率) Or fromClsDisplay.產出率 Is Nothing) Then
            TempValue = String.Format("{0:0.00}", Double.Parse(fromClsDisplay.產出率))
            fromClsDisplay.產出率 = TempValue & Space(1)
        End If
        If Not (String.IsNullOrEmpty(fromClsDisplay.一級品率) Or fromClsDisplay.一級品率 Is Nothing) Then
            TempValue = String.Format("{0:0.00}", Double.Parse(fromClsDisplay.一級品率))
            fromClsDisplay.一級品率 = TempValue & Space(1)
        End If

        '數字3位補上一個逗號
        If Not (String.IsNullOrEmpty(fromClsDisplay.繳庫量) Or fromClsDisplay.繳庫量 Is Nothing) Then
            TempValue = String.Format("{0:N0}", Long.Parse(fromClsDisplay.繳庫量))
            fromClsDisplay.繳庫量 = TempValue
        End If
        If Not (String.IsNullOrEmpty(fromClsDisplay.產出損失) Or fromClsDisplay.產出損失 Is Nothing) Then
            TempValue = String.Format("{0:N0}", Long.Parse(fromClsDisplay.產出損失))
            fromClsDisplay.產出損失 = TempValue
        End If
    End Sub

    Private Sub ReturnDataTableAddStatistic(ByRef fromDataTable As DataTable, _
                                        ByVal fromTypeKind As String, ByVal fromSurface As String, _
                                        ByVal fromQueryList1 As List(Of clsDisplay), ByVal fromQueryList2 As List(Of cls一級品率))

        ReturnDataTableAddStatistic(fromDataTable, fromTypeKind, fromSurface, fromQueryList1, fromQueryList2, 0)
    End Sub

    Private Sub ReturnDataTableAddStatistic(ByRef fromDataTable As DataTable, _
                                            ByVal fromTypeKind As String, ByVal fromSurface As String, _
                                            ByVal fromQueryList1 As List(Of clsDisplay), ByVal fromQueryList2 As List(Of cls一級品率), fromOtherLos As Long)
        Dim StatisticClsDisplay As New clsDisplay

        StatisticClsDisplay.鋼種 = fromTypeKind
        StatisticClsDisplay.表面 = fromSurface

        Dim QueryList1ClsDisplay As clsDisplay = (From A In fromQueryList1 Where A.鋼種 = StatisticClsDisplay.鋼種 And A.表面 = StatisticClsDisplay.表面 Select A).FirstOrDefault
        If Not QueryList1ClsDisplay Is Nothing Then
            StatisticClsDisplay.繳庫量 = QueryList1ClsDisplay.繳庫量
            StatisticClsDisplay.產出率 = QueryList1ClsDisplay.產出率

            Dim TempValue As Long = Long.Parse(QueryList1ClsDisplay.產出損失) + fromOtherLos
            StatisticClsDisplay.產出損失 = TempValue.ToString
        End If

        Dim QueryList2ClsDisplay As cls一級品率 = (From A In fromQueryList2 Where A.鋼種 = StatisticClsDisplay.鋼種 And A.表面 = StatisticClsDisplay.表面 Select A).FirstOrDefault
        If Not QueryList2ClsDisplay Is Nothing Then StatisticClsDisplay.一級品率 = QueryList2ClsDisplay.一級品率

        ReturnDataTableAddRow(fromDataTable, StatisticClsDisplay)
    End Sub


    Private Sub ReturnDataTableAddMoney(ByRef fromDataTable As DataTable, ByVal fromDateOfMoney As String)
        Dim QuerySQLCrHr As String = "SELECT * FROM @#SLS300LB.SL2CH2PF"
        Dim QuerySQL0 As String = "SELECT * FROM @#SLS300LB.SL2PR0PF v0 WHERE pr001='" & fromDateOfMoney & "' "
        Dim QuerySQL1 As String = "SELECT * FROM @#SLS300LB.SL2PR1PF v1 WHERE pr001='" & fromDateOfMoney & "' ORDER BY pr101,pr102  "
        Dim QuerySQL2 As String = "SELECT * FROM @#SLS300LB.SL2PR2PF v2 WHERE pr001='" & fromDateOfMoney & "' "

        Dim QueryListCrHr As List(Of SLS300LB.SL2CH2PF) = SLS300LB.SL2CH2PF.CDBSelect(Of SLS300LB.SL2CH2PF)(QuerySQLCrHr, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim QueryList0 As List(Of SLS300LB.SL2PR0PF) = SLS300LB.SL2PR0PF.CDBSelect(Of SLS300LB.SL2PR0PF)(QuerySQL0, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).ToList
        Dim QueryList1 As List(Of SLS300LB.SL2PR1PF) = SLS300LB.SL2PR1PF.CDBSelect(Of SLS300LB.SL2PR1PF)(QuerySQL1, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).ToList
        Dim QueryList2 As List(Of SLS300LB.SL2PR2PF) = SLS300LB.SL2PR2PF.CDBSelect(Of SLS300LB.SL2PR2PF)(QuerySQL2, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).ToList

        Dim IsCrHr As String
        Dim Price0 As Integer, Price1 As Integer, Price2A As Integer, Price2B As Integer
        Dim WeightAll As Double, WeightOK As Double, WeightLoss As Double
        For Each eachItemRow As DataRow In fromDataTable.Rows
            If eachItemRow.Item(getDataDableName(DataTable_Emum.鋼種)) = "總計" OrElse eachItemRow.Item(getDataDableName(DataTable_Emum.表面)) = "小計" Then Continue For

            IsCrHr = (From A In QueryListCrHr Where A.CH201.Trim = eachItemRow.Item(getDataDableName(DataTable_Emum.表面)).ToString.Trim Select A.CH205.Trim).FirstOrDefault
            Price0 = (From A In QueryList0 Where A.PR004.Trim = IsCrHr And A.PR003 = Left(eachItemRow.Item(getDataDableName(DataTable_Emum.鋼種)), 1) Select A.PR011).FirstOrDefault
            Price1 = (From B In QueryList1 Where B.PR004.Trim = IsCrHr And B.PR101 = eachItemRow.Item(getDataDableName(DataTable_Emum.鋼種)) Select (B.PR111 + B.PR112)).FirstOrDefault
            Price2A = (From C In QueryList2 Where C.PR003.Trim = Left(eachItemRow.Item(getDataDableName(DataTable_Emum.鋼種)), 1) And C.PR201.Trim = eachItemRow.Item(getDataDableName(DataTable_Emum.表面)).ToString.Trim Select C.PR211).FirstOrDefault
            '廢料價:表面=99 
            Price2B = (From C In QueryList2 Where C.PR003.Trim = Left(eachItemRow.Item(getDataDableName(DataTable_Emum.鋼種)), 1) And C.PR201.Trim = "99" Select C.PR211).FirstOrDefault

            WeightOK = Decimal.Parse(eachItemRow.Item(getDataDableName(DataTable_Emum.繳庫量)), System.Globalization.NumberStyles.Number)
            WeightAll = WeightOK / (Double.Parse(eachItemRow.Item(getDataDableName(DataTable_Emum.產出率)) / 100))
            WeightLoss = (WeightAll - WeightOK)
            eachItemRow.Item(getDataDableName(DataTable_Emum.牌價)) = String.Format("{0:N0}", (Price0 + Price1 + Price2A))
            eachItemRow.Item(getDataDableName(DataTable_Emum.廢料價)) = String.Format("{0:N0}", Price2B)
            eachItemRow.Item(getDataDableName(DataTable_Emum.產出損失2)) = String.Format("{0:N0}", (WeightAll * Price2B))
        Next


    End Sub

#End Region

#Region "相關Class"

    Class clsDisplay
        Private _鋼種 As String
        Private _表面 As String
        Private _繳庫量 As String
        Private _產出率 As String
        Private _產出損失 As String
        Private _一級品率 As String

        Sub New()

        End Sub
        Sub New(ByVal fromDataRow As DataRow)
            鋼種 = fromDataRow.Item("ci701")
            表面 = fromDataRow.Item("ci703")
            繳庫量 = fromDataRow.Item("wt")
            產出率 = fromDataRow.Item("pExcel")
            產出損失 = fromDataRow.Item("los")
        End Sub

        Public Property 鋼種 As String
            Get
                Return _鋼種
            End Get
            Set(value As String)
                _鋼種 = value
            End Set
        End Property
        Public Property 表面 As String
            Get
                Return _表面
            End Get
            Set(value As String)
                _表面 = value
            End Set
        End Property
        Public Property 繳庫量 As String
            Get
                Return _繳庫量
            End Get
            Set(value As String)
                _繳庫量 = value
            End Set
        End Property
        Public Property 產出率 As String
            Get
                Return _產出率
            End Get
            Set(value As String)
                _產出率 = value
            End Set
        End Property
        Public Property 產出損失 As String
            Get
                Return _產出損失
            End Get
            Set(value As String)
                _產出損失 = value
            End Set
        End Property
        Public Property 一級品率 As String
            Get
                Return _一級品率
            End Get
            Set(value As String)
                _一級品率 = value
            End Set
        End Property

    End Class

    Class cls一級品率
        Private _鋼種 As String
        Private _表面 As String
        Private _一級品率 As String

        Sub New(ByVal fromDataRow As DataRow)
            鋼種 = fromDataRow.Item("ci701")
            表面 = fromDataRow.Item("ci703")
            一級品率 = fromDataRow.Item("p")
        End Sub

        Public Property 鋼種 As String
            Get
                Return _鋼種
            End Get
            Set(value As String)
                _鋼種 = value
            End Set
        End Property
        Public Property 表面 As String
            Get
                Return _表面
            End Get
            Set(value As String)
                _表面 = value
            End Set
        End Property
        Public Property 一級品率 As String
            Get
                Return _一級品率
            End Get
            Set(value As String)
                _一級品率 = value
            End Set
        End Property
    End Class
#End Region

End Class


