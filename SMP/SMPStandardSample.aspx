<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SMPStandardSample.aspx.vb" Inherits="SMP.SMPStandardSample" %>
<%@ Register src="Control/SMPStandardSampleEdit.ascx" tagname="SMPStandardSampleEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SMPStandardSampleEdit ID="SMPStandardSampleEdit1" runat="server" />
</asp:Content>
