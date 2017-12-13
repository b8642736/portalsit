<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SiteEditForm.aspx.vb" Inherits="IM.SiteEditForm" %>
<%@ Register src="Controls/SiteEdit.ascx" tagname="SiteEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SiteEdit ID="SiteEdit1" runat="server" />
</asp:Content>
