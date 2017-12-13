<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SteelPlantSendOutSearchForm.aspx.vb" Inherits="StockStatic.SteelPlantSendOutSearchForm" %>
<%@ Register src="Control/SteelPlantSendOutSearch.ascx" tagname="SteelPlantSendOutSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SteelPlantSendOutSearch ID="SteelPlantSendOutSearch1" runat="server" />
</asp:Content>
