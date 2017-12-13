<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebUserAuthority.aspx.vb" Inherits="WebAppAuthority.WebUserAuthority1" 
    title="未命名頁面" %>
<%@ Register src="Control/WebUserAuthorityEdit.ascx" tagname="WebUserAuthorityEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserAuthorityEdit ID="WebUserAuthorityEdit1" runat="server" />
</asp:Content>
