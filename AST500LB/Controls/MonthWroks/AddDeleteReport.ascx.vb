Public Class AddDeleteReport
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal QryString As String) As AST500LB.AST500LBDataSet.AddDeleteReportDataTable
        Dim ReturnValue = New AST500LB.AST500LBDataSet.AddDeleteReportDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        For EachCount = 1 To 70
            Dim AddItem As AST500LB.AST500LBDataSet.AddDeleteReportRow = ReturnValue.NewRow
            With AddItem
                .增減 = IIf(EachCount Mod 2 = 1, "增", "減")
                .財產統一編號 = EachCount
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
        'If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
        '    Return New List(Of CompanyORMDB.AST501LB.AST001PF)
        'End If
        'Return CompanyORMDB.AST501LB.AST001PF.CDBSelect(Of CompanyORMDB.AST501LB.AST001PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As String = Nothing
        SQLString = " Select A.* From @#AST501LB.AST001PF.ASTF  A ORDER BY A.CODE "
        Me.hfQuery.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        'Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        'Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("SignDeps", GetSignDeps)
        'ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()

    End Sub
End Class