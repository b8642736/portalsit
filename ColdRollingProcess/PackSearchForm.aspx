<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="PackSearchForm.aspx.vb" Inherits="ColdRollingProcess.PackSearchForm" %>
<%@ Register src="Controls/PackSearch.ascx" tagname="PackSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PackSearch ID="PackSearch1" runat="server" />
</asp:Content>
