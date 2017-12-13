Public Partial Class AssetDepreciationForecastForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("AST01", "AST0103", Me)
    End Sub

End Class