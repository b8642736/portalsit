Public Class CustomerIncomeAnalysis
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal ACSSKBPFResultSQLString As String, ByVal SL3X04PFResultSQLString As String, ByVal SL2EXRPFResultSQLString As String) As SLS300LB.CustomerIncomeAnalysisDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.CustomerIncomeAnalysisDataTable
        End If
        Dim ReturnValue = New SLS300LB.CustomerIncomeAnalysisDataTable

        Dim AS400DBAdaptere As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AllACSSKBPFResult As List(Of CompanyORMDB.ACS300LB.ACSSKBPF) = CompanyORMDB.ACS300LB.ACSSKBPF.CDBSelect(Of CompanyORMDB.ACS300LB.ACSSKBPF)(ACSSKBPFResultSQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AllSL3X04PFResult As List(Of CompanyORMDB.SLS300LB.SL3X04PF) = CompanyORMDB.SLS300LB.SL3X04PF.CDBSelect(Of CompanyORMDB.SLS300LB.SL3X04PF)(SL3X04PFResultSQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AllSL2EXRPFResult As List(Of CompanyORMDB.SLS300LB.SL2EXRPF) = CompanyORMDB.SLS300LB.SL2EXRPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2EXRPF)(SL2EXRPFResultSQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = AS400DBAdaptere.SelectQuery(SQLString)

        Dim ShowFieldValue1 As String = Nothing
        Dim ShowFieldValue2 As String = Nothing
        Dim ShowFieldValue3 As String = Nothing
        Dim ShowFieldValue4 As String = Nothing
        Dim ShowFieldValue5 As String = Nothing
        For Each EachCustomer As String In (From A In SearchResult Select CType(A.Item("BOL03"), String).Substring(0, 3) Distinct).ToList
            Dim EachCustomerTemp As String = EachCustomer : ShowFieldValue1 = EachCustomerTemp
            Dim CustomerGroupDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("BOL03"), String).Substring(0, 3) = EachCustomerTemp Select A).ToList
            For Each EachCROrHR As String In {"CR", "HR"}
                Dim EachCROrHRTemp As String = EachCROrHR : ShowFieldValue2 = ShowFieldValue1 & "@" & EachCROrHRTemp
                Dim CROrHRGroupDatas As List(Of DataRow) = Nothing '= (From A In CustomerGroupDatas Where CType(A.Item("BOL06"), String) = "NO1" Select A).ToList
                If EachCROrHRTemp = "CR" Then
                    CROrHRGroupDatas = (From A In CustomerGroupDatas Where CType(A.Item("BOL06"), String) <> "NO1" Select A).ToList
                Else
                    CROrHRGroupDatas = (From A In CustomerGroupDatas Where CType(A.Item("BOL06"), String) = "NO1" Select A).ToList
                End If
                If CROrHRGroupDatas.Count = 0 Then
                    Continue For
                End If
                For Each EachSteelKind As String In (From A In CROrHRGroupDatas Select CType(A.Item("BOL05"), String) Distinct).ToList
                    Dim EachSteelKindTemp As String = EachSteelKind : ShowFieldValue3 = ShowFieldValue2 & "@" & EachSteelKindTemp
                    Dim SteelKindGroupDatas As List(Of DataRow) = (From A In CROrHRGroupDatas Where CType(A.Item("BOL05"), String) = EachSteelKindTemp Select A).ToList
                    For Each EachFace As String In (From A In SteelKindGroupDatas Select CType(A.Item("BOL06"), String) Distinct).ToList
                        Dim EachFaceTemp As String = EachFace : ShowFieldValue4 = ShowFieldValue3 & "@" & EachFaceTemp
                        Dim FaceGroupDatas As List(Of DataRow) = (From A In SteelKindGroupDatas Where CType(A.Item("BOL06"), String) = EachFaceTemp Select A).ToList
                        For Each EachMaterialKind As String In (From A In FaceGroupDatas Select CType(A.Item("CIA33"), String) Distinct).ToList
                            Dim EachMaterialKindTemp As String = EachMaterialKind : ShowFieldValue5 = ShowFieldValue4 & "@" & EachMaterialKindTemp
                            Dim MaterialKindDatas As List(Of DataRow) = (From A In FaceGroupDatas Where CType(A.Item("CIA33"), String) = EachMaterialKindTemp Select A).ToList
                            AddDisplayData(ReturnValue, ShowFieldValue5, MaterialKindDatas, AllACSSKBPFResult, AllSL3X04PFResult, AllSL2EXRPFResult)
                        Next
                        'AddDisplayData(ReturnValue, ShowFieldValue4, FaceGroupDatas, AllACSSKBPFResult, AllSL3X04PFResult,AllSL2EXRPFResult)
                    Next
                    'AddDisplayData(ReturnValue, ShowFieldValue3, SteelKindGroupDatas, AllACSSKBPFResult, AllSL3X04PFResult, AllSL2EXRPFResult)
                Next
                'AddDisplayData(ReturnValue, ShowFieldValue2, CROrHRGroupDatas, AllACSSKBPFResult, AllSL3X04PFResult, AllSL2EXRPFResult)
            Next
            'AddDisplayData(ReturnValue, ShowFieldValue1, CustomerGroupDatas, AllACSSKBPFResult, AllSL3X04PFResult, AllSL2EXRPFResult)
        Next
        'AddDisplayData(ReturnValue, "", (From A In SearchResult Select A).ToList, AllACSSKBPFResult, AllSL3X04PFResult, AllSL2EXRPFResult)
        Return ReturnValue
    End Function

    Private Sub AddDisplayData(ByVal ReturnValue As SLS300LB.CustomerIncomeAnalysisDataTable, ByVal ShowFieldValues As String, ByVal GroupDatas As List(Of DataRow), ByVal AllACSSKBPFResult As List(Of CompanyORMDB.ACS300LB.ACSSKBPF), ByVal AllSL3X04PFResult As List(Of CompanyORMDB.SLS300LB.SL3X04PF), ByVal AllSL2EXRPFResult As List(Of CompanyORMDB.SLS300LB.SL2EXRPF))
        Dim AddItem As SLS300LB.CustomerIncomeAnalysisRow = ReturnValue.NewRow
        Dim InOutSellString As String = Nothing
        If GroupDatas.Count > 0 Then
            InOutSellString = IIf(CType(GroupDatas(0).Item("BOL92"), String).Trim.Length = 0, "內銷", "外銷")
        End If
        Dim ShowFieldValue() As String = ShowFieldValues.Split("@")
        With AddItem
            .內外銷 = InOutSellString
            ._CR_HR = "--"
            .鋼種 = "--"
            .表面 = "--"
            .料別 = "--"
            Select Case True
                Case ShowFieldValue.Length = 1 AndAlso ShowFieldValue(0).Trim.Length = 0
                    .客戶 = "全部合計:"
                Case ShowFieldValue.Length = 1
                    .客戶 = ShowFieldValue(0).Trim
                Case ShowFieldValue.Length = 2
                    .客戶 = ShowFieldValue(0).Trim
                    ._CR_HR = ShowFieldValue(1).Trim
                Case ShowFieldValue.Length = 3
                    .客戶 = ShowFieldValue(0).Trim
                    ._CR_HR = ShowFieldValue(1).Trim
                    .鋼種 = ShowFieldValue(2).Trim
                Case ShowFieldValue.Length = 4
                    .客戶 = ShowFieldValue(0).Trim
                    ._CR_HR = ShowFieldValue(1).Trim
                    .鋼種 = ShowFieldValue(2).Trim
                    .表面 = ShowFieldValue(3).Trim
                Case ShowFieldValue.Length = 5
                    .客戶 = ShowFieldValue(0).Trim
                    ._CR_HR = ShowFieldValue(1).Trim
                    .鋼種 = ShowFieldValue(2).Trim
                    .表面 = ShowFieldValue(3).Trim
                    .料別 = ShowFieldValue(4).Trim
            End Select

            If ShowFieldValue(0).Trim.Length > 0 Then
                Dim FindCustomer As CompanyORMDB.SLS300LB.SL2CUAPF = (From A In CompanyORMDB.SLS300LB.SL2CUAPF.ALLSL2CUAPFs Where A.CUA01.Trim = ShowFieldValue(0).Trim).FirstOrDefault
                If Not IsNothing(FindCustomer) AndAlso Not String.IsNullOrEmpty(FindCustomer.CUA11) Then
                    .客戶 &= "(" & FindCustomer.CUA11.Trim & ")"
                End If
            End If
            .數量 = (From A In GroupDatas Select CType(A.Item("BOL14"), Double)).Sum

            '不函匯差(SX403 <> "B02")
            Dim DiscountValue1 As Double = (From A In AllSL3X04PFResult Where A.SX403 <> "B02" And (From B In GroupDatas Select CType(B.Item("BOL16"), String) & CType(B.Item("BOL17"), String)).ToList.Contains(A.SX401 & A.SX402) Select A.SX404).Sum
            .匯差 = (From A In AllSL3X04PFResult Where A.SX403 = "B02" And (From B In GroupDatas Select CType(B.Item("BOL16"), String) & CType(B.Item("BOL17"), String)).ToList.Contains(A.SX401 & A.SX402) Select A.SX404).Sum

            Dim HonorDiscount As Double = 0 : HonorDiscount = 0 '履約獎勵
            Select Case True
                Case CType(GroupDatas(0).Item("BOL92"), String).Trim.Length = 0 '內銷
                    For Each EachItem As DataRow In GroupDatas
                        HonorDiscount += CType(EachItem.Item("BOL14"), Double) * 500
                    Next
                Case CType(GroupDatas(0).Item("BOL92"), String) = "O" OrElse CType(GroupDatas(0).Item("BOL03"), String).Substring(0, 3) = "E35"
                    For Each EachItem As DataRow In GroupDatas
                        HonorDiscount += CType(EachItem.Item("BOL14"), Double) * 50 * CompanyORMDB.SLS300LB.SL2PR0PF.YearMonthRate1(Val(CType(EachItem.Item("BOL03"), String).Substring(3, 5)))
                    Next
                Case CType(GroupDatas(0).Item("BOL92"), String) = "E"   '直接外銷

            End Select
            .履約獎勵 = HonorDiscount

            Dim ProcessExportDiscount As Double = 0 : ProcessExportDiscount = 0 '加工外銷沖退
            If CType(GroupDatas(0).Item("BOL92"), String).Trim.Length = 0 Then
                For Each EachItem As DataRow In GroupDatas
                    For Each EachSL2EXRPF In AllSL2EXRPFResult
                        If EachSL2EXRPF.EXR03 & EachSL2EXRPF.EXR01 & EachSL2EXRPF.EXR02 = CType(EachItem("BOL03"), String).Substring(0, 8) Then
                            ProcessExportDiscount += EachSL2EXRPF.DrawWeight(CType(EachItem.Item("BOL14"), Double)) : Exit For
                        End If
                    Next
                Next
            End If
            .預估加工外銷沖退 = ProcessExportDiscount

            'Dim DiscountValue2 As Double = 0    '內銷有數量折扣
            'For Each EachItem As DataRow In (From A In GroupDatas Where CType(A.Item("BOL92"), String) = " " Select A).ToList
            '    DiscountValue2 += CompanyORMDB.SLS300LB.SL3X11PF.MonthWeightDiscount(Val(Format(CType(GroupDatas(0).Item("CIA64"), Integer), "0000000").Substring(0, 5))) * CType(EachItem.Item("BOL14"), Double)
            'Next

            .收入 = (From A In GroupDatas Select CType(A.Item("BOL27"), Double)).Sum + DiscountValue1 '- DiscountValue2
            .變動成本 = CostCompute(CostType.VariableUnitCost, GroupDatas, AllACSSKBPFResult)
            .固定成本 = CostCompute(CostType.FixedUnitCost, GroupDatas, AllACSSKBPFResult)
            .客戶貢獻度 = Val(.收入) - Val(.變動成本)
            .毛利 = Val(.收入) - Val(.變動成本) - Val(.固定成本)
            .數量 = Format(Val(.數量), "#,#")
            .匯差 = Format(Val(.匯差), "#,#")
            .履約獎勵 = Format(Val(.履約獎勵), "#,#")
            .預估加工外銷沖退 = Format(Val(.預估加工外銷沖退), "#,#")
            .收入 = Format(Val(.收入), "#,#")
            .變動成本 = Format(Val(.變動成本), "#,#")
            .固定成本 = Format(Val(.固定成本), "#,#")
            .客戶貢獻度 = Format(Val(.客戶貢獻度), "#,#")
            .毛利 = Format(Val(.毛利), "#,#")
        End With

        ReturnValue.Rows.Add(AddItem)
    End Sub

    Private Function CostCompute(ByVal GetCostType As CostType, ByVal GroupDatas As List(Of DataRow), ByVal AllACSSKBPFResult As List(Of CompanyORMDB.ACS300LB.ACSSKBPF)) As Double
        Dim ReturnValue As Double = 0
        Dim FindACSSKBPF As CompanyORMDB.ACS300LB.ACSSKBPF = Nothing
        For Each EachItem As DataRow In GroupDatas
            Dim SteelKind As String = CType(EachItem.Item("BOL05"), String).Trim
            Dim CROrHR As String = IIf(CType(EachItem.Item("BOL06"), String).Trim = "NO1", "HR", "CR")
            Dim Thith As String = Format(CType(CType(EachItem.Item("CIA59"), String), Single) / 100, "0.00").PadLeft(5)
            Dim Face As String = CType(EachItem.Item("BOL06"), String).Trim
            Dim MaterialKind As String = CType(EachItem.Item("CIA33"), String).Trim
            Dim HormOrOutSell As String = CType(EachItem.Item("CIA34"), String)
            Dim DataYearMonth As String = CType(EachItem.Item("UFI01"), String).Substring(0, 5)

            FindACSSKBPF = Nothing
            For Each EachACSSKBPF As CompanyORMDB.ACS300LB.ACSSKBPF In AllACSSKBPFResult
                If EachACSSKBPF.SKB13 = HormOrOutSell And EachACSSKBPF.SKB11.Substring(0, 5) = DataYearMonth AndAlso EachACSSKBPF.SKB01.Trim = SteelKind AndAlso EachACSSKBPF.SKB02.Trim = CROrHR AndAlso EachACSSKBPF.SKB04 = Thith AndAlso EachACSSKBPF.SKB05.Trim = Face AndAlso EachACSSKBPF.SKB12.Trim = MaterialKind Then
                    FindACSSKBPF = EachACSSKBPF : Exit For
                End If
            Next
            If IsNothing(FindACSSKBPF) Then
                Throw New Exception("系統找不到成本明細資料 內外銷/鋼種/CROrHR/厚度/表面/料別=>" & HormOrOutSell & SteelKind & "/" & CROrHR & "/" & Thith & "/" & Face & "/" & MaterialKind)
            End If

            Select Case GetCostType
                Case CostType.UnitCost
                    ReturnValue += CType(EachItem.Item("BOL14"), Double) * FindACSSKBPF.CostUnitCost
                Case CostType.VariableUnitCost
                    ReturnValue += CType(EachItem.Item("BOL14"), Double) * FindACSSKBPF.VariableUnitCost
                Case CostType.FixedUnitCost
                    ReturnValue += CType(EachItem.Item("BOL14"), Double) * FindACSSKBPF.FixedUnitCost
            End Select
        Next
        Return ReturnValue
    End Function

    Private Enum CostType
        UnitCost = 1
        VariableUnitCost = 2
        FixedUnitCost = 3
    End Enum

