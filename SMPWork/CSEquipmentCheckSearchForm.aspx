<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CSEquipmentCheckSearchForm.aspx.vb" Inherits="SMPWork.CSEquipmentCheckSearchForm" %>
<%@ Register src="Controls/儀器檢測查詢編修/CSEquipmentCheckSearch.ascx" tagname="CSEquipmentCheckSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CSEquipmentCheckSearch ID="CSEquipmentCheckSearch1" runat="server" />
</asp:Content>
