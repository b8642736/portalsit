<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/EAF.Master" CodeBehind="ConvertDBToExcelFile.aspx.vb" Inherits="EAFWeb.ConvertDBToExcelFile" 
    title="未命名頁面" %>
<%@ Register src="~/Controls/ConvertDBToExcel.ascx" tagname="ConvertDBToExcel" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ConvertDBToExcel ID="ConvertDBToExcel1" runat="server" />
</asp:Content>
