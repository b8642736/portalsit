<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodMonthReport_DetailForm.aspx.vb" Inherits="Personnel.FoodMonthReport_DetailForm" %>
<%@ Register src="Controls/FoodMonthReport_Detail/FoodMonthReport_Detail.ascx" tagname="FoodMonthReport_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodMonthReport_Detail ID="FoodMonthReport_Detail1" runat="server" />
</asp:Content>
