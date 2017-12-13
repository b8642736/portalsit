<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductBugWeightSearchForm.aspx.vb" Inherits="QualityControl.ProductBugWeightSearchForm" %>
<%@ Register src="Controls/ProductBugWeightSearch.ascx" tagname="ProductBugWeightSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductBugWeightSearch ID="ProductBugWeightSearch1" runat="server" />
</asp:Content>
