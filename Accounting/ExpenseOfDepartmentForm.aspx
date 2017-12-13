<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ExpenseOfDepartmentForm.aspx.vb" Inherits="Accounting.ExpenseOfDepartmentForm" %>
<%@ Register src="Controls/ExpenseOfDepartment.ascx" tagname="ExpenseOfDepartment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ExpenseOfDepartment ID="ExpenseOfDepartment1" runat="server" />
</asp:Content>
