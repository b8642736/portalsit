<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="HotRollingSearchForm.aspx.vb" Inherits="QualityControl.HotRollingSearchForm" %>
<%@ Register src="Controls/HotRollingSearch.ascx" tagname="HotRollingSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HotRollingSearch ID="HotRollingSearch1" runat="server" />
</asp:Content>
