<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="ProductionNoOnwerEditForm.aspx.vb" Inherits="ColdRollingProcess.ProductionNoOnwerEditForm" %>
<%@ Register src="Controls/ProductionNoOnwerEdit.ascx" tagname="ProductionNoOnwerEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductionNoOnwerEdit ID="ProductionNoOnwerEdit1" runat="server" />
</asp:Content>
