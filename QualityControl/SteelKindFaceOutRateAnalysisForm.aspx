<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SteelKindFaceOutRateAnalysisForm.aspx.vb" Inherits="QualityControl.SteelKindFaceOutRateAnalysisForm" %>
<%@ Register src="Controls/SteelKindFaceOutRateAnalysis/SteelKindFaceOutRateAnalysis.ascx" tagname="SteelKindFaceOutRateAnalysis" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SteelKindFaceOutRateAnalysis ID="SteelKindFaceOutRateAnalysis1" 
        runat="server" />
</asp:Content>
