<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="YieldRateSearchForm.aspx.vb" Inherits="QualityControl.YieldRateSearchForm" %>
<%@ Register src="Controls/YieldRateSearch.ascx" tagname="YieldRateSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:YieldRateSearch ID="YieldRateSearch1" runat="server" />
</asp:Content>
