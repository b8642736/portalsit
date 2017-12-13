<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebClientPC.aspx.vb" Inherits="WebAppAuthority.WebClientPC" %>
<%@ Register src="Control/WebClientPCEdit.ascx" tagname="WebClientPCEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebClientPCEdit ID="WebClientPCEdit1" runat="server" />
</asp:Content>
