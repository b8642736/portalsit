Public Class ProductManufactureCostStatistics
    Inherits System.Web.UI.UserControl

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            '寬度
            Dim Width As Integer
            For II As Integer = 0 To 6
                Select Case II
                    Case 4
                        Width = 100
                    Case 5, 6
                        Width = 140
                    Case 2
                        Width = 75
                    Case Else
                        Width = 55
                End Select

                e.Row.Cells(II).Width = Width
            Next

            '數字靠右對齊
            For II As Integer = 4 To 6
                e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            Next II
        End If
    End Sub

    Protected Sub btnDownToExcel_Click(sender As Object, e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim queryDataTable As DataTable = Search(Me.hfSQL_acsrm1pf.Value, Me.hfSQL_sl2cicpf.Value, Me.hfSQL_ppsciapf.Value)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "製成品淨變現價值統計" & Me.hfSearchDate.Value & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl - v1"
    '    ''' <summary>
    '    ''' 查詢產生至控制項
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    ''' 
    '    Private Function MakeSQL1String(ByVal fromType As Integer) As String
    '        Dim ReturnSQL_acsrm1pf1 As New StringBuilder
    '        Dim SQL4Of5DataAdjustment As String = "0.0000001"
    '        'Note:在某些欄位上在四捨五入前要先加上一個不會影響結果值的數字(ex:0.0000001),否則在四捨五入情況下會有問題

    '        If fromType = 2 Then
    '            ReturnSQL_acsrm1pf1.Append("		SELECT 2 BREAKLVL, rm103,rm103 rm103O,ym,cic16 " & vbNewLine)
    '        ElseIf fromType = 1 Then
    '            ReturnSQL_acsrm1pf1.Append("		SELECT 1 BREAKLVL, rm103,rm103 rm103O,''ym,''cic16 " & vbNewLine)
    '        ElseIf fromType = 0 Then
    '            ReturnSQL_acsrm1pf1.Append("		SELECT 0 BREAKLVL, ' ' rm103,'999ZZ' rm103O,''ym,''cic16 " & vbNewLine)
    '        End If
    '        ReturnSQL_acsrm1pf1.Append("			   ,SUM(rm1100203) rm11002001 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("			   ,SUM(rm12001) rm1200101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("			   ,SUM(amt) amt01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("		FROM ( " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				SELECT T01.RM103 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				,CASE COALESCE(cic10,'NULL') " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						   WHEN 'NULL' THEN '     ' " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						   ELSE substr(cic10,4,5) " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				  END YM " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("					  ,COALESCE(t02.cic16,' ') cic16,t01.rm100 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("					  ,t01.rm101,t01.rm1100203,t01.rm12001 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("					  ,rm12001+rm12101+rm12301+rm12401+rm123a01+rm124a01+rm12201 amt " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				FROM ( " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						SELECT T01.RM103,T01.RM100,T01.RM101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("							   ,SUM(T02.RM120) RM12001 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("							  ,Min(T01.RM11002) RM1100203,SUM(T02.RM121) RM12101,SUM(T02.RM122) RM12201,SUM(T02.RM123) RM12301 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("							  ,SUM(T02.RM124) RM12401,SUM(T02.RM123A) RM123A01,SUM(T02.RM124A) RM124A01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						FROM ( " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("								SELECT t01.rm103,t01.rm100,t01.rm101,DEC(Avg(t02.rm110)) rm11002 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("								FROM ( " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("										SELECT rm103,rm100,rm101,MAX(rm102) rm10204 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("										FROM @#ACS300LB.ACSRM1PF.TEMP03  " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("										GROUP BY rm103,rm100,rm101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("								) t01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("								   LEFT JOIN @#ACS300LB.ACSRM1PF.TEMP03 t02 ON t02.rm103=t01.rm103 AND t02.rm100=t01.rm100 AND t02.rm101=t01.rm101 AND t02.rm102=t01.rm10204 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("								GROUP BY t01.rm103,t01.rm100,t01.rm101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						) t01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						   LEFT JOIN @#ACS300LB.ACSRM1PF.TEMP03 t02 ON T02.RM103=T01.RM103 AND T02.RM100=T01.RM100 AND T02.RM101=T01.RM101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						GROUP BY t01.RM103,t01.RM100,t01.RM101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("						ORDER BY t01.RM103,t01.RM100,t01.RM101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				) t01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("				   LEFT JOIN @#SLS300LB.SL2CICPF t02 ON t02.cic01 =t01.rm100 AND t02.cic02=t01.rm101 " & vbNewLine)
    '        ReturnSQL_acsrm1pf1.Append("		) V " & vbNewLine)
    '        If fromType = 2 Then
    '            ReturnSQL_acsrm1pf1.Append("		GROUP BY rm103,ym,cic16 " & vbNewLine)
    '        ElseIf fromType = 1 Then
    '            ReturnSQL_acsrm1pf1.Append("		GROUP BY rm103 " & vbNewLine)
    '        ElseIf fromType = 0 Then
    '            ReturnSQL_acsrm1pf1.Append("		GROUP BY 0 " & vbNewLine)
    '        End If



    '        Return ReturnSQL_acsrm1pf1.ToString
    '    End Function

    '    Private Sub MakerSQLStringToControl()


    '        Dim ReturnSQL_acsrm1pf As New StringBuilder
    '        ReturnSQL_acsrm1pf.Append("SELECT BREAKLVL,rm103,ym,cic16, CHAR(rm11002001) rm11002001,CHAR(rm1200101) rm1200101,CHAR(amt01) amt01 " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append("FROM ( " & vbNewLine)

    '        ReturnSQL_acsrm1pf.Append(MakeSQL1String(2) & " " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append("		UNION " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append(MakeSQL1String(1) & " " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append("		UNION " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append(MakeSQL1String(0) & " " & vbNewLine)


    '        ReturnSQL_acsrm1pf.Append(") V " & vbNewLine)
    '        ReturnSQL_acsrm1pf.Append("ORDER BY rm103O,BREAKLVL desc,ym,cic16 " & vbNewLine)

    '        Me.hfSQL.Value = ReturnSQL_acsrm1pf.ToString
    '        Me.hfSearchDate.Value = Format(Now, "yyyyMMdd_HHmmss")

    '    End Sub
#End Region

#Region "查詢 方法:Search - v1"
    '    ''' <summary>
    '    ''' 查詢
    '    ''' </summary>
    '    ''' <param name="fromSQL"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    <DataObjectMethod(DataObjectMethodType.Select)> _
    '    Public Function Search(ByVal fromSQL As String) As DataTable
    '        Dim ReturnDataTable As New DataTable

    '        If String.IsNullOrEmpty(fromSQL) Then
    '            Return ReturnDataTable
    '        End If

    '        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    '        ReturnDataTable = Adapter.SelectQuery(fromSQL)

    '        For Each eachItemRow As DataRow In ReturnDataTable.Rows
    '            '3個數字加上1個逗號
    '            eachItemRow.Item("RM11002001") = StringFormatNumberOf3Symbol(eachItemRow.Item("RM11002001"))
    '            eachItemRow.Item("RM1200101") = StringFormatNumberOf3Symbol(eachItemRow.Item("RM1200101"))
    '            eachItemRow.Item("AMT01") = StringFormatNumberOf3Symbol(eachItemRow.Item("AMT01"))
    '        Next

    '        'ReturnDataTable.Columns.Remove("BREAKLVL")

    '        ReturnDataTable.Columns("RM103").ColumnName = "鋼種"
    '        ReturnDataTable.Columns("YM").ColumnName = "訂單年月"
    '        ReturnDataTable.Columns("CIC16").ColumnName = "內外銷"
    '        ReturnDataTable.Columns("RM11002001").ColumnName = "重量"
    '        ReturnDataTable.Columns("RM1200101").ColumnName = "原料成本"
    '        ReturnDataTable.Columns("AMT01").ColumnName = "總成本"
    '        Return ReturnDataTable
    '    End Function

#End Region





#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl - v2"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Private Sub MakerSQLStringToControl()

        Dim ReturnSQL_acsrm1pf As New StringBuilder
        ReturnSQL_acsrm1pf.Append("SELECT 3 BREAKLVL,t01d.RM103, '' YM, '' IO " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  ,t01d.rm100, t01d.rm101 " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  ,t01d.RM1100_MIN Weight,t01d.RM120_SUM Costs_1 " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  ,(t01d.RM120_SUM + t01d.RM121_SUM + t01d.RM122_SUM + t01d.RM123_SUM + t01d.RM123A_SUM + t01d.RM124_SUM + t01d.RM124A_SUM) Costs_ALL " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("FROM (	   " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  SELECT t01c.RM103,t01c.RM100,t01c.RM101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  	  ,SUM(t01d.RM120) RM120_SUM " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  	  ,Min(t01c.rm110_AVG) RM1100_MIN " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  	  ,SUM(t01d.RM121) RM121_SUM, SUM(t01d.RM122) RM122_SUM, SUM(t01d.RM123) RM123_SUM " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  	  ,SUM(t01d.RM124) RM124_SUM, SUM(t01d.RM123A) RM123A_SUM, SUM(t01d.RM124A) RM124A_SUM  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  FROM (  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  		SELECT t01a.rm103,t01a.rm100,t01a.rm101,DEC(Avg(t01b.rm110)) rm110_AVG  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  		FROM (  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  				SELECT rm103,rm100,rm101,MAX(rm102) rm102_MAX " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  				FROM @#ACS300LB.ACSRM1PF.TEMP03   " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  				GROUP BY rm103,rm100,rm101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  		) t01a " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  		   LEFT JOIN @#ACS300LB.ACSRM1PF.TEMP03 t01b ON t01b.rm103=t01a.rm103 AND t01b.rm100=t01a.rm100 AND t01b.rm101=t01a.rm101 AND t01b.rm102=t01a.rm102_MAX  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  		GROUP BY t01a.rm103,t01a.rm100,t01a.rm101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  ) t01c  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	     LEFT JOIN @#ACS300LB.ACSRM1PF.TEMP03 t01d ON t01d.RM103=t01c.RM103 AND t01d.RM100=t01c.RM100 AND t01d.RM101=t01c.RM101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  GROUP BY t01c.RM103,t01c.RM100,t01c.RM101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append("	  ORDER BY t01c.RM103,t01c.RM100,t01c.RM101  " & vbNewLine)
        ReturnSQL_acsrm1pf.Append(") t01d	  " & vbNewLine)


        Dim ReturnSQL_sl2cicpf As New StringBuilder
        ReturnSQL_sl2cicpf.Append("SELECT t02c.*  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("FROM @#SLS300LB.SL2CICPF t02c  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("EXCEPTION  Join    " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("(  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("	SELECT t02a.*  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("	FROM @#SLS300LB.SL2CICPF t02a  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append("	EXCEPTION  Join  @#ACS300LB.ACSRM1PF.TEMP03 t01 ON t01.rm100=t02a.cic01  AND t01.rm101=t02a.cic02  " & vbNewLine)
        ReturnSQL_sl2cicpf.Append(")  t02b  ON t02b.cic01=t02c.cic01 AND t02b.cic02=t02c.cic02 AND t02b.cic03=t02c.cic03  " & vbNewLine)


        Dim ReturnSQL_ppsciapf As New StringBuilder
        ReturnSQL_ppsciapf.Append("SELECT t03c.* " & vbNewLine)
        ReturnSQL_ppsciapf.Append("FROM @#PPS100LB.PPSCIAPF t03c " & vbNewLine)
        ReturnSQL_ppsciapf.Append("EXCEPTION  Join   " & vbNewLine)
        ReturnSQL_ppsciapf.Append("( " & vbNewLine)
        ReturnSQL_ppsciapf.Append("	SELECT t03a.* " & vbNewLine)
        ReturnSQL_ppsciapf.Append("	FROM @#PPS100LB.PPSCIAPF t03a " & vbNewLine)
        ReturnSQL_ppsciapf.Append("	EXCEPTION  Join  @#ACS300LB.ACSRM1PF.TEMP03 t01 ON t01.rm100=t03a.cia02  AND t01.rm101=t03a.cia03 " & vbNewLine)
        ReturnSQL_ppsciapf.Append(")  t03b  ON t03b.cia02=t03c.cia02 AND t03b.cia03=t03c.cia03 AND t03b.cia54=t03c.cia54 AND t03b.cia55=t03c.cia55 " & vbNewLine)


        Me.hfSQL_acsrm1pf.Value = ReturnSQL_acsrm1pf.ToString
        Me.hfSQL_sl2cicpf.Value = ReturnSQL_sl2cicpf.ToString
        Me.hfSQL_ppsciapf.Value = ReturnSQL_ppsciapf.ToString
        Me.hfSearchDate.Value = Format(Now, "yyyyMMdd_HHmmss")

    End Sub
#End Region
#Region "v2版本說明"
    '1:抓取在製品鋼捲清單 ACS300LB.ACSRM1PF.TEMP03

    '2:判斷狀況
    '       0 :檢查 SLS300LB.SL2CICPF.在製品鋼捲入有主
    '       A:狀況1 還在線上生產 
    '	                    cic91 (CODE-1)  =''
    '                       cic10 (報價單), cic16 (銷)
    '       B:狀況2 已繳庫
    '	                    cic91 (CODE-1)  <>''
    '                       PPS100LB.PPSCIAPF.繳庫檔
    '                       cia58 (會計日期), cia34 (外銷)
    '       C:狀況3 非上述兩項，歸屬在無主生產

    '3:整理相關群組資料
    '       Break Lvl 3：鋼捲清單資料
    '       Break Lvl 2：鋼種+訂單月份+內外銷
    '       Break Lvl 1：鋼種小計
    '       Break Lvl 0：總計
#End Region
#Region "查詢 方法:Search - v2"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromSQL_acsrm1pf"></param>
    ''' <param name="fromSQL_sl2cicpf"></param>
    ''' <param name="fromSQL_ppsciapf"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL_acsrm1pf As String, ByVal fromSQL_sl2cicpf As String, ByVal fromSQL_ppsciapf As String) As DataTable
        Dim ReturnTable As New DataTable

        If String.IsNullOrEmpty(fromSQL_acsrm1pf) OrElse _
            String.IsNullOrEmpty(fromSQL_sl2cicpf) OrElse
            String.IsNullOrEmpty(fromSQL_ppsciapf) Then
            Return ReturnTable
        End If

        Dim queryTable1 As DataTable
        Dim queryList2 As List(Of SLS300LB.SL2CICPF), filterList2 As List(Of SLS300LB.SL2CICPF), itemObj2 As SLS300LB.SL2CICPF
        Dim queryList3 As List(Of PPS100LB.PPSCIAPF), filterList3 As List(Of PPS100LB.PPSCIAPF), itemObj3 As PPS100LB.PPSCIAPF
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        '讀取400資料
        '--------------------------------------------------------------------------------------------------------------
        queryTable1 = Adapter.SelectQuery(fromSQL_acsrm1pf)
        queryList2 = SLS300LB.SL2CICPF.CDBSelect(Of SLS300LB.SL2CICPF)(fromSQL_sl2cicpf, Adapter)
        queryList3 = PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(fromSQL_ppsciapf, Adapter)

        '查詢鋼捲對應的年月份及內外銷
        '--------------------------------------------------------------------------------------------------------------
        For Each eachRow As DataRow In queryTable1.Rows

            filterList2 = (From B In queryList2 Where 1 = 1 _
                                 And B.CIC01.Trim.Equals(eachRow.Field(Of String)("rm100").Trim) _
                                 And B.CIC02.Trim.Equals(eachRow.Field(Of String)("rm101").Trim) _
                                 Order By B.CIC03 Descending _
                            Select B).ToList

            If filterList2.Count > 0 Then

                '狀況1 還在線上生產 
                itemObj2 = filterList2(0)
                If itemObj2.CIC10.Length > 8 Then eachRow.Item("YM") = itemObj2.CIC10.Substring(3, 5)
                eachRow.Item("IO") = itemObj2.CIC16

            Else

                filterList3 = (From C In queryList3 Where 1 = 1 _
                                         And C.CIA02.Trim.Equals(eachRow.Field(Of String)("rm100").Trim) _
                                         And C.CIA03.Trim.Equals(eachRow.Field(Of String)("rm101").Trim) _
                                       Order By C.CIA55 Descending _
                                      Select C).ToList
                If filterList3.Count > 0 Then
                    '狀況2 已繳庫
                    itemObj3 = filterList3(0)
                    eachRow.Item("YM") = itemObj3.CIA58
                    eachRow.Item("IO") = itemObj3.CIA34
                    If eachRow.Item("YM").ToString.Length >= 5 Then eachRow.Item("YM") = eachRow.Item("YM").ToString.Substring(0, 5)

                Else
                    'C:狀況3 非上述兩項，歸屬在無主生產
                End If

            End If

        Next


        '複製標題
        '--------------------------------------------------------------------------------------------------------------
        'ReturnTable = queryTable1.Clone
        For Each eachColumn As DataColumn In queryTable1.Columns
            ReturnTable.Columns.Add(eachColumn.ColumnName)
        Next

        '統計相關資料
        '--------------------------------------------------------------------------------------------------------------
        Dim groupTable As List(Of String()) = (From D In queryTable1.AsEnumerable _
                                    Group D By g1 = D.Field(Of String)("RM103") _
                                                    , g2 = D.Field(Of String)("YM") _
                                                    , g3 = D.Field(Of String)("IO") Into M_A = Group _
                                   Order By g1, g2, g3 _
                                   Select New String() {g1, g2, g3}).ToList

        Dim LastW_RM103 As String = "", W_RM103 As String, W_YM As String, W_IO As String
        For Each eachItem As String() In groupTable
            W_RM103 = eachItem(0)
            W_YM = eachItem(1)
            W_IO = eachItem(2)

            'LV 1
            If LastW_RM103 <> "" AndAlso LastW_RM103 <> W_RM103 Then
                P_AddAndStatistics(1, ReturnTable, ReturnTable, LastW_RM103, "", "")
            End If
            LastW_RM103 = W_RM103

            'LV 2
            P_AddAndStatistics(2, ReturnTable, queryTable1, W_RM103, W_YM, W_IO)
        Next

        'LV 1     最後一組
        P_AddAndStatistics(1, ReturnTable, ReturnTable, LastW_RM103, "", "")

        'V0
        P_AddAndStatistics(0, ReturnTable, ReturnTable, "", "", "")

        '美化排版資料
        '--------------------------------------------------------------------------------------------------------------        
        For Each eachItemRow As DataRow In ReturnTable.Rows
            '3個數字加上1個逗號
            eachItemRow.Item("Weight") = StringFormatNumberOf3Symbol(eachItemRow.Item("Weight"))
            eachItemRow.Item("Costs_1") = StringFormatNumberOf3Symbol(eachItemRow.Item("Costs_1"))
            eachItemRow.Item("Costs_ALL") = StringFormatNumberOf3Symbol(eachItemRow.Item("Costs_ALL"))
        Next

        ReturnTable.Columns.Remove("RM100")
        ReturnTable.Columns.Remove("RM101")

        ReturnTable.Columns("RM103").ColumnName = "鋼種"
        ReturnTable.Columns("YM").ColumnName = "訂單年月"
        ReturnTable.Columns("IO").ColumnName = "內外銷"
        ReturnTable.Columns("Weight").ColumnName = "重量"
        ReturnTable.Columns("Costs_1").ColumnName = "原料成本"
        ReturnTable.Columns("Costs_ALL").ColumnName = "總成本"
        Return ReturnTable
    End Function

    Private Sub P_AddAndStatistics(ByVal fromLel As Integer, ByRef fromReturn As DataTable, ByRef fromQuery As DataTable, _
                                              ByVal fromRM103 As String, ByVal fromYM As String, ByVal fromIO As String)

        Dim AddItem As DataRow = fromReturn.NewRow
        Dim subQueryTable As DataTable = Nothing
        Select Case fromLel
            Case 0
                subQueryTable = (From A In fromQuery Where A.Item("BREAKLVL").Equals("1") Select A).CopyToDataTable
            Case 1
                subQueryTable = (From A In fromQuery Where A.Item("RM103").Equals(fromRM103) And A.Item("BREAKLVL").Equals("2") Select A).CopyToDataTable
            Case 2
                subQueryTable = (From A In fromQuery Where A.Item("RM103").Equals(fromRM103) AndAlso A.Item("YM").Equals(fromYM) AndAlso A.Item("IO").Equals(fromIO) Select A).CopyToDataTable
        End Select

        With AddItem
            .Item("BREAKLVL") = fromLel
            .Item("RM103") = fromRM103
            .Item("YM") = fromYM
            .Item("IO") = fromIO

            .Item("Weight") = (From A In subQueryTable Select Double.Parse(A.Item("Weight"))).Sum
            .Item("Costs_1") = (From A In subQueryTable Select Double.Parse(A.Item("Costs_1"))).Sum
            .Item("Costs_ALL") = (From A In subQueryTable Select Double.Parse(A.Item("Costs_ALL"))).Sum
        End With

        fromReturn.Rows.Add(AddItem)
    End Sub
#End Region


    Public Shared Function StringFormatNumberOf3Symbol(ByVal fromString As String) As String
        If String.IsNullOrEmpty(fromString) Then Return ""

        Dim ReturnString As String
        Dim Num1 As String
        Dim Num2 As String
        Dim NumPoint As Integer

        NumPoint = fromString.IndexOf(".")
        If NumPoint = -1 Then
            Num1 = fromString
            Num2 = ""
        Else
            Num1 = IIf(NumPoint = 0, "0", fromString.Substring(0, NumPoint))
            Num2 = fromString.Substring(NumPoint + 1)
        End If

        ReturnString = IIf(NumPoint = 0, "", String.Format("{0:N0}", Integer.Parse(Num1)))
        ReturnString &= IIf(Num2 = "", "", "." & Num2)
        Return ReturnString
    End Function

End Class