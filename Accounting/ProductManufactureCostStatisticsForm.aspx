﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductManufactureCostStatisticsForm.aspx.vb" Inherits="Accounting.ProductManufactureCostStatisticsForm" %>
<%@ Register src="Controls/ProductManufactureCostStatistics.ascx" tagname="ProductManufactureCostStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductManufactureCostStatistics ID="ProductManufactureCostStatistics1" runat="server" />
</asp:Content>