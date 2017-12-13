<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilDefectExtendSearchForm.aspx.vb" Inherits="QualityControl.CoilDefectExtendSearchForm" %>
<%@ Register src="Controls/CoilDefectExtendSearch.ascx" tagname="CoilDefectExtendSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilDefectExtendSearch ID="CoilDefectExtendSearch1" runat="server" />
</asp:Content>
