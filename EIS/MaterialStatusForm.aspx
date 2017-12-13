<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MaterialStatusForm.aspx.vb" Inherits="EIS.MaterialStatusForm" %>
<%@ Register src="Controls/MaterialStatusSearch.ascx" tagname="MaterialStatusSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MaterialStatusSearch ID="MaterialStatusSearch1" runat="server" />
</asp:Content>
