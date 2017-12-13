<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ContinueInsuranceSearchForm.aspx.vb" Inherits="AST500LB.ContinueInsuranceSearchForm" %>
<%@ Register src="Controls/Insurance/ContinueInsuranceSearch.ascx" tagname="ContinueInsuranceSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ContinueInsuranceSearch ID="ContinueInsuranceSearch1" runat="server" />
</asp:Content>
