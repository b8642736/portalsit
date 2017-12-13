<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InStockCheckSearchForm.aspx.vb" Inherits="Buy.InStockCheckSearchForm" %>
<%@ Register src="Controls/InStockCheckSearch.ascx" tagname="InStockCheckSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InStockCheckSearch ID="InStockCheckSearch1" runat="server" />
</asp:Content>
