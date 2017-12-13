<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InsuranceEditForm.aspx.vb" Inherits="AST500LB.InsuranceEditForm" %>
<%@ Register src="Controls/Insurance/InsuranceEdit.ascx" tagname="InsuranceEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InsuranceEdit ID="InsuranceEdit1" runat="server" />
</asp:Content>
