﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LaboratoryReportMakerForm.aspx.vb" Inherits="SMPWork.LaboratoryReportMakerForm" %>
<%@ Register src="Controls/LaboratoryReport/LaboratoryReportMaker.ascx" tagname="LaboratoryReportMaker" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LaboratoryReportMaker ID="LaboratoryReportMaker1" runat="server" />
</asp:Content>
