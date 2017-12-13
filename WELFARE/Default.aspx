<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="WELFARE._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="傳票查詢" AuthorizePath="WELF01@WELF0101" 
        OpenControlPath="WELFARE@VoucherSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <BR />編修:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="傳票編修" AuthorizePath="WELF01@WELF0102" 
        OpenControlPath="WELFARE@VoucherEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="傳票明細編修" AuthorizePath="WELF01@WELF0103" 
        OpenControlPath="WELFARE@VoucherDetailEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
</asp:Content>
