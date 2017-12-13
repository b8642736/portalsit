<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InventoryForm.aspx.vb" Inherits="AST500LB.InventoryForm" %>
<%@ Register src="Controls/InventoryReport/Inventory.ascx" tagname="Inventory" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Inventory ID="Inventory1" runat="server" />
</asp:Content>
