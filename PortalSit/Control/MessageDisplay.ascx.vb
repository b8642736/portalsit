Public Partial Class MessageDisplay
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LDSMessageBoard_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSMessageBoard.Selecting
        e.Result = From A In DBDataContext.MessageBoard Where A.StartDateTime <= Now And Now <= A.EndDateTime.AddDays(1).AddSeconds(-1) Select A
    End Sub
End Class