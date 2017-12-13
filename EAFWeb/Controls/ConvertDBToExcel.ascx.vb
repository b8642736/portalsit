Public Partial Class ConvertDBToExcel
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.btStartDataDate.Text = Format(Now, "yyyy/MM/dd").ToString
            Me.btEndDataDate.Text = Me.btStartDataDate.Text
        End If

    End Sub

    Private Sub btStartDataDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btStartDataDate.TextChanged
        Me.btEndDataDate.Text = Me.btStartDataDate.Text
    End Sub

End Class