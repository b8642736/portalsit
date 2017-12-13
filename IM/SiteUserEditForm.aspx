<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SiteUserEditForm.aspx.vb" Inherits="IM.SiteUserEditForm" %>
<%@ Register src="Controls/SiteUserEdit.ascx" tagname="SiteUserEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SiteUserEdit ID="SiteUserEdit1" runat="server" />
</asp:Content>
