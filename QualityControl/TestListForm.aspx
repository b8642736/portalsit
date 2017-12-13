<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="TestListForm.aspx.vb" Inherits="QualityControl.TestListForm" %>
<%@ Register src="Controls/TestList.ascx" tagname="TestList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TestList ID="TestList2" runat="server" />
</asp:Content>
