<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="GuestSuesForm.aspx.vb" Inherits="Business.GuestSuesForm" %>
<%@ Register src="Controls/GuestSues/GuestSues.ascx" tagname="GuestSues" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GuestSues ID="GuestSues2" runat="server" />
</asp:Content>
