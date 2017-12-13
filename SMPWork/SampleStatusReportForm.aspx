<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SampleStatusReportForm.aspx.vb" Inherits="SMPWork.SampleStatusReportForm" %>
<%@ Register src="Controls/SampleStatusReport/SampleStatusReport.ascx" tagname="SampleStatusReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SampleStatusReport ID="SampleStatusReport1" runat="server" />
</asp:Content>
