<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BlackCoilSearchForm.aspx.vb" Inherits="QualityControl.BlackCoilSearchForm" %>
<%@ Register src="Controls/BlackCoilSearch.ascx" tagname="BlackCoilSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BlackCoilSearch ID="BlackCoilSearch1" runat="server" />
</asp:Content>
