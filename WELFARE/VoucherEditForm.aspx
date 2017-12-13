<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="VoucherEditForm.aspx.vb" Inherits="WELFARE.VoucherEditForm" %>
<%@ Register src="Controls/VoucherEdit.ascx" tagname="VoucherEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VoucherEdit ID="VoucherEdit1" runat="server" />
</asp:Content>
