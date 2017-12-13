<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/EAF.Master" CodeBehind="DailyReport.aspx.vb" Inherits="EAFWeb.DailyReport" %>
<%@ Register src="Controls/DailyReportMaker.ascx" tagname="DailyReportMaker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DailyReportMaker ID="DailyReportMaker1" runat="server" />
</asp:Content>
