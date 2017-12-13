<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilLevelWeightSearchForm.aspx.vb" Inherits="QualityControl.CoilLevelWeightSearchForm" %>
<%@ Register src="Controls/CoilLevelWeightSearch.ascx" tagname="CoilLevelWeightSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilLevelWeightSearch ID="CoilLevelWeightSearch1" runat="server" />
</asp:Content>
