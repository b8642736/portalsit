Public Partial Class MainMaster
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    WebAppAuthority.FilterAuthorityMenu(Me.Page, Me.Menu1)
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
    '    '鋼捲缺陷查詢
    '    Select Case True
    '        Case Menu1.SelectedItem.Text = "鋼捲缺陷查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilDefectSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲主要缺陷查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "MainDefectSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "待熱軋鋼胚查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "SLABBeforeOutElementSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲實際寬度查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilRealWidthSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "委託加工鋼捲缺陷查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilDefectEntrustSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "外購鋼捲缺陷查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilDefectPurchaseSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "爐號成份查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "StoveElementSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "SQLServer爐號成份查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "SQLServerStoveElementSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲產線寬厚查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilLineWidthHeightSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "黑皮鋼捲資料查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "BlackCoilSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼種面表合格率分析"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "SteelKindFaceOutRateAnalysisForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲產出率查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "YieldRateSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲生產進度查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilProgressSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "SQLServer煉鋼成份管制查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "SQLServerElementControlSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "物理性能查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "NatureAttributeSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "熱軋品管查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "HotRollingSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "鋼捲等級重量查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "CoilLevelWeightSearchForm.aspx")
    '        Case Menu1.SelectedItem.Text = "成品鋼捲等級重量查詢"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "ProductBugWeightSearchForm.aspx")
    '            '內銷一級品率檢討
    '        Case Menu1.SelectedItem.Text = "成品一級品率檢討"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "QualityControl", "HomeSellReviewForm.aspx")
    '        Case Menu1.SelectedItem.Text = "返回首頁"
    '            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(Me.Page, "PortalSit")
    '    End Select
    'End Sub
End Class