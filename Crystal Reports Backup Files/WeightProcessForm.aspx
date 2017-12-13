<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="WeightProcessForm.aspx.vb" Inherits="Business.WeightProcessForm" %>
<%@ Register src="Controls/WeightProcess/WeightProcess.ascx" tagname="WeightProcess" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WeightProcess ID="WeightProcess1" runat="server" />
</asp:Content>
