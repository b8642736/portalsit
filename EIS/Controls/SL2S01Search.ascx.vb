Public Class SL2S01Search
    Inherits System.Web.UI.UserControl



#Region "查詢報價單訂購明細：Search1"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search1(ByVal fromOrderNo As String) As EISDataSet.SL2QTNPFDataTable
        Dim retDatatable As EISDataSet.SL2QTNPFDataTable = New EISDataSet.SL2QTNPFDataTable
        Dim AddItem As EISDataSet.SL2QTNPFRow = Nothing

        If String.IsNullOrEmpty(fromOrderNo) Then
            Return retDatatable
        End If

        Dim SQL As New StringBuilder

        Dim queryCustNo As String = IIf(fromOrderNo.Length < 3, fromOrderNo, fromOrderNo.Substring(0, 3))
        Dim queryOrderSeq As String = IIf(fromOrderNo.Length < 3, fromOrderNo, fromOrderNo.Substring(3))
        SQL.Append("SELECT * " & vbNewLine)
        SQL.Append("FROM @#SLS300LB.SL2QTNPF " & vbNewLine)
        SQL.Append("WHERE 1=1 " & vbNewLine)
        SQL.Append("  AND qtn01='" & queryCustNo & "' " & vbNewLine)
        SQL.Append("  AND qtn02='" & queryOrderSeq & "' " & vbNewLine)
        SQL.Append("ORDER BY qtn01,qtn02,qtn03,qtn04,qtn05 " & vbNewLine)

        Dim queryList As List(Of SLS300LB.SL2QTNPF) = ClassDBAS400.CDBSelect(Of SLS300LB.SL2QTNPF)(SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem As SLS300LB.SL2QTNPF In queryList
            AddItem = retDatatable.NewRow
            With AddItem
                .鋼種 = eachItem.QTN03
                .TYPE = eachItem.QTN30
                .表面 = eachItem.QTN04
                .厚度 = eachItem.QTN05
                .CODE3 = eachItem.QTN94
                .寬度 = eachItem.QTN06
                .毛_修邊 = eachItem.QTN08
                .長度 = eachItem.QTN07
                .C_S = eachItem.QTN10
                .訂單量 = eachItem.QTN12
                .發貨量 = eachItem.QTN21
                .待發貨 = eachItem.QTN22

                .料別 = eachItem.QTN25
                .未交量 = Math.Round((eachItem.QTN12 - eachItem.QTN21 - eachItem.QTN22), 0, MidpointRounding.AwayFromZero)
                .內徑 = eachItem.QTN09


                'Format
                Search1FormatAddItem(AddItem)
            End With

            retDatatable.Rows.Add(AddItem)
        Next

        '報價單合計
        Search1AddSum(retDatatable, queryList, queryCustNo, queryOrderSeq)

        Return retDatatable
    End Function

    Protected Shared Sub Search1FormatAddItem(ByRef fromAddItem As EISDataSet.SL2QTNPFRow)
        With fromAddItem
            If IsNumeric(.訂單量) Then .訂單量 = String.Format("{0:0.00}", Double.Parse(.訂單量))
            If IsNumeric(.發貨量) Then .發貨量 = String.Format("{0:0.000}", Double.Parse(.發貨量))
            If IsNumeric(.待發貨) Then .待發貨 = String.Format("{0:0.00}", Math.Floor(Double.Parse(fromAddItem.待發貨) * Math.Pow(10, 2)) / Math.Pow(10, 2))
        End With
    End Sub

    Protected Shared Sub Search1AddSum(ByRef fromDataTable As EISDataSet.SL2QTNPFDataTable, _
                                                                 ByVal fromQueryList As List(Of SLS300LB.SL2QTNPF), _
                                                                 ByVal fromCustNo As String, ByVal fromOrderSeq As String)

        Dim AddItem As EISDataSet.SL2QTNPFRow = fromDataTable.NewRow
        Dim QueryList As List(Of SLS300LB.SL2QTNPF) = (From A In fromQueryList Where A.QTN01 = fromCustNo And A.QTN02 = fromOrderSeq Select A).ToList
        With AddItem
            .鋼種 = "合計"
            .訂單量 = (From A In QueryList Select A.QTN12).Sum
            .發貨量 = (From A In QueryList Select A.QTN21).Sum
            .待發貨 = (From A In QueryList Select A.QTN22).Sum

            '未交量=訂單量-發貨量-待發貨
            .未交量 = (From A In QueryList Select Math.Round((A.QTN12 - A.QTN21 - A.QTN22), 0, MidpointRounding.AwayFromZero)).Sum
        End With
        Search1FormatAddItem(AddItem)

        fromDataTable.Rows.Add(AddItem)
    End Sub

#End Region


#Region "查詢報價單厚度鋼捲明細：SearchDetail"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromParam">報價單號|鋼種|表面|厚度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SearchDetail(ByVal fromParam As String) As EISDataSet.SL2CICPFDataTable
        Dim retDatatTable As EISDataSet.SL2CICPFDataTable = New EISDataSet.SL2CICPFDataTable
        Dim AddItem As EISDataSet.SL2CICPFRow = Nothing

        If String.IsNullOrEmpty(fromParam) = True Then
            Return retDatatTable
        End If

        Dim Static淨重Sum As Double = 0
        Dim Display淨重 As String = ""
        Dim Display沖銷 As String = ""

        Dim SQL1A As New StringBuilder
        Dim SQL1B As New StringBuilder
        Dim param() As String = fromParam.Split("|")
        Dim queryOrderNoNo As String = param(0)
        Dim querySteelKind As String = param(1)
        Dim queryCoiType As String = param(2)
        Dim queryThick As String = param(3)

        '製成品
        SQL1A.Append("SELECT * " & vbNewLine)
        SQL1A.Append("FROM @#PPS100LB.PPSCIAPF " & vbNewLine)
        SQL1A.Append("WHERE 1=1 " & vbNewLine)
        SQL1A.Append("  AND cia04='" & queryOrderNoNo & "' " & vbNewLine)
        SQL1A.Append("  AND cia05='" & querySteelKind & "' " & vbNewLine)
        SQL1A.Append("  AND cia06='" & queryCoiType & "' " & vbNewLine)
        SQL1A.Append("  AND cia37=cia05 " & vbNewLine)
        SQL1A.Append("  AND cia38=cia06 " & vbNewLine)
        SQL1A.Append("  AND TRIM(substr(cia39,1,2) || '.' || substr(cia39,3))='" & queryThick & "' " & vbNewLine)
        SQL1A.Append("  AND cia45='*' " & vbNewLine)
        SQL1A.Append("ORDER BY cia04,cia02,cia03 " & vbNewLine)
        Dim QueryList1 As List(Of PPS100LB.PPSCIAPF) = ClassDBAS400.CDBSelect(Of PPS100LB.PPSCIAPF)(SQL1A.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem1 As PPS100LB.PPSCIAPF In QueryList1

            SQL1B.Clear()
            SQL1B.Append("SELECT * FROM @#SLS300LB.SL2EXPPF WHERE 1=1 ")
            SQL1B.Append("     AND EXP15='" & eachItem1.CIA62 & "' ")
            SQL1B.Append("     AND EXP03='" & eachItem1.CIA02 & "' ")
            SQL1B.Append("      AND EXP04='" & eachItem1.CIA03 & "' ")
            Dim QueryList1B As List(Of SLS300LB.SL2EXPPF) = ClassDBAS400.CDBSelect(Of SLS300LB.SL2EXPPF)(SQL1B.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Display沖銷 = (From B In QueryList1B Select B.EXP11).Sum().ToString

            Display淨重 = eachItem1.CIA13
            Static淨重Sum += IIf(IsNumeric(Display淨重), Double.Parse(Display淨重), 0)

            SearchDetailAddItem(retDatatTable, eachItem1.CIA62, eachItem1.CIA02, eachItem1.CIA03, eachItem1.CIA05, _
                                                                            eachItem1.CIA06, eachItem1.CIA07, eachItem1.CIA08, eachItem1.CIA09, _
                                                                            eachItem1.CIA12, Display淨重, eachItem1.CIA16, eachItem1.CIA45, eachItem1.CIA46, Display沖銷)
        Next



        '在製品
        Dim SQL2 As New StringBuilder
        SQL2.Append("SELECT* " & vbNewLine)
        SQL2.Append("FROM @#SLS300LB.SL2CICPF " & vbNewLine)
        SQL2.Append("WHERE 1=1 " & vbNewLine)
        SQL2.Append("    and cic10='" & queryOrderNoNo & "' " & vbNewLine)
        SQL2.Append("    and cic11='" & querySteelKind & "' " & vbNewLine)
        SQL2.Append("    and cic13='" & queryCoiType & "' " & vbNewLine)
        SQL2.Append("    and TRIM(substr(cic14,1,2) || '.' || substr(cic14,3))='" & queryThick & "' " & vbNewLine)
        SQL2.Append("    and cic91='' " & vbNewLine)
        Dim QueryList2 As List(Of SLS300LB.SL2CICPF) = ClassDBAS400.CDBSelect(Of SLS300LB.SL2CICPF)(SQL2.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem2 As SLS300LB.SL2CICPF In QueryList2

            Dim Display提貨單號 As String = ""
            Dim Display寬度 As String = ""
            Dim Display厚度 As String = eachItem2.CIC14.Substring(0, 2).Trim & "." & eachItem2.CIC14.Substring(2).Trim
            Dim Display繳庫 As String = ""

            Dim Display長度 As String = ""
            Dim DisplayC_S As String = ""
            Dim Display等級 As String = ""
            Dim Display發貨 As String = ""
            Display沖銷 = ""

            Dim SQL3 As New StringBuilder

            SQL3.Clear()
            SQL3.Append("SELECT  *" & vbNewLine)
            SQL3.Append("FROM @#PPS100LB.PPSSHAPF " & vbNewLine)
            SQL3.Append("WHERE 1=1 " & vbNewLine)
            SQL3.Append(" and sha01='" & eachItem2.CIC01 & "' and sha02='" & eachItem2.CIC02 & "' " & vbNewLine)
            SQL3.Append(" and sha28<>'*' " & vbNewLine)
            SQL3.Append("order by sha04 " & vbNewLine)
            SQL3.Append("fetch first 1 rows only" & vbNewLine)
            Dim ppsshapfObj As PPS100LB.PPSSHAPF = ClassDBAS400.CDBSelect(Of PPS100LB.PPSSHAPF)(SQL3.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).FirstOrDefault
            If Not IsNothing(ppsshapfObj) Then
                Display提貨單號 = ppsshapfObj.SHA08 & " 製程"
                Display寬度 = ppsshapfObj.SHA15
                Display厚度 = ppsshapfObj.SHA14
                Display淨重 = ppsshapfObj.SHA17
                Display繳庫 = ppsshapfObj.SHA28
            End If


            SearchDetailAddItem(retDatatTable, Display提貨單號, eachItem2.CIC01, eachItem2.CIC02, eachItem2.CIC11, eachItem2.CIC13, _
                                                                         Display厚度, _
                                                                            Display寬度, Display長度, DisplayC_S, Display淨重, Display等級, Display繳庫, Display發貨, Display沖銷)

            Static淨重Sum += IIf(IsNumeric(Display淨重), Double.Parse(Display淨重), 0)
        Next

        '小計
        If retDatatTable.Rows.Count > 0 Then SearchDetailAddSum(retDatatTable, Static淨重Sum)

        Return retDatatTable
    End Function

    Protected Shared Sub SearchDetailAddItem(ByRef fromDatatTable As EISDataSet.SL2CICPFDataTable, _
                                                                                      ByVal from提貨單號 As String, ByVal from鋼捲號碼1 As String, ByVal from鋼捲號碼2 As String, _
                                                                                      ByVal from鋼種 As String, ByVal from表面 As String, ByVal from厚度 As String, _
                                                                                      ByVal from寬度 As String, ByVal from長度 As String, ByVal fromC_S As String, _
                                                                                      ByVal from淨重 As String, ByVal from等級 As String, ByVal from繳庫 As String, _
                                                                                      ByVal from發貨 As String, ByVal from沖銷 As String)
        Dim AddItem As EISDataSet.SL2CICPFRow = fromDatatTable.NewRow

        With AddItem
            .提貨單號 = from提貨單號
            .鋼捲號碼 = from鋼捲號碼1 & Space(2) & from鋼捲號碼2
            .鋼種 = from鋼種
            .表面 = from表面
            .厚度 = from厚度
            .寬度 = from寬度
            .長度 = from長度
            .C_S = fromC_S
            .淨重 = from淨重
            .等級 = from等級
            .繳庫 = from繳庫
            .發貨 = from發貨
            .沖銷 = from沖銷
        End With

        'Format
        With AddItem
            If IsNumeric(.厚度) Then .厚度 = String.Format("{0:0.00}", Double.Parse(.厚度))
            If IsNumeric(.淨重) Then .淨重 = String.Format("{0:0.000}", Double.Parse(.淨重) / 1000)
            If IsNumeric(.發貨) Then .發貨 = String.Format("{0:0.00}", Double.Parse(.發貨))
        End With

        fromDatatTable.Rows.Add(AddItem)
    End Sub

    Protected Shared Sub SearchDetailAddSum(ByRef fromDatatTable As EISDataSet.SL2CICPFDataTable, _
                                                                                   ByVal from淨重Sum As Double)

        SearchDetailAddItem(fromDatatTable, "小計", "", "", "", "", _
                                                             "", _
                                                                "", "", "", from淨重Sum, "", "", "", "")
    End Sub

#End Region


#Region "查詢報價單訂購明細：Search2"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search2(ByVal fromOrderNo As String) As EISDataSet.SL2QTNPF1_SL2CICPFDataTable
        Dim retDatatTable As New EISDataSet.SL2QTNPF1_SL2CICPFDataTable
        Dim AddRow As EISDataSet.SL2QTNPF1_SL2CICPFRow = Nothing

        If String.IsNullOrEmpty(fromOrderNo) Then
            Return retDatatTable
        End If

        Dim queryMasterDatatble As EISDataSet.SL2QTNPFDataTable = Search1(fromOrderNo)
        Dim queryDetailDatatable As EISDataSet.SL2CICPFDataTable = Nothing
        For Each eachRowMasther As DataRow In queryMasterDatatble.Rows
            AddRow = retDatatTable.NewRow

            'Copy Masther Data
            For Each eachColumnMaster As DataColumn In queryMasterDatatble.Columns
                AddRow.Item(eachColumnMaster.ColumnName) = eachRowMasther.Item(eachColumnMaster.ColumnName)
            Next


            'Copy Detail Data
            Dim Param As String          '報價單號|鋼種|表面|厚度
            Param = fromOrderNo & "|" & eachRowMasther.Item("鋼種").ToString.Trim & "|" & eachRowMasther.Item("表面").ToString.Trim & "|" & eachRowMasther.Item("厚度").ToString.Trim
            queryDetailDatatable = SearchDetail(Param)

            If queryDetailDatatable.Rows.Count = 0 Then
                retDatatTable.Rows.Add(AddRow)
            Else
                Dim eachRowDetail As DataRow = Nothing
                Dim RealColumnName As String = Nothing

                For II As Integer = 0 To queryDetailDatatable.Rows.Count - 1
                    eachRowDetail = queryDetailDatatable.Rows(II)

                    For Each eachColumnDetail As DataColumn In queryDetailDatatable.Columns
                        RealColumnName = eachColumnDetail.ColumnName

                        Select Case RealColumnName
                            Case "提貨單號", "鋼捲號碼", "鋼種", "表面", "厚度", "寬度", "長度", "C_S", "淨重", "等級", "繳庫", "發貨", "沖銷"
                                RealColumnName = RealColumnName & "D"
                        End Select

                        If RealColumnName = "長度D" Then
                            Debug.Print(Now)
                        End If

                        If Not String.IsNullOrEmpty(AddRow.Item(RealColumnName)) Then
                            AddRow.Item(RealColumnName) &= "<BR>"
                        End If

                        If (String.IsNullOrEmpty(eachRowDetail.Item(eachColumnDetail.ColumnName)) = False) AndAlso (eachRowDetail.Item(eachColumnDetail.ColumnName).trim <> "") Then
                            AddRow.Item(RealColumnName) &= eachRowDetail.Item(eachColumnDetail.ColumnName)
                        Else
                            AddRow.Item(RealColumnName) &= "　　"
                        End If

                    Next

                Next
                retDatatTable.Rows.Add(AddRow)
            End If

        Next

        Return retDatatTable
    End Function
#End Region

    Public Sub MakeQuerySQL()
        CType(Me.FindControl("hfOrderNoNo" & ddShowType.SelectedValue), HiddenField).Value = TxtOrderNo.Text
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQuerySQL()
        MultiView1.SetActiveView(CType(Me.FindControl("View" & ddShowType.SelectedValue), View))
    End Sub

    'Public Sub MakeQuerySQL2() 'for test
    '    Me.hfParam2.Value = "P2410207001|304|2B|1.00"
    'End Sub

    'Protected Sub btnSearch2_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
    '    MakeQuerySQL2()
    'End Sub


    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        TxtOrderNo.Text = Nothing
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQuerySQL()

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim QueryDataTable As DataTable = Nothing

        If ddShowType.SelectedValue = 1 Then
            QueryDataTable = Search1(Me.hfOrderNoNo1.Value)
        ElseIf ddShowType.SelectedValue = 2 Then
            QueryDataTable = Search2(Me.hfOrderNoNo2.Value)
        End If

        For Each eachItem As DataColumn In QueryDataTable.Columns
            eachItem.ColumnName = eachItem.ColumnName.Replace("_", "/")

            If Right(eachItem.ColumnName, 1) = "D" Then eachItem.ColumnName = Mid(eachItem.ColumnName, 1, eachItem.ColumnName.Length - 1) & Space(1)
        Next

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "報價單資訊查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub


#Region "GridView排版：文字靠右/數字靠左"

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        GridView_RowDataBound(e, GridView1)
    End Sub

    Private Sub GridView3_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView3.RowDataBound
        GridView_RowDataBound(e, GridView3)
    End Sub

    Private Sub GridView_RowDataBound(e As GridViewRowEventArgs, fromGridView As GridView)
        If e.Row.RowType = DataControlRowType.DataRow Then
            '數字靠右對齊
            For II As Integer = 0 To fromGridView.Columns.Count - 1
                Select Case fromGridView.Columns(II).HeaderText
                    Case "鋼種", "C/S", "毛/修邊", "料別", "提貨單號", "鋼捲號碼", "表面", "繳庫", "發貨"
                    Case Else
                        e.Row.Cells(II).Attributes.Add("style", "text-align:right")
                End Select
            Next II
        End If
    End Sub

#End Region


End Class