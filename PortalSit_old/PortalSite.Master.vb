Public Partial Class PortalSite
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    End Sub


    Private Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Select Case True
            Case e.Item.Text = "分光室作業"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMP")
            Case e.Item.Text = "分光室工作區"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork")
            Case e.Item.Text = "EAF作業"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "EAFWeb")
            Case e.Item.Text = "品管組"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl")
            Case e.Item.Text = "庫存統計"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "StockStatic")
            Case e.Item.Text = "冷軋現場作業"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "ColdRollingProcess")
            Case e.Item.Text = "會計系統"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "Accounting", "Default.aspx")
            Case e.Item.Text = "財務"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "Financial")
            Case e.Item.Text = "業務"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "Business", "Default.aspx")
            Case e.Item.Text = "固定資產"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "AST500LB", "Default.aspx")
            Case e.Item.Text = "即時通訊系統"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "IM", "Default.aspx")
            Case e.Item.Text = "其它作業"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "OtherOperator", "Default.aspx")
            Case e.Item.Text = "系統權限管理"
                WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "WebAppAuthority")
        End Select
    End Sub
End Class