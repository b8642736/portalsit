<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OXEquipmentCheckSearchForm.aspx.vb" Inherits="SMPWork.OXEquipmentCheckSearchForm" %>
<%@ Register src="Controls/儀器檢測查詢編修/OXEquipmentCheckSearch.ascx" tagname="OXEquipmentCheckSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OXEquipmentCheckSearch ID="OXEquipmentCheckSearch1" runat="server" />
</asp:Content>
