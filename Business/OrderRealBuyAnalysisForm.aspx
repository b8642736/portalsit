<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderRealBuyAnalysisForm.aspx.vb" Inherits="Business.OrderRealBuyAnalysisForm" %>
<%@ Register src="Controls/OrderRealBuyAnalysis/OrderRealBuyAnalysis.ascx" tagname="OrderRealBuyAnalysis" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderRealBuyAnalysis ID="OrderRealBuyAnalysis2" runat="server" />
</asp:Content>
