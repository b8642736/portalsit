<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SQLServerStoveElementSearchForm.aspx.vb" Inherits="QualityControl.SQLServerStoveElementSearchForm" %>
<%@ Register src="Controls/SQLServerStoveElementSearch.ascx" tagname="SQLServerStoveElementSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SQLServerStoveElementSearch ID="SQLServerStoveElementSearch1" 
        runat="server" />
</asp:Content>
