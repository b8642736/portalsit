<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="RepairEditForm.aspx.vb" Inherits="MIS.RepairEditForm" %>
<%@ Register src="Controls/RepairEdit.ascx" tagname="RepairEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RepairEdit ID="RepairEdit1" runat="server" />
</asp:Content>
