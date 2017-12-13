<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Buy._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="廠商進貨驗收資查詢" AuthorizePath="BUY01@BUY0101" 
        OpenControlPath="BUY@InStockCheckSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="原枓採購進貨資料查詢" AuthorizePath="BUY01@BUY0102" 
        OpenControlPath="BUY@MaterialBuyInComeSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br />
    編修:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="開標通知編修" AuthorizePath="BUY01@BUY0103" 
        OpenControlPath="BUY@BuyMeetEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
</asp:Content>
