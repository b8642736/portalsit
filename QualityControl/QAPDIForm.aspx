<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="QAPDIForm.aspx.vb" Inherits="QualityControl.QAPDIForm" %>
<%@ Register src="Controls/QAPDI.ascx" tagname="QAPDI" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:QAPDI ID="QAPDI1" runat="server" />
</asp:Content>
