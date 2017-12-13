<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="AST500LB._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="資產移轉及狀態查詢" AuthorizePath="AST01@AST0101" 
        OpenControlPath="AST500LB@AssetTransferSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="折舊預測估算" AuthorizePath="AST01@AST0103" 
        OpenControlPath="AST500LB@AssetDepreciationForecastForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="固定資產保險明細查詢" AuthorizePath="AST01@AST0108" 
        OpenControlPath="AST500LB@InsuranceDetailSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
        CssClass="Button1" Text="當月資產重估年限查詢" AuthorizePath="AST01@AST0115" 
        OpenControlPath="AST500LB@AssetExtendUseEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />編修:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="固定資產移轉作業" AuthorizePath="AST01@AST0102" 
        OpenControlPath="AST500LB@AssetTransferUserForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="主設備與備品設備編修" AuthorizePath="AST01@AST0104" 
        OpenControlPath="AST500LB@MainSubAssetEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="資產保險查詢編修" AuthorizePath="AST01@AST0107" 
        OpenControlPath="AST500LB@InsuranceEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="固定資產報廢備註編修" AuthorizePath="AST01@AST0112" 
        OpenControlPath="AST500LB@AssetDeclareMemoEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton18" runat="server" 
        CssClass="Button1" Text="固定資產分割移轉編修" AuthorizePath="AST01@AST0118" 
        OpenControlPath="AST500LB@AssetSplitForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />報表:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="財產盤點清冊" AuthorizePath="AST01@AST0105" 
        OpenControlPath="AST500LB@InventoryForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
        CssClass="Button1" Text="資產保險續保調查表" AuthorizePath="AST01@AST0106" 
        OpenControlPath="AST500LB@ContinueInsuranceSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
        CssClass="Button1" Text="固定資產結存" AuthorizePath="AST01@AST0109" 
        OpenControlPath="AST500LB@CategorySumForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
        CssClass="Button1" Text="財產報廢單" AuthorizePath="AST01@AST0110" 
        OpenControlPath="AST500LB@DiscardReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
        CssClass="Button1" Text="財產驗收入帳單" AuthorizePath="AST01@AST0111" 
        OpenControlPath="AST500LB@AssetReceiptForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
        CssClass="Button1" Text="4.固定資增減月報表" AuthorizePath="AST01@AST0113" 
        OpenControlPath="AST500LB@AssetChangeReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
        CssClass="Button1" Text="5.固定資產折舊明細表" AuthorizePath="AST01@AST0114" 
        OpenControlPath="AST500LB@AssetDetailReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
        CssClass="Button1" Text="E.殘值使用年限重估表" AuthorizePath="AST01@AST0116" 
        OpenControlPath="AST500LB@AssetExtendUseReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
        CssClass="Button1" Text="F.每月單位累計折舊" AuthorizePath="AST01@AST0117" 
        OpenControlPath="AST500LB@DepreciationSumByDeptReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton19" runat="server" 
        CssClass="Button1" Text="資訊專用資產移轉作業" AuthorizePath="AST01@AST0119" 
        OpenControlPath="AST500LB@MISAssetTransferEditForm.aspx" 
        AutoValidMode="VaildToVisible" />
</asp:Content>
