<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CCClearAndArgReportForm.aspx.vb" Inherits="StockStatic.CCClearAndArgReportForm" %>
<%@ Register src="Control/CCClearAndArgReport/CCClearAndArgReport.ascx" tagname="CCClearAndArgReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CCClearAndArgReport ID="CCClearAndArgReport1" runat="server" />
</asp:Content>
