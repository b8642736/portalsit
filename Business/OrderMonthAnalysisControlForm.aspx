<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderMonthAnalysisControlForm.aspx.vb" Inherits="Business.OrderMonthAnalysisControlForm" %>
<%@ Register src="Controls/OrderMonthAnalysis/OrderMonthAnalysisControl.ascx" tagname="OrderMonthAnalysisControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderMonthAnalysisControl ID="OrderMonthAnalysisControl1" runat="server" />
</asp:Content>
