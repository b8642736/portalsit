<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="VoucherSearchForm.aspx.vb" Inherits="WELFARE.VoucherSearchForm" %>
<%@ Register src="Controls/VoucherSearch.ascx" tagname="VoucherSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VoucherSearch ID="VoucherSearch1" runat="server" />
</asp:Content>
