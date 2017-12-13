<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CCClearAndArgEditForm.aspx.vb" Inherits="StockStatic.CCClearAndArgEditForm" %>
<%@ Register src="Control/CCClearAndArgEdit.ascx" tagname="CCClearAndArgEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CCClearAndArgEdit ID="CCClearAndArgEdit1" runat="server" />
</asp:Content>
