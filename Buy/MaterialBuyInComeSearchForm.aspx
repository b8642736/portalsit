<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MaterialBuyInComeSearchForm.aspx.vb" Inherits="Buy.MaterialBuyInComeSearchForm" %>
<%@ Register src="Controls/MaterialBuyInComeSearch.ascx" tagname="MaterialBuyInComeSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MaterialBuyInComeSearch ID="MaterialBuyInComeSearch1" runat="server" />
</asp:Content>
