<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BorrowLCBill.aspx.vb" Inherits="Financial.BorrowLCBill" %>
<%@ Register src="Control/BorrowLCBillEdit.ascx" tagname="BorrowLCBillEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowLCBillEdit ID="BorrowLCBillEdit1" runat="server" />
</asp:Content>
