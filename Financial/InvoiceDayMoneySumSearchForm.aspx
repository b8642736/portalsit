<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InvoiceDayMoneySumSearchForm.aspx.vb" Inherits="Financial.InvoiceDayMoneySumSearchForm" %>
<%@ Register src="Control/InvoiceDayMoneySumSearch.ascx" tagname="InvoiceDayMoneySumSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InvoiceDayMoneySumSearch ID="InvoiceDayMoneySumSearch1" runat="server" />
</asp:Content>
