<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetSplitForm.aspx.vb" Inherits="AST500LB.AssetSplitForm" %>
<%@ Register src="Controls/AssetSplit/AssetSplit.ascx" tagname="AssetSplit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetSplit ID="AssetSplit1" runat="server" />
</asp:Content>
