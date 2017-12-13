<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AssetExtendUseEditForm.aspx.vb" Inherits="AST500LB.AssetExtendUseEditForm" %>
<%@ Register src="Controls/AssetExtendUseEdit/AssetExtendUseEdit.ascx" tagname="AssetExtendUseEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AssetExtendUseEdit ID="AssetExtendUseEdit1" runat="server" />
</asp:Content>
