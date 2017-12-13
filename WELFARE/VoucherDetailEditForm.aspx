<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="VoucherDetailEditForm.aspx.vb" Inherits="WELFARE.VoucherDetailEditForm" %>
<%@ Register src="Controls/VoucherDetailEdit.ascx" tagname="VoucherDetailEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VoucherDetailEdit ID="VoucherDetailEdit1" runat="server" />
</asp:Content>
