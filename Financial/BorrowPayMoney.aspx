<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BorrowPayMoney.aspx.vb" Inherits="Financial.BorrowPayMoney" %>
<%@ Register src="Control/BorrowPayMoneyEdit.ascx" tagname="BorrowPayMoneyEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowPayMoneyEdit ID="BorrowPayMoneyEdit1" runat="server" />
</asp:Content>
