Public Class YieldRateSearch2Form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("QTYCTL01", "QTYCTL0120", Me)
    End Sub

End Class