Public Partial Class DailyReportMaker
    Inherits System.Web.UI.UserControl
    Dim DataContext As New CompanyLINQDB.EAFDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.HFIsDStartSearchData.Value = False
            Me.txStartDate.Text = Format(Today, "yyyy/MM/dd")
            Me.txEndDate.Text = Format(Today.AddDays(1).AddSeconds(-1), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Panel1.Visible = (Me.RadioButtonList1.SelectedValue = "2")
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub LDSEAFDataSrouce_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEAFDataSrouce.Selecting
        Select Case Me.RadioButtonList1.SelectedValue
            Case "0"
                e.Result = (From A In DataContext.EAFT1 Where Me.HFIsDStartSearchData.Value = "True" And A.DataDate >= Today And A.DataDate < Today.AddDays(1) Select A)
            Case "1"
                e.Result = (From A In DataContext.EAFT1 Where Me.HFIsDStartSearchData.Value = "True" And A.DataDate >= Today.AddDays(-1) And A.DataDate < Today Select A)
            Case "2"
                e.Result = (From A In DataContext.EAFT1 Where Me.HFIsDStartSearchData.Value = "True" And A.DataDate >= CType(Me.txStartDate.Text, DateTime) And A.DataDate < CType(Me.txEndDate.Text, DateTime).AddDays(1) Select A)
            Case Else
                e.Result = (From A In DataContext.EAFT1 Where Me.HFIsDStartSearchData.Value = "True" Select A)
        End Select

    End Sub

    Private Sub btnCreateReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
        Me.HFIsDStartSearchData.Value = True
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class