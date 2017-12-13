Public Class ProductManufactureCostStatisticsForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("ACC01", "ACC0110", Me)
    End Sub

End Class