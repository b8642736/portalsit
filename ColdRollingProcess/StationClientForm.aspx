<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="StationClientForm.aspx.vb" Inherits="ColdRollingProcess.StationClientForm" %>
<%@ Register src="Controls/StationClient/StationClient.ascx" tagname="StationClient" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StationClient ID="StationClient2" runat="server" />
</asp:Content>
