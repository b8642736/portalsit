<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="SystemNoteEditForm_ProductionNoOnwerEdit.aspx.vb" Inherits="ColdRollingProcess.SystemNoteEditForm_ProductionNoOnwerEdit" %>
<%@ Register src="Controls/SystemNote.ascx" tagname="SystemNote" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SystemNote ID="SystemNote1" runat="server" />
</asp:Content>
