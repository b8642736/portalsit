<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderMonthBuyAnalysisForm.aspx.vb" Inherits="Business.OrderMonthBuyAnalysisForm" %>
<%@ Register src="Controls/OrderMonthBuyAnalysis/OrderMonthBuyAnalysis.ascx" tagname="OrderMonthBuyAnalysis" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderMonthBuyAnalysis ID="OrderMonthBuyAnalysis1" runat="server" />
</asp:Content>
