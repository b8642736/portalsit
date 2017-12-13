<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebGroupAuthority.aspx.vb" Inherits="WebAppAuthority.WebGroupAuthority" %>
<%@ Register src="Control/WebGroupAuthorityEdit.ascx" tagname="WebGroupAuthorityEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebGroupAuthorityEdit ID="WebGroupAuthorityEdit1" runat="server" />
</asp:Content>
