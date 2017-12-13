<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MainDefectSearchForm.aspx.vb" Inherits="QualityControl.MainDefectSearchForm" %>
<%@ Register src="Controls/MainDefectSearch.ascx" tagname="MainDefectSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MainDefectSearch ID="MainDefectSearch1" runat="server" />
</asp:Content>
