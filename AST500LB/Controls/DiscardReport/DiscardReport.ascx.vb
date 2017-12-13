Public Class DiscardReport
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    'Public Function Search() As List(Of AST500LBDataSet.DiscardReportRow)

    'End Function
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As AST500LBDataSet.DiscardReportDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New AST500LBDataSet.DiscardReportDataTable
        End If
        Dim ReturnValue As New AST500LBDataSet.DiscardReportDataTable
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery(QryString)
        Dim AddRow As AST500LBDataSet.DiscardReportRow
        For Each EachItem As DataRow In SearchResult.Rows
            AddRow = ReturnValue.NewRow
            With AddRow
                .分類編號 = EachItem.Item("Number")
                .名稱 = Trim(EachItem.Item("NAME"))
                '.特徵說明 = EachItem.Item("")
                .單位 = EachItem.Item("UNIT")
                If Val(EachItem.Item("QUANT")) = 0 Then
                    .單價 = EachItem.Item("AMOUNT")
                Else
                    .單價 = Format(Val(EachItem.Item("AMOUNT")) / Val(EachItem.Item("QUANT")), "#,#.00")
                End If
                .數量 = EachItem.Item("QUANT")
                .價值 = Format(Val(EachItem.Item("AMOUNT")), "#,#.00")
                .入帳年月 = EachItem.Item("DATE")
                .耐用年限 = EachItem.Item("USLAFF")
                .已提折舊數額 = Format(Val(EachItem.Item("DEPR")), "#,#.00")
                .報廢原因 = EachItem.Item("FACT1")
                .殘餘價值 = Format(Val(EachItem.Item("AMOUNT")) - Val(EachItem.Item("DEPR")), "#,#.00")
                .備註 = Trim(EachItem.Item("FACT2"))
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        AddRow = ReturnValue.NewRow
        With AddRow
            .名稱 = "合計:"
            .價值 = Format((From A In SearchResult Select Val(A.Item("AMOUNT"))).Sum, "#,#.00")
            .已提折舊數額 = Format((From A In SearchResult Select Val(A.Item("DEPR"))).Sum, "#,#.00")
            .殘餘價值 = Format((From A In SearchResult Select Val(A.Item("AMOUNT"))).Sum - (From A In SearchResult Select Val(A.Item("DEPR"))).Sum, "#,#.00")
        End With
        ReturnValue.Rows.Add(AddRow)

        'If (31 - SearchResult.Rows.Count) > 0 Then      '加入空白列，美觀用
        '    For i As Integer = 1 To (31 - SearchResult.Rows.Count)
        '        AddRow = ReturnValue.NewRow
        '        ReturnValue.Rows.Add(AddRow)
        '    Next
        'End If

        Return ReturnValue
    End Function
#End Region

#Region "取得審核單位 方法:GetSignDeps"
    ''' <summary>
    ''' 取得審核單位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSignDeps() As String
        Dim ReturnValue As String = "行政處@企劃處@會計處@副總經理"
        Dim SearchReslut As AST500LBDataSet.DiscardReportDataTable = Search(Me.hfQry.Value)
        'Dim IsOver1Million As Boolean = False
        Dim IsNotOverEndCanUseDate As Boolean = False
        Dim ThisYearMonth As Integer = (Val(Format(Now, "yyyy")) - 1911) * 100 + Val(Format(Now, "MM"))
        For Each EachItem As AST500LBDataSet.DiscardReportRow In SearchReslut.Rows
            If EachItem.Is名稱Null OrElse EachItem.名稱.Substring(0, 2) = "合計" Then
                Exit For
            End If
            'If Val(EachItem.價值.Replace(",", "")) >= 1000000 Then
            '    IsOver1Million = True
            'End If
            If (Val(EachItem.入帳年月) + Val(EachItem.耐用年限) * 100) > ThisYearMonth Then
                IsNotOverEndCanUseDate = True
            End If
        Next
        Select Case True
            Case IsNotOverEndCanUseDate
                ReturnValue &= "@總經理@董事長"
                'Case IsOver1Million
                '    ReturnValue &= "@總經理@"
            Case Else
                'ReturnValue &= "@@"
                ReturnValue &= "@總經理@"
        End Select
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As String = "Select A.* , B.* , C.DEPTSA From  @#AST500LB.AST101PH A LEFT JOIN  @#AST500LB.AST101PF.ASTFSA B ON A.NUMBER=B.NUMBER AND A.DEPT=B.DEPT LEFT JOIN  @#AST500LB.AST106PF.ASTFSA C  ON A.NUMBER=C.NUMBER AND C.SEQ=1 "
        Me.hfQry.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        MakQryStringToControl()
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("SignDeps", GetSignDeps)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class