#End Region

#Region "產生查詢至控製項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢至控製項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim StartDate As DateTime = CType(tbStartDate.Text, DateTime)
        Dim EndDate As DateTime = CType(tbEndDate.Text, DateTime)
        Dim StartTwDate As String = Format(New CompanyORMDB.AS400DateConverter(StartDate).TwIntegerTypeData, "0000000")
        Dim EndTwDate As String = Format(New CompanyORMDB.AS400DateConverter(EndDate).TwIntegerTypeData, "0000000")
        If EndDate < StartDate Then
            hfQry.Value = Nothing : hfQryACSSKBLA.Value = Nothing
            Exit Sub
        End If

        'CIA59:公稱厚度 CAI33:料別 CIA34:外銷 UFI01:發日期
        Dim SelectOutString As String = "Select DISTINCT  A.BOL01, A.BOL02, A.BOL03, A.BOL05, BOL06, A.BOL14, A.BOL16, A.BOL17, A.BOL27, A.BOL92 ,B.CIA59 ,B.CIA33, B.CIA34, B.CIA64, C.UFI01 "
        Dim SQLFromAfterString As String = "From @#SLS300LB.SL2BOLPF AS A LEFT JOIN @#PPS100LB.PPSCIAPF AS B ON A.BOL16 = B.CIA02 AND A.BOL17 = B.CIA03 AND INTEGER(A.BOL01)= B.CIA63 " _
                                  & "LEFT JOIN @#SLS300LB.SL2UFIPF AS C ON A.BOL02=C.UFI19 " _
                                  & "Where BOL06 IN (Select CH201 FROM @#SLS300LB.SL2CH2PF Where CH202<>'Y') "
        SQLFromAfterString &= " AND C.UFI01 >= '" & StartTwDate & "' AND C.UFI01 <= '" & EndTwDate & "' AND C.UFI13<>'$' "
        'SQLFromAfterString &= " AND A.BOL02 IN (SELECT UFI19 FROM @#SLS300LB.SL2UFIPF WHERE UFI01 >= '" & StartTwDate & "' AND UFI01 <= '" & EndTwDate & "' AND UFI13<>'$' ) "
        hfQry.Value = SelectOutString & SQLFromAfterString & " Order by A.BOL92, A.BOL03"

        '找尋所有結退記錄資料
        hfQrySL3X04PF.Value = "Select * From @#SLS300LB.SL3X04LF Where (SX400 || SX401 || SX402) IN (" & "Select A.BOL02 || A.BOL16 || A.BOL17 " & SQLFromAfterString & ")"

        '找尋所有加工外銷沖消
        hfQrySL2EXRPF.Value = "Select * From @#SLS300LB.SL2EXRPF Where (EXR03 || EXR01 || EXR02) IN ( " & "Select SUBSTR(A.BOL03,1,8) " & SQLFromAfterString & ")"

        '找尋所有成本資料
        Dim AllMonthDays As String = Nothing
        Dim QryDateValue As DateTime = New DateTime(StartDate.Year, StartDate.Month, DateTime.DaysInMonth(StartDate.Year, StartDate.Month))
        Dim EndQryDateValue As DateTime = New DateTime(EndDate.Year, EndDate.Month, DateTime.DaysInMonth(EndDate.Year, EndDate.Month))
        Do While QryDateValue <= EndQryDateValue
            AllMonthDays &= IIf(String.IsNullOrEmpty(AllMonthDays), Nothing, ",") & Format(New CompanyORMDB.AS400DateConverter(QryDateValue).TwIntegerTypeData, "0000000").Substring(0, 5)
            QryDateValue = New Date(QryDateValue.AddMonths(1).Year, QryDateValue.AddMonths(1).Month, Date.DaysInMonth(QryDateValue.AddMonths(1).Year, QryDateValue.AddMonths(1).Month))
        Loop
        hfQryACSSKBLA.Value = "Select * From @#ACS300LB.ACSSKBLA Where SKB00='14' AND  SKB08>0 AND LEFT(SKB11,5) IN (" & AllMonthDays & ")"

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim SetDefaultDate As DateTime = Now.AddMonths(-1)
            Me.tbStartDate.Text = Format(SetDefaultDate, "yyyy/MM/01")
            Me.tbEndDate.Text = Format(SetDefaultDate, "yyyy/MM/" & Date.DaysInMonth(SetDefaultDate.Year, SetDefaultDate.Month))
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnDownLoadExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoadExcel.Click
        MakeQryToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value, Me.hfQryACSSKBLA.Value, Me.hfQrySL3X04PF.Value, Me.hfQrySL2EXRPF.Value), "客戶毛利分析" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class