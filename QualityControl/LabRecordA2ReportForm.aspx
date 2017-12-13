<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LabRecordA2ReportForm.aspx.vb" Inherits="QualityControl.LabRecordA2ReportForm" %>
<%@ Register src="Controls/LabRecordA2_Report/LabRecordA2_Report.ascx" tagname="LabRecordA2_Report" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LabRecordA2_Report ID="LabRecordA2_Report1" runat="server" />
</asp:Content>
