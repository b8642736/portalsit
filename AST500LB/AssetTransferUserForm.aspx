<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetTransferUserForm.aspx.vb" Inherits="AST500LB.AssetTransferUserForm" %>
<%@ Register src="Controls/AssetTransferUser.ascx" tagname="AssetTransferUser" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetTransferUser ID="AssetTransferUser1" runat="server" />
</asp:Content>
