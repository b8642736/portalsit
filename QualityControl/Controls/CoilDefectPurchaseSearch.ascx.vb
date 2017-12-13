Partial Public Class CoilDefectPurchaseSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search2(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectPurchaseSearchDataTable2DataTable
        Dim ReturnValue As New QualityControlDataSet.CoilDefectPurchaseSearchDataTable2DataTable
        Dim ShowTitleInfoKey As DataRow = Nothing
        Dim ShowTitleInfoKeyGroupDatas As New List(Of DataRow)
        Dim NumberCount As Integer = 0
        Dim CoilBugAssey As List(Of CompanyORMDB.PPS100LB.PPSDEFPF) = CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        Dim SearchTemp As List(Of DataRow) = (From A In SearchBase(SQLString, DFAndMD30Range) Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        SearchTemp = FilterDefectMinNumber(SearchTemp, FilterDefectNumber)
        SearchTemp = FilterTotalVLength(SearchTemp, FilterMaxBugTotalVLength)
        '  Dim TraceLineDateValue As String = Nothing

        For Each EachItem As DataRow In SearchTemp
            Dim EachItemTemp As DataRow = EachItem
            Dim ADDItem As QualityControlDataSet.CoilDefectPurchaseSearchDataTable2Row = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01") OrElse ShowTitleInfoKey("熱軋批次") <> EachItem.Item("BLA11") OrElse ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("鋼種") <> EachItem.Item("QCI05") OrElse ShowTitleInfoKey("鋼胚產日") <> EachItem.Item("QCI02"))
                'If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged OrElse TraceLineDateValue <> EachItem.Item("QDE04") Then

                'End If
                'TraceLineDateValue = EachItem.Item("QDE04")
                .追縱線別日期 = EachItem.Item("QDE04")

                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                    'ShowTitleInfoKeyGroupDatas.Clear()
                    'ShowTitleInfoKeyGroupDatas = (From A In SearchTemp Where A.Item("BLA01") = EachItemTemp.Item("BLA01") And A.Item("BLA11") = EachItemTemp.Item("BLA11") And A.Item("BLA07") = EachItemTemp.Item("BLA07") And A.Item("BLA09") = EachItemTemp.Item("BLA09") And A.Item("QCI05") = EachItemTemp.Item("QCI05") And A.Item("QCI02") = EachItemTemp.Item("QCI02") And A.Item("QCI06") = EachItemTemp.Item("QCI06") Select A).ToList
                    '.序號 = NumberCount
                    '.熱軋號碼 = EachItem.Item("BLA01")
                    '.熱軋批次 = EachItem.Item("BLA11")
                    '.鋼胚號碼 = EachItem.Item("BLA07")
                    '.鋼捲號碼 = EachItem.Item("BLA09")
                    '.鋼種 = EachItem.Item("QCI05")
                    '.材質 = EachItem.Item("QCI06")
                    '.鋼胚產日 = EachItem.Item("QCI02")
                    '.DF = IIf(CType(EachItem.Item("QCI05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                    '.MD30 = EachItem.Item("MD30")
                    '.C = EachItem.Item("QCI07")
                    '.SI = EachItem.Item("QCI08")
                    '.MN = EachItem.Item("QCI09")
                    '.P = EachItem.Item("QCI10")
                    '.S = EachItem.Item("QCI11")
                    '.CR = EachItem.Item("QCI12")
                    '.NI = EachItem.Item("QCI13")
                    '.CU = EachItem.Item("QCI14")
                    '.MO = EachItem.Item("QCI15")
                    '.CO = EachItem.Item("QCI16")
                    '.AL = EachItem.Item("QCI17")
                    '.SN = EachItem.Item("QCI18")
                    '.PB = EachItem.Item("QCI19")
                    '.TI = EachItem.Item("QCI20")
                    '.NB = EachItem.Item("QCI21")
                    '.V = EachItem.Item("QCI22")
                    '.W = EachItem.Item("QCI23")
                    '.O2 = EachItem.Item("QCI24")
                    '.N2 = EachItem.Item("QCI25")
                    '.H2 = EachItem.Item("QCI26")
                    '.B = EachItem.Item("QCI27")
                    '.Ca = EachItem.Item("QCI28") / 100
                    '.Mg = EachItem.Item("QCI29") / 100
                    '.Fe = EachItem.Item("QCI30")
                    'ShowTitleInfoKey = ADDItem
                End If

                .序號 = NumberCount
                .熱軋號碼 = EachItem.Item("BLA01")
                .熱軋批次 = EachItem.Item("BLA11")
                .鋼胚號碼 = EachItem.Item("BLA07")
                .鋼捲號碼 = EachItem.Item("BLA09")
                .鋼種 = EachItem.Item("QCI05")
                .材質 = EachItem.Item("QCI06")
                .鋼胚產日 = EachItem.Item("QCI02")
                .DF = IIf(CType(EachItem.Item("QCI05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .MD30 = EachItem.Item("MD30")
                .C = EachItem.Item("QCI07")
                .SI = EachItem.Item("QCI08")
                .MN = EachItem.Item("QCI09")
                .P = EachItem.Item("QCI10")
                .S = EachItem.Item("QCI11")
                .CR = EachItem.Item("QCI12")
                .NI = EachItem.Item("QCI13")
                .CU = EachItem.Item("QCI14")
                .MO = EachItem.Item("QCI15")
                .CO = EachItem.Item("QCI16")
                .AL = EachItem.Item("QCI17")
                .SN = EachItem.Item("QCI18")
                .PB = EachItem.Item("QCI19")
                .TI = EachItem.Item("QCI20")
                .NB = EachItem.Item("QCI21")
                .V = EachItem.Item("QCI22")
                .W = EachItem.Item("QCI23")
                .O2 = EachItem.Item("QCI24")
                .N2 = EachItem.Item("QCI25")
                .H2 = EachItem.Item("QCI26")
                .B = EachItem.Item("QCI27")
                .Ca = EachItem.Item("QCI28") / 100
                .Mg = EachItem.Item("QCI29") / 100
                .Fe = EachItem.Item("QCI30")
                ShowTitleInfoKey = ADDItem
                .班別 = EachItem.Item("SHA09")
                .進時間 = Format(EachItem.Item("SHA22"), "00") & ":" & Format(EachItem.Item("SHA23"), "00")
                .出時間 = Format(EachItem.Item("SHA24"), "00") & ":" & Format(EachItem.Item("SHA25"), "00")


                ''缺陷代碼38,138,238同歸一類缺陷次數累計
                'Dim BugCode As Integer = EachItemTemp.Item("QDE05")
                'If {38, 138, 238}.Contains(BugCode) Then
                '    .缺陷次數 = (From A In ShowTitleInfoKeyGroupDatas Where {38, 138, 238}.Contains(CType(A.Item("QDE05"), Integer)) Select A).Count
                'Else
                '    .缺陷次數 = (From A In ShowTitleInfoKeyGroupDatas Where CType(A.Item("QDE05"), Integer) = BugCode Select A).Count
                'End If
                .追蹤線別 = EachItem.Item("QDE01")
                .厚度 = EachItem.Item("BLA03")
                Dim GetCoilBugAssey As CompanyORMDB.PPS100LB.PPSDEFPF = (From A In CoilBugAssey Where A.DEF01 = CType(EachItemTemp.Item("QDE05"), String) Select A).FirstOrDefault
                If IsNothing(GetCoilBugAssey) Then
                    .缺陷代號 = EachItemTemp.Item("QDE05")
                Else
                    .缺陷代號 = GetCoilBugAssey.DEF02
                End If
                .程度 = EachItemTemp.Item("QDE13")
                Select Case EachItem.Item("QDE09")
                    Case "1"
                        .分佈 = "內"
                    Case "2"
                        .分佈 = "中"
                    Case "3"
                        .分佈 = "外"
                    Case "4"
                        .分佈 = "雙"
                    Case Else
                        .分佈 = EachItem.Item("QDE09")
                End Select
                .直起 = EachItem.Item("QDE07")
                .直終 = EachItem.Item("QDE08")
                .橫起 = EachItem.Item("QDE10")
                .橫終 = EachItem.Item("QDE11")
                Select Case CType(EachItem.Item("QDE12"), String)
                    Case "1"
                        .正反 = "正面"
                    Case "2"
                        .正反 = "反面"
                    Case "3"
                        .正反 = "雙面"
                    Case Else
                        .正反 = CType(EachItem.Item("QDE12"), String)
                End Select
                .密度 = CType(EachItem.Item("QDE14"), String)
                '.材質 = EachItem.Item("QCI06")
            End With
            ReturnValue.Rows.Add(ADDItem)

        Next

        '' 統計
        'Dim FindLotsNumbersQryIn As String = (From A In SQLString.Replace("AND", "~").Replace("Order", "~").Replace("UNION", "~").Split("~") Where A.Trim.Contains("B.BLA11 IN") Select A).FirstOrDefault
        'If Not IsNothing(FindLotsNumbersQryIn) Then
        '    FindLotsNumbersQryIn = FindLotsNumbersQryIn.Replace("B.BLA11 IN", Nothing)
        '    Dim TotalBatchCoilCountQry As String = "Select Count(*) from " & (New CompanyORMDB.PPS100LB.PPSBLAPF).CDBFullAS400DBPath & " Where BLA15='  ' AND  BLA11 IN " & FindLotsNumbersQryIn
        '    Dim TotalBatchCoilCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, TotalBatchCoilCountQry).SelectQuery.Rows(0).Item(0)
        '    Dim ToProcessQry As String = "Select COUNT(*) from " & (New CompanyORMDB.PPS100LB.PPSBLAPF).CDBFullAS400DBPath & " Where  BLA15='  ' AND BLA11 IN " & FindLotsNumbersQryIn & " AND " & _
        '                                " BLA09 IN ( Select SHA01 from  " & (New CompanyORMDB.PPS100LB.PPSSHAPF).CDBFullAS400DBPath & "  WHERE SHA04=1 AND  SHA21<>0)"
        '    Dim ToProcessCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, ToProcessQry).SelectQuery.Rows(0).Item(0)
        '    Dim ADDItem As QualityControlDataSet.CoilDefectPurchaseSearchDataTable1Row = ReturnValue.NewRow
        '    With ADDItem
        '        .熱軋批次 = "鋼捲總數:" & TotalBatchCoilCount
        '        .鋼胚號碼 = "投入數:" & ToProcessCount
        '        .熱軋號碼 = "有缺陷數:" & NumberCount
        '    End With
        '    ReturnValue.Rows.Add(ADDItem)
        'End If
        Return ReturnValue

    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectPurchaseSearchDataTable1DataTable
        Dim ReturnValue As New QualityControlDataSet.CoilDefectPurchaseSearchDataTable1DataTable
        Dim ShowTitleInfoKey As DataRow = Nothing
        Dim ShowTitleInfoKeyGroupDatas As New List(Of DataRow)
        Dim NumberCount As Integer = 0
        Dim CoilBugAssey As List(Of CompanyORMDB.PPS100LB.PPSDEFPF) = CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        Dim SearchTemp As List(Of DataRow) = (From A In SearchBase(SQLString, DFAndMD30Range) Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        SearchTemp = FilterDefectMinNumber(SearchTemp, FilterDefectNumber)
        SearchTemp = FilterTotalVLength(SearchTemp, FilterMaxBugTotalVLength)
        Dim TraceLineDateValue As String = Nothing

        For Each EachItem As DataRow In SearchTemp
            Dim EachItemTemp As DataRow = EachItem
            Dim ADDItem As QualityControlDataSet.CoilDefectPurchaseSearchDataTable1Row = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01") OrElse ShowTitleInfoKey("熱軋批次") <> EachItem.Item("BLA11") OrElse ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("鋼種") <> EachItem.Item("QCI05") OrElse ShowTitleInfoKey("鋼胚產日") <> EachItem.Item("QCI02"))
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged OrElse TraceLineDateValue <> EachItem.Item("QDE04") Then
                    .追縱線別日期 = EachItem.Item("QDE04")
                End If
                TraceLineDateValue = EachItem.Item("QDE04")

                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                    ShowTitleInfoKeyGroupDatas.Clear()
                    ShowTitleInfoKeyGroupDatas = (From A In SearchTemp Where A.Item("BLA01") = EachItemTemp.Item("BLA01") And A.Item("BLA11") = EachItemTemp.Item("BLA11") And A.Item("BLA07") = EachItemTemp.Item("BLA07") And A.Item("BLA09") = EachItemTemp.Item("BLA09") And A.Item("QCI05") = EachItemTemp.Item("QCI05") And A.Item("QCI02") = EachItemTemp.Item("QCI02") And A.Item("QCI06") = EachItemTemp.Item("QCI06") Select A).ToList
                    .序號 = NumberCount
                    .熱軋號碼 = EachItem.Item("BLA01")
                    .熱軋批次 = EachItem.Item("BLA11")
                    .鋼胚號碼 = EachItem.Item("BLA07")
                    .鋼捲號碼 = EachItem.Item("BLA09")
                    .鋼種 = EachItem.Item("QCI05")
                    .材質 = EachItem.Item("QCI06")
                    .鋼胚產日 = EachItem.Item("QCI02")
                    .DF = IIf(CType(EachItem.Item("QCI05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                    .MD30 = EachItem.Item("MD30")
                    .C = EachItem.Item("QCI07")
                    .SI = EachItem.Item("QCI08")
                    .MN = EachItem.Item("QCI09")
                    .P = EachItem.Item("QCI10")
                    .S = EachItem.Item("QCI11")
                    .CR = EachItem.Item("QCI12")
                    .NI = EachItem.Item("QCI13")
                    .CU = EachItem.Item("QCI14")
                    .MO = EachItem.Item("QCI15")
                    .CO = EachItem.Item("QCI16")
                    .AL = EachItem.Item("QCI17")
                    .SN = EachItem.Item("QCI18")
                    .PB = EachItem.Item("QCI19")
                    .TI = EachItem.Item("QCI20")
                    .NB = EachItem.Item("QCI21")
                    .V = EachItem.Item("QCI22")
                    .W = EachItem.Item("QCI23")
                    .O2 = EachItem.Item("QCI24")
                    .N2 = EachItem.Item("QCI25")
                    .H2 = EachItem.Item("QCI26")
                    .B = EachItem.Item("QCI27")
                    .Ca = EachItem.Item("QCI28") / 100
                    .Mg = EachItem.Item("QCI29") / 100
                    .Fe = EachItem.Item("QCI30")
                    ShowTitleInfoKey = ADDItem
                End If
                '缺陷代碼38,138,238同歸一類缺陷次數累計
                Dim BugCode As Integer = EachItemTemp.Item("QDE05")
                If {38, 138, 238}.Contains(BugCode) Then
                    .缺陷次數 = (From A In ShowTitleInfoKeyGroupDatas Where {38, 138, 238}.Contains(CType(A.Item("QDE05"), Integer)) Select A).Count
                Else
                    .缺陷次數 = (From A In ShowTitleInfoKeyGroupDatas Where CType(A.Item("QDE05"), Integer) = BugCode Select A).Count
                End If
                .追蹤線別 = EachItem.Item("QDE01")
                .厚度 = EachItem.Item("BLA03")
                Dim GetCoilBugAssey As CompanyORMDB.PPS100LB.PPSDEFPF = (From A In CoilBugAssey Where A.DEF01 = CType(EachItemTemp.Item("QDE05"), String) Select A).FirstOrDefault
                .缺陷代號 = EachItemTemp.Item("QDE05")
                If IsNothing(GetCoilBugAssey) Then
                    .缺陷名稱 = EachItemTemp.Item("QDE05")
                Else
                    .缺陷名稱 = GetCoilBugAssey.DEF02
                End If
                .程度 = EachItemTemp.Item("QDE13")
                Select Case EachItem.Item("QDE09")
                    Case "1"
                        .分佈 = "內"
                    Case "2"
                        .分佈 = "中"
                    Case "3"
                        .分佈 = "外"
                    Case "4"
                        .分佈 = "雙"
                    Case Else
                        .分佈 = EachItem.Item("QDE09")
                End Select
                .直起 = EachItem.Item("QDE07")
                .直終 = EachItem.Item("QDE08")
                .橫起 = EachItem.Item("QDE10")
                .橫終 = EachItem.Item("QDE11")
                Select Case CType(EachItem.Item("QDE12"), String)
                    Case "1"
                        .正反 = "正面"
                    Case "2"
                        .正反 = "反面"
                    Case "3"
                        .正反 = "雙面"
                    Case Else
                        .正反 = CType(EachItem.Item("QDE12"), String)
                End Select
                .密度 = CType(EachItem.Item("QDE14"), String)
                '.材質 = EachItem.Item("QCI06")
            End With
            ReturnValue.Rows.Add(ADDItem)

        Next

        ' 統計
        Dim FindLotsNumbersQryIn As String = (From A In SQLString.Replace("AND", "~").Replace("Order", "~").Replace("UNION", "~").Split("~") Where A.Trim.Contains("B.BLA11 IN") Select A).FirstOrDefault
        If Not IsNothing(FindLotsNumbersQryIn) Then
            FindLotsNumbersQryIn = FindLotsNumbersQryIn.Replace("B.BLA11 IN", Nothing)
            Dim TotalBatchCoilCountQry As String = "Select Count(*) from " & (New CompanyORMDB.PPS100LB.PPSBLAPF).CDBFullAS400DBPath & " Where BLA15='  ' AND  BLA11 IN " & FindLotsNumbersQryIn
            Dim TotalBatchCoilCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, TotalBatchCoilCountQry).SelectQuery.Rows(0).Item(0)
            Dim ToProcessQry As String = "Select COUNT(*) from " & (New CompanyORMDB.PPS100LB.PPSBLAPF).CDBFullAS400DBPath & " Where  BLA15='  ' AND BLA11 IN " & FindLotsNumbersQryIn & " AND " & _
                                        " BLA09 IN ( Select SHA01 from  " & (New CompanyORMDB.PPS100LB.PPSSHAPF).CDBFullAS400DBPath & "  WHERE SHA04=1 AND  SHA21<>0)"
            Dim ToProcessCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, ToProcessQry).SelectQuery.Rows(0).Item(0)
            Dim ADDItem As QualityControlDataSet.CoilDefectPurchaseSearchDataTable1Row = ReturnValue.NewRow
            With ADDItem
                .熱軋批次 = "鋼捲總數:" & TotalBatchCoilCount
                .鋼胚號碼 = "投入數:" & ToProcessCount
                .熱軋號碼 = "有缺陷數:" & NumberCount
            End With
            ReturnValue.Rows.Add(ADDItem)
        End If
        Return ReturnValue

    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectPurchaseSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.CoilDefectPurchaseSearchDataTableDataTable
        Dim ShowTitleInfoKey As QualityControlDataSet.CoilDefectPurchaseSearchDataTableRow = Nothing
        Dim NumberCount As Integer = 0
        Dim SearchTemp As List(Of DataRow) = (From A In SearchBase(SQLString, DFAndMD30Range) Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        SearchTemp = FilterDefectMinNumber(SearchTemp, FilterDefectNumber)
        SearchTemp = FilterTotalVLength(SearchTemp, FilterMaxBugTotalVLength)

        For Each EachItem As DataRow In SearchTemp
            Dim ADDItem As QualityControlDataSet.CoilDefectPurchaseSearchDataTableRow = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01"))
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                    .序號 = NumberCount
                    .鋼胚號碼 = EachItem.Item("BLA07")
                    .鋼捲號碼 = EachItem.Item("BLA09")
                    .熱軋號碼 = EachItem.Item("BLA01")
                    ShowTitleInfoKey = ADDItem
                End If
                .日期 = EachItem.Item("QCI02")
                .DF值 = IIf(CType(EachItem.Item("QCI05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .鋼種 = EachItem.Item("QCI05")
                .材質 = EachItem.Item("QCI06")
                .缺陷代碼 = EachItem.Item("QDE05")
                .啟始長度 = EachItem.Item("QDE07")
                .終止長度 = EachItem.Item("QDE08")
                Select Case CType(EachItem.Item("QDE12"), String)
                    Case "1"
                        .缺陷面 = "正面"
                    Case "2"
                        .缺陷面 = "反面"
                    Case "3"
                        .缺陷面 = "雙面"
                    Case Else
                        .缺陷面 = CType(EachItem.Item("QDE12"), String)
                End Select
                .缺陷程度 = EachItem.Item("QDE13")
                Select Case CType(EachItem.Item("QDE14"), String)
                    Case "1"
                        .表面狀況 = "散"
                    Case "2"
                        .表面狀況 = "斷"
                    Case "3"
                        .表面狀況 = "密"
                    Case Else
                        .表面狀況 = CType(EachItem.Item("QDE14"), String)
                End Select
                .綜合程度 = EachItem.Item("QDE17")
            End With
            ReturnValue.Rows.Add(ADDItem)

        Next
        Return ReturnValue
    End Function

    Private Function FilterDefectMinNumber(ByVal SourceData As List(Of DataRow), ByVal SetMinNumber As Integer) As List(Of DataRow)
        If SetMinNumber <= 1 Then
            Return SourceData
        End If
        Dim ReturnValue As New List(Of DataRow)
        Dim DefectCodes As List(Of Integer) = (From A In SourceData Select CType(A.Item("QDE05"), Integer)).Distinct.ToList
        Dim KeyStrings As List(Of String) = (From A In SourceData Select CType(A.Item("BLA01"), String) & CType(A.Item("BLA11"), String) & CType(A.Item("BLA07"), String) & CType(A.Item("BLA09"), String) & CType(A.Item("QCI05"), String) & CType(A.Item("QCI02"), String) Distinct).ToList

        Dim KeyGroupDatas As List(Of DataRow)
        For Each EachItem As String In KeyStrings
            Dim EachItemTemp As String = EachItem
            KeyGroupDatas = (From A In SourceData Where A.Item("BLA01") & A.Item("BLA11") & A.Item("BLA07") & A.Item("BLA09") & CType(A.Item("QCI05"), String) & A.Item("QCI02") = EachItemTemp Select A).ToList
            Dim IsAllDefectNumberBiggerThenSetMinNumber As Boolean = True
            For Each EachCode As Integer In DefectCodes
                Dim EachCodeTemp As Integer = EachCode
                '使用所有缺陷為AND的條件
                'IsAllDefectNumberBiggerThenSetMinNumber = IsAllDefectNumberBiggerThenSetMinNumber And (From A In KeyGroupDatas Where CType(A.Item("QDE05"), Integer) = EachCode Select A).Count >= SetMinNumber
                'If IsAllDefectNumberBiggerThenSetMinNumber = False Then
                '    Exit For
                'End If
                '使用所有缺陷為OR的條件 並且 缺陷代碼138,238歸入38計算
                If EachCodeTemp = 138 OrElse EachCodeTemp = 238 Then
                    EachCodeTemp = 38
                End If
                If EachCodeTemp = 38 Then
                    IsAllDefectNumberBiggerThenSetMinNumber = (From A In KeyGroupDatas Where {38, 138, 238}.Contains(CType(A.Item("QDE05"), Integer)) Select A).Count >= SetMinNumber
                Else
                    IsAllDefectNumberBiggerThenSetMinNumber = (From A In KeyGroupDatas Where CType(A.Item("QDE05"), Integer) = EachCodeTemp Select A).Count >= SetMinNumber
                End If
                If IsAllDefectNumberBiggerThenSetMinNumber = True Then
                    Exit For
                End If
            Next
            If IsAllDefectNumberBiggerThenSetMinNumber Then
                ReturnValue.AddRange(KeyGroupDatas)
            End If
        Next
        Return ReturnValue
    End Function

#End Region


    Private Function FilterTotalVLength(ByVal SourceData As List(Of DataRow), ByVal SetMaxTotalVLength As Integer) As List(Of DataRow)
        If SetMaxTotalVLength < 0 Then
            Return SourceData
        End If
        Dim ReturnValue As New List(Of DataRow)
        For Each EachCoilNumber As String In (From A In SourceData Select CType(A.Item("BLA09"), String)).Distinct
            Dim EachCoilNumberTemp As String = EachCoilNumber
            If (From A In SourceData Where CType(A.Item("BLA09"), String) = EachCoilNumberTemp Select CType(A.Item("QDE08") - A.Item("QDE07"), Integer)).Sum >= SetMaxTotalVLength Then
                ReturnValue.AddRange((From A In SourceData Where CType(A.Item("BLA09"), String) = EachCoilNumberTemp Select A).ToList)
            End If
        Next
        Return ReturnValue
    End Function

    Private Function SearchBase(ByVal SQLString As String, ByVal DFAndMD30Range As String) As List(Of DataRow)
        Dim DFAndMD30s As List(Of Single) = (From A In DFAndMD30Range.Split(",") Select CType(A, Single)).ToList
        Dim QryString As String = SQLString
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        If DFAndMD30s(0) <> -999 OrElse DFAndMD30s(1) <> 999 Then
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCI05"), String).Substring(0, 1) = "2" And CType(A.Item("DF_2"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_2"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCI05"), String).Substring(0, 1) = "3" Select A).ToList
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCI05"), String).Substring(0, 1) = "3" And CType(A.Item("DF_3"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_3"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCI05"), String).Substring(0, 1) = "2" Select A).ToList
        End If
        If DFAndMD30s(2) <> -999 OrElse DFAndMD30s(3) <> 999 Then
            AdapterResult = (From A In AdapterResult Where CType(A.Item("MD30"), Single) >= DFAndMD30s(2) And CType(A.Item("MD30"), Single) <= DFAndMD30s(3) Select A).ToList
        End If
        Return AdapterResult
    End Function



#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

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
#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' 控制項Where條件產生器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property ControlWhereMaker() As String
        Get
            If cbIsBuyWiteCoil.Checked Then '白皮之資料來源不同
                Return ControlWhereMakerForWiteCoil
            End If

            Dim ReturnValue As String = ""

            Select Case True
                Case ddlOutFormat.SelectedValue = "Format2" '格式2,輸出格式Join 排程資料
                    ReturnValue = "Select A.*,B.*,C.* " & _
                                                ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                                                ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                                                ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30" & _
                                                ",E.SHA08,E.SHA09,E.SHA22,E.SHA23,E.SHA21,E.SHA24,E.SHA25" & _
                                                " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C,@#PPS100LB.PPSSHAPF E " & _
                                                " WHERE (A.QCI01 = LEFT(B.BLA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BLA11 And B.BLA09 = C.QDE02)" & _
                                                " AND B.BLA08<=C.QDE04 AND B.BLA15='  ' " & _
                                                " AND C.QDE02=E.SHA01 AND C.QDE03=E.SHA02 "

                Case Not CheckBox3.Checked  '預設格式
                    ReturnValue = "Select A.*,B.*,C.* " & _
                                                ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                                                ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                                                ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30" & _
                                                " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C " & _
                                                " WHERE (A.QCI01 = LEFT(B.BLA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BLA11 And B.BLA09 = C.QDE02)" & _
                                                " AND B.BLA08<=C.QDE04 AND B.BLA15='  ' "

                Case CheckBox3.Checked  '格式1
                    ReturnValue = "Select A.*,B.*,C.* " & _
                            ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                            ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                            ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30 , D.QDS30 " & _
                            " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C  LEFT JOIN @#PPS100LB.PPSQDSPF D ON C.QDE01=D.QDS01 AND C.QDE02=D.QDS02 AND C.QDE03=D.QDS03 AND C.QDE04=D.QDS04 " & _
                            " WHERE (A.QCI01 = LEFT(B.BLA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BLA11 And B.BLA09 = C.QDE02)" & _
                            " AND B.BLA08<=C.QDE04 AND B.BLA15='  ' "
            End Select


            Dim WhereValue As String = Nothing
            If Not String.IsNullOrEmpty(tbSLABNumber.Text) AndAlso tbSLABNumber.Text.Trim.Length > 0 Then
                WhereValue &= " AND B.BLA07 LIKE '" & tbSLABNumber.Text.Trim.Replace("*", "%") & "' "
            End If

            If CheckBox1.Checked Then
                Dim StartDate As Date = tbStartDate.Text
                Dim EndDate As Date = tbEndDate.Text
                WhereValue &= " AND A.QCI02>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND A.QCI02<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If CheckBox2.Checked Then
                Dim StartDate As Date = tbProLineStartDate.Text
                Dim EndDate As Date = tbProLineEndDate.Text
                WhereValue &= " AND C.QDE04>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND C.QDE04<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
                tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCI05) || A.QCI06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbBugCode.Text) Then
                tbBugCode.Text = tbBugCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugCode.Text.Trim.Length > 0, " AND C.QDE05  IN (" & tbBugCode.Text & ")", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbProuctLine.Text) Then
                tbProuctLine.Text = tbProuctLine.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbProuctLine.Text.Trim.Length > 0, " AND C.QDE01 IN ('" & tbProuctLine.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbTotalEvent.Text) Then
                tbTotalEvent.Text = tbTotalEvent.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbTotalEvent.Text.Trim.Length > 0, " AND C.QDE17 IN ('" & tbTotalEvent.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbLotsNumbers.Text) Then
                tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
                If tbLotsNumbers.Text.Contains("~") Then
                    WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 >= '" & tbLotsNumbers.Text.Split("~")(0).Trim & "' AND B.BLA11 <= '" & tbLotsNumbers.Text.Split("~")(1).Trim & "'", Nothing)
                Else
                    WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
                End If
            End If

            'If Not String.IsNullOrEmpty(tbBugWidth.Text) Then
            '    tbBugWidth.Text = tbBugWidth.Text.Replace("'", Nothing)
            '    WhereValue &= IIf(tbBugWidth.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1) " & RadioButtonList1.SelectedValue & CType(tbBugWidth.Text, Integer), Nothing)
            'End If
            If Not String.IsNullOrEmpty(tbBugWidthS.Text) Then
                tbBugWidthS.Text = tbBugWidthS.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugWidthS.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1)  >=" & CType(tbBugWidthS.Text, Integer), Nothing)
            End If
            If Not String.IsNullOrEmpty(tbBugWidthE.Text) Then
                tbBugWidthE.Text = tbBugWidthE.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugWidthE.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1)  <=" & CType(tbBugWidthE.Text, Integer), Nothing)
            End If

            'If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
            '    WhereValue = WhereValue.ToUpper.Trim
            '    If WhereValue.Substring(0, 3) = "AND" Then
            '        WhereValue = WhereValue.Substring(3, WhereValue.Length - 3)
            '    End If
            'End If
            If Not String.IsNullOrEmpty(Me.tbFrontBackCode.Text) Then
                tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbFrontBackCode.Text.Trim.Length > 0, " AND C.QDE12 IN ('" & tbFrontBackCode.Text.Replace(",", "','") & "')", Nothing)
            End If

            For Each EachItem As ListItem In lbElements.Items
                Dim Datas() As String = EachItem.Value.Split(":")
                WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
                If EachItem.Text.ToUpper = "CA" OrElse EachItem.Text.ToUpper = "MG" Then
                    WhereValue &= " QCA" & Datas(0) & "/100 >= " & Datas(1) & " AND QCA" & Datas(0) & "/100 <= " & Datas(2)
                Else
                    WhereValue &= " QCA" & Datas(0) & " >= " & Datas(1) & " AND QCA" & Datas(0) & " <= " & Datas(2)
                End If

            Next

            If Not String.IsNullOrEmpty(Me.tbDefective.Text) Then
                tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
                WhereValue &= IIf(tbDefective.Text.Trim.Length > 0, " C.QDE14 IN ('" & tbDefective.Text.Replace(",", "','") & "')", Nothing)
            End If

            If CheckBox3.Checked And (ddlOutFormat.SelectedValue <> "Format2") Then
                Dim DeleteLeng As Single = tbQDS30DelLeng.Text
                WhereValue &= " AND NOT D.QDS30 IS NULL AND ( (C.QDE08-C.QDE07)>" & DeleteLeng & " OR NOT ( (C.QDE07<" & DeleteLeng & " AND C.QDE08<" & DeleteLeng & ") OR (C.QDE07>(D.QDS30-" & DeleteLeng & ") AND C.QDE08>(D.QDS30-" & DeleteLeng & ")) ) )"
            End If

            If Not String.IsNullOrEmpty(tbStartWidth.Text) AndAlso Not String.IsNullOrEmpty(tbEndWidth.Text) AndAlso (tbStartWidth.Text.Trim <> "0" OrElse tbEndWidth.Text.Trim <> "9999") Then
                Dim StartWdith As Integer = CType(tbStartWidth.Text, Integer)
                Dim EndWidth As Integer = CType(tbEndWidth.Text, Integer)
                Dim SubQry As String = "Select SHA01 || SHA02 From @#PPS100LB.PPSSHAPF  Where SHA34>=" & StartWdith & " AND SHA34<=" & EndWidth
                WhereValue &= " AND  (C.QDE02 || C.QDE03)  IN (" & SubQry & ")"
            End If

            If ddlOutFormat.SelectedValue = "Format2" AndAlso Not String.IsNullOrEmpty(tbSchedualLines.Text) AndAlso tbSchedualLines.Text.Trim.Length > 0 Then
                WhereValue &= " AND  E.SHA08  IN ('" & tbSchedualLines.Text.Trim.Replace(",", "','") & "')"
            End If

            hfSortFieldsList.Value = Nothing
            For Each EachItem As ListItem In lbSort.Items
                hfSortFieldsList.Value &= IIf(String.IsNullOrEmpty(hfSortFieldsList.Value), Nothing, ",")
                hfSortFieldsList.Value &= EachItem.Value.Trim
            Next
            Return ReturnValue & WhereValue
        End Get
    End Property

    Private ReadOnly Property ControlWhereMakerForWiteCoil() As String
        Get
            Dim ReturnValue As String = ""

            Select Case True
                Case ddlOutFormat.SelectedValue = "Format2" '格式2,輸出格式Join 排程資料
                    ReturnValue = "Select A.*,B.BWA01 BLA01,B.BWA03 BLA03,B.BWA11 BLA11,B.BWA07 BLA07,B.BWA09 BLA09,C.* " & _
                                                ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                                                ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                                                ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30" & _
                                                ",E.SHA08,E.SHA09,E.SHA22,E.SHA23,E.SHA21,E.SHA24,E.SHA25" & _
                                                " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBWAPF B,@#PPS100LB.PPSQDEPF C,@#PPS100LB.PPSSHAPF E " & _
                                                " WHERE (A.QCI01 = LEFT(B.BWA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BWA11 And B.BWA09 = C.QDE02)" & _
                                                " AND B.BWA08<=C.QDE04 AND B.BWA15='  ' " & _
                                                " AND C.QDE02=E.SHA01 AND C.QDE03=E.SHA02 "

                Case Not CheckBox3.Checked  '預設格式
                    ReturnValue = "Select A.*,B.BWA01 BLA01,B.BWA03 BLA03,B.BWA11 BLA11,B.BWA07 BLA07,B.BWA09 BLA09,C.* " & _
                                                ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                                                ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                                                ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30" & _
                                                " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBWAPF B,@#PPS100LB.PPSQDEPF C " & _
                                                " WHERE (A.QCI01 = LEFT(B.BWA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BWA11 And B.BWA09 = C.QDE02)" & _
                                                " AND B.BWA08<=C.QDE04 AND B.BWA15='  ' "

                Case CheckBox3.Checked  '格式1
                    ReturnValue = "Select A.*,B.BWA01 BLA01,B.BWA03 BLA03,B.BWA11 BLA11,B.BWA07 BLA07,B.BWA09 BLA09,C.* " & _
                            ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                            ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                            ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30 , D.QDS30 " & _
                            " From  @#PPS100LB.PPSQCIPF A,@#PPS100LB.PPSBWAPF B,@#PPS100LB.PPSQDEPF C  LEFT JOIN @#PPS100LB.PPSQDSPF D ON C.QDE01=D.QDS01 AND C.QDE02=D.QDS02 AND C.QDE03=D.QDS03 AND C.QDE04=D.QDS04 " & _
                            " WHERE (A.QCI01 = LEFT(B.BWA07,LENGTH(TRIM(A.QCI01))) AND A.QCI40 =B.BWA11 And B.BWA09 = C.QDE02)" & _
                            " AND B.BWA08<=C.QDE04 AND B.BWA15='  ' "
            End Select


            Dim WhereValue As String = Nothing
            If Not String.IsNullOrEmpty(tbSLABNumber.Text) AndAlso tbSLABNumber.Text.Trim.Length > 0 Then
                WhereValue &= " AND B.BWA07 LIKE '" & tbSLABNumber.Text.Trim.Replace("*", "%") & "' "
            End If

            If CheckBox1.Checked Then
                Dim StartDate As Date = tbStartDate.Text
                Dim EndDate As Date = tbEndDate.Text
                WhereValue &= " AND A.QCI02>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND A.QCI02<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If CheckBox2.Checked Then
                Dim StartDate As Date = tbProLineStartDate.Text
                Dim EndDate As Date = tbProLineEndDate.Text
                WhereValue &= " AND C.QDE04>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND C.QDE04<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
                tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCI05) || A.QCI06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbBugCode.Text) Then
                tbBugCode.Text = tbBugCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugCode.Text.Trim.Length > 0, " AND C.QDE05  IN (" & tbBugCode.Text & ")", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbProuctLine.Text) Then
                tbProuctLine.Text = tbProuctLine.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbProuctLine.Text.Trim.Length > 0, " AND C.QDE01 IN ('" & tbProuctLine.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbTotalEvent.Text) Then
                tbTotalEvent.Text = tbTotalEvent.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbTotalEvent.Text.Trim.Length > 0, " AND C.QDE17 IN ('" & tbTotalEvent.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbLotsNumbers.Text) Then
                tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
                If tbLotsNumbers.Text.Contains("~") Then
                    WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BWA11 >= '" & tbLotsNumbers.Text.Split("~")(0).Trim & "' AND B.BWA11 <= '" & tbLotsNumbers.Text.Split("~")(1).Trim & "'", Nothing)
                Else
                    WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BWA11 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
                End If
            End If

            'If Not String.IsNullOrEmpty(tbBugWidth.Text) Then
            '    tbBugWidth.Text = tbBugWidth.Text.Replace("'", Nothing)
            '    WhereValue &= IIf(tbBugWidth.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1) " & RadioButtonList1.SelectedValue & CType(tbBugWidth.Text, Integer), Nothing)
            'End If
            If Not String.IsNullOrEmpty(tbBugWidthS.Text) Then
                tbBugWidthS.Text = tbBugWidthS.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugWidthS.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1)  >=" & CType(tbBugWidthS.Text, Integer), Nothing)
            End If
            If Not String.IsNullOrEmpty(tbBugWidthE.Text) Then
                tbBugWidthE.Text = tbBugWidthE.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugWidthE.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1)  <=" & CType(tbBugWidthE.Text, Integer), Nothing)
            End If

            'If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
            '    WhereValue = WhereValue.ToUpper.Trim
            '    If WhereValue.Substring(0, 3) = "AND" Then
            '        WhereValue = WhereValue.Substring(3, WhereValue.Length - 3)
            '    End If
            'End If
            If Not String.IsNullOrEmpty(Me.tbFrontBackCode.Text) Then
                tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbFrontBackCode.Text.Trim.Length > 0, " AND C.QDE12 IN ('" & tbFrontBackCode.Text.Replace(",", "','") & "')", Nothing)
            End If

            For Each EachItem As ListItem In lbElements.Items
                Dim Datas() As String = EachItem.Value.Split(":")
                WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
                If EachItem.Text.ToUpper = "CA" OrElse EachItem.Text.ToUpper = "MG" Then
                    WhereValue &= " QCA" & Datas(0) & "/100 >= " & Datas(1) & " AND QCA" & Datas(0) & "/100 <= " & Datas(2)
                Else
                    WhereValue &= " QCA" & Datas(0) & " >= " & Datas(1) & " AND QCA" & Datas(0) & " <= " & Datas(2)
                End If

            Next

            If Not String.IsNullOrEmpty(Me.tbDefective.Text) Then
                tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
                WhereValue &= IIf(tbDefective.Text.Trim.Length > 0, " C.QDE14 IN ('" & tbDefective.Text.Replace(",", "','") & "')", Nothing)
            End If

            If CheckBox3.Checked And (ddlOutFormat.SelectedValue <> "Format2") Then
                Dim DeleteLeng As Single = tbQDS30DelLeng.Text
                WhereValue &= " AND NOT D.QDS30 IS NULL AND ( (C.QDE08-C.QDE07)>" & DeleteLeng & " OR NOT ( (C.QDE07<" & DeleteLeng & " AND C.QDE08<" & DeleteLeng & ") OR (C.QDE07>(D.QDS30-" & DeleteLeng & ") AND C.QDE08>(D.QDS30-" & DeleteLeng & ")) ) )"
            End If

            If Not String.IsNullOrEmpty(tbStartWidth.Text) AndAlso Not String.IsNullOrEmpty(tbEndWidth.Text) AndAlso (tbStartWidth.Text.Trim <> "0" OrElse tbEndWidth.Text.Trim <> "9999") Then
                Dim StartWdith As Integer = CType(tbStartWidth.Text, Integer)
                Dim EndWidth As Integer = CType(tbEndWidth.Text, Integer)
                Dim SubQry As String = "Select SHA01 || SHA02 From @#PPS100LB.PPSSHAPF  Where SHA34>=" & StartWdith & " AND SHA34<=" & EndWidth
                WhereValue &= " AND  (C.QDE02 || C.QDE03)  IN (" & SubQry & ")"
            End If

            If ddlOutFormat.SelectedValue = "Format2" AndAlso Not String.IsNullOrEmpty(tbSchedualLines.Text) AndAlso tbSchedualLines.Text.Trim.Length > 0 Then
                WhereValue &= " AND  E.SHA08  IN ('" & tbSchedualLines.Text.Trim.Replace(",", "','") & "')"
            End If

            hfSortFieldsList.Value = Nothing
            For Each EachItem As ListItem In lbSort.Items
                hfSortFieldsList.Value &= IIf(String.IsNullOrEmpty(hfSortFieldsList.Value), Nothing, ",")
                hfSortFieldsList.Value &= EachItem.Value.Trim
            Next
            Return ReturnValue & WhereValue
        End Get
    End Property
