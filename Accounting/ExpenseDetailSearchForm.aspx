<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ExpenseDetailSearchForm.aspx.vb" Inherits="Accounting.ExpenseDetailSearchForm" %>
<%@ Register src="Controls/ExpenseDetailSearch.ascx" tagname="ExpenseDetailSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ExpenseDetailSearch ID="ExpenseDetailSearch1" runat="server" />
</asp:Content>
