<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ChangeSearchForm.aspx.vb" Inherits="Financial.ChangeSearchForm" %>
<%@ Register src="Control/ChangeSearch.ascx" tagname="ChangeSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ChangeSearch ID="ChangeSearch1" runat="server" />
</asp:Content>
