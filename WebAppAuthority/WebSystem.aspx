<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebSystem.aspx.vb" Inherits="WebAppAuthority.WebSystem" 
    title="未命名頁面" %>
<%@ Register src="Control/WebSystemEdit.ascx" tagname="WebSystemEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebSystemEdit ID="WebSystemEdit1" runat="server" />
</asp:Content>
