<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MessageSenderForm.aspx.vb" Inherits="IM.MessageSenderForm" %>
<%@ Register src="Controls/MessageSender.ascx" tagname="MessageSender" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageSender ID="MessageSender1" runat="server" />
</asp:Content>
