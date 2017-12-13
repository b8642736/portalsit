Public Partial Class MainMaster
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    Select Case True
    '        Case Menu1.SelectedItem.Text = "煉鋼即時通工作平台"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPIMClient", "SMPIMClient.application")
    '        Case Menu1.SelectedItem.Text = "分光儀儀器檢測資料查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "EquipmentCheckSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "氮氧儀儀器檢測資料查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "OXEquipmentCheckSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "碳硫儀儀器檢測資料查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "CSEquipmentCheckSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "樣本取樣品質統計表"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "SampleStatusReportForm.aspx")
    '        Case Menu1.SelectedItem.Text = "樣本取樣品質細目查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "SampleStatusDetailSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "成品輻射劑量檢測紀錄表"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "RadiationReportMakerForm.aspx")
    '        Case Menu1.SelectedItem.Text = "煉鋼配料排程編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "DosingScheduleEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "標準樣本上下限編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "StandSampleRangeEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "溫濕度編修"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "HumitureEditForm.aspx")
    '        Case Menu1.SelectedItem.Text = "儀器校驗記錄A"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "EquipmentCheckPrintForm.aspx")
    '        Case Menu1.SelectedItem.Text = "化驗報告單印表"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "SMPWork", "LaboratoryReportMakerForm.aspx")
    '        Case Menu1.SelectedItem.Text = "返回首頁"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select

    'End Sub
End Class