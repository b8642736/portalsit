<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SiteGroupEditForm.aspx.vb" Inherits="IM.SiteGroupEditForm" %>
<%@ Register src="Controls/SiteGroupEdit.ascx" tagname="SiteGroupEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SiteGroupEdit ID="SiteGroupEdit1" runat="server" />
</asp:Content>
