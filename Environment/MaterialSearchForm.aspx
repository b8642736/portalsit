<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MaterialSearchForm.aspx.vb" Inherits="Environment.MaterialSearchForm" %>
<%@ Register src="Controls/MaterialSearch.ascx" tagname="MaterialSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MaterialSearch ID="MaterialSearch1" runat="server" />
</asp:Content>
