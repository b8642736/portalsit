﻿Public Class AssetDeclareMemoEditForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("AST01", "AST0112", Me)
    End Sub

End Class