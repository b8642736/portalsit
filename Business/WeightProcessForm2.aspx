<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="WeightProcessForm2.aspx.vb" Inherits="Business.WeightProcessForm2" %>
<%@ Register src="Controls/WeightProcess2/WeightProcess2.ascx" tagname="WeightProcess2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WeightProcess2 ID="WeightProcess21" runat="server" />
</asp:Content>
