<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CashTicket.aspx.vb" Inherits="Accounting.CashTicket" EnableEventValidation="false"  %>
<%@ Register src="PCash/CheckTicketMake.ascx" tagname="CheckTicketMake" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckTicketMake ID="CheckTicketMake1" runat="server" />
</asp:Content>
