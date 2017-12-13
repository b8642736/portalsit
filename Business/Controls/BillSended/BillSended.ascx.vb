Public Partial Class BillSended
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal Date1 As Date, ByVal Date2 As Date) As SLS300LB.BillSendedPrintDataTable
        Dim FindDate1 As String = (Date1.Year - 1911) * 10000 + Format(Date1, "MMdd")
        Dim FindDate2 As String = (Date2.Year - 1911) * 10000 + Format(Date2, "MMdd")

        Dim SQLString As String = "Select A.* from @#PPS100LB.PPSCIAPF A LEFT JOIN @#SLS300LB.SL2CH2PF B ON A.CIA06=B.CH201 Where A.CIA63>=" & FindDate1 & " AND A.CIA63<=" & FindDate2 & " AND B.CH202<>'Y' AND (NOT CIA06 LIKE 'NO1%')  "

        Dim Step1SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In CompanyORMDB.PPS100LB.PPSCIAPF.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCIAPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Select A Order By A.CIA05, A.CIA39, A.SubThickArea).ToList
        Dim ReturnValue As New SLS300LB.BillSendedPrintDataTable

        Dim SteelKindGroup As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)   '鋼種小計
        Dim CRGroup As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)   'CR小計
        Dim AddItem As DataRow
        For Each EachSteelKind As String In (From A In Step1SearchResult Select A.CIA05).Distinct
            Dim TempData1 As String = EachSteelKind
            For Each EachSteelKindThith In (From A In Step1SearchResult Where A.CIA05 = TempData1 Select A.CIA05, A.CIA39, A.SubThickArea).Distinct
                Dim FilterResult As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In Step1SearchResult Where A.CIA05 = EachSteelKindThith.CIA05 And A.CIA39 = EachSteelKindThith.CIA39 And A.SubThickArea = EachSteelKindThith.SubThickArea Select A).ToList
                SteelKindGroup.AddRange(FilterResult)
                CRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = TempData1
                        .Item("厚度") = EachSteelKindThith.CIA39
                        .Item("型別") = EachSteelKindThith.SubThickArea
                        .Item("2D1") = Format(CType((From A In FilterResult Where A.IsHomeSell = True And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("2B1") = Format(CType((From A In FilterResult Where A.IsHomeSell = True And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("BA1") = Format(CType((From A In FilterResult Where A.IsHomeSell = True And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("SH1") = Format(CType((From A In FilterResult Where A.IsHomeSell = True And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
                        .Item("2D2") = Format(CType((From A In FilterResult Where A.IsHomeSell = False And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("2B2") = Format(CType((From A In FilterResult Where A.IsHomeSell = False And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("BA2") = Format(CType((From A In FilterResult Where A.IsHomeSell = False And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("SH2") = Format(CType((From A In FilterResult Where A.IsHomeSell = False And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = TempData1 & "小計"
                .Item("2D1") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = True And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("2B1") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = True And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("BA1") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = True And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("SH1") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = True And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
                .Item("2D2") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = False And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("2B2") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = False And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("BA2") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = False And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("SH2") = Format(CType((From A In SteelKindGroup Where A.IsHomeSell = False And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelKindGroup.Clear()
        Next
        'CR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "CR小計"
            .Item("2D1") = Format(CType((From A In CRGroup Where A.IsHomeSell = True And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("2B1") = Format(CType((From A In CRGroup Where A.IsHomeSell = True And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("BA1") = Format(CType((From A In CRGroup Where A.IsHomeSell = True And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("SH1") = Format(CType((From A In CRGroup Where A.IsHomeSell = True And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
            .Item("2D2") = Format(CType((From A In CRGroup Where A.IsHomeSell = False And A.CIA06 Like "2D*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("2B2") = Format(CType((From A In CRGroup Where A.IsHomeSell = False And A.CIA06 Like "2B*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("BA2") = Format(CType((From A In CRGroup Where A.IsHomeSell = False And A.CIA06 Like "BA*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("SH2") = Format(CType((From A In CRGroup Where A.IsHomeSell = False And A.CIA06 Like "SH*" Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
        End With
        ReturnValue.Rows.Add(AddItem)

        '加入HR
        ReturnValue.Merge(SearchHR(Date1, Date2))

        '加入總計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "總計"
            .Item("小計1") = Format(CType((From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計1).Sum, Double), "0.000")
            .Item("小計2") = Format(CType((From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計2).Sum, Double), "0.000")
        End With
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue
    End Function

#Region "小計 函式:AddSmallSum"
    ''' <summary>
    ''' 小計
    ''' </summary>
    ''' <param name="SourceDatas"></param>
    ''' <param name="TargetCustomer"></param>
    ''' <remarks></remarks>
    Private Shared Sub AddSmallSum(ByVal SourceDatas As SLS300LB.TakeGoodSearchResultTableDataTable, ByVal TargetCustomer As String)
        '客戶小計
        Dim AddItem2 As SLS300LB.TakeGoodSearchResultTableRow = SourceDatas.NewRow
        With AddItem2
            .客戶 = TargetCustomer & " 小計:"
            .鋼種 = ""
            .CR訂單量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.CR訂單量).Sum, Double) / 1000, "0.000")
            .CR提貨量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.CR提貨量).Sum, Double) / 1000, "0.000")
            .HR訂單量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.HR訂單量).Sum, Double) / 1000, "0.000")
            .HR提貨量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.HR提貨量).Sum, Double) / 1000, "0.000")
            .其它訂單量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.其它訂單量).Sum, Double) / 1000, "0.000")
            .其它提貨量 = Format(CType((From A In SourceDatas Where A.客戶 = TargetCustomer Select A.其它提貨量).Sum, Double) / 1000, "0.000")
        End With
        SourceDatas.Rows.Add(AddItem2)

    End Sub
#End Region

#End Region
#Region "資料查詢HR 方法:SearchHR"
    Public Shared Function SearchHR(ByVal Date1 As Date, ByVal Date2 As Date) As SLS300LB.BillSendedPrintDataTable
        Dim FindDate1 As String = (Date1.Year - 1911) * 10000 + Format(Date1, "MMdd")
        Dim FindDate2 As String = (Date2.Year - 1911) * 10000 + Format(Date2, "MMdd")
        'Dim SQLString As String = "Select * from @#SLS300LB.SL2UFIPF A RIGHT JOIN @#PPS100LB.PPSCIAPF B ON A.UFI19=B.CIA62 Where LEFT(A.UFI01,4)>='" & FindYear & FindMonth & "' AND LEFT(A.UFI01,4)<='" & FindYear2 & FindMonth2 & "' "
        Dim SQLString As String = "Select A.* from @#PPS100LB.PPSCIAPF A LEFT JOIN @#SLS300LB.SL2CH2PF B ON A.CIA06=B.CH201  Where A.CIA63>=" & FindDate1 & " AND A.CIA63<=" & FindDate2 & " AND B.CH202<>'Y'  AND  A.CIA06 LIKE 'NO1%'"
        Dim Step1SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In CompanyORMDB.PPS100LB.PPSCIAPF.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCIAPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Select A Order By A.CIA06, A.CIA05, A.CIA39, A.CIA35).ToList
        Dim ReturnValue As New SLS300LB.BillSendedPrintDataTable
        Dim SteelFacdAndKindGroup As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)
        Dim HRGroup As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)   'HR小計
        Dim AddItem As DataRow
        For Each EachSteelFaceAndKind In (From A In Step1SearchResult Select A.CIA06, A.CIA05).Distinct

            For Each EachItem In (From A In Step1SearchResult Where A.CIA06 = EachSteelFaceAndKind.CIA06 And A.CIA05 = EachSteelFaceAndKind.CIA05 Select A.CIA06, A.CIA05, A.CIA39, A.SubThickArea).Distinct
                Dim FilterResult As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From a In Step1SearchResult Where a.CIA06 = EachItem.CIA06 And a.CIA05 = EachItem.CIA05 And a.CIA39 = EachItem.CIA39 And a.SubThickArea = EachItem.SubThickArea Select a).ToList
                SteelFacdAndKindGroup.AddRange(FilterResult)
                HRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = EachSteelFaceAndKind.CIA06 & ":" & EachSteelFaceAndKind.CIA05
                        .Item("厚度") = EachItem.CIA39
                        .Item("型別") = EachItem.SubThickArea
                        .Item("小計1") = Format(CType((From A In FilterResult Where A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
                        .Item("小計2") = Format(CType((From A In FilterResult Where Not A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = EachSteelFaceAndKind.CIA06 & ":" & EachSteelFaceAndKind.CIA05 & "小計"
                .Item("小計1") = Format(CType((From A In SteelFacdAndKindGroup Where A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
                .Item("小計2") = Format(CType((From A In SteelFacdAndKindGroup Where Not A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelFacdAndKindGroup.Clear()
        Next

        'HR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "HR小計"
            .Item("小計1") = Format(CType((From A In HRGroup Where A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
            .Item("小計2") = Format(CType((From A In HRGroup Where Not A.IsHomeSell Select A.CIA13).Sum, Double) / 1000, "0.000")
        End With
        ReturnValue.Rows.Add(AddItem)



        Return ReturnValue
    End Function
#End Region


#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy/MM/01")
            TextBox2.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        ReportViewer1.Visible = True
        Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Date1", CType(Me.TextBox1.Text, Date))
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Date2", CType(Me.TextBox2.Text, Date))
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

End Class