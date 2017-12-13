Public Partial Class MainMaster
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    '站台群組對應站台()
    '    '站台對應站台使用者()
    '    '站台群組結構調整()

    '    '訊息編修()
    '    '鋼捲缺陷查詢
    '    Select Case True
    '        Case Menu1.SelectedItem.Text = "1.訊息定義編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "MessageEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "2.站台編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "SiteEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "3.站台群組編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "SiteGroupEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "4.站台使用者編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "SiteUserEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "5.站台群組對應站台"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "SiteGroupToSiteEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "6.站台群組對應訊息定義"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "SiteGroupToMessageEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "發送訊息"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "MessageSenderForm.aspx")
    '        Case Menu1.SelectedItem.Text = "用戶設定即時通知變更"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "RemoteClentPCConfigForm.aspx")
    '        Case Menu1.SelectedItem.Text = "返回首頁"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select
    'End Sub
End Class