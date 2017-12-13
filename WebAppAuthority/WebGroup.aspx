<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebGroup.aspx.vb" Inherits="WebAppAuthority.WebGroup" %>
<%@ Register src="Control/WebGroupEdit.ascx" tagname="WebGroupEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebGroupEdit ID="WebGroupEdit1" runat="server" />
</asp:Content>
