<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductLoseStatisticsForm.aspx.vb" Inherits="QualityControl.ProductLoseStatisticsForm" %>
<%@ Register src="Controls/ProductLoseStatistics.ascx" tagname="ProductLoseStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductLoseStatistics ID="ProductLoseStatistics1" runat="server" />
</asp:Content>
