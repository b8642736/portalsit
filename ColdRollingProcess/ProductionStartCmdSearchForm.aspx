<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="ProductionStartCmdSearchForm.aspx.vb" Inherits="ColdRollingProcess.ProductionStartCmdSearchForm" %>
<%@ Register src="Controls/ProductionStartCmdSearch.ascx" tagname="ProductionStartCmdSearch" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ProductionStartCmdSearch ID="ProductionStartCmdSearch1" runat="server" />
</asp:Content>
