Public Class MaterialBuyInComeSearchForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("BUY01", "BUY0102", Me)
    End Sub

End Class