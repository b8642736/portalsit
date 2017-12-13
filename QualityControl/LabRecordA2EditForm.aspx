<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LabRecordA2EditForm.aspx.vb" Inherits="QualityControl.LabRecordA2EditForm" %>

<%@ Register src="Controls/LabRecordA2_Edit/LabRecordA2_Main.ascx" tagname="LabRecordA2_Main" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:LabRecordA2_Main ID="LabRecordA2_Main1" runat="server" />
    
</asp:Content>
