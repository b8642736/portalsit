﻿Public Class MailMsgEditForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("SMPWRK01", "SMPWRK0113", Me)
    End Sub

End Class