<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MainSubAssetEditForm.aspx.vb" Inherits="AST500LB.MainSubAssetEditForm" %>
<%@ Register src="Controls/MainSubAssetEdit.ascx" tagname="MainSubAssetEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MainSubAssetEdit ID="MainSubAssetEdit1" runat="server" />
</asp:Content>
