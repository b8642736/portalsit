Public Partial Class AS400SQLQueryForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("Other01", "Other0102", Me)
        Me.AS400SQLQuery1.IsCanDelteSearchRecords = WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem("Other01", "Other0103", Me.Request.UserHostAddress)
    End Sub

End Class