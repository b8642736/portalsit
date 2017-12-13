<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Environment._Default" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢<BR />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton1" runat="server" 
        AuthorizePath="ECO01@ECO0101" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="Environment@ECO0101Form.aspx" 
        Text="外部網站" />
    <cc1:ucauthorizebutton ID="ucAuthorizeButton2" runat="server" 
        AuthorizePath="ECO01@ECO0102" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="Environment@MaterialSearchForm.aspx" 
        Text="單位物料查詢" />
    <asp:Button ID="btnECO0103" runat="server" Text="溫室氣體網站" CssClass="Button1" />
</asp:Content>
