Public Partial Class WebSystem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidAuthorityModule.ValidAuthoritySystem("Auth01", "Auth0101", Me)
    End Sub

End Class