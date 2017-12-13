<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CoilExamineRecForm.aspx.vb" Inherits="QualityControl.CoilExamineRecForm" %>
<%@ Register src="Controls/CoilExamineRec.ascx" tagname="CoilExamineRec" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CoilExamineRec ID="CoilExamineRec1" runat="server" />
</asp:Content>
