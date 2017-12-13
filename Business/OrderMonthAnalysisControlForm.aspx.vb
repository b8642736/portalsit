Public Partial Class OrderMonthAnalysisControlForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("BUS01", "BUS0110", Me)
    End Sub

End Class