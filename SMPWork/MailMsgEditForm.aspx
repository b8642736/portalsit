<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MailMsgEditForm.aspx.vb" Inherits="SMPWork.MailMsgEditForm" %>
<%@ Register src="Controls/MailMsgEdit/MailMsgEdit.ascx" tagname="MailMsgEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MailMsgEdit ID="MailMsgEdit1" runat="server" />
</asp:Content>
