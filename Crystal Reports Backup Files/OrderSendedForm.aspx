<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderSendedForm.aspx.vb" Inherits="Business.OrderSendedForm" %>
<%@ Register src="Controls/OrderSended/OrderSended.ascx" tagname="OrderSended" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:OrderSended ID="OrderSended1" runat="server" />
</asp:Content>
