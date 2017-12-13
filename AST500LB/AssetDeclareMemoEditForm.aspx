<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetDeclareMemoEditForm.aspx.vb" Inherits="AST500LB.AssetDeclareMemoEditForm" %>
<%@ Register src="Controls/AssetDeclareMemoEdit/AssetDeclareMemoEdit.ascx" tagname="AssetDeclareMemoEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetDeclareMemoEdit ID="AssetDeclareMemoEdit1" runat="server" />
</asp:Content>
