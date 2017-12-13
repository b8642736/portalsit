<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="StockStatic._Default" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="鋼胚庫存查詢" AuthorizePath="Stock01@Stock0101" 
        OpenControlPath="StockStatic@AgencyStockStaticForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="鋼胚研磨品質不良查詢" AuthorizePath="Stock01@Stock0102" 
        OpenControlPath="StockStatic@SGMBadQualitySearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="送外代軋鋼胚統計查詢" AuthorizePath="Stock01@Stock0103" 
        OpenControlPath="StockStatic@SteelPlantSendOutSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="鋼胚研磨重量查詢" AuthorizePath="Stock01@Stock0104" 
        OpenControlPath="StockStatic@SGMWeightSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="送外代軋鋼胚送回統計" AuthorizePath="Stock01@Stock0108" 
        OpenControlPath="StockStatic@SteelPlantSendInOutSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />編修:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="鋼液清淨及製程參數編修" AuthorizePath="Stock01@Stock0105" 
        OpenControlPath="StockStatic@CCClearAndArgEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="澆鑄記錄表編修" AuthorizePath="Stock01@Stock0106" 
        OpenControlPath="CCProcess@CCProcess.application" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
        CssClass="Button1" Text="磅單訂單配對系統" AuthorizePath="Stock01@Stock0109" 
        OpenControlPath="WeightHousePairOrder@WeightHousePairOrder.application" 
        AutoValidMode="VaildToEnableOrDisable" />

    <br />
    報表:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="鋼液清淨及參數報表1" AuthorizePath="Stock01@Stock0107" 
        OpenControlPath="StockStatic@CCClearAndArgReportForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />

</asp:Content>
