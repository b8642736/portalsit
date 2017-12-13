<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ScrapValueReportForm.aspx.vb" Inherits="AST500LB.ScrapValueReportForm" %>
<%@ Register src="Controls/MonthWroks/ScrapValueReport.ascx" tagname="ScrapValueReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ScrapValueReport ID="ScrapValueReport1" runat="server" />
</asp:Content>
