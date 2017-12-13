<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilLineWidthHeightSearchForm.aspx.vb" Inherits="QualityControl.CoilLineWidthHeightSearchForm" %>
<%@ Register src="Controls/CoilLineWidthHeightSearch.ascx" tagname="CoilLineWidthHeightSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilLineWidthHeightSearch ID="CoilLineWidthHeightSearch1" runat="server" />
</asp:Content>
