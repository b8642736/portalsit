<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetReceiptForm.aspx.vb" Inherits="AST500LB.AssetReceiptForm" %>
<%@ Register src="Controls/AssetReceipt/AssetReceipt.ascx" tagname="AssetReceipt" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetReceipt ID="AssetReceipt1" runat="server" />
</asp:Content>
