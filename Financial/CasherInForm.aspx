<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CasherInForm.aspx.vb" Inherits="Financial.CasherInForm" %>
<%@ Register src="Control/Cashier/CasherIn.ascx" tagname="CasherIn" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CasherIn ID="CasherIn1" runat="server" />
</asp:Content>
