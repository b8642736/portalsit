<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StandardSampleOXReceiveForm.aspx.vb" Inherits="SMP.StandardSampleOXReceiveForm" %>
<%@ Register src="Control/StandardSampleOXReceiveEdit.ascx" tagname="StandardSampleOXReceiveEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StandardSampleOXReceiveEdit ID="StandardSampleOXReceiveEdit1" runat="server" />
</asp:Content>
