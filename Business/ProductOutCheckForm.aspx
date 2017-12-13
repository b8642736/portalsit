<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ProductOutCheckForm.aspx.vb" Inherits="Business.ProductOutCheckForm" %>
<%@ Register src="Controls/ProductOutCheck/ProductOutCheck.ascx" tagname="ProductOutCheck" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductOutCheck ID="ProductOutCheck1" runat="server" />
</asp:Content>
