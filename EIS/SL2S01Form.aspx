<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SL2S01Form.aspx.vb" Inherits="EIS.SL2S01Form" %>
<%@ Register src="Controls/SL2S01Search.ascx" tagname="SL2S01Search" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SL2S01Search ID="SL2S01Search1" runat="server" />
</asp:Content>
