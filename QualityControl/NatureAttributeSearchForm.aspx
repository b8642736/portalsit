<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="NatureAttributeSearchForm.aspx.vb" Inherits="QualityControl.NatureAttributeSearchForm" %>
<%@ Register src="Controls/NatureAttributeSearch.ascx" tagname="NatureAttributeSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NatureAttributeSearch ID="NatureAttributeSearch1" runat="server" />
</asp:Content>
