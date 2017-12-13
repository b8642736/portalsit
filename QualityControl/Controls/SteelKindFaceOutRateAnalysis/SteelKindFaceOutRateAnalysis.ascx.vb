Public Class SteelKindFaceOutRateAnalysis
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    Public Function Search() As List(Of QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableRow)
        Return New List(Of QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableRow)
    End Function
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of PPS100LB.PPSCI7PF) = PPS100LB.PPSCI7PF.CDBSelect(Of PPS100LB.PPSCI7PF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As String In (From A In SearchResult Select A.CI701).Distinct
            Dim EachItemTemp As String = EachItem
            PutFieldValueToDataRow((From A In SearchResult Where A.CI701 = EachItemTemp And A.CI705 = " " Select A).ToList, ReturnValue)
            PutFieldValueToDataRow((From A In SearchResult Where A.CI701 = EachItemTemp And A.CI705 = "X" Select A).ToList, ReturnValue)
            PutFieldValueToDataRow((From A In SearchResult Where A.CI701 = EachItemTemp Select A).ToList, ReturnValue)
            ReturnValue.Rows(ReturnValue.Rows.Count - 1)(0) = "小計"
        Next

        PutFieldValueToDataRow((From A In SearchResult Where A.CI705 = " " Select A).ToList, ReturnValue)
        ReturnValue.Rows(ReturnValue.Rows.Count - 1)(0) = "內銷"
        PutFieldValueToDataRow((From A In SearchResult Where A.CI705 = "X" Select A).ToList, ReturnValue)
        ReturnValue.Rows(ReturnValue.Rows.Count - 1)(0) = "外銷"
        PutFieldValueToDataRow(SearchResult.ToList, ReturnValue)
        ReturnValue.Rows(ReturnValue.Rows.Count - 1)(0) = "合計"

        Return ReturnValue
    End Function
    Private Sub PutFieldValueToDataRow(ByVal SourceData As List(Of PPS100LB.PPSCI7PF), ByRef ADDToDataTable As QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableDataTable)
        If SourceData.Count = 0 Then
            Exit Sub
        End If
        Dim ADDDataRow As QualityControlDataSet.SteelKindFaceOutRateAnalysisDataTableRow = ADDToDataTable.NewRow
        Dim Datas_BA As List(Of PPS100LB.PPSCI7PF) = (From A In SourceData Where A.CI703 = "BA " Select A).ToList
        Dim Datas_2B As List(Of PPS100LB.PPSCI7PF) = (From A In SourceData Where A.CI703 = "2B " Select A).ToList
        Dim Datas_2D As List(Of PPS100LB.PPSCI7PF) = (From A In SourceData Where A.CI703 = "2D " Select A).ToList
        Dim Datas_SH As List(Of PPS100LB.PPSCI7PF) = (From A In SourceData Where A.CI703 = "SH " Select A).ToList
        Dim Datas_NO1 As List(Of PPS100LB.PPSCI7PF) = (From A In SourceData Where A.CI703 = "NO1" Select A).ToList
        Dim HCRDatas As New List(Of PPS100LB.PPSCI7PF)
        Dim LCRDatas As New List(Of PPS100LB.PPSCI7PF)
        With ADDDataRow
            .Item("鋼種") = SourceData(0).CI701.Trim & " " & IIf(SourceData(0).CI705 = "X", "外銷", "內銷")
            HCRDatas = (From A In Datas_BA Where A.CI704 > " 0.80" Select A).ToList
            LCRDatas = (From A In Datas_BA Where A.CI704 <= " 0.80" Select A).ToList
            .Item("BA_HCR_產出率") = (From A In HCRDatas Select A.CI711).Sum / (From A In HCRDatas Select A.CI712).Sum
            .Item("BA_HCR_一級品率") = (From A In HCRDatas Select A.CI713).Sum / (From A In HCRDatas Select A.CI711).Sum
            .Item("BA_HCR_全程合格率") = Val(.Item("BA_HCR_產出率")) * Val(.Item("BA_HCR_一級品率"))
            .Item("BA_LCR_產出率") = (From A In LCRDatas Select A.CI711).Sum / (From A In LCRDatas Select A.CI712).Sum
            .Item("BA_LCR_一級品率") = (From A In LCRDatas Select A.CI713).Sum / (From A In LCRDatas Select A.CI711).Sum
            .Item("BA_LCR_全程合格率") = Val(.Item("BA_LCR_產出率")) * Val(.Item("BA_LCR_一級品率"))
            HCRDatas = (From A In Datas_2B Where A.CI704 > " 0.80" Select A).ToList
            LCRDatas = (From A In Datas_2B Where A.CI704 <= " 0.80" Select A).ToList
            .Item("I2B_HCR_產出率") = (From A In HCRDatas Select A.CI711).Sum / (From A In HCRDatas Select A.CI712).Sum
            .Item("I2B_HCR_一級品率") = (From A In HCRDatas Select A.CI713).Sum / (From A In HCRDatas Select A.CI711).Sum
            .Item("I2B_HCR_全程合格率") = Val(.Item("I2B_HCR_產出率")) * Val(.Item("I2B_HCR_一級品率"))
            .Item("I2B_LCR_產出率") = (From A In LCRDatas Select A.CI711).Sum / (From A In LCRDatas Select A.CI712).Sum
            .Item("I2B_LCR_一級品率") = (From A In LCRDatas Select A.CI713).Sum / (From A In LCRDatas Select A.CI711).Sum
            .Item("I2B_LCR_全程合格率") = Val(.Item("I2B_LCR_產出率")) * Val(.Item("I2B_LCR_一級品率"))


            .Item("I2D_產出率") = (From A In Datas_2D Select A.CI711).Sum / (From A In Datas_2D Select A.CI712).Sum
            .Item("I2D_一級品率") = (From A In Datas_2D Select A.CI713).Sum / (From A In Datas_2D Select A.CI711).Sum
            .Item("I2D_全程合格率") = Val(.Item("I2D_產出率")) * Val(.Item("I2D_一級品率"))

            .Item("SH_產出率") = (From A In Datas_SH Select A.CI711).Sum / (From A In Datas_SH Select A.CI712).Sum
            .Item("SH_一級品率") = (From A In Datas_SH Select A.CI713).Sum / (From A In Datas_SH Select A.CI711).Sum
            .Item("SH_全程合格率") = Val(.Item("SH_產出率")) * Val(.Item("SH_一級品率"))

            .Item("NO1_產出率") = (From A In Datas_NO1 Select A.CI711).Sum / (From A In Datas_NO1 Select A.CI712).Sum
            .Item("NO1_一級品率") = (From A In Datas_NO1 Select A.CI713).Sum / (From A In Datas_NO1 Select A.CI711).Sum
            .Item("NO1_全程合格率") = Val(.Item("NO1_產出率")) * Val(.Item("NO1_一級品率"))

            .Item("產出率合計") = (From A In SourceData Select A.CI711).Sum / (From A In SourceData Select A.CI712).Sum
            .Item("一級品率合計") = (From A In SourceData Select A.CI713).Sum / (From A In SourceData Select A.CI711).Sum
            .Item("全程合格率合計") = Val(.Item("產出率合計")) * Val(.Item("一級品率合計"))

        End With
        FormatDataRowDatas(ADDDataRow)
        ADDToDataTable.Rows.Add(ADDDataRow)
    End Sub

    Private Sub FormatDataRowDatas(ByVal SourceDataRow As DataRow)
        For Each EachColumn As DataColumn In SourceDataRow.Table.Columns

            Select Case True
                Case CType(SourceDataRow.Item(EachColumn), String).Trim = "不是一個數字"
                    SourceDataRow.Item(EachColumn) = ""
                Case EachColumn.ColumnName.Contains("全程") AndAlso CType(SourceDataRow.Item(EachColumn), Single) = 0
                    SourceDataRow.Item(EachColumn) = ""
                Case Single.TryParse(SourceDataRow.Item(EachColumn), Nothing)
                    SourceDataRow.Item(EachColumn) = Format(CType(SourceDataRow.Item(EachColumn), Single), "0.00%")
            End Select
        Next
    End Sub
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As String = "Select * From @#PPS100LB.PPSCI7PF WHERE 1=1 "

        Dim StartYearMonth As String = Format(Val(tbStartYear.Text), "000") & Format(Val(tbStartMonth.Text), "00")
        Dim EndYearMonth As String = Format(Val(tbEndYear.Text), "000") & Format(Val(tbEndMonth.Text), "00")
        ReturnValue &= " AND CI700>='" & StartYearMonth & "' AND CI700<='" & EndYearMonth & "'"
        Me.hfSQLString.Value = ReturnValue & " Order by CI701  ,CI705"
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim StartDate As DateTime = New Date(Now.Year, Now.Month, 1)
            Dim EndDate As DateTime = New Date(Now.Year, Now.Month, 1)
            tbStartYear.Text = Val(Format(StartDate, "yyyy")) - 1911
            tbStartMonth.Text = Format(StartDate, "MM")
            tbEndYear.Text = Val(Format(EndDate, "yyyy")) - 1911
            tbEndMonth.Text = Format(EndDate, "MM")
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Dim RightString As String = "期間:民國 " & Me.tbStartYear.Text.Trim & "年" & Me.tbStartMonth.Text.Trim & "月~" & Me.tbEndYear.Text.Trim & "年" & Me.tbEndMonth.Text.Trim & "月"
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("ReportDateRange", RightString)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()

    End Sub

    'Protected Sub tbSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearchToExcel.Click
    '    SetQryStringToControl()
    '    Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "鋼種面表合格率分析" & Format(Now, "mmss") & ".xls")
    '    ExcelConvert.DownloadEXCELFile(Me.Response)
    'End Sub

End Class