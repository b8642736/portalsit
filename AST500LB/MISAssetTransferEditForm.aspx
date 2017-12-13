<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MISAssetTransferEditForm.aspx.vb" Inherits="AST500LB.MISAssetTransferEditForm" %>
<%@ Register src="Controls/MISAssetTransferEdit/MISAssetTransferEdit.ascx" tagname="MISAssetTransferEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MISAssetTransferEdit ID="MISAssetTransferEdit1" runat="server" />
</asp:Content>
