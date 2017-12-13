<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CashDepartment.aspx.vb" Inherits="Accounting.CashDepartment" %>
<%@ Register src="PCash/CashDepartmentEdit.ascx" tagname="CashDepartmentEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CashDepartmentEdit ID="CashDepartmentEdit1" runat="server" />
</asp:Content>
