<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StoveElementOutBuySearchForm.aspx.vb" Inherits="QualityControl.StoveElementOutBuySearchForm" %>
<%@ Register src="Controls/StoveElementOutBuySearch.ascx" tagname="StoveElementOutBuySearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StoveElementOutBuySearch ID="StoveElementOutBuySearch1" runat="server" />
</asp:Content>
