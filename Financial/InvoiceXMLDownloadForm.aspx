<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="InvoiceXMLDownloadForm.aspx.vb" Inherits="Financial.InvoiceXMLDownloadForm" %>
<%@ Register src="Control/InvoiceXMLDownload.ascx" tagname="InvoiceXMLDownload" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InvoiceXMLDownload ID="InvoiceXMLDownload1" runat="server" />
</asp:Content>
