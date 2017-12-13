<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilProgressSearchForm.aspx.vb" Inherits="QualityControl.CoilProgressSearchForm" %>
<%@ Register src="Controls/CoilProgressSearch.ascx" tagname="CoilProgressSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilProgressSearch ID="CoilProgressSearch1" runat="server" />
</asp:Content>
