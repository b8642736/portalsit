<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodDeskPersonForm.aspx.vb" Inherits="Personnel.FoodDeskPersonForm" %>
<%@ Register src="Controls/FoodDeskPerson.ascx" tagname="FoodDeskPerson" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodDeskPerson ID="FoodDeskPerson1" runat="server" />
</asp:Content>
