<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StandardSampleReceiveForm.aspx.vb" Inherits="SMP.StandardSampleReceiveForm" %>
<%@ Register src="Control/StandardSampleReceiveEdit.ascx" tagname="StandardSampleReceiveEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StandardSampleReceiveEdit ID="StandardSampleReceiveEdit1" runat="server" />
</asp:Content>
