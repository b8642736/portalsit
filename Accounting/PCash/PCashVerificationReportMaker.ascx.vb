Public Partial Class PCashVerificationReportMaker
    Inherits System.Web.UI.UserControl

    Dim DataContext As New CompanyLINQDB.PCashDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TextBox1.Text = Format(Now, "yyyy")
            Me.TextBox2.Text = Nothing
        End If
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.TextBox1.Text = Format(Now, "yyyy")
        Me.TextBox2.Text = Nothing
        Me.GridView1.DataBind()
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        Dim Result As IQueryable(Of PCash2) = From A In DataContext.PCash2 Where A.IsNewYearStartTicket = False Select A
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.RecDate >= New DateTime(Val(TextBox1.Text), 1, 1) And A.RecDate < New DateTime(Val(TextBox1.Text), 1, 1).AddYears(1) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.Number = Val(TextBox2.Text) Select A)
        e.Result = Result
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.HFSetRecDate.Value = CType(GridView1.SelectedDataKey.Item(0), String)
        Me.HFSetNumber.Value = GridView1.SelectedDataKey.Item(1)
        Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TableNumber", Me.HFSetNumber.Value)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
        TabPanel2.Visible = True
        Me.TabContainer1.ActiveTab = TabPanel2
    End Sub

    Protected Sub LDSPrintDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSPrintDataSource.Selecting
        If String.IsNullOrEmpty(Me.HFSetRecDate.Value) OrElse String.IsNullOrEmpty(Me.HFSetNumber.Value) Then
            Exit Sub
        End If
        e.Result = From A In DataContext.PCash1 Where (From B In DataContext.PCash3 Where B.PC2RecDate = CType(Me.HFSetRecDate.Value, DateTime) And B.PC2Number = Val(Me.HFSetNumber.Value) Select B.PC1RecDate.ToString + B.PC1Number.ToString).Contains(A.RecDate.ToString + A.Number.ToString) Select A Order By A.Number, A.RecDate
    End Sub
End Class