<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="SPMPasswordSearchForm.aspx.vb" Inherits="WebAppAuthority.SPMPasswordSearchForm" %>
<%@ Register src="Control/SPMPasswordSearch.ascx" tagname="SPMPasswordSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SPMPasswordSearch ID="SPMPasswordSearch1" runat="server" />
</asp:Content>
