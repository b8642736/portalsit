<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MessageEditForm.aspx.vb" Inherits="IM.MessageEditForm" %>
<%@ Register src="Controls/MessageEdit.ascx" tagname="MessageEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageEdit ID="MessageEdit1" runat="server" />
</asp:Content>
