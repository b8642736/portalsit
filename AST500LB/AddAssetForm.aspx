<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AddAssetForm.aspx.vb" Inherits="AST500LB.AddAssetForm" %>
<%@ Register src="Controls/MonthWroks/AddAsset.ascx" tagname="AddAsset" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddAsset ID="AddAsset1" runat="server" />
</asp:Content>
