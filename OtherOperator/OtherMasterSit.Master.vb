Public Partial Class OtherMasterSit
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    Select Case Menu1.SelectedItem.Text
    '        Case "公佈欄編修"
    '            Response.Redirect("~\MessageBoard.aspx")
    '        Case "AS400SQL查詢"
    '            Response.Redirect("~\AS400SQLQueryForm.aspx")
    '        Case "AS400資料庫定義轉VB類別"
    '            Response.Redirect("~\AS400DBPFToVBClassForm.aspx")
    '        Case "SQLServer資料庫定義轉VB類別"
    '            Response.Redirect("~\SQLServerDBToVBClassForm.aspx")
    '        Case "檔案共享"
    '            Response.Redirect("~\FileSharedForm.aspx")
    '        Case "資料庫切換作業"
    '            Response.Redirect("~\DBConnectSwitchForm.aspx")
    '        Case "AS400與SQLServerDB轉檔"
    '            GoWebSitByWebAPPAuthority(Me.Page, "SQLVsAS400DataTransfer")
    '        Case "舊單位轉換新單位"
    '            Response.Redirect("~\OldDeptTransNewDeptForm.aspx")
    '        Case "回首頁"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select
    '    Response.Redirect("~\AS400SQLQueryForm.aspx")
    'End Sub

End Class