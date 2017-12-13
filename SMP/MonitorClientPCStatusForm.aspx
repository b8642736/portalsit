<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="MonitorClientPCStatusForm.aspx.vb" Inherits="SMP.MonitorClientPCStatusForm" %>
<%@ Register src="~/control/MonitorCleintPCStatus.ascx" tagname="MonitorCleintPCStatus" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MonitorCleintPCStatus ID="MonitorCleintPCStatus1" runat="server" />
</asp:Content>
