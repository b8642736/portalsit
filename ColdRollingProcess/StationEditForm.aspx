<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="StationEditForm.aspx.vb" Inherits="ColdRollingProcess.StationEditForm" %>
<%@ Register src="Controls/StationEdit.ascx" tagname="StationEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StationEdit ID="StationEdit1" runat="server" />
</asp:Content>
