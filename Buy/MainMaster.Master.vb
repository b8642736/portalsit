Public Class MainMaster
    Inherits System.Web.UI.MasterPage


    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    '鋼捲缺陷查詢
    '    Select Case True
    '        Case Menu1.SelectedItem.Text = "廠商進貨驗收資查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "BUY", "InStockCheckSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "原枓採購進貨資料查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "BUY", "MaterialBuyInComeSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "返回首頁"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select
    'End Sub

End Class