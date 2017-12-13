<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="DebtLetterofCreditSearchForm.aspx.vb" Inherits="Accounting.DebtLetterofCreditSearchForm" %>
<%@ Register src="Controls/DebtLetterofCreditSearch.ascx" tagname="DebtLetterofCreditSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DebtLetterofCreditSearch ID="DebtLetterofCreditSearch1" runat="server" />
</asp:Content>
