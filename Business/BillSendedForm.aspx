<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BillSendedForm.aspx.vb" Inherits="Business.BillSendedForm" %>
<%@ Register src="Controls/BillSended/BillSended.ascx" tagname="BillSended" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BillSended ID="BillSended1" runat="server" />
</asp:Content>
