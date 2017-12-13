Public Partial Class WebAuthorityMaster
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    '清理Session暫存值
    '    For Each EachItem As System.Web.UI.Control In Me.ContentPlaceHolder1.Controls
    '        If TypeOf EachItem Is WebMemberForWebGroup Then
    '            CType(EachItem, WebMemberForWebGroup).ClearBeforeSearchFilterInSession()
    '        End If
    '    Next
    '    Select Case Menu1.SelectedValue
    '        Case "1-1"
    '            Response.Redirect("~\WebSystem.aspx")
    '        Case "1-2"
    '            Response.Redirect("~\WebSystemFunction.aspx")
    '        Case "1-3"
    '            Response.Redirect("~\WebUser.aspx")
    '        Case "1-4"
    '            Response.Redirect("~\WebClientPC.aspx")
    '        Case "1-5"
    '            Response.Redirect("~\WebGroup.aspx")
    '        Case "2-1"
    '            Response.Redirect("~\WebUserAuthority.aspx")
    '        Case "2-2"
    '            Response.Redirect("~\WebUserAuthorityCopys.aspx")
    '        Case "2-3"
    '            Response.Redirect("~\WebClientPCAuthority.aspx")
    '        Case "3-1"
    '            Response.Redirect("~\WebMemberForGroup.aspx")
    '        Case "3-2"
    '            Response.Redirect("~\WebGroupAuthority.aspx")
    '        Case "4"
    '            Response.Redirect("~\WebUserOrIPAllAuthoritySearchForm.aspx")
    '        Case "999"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select

    'End Sub
End Class