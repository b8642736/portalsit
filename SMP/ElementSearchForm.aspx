<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ElementSearchForm.aspx.vb" Inherits="SMP.ElementSearchForm" %>
<%@ Register src="Control/ElementSearch.ascx" tagname="ElementSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ElementSearch ID="ElementSearch1" runat="server" />
</asp:Content>
