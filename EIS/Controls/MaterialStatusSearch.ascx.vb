Public Class MaterialStatusSearch
    Inherits System.Web.UI.UserControl

    Private Shared adapterObj As New CompanyORMDB.AS400SQLQueryAdapter
    Private Shared class成品當量Obj As New class成品當量

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call InitFrom()
        End If
    End Sub

    Private Sub InitFrom()
        Dim W_Now As Date = DateAdd(DateInterval.Day, -1, Now)

        tb黑皮進場截止日.Text = Format(W_Now, "yyyy/MM/dd")
        tb在製品截止日.Text = Format(W_Now, "yyyy/MM/dd")
        tb鋼胚生產截止日.Text = Format(W_Now, "yyyy/MM/dd")


        Dim show承訂落後量StartMonth As String = "", show承訂落後量EndMonth As String = ""
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT SUBSTR(pam11b,1,4) || '/' || SUBSTR(pam11b,5,2) pam11 " & vbNewLine)
        querySQL.Append("              ,SUBSTR(pam12b,1,4) || '/' || SUBSTR(pam12b,5,2) pam12 " & vbNewLine)
        querySQL.Append("FROM( " & vbNewLine)
        querySQL.Append("SELECT v1.* " & vbNewLine)
        querySQL.Append("               ,CASE LENGTH(TRIM(PAM11)) " & vbNewLine)
        querySQL.Append("                           WHEN 6 THEN substr(pam11,1,4)+191100 " & vbNewLine)
        querySQL.Append("                           WHEN 7 THEN substr(pam11,1,5)+191100 " & vbNewLine)
        querySQL.Append("                           ELSE 'xxxxoo' " & vbNewLine)
        querySQL.Append("                END PAM11B " & vbNewLine)
        querySQL.Append(" " & vbNewLine)
        querySQL.Append("               ,CASE LENGTH(TRIM(PAM12)) " & vbNewLine)
        querySQL.Append("                           WHEN 6 THEN substr(pam12,1,4)+191100 " & vbNewLine)
        querySQL.Append("                           WHEN 7 THEN substr(pam12,1,5)+191100 " & vbNewLine)
        querySQL.Append("                           ELSE 'xxxxoo' " & vbNewLine)
        querySQL.Append("                END PAM12B " & vbNewLine)
        querySQL.Append(" " & vbNewLine)
        querySQL.Append("FROM @#SLS300LB.SL2PAMPF v1 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("   and PAM01='H3' " & vbNewLine)
        querySQL.Append("   and pam02 <=" & (Format(Now, "yyyyMM") - 191100) & vbNewLine)
        querySQL.Append("ORDER BY pam02 DESC " & vbNewLine)
        querySQL.Append("FETCH FIRST 1 ROWS ONLY " & vbNewLine)
        querySQL.Append(") V2 " & vbNewLine)
        Dim queryDataTable As DataTable = New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(querySQL.ToString)
        If Not IsNothing(queryDataTable) Then
            show承訂落後量StartMonth = queryDataTable.Rows(0).Item("pam11")
            show承訂落後量EndMonth = queryDataTable.Rows(0).Item("pam12")
        Else
            show承訂落後量StartMonth = Format(DateAdd(DateInterval.Month, -6, W_Now), "yyyy/MM")
            show承訂落後量EndMonth = Format(DateAdd(DateInterval.Month, -1, W_Now), "yyyy/MM")
        End If

        tb承訂落後量StartMonth.Text = show承訂落後量StartMonth
        tb承訂落後量EndMonth.Text = show承訂落後量EndMonth
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call InitFrom()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQuerySQL()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQuerySQL()

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim QueryDataTable As DataTable = Search(hfParam.Value, hfSQL00_LOT對照檔.Value, hfSQL01_成品繳庫.Value, _
                                                                                                 hfSQL02_在製品_03場內黑皮.Value, hfSQL02_在製品_03場內黑皮_LOT.Value, _
                                                                                                 hfSQL02_在製品_05外送代軋鋼胚A.Value, hfSQL04_場內鋼胚.Value, _
                                                                                                 hfSQL05_外送代軋鋼胚B.Value, hfSQL06_承訂落後量.Value)

        Dim changeColumnName As String
        For Each eachItem As DataColumn In QueryDataTable.Columns
            changeColumnName = ""

            Select Case eachItem.ColumnName
                Case "COL1"
                    changeColumnName = "項目"
                Case "COL2"
                    changeColumnName = "　"
                Case "成品當量"
                    changeColumnName = "成品當量(公噸)"
            End Select
            If changeColumnName <> "" Then eachItem.ColumnName = changeColumnName
        Next

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "料源狀況查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            For II As Integer = EnumGrdCol._COL1_項目 To EnumGrdCol._成品當量
                '寬度
                e.Row.Cells(II).Width = CType(IIf((II = EnumGrdCol._COL1_項目), 260, 60), Integer)

                '數字靠右對齊
                e.Row.Cells(II).Attributes.Add("style", IIf((II <= EnumGrdCol._COL3_細項), "text-align:left", "text-align:right"))
            Next II
        End If
    End Sub

#Region "MakeQuerySQL"
    Private Sub MakeQuerySQL()

        Dim querySQL As New StringBuilder
        Dim QueryDateDefault As String = "1010101"
        Dim QueryDate1 As String
        Dim QueryDate2 As String

        hfParam.Value = Format(Now, "yyyy/MM/dd hh:mm:ss")
        With querySQL
            .Clear()
            .Append("SELECT * FROM @#PPS100LB.PPSBPHPF" & vbNewLine)

            hfSQL00_LOT對照檔.Value = .ToString
        End With

        With querySQL
            .Clear()
            .Append("SELECT SUBSTR(cia05,1,3) ciab ,ch205 ,ROUND( DOUBLE(SUM(cia13))/1000 ,0 ) S00003" & vbNewLine)
            .Append(" FROM PPS100LB.PPSCIALJ,SLS300LB.SL2CH2PF" & vbNewLine)
            .Append(" WHERE cia06=ch201 and ch202<>'Y' and ch204=' '" & vbNewLine)
            .Append(" GROUP BY SUBSTR(cia05,1,3),ch205" & vbNewLine)
            .Append(" ORDER BY 1,2" & vbNewLine)

            hfSQL01_成品繳庫.Value = .ToString
        End With


        With querySQL
            .Clear()
            .Append("             (SELECT sha01,sha02,sha04,sha12,sha27,sha17/1000 S00006,sha06,sha21 FROM PPS100LB.PPSSHAL4 WHERE sha27<>'SSS ')" & vbNewLine)
            .Append("             UNION" & vbNewLine)
            .Append("             (SELECT sha01,sha02,sha04,sha12,sha27,sha17/1000 S00006,sha06,sha21 FROM PPS100LB.PPSSHAL5 WHERE sha27<>'SSS ')" & vbNewLine)

            hfSQL02_在製品_03場內黑皮.Value = .ToString
        End With

        With querySQL
            .Clear()
            .Append(" 		SELECT D1.bla09,bla11" & vbNewLine)
            .Append(" 		FROM @#PPS100LB.PPSBLALE D1" & vbNewLine)
            .Append(" 		WHERE 1=1" & vbNewLine)
            .Append(" 		  AND D1.bla09 IN (" & vbNewLine)
            .Append(" 						   SELECT M.sha01" & vbNewLine)
            .Append(" 						   FROM (" & vbNewLine)
            .Append(" 											  " & vbNewLine)
            .Append(hfSQL02_在製品_03場內黑皮.Value)
            .Append(" 											  " & vbNewLine)
            .Append(" 						  ) M" & vbNewLine)
            .Append(" 				)  " & vbNewLine)

            hfSQL02_在製品_03場內黑皮_LOT.Value = .ToString
        End With


        QueryDate1 = New AS400DateConverter(tb黑皮進場截止日.Text).TwSixCharsTypeData
        QueryDate2 = New AS400DateConverter(tb在製品截止日.Text).TwSixCharsTypeData
        hfParam.Value &= "|" & QueryDate1 & "|" & QueryDate2
        With querySQL
            .Clear()
            .Append("SELECT V1.*" & vbNewLine)
            .Append(" FROM (" & vbNewLine)
            .Append(" 		SELECT D1.bla09,D1.bla08,bla11,D1.bla07" & vbNewLine)
            .Append(" 				,substr(D1.bla07,1,5) ID1,substr(D1.bla07,7,1) ID2,substr(D1.bla07,8,2) ID3,substr(D1.bla07,10,1) ID4" & vbNewLine)
            .Append(" 				,'--' D1 ,CASE WHEN D1.BLA08>" & QueryDate1 & " THEN 'TRUE' ELSE 'FALSE' END D1Flag" & vbNewLine)
            .Append(" " & vbNewLine)
            .Append(" 				,'--' D2 ,CASE COALESCE(D2.sha01,'FALSE') WHEN 'FALSE' THEN 'FALSE' ELSE 'TRUE' END D2Flag" & vbNewLine)
            .Append(" 				,D2.sha01,D2.sha21" & vbNewLine)
            .Append(" " & vbNewLine)
            .Append(" 				,'--' D3 ,CASE COALESCE(D3.sga01,'FALSE') WHEN 'FALSE' THEN 'FALSE' ELSE 'TRUE' END D3Flag" & vbNewLine)
            .Append(" 				,D3.sga05,D3.sga33,D3.sga24/1000 S00007" & vbNewLine)
            .Append(" 						  " & vbNewLine)
            .Append(" 		FROM @#PPS100LB.PPSBLALE D1" & vbNewLine)
            .Append(" 			 LEFT JOIN @#PPS100LB.PPSSHAPF D2 ON D2.sha01=D1.bla09 and D2.sha04=1 and (D2.sha21=0 or D2.sha21>" & QueryDate2 & ")" & vbNewLine)
            .Append(" 			 LEFT JOIN @#SMS100LB.SMSSGALL D3 ON D3.sga01=substr(bla07,1,5) and D3.sga02=substr(bla07,7,1)  and D3.sga03=substr(bla07,8,2) and D3.sga04=substr(bla07,10,1) and sga35<>'R'" & vbNewLine)
            .Append(" 					 " & vbNewLine)
            .Append(" 		WHERE 1=1" & vbNewLine)
            .Append(" 		  AND D1.bla09 IN (" & vbNewLine)
            .Append(" 						   SELECT M.sha01" & vbNewLine)
            .Append(" 						   FROM (" & vbNewLine)
            .Append(" 											  " & vbNewLine)
            .Append(hfSQL02_在製品_03場內黑皮.Value)
            .Append(" 											  " & vbNewLine)
            .Append(" 						  ) M" & vbNewLine)
            '.Append(" 				)  AND D1.bla08>" & QueryDate1 & " and PosStr(bla07, '-')>0" & vbNewLine)
            .Append(" 				)  AND  PosStr(bla07, '-')>0" & vbNewLine)
            .Append(" ) V1" & vbNewLine)
            .Append(" WHERE 1=1" & vbNewLine)

            hfSQL02_在製品_05外送代軋鋼胚A.Value = .ToString
        End With


        QueryDate1 = QueryDateDefault
        QueryDate2 = New AS400DateConverter(tb鋼胚生產截止日.Text).TwSixCharsTypeData
        hfParam.Value &= "|" & QueryDate1 & "~" & QueryDate2
        With querySQL
            .Clear()
            .Append("SELECT sga05b,SAG35B,ROUND( sum(s0005),0) S00003" & vbNewLine)
            .Append(" FROM (" & vbNewLine)
            .Append(" select substr( sga05,1,3) sga05b " & vbNewLine)
            .Append("          , CASE SGA35" & vbNewLine)
            .Append("                    WHEN ' '  THEN '未研磨'" & vbNewLine)
            .Append("                    WHEN 'A' THEN '待檢驗'" & vbNewLine)
            .Append("                    WHEN 'B' THEN '已入庫'" & vbNewLine)
            .Append("                    ELSE 'X'" & vbNewLine)
            .Append("            END SAG35B" & vbNewLine)
            .Append("          , CASE SGA35" & vbNewLine)
            .Append("                    WHEN ' ' THEN DOUBLE(sga14)/1000" & vbNewLine)
            .Append("                    WHEN 'A' THEN DOUBLE(sga24)/1000" & vbNewLine)
            .Append("                    WHEN 'B' THEN DOUBLE(sga24)/1000" & vbNewLine)
            .Append("                    ELSE  0" & vbNewLine)
            .Append("            END S0005" & vbNewLine)
            .Append("			" & vbNewLine)
            .Append(" FROM SMS100LB.SMSSGAL6" & vbNewLine)
            .Append(" WHERE sga07 BETWEEN " & QueryDate1 & " AND " & QueryDate2 & " and sga35<>'C'" & vbNewLine)
            .Append("" & vbNewLine)
            .Append(" ) V" & vbNewLine)
            .Append(" GROUP BY sga05b,SAG35B" & vbNewLine)

            hfSQL04_場內鋼胚.Value = .ToString
        End With


        QueryDate1 = QueryDateDefault
        QueryDate2 = New AS400DateConverter(tb鋼胚生產截止日.Text).TwSixCharsTypeData
        hfParam.Value &= "|" & QueryDate1 & "~" & QueryDate2
        With querySQL
            .Clear()

            .Append("SELECT sga05,sga33,sga34" & vbNewLine)

            '1021017 by renhsin
            '.Append("                ,CASE WHEN sga34 > " & QueryDate1 & " THEN 'TRUE' ELSE 'FALSE' END isReadItem04" & vbNewLine)
            .Append("                ,CASE WHEN sga34 > " & QueryDate2 & " THEN 'TRUE' ELSE 'FALSE' END isReadItem04" & vbNewLine)

            .Append("               ,DEC(ROUND(SUM(sga24) /1000,0)) S00003" & vbNewLine)
            .Append(" FROM SMS100LB.SMSSGAL6" & vbNewLine)
            .Append(" WHERE sga07 between " & QueryDate1 & " and  " & QueryDate2 & "  AND sga35='C'" & vbNewLine)
            .Append(" GROUP BY sga05,sga33,sga34" & vbNewLine)

            hfSQL05_外送代軋鋼胚B.Value = .ToString
        End With


        QueryDate1 = Left(New AS400DateConverter(tb承訂落後量StartMonth.Text & "/01").TwSixCharsTypeData, 5)
        QueryDate2 = Left(New AS400DateConverter(tb承訂落後量EndMonth.Text & "/01").TwSixCharsTypeData, 5)
        hfParam.Value &= "|" & QueryDate1 & "~" & QueryDate2
        With querySQL
            .Clear()
            .Append("SELECT SUBSTR( qtn03,1,3) qtn03b,ch205,DEC( ROUND( SUM(qtn12-qtn21-qtn22) ,0)) S00003" & vbNewLine)
            .Append(" FROM SLS300LB.SL2QTNL2,SLS300LB.SL2CH2PF " & vbNewLine)
            .Append(" WHERE SUBSTR(qtn02,1,5) BETWEEN '" & QueryDate1 & "' AND '" & QueryDate2 & "' " & vbNewLine)
            .Append("   AND qtn12-qtn21-qtn22>=3 AND qtn93=' ' " & vbNewLine)
            .Append("   AND qtn04=ch201 AND ch202<>'Y' AND ch204=' ' " & vbNewLine)
            .Append(" GROUP BY SUBSTR(qtn03,1,3),ch205" & vbNewLine)

            hfSQL06_承訂落後量.Value = .ToString
        End With

    End Sub
#End Region

#Region "共用相關Method:取得位子/批次代碼/設定Gird的值"
    ''' <summary>
    ''' getGrdCol:取得表格欄的位置
    ''' </summary>
    ''' <param name="fromGRADE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getGrdCol(ByVal fromGRADE As String) As Integer
        Select Case Mid(fromGRADE, 1, 3)
            Case Is = "304"
                getGrdCol = EnumGrdCol._304
            Case Is = "202"
                getGrdCol = EnumGrdCol._202
            Case Is = "201"
                getGrdCol = EnumGrdCol._201
            Case Is = "301"
                getGrdCol = EnumGrdCol._301
            Case Else
                getGrdCol = EnumGrdCol._其他
        End Select
    End Function

    ''' <summary>
    ''' getGrdRow:取得表格列的位置
    ''' </summary>
    ''' <param name="fromDataMode"></param>
    ''' <param name="fromParamData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getGrdRow(ByVal fromDataMode As EnumDataMode, ByVal fromParamData As String) As Integer
        Dim retRowIndex As Integer

        Select Case fromDataMode
            Case EnumDataMode._01成品庫存
                retRowIndex = IIf(fromParamData.Trim = "CR", EnumGrdRow._成品庫存_CR, EnumGrdRow._成品庫存_NO1)

            Case EnumDataMode._04場內鋼胚
                Select Case fromParamData
                    Case "未研磨"
                        retRowIndex = EnumGrdRow._廠內鋼胚_未研磨
                    Case "待檢驗"
                        retRowIndex = EnumGrdRow._廠內鋼胚_待檢驗
                    Case "已入庫"
                        retRowIndex = EnumGrdRow._廠內鋼胚_已入庫
                End Select

            Case EnumDataMode._05送外代軋鋼胚A, EnumDataMode._05送外代軋鋼胚B
                retRowIndex = EnumGrdRow._送外代軋鋼胚_中鋼 + getLotSeq(fromParamData)

            Case EnumDataMode._06承訂落後量
                retRowIndex = IIf(fromParamData.Trim = "CR", EnumGrdRow._承訂落後量_CR, EnumGrdRow._承訂落後量_NO1)
            Case Else
                retRowIndex = 0
        End Select

        Return retRowIndex
    End Function

    ''' <summary>
    ''' getLotCode:取得外送批號代號
    ''' </summary>
    ''' <param name="fromLot"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getLotCode(ByVal fromLot As String) As String
        Dim L1, Lot As String
        Lot = Mid(fromLot, 1, 2)
        L1 = Mid(Lot, 2, 1)
        If (L1 >= "0" And L1 <= "9") Then Lot = Mid(Lot, 1, 1) & " "

        Return Lot
    End Function

    ''' <summary>
    ''' getLotSeq:取得外送批號序號
    ''' </summary>
    ''' <param name="fromLotCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getLotSeq(ByVal fromLotCode) As String
        Dim seq As Integer

        Select Case getLotCode(fromLotCode)
            Case Is = "T "
                seq = 0
            Case Else
                seq = 1
        End Select

        Return seq
    End Function

    ''' <summary>
    ''' setGridAddValue:將一個新的值加總至某個表格的欄位
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromRow"></param>
    ''' <param name="fromCol"></param>
    ''' <param name="fromAddValue"></param>
    ''' <remarks></remarks>
    Protected Shared Sub setGridAddValue(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, _
                                                                                    ByVal fromRow As Integer, ByVal fromCol As Integer, ByVal fromAddValue As String)
        Dim itemOldValue As Double = PassTextToValue(fromDataTable.Rows(fromRow).Item(fromCol))
        Dim itemAddValue As Double = PassTextToValue(fromAddValue)
        fromDataTable.Rows(fromRow).Item(fromCol) = itemOldValue + itemAddValue
    End Sub

    ''' <summary>
    ''' PassTextToValue:處理文字轉數字
    ''' </summary>
    ''' <param name="fromText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function PassTextToValue(ByVal fromText As String) As Double
        Dim retValue As Double = 0
        If IsNumeric(fromText) = True Then retValue = Double.Parse(fromText)
        Return retValue
    End Function

#End Region

#Region "查詢料源狀況：Search"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search(ByVal fromParam As String, _
                                                                ByVal fromSQL00_LOT對照檔 As String, _
                                                                ByVal fromSQL01_成品繳庫 As String, _
                                                                ByVal fromSQL02_在製品_03場內黑皮 As String, _
                                                                ByVal fromSQL02_在製品_03場內黑皮_LOT As String, _
                                                                ByVal fromSQL02_在製品_05外送代軋鋼胚A As String, _
                                                                ByVal fromSQL04_場內鋼胚 As String, _
                                                                ByVal fromSQL05_外送代軋鋼胚B As String, _
                                                                ByVal fromSQL06_承訂落後量 As String) As EISDataSet.MaterialStatusDataTable

        Dim retDataTable As EISDataSet.MaterialStatusDataTable = retDataTable_Create()
        If String.IsNullOrEmpty(fromParam) Then Return New EISDataSet.MaterialStatusDataTable

        Dim querySQL05外送代軋鋼胚A As New StringBuilder
        With querySQL05外送代軋鋼胚A
            .Append(" SELECT SUBSTR(sga05,1,3) sgab,sga33, DEC(ROUND(SUM(s00007),0)) s00007" & vbNewLine)
            .Append(" FROM (" & vbNewLine)
            .Append(" 		        " & vbNewLine)
            .Append(fromSQL02_在製品_05外送代軋鋼胚A)
            .Append(" 		        " & vbNewLine)
            .Append("                AND  D1Flag='TRUE' AND  D2Flag='TRUE' AND D3Flag='TRUE' " & vbNewLine)
            .Append(" ) V2" & vbNewLine)
            .Append(" GROUP BY SUBSTR(sga05,1,3),sga33" & vbNewLine)
        End With

        'Step1:分析各大類資料
        Search_Display(EnumDataMode._01成品庫存, retDataTable, fromSQL01_成品繳庫)

        Search_Static02_03(retDataTable, fromSQL02_在製品_03場內黑皮, fromSQL02_在製品_03場內黑皮_LOT, fromSQL00_LOT對照檔, fromSQL02_在製品_05外送代軋鋼胚A)

        Search_Display(EnumDataMode._04場內鋼胚, retDataTable, fromSQL04_場內鋼胚)

        Search_Display(EnumDataMode._05送外代軋鋼胚A, retDataTable, querySQL05外送代軋鋼胚A.ToString)
        Search_Display(EnumDataMode._05送外代軋鋼胚B, retDataTable, fromSQL05_外送代軋鋼胚B)

        Search_Display(EnumDataMode._06承訂落後量, retDataTable, fromSQL06_承訂落後量)


        'Step2:四捨五入(細項)
        retDataTable_Rounding(retDataTable, EnumRoundingMode._細項)

        'Step3:統計的合計/成品當量
        Static_ColSumTotal(retDataTable)
        Static_RowSumTotal(retDataTable)
        Static_otherSumTotal(retDataTable)

        'Step4:四捨五入(合計)
        retDataTable_Rounding(retDataTable, EnumRoundingMode._合計Row)
        retDataTable_Rounding(retDataTable, EnumRoundingMode._合計Col)

        Dim retDataTableOut As EISDataSet.MaterialStatusDataTable = retDataTable_FormatLayout(retDataTable)
        retDataTable_SetParam(retDataTableOut, fromParam)

        Return retDataTableOut
    End Function

    ''' <summary>
    ''' Search_Display:將SQL搜尋結果依規則放置特定位置
    ''' </summary>
    ''' <param name="fromDataMode"></param>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromSQL"></param>
    ''' <remarks></remarks>
    Protected Shared Sub Search_Display(ByVal fromDataMode As EnumDataMode, _
                                                                                       ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, ByVal fromSQL As String)
        Dim itemNameCol As String = ""
        Dim itemNameRow As String = ""
        Dim itemlNameValue As String = ""

        Select Case fromDataMode
            Case EnumDataMode._01成品庫存
                itemNameRow = "CH205"
                itemNameCol = "CIAB"
                itemlNameValue = "S00003"

            Case EnumDataMode._04場內鋼胚
                itemNameRow = "sag35b"
                itemNameCol = "sga05b"
                itemlNameValue = "S00003"

            Case EnumDataMode._05送外代軋鋼胚A
                itemNameRow = "sga33"
                itemNameCol = "sgab"
                itemlNameValue = "S00007"

            Case EnumDataMode._05送外代軋鋼胚B
                itemNameRow = "sga33"
                itemNameCol = "sga05"
                itemlNameValue = "S00003"

            Case EnumDataMode._06承訂落後量
                itemNameRow = "ch205"
                itemNameCol = "qtn03b"
                itemlNameValue = "S00003"
        End Select


        Dim queryDataTable As DataTable = adapterObj.SelectQuery(fromSQL)

        Dim showIndexRow As Integer
        Dim showIndexCol As Integer

        For Each eachItem As DataRow In queryDataTable.Rows
            showIndexRow = getGrdRow(fromDataMode, eachItem.Item(itemNameRow))
            showIndexCol = getGrdCol(eachItem.Item(itemNameCol))

            If fromDataMode = EnumDataMode._05送外代軋鋼胚B Then
                If eachItem.Item("isReadItem04") = "TRUE" Then
                    showIndexRow = EnumGrdRow._廠內鋼胚_已入庫
                End If
            End If

            setGridAddValue(fromDataTable, showIndexRow, showIndexCol, eachItem.Item(itemlNameValue))
        Next
    End Sub

    ''' <summary>
    ''' Search_Static02_03:統計分析 （二）在 製 品/（三）廠內黑皮
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromSQL02_03"></param>
    ''' <param name="fromSQL02_03_LOT"></param>
    ''' <param name="fromSQL00_LOT對照檔"></param>
    ''' <param name="fromSQL05A"></param>
    ''' <remarks></remarks>
    Protected Shared Sub Search_Static02_03(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, _
                                                                                      ByVal fromSQL02_03 As String, _
                                                                                      ByVal fromSQL02_03_LOT As String, ByVal fromSQL00_LOT對照檔 As String, _
                                                                                      ByVal fromSQL05A As String)

        Dim queryLotTemp As List(Of DataRow) = Nothing
        Dim queryDataTable02_03 As DataTable = adapterObj.SelectQuery(fromSQL02_03)
        Dim queryDataTable02_03_LOT As DataTable = adapterObj.SelectQuery(fromSQL02_03_LOT)
        Dim queryDataTable05A As DataTable = adapterObj.SelectQuery(fromSQL05A)

        Dim isSLABList As String = String.Join(",", (From A In queryDataTable05A _
                                                Where A.Item("D1Flag") = "TRUE" And A.Item("D2Flag") = "TRUE" And A.Item("D3Flag") = "TRUE" _
                                                Select A.Item("bla09")).ToArray)

        'Step1-A:排除送外代軋鋼胚
        Dim queryDataTable02_03_NotIsSLABList As DataTable = (From A In queryDataTable02_03 _
                                                                                                                             Where 1 = 1 _
                                                                                                                                  And Not isSLABList.Split(",").Contains(A.Item("sha01")) _
                                                                                                                             Select A).CopyToDataTable
        Dim showIndexRow As Integer
        Dim showIndexCol As Integer
        Dim LINE As String, S27 As String

        Dim CSC As String = ""
        Dim LotMapingList As List(Of PPS100LB.PPSBPHPF) = ClassDBAS400.CDBSelect(Of PPS100LB.PPSBPHPF)(fromSQL00_LOT對照檔, adapterObj)
        Dim LotCodeList未組 As New LotCodeList(LotMapingList)
        Dim LotCodeList已組 As New LotCodeList(LotMapingList)

        'Step 1:統計分析資料
        For Each eachItem As DataRow In queryDataTable02_03_NotIsSLABList.Rows

            '相關參數
            showIndexRow = 0
            showIndexCol = getGrdCol(eachItem.Item("sha12"))
            LINE = eachItem.Item("sha27")
            S27 = Mid(LINE, 4, 1)


            If (eachItem.Item("sha06") = "BL ") Then                         ' 黑皮
                'Step1-C:取得批號
                queryLotTemp = (From A In queryDataTable02_03_LOT _
                                                        Where A.Item("bla09") = eachItem.Item("sha01") _
                                                        Select A).ToList
                If queryLotTemp.Count > 0 Then
                    CSC = queryLotTemp.Item(0).Item("bla11")
                Else
                    CSC = "  "
                End If

                If (eachItem.Item("sha04") = 1 And eachItem.Item("sha21") = 0) Then       ' 未組
                    showIndexRow = 8 + getLotSeq(CSC)
                    LotCodeList未組.Add(getLotCode(CSC))
                Else                                                    ' 已組
                    showIndexRow = 10 + getLotSeq(CSC)
                    LotCodeList已組.Add(getLotCode(CSC))
                End If

            ElseIf (S27 = "*") Then                                 ' 待繳
                showIndexRow = EnumGrdRow._在製品_待繳
            ElseIf (eachItem.Item("sha06") = "NO1") Then                     ' NO1
                If (LINE <> "ZML ") Then                            ' NO1
                    showIndexRow = EnumGrdRow._在製品_NO1
                Else                                                ' 待派工
                    showIndexRow = EnumGrdRow._在製品_待派
                End If
            Else                                                    ' CR
                showIndexRow = EnumGrdRow._在製品_CR
            End If

            setGridAddValue(fromDataTable, showIndexRow, showIndexCol, eachItem.Item("S00006"))
        Next


        'Step 2:設定『場內黑皮』 其他廠商名稱
        fromDataTable.Rows(EnumGrdRow._廠內黑皮_未組其他).Item(EnumGrdCol._COL3_細項) = LotCodeList未組.getLotName
        fromDataTable.Rows(EnumGrdRow._廠內黑皮_已組其他).Item(EnumGrdCol._COL3_細項) = LotCodeList已組.getLotName

    End Sub

#End Region

#Region "相關欄位統計"
    ''' <summary>
    ''' Static_ColSumTotal:統計欄
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <remarks></remarks>
    Protected Shared Sub Static_ColSumTotal(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable)
        Dim rowStart As Integer, rowEnd As Integer
        Dim colSumTotal As Integer

        For colIndex As Integer = EnumGrdCol._304 To EnumGrdCol._成品當量
            colSumTotal = 0

            For rowIndex As Integer = EnumGrdRow._成品庫存_CR To EnumGrdRow._承訂落後量_小計
                Select Case rowIndex
                    Case EnumGrdRow._成品庫存_小計
                        rowStart = EnumGrdRow._成品庫存_CR : rowEnd = EnumGrdRow._成品庫存_NO1
                    Case EnumGrdRow._在製品_小計
                        rowStart = EnumGrdRow._在製品_待繳 : rowEnd = EnumGrdRow._在製品_待派
                    Case EnumGrdRow._廠內黑皮_小計
                        rowStart = EnumGrdRow._廠內黑皮_未組中鋼 : rowEnd = EnumGrdRow._廠內黑皮_已組其他
                    Case EnumGrdRow._廠內鋼胚_小計
                        rowStart = EnumGrdRow._廠內鋼胚_未研磨 : rowEnd = EnumGrdRow._廠內鋼胚_已入庫
                    Case EnumGrdRow._送外代軋鋼胚_小計
                        rowStart = EnumGrdRow._送外代軋鋼胚_中鋼 : rowEnd = EnumGrdRow._送外代軋鋼胚_其他
                    Case EnumGrdRow._承訂落後量_小計
                        rowStart = EnumGrdRow._承訂落後量_CR : rowEnd = EnumGrdRow._承訂落後量_NO1
                    Case Else
                        rowStart = -1 : rowEnd = -1
                End Select

                If rowStart = -1 AndAlso rowEnd = -1 Then Continue For

                'COL-小計
                For rowAddItemIndex As Integer = rowStart To rowEnd
                    setGridAddValue(fromDataTable, rowIndex, colIndex, fromDataTable.Rows(rowAddItemIndex).Item(colIndex))
                Next

                'COL-合計
                Select Case rowIndex
                    Case EnumGrdRow._成品庫存_小計, EnumGrdRow._在製品_小計, EnumGrdRow._廠內黑皮_小計, _
                               EnumGrdRow._廠內鋼胚_小計, EnumGrdRow._送外代軋鋼胚_小計
                        colSumTotal += Integer.Parse(fromDataTable.Rows(rowIndex).Item(colIndex))
                End Select

                'Display 合計
                If rowIndex = EnumGrdRow._送外代軋鋼胚_小計 Then fromDataTable.Rows(EnumGrdRow._ROW合計).Item(colIndex) = colSumTotal

            Next


            'COL-當量
            fromDataTable.Rows(EnumGrdRow._ROW成品當量).Item(colIndex) = 0 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._成品庫存_小計).Item(colIndex)) * class成品當量Obj._C成品庫存_小計 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_待繳).Item(colIndex)) * class成品當量Obj._C在製品_待繳 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_CR).Item(colIndex)) * class成品當量Obj._C在製品_CR _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_NO1).Item(colIndex)) * class成品當量Obj._C在製品_NO1 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_待派).Item(colIndex)) * class成品當量Obj._C在製品_待派 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._廠內黑皮_小計).Item(colIndex)) * class成品當量Obj._C廠內黑皮_小計 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._廠內鋼胚_小計).Item(colIndex)) * class成品當量Obj._C廠內鋼胚_小計 _
                                                         + PassTextToValue(fromDataTable.Rows(EnumGrdRow._送外代軋鋼胚_小計).Item(colIndex)) * class成品當量Obj._C送外代軋鋼胚_小計

        Next

    End Sub

    ''' <summary>
    ''' Static_RowSumTotal:統計列
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <remarks></remarks>
    Protected Shared Sub Static_RowSumTotal(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable)
        For rowIndex As Integer = EnumGrdRow._成品庫存_CR To EnumGrdRow._承訂落後量_小計
            For colIndex As Integer = EnumGrdCol._304 To EnumGrdCol._其他
                setGridAddValue(fromDataTable, rowIndex, EnumGrdCol._合計, fromDataTable.Rows(rowIndex).Item(colIndex))

                setGridAddValue(fromDataTable, rowIndex, EnumGrdCol._成品當量, PassTextToValue(fromDataTable.Rows(rowIndex).Item(colIndex)) * class成品當量Obj.getRow成品當量(rowIndex))
            Next

            If rowIndex = EnumGrdRow._在製品_小計 Then   '特殊公式
                fromDataTable.Rows(rowIndex).Item(EnumGrdCol._成品當量) = 0 _
                                             + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_待繳).Item(EnumGrdCol._成品當量)) _
                                             + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_CR).Item(EnumGrdCol._成品當量)) _
                                             + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_NO1).Item(EnumGrdCol._成品當量)) _
                                             + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_待派).Item(EnumGrdCol._成品當量))
            End If

        Next

    End Sub

    ''' <summary>
    ''' Static_otherSumTotal:處理特例統計
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <remarks></remarks>
    Protected Shared Sub Static_otherSumTotal(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable)
        fromDataTable.Rows(EnumGrdRow._ROW成品當量).Item(EnumGrdCol._合計) = ""
        fromDataTable.Rows(EnumGrdRow._ROW合計).Item(EnumGrdCol._成品當量) = 0 _
                                                                 + PassTextToValue(fromDataTable.Rows(EnumGrdRow._成品庫存_小計).Item(EnumGrdCol._成品當量)) _
                                                                 + PassTextToValue(fromDataTable.Rows(EnumGrdRow._在製品_小計).Item(EnumGrdCol._成品當量)) _
                                                                 + PassTextToValue(fromDataTable.Rows(EnumGrdRow._廠內黑皮_小計).Item(EnumGrdCol._成品當量)) _
                                                                 + PassTextToValue(fromDataTable.Rows(EnumGrdRow._廠內鋼胚_小計).Item(EnumGrdCol._成品當量)) _
                                                                 + PassTextToValue(fromDataTable.Rows(EnumGrdRow._送外代軋鋼胚_小計).Item(EnumGrdCol._成品當量))
    End Sub

#End Region


#Region "retDataTable相關格式處理"
    ''' <summary>
    ''' retDataTable_Create:建立所需所有空白欄位與標題
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function retDataTable_Create() As EISDataSet.MaterialStatusDataTable
        Dim retDataTable As New EISDataSet.MaterialStatusDataTable


        retDataTableRow_Create(retDataTable, "（一）成品庫存", "C/R")
        retDataTableRow_Create(retDataTable, "（一）成品庫存", "NO1")
        retDataTableRow_Create(retDataTable, "（一）成品庫存", "小計")

        retDataTableRow_Create(retDataTable, "（二）在製品", "待繳")
        retDataTableRow_Create(retDataTable, "（二）在製品", "C/R")
        retDataTableRow_Create(retDataTable, "（二）在製品", "NO1")
        retDataTableRow_Create(retDataTable, "（二）在製品", "待派")
        retDataTableRow_Create(retDataTable, "（二）在製品", "小計")

        retDataTableRow_Create(retDataTable, "（三）廠內黑皮 - 未組", "中鋼")
        retDataTableRow_Create(retDataTable, "（三）廠內黑皮 - 未組", "")
        retDataTableRow_Create(retDataTable, "（三）廠內黑皮 - 已組", "中鋼")
        retDataTableRow_Create(retDataTable, "（三）廠內黑皮 - 已組", "")
        retDataTableRow_Create(retDataTable, "（三）廠內黑皮", "小計")

        retDataTableRow_Create(retDataTable, "（四）廠內鋼胚", "未研磨")
        retDataTableRow_Create(retDataTable, "（四）廠內鋼胚", "待檢驗")
        retDataTableRow_Create(retDataTable, "（四）廠內鋼胚", "已入庫")
        retDataTableRow_Create(retDataTable, "（四）廠內鋼胚", "小計")

        retDataTableRow_Create(retDataTable, "（五）送外代軋鋼胚", "中鋼")
        retDataTableRow_Create(retDataTable, "（五）送外代軋鋼胚", "")
        retDataTableRow_Create(retDataTable, "（五）送外代軋鋼胚", "小計")

        retDataTableRow_Create(retDataTable, "　合計", "")
        retDataTableRow_Create(retDataTable, "", "當量")

        retDataTableRow_Create(retDataTable, "（六）承訂落後量", "C/R")
        retDataTableRow_Create(retDataTable, "（六）承訂落後量", "NO1")
        retDataTableRow_Create(retDataTable, "（六）承訂落後量", "小計")

        Return retDataTable
    End Function

    ''' <summary>
    ''' retDataTableRow_Create:新增一個Row並設定值
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromCol1"></param>
    ''' <param name="fromCol2"></param>
    ''' <remarks></remarks>
    Protected Shared Sub retDataTableRow_Create(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, _
                                                                                                            ByVal fromCol1 As String, ByVal fromCol2 As String)
        Dim addItem As EISDataSet.MaterialStatusRow = Nothing


        addItem = fromDataTable.NewRow
        With addItem
            .COL1 = fromCol1
            .COL2 = fromCol2
        End With
        fromDataTable.Rows.Add(addItem)

    End Sub

    ''' <summary>
    ''' retDataTable_Rounding:四捨五入小數
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromMode"></param>
    ''' <remarks></remarks>
    Protected Shared Sub retDataTable_Rounding(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, ByVal fromMode As EnumRoundingMode)
        Dim rowStart As Integer, rowEnd As Integer
        Dim colStart As Integer, colEnd As Integer

        Select Case fromMode
            Case EnumRoundingMode._細項
                rowStart = EnumGrdRow._成品庫存_CR : rowEnd = EnumGrdRow._承訂落後量_NO1
                colStart = EnumGrdCol._304 : colEnd = EnumGrdCol._其他
            Case EnumRoundingMode._合計Row
                rowStart = EnumGrdRow._ROW成品當量 : rowEnd = EnumGrdRow._ROW成品當量
                colStart = EnumGrdCol._304 : colEnd = EnumGrdCol._合計
            Case EnumRoundingMode._合計Col
                rowStart = EnumGrdRow._成品庫存_CR : rowEnd = EnumGrdRow._承訂落後量_NO1
                colStart = EnumGrdCol._合計 : colEnd = EnumGrdCol._成品當量
        End Select


        Dim valueOld As String
        Dim valueNew As String

        For rowIndex As Integer = rowStart To rowEnd
            For colIndex As Integer = colStart To colEnd
                valueOld = fromDataTable.Rows(rowIndex).Item(colIndex)
                Select Case valueOld
                    Case "", "0"
                        valueNew = ""
                    Case Else
                        valueNew = Math.Round(Double.Parse(valueOld), 0, MidpointRounding.AwayFromZero)
                End Select
                fromDataTable.Rows(rowIndex).Item(colIndex) = valueNew
            Next
        Next
    End Sub

    ''' <summary>
    ''' retDataTable_FormatLayout:重新整理版面配置
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function retDataTable_FormatLayout(ByVal fromDataTable As EISDataSet.MaterialStatusDataTable) As EISDataSet.MaterialStatusDataTable
        Dim retDataTable As New EISDataSet.MaterialStatusDataTable
        Dim AddItemRow As DataRow = Nothing
        Dim AddShowText As String, TempShowText As String, splitTempShowText() As String
        Dim rowStart As Integer, rowEnd As Integer

        For II As Integer = EnumDataMode._01成品庫存 To EnumDataMode._06承訂落後量
            Select Case II
                Case EnumDataMode._01成品庫存
                    rowStart = EnumGrdRow._成品庫存_CR : rowEnd = EnumGrdRow._成品庫存_小計
                Case EnumDataMode._02在製品
                    rowStart = EnumGrdRow._在製品_待繳 : rowEnd = EnumGrdRow._在製品_小計
                Case EnumDataMode._03場內黑皮
                    rowStart = EnumGrdRow._廠內黑皮_未組中鋼 : rowEnd = EnumGrdRow._廠內黑皮_小計
                Case EnumDataMode._04場內鋼胚
                    rowStart = EnumGrdRow._廠內鋼胚_未研磨 : rowEnd = EnumGrdRow._廠內鋼胚_小計
                Case EnumDataMode._05送外代軋鋼胚A
                    rowStart = EnumGrdRow._送外代軋鋼胚_中鋼 : rowEnd = EnumGrdRow._送外代軋鋼胚_小計
                Case EnumDataMode._05送外代軋鋼胚B
                    Continue For
                Case EnumDataMode._合計
                    rowStart = EnumGrdRow._ROW合計 : rowEnd = EnumGrdRow._ROW合計
                Case EnumDataMode._當量
                    rowStart = EnumGrdRow._ROW成品當量 : rowEnd = EnumGrdRow._ROW成品當量
                Case EnumDataMode._06承訂落後量
                    rowStart = EnumGrdRow._承訂落後量_CR : rowEnd = EnumGrdRow._承訂落後量_小計
            End Select

            AddItemRow = retDataTable.NewRow
            For colIndex As Integer = EnumGrdCol._COL1_項目 To EnumGrdCol._成品當量
                For rowIndex As Integer = rowStart To rowEnd
                    AddShowText = fromDataTable.Rows(rowIndex).Item(colIndex)

                    If colIndex = EnumGrdCol._COL1_項目 Then
                        splitTempShowText = AddShowText.Split("-")
                        TempShowText = splitTempShowText(0)
                        If AddItemRow.Item(colIndex) <> "" Then TempShowText = "".PadRight(TempShowText.Length - 1, "　") & Space(2)

                        If rowIndex >= EnumGrdRow._廠內黑皮_未組中鋼 And rowIndex <= EnumGrdRow._廠內黑皮_已組其他 Then
                            TempShowText &= "-" & splitTempShowText(1)
                        End If
                        AddShowText = TempShowText
                    End If

                    If AddShowText = "0" Then AddShowText = ""
                    If AddShowText = "" Then AddShowText = "　"

                    If IsNumeric(AddShowText) = True Then AddShowText = String.Format("{0:N0}", Integer.Parse(AddShowText))

                    AddItemRow.Item(colIndex) &= AddShowText & "<BR>"
                Next

            Next

            retDataTable.Rows.Add(AddItemRow)
        Next

        Return retDataTable
    End Function

    ''' <summary>
    ''' retDataTable_SetParam:設定Param資訊
    ''' </summary>
    ''' <param name="fromDataTable"></param>
    ''' <param name="fromParam"></param>
    ''' <remarks></remarks>
    Protected Shared Sub retDataTable_SetParam(ByRef fromDataTable As EISDataSet.MaterialStatusDataTable, ByVal fromParam As String)
        Dim paramSplit = Split(fromParam, "|")
        Dim showCol1 As String = "", showCol2 As String = ""

        showCol1 &= "截止時間：" & paramSplit(0) & "<BR>"
        showCol1 &= "<BR>"
        showCol1 &= "黑皮進廠截止日：" & paramSplit(1) & "<BR>"
        showCol1 &= "在製品截止日：" & paramSplit(2) & "<BR>"
        showCol1 &= "鋼胚生產起訖日：" & paramSplit(3) & "<BR>"
        showCol1 &= "外送代軋鋼胚起起訖日：" & paramSplit(4) & "<BR>"
        showCol1 &= "承訂落後量起訖年月：" & paramSplit(5) & "<BR>"

        retDataTableRow_Create(fromDataTable, "", "")
        retDataTableRow_Create(fromDataTable, showCol1, showCol2)
    End Sub

