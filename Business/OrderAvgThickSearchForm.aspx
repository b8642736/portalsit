<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderAvgThickSearchForm.aspx.vb" Inherits="Business.OrderAvgThickSearchForm" %>
<%@ Register src="Controls/OrderAvgThickSearch/OrderAvgThickSearch.ascx" tagname="OrderAvgThickSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderAvgThickSearch ID="OrderAvgThickSearch1" runat="server" />
</asp:Content>
