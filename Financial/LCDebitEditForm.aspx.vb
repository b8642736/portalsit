﻿Public Partial Class LCDebitEditForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("FIN01", "FIN0106", Me)
    End Sub

End Class