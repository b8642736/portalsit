Public Partial Class OrderMonthAnalysisControl
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal Year1 As Integer, ByVal Month1 As Integer, ByVal Year2 As Integer, ByVal Month2 As Integer) As SLS300LB.OrderMonthAnalysisPrintDataTable

        Dim FindYear As String = CType(CType(Year1, Integer) - 1911, String)
        Dim FindMonth As String = Format(Month1, "00")
        Dim FindYear2 As String = CType(CType(Year2, Integer) - 1911, String)
        Dim FindMonth2 As String = Format(Month2, "00")
        Dim SQLString As String = "Select * from @#PPS100LB.PPSCIAPF Where SUBSTR(CIA62,3,4)>='" & FindYear & FindMonth & "' AND SUBSTR(CIA62,3,4)<='" & FindYear2 & FindMonth2 & "'  AND CIA34='X' AND CIA39<>'    ' "
        Dim ALLSearchResult As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In CompanyORMDB.PPS100LB.PPSCIAPF.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCIAPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Select A).ToList

        Dim SQLString2 As String = "Select * from @#SLS300LB.SL2BOLPF Where BOL02 || BOL16  ||BOL17 IN (" & SQLString.Replace("*", " CIA62 ||CIA02 ||CIA03") & ")"
        Dim ALLSearchResult2 As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = (From A In CompanyORMDB.SLS300LB.SL2BOLPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2BOLPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString2).SelectQuery) Select A).ToList




        Dim ReturnValue As New SLS300LB.OrderMonthAnalysisPrintDataTable
        Dim SmallSumDatas As New List(Of CompanyORMDB.PPS100LB.PPSCIAPF)    '小計資料
        For Each EachGroup1 In (From A In ALLSearchResult Select A.OutDoorYearMonth, A.CIA05, A.CIA06, A.CIA39, A.OrderYearMonth Order By OutDoorYearMonth, CIA05, CIA06, CIA39, OrderYearMonth).Distinct.ToList
            Dim EachGroup1Datas As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In ALLSearchResult Where A.OutDoorYearMonth = EachGroup1.OutDoorYearMonth And A.CIA05 = EachGroup1.CIA05 And A.CIA06 = EachGroup1.CIA06 And A.CIA39 = EachGroup1.CIA39 And A.OrderYearMonth = EachGroup1.OrderYearMonth Select A).ToList
            If SmallSumDatas.Count > 0 AndAlso Not (EachGroup1.OutDoorYearMonth = SmallSumDatas(0).OutDoorYearMonth AndAlso EachGroup1.CIA05 = SmallSumDatas(0).CIA05 AndAlso EachGroup1.CIA06 = SmallSumDatas(0).CIA06 AndAlso EachGroup1.CIA39 = SmallSumDatas(0).CIA39) Then
                AddSmallSum(ReturnValue, SmallSumDatas, ALLSearchResult2)
                SmallSumDatas.Clear()
            End If
            SmallSumDatas.AddRange(EachGroup1Datas)
            Dim AddItem As SLS300LB.OrderMonthAnalysisPrintRow = ReturnValue.NewRow
            With AddItem
                .提貨年月 = EachGroup1.OutDoorYearMonth
                .訂單年月 = EachGroup1.OrderYearMonth
                .鋼種 = EachGroup1.CIA05
                .表面 = EachGroup1.CIA06
                Dim TotalWeight As Double = (From A In EachGroup1Datas Select A.CIA13).Sum
                Dim TotalMoney As Double = (From A In EachGroup1Datas Select A.AboutSL2BOLPF(ALLSearchResult2).BOL27).Sum
                .厚度 = Format(CType(EachGroup1.CIA39.Trim, Single) / 100, "0.00")
                .重量 = Format(TotalWeight / 1000, "0.000")
                .金額 = Format(TotalMoney, "0,0,0,0")
                .單價 = Format(.金額 / .重量, "0,0,0,0")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        If SmallSumDatas.Count > 0 Then
            AddSmallSum(ReturnValue, SmallSumDatas, ALLSearchResult2)
        End If


        Return ReturnValue
    End Function

