<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductBugSearchForm.aspx.vb" Inherits="QualityControl.ProductBugSearchForm" %>
<%@ Register src="Controls/ProductBugSearch/ProductBugSearch.ascx" tagname="ProductBugSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductBugSearch ID="ProductBugSearch2" runat="server" />
</asp:Content>
