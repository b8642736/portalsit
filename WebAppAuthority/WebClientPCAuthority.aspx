<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebClientPCAuthority.aspx.vb" Inherits="WebAppAuthority.WebClientPCAuthority" %>
<%@ Register src="Control/WebClientPCAuthorityEdit.ascx" tagname="WebClientPCAuthorityEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebClientPCAuthorityEdit ID="WebClientPCAuthorityEdit1" runat="server" />
</asp:Content>
