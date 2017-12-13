<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CSSearchForm.aspx.vb" Inherits="QualityControl.CSSearchForm" %>
<%@ Register src="Controls/CSSearch.ascx" tagname="CSSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CSSearch ID="CSSearch1" runat="server" />
</asp:Content>
