<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodDayReport_SumTotalForm.aspx.vb" Inherits="Personnel.FoodDayReport_SumTotalForm" %>
<%@ Register src="Controls/FoodDayReport_SumTotal/FoodDayReport_SumTotal.ascx" tagname="FoodDayReport_SumTotal" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodDayReport_SumTotal ID="FoodDayReport_SumTotal1" runat="server" />
</asp:Content>
