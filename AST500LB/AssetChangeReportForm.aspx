<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetChangeReportForm.aspx.vb" Inherits="AST500LB.AssetChangeReportForm" %>
<%@ Register src="Controls/AssetChangeReport/AssetChangeReport.ascx" tagname="AssetChangeReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetChangeReport ID="AssetChangeReport1" runat="server" />
</asp:Content>
