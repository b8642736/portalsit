<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LCDebitEditForm.aspx.vb" Inherits="Financial.LCDebitEditForm" %>
<%@ Register src="Control/LCDebitEdit.ascx" tagname="LCDebitEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LCDebitEdit ID="LCDebitEdit1" runat="server" />
</asp:Content>
