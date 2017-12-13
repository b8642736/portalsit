<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="ProcessSchedualEditForm.aspx.vb" Inherits="ColdRollingProcess.ProcessSchedualEditForm" %>
<%@ Register src="Controls/ProcessSchedualEdit.ascx" tagname="ProcessSchedualEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProcessSchedualEdit ID="ProcessSchedualEdit1" runat="server" />
</asp:Content>
