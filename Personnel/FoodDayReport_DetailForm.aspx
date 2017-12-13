<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodDayReport_DetailForm.aspx.vb" Inherits="Personnel.FoodDayReport_DetailForm" %>
<%@ Register src="Controls/FoodDayReport_Detail/FoodDayReport_Detail.ascx" tagname="FoodDayReport_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodDayReport_Detail ID="FoodDayReport_Detail1" runat="server" />
</asp:Content>
