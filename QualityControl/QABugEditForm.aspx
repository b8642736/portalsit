<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="QABugEditForm.aspx.vb" Inherits="QualityControl.QABugEditForm" %>
<%@ Register src="Controls/QABugEdit.ascx" tagname="QABugEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:QABugEdit ID="QABugEdit1" runat="server" />
</asp:Content>
