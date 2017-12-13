<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SiteGroupToMessageEditForm.aspx.vb" Inherits="IM.SiteGroupToMessageEditForm" %>
<%@ Register src="Controls/SiteGroupToMessageEdit.ascx" tagname="SiteGroupToMessageEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SiteGroupToMessageEdit ID="SiteGroupToMessageEdit1" runat="server" />
</asp:Content>
