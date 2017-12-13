<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FAMDepReportForm.aspx.vb" Inherits="AST500LB.FAMDepReportForm" %>
<%@ Register src="Controls/MonthWroks/FAMDepReport.ascx" tagname="FAMDepReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FAMDepReport ID="FAMDepReport1" runat="server" />
</asp:Content>
