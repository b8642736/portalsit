Public Class SystemNoteEditForm_WebAppAuthority_CCMail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("Auth01", "Auth0107", Me)
        If Not IsPostBack Then
            Session("defaultSYSTEM_TYPE") = HttpUtility.UrlEncode("CCMail")
        End If
    End Sub


End Class