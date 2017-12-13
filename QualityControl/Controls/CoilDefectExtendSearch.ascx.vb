﻿Partial Public Class CoilDefectExtendSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search2(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectExtendSearch2DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilDefectExtendSearch2DataTable
        End If
        Dim ReturnValue As New QualityControlDataSet.CoilDefectExtendSearch2DataTable
        Dim ShowTitleInfoKey As DataRow = Nothing
        Dim NumberCount As Integer = 0
        Dim CoilBugAssey As List(Of CompanyORMDB.PPS100LB.PPSDEFPF) = CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        Dim SearchTemp As List(Of DataRow) = (From A In SearchBase(SQLString, DFAndMD30Range) Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        SearchTemp = FilterDefectMinNumber(SearchTemp, FilterDefectNumber)
        SearchTemp = FilterTotalVLength(SearchTemp, FilterMaxBugTotalVLength)
        'Dim TraceLineDateValue As String = Nothing

        For Each EachItem As DataRow In SearchTemp
            Dim EachItemTemp As DataRow = EachItem
            Dim ADDItem As QualityControlDataSet.CoilDefectExtendSearch2Row = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01") OrElse ShowTitleInfoKey("熱軋批次") <> EachItem.Item("BLA11") OrElse ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("鋼種") <> EachItem.Item("QCA05") OrElse ShowTitleInfoKey("鋼胚產日") <> EachItem.Item("QCA02"))
                'If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged OrElse TraceLineDateValue <> EachItem.Item("QDE04") Then
                'End If
                'TraceLineDateValue = EachItem.Item("QDE04")
                .追縱線別日期 = EachItem.Item("SHA21")
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                End If
                .序號 = NumberCount
                .熱軋號碼 = EachItem.Item("BLA01")
                .熱軋批次 = EachItem.Item("BLA11")
                .鋼胚號碼 = EachItem.Item("BLA07")
                .鋼捲號碼 = EachItem.Item("BLA09")
                .鋼種 = EachItem.Item("QCA05")
                .材質 = EachItem.Item("QCA06")
                .鋼胚產日 = EachItem.Item("QCA02")
                .DF = IIf(CType(EachItem.Item("QCA05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .MD30 = EachItem.Item("MD30")
                .C = EachItem.Item("QCA07")
                .SI = EachItem.Item("QCA08")
                .MN = EachItem.Item("QCA09")
                .P = EachItem.Item("QCA10")
                .S = EachItem.Item("QCA11")
                .CR = EachItem.Item("QCA12")
                .NI = EachItem.Item("QCA13")
                .CU = EachItem.Item("QCA14")
                .MO = EachItem.Item("QCA15")
                .CO = EachItem.Item("QCA16")
                .AL = EachItem.Item("QCA17")
                .SN = EachItem.Item("QCA18")
                .PB = EachItem.Item("QCA19")
                .TI = EachItem.Item("QCA20")
                .NB = EachItem.Item("QCA21")
                .V = EachItem.Item("QCA22")
                .W = EachItem.Item("QCA23")
                .O2 = EachItem.Item("QCA24")
                .N2 = EachItem.Item("QCA25")
                .H2 = EachItem.Item("QCA26")
                .B = EachItem.Item("QCA27")
                .Ca = EachItem.Item("QCA28") / 100
                .Mg = EachItem.Item("QCA29") / 100
                .Fe = EachItem.Item("QCA30")
                ShowTitleInfoKey = ADDItem
                .追蹤線別 = EachItem.Item("SHA08")
                .班別 = EachItem.Item("SHA09")
                .進時間 = Format(EachItem.Item("SHA22"), "00") & ":" & Format(EachItem.Item("SHA23"), "00")
                .出時間 = Format(EachItem.Item("SHA24"), "00") & ":" & Format(EachItem.Item("SHA25"), "00")

                .厚度 = EachItem.Item("BLA03")
                Dim GetCoilBugAssey As CompanyORMDB.PPS100LB.PPSDEFPF = (From A In CoilBugAssey Where A.DEF01 = CType(EachItemTemp.Item("QDE05"), String) Select A).FirstOrDefault
                If IsNothing(GetCoilBugAssey) Then
                    .缺陷代號 = EachItemTemp.Item("QDE05")
                Else
                    .缺陷代號 = GetCoilBugAssey.DEF02
                End If
                .程度 = EachItemTemp.Item("QDE13")
                Select Case EachItem.Item("QDE09")
                    Case "0"
                        .分佈 = "全"
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
                If Not IsDBNull(EachItem.Item("T3")) Then
                    .澆鑄粉 = EachItem.Item("T3")
                End If
                If Not IsDBNull(EachItem.Item("T4")) Then
                    .分鋼槽塗覆 = EachItem.Item("T4")
                End If
                If Not IsDBNull(EachItem.Item("T5")) Then
                    .模液位控制 = EachItem.Item("T5")
                End If
                If Not IsDBNull(EachItem.Item("T6")) Then
                    .澆鑄管 = EachItem.Item("T6")
                End If
                If Not IsDBNull(EachItem.Item("T7")) Then
                    .澆鑄速度 = EachItem.Item("T7")
                End If
                If Not IsDBNull(EachItem.Item("T8")) Then
                    .氣罩 = EachItem.Item("T8")
                End If
                If Not IsDBNull(EachItem.Item("T9")) Then
                    .冷卻水量 = EachItem.Item("T9")
                End If
                If Not IsDBNull(EachItem.Item("T10")) Then
                    .攪拌時間 = EachItem.Item("T10")
                End If
                If Not IsDBNull(EachItem.Item("T11")) Then
                    .靜置時間 = EachItem.Item("T11")
                End If
                If Not IsDBNull(EachItem.Item("T12")) Then
                    .交接爐TUNDISH重量 = EachItem.Item("T12")
                End If
                If Not IsDBNull(EachItem.Item("T13")) Then
                    .攪拌狀況 = EachItem.Item("T13")
                End If
                If Not IsDBNull(EachItem.Item("T14")) Then
                    .渣流動性 = EachItem.Item("T14")
                End If
                If Not IsDBNull(EachItem.Item("T15")) Then
                    .攪拌強度 = EachItem.Item("T15")
                End If
                If Not IsDBNull(EachItem.Item("T16")) Then
                    .分鋼槽溫度1 = EachItem.Item("T16")
                End If
                If Not IsDBNull(EachItem.Item("T17")) Then
                    .分鋼槽溫度2 = EachItem.Item("T17")
                End If
                If Not IsDBNull(EachItem.Item("T18")) Then
                    .分鋼槽溫度3 = EachItem.Item("T18")
                End If
                If Not IsDBNull(EachItem.Item("T19")) Then
                    .吹氧次數 = EachItem.Item("T19")
                End If
                If Not IsDBNull(EachItem.Item("T20")) Then
                    .分鋼槽內容積 = EachItem.Item("T20")
                End If
                If Not IsDBNull(EachItem.Item("T21")) Then
                    .連鑄班別 = EachItem.Item("T21")
                End If
                If Not IsDBNull(EachItem.Item("T22")) Then
                    .輪班時間 = EachItem.Item("T22")
                End If
                If Not IsDBNull(EachItem.Item("T23")) Then
                    .澆鑄管品名 = EachItem.Item("T23")
                End If
                If Not IsDBNull(EachItem.Item("T24")) Then
                    .氣罩品名 = EachItem.Item("T24")
                End If
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
        '    Dim ADDItem As QualityControlDataSet.CoilDefectSearchDataTable1Row = ReturnValue.NewRow
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
    Public Function Search1(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectExtendSearch1DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilDefectExtendSearch1DataTable
        End If
        Dim ReturnValue As New QualityControlDataSet.CoilDefectExtendSearch1DataTable
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
            Dim ADDItem As QualityControlDataSet.CoilDefectExtendSearch1Row = ReturnValue.NewRow
            With ADDItem
                'Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01") OrElse ShowTitleInfoKey("熱軋批次") <> EachItem.Item("BLA11") OrElse ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("鋼種") <> EachItem.Item("QCA05") OrElse ShowTitleInfoKey("鋼胚產日") <> EachItem.Item("QCA02"))
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("BLA01") <> EachItem.Item("BLA01") OrElse ShowTitleInfoKey("BLA11") <> EachItem.Item("BLA11") OrElse ShowTitleInfoKey("BLA07") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("BLA09") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("QCA05") <> EachItem.Item("QCA05") OrElse ShowTitleInfoKey("QCA02") <> EachItem.Item("QCA02") OrElse ShowTitleInfoKey("QCA06") <> EachItem.Item("QCA06"))
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged OrElse TraceLineDateValue <> EachItem.Item("QDE04") Then
                    .追縱線別日期 = EachItem.Item("QDE04")
                End If
                TraceLineDateValue = EachItem.Item("QDE04")
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    'ShowTitleInfoKey = ADDItem
                    ShowTitleInfoKey = EachItemTemp
                    NumberCount += 1
                    ShowTitleInfoKeyGroupDatas.Clear()
                    ShowTitleInfoKeyGroupDatas = (From A In SearchTemp Where A.Item("BLA01") = EachItemTemp.Item("BLA01") And A.Item("BLA11") = EachItemTemp.Item("BLA11") And A.Item("BLA07") = EachItemTemp.Item("BLA07") And A.Item("BLA09") = EachItemTemp.Item("BLA09") And A.Item("QCA05") = EachItemTemp.Item("QCA05") And A.Item("QCA02") = EachItemTemp.Item("QCA02") And A.Item("QCA06") = EachItemTemp.Item("QCA06") Select A).ToList
                    .序號 = NumberCount
                    .熱軋號碼 = EachItem.Item("BLA01")
                    .熱軋批次 = EachItem.Item("BLA11")
                    .鋼胚號碼 = EachItem.Item("BLA07")
                    .鋼捲號碼 = EachItem.Item("BLA09")
                    .鋼種 = EachItem.Item("QCA05")
                    .材質 = EachItem.Item("QCA06")
                    .鋼胚產日 = EachItem.Item("QCA02")
                    .DF = IIf(CType(EachItem.Item("QCA05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                    .MD30 = EachItem.Item("MD30")
                    .C = EachItem.Item("QCA07")
                    .SI = EachItem.Item("QCA08")
                    .MN = EachItem.Item("QCA09")
                    .P = EachItem.Item("QCA10")
                    .S = EachItem.Item("QCA11")
                    .CR = EachItem.Item("QCA12")
                    .NI = EachItem.Item("QCA13")
                    .CU = EachItem.Item("QCA14")
                    .MO = EachItem.Item("QCA15")
                    .CO = EachItem.Item("QCA16")
                    .AL = EachItem.Item("QCA17")
                    .SN = EachItem.Item("QCA18")
                    .PB = EachItem.Item("QCA19")
                    .TI = EachItem.Item("QCA20")
                    .NB = EachItem.Item("QCA21")
                    .V = EachItem.Item("QCA22")
                    .W = EachItem.Item("QCA23")
                    .O2 = EachItem.Item("QCA24")
                    .N2 = EachItem.Item("QCA25")
                    .H2 = EachItem.Item("QCA26")
                    .B = EachItem.Item("QCA27")
                    .Ca = EachItem.Item("QCA28") / 100
                    .Mg = EachItem.Item("QCA29") / 100
                    .Fe = EachItem.Item("QCA30")
                    If Not IsDBNull(EachItem.Item("T3")) Then
                        .澆鑄粉 = EachItem.Item("T3")
                    End If
                    If Not IsDBNull(EachItem.Item("T4")) Then
                        .分鋼槽塗覆 = EachItem.Item("T4")
                    End If
                    If Not IsDBNull(EachItem.Item("T5")) Then
                        .模液位控制 = EachItem.Item("T5")
                    End If
                    If Not IsDBNull(EachItem.Item("T6")) Then
                        .澆鑄管 = EachItem.Item("T6")
                    End If
                    If Not IsDBNull(EachItem.Item("T7")) Then
                        .澆鑄速度 = EachItem.Item("T7")
                    End If
                    If Not IsDBNull(EachItem.Item("T8")) Then
                        .氣罩 = EachItem.Item("T8")
                    End If
                    If Not IsDBNull(EachItem.Item("T9")) Then
                        .冷卻水量 = EachItem.Item("T9")
                    End If
                    If Not IsDBNull(EachItem.Item("T10")) Then
                        .攪拌時間 = EachItem.Item("T10")
                    End If
                    If Not IsDBNull(EachItem.Item("T11")) Then
                        .靜置時間 = EachItem.Item("T11")
                    End If
                    If Not IsDBNull(EachItem.Item("T12")) Then
                        .交接爐TUNDISH重量 = EachItem.Item("T12")
                    End If
                    If Not IsDBNull(EachItem.Item("T13")) Then
                        .攪拌狀況 = EachItem.Item("T13")
                    End If
                    If Not IsDBNull(EachItem.Item("T14")) Then
                        .渣流動性 = EachItem.Item("T14")
                    End If
                    If Not IsDBNull(EachItem.Item("T15")) Then
                        .攪拌強度 = EachItem.Item("T15")
                    End If
                    If Not IsDBNull(EachItem.Item("T16")) Then
                        .分鋼槽溫度1 = EachItem.Item("T16")
                    End If
                    If Not IsDBNull(EachItem.Item("T17")) Then
                        .分鋼槽溫度2 = EachItem.Item("T17")
                    End If
                    If Not IsDBNull(EachItem.Item("T18")) Then
                        .分鋼槽溫度3 = EachItem.Item("T18")
                    End If
                    If Not IsDBNull(EachItem.Item("T19")) Then
                        .吹氧次數 = EachItem.Item("T19")
                    End If
                    If Not IsDBNull(EachItem.Item("T20")) Then
                        .分鋼槽內容積 = EachItem.Item("T20")
                    End If
                    If Not IsDBNull(EachItem.Item("T21")) Then
                        .連鑄班別 = EachItem.Item("T21")
                    End If
                    If Not IsDBNull(EachItem.Item("T22")) Then
                        .輪班時間 = EachItem.Item("T22")
                    End If
                    If Not IsDBNull(EachItem.Item("T23")) Then
                        .澆鑄管品名 = EachItem.Item("T23")
                    End If
                    If Not IsDBNull(EachItem.Item("T24")) Then
                        .氣罩品名 = EachItem.Item("T24")
                    End If
                    If Not IsDBNull(EachItem.Item("T30")) Then
                        .插入深度 = EachItem.Item("T30")
                    End If
                    If Not IsDBNull(EachItem.Item("T27")) Then
                        .投料 = EachItem.Item("T27")
                    End If
                    If Not IsDBNull(EachItem.Item("T31")) Then
                        .AOD出鋼量 = EachItem.Item("T31")
                    End If
                    If Not IsDBNull(EachItem.Item("T32")) Then
                        .澆鑄粉用量 = EachItem.Item("T32")
                    End If
                    If Not IsDBNull(EachItem.Item("T33")) Then
                        .模溢位波動 = EachItem.Item("T33")
                    End If
                    If Not IsDBNull(EachItem.Item("T35")) Then
                        .分鋼槽連鑄完剩餘重量 = EachItem.Item("T35")
                    End If
                    If Not IsDBNull(EachItem.Item("T36")) Then
                        Select Case Val(EachItem.Item("T36"))
                            Case 1
                                .氣罩內壁夾鐵 = "正常"
                            Case 2
                                .氣罩內壁夾鐵 = "夾鐵"
                            Case Else
                                .氣罩內壁夾鐵 = ""
                        End Select
                    End If
                    If Not IsDBNull(EachItem.Item("T39")) Then
                        .填充砂品牌 = EachItem.Item("T39")
                    End If
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
                If IsNothing(GetCoilBugAssey) Then
                    .缺陷代號 = EachItemTemp.Item("QDE05")
                Else
                    .缺陷代號 = GetCoilBugAssey.DEF02
                End If
                .程度 = EachItemTemp.Item("QDE13")
                Select Case EachItem.Item("QDE09")
                    Case "0"
                        .分佈 = "全"
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
            Dim ADDItem As QualityControlDataSet.CoilDefectExtendSearch1Row = ReturnValue.NewRow
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
    Public Function Search(ByVal SQLString As String, ByVal DFAndMD30Range As String, ByVal OrderFieldList As String, ByVal FilterDefectNumber As Integer, ByVal FilterMaxBugTotalVLength As Double) As QualityControlDataSet.CoilDefectExtendSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilDefectExtendSearchDataTable
        End If
        Dim ReturnValue As New QualityControlDataSet.CoilDefectExtendSearchDataTable
        Dim ShowTitleInfoKey As QualityControlDataSet.CoilDefectExtendSearchRow = Nothing
        Dim NumberCount As Integer = 0
        Dim SearchTemp As List(Of DataRow) = (From A In SearchBase(SQLString, DFAndMD30Range) Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        SearchTemp = FilterDefectMinNumber(SearchTemp, FilterDefectNumber)
        SearchTemp = FilterTotalVLength(SearchTemp, FilterMaxBugTotalVLength)

        For Each EachItem As DataRow In SearchTemp
            Dim ADDItem As QualityControlDataSet.CoilDefectExtendSearchRow = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BLA07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BLA09") OrElse ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BLA01"))
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                    .序號 = NumberCount
                    .鋼胚號碼 = EachItem.Item("BLA07")
                    .鋼捲號碼 = EachItem.Item("BLA09")
                    .熱軋號碼 = EachItem.Item("BLA01")
                    If Not IsDBNull(EachItem.Item("T3")) Then
                        .澆鑄粉 = EachItem.Item("T3")
                    End If
                    If Not IsDBNull(EachItem.Item("T4")) Then
                        .分鋼槽塗覆 = EachItem.Item("T4")
                    End If
                    If Not IsDBNull(EachItem.Item("T5")) Then
                        .模液位控制 = EachItem.Item("T5")
                    End If
                    If Not IsDBNull(EachItem.Item("T6")) Then
                        .澆鑄管 = EachItem.Item("T6")
                    End If
                    If Not IsDBNull(EachItem.Item("T7")) Then
                        .澆鑄速度 = EachItem.Item("T7")
                    End If
                    If Not IsDBNull(EachItem.Item("T8")) Then
                        .氣罩 = EachItem.Item("T8")
                    End If
                    If Not IsDBNull(EachItem.Item("T9")) Then
                        .冷卻水量 = EachItem.Item("T9")
                    End If
                    If Not IsDBNull(EachItem.Item("T10")) Then
                        .攪拌時間 = EachItem.Item("T10")
                    End If
                    If Not IsDBNull(EachItem.Item("T11")) Then
                        .靜置時間 = EachItem.Item("T11")
                    End If
                    If Not IsDBNull(EachItem.Item("T12")) Then
                        .交接爐TUNDISH重量 = EachItem.Item("T12")
                    End If
                    If Not IsDBNull(EachItem.Item("T13")) Then
                        .攪拌狀況 = EachItem.Item("T13")
                    End If
                    If Not IsDBNull(EachItem.Item("T14")) Then
                        .渣流動性 = EachItem.Item("T14")
                    End If
                    If Not IsDBNull(EachItem.Item("T15")) Then
                        .攪拌強度 = EachItem.Item("T15")
                    End If
                    If Not IsDBNull(EachItem.Item("T16")) Then
                        .分鋼槽溫度1 = EachItem.Item("T16")
                    End If
                    If Not IsDBNull(EachItem.Item("T17")) Then
                        .分鋼槽溫度2 = EachItem.Item("T17")
                    End If
                    If Not IsDBNull(EachItem.Item("T18")) Then
                        .分鋼槽溫度3 = EachItem.Item("T18")
                    End If
                    If Not IsDBNull(EachItem.Item("T19")) Then
                        .吹氧次數 = EachItem.Item("T19")
                    End If
                    If Not IsDBNull(EachItem.Item("T20")) Then
                        .分鋼槽內容積 = EachItem.Item("T20")
                    End If
                    If Not IsDBNull(EachItem.Item("T21")) Then
                        .連鑄班別 = EachItem.Item("T21")
                    End If
                    If Not IsDBNull(EachItem.Item("T22")) Then
                        .輪班時間 = EachItem.Item("T22")
                    End If
                    If Not IsDBNull(EachItem.Item("T23")) Then
                        .澆鑄管品名 = EachItem.Item("T23")
                    End If
                    If Not IsDBNull(EachItem.Item("T24")) Then
                        .氣罩品名 = EachItem.Item("T24")
                    End If
                    ShowTitleInfoKey = ADDItem
                End If
                .日期 = EachItem.Item("QCA02")
                .DF值 = IIf(CType(EachItem.Item("QCA05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .鋼種 = EachItem.Item("QCA05")
                .材質 = EachItem.Item("QCA06")
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
        Dim QryString As String = SQLString ' GetBasicQry(WhereAfterString)
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        If DFAndMD30s(0) <> -999 OrElse DFAndMD30s(1) <> 999 Then
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCA05"), String).Substring(0, 1) = "2" And CType(A.Item("DF_2"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_2"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCA05"), String).Substring(0, 1) = "3" Select A).ToList
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCA05"), String).Substring(0, 1) = "3" And CType(A.Item("DF_3"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_3"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCA05"), String).Substring(0, 1) = "2" Select A).ToList
        End If
        If DFAndMD30s(2) <> -999 OrElse DFAndMD30s(3) <> 999 Then
            AdapterResult = (From A In AdapterResult Where CType(A.Item("MD30"), Single) >= DFAndMD30s(2) And CType(A.Item("MD30"), Single) <= DFAndMD30s(3) Select A).ToList
        End If
        Return AdapterResult
    End Function

    Private Function FilterDefectMinNumber(ByVal SourceData As List(Of DataRow), ByVal SetMinNumber As Integer) As List(Of DataRow)
        If SetMinNumber <= 1 Then
            Return SourceData
        End If
        Dim ReturnValue As New List(Of DataRow)
        Dim DefectCodes As List(Of Integer) = (From A In SourceData Select CType(A.Item("QDE05"), Integer)).Distinct.ToList
        Dim KeyStrings As List(Of String) = (From A In SourceData Select CType(A.Item("BLA01"), String) & CType(A.Item("BLA11"), String) & CType(A.Item("BLA07"), String) & CType(A.Item("BLA09"), String) & CType(A.Item("QCA05"), String) & CType(A.Item("QCA02"), String) Distinct).ToList

        Dim KeyGroupDatas As List(Of DataRow)
        For Each EachItem As String In KeyStrings
            Dim EachItemTemp As String = EachItem
            KeyGroupDatas = (From A In SourceData Where A.Item("BLA01") & A.Item("BLA11") & A.Item("BLA07") & A.Item("BLA09") & CType(A.Item("QCA05"), String) & A.Item("QCA02") = EachItemTemp Select A).ToList
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


#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' 控制項Where條件產生器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property ControlWhereMaker() As String
        Get
            Dim ReturnValue As New StringBuilder

            Select Case True
                Case ddlOutFormat.SelectedValue = "Format2" '格式2,輸出格式Join 排程資料
                    'ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14 " & _
                    '    ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                    '    ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                    '    ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30" & _
                    '    ",E.SHA08,E.SHA09,E.SHA22,E.SHA23,E.SHA21,E.SHA24,E.SHA25" & _
                    '    " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C,@#PPS100LB.PPSSHAPF E " & _
                    '    " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                    '    " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' " & _
                    '    " AND C.QDE02=E.SHA01 AND C.QDE03=E.SHA02")
                    ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14 " & _
                        ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                        ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                        ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30" & _
                        ",E.SHA08,E.SHA09,E.SHA22,E.SHA23,E.SHA21,E.SHA24,E.SHA25,F.* " & _
                        " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C,@#PPS100LB.PPSSHAPF E  LEFT JOIN @#SMS100LB.SMSREGPF F ON A.QCA01=Left(F.T2,5) AND A.QCA02<=(F.T1+10000) AND A.QCA02>=(F.T1-10000) " & _
                        " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                        " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' " & _
                        " AND C.QDE02=E.SHA01 AND C.QDE03=E.SHA02")
                Case Not CheckBox3.Checked  '預設格式
                    'ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14,C.QDE17 " & _
                    '    ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                    '    ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                    '    ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30" & _
                    '    " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C " & _
                    '    " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                    '    " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' ")
                    ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14,C.QDE17 " & _
                        ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                        ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                        ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30 ,F.* " & _
                        " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C LEFT JOIN @#SMS100LB.SMSREGPF F ON A.QCA01=Left(F.T2,5) AND A.QCA02<=(F.T1+10000) AND A.QCA02>=(F.T1-10000) " & _
                        " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                        " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' ")
                Case CheckBox3.Checked  '格式1
                    'ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14 " & _
                    '    ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                    '    ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                    '    ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30 , D.QDS30 " & _
                    '    " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C  LEFT JOIN @#PPS100LB.PPSQDSPF D ON C.QDE01=D.QDS01 AND C.QDE02=D.QDS02 AND C.QDE03=D.QDS03 AND C.QDE04=D.QDS04 " & _
                    '    " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                    '    " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' ")
                    ReturnValue.Append("Select A.*,B.BLA01,B.BLA03,B.BLA11,B.BLA07,B.BLA09,C.QDE01,C.QDE04,C.QDE05,C.QDE13,C.QDE09,C.QDE13,C.QDE07,C.QDE08,C.QDE10,C.QDE11,C.QDE12,C.QDE14 " & _
                        ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
                        ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
                        ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30 , D.QDS30,F.* " & _
                        " From  @#PPS100LB.PPSQCAPF A,@#PPS100LB.PPSBLAPF B,@#PPS100LB.PPSQDEPF C  LEFT JOIN @#PPS100LB.PPSQDSPF D ON C.QDE01=D.QDS01 AND C.QDE02=D.QDS02 AND C.QDE03=D.QDS03 AND C.QDE04=D.QDS04  LEFT JOIN @#SMS100LB.SMSREGPF F ON A.QCA01=Left(F.T2,5) AND A.QCA02<=(F.T1+10000) AND A.QCA02>=(F.T1-10000) " & _
                        " WHERE (A.QCA01 = Left(B.BLA07, 5) And B.BLA09 = C.QDE02)" & _
                        " AND A.QCA02<=B.BLA08 AND B.BLA08<=C.QDE04 AND B.BLA15='  ' ")
            End Select

            '加入備份檔找尋利用Union將相同爐代找出鋼肧化學成份資料
            Dim AddBackupFileDataQry As String = ReturnValue.ToString.Replace("A.", "AA.").Replace("B.", "BB.").Replace("C.", "CC.").Replace("D.", "DD.").Replace("E.", "EE.").Replace("F.", "FF.").Replace("@#PPS100LBB.PPSQCAPF A", "@#PPS100LB.PPSQCSPF AA").Replace("@#PPS100LBB.PPSBLAPF B", "@#PPS100LB.PPSBLAPF BB").Replace("@#PPS100LBB.PPSQDEPF C", "@#PPS100LB.PPSQDEPF CC").Replace("@#PPS100LBB.PPSQDSPF D", "@#PPS100LB.PPSQDSPF DD").Replace("@#PPS100LBB.PPSSHAPF E", "@#PPS100LB.PPSSHAPF EE").Replace("@#SMS100LBB.SMSREGPF F", "@#SMS100LB.SMSREGPF FF")
            AddBackupFileDataQry &= " AND AA.QCA35=BB.BLA13 "

            Dim WhereValue As String = Nothing
            If Not String.IsNullOrEmpty(tbSLABNumber.Text) AndAlso tbSLABNumber.Text.Trim.Length > 0 Then
                WhereValue &= " AND B.BLA07 LIKE '" & tbSLABNumber.Text.Trim.Replace("*", "%") & "' "
            End If
            If CheckBox1.Checked Then
                Dim StartDate As Date = tbStartDate.Text
                Dim EndDate As Date = tbEndDate.Text
                WhereValue &= " AND A.QCA02>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND A.QCA02<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If CheckBox2.Checked Then
                Dim StartDate As Date = tbProLineStartDate.Text
                Dim EndDate As Date = tbProLineEndDate.Text
                WhereValue &= " AND C.QDE04>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND C.QDE04<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            End If
            If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
                tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCA05) || A.QCA06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
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

            If Not String.IsNullOrEmpty(tbBugWidth.Text) Then
                tbBugWidth.Text = tbBugWidth.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbBugWidth.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1) " & RadioButtonList1.SelectedValue & CType(tbBugWidth.Text, Integer), Nothing)
            End If
            If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
                WhereValue = WhereValue.ToUpper.Trim
                If WhereValue.Substring(0, 3) = "AND" Then
                    WhereValue = WhereValue.Substring(3, WhereValue.Length - 3)
                End If
            End If
            If Not String.IsNullOrEmpty(Me.tbFrontBackCode.Text) Then
                tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbFrontBackCode.Text.Trim.Length > 0, " AND C.QDE12 IN ('" & tbFrontBackCode.Text.Replace(",", "','") & "')", Nothing)
            End If

            If Not String.IsNullOrEmpty(tbSteelBugCodes.Text) AndAlso tbSteelBugCodes.Text.Trim.Length > 0 Then  '煉鋼異常代碼
                WhereValue &= IIf(WhereValue.Length > 0, " AND ", Nothing)
                Dim SteelBugCodes As String = tbSteelBugCodes.Text.Replace("'", Nothing).Replace(",", "','")
                Dim SGAFilterStr As String = Nothing
                For Each EachItem As String In SteelBugCodes.Replace("'", Nothing).Split(",")
                    SGAFilterStr &= IIf(IsNothing(SGAFilterStr), Nothing, " OR ")
                    SGAFilterStr &= " POSSTR(SGE11 ,'" & EachItem & "')<>0 "
                Next
                WhereValue &= "("
                WhereValue &= "B.BLA07 IN (Select DISTINCT SGA01 || '-' || SGA02 || SUBSTR(CHAR(SGA03+100),2,2) || SGA04 From @#SMS100LB.SMSSGAPF Where SGA26 IN ('" & SteelBugCodes & "') )"
                WhereValue &= " OR B.BLA07 IN (Select DISTINCT SGA01 || '-' || SGA02 || SUBSTR(CHAR(SGA03+100),2,2) || SGA04 From @#SMS100LB.SMSSGEPF Where " & SGAFilterStr & ")"
                WhereValue &= ")"

            End If

            If Not String.IsNullOrEmpty(tbQCA33Code.Text) AndAlso tbQCA33Code.Text.Trim.Length > 0 Then  '煉鋼備註代碼
                tbQCA33Code.Text = tbQCA33Code.Text.Replace("'", Nothing)
                WhereValue &= IIf(tbQCA33Code.Text.Trim.Length > 0, " AND A.QCA33 IN ('" & tbQCA33Code.Text.Replace(",", "','") & "')", Nothing)
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

            If CheckBox3.Checked Then
                Dim DeleteLeng As Single = tbQDS30DelLeng.Text
                WhereValue &= " AND NOT D.QDS30 IS NULL AND ( (C.QDE08-C.QDE07)>" & DeleteLeng & " OR NOT ( (C.QDE07<" & DeleteLeng & " AND C.QDE08<" & DeleteLeng & ") OR (C.QDE07>(D.QDS30-" & DeleteLeng & ") AND C.QDE08>(D.QDS30-" & DeleteLeng & ")) ) )"
            End If


            If Not String.IsNullOrEmpty(tbStartWidth.Text) AndAlso Not String.IsNullOrEmpty(tbEndWidth.Text) AndAlso (tbStartWidth.Text.Trim <> "0" OrElse tbEndWidth.Text.Trim <> "9999") Then
                Dim StartWdith As Integer = CType(tbStartWidth.Text, Integer)
                Dim EndWidth As Integer = CType(tbEndWidth.Text, Integer)
                Dim SubQry As String = "Select SHA01 || SHA02 From @#PPS100LB.PPSSHAPF  Where SHA34>=" & StartWdith & " AND SHA34<=" & EndWidth
                ReturnValue.Append(" AND  (C.QDE02 || C.QDE03)  IN (" & SubQry & ")")
            End If

            If ddlOutFormat.SelectedValue = "Format2" AndAlso Not String.IsNullOrEmpty(tbSchedualLines.Text) AndAlso tbSchedualLines.Text.Trim.Length > 0 Then
                ReturnValue.Append(" AND  E.SHA08  IN ('" & tbSchedualLines.Text.Trim.Replace(",", "','") & "')")
            End If

            If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
                ReturnValue.Append(" AND " & WhereValue)
                ReturnValue.Append(" UNION ALL (" & AddBackupFileDataQry & " AND " & WhereValue.Replace("A.", "AA.").Replace("B.", "BB.").Replace("C.", "CC.").Replace("D.", "DD.").Replace("E.", "EE.").Replace("SMS100LBB", "SMS100LB") & ")")
            End If

            hfSortFieldsList.Value = Nothing
            For Each EachItem As ListItem In lbSort.Items
                hfSortFieldsList.Value &= IIf(String.IsNullOrEmpty(hfSortFieldsList.Value), Nothing, ",")
                hfSortFieldsList.Value &= EachItem.Value.Trim
            Next
            Return ReturnValue.ToString
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


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
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
        Me.tbBugWidth.Text = Nothing
        Me.tbFrontBackCode.Text = Nothing
        Me.tbSteelBugCodes.Text = Nothing
        Me.lbElements.Items.Clear()
        Me.tbDefective.Text = Nothing
    End Sub

    Private Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDownExcel.Click
        SetSelectArgToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Select Case True
            Case ddlOutFormat.SelectedValue = "Format0"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "鋼捲缺陷查詢_預設格式" & Format(Now, "mmss") & ".xls")
            Case ddlOutFormat.SelectedValue = "Format1"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "鋼捲缺陷查詢_格式1" & Format(Now, "mmss") & ".xls")
            Case ddlOutFormat.SelectedValue = "Format2"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search2(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value, Me.hfSortFieldsList.Value, Me.hfMinDefectFilterNumber.Value, hfMaxBugTotalVLength.Value), "鋼捲缺陷查詢_產線追踪格式" & Format(Now, "mmss") & ".xls")
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