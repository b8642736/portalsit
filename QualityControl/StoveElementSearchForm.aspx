<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StoveElementSearchForm.aspx.vb" Inherits="QualityControl.StoveElementSearchForm" %>
<%@ Register src="Controls/StoveElementSearch.ascx" tagname="StoveElementSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StoveElementSearch ID="StoveElementSearch1" runat="server" />
</asp:Content>
