<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="DiscardReportForm.aspx.vb" Inherits="AST500LB.DiscardReportForm" %>
<%@ Register src="Controls/DiscardReport/DiscardReport.ascx" tagname="DiscardReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DiscardReport ID="DiscardReport1" runat="server" />
</asp:Content>
