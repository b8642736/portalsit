<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="RGSGrindRecordEditForm.aspx.vb" Inherits="ColdRollingProcess.RGSGrindRecordEditForm" %>
<%@ Register src="Controls/RGSGrindRecordEdit.ascx" tagname="RGSGrindRecordEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RGSGrindRecordEdit ID="RGSGrindRecordEdit1" runat="server" />
</asp:Content>
