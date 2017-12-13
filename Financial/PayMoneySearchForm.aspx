<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="PayMoneySearchForm.aspx.vb" Inherits="Financial.PayMoneySearchForm" %>
<%@ Register src="Control/PayMoneySearch.ascx" tagname="PayMoneySearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PayMoneySearch ID="PayMoneySearch1" runat="server" />
</asp:Content>
