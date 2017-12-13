<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CashPay.aspx.vb" Inherits="Accounting.CashPay" %>
<%@ Register src="PCash/CashPayEdit.ascx" tagname="CashPayEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CashPayEdit ID="CashPayEdit1" runat="server" />
</asp:Content>
