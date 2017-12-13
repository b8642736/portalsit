Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim DBContext As New CompanyLINQDB.EAFDataContext
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("EAF01", "EAF0101", Me)

        'Me.CrystalReportSource1.Report.DataSources = (From A In DBContext.EAFT1 Select A)
        'Me.CrystalReportSource1.ReportDocument.SetDataSource((From A In DBContext.EAFT1 Select A).ToArray)
        'Me.CrystalReportSource1.ReportDocument.SetDataSource(From A In DBContext.EAFT1 Select A)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Select Case RadioButtonList1.SelectedValue
            Case "0"
                Me.MultiView1.SetActiveView(Me.ReportView)
            Case "1"
                Me.MultiView1.SetActiveView(Me.MoniterSoftView)
        End Select
    End Sub
End Class