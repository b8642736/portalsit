<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ExpenseSearchForm.aspx.vb" Inherits="Accounting.ExpenseSearchForm" %>
<%@ Register src="Controls/ExpenseSearch.ascx" tagname="ExpenseSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ExpenseSearch ID="ExpenseSearch1" runat="server" />
</asp:Content>
