<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InspectionSearchForm.aspx.vb" Inherits="QualityControl.InspectionSearchForm" %>
<%@ Register src="Controls/InspectionSearch.ascx" tagname="InspectionSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InspectionSearch ID="InspectionSearch1" runat="server" />
</asp:Content>
