<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="PendingPaymentSearchForm.aspx.vb" Inherits="Financial.PendingPaymentSearchForm" %>
<%@ Register src="Control/PendingPayment.ascx" tagname="PendingPayment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PendingPayment ID="PendingPayment2" runat="server" />
</asp:Content>
