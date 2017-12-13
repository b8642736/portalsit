<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MasterStockForm.aspx.vb" Inherits="Business.MasterStockForm" %>
<%@ Register src="Controls/MasterStock/MasterStock.ascx" tagname="MasterStock" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MasterStock ID="MasterStock1" runat="server" />
</asp:Content>
