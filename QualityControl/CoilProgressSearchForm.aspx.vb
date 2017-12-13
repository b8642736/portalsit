Public Class CoilProgressSearchForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("QTYCTL01", "QTYCTL0113", Me)
    End Sub

End Class