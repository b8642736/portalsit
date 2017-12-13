<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Borrow.aspx.vb" Inherits="Financial.Borrow" %>
<%@ Register src="Control/BorrowEdit.ascx" tagname="BorrowEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowEdit ID="BorrowEdit1" runat="server" />
    </asp:Content>
