<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="DeleteAssetForm.aspx.vb" Inherits="AST500LB.DeleteAssetForm" %>
<%@ Register src="Controls/MonthWroks/DeleteAsset.ascx" tagname="DeleteAsset" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DeleteAsset ID="DeleteAsset1" runat="server" />
</asp:Content>
