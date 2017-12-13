<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductCashStatisticsForm.aspx.vb" Inherits="Accounting.ProductCashStatisticsForm" %>
<%@ Register src="Controls/ProductCashStatistics.ascx" tagname="ProductCashStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductCashStatistics ID="ProductCashStatistics1" runat="server" />
</asp:Content>
