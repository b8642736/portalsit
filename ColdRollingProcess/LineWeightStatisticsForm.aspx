<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="LineWeightStatisticsForm.aspx.vb" Inherits="ColdRollingProcess.LineWeightStatisticsForm" %>
<%@ Register src="Controls/LineWeightStatistics.ascx" tagname="LineWeightStatistics" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LineWeightStatistics ID="LineWeightStatistics1" runat="server" />
</asp:Content>
