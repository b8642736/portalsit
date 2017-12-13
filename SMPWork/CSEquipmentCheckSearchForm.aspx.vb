Public Partial Class CSEquipmentCheckSearchForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("SMPWRK01", "SMPWRK0101", Me)
    End Sub

End Class