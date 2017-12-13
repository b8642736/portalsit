<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BorrowContract.aspx.vb" Inherits="Financial.BorrowContract" enableEventValidation="false" %>
<%@ Register src="Control/BorrowContractEdit.ascx" tagname="BorrowContractEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowContractEdit ID="BorrowContractEdit1" runat="server" />
</asp:Content>
