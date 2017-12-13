Public Class DepreciationSumByDeptReport
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString1 As String) As AST500LBDataSet.DepreciationSumByDeptReportDataTable
        Dim ReturnValue As AST500LBDataSet.DepreciationSumByDeptReportDataTable = New AST500LBDataSet.DepreciationSumByDeptReportDataTable
        If String.IsNullOrEmpty(QryString1) Then
            Return ReturnValue
        End If

        Dim AddRow As AST500LBDataSet.DepreciationSumByDeptReportRow
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = DBService.SelectQuery(QryString1)
        Dim Rowgroup1 As List(Of DataRow)
        Dim Rowgroup2 As List(Of DataRow)
        Dim Rowgroup3 As List(Of DataRow)
        For Each EachAssetState As String In (From A In SearchResult.Rows Select ACD2 = CType(A.ITEM("ACD2"), String) Order By ACD2).Distinct
            Rowgroup1 = (From A In SearchResult.Rows Where CType(A.item("ACD2"), String) = EachAssetState Select CType(A, DataRow)).ToList
            For Each EachAssetKind As String In (From A In Rowgroup1 Select CType(A.Item("NUMBER"), String).Substring(0, 1)).Distinct
                Rowgroup2 = (From A In Rowgroup1 Where A.Item("NUMBER").Substring(0, 1) = EachAssetKind Select A).ToList
                For Each EachDEPTSA As String In (From A In Rowgroup2 Select DEPTSA = CType(A.Item("DEPTSA"), String) Order By DEPTSA).Distinct
                    Rowgroup3 = (From A In Rowgroup2 Where A.Item("DEPTSA") = EachDEPTSA Select A).ToList
                    AddRow = ReturnValue.NewRow
                    With AddRow
                        Select Case EachAssetState.Trim
                            Case ""
                                .資產狀態 = "正常"
                            Case "A"
                                .資產狀態 = "閒置"
                            Case "B"
                                .資產狀態 = "出租"
                            Case Else
                                .資產狀態 = "未知"
                        End Select
                        .資產類別 = EachAssetKind
                        .單位代號 = EachDEPTSA
                        .本月折舊 = Format((From A In Rowgroup3 Select CType(A.Item("DEPR"), Double) - CType(A.Item("PREMONTHDEPR"), Double)).Sum, "0,0.00")
                        .帳面金額 = Format((From A In Rowgroup3 Select CType(A.Item("AMOUNT"), Double)).Sum, "0,0.00")
                        .累計折舊 = Format((From A In Rowgroup3 Select CType(A.Item("DEPR"), Double)).Sum, "0,0.00")
                    End With
                    ReturnValue.Rows.Add(AddRow)
                Next
                '類別小計
                AddRow = ReturnValue.NewRow
                With AddRow
                    Select Case EachAssetState.Trim
                        Case ""
                            .資產狀態 = "正常"
                        Case "A"
                            .資產狀態 = "閒置"
                        Case "B"
                            .資產狀態 = "出租"
                        Case Else
                            .資產狀態 = "未知"
                    End Select
                    .資產類別 = ""
                    .單位代號 = "單位小計:"
                    .本月折舊 = Format((From A In Rowgroup2 Select CType(A.Item("DEPR"), Double) - CType(A.Item("PREMONTHDEPR"), Double)).Sum, "0,0.00")
                    .帳面金額 = Format((From A In Rowgroup2 Select CType(A.Item("AMOUNT"), Double)).Sum, "0,0.00")
                    .累計折舊 = Format((From A In Rowgroup2 Select CType(A.Item("DEPR"), Double)).Sum, "0,0.00")
                End With
                ReturnValue.Rows.Add(AddRow)
            Next
            '單位小計
            AddRow = ReturnValue.NewRow
            With AddRow
                Select Case EachAssetState.Trim
                    Case ""
                        .資產狀態 = "正常"
                    Case "A"
                        .資產狀態 = "閒置"
                    Case "B"
                        .資產狀態 = "出租"
                    Case Else
                        .資產狀態 = "未知"
                End Select
                .資產類別 = "類別小計:"
                .單位代號 = ""
                .本月折舊 = Format((From A In Rowgroup1 Select CType(A.Item("DEPR"), Double) - CType(A.Item("PREMONTHDEPR"), Double)).Sum, "0,0.00")
                .帳面金額 = Format((From A In Rowgroup1 Select CType(A.Item("AMOUNT"), Double)).Sum, "0,0.00")
                .累計折舊 = Format((From A In Rowgroup1 Select CType(A.Item("DEPR"), Double)).Sum, "0,0.00")
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        '總計
        AddRow = ReturnValue.NewRow
        With AddRow
            .資產狀態 = "總計:"
            .資產類別 = ""
            .單位代號 = ""
            .本月折舊 = Format((From A In SearchResult.Rows Select CType(A.Item("DEPR"), Double) - CType(A.Item("PREMONTHDEPR"), Double)).Sum, "0,0.00")
            .帳面金額 = Format((From A In SearchResult.Rows Select CType(A.Item("AMOUNT"), Double)).Sum, "0,0.00")
            .累計折舊 = Format((From A In SearchResult.Rows Select CType(A.Item("DEPR"), Double)).Sum, "0,0.00")
        End With
        ReturnValue.Rows.Add(AddRow)
        Return ReturnValue
    End Function
#End Region
#Region "計算合計結果至報表參數 函式:SubTotalToReportParameter"
    Private Sub SubTotalToReportParameter(ByVal SourceReport As Microsoft.Reporting.WebForms.Report)
        Dim TitleArg1 As New StringBuilder
        TitleArg1.Append("報表建立時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss"))
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleString", TitleArg1.ToString)
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
        SQLString1 = "Select A.* , B.DEPTSA, C.DEPR PREMONTHDEPR From @#AST500LB.AST101PF.ASTFSA A LEFT JOIN @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER AND B.SEQ=1 Left JOIN @#AST500LB.AST201PF.ASTFSA C ON A.NUMBER=C.NUMBER Order by A.NUMBER"
        Me.hfQry.Value = SQLString1
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