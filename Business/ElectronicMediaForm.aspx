<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ElectronicMediaForm.aspx.vb" Inherits="Business.ElectronicMediaForm" %>
<%@ Register src="Controls/ElectronicMedia.ascx" tagname="ElectronicMedia" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ElectronicMedia ID="ElectronicMedia1" runat="server" />
</asp:Content>
