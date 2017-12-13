<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="ProductionStartCmdEditbForm.aspx.vb" Inherits="ColdRollingProcess.ProductionStartCmdEditbForm" %>
<%@ Register src="Controls/ProductionStartCmdEdit.ascx" tagname="ProductionStartCmdEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductionStartCmdEdit ID="ProductionStartCmdEdit1" runat="server" />
</asp:Content>
