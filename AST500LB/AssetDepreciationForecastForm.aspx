<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetDepreciationForecastForm.aspx.vb" Inherits="AST500LB.AssetDepreciationForecastForm" %>
<%@ Register src="Controls/AssetDepreciationForecast.ascx" tagname="AssetDepreciationForecast" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetDepreciationForecast ID="AssetDepreciationForecast1" runat="server" />
</asp:Content>
