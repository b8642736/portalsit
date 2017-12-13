<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilDefectSearchForm.aspx.vb" Inherits="QualityControl.CoilDefectSearchForm" %>
<%@ Register src="Controls/CoilDefectSearch.ascx" tagname="CoilDefectSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilDefectSearch ID="CoilDefectSearch1" runat="server" />
</asp:Content>
