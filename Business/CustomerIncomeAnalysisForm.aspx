<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CustomerIncomeAnalysisForm.aspx.vb" Inherits="Business.CustomerIncomeAnalysisForm" %>
<%@ Register src="Controls/CustomerIncomeAnalysis/CustomerIncomeAnalysis.ascx" tagname="CustomerIncomeAnalysis" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CustomerIncomeAnalysis ID="CustomerIncomeAnalysis1" runat="server" />
</asp:Content>
