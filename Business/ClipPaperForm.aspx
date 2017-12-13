<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ClipPaperForm.aspx.vb" Inherits="Business.ClipPaperForm" %>
<%@ Register src="Controls/ClipPaper/ClipPaper.ascx" tagname="ClipPaper" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ClipPaper ID="ClipPaper1" runat="server" />
</asp:Content>
