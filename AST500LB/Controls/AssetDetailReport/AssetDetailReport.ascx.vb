Public Class AssetDetailReport
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString1 As String, ByVal QryString2 As String) As AST500LBDataSet.AssetMonthDetailReportDataTable
        Dim ReturnValue As AST500LBDataSet.AssetMonthDetailReportDataTable = New AST500LBDataSet.AssetMonthDetailReportDataTable
        If String.IsNullOrEmpty(QryString1) OrElse String.IsNullOrEmpty(QryString2) Then
            Return ReturnValue
        End If
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult1 As DataTable = DBService.SelectQuery(QryString1)
        Dim SearchResult2 As DataTable = DBService.SelectQuery(QryString2)

        Dim FiveGrupDatas As New SortedList(Of String, List(Of DataRow))    '分組類別,資料集合
        FiveGrupDatas.Add("1", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 7) < "1110101" Select A).ToList)
        FiveGrupDatas.Add("11", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 7) >= "1110101" And CType(A.Item("NUMBER"), String).Substring(0, 1) < "2" Select A).ToList)
        FiveGrupDatas.Add("2", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "2" Select A).ToList)
        FiveGrupDatas.Add("3", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "3" Select A).ToList)
        FiveGrupDatas.Add("4", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "4" Select A).ToList)
        FiveGrupDatas.Add("5", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "5" Select A).ToList)

        Dim FiveGrupOrginDatas As New SortedList(Of String, List(Of DataRow))    '分組類別,資料集合
        FiveGrupOrginDatas.Add("1", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 7) < "1110101" Select A).ToList)
        FiveGrupOrginDatas.Add("11", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 7) >= "1110101" And CType(A.Item("NUMBER"), String).Substring(0, 1) < "2" Select A).ToList)
        FiveGrupOrginDatas.Add("2", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "2" Select A).ToList)
        FiveGrupOrginDatas.Add("3", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "3" Select A).ToList)
        FiveGrupOrginDatas.Add("4", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "4" Select A).ToList)
        FiveGrupOrginDatas.Add("5", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "5" Select A).ToList)

        Return ViewDatas(SearchResult1, SearchResult2, FiveGrupDatas, FiveGrupOrginDatas)
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchTotal(ByVal QryString1 As String, ByVal QryString2 As String) As AST500LBDataSet.AssetMonthDetailReport_TotalDataTable
        Dim ReturnValue As AST500LBDataSet.AssetMonthDetailReport_TotalDataTable = New AST500LBDataSet.AssetMonthDetailReport_TotalDataTable
        If String.IsNullOrEmpty(QryString1) OrElse String.IsNullOrEmpty(QryString2) Then
            Return ReturnValue
        End If
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult1 As DataTable = DBService.SelectQuery(QryString1)
        Dim SearchResult2 As DataTable = DBService.SelectQuery(QryString2)

        Dim FiveGrupDatas As New SortedList(Of String, List(Of DataRow))    '本月份 分組類別,資料集合
        FiveGrupDatas.Add("1", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 7) < "1110101" Select A).ToList)
        FiveGrupDatas.Add("11", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 7) >= "1110101" And CType(A.Item("NUMBER"), String).Substring(0, 1) < "2" Select A).ToList)
        FiveGrupDatas.Add("2", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "2" Select A).ToList)
        FiveGrupDatas.Add("3", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "3" Select A).ToList)
        FiveGrupDatas.Add("4", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "4" Select A).ToList)
        FiveGrupDatas.Add("5", (From A In SearchResult1 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "5" Select A).ToList)

        Dim PreMonthFiveGrupDatas As New SortedList(Of String, List(Of DataRow))    '上個月份 分組類別,資料集合
        PreMonthFiveGrupDatas.Add("1", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 7) < "1110101" Select A).ToList)
        PreMonthFiveGrupDatas.Add("11", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 7) >= "1110101" And CType(A.Item("NUMBER"), String).Substring(0, 1) < "2" Select A).ToList)
        PreMonthFiveGrupDatas.Add("2", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "2" Select A).ToList)
        PreMonthFiveGrupDatas.Add("3", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "3" Select A).ToList)
        PreMonthFiveGrupDatas.Add("4", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "4" Select A).ToList)
        PreMonthFiveGrupDatas.Add("5", (From A In SearchResult2 Where CType(A.Item("NUMBER"), String).Substring(0, 1) = "5" Select A).ToList)


        Dim TotalArgs As String = Nothing
        Dim TotalArgsLastLineValues(5) As Double
        Dim ThisMonthAmount As Double
        Dim ThisMonthDepr As Double
        Dim PreMonthDepr As Double
        Dim AddRow As AST500LBDataSet.AssetMonthDetailReport_TotalRow
        For Each EachGroupKey As String In FiveGrupDatas.Keys
            If IsNothing(FiveGrupDatas(EachGroupKey)) OrElse FiveGrupDatas(EachGroupKey).Count = 0 Then
                Continue For
            End If
            Dim AssetKind As String = Nothing
            Select Case True
                Case EachGroupKey = "1"
                    AssetKind = "土地　　　"
                Case EachGroupKey = "11"
                    AssetKind = "土地改良物"
                Case EachGroupKey = "2"
                    AssetKind = "房屋及設備"
                Case EachGroupKey = "3"
                    AssetKind = "機械及設備"
                Case EachGroupKey = "4"
                    AssetKind = "交通設備　"
                Case EachGroupKey = "5"
                    AssetKind = "雜項設備　"
            End Select
            For Each EachStateCode As String In (From A In FiveGrupDatas(EachGroupKey) Select ACD2 = CType(A.Item("ACD2"), Char) Order By ACD2).Distinct
                AddRow = ReturnValue.NewRow
                With AddRow
                    .分類彙總 = AssetKind
                    Select Case True
                        Case EachStateCode = " "
                            .入帳日期 = "正常"
                        Case EachStateCode = "A"
                            .入帳日期 = "閒置"
                        Case EachStateCode = "B"
                            .入帳日期 = "出租"
                    End Select
                    ThisMonthAmount = (From A In FiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("AMOUNT"))).Sum
                    ThisMonthDepr = (From A In FiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("DEPR"))).Sum
                    PreMonthDepr = (From A In PreMonthFiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("DEPR"))).Sum
                    .上月累計折舊 = Format(PreMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(0) += PreMonthDepr
                    .帳面金額 = Format(ThisMonthAmount, "###,###,##0.00") : TotalArgsLastLineValues(1) += ThisMonthAmount
                    .累計折舊金額 = Format(ThisMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(2) += ThisMonthDepr
                    .本月折舊金額 = Format(ThisMonthDepr - PreMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(3) += (ThisMonthDepr - PreMonthDepr)
                    .未折舊金額 = Format(ThisMonthAmount - ThisMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(4) += (ThisMonthAmount - ThisMonthDepr)
                    ReturnValue.Rows.Add(AddRow)
                End With
            Next


            'TotalArgs &= IIf(String.IsNullOrEmpty(TotalArgs), Nothing, vbNewLine & vbNewLine)
            'Select Case True
            '    Case EachGroupKey = "1"
            '        TotalArgs &= "土地　　　"
            '    Case EachGroupKey = "11"
            '        TotalArgs &= "土地改良物"
            '    Case EachGroupKey = "2"
            '        TotalArgs &= "房屋及設備"
            '    Case EachGroupKey = "3"
            '        TotalArgs &= "機械及設備"
            '    Case EachGroupKey = "4"
            '        TotalArgs &= "交通設備　"
            '    Case EachGroupKey = "5"
            '        TotalArgs &= "雜項設備　"
            'End Select
            'For Each EachStateCode As String In (From A In FiveGrupDatas(EachGroupKey) Select ACD2 = CType(A.Item("ACD2"), Char) Order By ACD2).Distinct
            '    Select Case True
            '        Case EachStateCode = " "
            '            TotalArgs &= vbTab & vbTab & "正常 小計:"
            '        Case EachStateCode = "A"
            '            TotalArgs &= vbNewLine & "　　　　　" & vbTab & vbTab & "閒置 小計:"
            '        Case EachStateCode = "B"
            '            TotalArgs &= vbNewLine & "　　　　　" & vbTab & vbTab & "出租 小計:"
            '    End Select
            '    ThisMonthAmount = (From A In FiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("AMOUNT"))).Sum
            '    ThisMonthDepr = (From A In FiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("DEPR"))).Sum
            '    PreMonthDepr = (From A In PreMonthFiveGrupDatas(EachGroupKey) Where CType(A.Item("ACD2"), String) = EachStateCode Select Val(A.Item("DEPR"))).Sum
            '    TotalArgs &= vbTab & "上月累計折舊:" & Format(PreMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(0) += PreMonthDepr
            '    TotalArgs &= vbTab & "　　帳面金額:" & Format(ThisMonthAmount, "###,###,##0.00") : TotalArgsLastLineValues(1) += ThisMonthAmount
            '    TotalArgs &= vbTab & "累計折舊金額:" & Format(ThisMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(2) += ThisMonthDepr
            '    TotalArgs &= vbTab & "本月折舊金額:" & Format(ThisMonthDepr - PreMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(3) += (ThisMonthDepr - PreMonthDepr)
            '    TotalArgs &= vbTab & "未折舊金額:" & Format(ThisMonthAmount - ThisMonthDepr, "###,###,##0.00") : TotalArgsLastLineValues(4) += (ThisMonthAmount - ThisMonthDepr)
            'Next
        Next
        AddRow = ReturnValue.NewRow
        With AddRow
            .分類彙總 = "　　 合計:"
            .上月累計折舊 = Format(TotalArgsLastLineValues(0), "###,###,##0.00")
            .帳面金額 = Format(TotalArgsLastLineValues(1), "###,###,##0.00")
            .累計折舊金額 = Format(TotalArgsLastLineValues(2), "###,###,##0.00")
            .本月折舊金額 = Format(TotalArgsLastLineValues(3), "###,###,##0.00")
            .未折舊金額 = Format(TotalArgsLastLineValues(4), "###,###,##0.00")

        End With
        ReturnValue.Rows.Add(AddRow)

        Return ReturnValue
        'TotalArgs &= IIf(String.IsNullOrEmpty(TotalArgs), Nothing, vbNewLine & vbNewLine)
        'TotalArgs &= vbTab & vbTab & "　　 合計:"
        'TotalArgs &= vbTab & "上月累計折舊:" & Format(TotalArgsLastLineValues(0), "###,###,##0.00")
        'TotalArgs &= vbTab & "　　帳面金額:" & Format(TotalArgsLastLineValues(1), "###,###,##0.00")
        'TotalArgs &= vbTab & "累計折舊金額:" & Format(TotalArgsLastLineValues(2), "###,###,##0.00")
        'TotalArgs &= vbTab & "本月折舊金額:" & Format(TotalArgsLastLineValues(3), "###,###,##0.00")
        'TotalArgs &= vbTab & "未折舊金額:" & Format(TotalArgsLastLineValues(4), "###,###,##0.00")

        'Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("TotalArgs", TotalArgs)
    End Function

    Private Function ViewDatas(ByVal OrginDatas1 As DataTable, ByVal OrginDatas2 As DataTable, ByVal FiveGrupDatas As SortedList(Of String, List(Of DataRow)), ByVal FiveGrupOrginDatas As SortedList(Of String, List(Of DataRow))) As AST500LBDataSet.AssetMonthDetailReportDataTable
        'ACD02:' '正常 'A'閒置 'B'出租
        Dim ReturnValue As AST500LBDataSet.AssetMonthDetailReportDataTable = New AST500LBDataSet.AssetMonthDetailReportDataTable
        Dim AddRow As AST500LBDataSet.AssetMonthDetailReportRow
        Dim NextSubSumKey As String = "1110101"
        Dim CurrentDataIndex As Integer = 0
        For Each EachItem As DataRow In OrginDatas1.Rows
            If Val(EachItem.Item("QUANT")) = 0 Then
                Continue For
            End If
            AddRow = ReturnValue.NewRow
            With AddRow
                If Not IsDBNull(EachItem.Item("NUMBER")) Then
                    .財產統一編號 = EachItem.Item("NUMBER")
                End If
                If Not IsDBNull(EachItem.Item("NAME")) Then
                    .名稱 = CType(EachItem.Item("NAME"), String).Trim
                End If
                Select Case True
                    Case Not IsDBNull(EachItem.Item("ACD2")) AndAlso CType(EachItem.Item("ACD2"), String) = "A"
                        .名稱 &= "(閒置)"
                    Case Not IsDBNull(EachItem.Item("ACD2")) AndAlso CType(EachItem.Item("ACD2"), String) = "B"
                        .名稱 &= "(出租)"
                End Select
                If Not IsDBNull(EachItem.Item("DATE")) Then
                    .入帳日期 = EachItem.Item("DATE")
                End If
                If Not IsDBNull(EachItem.Item("USLAFF")) Then
                    .使用年限 = EachItem.Item("USLAFF")
                End If
                If Not IsDBNull(EachItem.Item("UNIT")) Then
                    .計量單位 = EachItem.Item("UNIT")
                End If
                If Not IsDBNull(EachItem.Item("QUANT")) Then
                    .數量 = EachItem.Item("QUANT")
                End If
                If Not IsDBNull(EachItem.Item("QUANT")) AndAlso Not IsDBNull(EachItem.Item("AMOUNT")) Then
                    .單價 = Format(Val(EachItem.Item("AMOUNT")) / Val(EachItem.Item("QUANT")), "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("AMOUNT")) Then
                    .帳面金額 = EachItem.Item("AMOUNT")
                End If
                If Not IsDBNull(EachItem.Item("DEPR")) Then
                    .累計折舊金額 = Format(EachItem.Item("DEPR"), "###,##0.00")
                End If
                If Not IsDBNull(EachItem.Item("AMOUNT")) And Not IsDBNull(EachItem.Item("DEPR")) Then
                    .未折舊金額 = Format(Val(EachItem.Item("AMOUNT")) - Val(EachItem.Item("DEPR")), "###,##0.00")
                    If Not IsDBNull(EachItem.Item("ACD3")) And EachItem.Item("ACD3") = "-" Then
                        If .財產統一編號.Substring(0, 1) = "3" AndAlso EachItem.Item("ACD2") = "B" AndAlso EachItem.Item("DEPT") = "RA" AndAlso Val(.入帳日期) <= 9809 Then
                            .未折舊金額 = "累計減損" & vbNewLine & .未折舊金額
                        Else
                            '.未折舊金額 = "備抵跌價損失" & vbNewLine & .未折舊金額
                            .未折舊金額 = "累計減損" & vbNewLine & .未折舊金額    '105/1/4 朱焉操要求變更
                        End If
                    End If
                End If

                Dim FindPreMonthRecord As DataRow = (From A In OrginDatas2 Where CType(A.Item("NUMBER"), String).Trim = CType(EachItem.Item("NUMBER"), String).Trim Select A).FirstOrDefault
                If Not IsDBNull(EachItem.Item("DEPR")) AndAlso Not IsDBNull(FindPreMonthRecord.Item("DEPR")) Then
                    .本月折舊金額 = Format(Val(EachItem.Item("DEPR")) - Val(FindPreMonthRecord.Item("DEPR")), "###,##0.00")
                End If

            End With
            ReturnValue.Rows.Add(AddRow)

            '資料小計
            Dim ShowSubGroupIndex As String = ""
            Select Case True
                Case CurrentDataIndex = OrginDatas1.Rows.Count - 1
                    ShowSubGroupIndex = "5"
                Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 7) < "1110101" AndAlso CType(OrginDatas1.Rows(CurrentDataIndex + 1).Item("NUMBER"), String).Substring(0, 7) >= "1110101"
                    ShowSubGroupIndex = "1"
                Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 1) <> CType(OrginDatas1.Rows(CurrentDataIndex + 1).Item("NUMBER"), String).Substring(0, 1)
                    Select Case True
                        Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 1) = "1"
                            ShowSubGroupIndex = "11"
                        Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 1) = "2"
                            ShowSubGroupIndex = "2"
                        Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 1) = "3"
                            ShowSubGroupIndex = "3"
                        Case CType(OrginDatas1.Rows(CurrentDataIndex).Item("NUMBER"), String).Substring(0, 1) = "4"
                            ShowSubGroupIndex = "4"
                    End Select
            End Select
            If Not String.IsNullOrEmpty(ShowSubGroupIndex) Then
                For Each EachStateCode As String In (From A In FiveGrupDatas(ShowSubGroupIndex) Select CType(A.Item("ACD2"), Char)).Distinct
                    AddRow = ReturnValue.NewRow
                    With AddRow
                        Select Case True
                            Case EachStateCode = " "
                                .名稱 = "正常 小計:"
                            Case EachStateCode = "A"
                                .名稱 = "閒置 小計:"
                            Case EachStateCode = "B"
                                .名稱 = "出租 小計:"
                        End Select
                        .帳面金額 = Format((From A In FiveGrupDatas(ShowSubGroupIndex) Where CType(A.Item("ACD2"), Char) = EachStateCode Select Val(A.Item("AMOUNT"))).Sum, "###,##0.00")
                        .累計折舊金額 = Format((From A In FiveGrupDatas(ShowSubGroupIndex) Where CType(A.Item("ACD2"), Char) = EachStateCode Select Val(A.Item("DEPR"))).Sum, "###,##0.00")
                        .本月折舊金額 = Format((From A In FiveGrupDatas(ShowSubGroupIndex) Where CType(A.Item("ACD2"), Char) = EachStateCode Select Val(A.Item("DEPR"))).Sum - (From A In FiveGrupOrginDatas(ShowSubGroupIndex) Where CType(A.Item("ACD2"), Char) = EachStateCode Select Val(A.Item("DEPR"))).Sum, "###,##0.00")
                        .未折舊金額 = Format(CType(.帳面金額, Double) - CType(.累計折舊金額, Double), "###,##0.00")
                    End With
                    ReturnValue.Rows.Add(AddRow)
                Next
            End If
            CurrentDataIndex += 1
        Next

        '資料總計
        AddRow = ReturnValue.NewRow
        With AddRow
            .名稱 = "總計"
            .帳面金額 = Format((From A In OrginDatas1 Select Val(A.Item("AMOUNT"))).Sum, "###,##0.00")
            .累計折舊金額 = Format((From A In OrginDatas1 Select Val(A.Item("DEPR"))).Sum, "###,##0.00")
            .本月折舊金額 = Format((From A In OrginDatas1 Select Val(A.Item("DEPR"))).Sum - (From A In OrginDatas2 Select Val(A.Item("DEPR"))).Sum, "###,##0.00")
            .未折舊金額 = Format((From A In OrginDatas1 Select Val(A.Item("AMOUNT"))).Sum - (From A In OrginDatas1 Select Val(A.Item("DEPR"))).Sum, "###,##0.00")
        End With
        ReturnValue.Rows.Add(AddRow)


        Return ReturnValue
    End Function
