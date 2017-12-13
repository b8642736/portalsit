<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BorrowLCBillPayMoney.aspx.vb" Inherits="Financial.BorrowLCBillPayMoney" %>
<%@ Register src="Control/BorrowLCBillPayMoneyEdit.ascx" tagname="BorrowLCBillPayMoneyEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowLCBillPayMoneyEdit ID="BorrowLCBillPayMoneyEdit1" runat="server" />
</asp:Content>
