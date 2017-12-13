<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilRealWidthSearchForm.aspx.vb" Inherits="QualityControl.CoilRealWidthSearchForm" %>
<%@ Register src="Controls/CoilRealWidthSearch.ascx" tagname="CoilRealWidthSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilRealWidthSearch ID="CoilRealWidthSearch1" runat="server" />
</asp:Content>
