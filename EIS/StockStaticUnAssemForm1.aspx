<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StockStaticUnAssemForm1.aspx.vb" Inherits="EIS.StockStaticUnAssemForm1" %>
<%@ Register src="Controls/StockStaticUnAssem.ascx" tagname="StockStaticUnAssem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:StockStaticUnAssem ID="StockStaticUnAssem1" runat="server"  SystemRunModeText="無主庫存_不含客戶保留"/>

</asp:Content>
