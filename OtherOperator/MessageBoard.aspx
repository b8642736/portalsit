<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="MessageBoard.aspx.vb" Inherits="OtherOperator.MessageBoard" %>
<%@ Register src="Control/MessageBoardEdit.ascx" tagname="MessageBoardEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageBoardEdit ID="MessageBoardEdit1" runat="server" />
</asp:Content>
