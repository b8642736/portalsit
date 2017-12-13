<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductBugStatisticsForm.aspx.vb" Inherits="QualityControl.ProductBugStatisticsForm" %>
<%@ Register src="Controls/ProductBugStatistics.ascx" tagname="ProductBugStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductBugStatistics ID="ProductBugStatistics1" runat="server" />
</asp:Content>
