<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProcessGaugeEditForm.aspx.vb" Inherits="SMP.ProcessGaugeEditForm" %>
<%@ Register src="Control/ProcessGaugeEdit.ascx" tagname="ProcessGaugeEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProcessGaugeEdit ID="ProcessGaugeEdit1" runat="server" />
</asp:Content>
