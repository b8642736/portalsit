﻿Public Class InStockCheckSearchForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("BUY01", "BUY0101", Me)
    End Sub

End Class