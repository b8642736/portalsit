<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="CoilStationStateSearchForm.aspx.vb" Inherits="ColdRollingProcess.CoilStationStateSearchForm" %>
<%@ Register src="Controls/CoilStationStateSearch.ascx" tagname="CoilStationStateSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilStationStateSearch ID="CoilStationStateSearch1" runat="server" />
</asp:Content>
