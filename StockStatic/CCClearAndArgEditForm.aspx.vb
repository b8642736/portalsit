﻿Public Class CCClearAndArgEditForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("Stock01", "Stock0105", Me)
    End Sub

End Class