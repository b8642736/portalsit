<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="SMP._Default" %>

<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    查詢:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server"
        CssClass="Button1" Text="監看模式" AuthorizePath="SMP01@SMP0101"
        OpenControlPath="SMP@ElementMoniterForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server"
        CssClass="Button1" Text="成份查詢" AuthorizePath="SMP01@SMP0101"
        OpenControlPath="SMP@ElementSearchForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server"
        CssClass="Button1" Text="用戶端PC連線監控" AuthorizePath="SMP01@SMP0101"
        OpenControlPath="SMP@MonitorClientPCStatusForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <br />
    報表:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server"
        CssClass="Button1" Text="成品輻射劑量檢測紀錄表" AuthorizePath="SMPWRK01@SMPWRK0104"
        OpenControlPath="SMPWork@RadiationReportMakerForm.aspx"
        AutoValidMode="VaildToVisible" />
    <br />
    系統編修設定:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server"
        CssClass="Button1" Text="編修用戶端PC連線監控" AuthorizePath="SMP01@SMP0102"
        OpenControlPath="SMP@MonitorClientPCEditForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server"
        CssClass="Button1" Text="編修製程判定" AuthorizePath="SMP01@SMP0103"
        OpenControlPath="SMP@ProcessGaugeEditForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server"
        CssClass="Button1" Text="標準樣本編修" AuthorizePath="SMP01@SMP0104"
        OpenControlPath="SMP@SMPStandardSample.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server"
        CssClass="Button1" Text="標準樣本接收資料編修" AuthorizePath="SMP01@SMP0105"
        OpenControlPath="SMP@StandardSampleReceiveForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server"
        CssClass="Button1" Text="標準樣本接收資料編修OX" AuthorizePath="SMP01@SMP0106"
        OpenControlPath="SMP@StandardSampleOXReceiveForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server"
        CssClass="Button1" Text="標準樣本接收資料編修CS_儀器匯入" AuthorizePath="SMP01@SMP0107"
        OpenControlPath="SMP@StandardSampleCS_InstrReceiveForm.aspx"
        AutoValidMode="VaildToEnableOrDisable" />
</asp:Content>
