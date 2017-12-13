<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilDefectEntrustSearchForm.aspx.vb" Inherits="QualityControl.CoilDefectEntrustSearchForm" %>
<%@ Register src="Controls/CoilDefectEntrustSearch.ascx" tagname="CoilDefectEntrustSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilDefectEntrustSearch ID="CoilDefectEntrustSearch1" runat="server" />
</asp:Content>