#End Region
#Region "計算合計結果至報表參數 函式:SubTotalToReportParameter"
    ''' <summary>
    ''' 計算合計結果至報表參數
    ''' </summary>
    ''' <param name="SourceReport"></param>
    ''' <remarks></remarks>
    Private Sub SubTotalToReportParameter(ByVal SourceReport As Microsoft.Reporting.WebForms.Report)

        Dim TitleArg1 As String = Nothing
        Select Case RadioButtonList1.SelectedValue
            Case "AA"
                TitleArg1 = "總公司" & RadioButtonList1.SelectedValue
            Case "AB"
                TitleArg1 = "總公司-新豐" & RadioButtonList1.SelectedValue
            Case "NA"
                TitleArg1 = "台北辦事處" & RadioButtonList1.SelectedValue
            Case "QA"
                TitleArg1 = "營建部" & RadioButtonList1.SelectedValue
            Case "RA"
                TitleArg1 = "機械廠本部" & RadioButtonList1.SelectedValue
            Case "RC"
                TitleArg1 = "公路車輛事業部" & RadioButtonList1.SelectedValue
            Case "RD"
                TitleArg1 = "鋼構組" & RadioButtonList1.SelectedValue
            Case "SA"
                TitleArg1 = "不銹鋼"
        End Select

        Dim TitleArg2 As String = Nothing
        Dim ThisMonthFirstDay As Date = New Date(Now.Year, Now.Month, 1)
        Dim TitleArgYear As String = Nothing
        Select Case True
            Case Now <= ThisMonthFirstDay.AddDays(15)
                TitleArg2 = ThisMonthFirstDay.AddMonths(-1).Month
                TitleArgYear = ThisMonthFirstDay.AddMonths(-1).Year - 1911
            Case Now > ThisMonthFirstDay.AddDays(15)
                TitleArg2 = ThisMonthFirstDay.Month
                TitleArgYear = ThisMonthFirstDay.Year - 1911
        End Select


        Dim Parameters(2) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArg1", TitleArg1)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArg2", TitleArg2)
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArgYear", TitleArgYear)

        SourceReport.SetParameters(Parameters)
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString1 As String = Nothing
        Dim SQLString2 As String = Nothing
        SQLString1 = "Select A.* , B.DEPTSA From @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER AND B.SEQ=1 Order by A.NUMBER"
        SQLString2 = "Select A.* , B.DEPTSA From @#AST500LB.AST201PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER AND B.SEQ=1 Order by A.NUMBER"
        Me.hfQry1.Value = SQLString1
        Me.hfQry2.Value = SQLString2
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        SubTotalToReportParameter(ReportViewer1.LocalReport)
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class