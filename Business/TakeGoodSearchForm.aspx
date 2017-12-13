<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="TakeGoodSearchForm.aspx.vb" Inherits="Business.TakeGoodSearchForm" %>
<%@ Register src="Controls/TakeGoodSearch.ascx" tagname="TakeGoodSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TakeGoodSearch ID="TakeGoodSearch1" runat="server" />
</asp:Content>
