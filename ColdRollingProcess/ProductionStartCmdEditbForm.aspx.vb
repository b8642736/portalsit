﻿Public Class ProductionStartCmdEditbForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("COLD01", "COLD0107", Me)
    End Sub

End Class