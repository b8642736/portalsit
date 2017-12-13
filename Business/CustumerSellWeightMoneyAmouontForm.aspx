<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CustumerSellWeightMoneyAmouontForm.aspx.vb" Inherits="Business.CustumerSellWeightMoneyAmouontForm" %>
<%@ Register src="Controls/CustumerSellWeightMoneyAmouont/CustumerSellWeightMoneyAmouont.ascx" tagname="CustumerSellWeightMoneyAmouont" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CustumerSellWeightMoneyAmouont ID="CustumerSellWeightMoneyAmouont1" 
        runat="server" />
</asp:Content>
