<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="DepreciationSearch.aspx.vb" Inherits="Accounting.DepreciationSearch" %>
<%@ Register src="FAM/Depreciation.ascx" tagname="Depreciation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Depreciation ID="Depreciation1" runat="server" />
</asp:Content>
