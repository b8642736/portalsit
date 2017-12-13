<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="PCashInOutPrint.aspx.vb" Inherits="Accounting.PCashInOutPrint" %>
<%@ Register src="PCash/PCashInOutReportMaker.ascx" tagname="PCashInOutReportMaker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PCashInOutReportMaker ID="PCashInOutReportMaker1" runat="server" />
</asp:Content>
