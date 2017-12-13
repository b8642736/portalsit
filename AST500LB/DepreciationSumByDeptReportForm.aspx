<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="DepreciationSumByDeptReportForm.aspx.vb" Inherits="AST500LB.DepreciationSumByDeptReportForm" %>
<%@ Register src="Controls/DepreciationSumByDeptReport/DepreciationSumByDeptReport.ascx" tagname="DepreciationSumByDeptReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DepreciationSumByDeptReport ID="DepreciationSumByDeptReport1" runat="server" />
</asp:Content>
