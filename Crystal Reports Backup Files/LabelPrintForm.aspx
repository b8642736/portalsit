<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LabelPrintForm.aspx.vb" Inherits="Business.LabelPrintForm" %>
<%@ Register src="Controls/LabelPrint/LabelPrint.ascx" tagname="LabelPrint" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LabelPrint ID="LabelPrint1" runat="server" />
</asp:Content>
