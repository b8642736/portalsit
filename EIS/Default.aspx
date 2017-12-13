<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="EIS._Default" %>

<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p />
    查詢<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server"
        CssClass="Button1" Text="成品庫存數量統計"
        AuthorizePath="EIS01@EIS0101" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@StockStaticForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server"
        CssClass="Button1" Text="訂單發貨量查詢"
        AuthorizePath="EIS01@EIS0102" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@SL2S01Form.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server"
        CssClass="Button1" Text="客戶訂單狀況查詢"
        AuthorizePath="EIS01@EIS0103" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@OrderStatusStatisticsForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server"
        CssClass="Button1" Text="訂單生產派工狀況查詢"
        AuthorizePath="EIS01@EIS0104" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@OrderProduceAssignForm.aspx" />
        <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server"
        CssClass="Button1" Text="料源狀況查詢"
        AuthorizePath="EIS01@EIS0105" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@MaterialStatusForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server"
        CssClass="Button1" Text="無主庫存查詢(不含客戶保留)"
        AuthorizePath="EIS01@EIS0106" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@StockStaticUnAssemForm1.aspx" Width ="200px" />
        <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server"
        CssClass="Button1" Text="客戶已保留無主庫存查詢"
        AuthorizePath="EIS01@EIS0107" AutoValidMode="VaildToEnableOrDisable"
        OpenControlPath="EIS@StockStaticUnAssemForm2.aspx" Width ="200px" />
</asp:Content>
