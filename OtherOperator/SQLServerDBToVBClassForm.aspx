<%@ Page Title="" Language="vb"  validateRequest="false" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="SQLServerDBToVBClassForm.aspx.vb" Inherits="OtherOperator.SQLServerDBToVBClassForm" %>
<%@ Register src="Control/SQLServerDBToVBClass.ascx" tagname="SQLServerDBToVBClass" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SQLServerDBToVBClass ID="SQLServerDBToVBClass1" runat="server" />
</asp:Content>
