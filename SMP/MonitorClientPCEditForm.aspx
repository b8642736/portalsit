<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MonitorClientPCEditForm.aspx.vb" Inherits="SMP.MonitorClientPCEditForm" %>
<%@ Register src="Control/MonitorClientPCEdit.ascx" tagname="MonitorClientPCEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MonitorClientPCEdit ID="MonitorClientPCEdit1" runat="server" />
</asp:Content>
