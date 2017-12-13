<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="WebMemberForGroup.aspx.vb" Inherits="WebAppAuthority.WebMemberForGroup" %>
<%@ Register src="Control/WebMemberForWebGroup.ascx" tagname="WebMemberForWebGroup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebMemberForWebGroup ID="WebMemberForWebGroup1" runat="server" />
</asp:Content>
