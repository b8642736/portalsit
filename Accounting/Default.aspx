<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Accounting._Default" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢:<BR/>
    <cc1:ucauthorizebutton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="固定資產折舊查詢" AuthorizePath="ACC01@ACC0101" 
        OpenControlPath="Accounting@DepreciationSearch.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="費用科目金額合計查詢" AuthorizePath="ACC01@ACC0104" 
        OpenControlPath="Accounting@ExpenseSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="費用科目細目金額查詢" AuthorizePath="ACC01@ACC0105" 
        OpenControlPath="Accounting@ExpenseDetailSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton11" runat="server" 
        CssClass="Button1" Text="單位費用細目金額查詢" AuthorizePath="ACC01@ACC0107" 
        OpenControlPath="Accounting@ExpenseOfDepartmentForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton12" runat="server" 
        CssClass="Button1" Text="製成品淨變現價值統計" AuthorizePath="ACC01@ACC0108" 
        OpenControlPath="Accounting@ProductCashStatisticsForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton13" runat="server" 
        CssClass="Button1" Text="製成品庫存成本統計" AuthorizePath="ACC01@ACC0109" 
        OpenControlPath="Accounting@ProductStockCostStatisticsForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
        <cc1:ucauthorizebutton ID="ucAuthorizeButton14" runat="server" 
        CssClass="Button1" Text="軋鋼在製品庫存統計" AuthorizePath="ACC01@ACC0110" 
        OpenControlPath="Accounting@ProductManufactureCostStatisticsForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
        <cc1:ucauthorizebutton ID="ucAuthorizeButton15" runat="server" 
        CssClass="Button1" Text="鋼捲線上成本查詢" AuthorizePath="ACC01@ACC0111" 
        OpenControlPath="Accounting@CoilCostSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />

    <BR />編輯:<BR/>
    <cc1:ucauthorizebutton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="非消耗物品編輯" AuthorizePath="ACC01@ACC0103" 
        OpenControlPath="Accounting@NonConsumFAMEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />零用金作業:<BR/>
    <cc1:ucauthorizebutton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="單位代碼維護成業" AuthorizePath="ACC01@ACC0102" 
        OpenControlPath="Accounting@CashDepartment.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="現金支出作業" AuthorizePath="ACC01@ACC0102" 
        OpenControlPath="Accounting@CashPay.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="報銷/年初開立 支票作業" AuthorizePath="ACC01@ACC0102" 
        OpenControlPath="Accounting@CashTicket.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />零用金作業報表:<BR/>
    <cc1:ucauthorizebutton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="現金出納備查記錄表" AuthorizePath="ACC01@ACC0102" 
        OpenControlPath="Accounting@PCashInOutPrint.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton9" runat="server" 
        CssClass="Button1" Text="零用金報銷撥補清單" AuthorizePath="ACC01@ACC0102" 
        OpenControlPath="Accounting@PCashVerificationPrint.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br />
    電子表單:<br />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton10" runat="server" 
        CssClass="Button1" Text="表單會計科目選擇設定" AuthorizePath="ACC01@ACC0106" 
        OpenControlPath="Accounting@SPMAccDepSelectEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
</asp:Content>
