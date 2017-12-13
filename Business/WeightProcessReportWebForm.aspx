<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="WeightProcessReportWebForm.aspx.vb" Inherits="Business.WeightProcessReportWebForm" %>
<%@ Register src="Controls/WeightProcessReport/WeightProcessReport.ascx" tagname="WeightProcessReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WeightProcessReport ID="WeightProcessReport1" runat="server" />
</asp:Content>
