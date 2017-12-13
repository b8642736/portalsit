<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodMonthReport_SumTotalForm.aspx.vb" Inherits="Personnel.FoodMonthReport_SumTotalForm" %>
<%@ Register src="Controls/FoodMonthReport_SumTotal/FoodMonthReport_SumTotal.ascx" tagname="FoodMonthReport_SumTotal" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodMonthReport_SumTotal ID="FoodMonthReport_SumTotal1" runat="server" />
</asp:Content>
