<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebUserAuthorityCopys.aspx.vb" Inherits="WebAppAuthority.WebUserAuthorityCopys" 
    title="未命名頁面" %>
<%@ Register src="Control/WebUserAuthorityCopy.ascx" tagname="WebUserAuthorityCopy" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserAuthorityCopy ID="WebUserAuthorityCopy1" runat="server" />
</asp:Content>
