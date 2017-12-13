<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="NonConsumFAMEditForm.aspx.vb" Inherits="Accounting.NonConsumFAMEditForm" %>
<%@ Register src="NonConsumFAMManager/NonConsumFAMEdit.ascx" tagname="NonConsumFAMEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NonConsumFAMEdit ID="NonConsumFAMEdit1" runat="server" />
</asp:Content>
