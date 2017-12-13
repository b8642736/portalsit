<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FoodOrderInputForm.aspx.vb" Inherits="Personnel.FoodOrderInputForm" %>
<%@ Register src="Controls/FoodOrderInput.ascx" tagname="FoodOrderInput" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FoodOrderInput ID="FoodOrderInput1" runat="server" />
</asp:Content>
