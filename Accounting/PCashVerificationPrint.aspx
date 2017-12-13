<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="PCashVerificationPrint.aspx.vb" Inherits="Accounting.PCashVerificationPrint" %>
<%@ Register src="PCash/PCashVerificationReportMaker.ascx" tagname="PCashVerificationReportMaker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PCashVerificationReportMaker ID="PCashVerificationReportMaker1" 
        runat="server" />
</asp:Content>
