<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SQLServerElementControlSearchForm.aspx.vb" Inherits="QualityControl.SQLServerElementControlSearchForm" %>
<%@ Register src="Controls/SQLServerElementControlSearch.ascx" tagname="SQLServerElementControlSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SQLServerElementControlSearch ID="SQLServerElementControlSearch1" 
        runat="server" />
</asp:Content>
