<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StockStaticForm.aspx.vb" Inherits="EIS.StockStaticForm" %>
<%@ Register src="Controls/StockStatic.ascx" tagname="StockStatic" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StockStatic ID="StockStatic1" runat="server" />
</asp:Content>
