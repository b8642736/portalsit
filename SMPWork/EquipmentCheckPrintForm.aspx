<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="EquipmentCheckPrintForm.aspx.vb" Inherits="SMPWork.EquipmentCheckPrintForm" %>
<%@ Register src="Controls/儀器檢測查詢編修/EquipmentCheckPrint.ascx" tagname="EquipmentCheckPrint" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EquipmentCheckPrint ID="EquipmentCheckPrint1" runat="server" />
</asp:Content>
