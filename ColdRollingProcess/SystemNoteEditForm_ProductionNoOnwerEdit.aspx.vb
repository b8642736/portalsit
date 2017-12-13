Public Class SystemNoteEditForm_ProductionNoOnwerEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("COLD01", "COLD0118", Me)
        If Not IsPostBack Then
            Session("defaultSYSTEM_TYPE") = HttpUtility.UrlEncode("生計_無主庫存鋼捲")
        End If
    End Sub

End Class