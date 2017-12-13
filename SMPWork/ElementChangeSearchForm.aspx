<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ElementChangeSearchForm.aspx.vb" Inherits="SMPWork.ElementChangeSearchForm" %>
<%@ Register src="Controls/ElementChangeSearch/ElementChangeSearch.ascx" tagname="ElementChangeSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ElementChangeSearch ID="ElementChangeSearch1" runat="server" />
</asp:Content>
