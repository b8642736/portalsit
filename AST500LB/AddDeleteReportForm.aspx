<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AddDeleteReportForm.aspx.vb" Inherits="AST500LB.AddDeleteReportForm" %>
<%@ Register src="Controls\MonthWroks\AddDeleteReport.ascx" tagname="AddDeleteReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddDeleteReport ID="AddDeleteReport1" runat="server" />
</asp:Content>
