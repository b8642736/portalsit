﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InsuranceDetailSearchForm.aspx.vb" Inherits="AST500LB.InsuranceDetailSearchForm" %>
<%@ Register src="Controls/Insurance/InsuranceDetailSearch.ascx" tagname="InsuranceDetailSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InsuranceDetailSearch ID="InsuranceDetailSearch1" runat="server" />
</asp:Content>
