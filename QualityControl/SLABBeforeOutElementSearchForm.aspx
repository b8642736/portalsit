<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SLABBeforeOutElementSearchForm.aspx.vb" Inherits="QualityControl.SLABBeforeOutElementSearchForm" %>
<%@ Register src="Controls/SLABBeforeOutElementSearch.ascx" tagname="SLABBeforeOutElementSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SLABBeforeOutElementSearch ID="SLABBeforeOutElementSearch1" 
        runat="server" />
</asp:Content>
