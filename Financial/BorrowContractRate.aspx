<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BorrowContractRate.aspx.vb" Inherits="Financial.BorrowContractRate" %>
<%@ Register src="Control/BorrowContractRateEdit.ascx" tagname="BorrowContractRateEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BorrowContractRateEdit ID="BorrowContractRateEdit1" runat="server" />
</asp:Content>
