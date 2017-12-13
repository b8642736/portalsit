<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="RemoteClentPCConfigForm.aspx.vb" Inherits="IM.RemoteClentPCConfigForm"  %>
<%@ Register src="Controls/RemoteClentPCConfig.ascx" tagname="RemoteClentPCConfig" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RemoteClentPCConfig ID="RemoteClentPCConfig1" runat="server" />
</asp:Content>
