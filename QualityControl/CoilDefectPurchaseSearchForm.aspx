<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilDefectPurchaseSearchForm.aspx.vb" Inherits="QualityControl.CoilDefectPurchaseSearchForm" %>
<%@ Register src="Controls/CoilDefectPurchaseSearch.ascx" tagname="CoilDefectPurchaseSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilDefectPurchaseSearch ID="CoilDefectPurchaseSearch1" runat="server" />
</asp:Content>
