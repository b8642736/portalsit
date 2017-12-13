<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="RadiationReportMakerForm.aspx.vb" Inherits="SMPWork.RadiationReportMakerForm" %>
<%@ Register src="Controls/RadiationReport/RadiationReportMaker.ascx" tagname="RadiationReportMaker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RadiationReportMaker ID="RadiationReportMaker1" runat="server" />
</asp:Content>
