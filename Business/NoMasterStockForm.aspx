<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="NoMasterStockForm.aspx.vb" Inherits="Business.NoMasterStockForm" %>
<%@ Register src="Controls/NoMasterStock/NoMasterStock.ascx" tagname="NoMasterStock" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NoMasterStock ID="NoMasterStock1" runat="server" />
</asp:Content>
