<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebSystemFunction.aspx.vb" Inherits="WebAppAuthority.WebSystemFunction" 
    title="未命名頁面" %>
<%@ Register src="Control/WebSystemFunctionEdit.ascx" tagname="WebSystemFunctionEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebSystemFunctionEdit ID="WebSystemFunctionEdit1" runat="server" />
</asp:Content>
