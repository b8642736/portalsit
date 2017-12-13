<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebUserOrIPAllAuthoritySearchForm.aspx.vb" Inherits="WebAppAuthority.WebUserOrIPAllAuthoritySearchForm" %>
<%@ Register src="Control/AllAuthoritySearch/WebUserOrIPAllAuthoritySearch.ascx" tagname="WebUserOrIPAllAuthoritySearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserOrIPAllAuthoritySearch ID="WebUserOrIPAllAuthoritySearch1" 
        runat="server" />
</asp:Content>
