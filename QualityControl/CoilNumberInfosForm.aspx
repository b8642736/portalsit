<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilNumberInfosForm.aspx.vb" Inherits="QualityControl.CoilNumberInfosForm" %>
<%@ Register src="Controls/CoilNumberInfos.ascx" tagname="CoilNumberInfos" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilNumberInfos ID="CoilNumberInfos1" runat="server" />
</asp:Content>
