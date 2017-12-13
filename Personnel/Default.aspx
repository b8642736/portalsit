<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Personnel._Default" %>

<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    查詢<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server"
        AuthorizePath="PSN01@PSN0101" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@WorkOrRestDetailSearchForm.aspx"
        Text="加班明細查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server"
        AuthorizePath="PSN01@PSN0102" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@HRLeaveDetailForm.aspx"
        Text="請假明細查詢" />


    <br />
    <br />
    <br />
    伙食<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server"
        AuthorizePath="PSN01@PSN0103" AutoValidMode="None"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodOrderInputForm.aspx"
        Text="訂餐輸入" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server"
        AuthorizePath="PSN01@PSN0104" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodDeskPersonForm.aspx"
        Text="伙食登記桌人員輸入" />
    <br />
    <br />
    報表<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server"
        AuthorizePath="PSN01@PSN0105" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodDayReport_SumTotalForm.aspx"
        Text="(日)伙食小計表" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server"
        AuthorizePath="PSN01@PSN0106" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodDayReport_DetailForm.aspx"
        Text="(日)伙食明細表" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server"
        AuthorizePath="PSN01@PSN0107" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodMonthReport_DetailForm.aspx"
        Text="(月)伙食報支總表" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server"
        AuthorizePath="PSN01@PSN0108" AutoValidMode="VaildToEnableOrDisable"
        CssClass="Button1"
        OpenControlPath="Personnel@FoodMonthReport_SumTotalForm.aspx"
        Text="(月)伙食供應統計表" />
    <br />

</asp:Content>
