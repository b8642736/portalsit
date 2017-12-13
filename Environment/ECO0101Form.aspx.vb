Public Class ECO0101Form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("ECO01", "ECO0101", Me)
        Response.Redirect("http://10.1.4.19/GHG/")
    End Sub

End Class