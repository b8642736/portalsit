<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SGMWeightSearchForm.aspx.vb" Inherits="StockStatic.SGMWeightSearchForm" %>
<%@ Register src="Control/SGMWeightSearch.ascx" tagname="SGMWeightSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SGMWeightSearch ID="SGMWeightSearch1" runat="server" />
</asp:Content>