#End Region

#Region "Class相關"
    ''' <summary>
    ''' LotCodeList:取得外送批號公司名稱清單
    ''' </summary>
    ''' <remarks></remarks>
    Class LotCodeList
        Private _LotCodeList As New List(Of String)
        Private _LotMapingList As List(Of PPS100LB.PPSBPHPF)

        Sub New(ByVal fromLotMapingList As List(Of PPS100LB.PPSBPHPF))
            _LotMapingList = fromLotMapingList
        End Sub

        Public Sub Add(ByVal fromLotCode As String)
            For Each eachItem As String In _LotCodeList
                If eachItem.Equals(fromLotCode) Then Exit Sub
            Next

            _LotCodeList.Add(fromLotCode)
        End Sub

        Public Function getLotName() As String
            Dim retLotName As String = ""
            Dim queryLotName As String

            For Each eachItem As String In _LotCodeList
                queryLotName = (From A In _LotMapingList Where A.BPH00 = eachItem Select A.BPH04.Trim).FirstOrDefault
                If IsNothing(queryLotName) OrElse queryLotName = "" Then Continue For

                retLotName &= IIf(retLotName = "", "", ",") & queryLotName
            Next

            Return retLotName
        End Function

    End Class

    ''' <summary>
    ''' class成品當量:取得成品當量的乘數
    ''' </summary>
    ''' <remarks></remarks>
    Class class成品當量
        Public _C成品庫存_CR As Double = 1
        Public _C成品庫存_NO1 As Double = 1
        Public _C成品庫存_小計 As Double = 1

        Public _C在製品_待繳 As Double = 1
        Public _C在製品_CR As Double = 0.93
        Public _C在製品_NO1 As Double = 0.98
        Public _C在製品_待派 As Double = 0.92
        Public _C在製品_小計 As Double = 1

        Public _C廠內黑皮_未組中鋼 As Double = 0.91
        Public _C廠內黑皮_未組其他 As Double = 0.91
        Public _C廠內黑皮_已組中鋼 As Double = 0.91
        Public _C廠內黑皮_已組其他 As Double = 0.91
        Public _C廠內黑皮_小計 As Double = 0.91

        Public _C廠內鋼胚_未研磨 As Double = 0.98 * 0.91
        Public _C廠內鋼胚_待檢驗 As Double = 0.98 * 0.91
        Public _C廠內鋼胚_已入庫 As Double = 0.98 * 0.91
        Public _C廠內鋼胚_小計 As Double = 0.98 * 0.91

        Public _C送外代軋鋼胚_中鋼 As Double = 0.98 * 0.91
        Public _C送外代軋鋼胚_其他 As Double = 0.98 * 0.91
        Public _C送外代軋鋼胚_小計 As Double = 0.98 * 0.91

        Public _C承訂落後量_CR As Double = 1
        Public _C承訂落後量_NO1 As Double = 1
        Public _C承訂落後量_小計 As Double = 1

        Public Function getRow成品當量(ByVal fromRow As EnumGrdRow) As Double
            Dim retValue As Double = 1

            Select Case fromRow
                Case EnumGrdRow._成品庫存_CR
                    retValue = _C成品庫存_CR
                Case EnumGrdRow._成品庫存_NO1
                    retValue = _C成品庫存_NO1
                Case EnumGrdRow._成品庫存_小計
                    retValue = _C成品庫存_小計

                Case EnumGrdRow._在製品_待繳
                    retValue = _C在製品_待繳
                Case EnumGrdRow._在製品_CR
                    retValue = _C在製品_CR
                Case EnumGrdRow._在製品_NO1
                    retValue = _C在製品_NO1
                Case EnumGrdRow._在製品_待派
                    retValue = _C在製品_待派
                Case EnumGrdRow._在製品_小計
                    retValue = _C在製品_小計

                Case EnumGrdRow._廠內黑皮_未組中鋼
                    retValue = _C廠內黑皮_未組中鋼
                Case EnumGrdRow._廠內黑皮_未組其他
                    retValue = _C廠內黑皮_未組其他
                Case EnumGrdRow._廠內黑皮_已組中鋼
                    retValue = _C廠內黑皮_已組中鋼
                Case EnumGrdRow._廠內黑皮_已組其他
                    retValue = _C廠內黑皮_已組其他
                Case EnumGrdRow._廠內黑皮_小計
                    retValue = _C廠內黑皮_小計

                Case EnumGrdRow._廠內鋼胚_未研磨
                    retValue = _C廠內鋼胚_未研磨
                Case EnumGrdRow._廠內鋼胚_待檢驗
                    retValue = _C廠內鋼胚_待檢驗
                Case EnumGrdRow._廠內鋼胚_已入庫
                    retValue = _C廠內鋼胚_已入庫
                Case EnumGrdRow._廠內鋼胚_小計
                    retValue = _C廠內鋼胚_小計

                Case EnumGrdRow._送外代軋鋼胚_中鋼
                    retValue = _C送外代軋鋼胚_中鋼
                Case EnumGrdRow._送外代軋鋼胚_其他
                    retValue = _C送外代軋鋼胚_其他
                Case EnumGrdRow._送外代軋鋼胚_小計
                    retValue = _C送外代軋鋼胚_小計

                Case EnumGrdRow._承訂落後量_CR
                    retValue = _C承訂落後量_CR
                Case EnumGrdRow._承訂落後量_NO1
                    retValue = _C承訂落後量_NO1
                Case EnumGrdRow._承訂落後量_小計
                    retValue = _C承訂落後量_小計
            End Select

            Return retValue
        End Function

    End Class
