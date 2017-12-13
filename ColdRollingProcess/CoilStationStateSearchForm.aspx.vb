Imports System.Threading

Public Class CoilStationStateSearchForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("COLD01", "COLD0105", Me)
    End Sub

End Class