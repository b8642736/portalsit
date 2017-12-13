<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetDetailReportForm.aspx.vb" Inherits="AST500LB.AssetDetailReportForm" %>
<%@ Register src="Controls/AssetDetailReport/AssetDetailReport.ascx" tagname="AssetDetailReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetDetailReport ID="AssetDetailReport1" runat="server" />
</asp:Content>