#Region "金額/單價平均小計 函式:AddSmallSum"
    ''' <summary>
    ''' 金額/單價平均小計
    ''' </summary>
    ''' <param name="SourceDatas"></param>
    ''' <remarks></remarks>
    Private Shared Sub AddSmallSum(ByVal SourceDatas As SLS300LB.OrderMonthAnalysisPrintDataTable, ByVal SumDatas As List(Of CompanyORMDB.PPS100LB.PPSCIAPF), ByVal DataCache As List(Of CompanyORMDB.SLS300LB.SL2BOLPF))
        '金額/單價平均
        Dim AddItem As SLS300LB.OrderMonthAnalysisPrintRow = SourceDatas.NewRow
        With AddItem
            .訂單年月 = "小計:"
            .鋼種 = SumDatas(0).CIA05
            .表面 = SumDatas(0).CIA06
            Dim TotalWeight As Double = (From A In SumDatas Select A.CIA13).Sum / 1000
            Dim TotalMoney As Double = (From A In SumDatas Select A.AboutSL2BOLPF(DataCache).BOL27).Sum
            .重量 = "合計:" & Format(TotalWeight, "0.000")
            .金額 = "合計:" & Format(TotalMoney, "0,0,0,0")
            .單價 = "平均:" & Format(TotalMoney / TotalWeight, "0,0,0,0")
        End With
        SourceDatas.Rows.Add(AddItem)
    End Sub
#End Region

#End Region
#Region "資料查詢HR 方法:SearchHR"
    Public Shared Function SearchHR(ByVal Year As Integer, ByVal Month As Integer, ByVal Year2 As Integer, ByVal Month2 As Integer) As SLS300LB.OrderNotSendPrintDataTable
        Dim FindYear As String = CType(CType(Year, Integer) - 1911, String)
        Dim FindMonth As String = Format(Month, "00")
        Dim FindYear2 As String = CType(CType(Year2, Integer) - 1911, String)
        Dim FindMonth2 As String = Format(Month2, "00")
        Dim SQLString As String = "Select * from @#SLS300LB.SL2QTNPF Where  LEFT(QTN02,4)>='" & FindYear & FindMonth & "' AND LEFT(QTN02,4)<='" & FindYear2 & FindMonth2 & "' AND  QTN04 LIKE 'NO1%'  AND QTN91='*' "
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN04, A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.OrderNotSendPrintDataTable
        Dim SteelFacdAndKindGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)
        Dim HRGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   'HR小計
        Dim AddItem As DataRow
        For Each EachSteelFaceAndKind In (From A In Step1SearchResult Select A.QTN04, A.QTN03).Distinct

            For Each EachItem In (From A In Step1SearchResult Where A.QTN04 = EachSteelFaceAndKind.QTN04 And A.QTN03 = EachSteelFaceAndKind.QTN03 Select A.QTN05, A.SubThickArea).Distinct
                Dim FilterResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From a In Step1SearchResult Where a.QTN03 = EachSteelFaceAndKind.QTN03 And a.QTN04 = EachSteelFaceAndKind.QTN04 And a.QTN05 = EachItem.QTN05 And a.SubThickArea = EachItem.SubThickArea Select a).ToList
                SteelFacdAndKindGroup.AddRange(FilterResult)
                HRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03
                        .Item("厚度") = EachItem.QTN05
                        .Item("型別") = EachItem.SubThickArea
                        .Item("小計1") = (From A In FilterResult Where A.IsHomeSell Select A.QTN21).Sum
                        .Item("小計2") = (From A In FilterResult Where Not A.IsHomeSell Select A.QTN21).Sum
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03 & "小計"
                .Item("小計1") = (From A In SteelFacdAndKindGroup Where A.IsHomeSell Select A.QTN21).Sum
                .Item("小計2") = (From A In SteelFacdAndKindGroup Where Not A.IsHomeSell Select A.QTN21).Sum
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelFacdAndKindGroup.Clear()
        Next

        'HR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "HR小計"
            .Item("小計1") = (From A In HRGroup Where A.IsHomeSell Select A.QTN21).Sum
            .Item("小計2") = (From A In HRGroup Where Not A.IsHomeSell Select A.QTN21).Sum
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


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy")
            Me.DropDownList1.SelectedValue = Format(Now, "MM")
            TextBox2.Text = Format(Now, "yyyy")
            Me.DropDownList2.SelectedValue = Format(Now, "MM")
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        ReportViewer1.Visible = True
        Dim Parameters(3) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Year1", CType(Me.TextBox1.Text, Integer))
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Month1", CType(Me.DropDownList1.SelectedValue, Integer))
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("Year2", CType(Me.TextBox2.Text, Integer))
        Parameters(3) = New Microsoft.Reporting.WebForms.ReportParameter("Month2", CType(Me.DropDownList2.SelectedValue, Integer))
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub


End Class