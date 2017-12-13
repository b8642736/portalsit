<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%--<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LabRecordA2SettingForm.aspx.vb" Inherits="QualityControl.LabRecordA2SettingForm" %>--%>
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LabRecordA2SettingForm.aspx.vb" Inherits="QualityControl.LabRecordA2SettingForm" EnableEventValidation="false" %>

<%@ Register Src="Controls/LabRecordA2_Setting/LabRecordA2_Setting_Main.ascx" TagName="LabRecordA2_Setting_Main" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



            <uc1:LabRecordA2_Setting_Main ID="LabRecordA2_Setting_Main1" runat="server" />

</asp:Content>
