﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductStockCostStatisticsForm.aspx.vb" Inherits="Accounting.ProductStockCostStatisticsForm" %>
<%@ Register src="Controls/ProductStockCostStatistics.ascx" tagname="ProductStockCostStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductStockCostStatistics ID="ProductStockCostStatistics1" runat="server" />
</asp:Content>
