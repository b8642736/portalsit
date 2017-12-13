<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="BlackCoilUnDoSearchForm.aspx.vb" Inherits="ColdRollingProcess.BlackCoilUnDoSearchForm" %>
<%@ Register src="Controls/BlackCoilUnDoSearch.ascx" tagname="BlackCoilUnDoSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BlackCoilUnDoSearch ID="BlackCoilUnDoSearch1" runat="server" />
</asp:Content>