#End Region
#Region "設定查詢條件至控制項 屬性:SetSelectArgToControl"
    Private Sub SetSelectArgToControl()
        Me.hfSQLString.Value = ControlWhereMaker
        Me.hfDFAndMD30Range.Value = (Me.txDF1.Text & "," & Me.txDF2.Text & "," & Me.txMD301.Text & "," & Me.txMD302.Text).Replace("'", Nothing)
        Me.hfMinDefectFilterNumber.Value = IIf(CheckBox4.Checked, Val(tbFrontBackCodeCount.Text), -1)
        Me.hfMaxBugTotalVLength.Value = IIf(CheckBox5.Checked, tbButTotalMaxVLeng.Text.Trim, -1)
    End Sub
#End Region
#Region "重整顯示排序按鈕啟用 函式:RefreshSortButtonEnable"
    ''' <summary>
    ''' 重整顯示排序按鈕啟用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshSortButtonEnable()
        Me.btnSortUp.Enabled = False
        Me.btnSortDown.Enabled = False
        If lbSort.Items.Count = 0 OrElse lbSort.SelectedIndex < 0 Then
            Exit Sub
        End If
        Try
            Select Case True
                Case lbSort.SelectedItem Is lbSort.Items(0)
                    Me.btnSortDown.Enabled = True
                Case lbSort.SelectedItem Is lbSort.Items(lbSort.Items.Count - 1)
                    Me.btnSortUp.Enabled = True
                Case Else
                    Me.btnSortUp.Enabled = True
                    Me.btnSortDown.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack OrElse String.IsNullOrEmpty(Me.tbStartDate.Text) OrElse String.IsNullOrEmpty(Me.tbEndDate.Text) Then
            Me.tbStartDate.Text = New Date(Now.Year, 1, 1)
            Me.tbEndDate.Text = Now.Date
            Me.tbProLineStartDate.Text = Me.tbStartDate.Text
            Me.tbProLineEndDate.Text = Me.tbEndDate.Text
        End If
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting, odsSearchResult1.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        SetSelectArgToControl()
        Select Case True
            Case ddlOutFormat.SelectedValue = "Format0"
                Me.GridView1.DataBind()
                Me.MultiView1.SetActiveView(Me.View1)
            Case ddlOutFormat.SelectedValue = "Format1"
                Me.GridView2.DataBind()
                Me.MultiView1.SetActiveView(Me.View2)
            Case ddlOutFormat.SelectedValue = "Format2"
                Me.GridView3.DataBind()
                Me.MultiView1.SetActiveView(Me.View3)
        End Select
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Me.tbSteelKind.Text = Nothing
        Me.tbBugCode.Text = Nothing
        Me.tbProuctLine.Text = Nothing
        Me.txDF1.Text = -999
        Me.txDF2.Text = 999
        Me.txMD301.Text = -999
        Me.txMD302.Text = 999
        Me.tbStartDate.Text = New Date(Now.Year, 1, 1)
        Me.tbEndDate.Text = Now.Date
        Me.tbTotalEvent.Text = Nothing
        Me.tbLotsNumbers.Text = Nothing
        'Me.tbBugWidth.Text = Nothing
        Me.tbBugWidthS.Text = 0
        Me.tbBugWidthE.Text = 9999

        Me.tbFrontBackCode.Text = Nothing
        'Me.tbSteelBugCodes.Text = Nothing
        Me.lbElements.Items.Clear()
        Me.tbDefective.Text = Nothing
    End Sub

    Private Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDownExcel.Click
        Me.IsUserAlreadyPutSearch = True
        SetSelectArgToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Select Case True
            Case ddlOutFormat.SelectedValue = "Format0"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "外購鋼捲缺陷查詢" & Format(Now, "mmss") & ".xls")
            Case ddlOutFormat.SelectedValue = "Format1"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "外購鋼捲缺陷查詢" & Format(Now, "mmss") & ".xls")
            Case ddlOutFormat.SelectedValue = "Format2"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search2(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "外購鋼捲缺陷查詢" & Format(Now, "mmss") & ".xls")
        End Select
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Protected Sub ddlOutFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlOutFormat.SelectedIndexChanged
        Select Case True
            Case ddlOutFormat.SelectedValue = "Format0"
                Me.MultiView1.SetActiveView(Me.View1)
            Case ddlOutFormat.SelectedValue = "Format1"
                Me.MultiView1.SetActiveView(Me.View2)
        End Select
    End Sub

    Protected Sub btnBackSearch1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackSearch1.Click, btnBackSearch2.Click, btnBackSearch3.Click
        Me.MultiView1.SetActiveView(Me.SearchView)
    End Sub


    Protected Sub btnAddElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddElement.Click
        Try
            Dim AddItem As New ListItem
            AddItem.Text = DropDownList1.SelectedItem.Text & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & "~" & CType(tbElementEndValue.Text.Trim, Single).ToString
            AddItem.Value = DropDownList1.SelectedItem.Value & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            lbElements.Items.Add(AddItem)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDeleteElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteElement.Click
        If Not IsNothing(lbElements.SelectedItem) Then
            lbElements.Items.Remove(lbElements.SelectedItem)
        End If
    End Sub

    Private Sub lbSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSort.SelectedIndexChanged
        RefreshSortButtonEnable()
    End Sub

    Protected Sub btnSortUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSortUp.Click, btnSortDown.Click
        If IsNothing(lbSort.SelectedItem) Then
            Exit Sub
        End If
        Dim MoveToIndex As Integer = lbSort.SelectedIndex
        Dim InsertItem As ListItem = lbSort.SelectedItem
        lbSort.Items.Remove(lbSort.SelectedItem)
        If sender Is btnSortUp Then
            MoveToIndex -= 1
        Else
            MoveToIndex += 1
        End If
        MoveToIndex = IIf(MoveToIndex < 0, 0, MoveToIndex)
        lbSort.Items.Insert(MoveToIndex, InsertItem)
        RefreshSortButtonEnable()
    End Sub

End Class