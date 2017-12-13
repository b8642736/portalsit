<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/EAF.Master" CodeBehind="MoniterSoftware.aspx.vb" Inherits="EAFWeb.MoniterSoftware" 
    title="未命名頁面" %>
<%@ Register src="Controls/ClientStationExcelFileTransMoniter.ascx" tagname="ClientStationExcelFileTransMoniter" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ClientStationExcelFileTransMoniter ID="ClientStationExcelFileTransMoniter1" 
        runat="server" />
</asp:Content>
