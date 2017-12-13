<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetTransferSearchForm.aspx.vb" Inherits="AST500LB.AssetTransferSearchForm" %>
<%@ Register src="Controls/AssetTransferSearch.ascx" tagname="AssetTransferSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetTransferSearch ID="AssetTransferSearch1" runat="server" />
</asp:Content>
