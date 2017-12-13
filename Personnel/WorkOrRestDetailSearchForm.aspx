<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="WorkOrRestDetailSearchForm.aspx.vb" Inherits="Personnel.WorkOrRestDetailSearchForm" %>
<%@ Register src="Controls/WorkOrRestDetailSearch.ascx" tagname="WorkOrRestDetailSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WorkOrRestDetailSearch ID="WorkOrRestDetailSearch1" runat="server" />
</asp:Content>
