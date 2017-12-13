Public Class DailyReportMaker
    Dim DBContext As New EAFClassesDataContext
    Private Sub btnCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
        'Me.BSDailyReport.DataSource = From A In DBContext.EAFT1 Where A.StoveNumber >= "A3854" And A.StoveNumber <= "A3856" Select A
        Me.EAFT1ReportTempBindingSource.DataSource = From A In DBContext.EAFT1 Select A
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
