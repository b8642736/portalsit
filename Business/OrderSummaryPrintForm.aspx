<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderSummaryPrintForm.aspx.vb" Inherits="Business.OrderSummaryPrintForm" %>
<%@ Register src="Controls/OrderSummaryPrint/OrderSummaryPrint.ascx" tagname="OrderSummaryPrint" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderSummaryPrint ID="OrderSummaryPrint1" runat="server" />
</asp:Content>
