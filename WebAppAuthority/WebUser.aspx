<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebUser.aspx.vb" Inherits="WebAppAuthority.WebUser" 
    title="未命名頁面" %>
<%@ Register src="Control/WebUserEdit.ascx" tagname="WebUserEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserEdit ID="WebUserEdit1" runat="server" />
</asp:Content>