#End Region

#Region "常數Enum"
    ''' <summary>
    ''' EnumRoundingMode:四捨五入模式
    ''' </summary>
    ''' <remarks></remarks>
    Enum EnumRoundingMode
        _細項 = 1
        _合計Row = 2
        _合計Col = 3
    End Enum

    ''' <summary>
    ''' EnumDataMode:資料統計類型
    ''' </summary>
    ''' <remarks></remarks>
    Enum EnumDataMode
        _01成品庫存 = 1
        _02在製品 = 2
        _03場內黑皮 = 3
        _04場內鋼胚 = 4
        _05送外代軋鋼胚A = 5
        _05送外代軋鋼胚B = 6
        _合計 = 7
        _當量 = 8
        _06承訂落後量 = 9
    End Enum

    ''' <summary>
    ''' EnumGrdCol:表格欄
    ''' </summary>
    ''' <remarks></remarks>
    Enum EnumGrdCol
        _COL1_項目 = 0
        _COL3_細項 = 1
        _304 = 2
        _202 = 3
        _201 = 4
        _301 = 5
        _其他 = 6
        _合計 = 7
        _成品當量 = 8
    End Enum

    ''' <summary>
    ''' EnumGrdRow:表格列
    ''' </summary>
    ''' <remarks></remarks>
    Enum EnumGrdRow
        _成品庫存_CR = 0
        _成品庫存_NO1 = 1
        _成品庫存_小計 = 2
        _在製品_待繳 = 3
        _在製品_CR = 4
        _在製品_NO1 = 5
        _在製品_待派 = 6
        _在製品_小計 = 7
        _廠內黑皮_未組中鋼 = 8
        _廠內黑皮_未組其他 = 9
        _廠內黑皮_已組中鋼 = 10
        _廠內黑皮_已組其他 = 11
        _廠內黑皮_小計 = 12
        _廠內鋼胚_未研磨 = 13
        _廠內鋼胚_待檢驗 = 14
        _廠內鋼胚_已入庫 = 15
        _廠內鋼胚_小計 = 16
        _送外代軋鋼胚_中鋼 = 17
        _送外代軋鋼胚_其他 = 18
        _送外代軋鋼胚_小計 = 19
        _ROW合計 = 20
        _ROW成品當量 = 21
        _承訂落後量_CR = 22
        _承訂落後量_NO1 = 23
        _承訂落後量_小計 = 24
    End Enum

#End Region


End Class