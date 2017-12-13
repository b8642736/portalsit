Public Partial Class SampleStatusReport
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SearchStation"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
  Public Function Search(ByVal SearchStation As String, ByVal StartDate As Date, ByVal EndDate As Date) As SMPWork.ReportUseDataSet.SampleStatusDataTableDataTable
        Dim DBDataContext As New CompanyLINQDB.SMPDataContext
        Dim ReturnValue As New ReportUseDataSet.SampleStatusDataTableDataTable
        Dim SearchStartDate As Integer = Format(StartDate, "yyyy") - 1911 & Format(StartDate, "MMdd")
        Dim SearchEndDate As Integer = Format(EndDate, "yyyy") - 1911 & Format(EndDate, "MMdd")
        Dim GetDatas As List(Of CompanyLINQDB.取樣品質) = (From A In DBDataContext.取樣品質 Where A.IsDeleted = False And A.日期 >= SearchStartDate And A.日期 <= SearchEndDate And (SearchStation = "ALL" Or A.站別 = SearchStation) And (A.站別.Trim = "A1" Or A.站別.Trim = "C1" Or A.站別.Trim = "E1" Or A.站別.Trim = "E2" Or A.站別.Trim = "L1") Select A Order By A.站別, A.取樣品質代碼).ToList

        For Each EachStationName As String In (From A In GetDatas Select A.站別.Trim).Distinct

            Dim FindStationName As String = EachStationName
            Dim StationDatas As List(Of CompanyLINQDB.取樣品質) = (From A In GetDatas Where A.站別 = FindStationName Select A).ToList
            Dim NormalCount As Integer = (From A In StationDatas Where A.取樣品質代碼 = 1 Select A).Count
            Dim TooShortCount As Integer = (From A In StationDatas Where A.取樣品質代碼 = 2 Select A).Count
            Dim SShortDregs As Integer = (From A In StationDatas Where A.取樣品質代碼 = 3 Select A).Count
            Dim MShortDregs As Integer = (From A In StationDatas Where A.取樣品質代碼 = 4 Select A).Count
            Dim LShortDregs As Integer = (From A In StationDatas Where A.取樣品質代碼 = 5 Select A).Count
            Dim SRift As Integer = (From A In StationDatas Where A.取樣品質代碼 = 6 Select A).Count
            Dim MRift As Integer = (From A In StationDatas Where A.取樣品質代碼 = 7 Select A).Count
            Dim LRift As Integer = (From A In StationDatas Where A.取樣品質代碼 = 8 Select A).Count
            Dim SGasHole As Integer = (From A In StationDatas Where A.取樣品質代碼 = 9 Select A).Count
            Dim MGasHole As Integer = (From A In StationDatas Where A.取樣品質代碼 = 10 Select A).Count
            Dim LGasHole As Integer = (From A In StationDatas Where A.取樣品質代碼 = 11 Select A).Count
            Dim Repeat As Integer = (From A In StationDatas Where A.取樣品質代碼 = 12 Select A).Count
            Dim Alteration As Integer = (From A In StationDatas Where A.取樣品質代碼 = 13 Select A).Count
            Dim CaliberTooShort As Integer = (From A In StationDatas Where A.取樣品質代碼 = 14 Select A).Count
            Dim BigDifferent As Integer = (From A In StationDatas Where A.取樣品質代碼 = 15 Select A).Count
            Dim SampleIsCold As Integer = (From A In StationDatas Where A.取樣品質代碼 = 16 Select A).Count
            Dim SampleTransError As Integer = (From A In StationDatas Where A.取樣品質代碼 = 17 Select A).Count
            For DefectKind As Integer = 1 To 11
                Dim AddRow As SMPWork.ReportUseDataSet.SampleStatusDataTableRow = ReturnValue.NewRow
                With AddRow
                    .站別 = FindStationName
                    Select Case DefectKind
                        Case 1
                            .缺陷 = "正常"
                            .數量小計 = NormalCount
                        Case 2
                            .缺陷 = "太短"
                            .數量小計 = TooShortCount
                        Case 3
                            .缺陷 = "夾渣"
                            .數量小計 = SShortDregs + MShortDregs + LShortDregs
                            .輕數量 = SShortDregs
                            .中數量 = MShortDregs
                            .重數量 = LShortDregs
                            If .數量小計 > 0 Then
                                .輕百分比 = Format(SShortDregs / StationDatas.Count, "0.00%")
                                .中百分比 = Format(MShortDregs / StationDatas.Count, "0.00%")
                                .重百分比 = Format(LShortDregs / StationDatas.Count, "0.00%")
                            Else
                                .輕百分比 = "0.00%"
                                .中百分比 = "0.00%"
                                .重百分比 = "0.00%"
                            End If
                        Case 4
                            .缺陷 = "裂痕"
                            .數量小計 = SRift + MRift + LRift
                            .輕數量 = SRift
                            .中數量 = MRift
                            .重數量 = LRift
                            If .數量小計 > 0 Then
                                .輕百分比 = Format(SRift / StationDatas.Count, "0.00%")
                                .中百分比 = Format(MRift / StationDatas.Count, "0.00%")
                                .重百分比 = Format(LRift / StationDatas.Count, "0.00%")
                            Else
                                .輕百分比 = "0.00%"
                                .中百分比 = "0.00%"
                                .重百分比 = "0.00%"
                            End If
                        Case 5
                            .缺陷 = "氣孔"
                            .數量小計 = SGasHole + MGasHole + LGasHole
                            .輕數量 = SGasHole
                            .中數量 = MGasHole
                            .重數量 = LGasHole
                            If .數量小計 > 0 Then
                                .輕百分比 = Format(SGasHole / StationDatas.Count, "0.00%")
                                .中百分比 = Format(MGasHole / StationDatas.Count, "0.00%")
                                .重百分比 = Format(LGasHole / StationDatas.Count, "0.00%")
                            Else
                                .輕百分比 = "0.00%"
                                .中百分比 = "0.00%"
                                .重百分比 = "0.00%"
                            End If
                        Case 6
                            .缺陷 = "重取"
                            .數量小計 = Repeat
                        Case 7
                            .缺陷 = "樣品變型"
                            .數量小計 = Alteration
                        Case 8
                            .缺陷 = "直徑太小"
                            .數量小計 = CaliberTooShort
                        Case 9
                            .缺陷 = "分析差異過大"
                            .數量小計 = BigDifferent
                        Case 10
                            .缺陷 = "收樣已冷卻"
                            .數量小計 = SampleIsCold
                        Case 11
                            .缺陷 = "輸送設備異常"
                            .數量小計 = SampleTransError
                    End Select
                    If .數量小計 > 0 Then
                        .數量小計百分比 = Format(.數量小計 / StationDatas.Count, "0.00%")
                    Else
                        .數量小計百分比 = "0.00%"
                    End If
                End With
                ReturnValue.Rows.Add(AddRow)
            Next
            Dim AddSmallCountRow As SMPWork.ReportUseDataSet.SampleStatusDataTableRow = ReturnValue.NewRow
            With AddSmallCountRow
                .站別 = FindStationName & "小計:"
                .缺陷 = "正常:" & Format(NormalCount / StationDatas.Count, "0.00%") & vbNewLine & "缺陷:" & Format((StationDatas.Count - NormalCount) / StationDatas.Count, "0.00%")
                .輕數量 = SShortDregs + SRift + SGasHole
                .中數量 = MShortDregs + MRift + MGasHole
                .重數量 = LShortDregs + LRift + LGasHole
                If StationDatas.Count > 0 Then
                    .輕百分比 = Format(.輕數量 / StationDatas.Count, "0.00%")
                    .中百分比 = Format(.中數量 / StationDatas.Count, "0.00%")
                    .重百分比 = Format(.重數量 / StationDatas.Count, "0.00%")
                    .數量小計百分比 = Format(StationDatas.Count / GetDatas.Count, "0.00%")
                Else
                    .輕百分比 = "0.00%"
                    .中百分比 = "0.00%"
                    .重百分比 = "0.00%"
                    .數量小計百分比 = "0.00%"
                End If
                .數量小計 = StationDatas.Count
            End With
            ReturnValue.Rows.Add(AddSmallCountRow)
        Next
        Dim AddTotalCountRow As SMPWork.ReportUseDataSet.SampleStatusDataTableRow = ReturnValue.NewRow
        Dim TotalNormalCount As Integer = (From A In GetDatas Where A.取樣品質代碼 = 1 Select A).Count
        With AddTotalCountRow
            .站別 = "總小計:"
            .缺陷 = "正常:" & Format(TotalNormalCount / GetDatas.Count, "0.00%") & vbNewLine & "缺陷:" & Format((GetDatas.Count - TotalNormalCount) / GetDatas.Count, "0.00%")
            .輕數量 = (From A In GetDatas Where A.取樣品質代碼 = 3 Or A.取樣品質代碼 = 6 Or A.取樣品質代碼 = 9 Select A).Count
            .中數量 = (From A In GetDatas Where A.取樣品質代碼 = 4 Or A.取樣品質代碼 = 7 Or A.取樣品質代碼 = 10 Select A).Count
            .重數量 = (From A In GetDatas Where A.取樣品質代碼 = 5 Or A.取樣品質代碼 = 8 Or A.取樣品質代碼 = 11 Select A).Count
            If GetDatas.Count > 0 Then
                .輕百分比 = Format(.輕數量 / GetDatas.Count, "0.00%")
                .中百分比 = Format(.中數量 / GetDatas.Count, "0.00%")
                .重百分比 = Format(.重數量 / GetDatas.Count, "0.00%")
            Else
                .輕百分比 = "0.00%"
                .中百分比 = "0.00%"
                .重百分比 = "0.00%"
            End If
            .數量小計 = GetDatas.Count
        End With
        ReturnValue.Rows.Add(AddTotalCountRow)

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
            ReportViewer1.Visible = value
        End Set
    End Property
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Now.Date.AddDays(-1)
            tbEndDate.Text = Now.Date
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TimeRange", Me.tbStartDate.Text & " ~ " & Me.tbEndDate.Text)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()

    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub
End Class