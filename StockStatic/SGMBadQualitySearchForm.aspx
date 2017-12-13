<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SGMBadQualitySearchForm.aspx.vb" Inherits="StockStatic.SGMBadQualitySearchForm" %>
<%@ Register src="Control/SGMBadQualitySearch.ascx" tagname="SGMBadQualitySearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SGMBadQualitySearch ID="SGMBadQualitySearch1" runat="server" />
</asp:Content>
