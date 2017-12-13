<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InvoiceOfReceivablesForm.aspx.vb" Inherits="Financial.InvoiceOfReceivablesForm" %>
<%@ Register src="Control/InvoiceOfReceivables/InvoiceOfReceivables_Main.ascx" tagname="InvoiceOfReceivables_Main" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InvoiceOfReceivables_Main ID="InvoiceOfReceivables_Main1" runat="server" />
 </asp:Content>
