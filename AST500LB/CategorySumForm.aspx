<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CategorySumForm.aspx.vb" Inherits="AST500LB.CategorySumForm" %>
<%@ Register src="Controls/CategorySum/CategorySum.ascx" tagname="CategorySum" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CategorySum ID="CategorySum1" runat="server" />
</asp:Content>
