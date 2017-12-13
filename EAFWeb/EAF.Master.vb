Public Partial Class EAF
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Select Case True
            Case Menu1.SelectedItem.Text = "返回首頁"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
        End Select
    End Sub
End Class