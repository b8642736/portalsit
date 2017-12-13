<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SiteGroupToSiteEditForm.aspx.vb" Inherits="IM.SiteGroupToSiteEditForm" %>
<%@ Register src="Controls/SiteGroupToSiteEdit.ascx" tagname="SiteGroupToSiteEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SiteGroupToSiteEdit ID="SiteGroupToSiteEdit1" runat="server" />
</asp:Content>
