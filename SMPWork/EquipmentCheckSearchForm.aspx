<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="EquipmentCheckSearchForm.aspx.vb" Inherits="SMPWork.EquipmentCheckSearchForm" %>
<%@ Register src="Controls/儀器檢測查詢編修/EquipmentCheckSearch.ascx" tagname="EquipmentCheckSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EquipmentCheckSearch ID="EquipmentCheckSearch1" runat="server" />
</asp:Content>
