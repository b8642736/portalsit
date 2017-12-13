<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="SMPWork._Default" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    </br>查詢:</br>
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="分光儀儀器檢測資料查詢" 
                    CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0101" 
                    OpenControlPath="SMPWork@EquipmentCheckSearchForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="氮氧儀儀器檢測資料查詢" CssClass="Button1"  AuthorizePath="SMPWRK01@SMPWRK0101" OpenControlPath="SMPWork@OXEquipmentCheckSearchForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="碳硫儀儀器檢測資料查詢" CssClass="Button1"  AuthorizePath="SMPWRK01@SMPWRK0101" OpenControlPath="SMPWork@CSEquipmentCheckSearchForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="樣本取樣品質統計表" CssClass="Button1"  AuthorizePath="SMPWRK01@SMPWRK0102" OpenControlPath="SMPWork@SampleStatusReportForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="樣本取樣品質細目查詢" CssClass="Button1"  AuthorizePath="SMPWRK01@SMPWRK0103" OpenControlPath="SMPWork@SampleStatusDetailSearchForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="爐號成份變更查詢" CssClass="Button1"  AuthorizePath="SMPWRK01@SMPWRK0115" OpenControlPath="SMPWork@ElementChangeSearchForm.aspx" />

    </br>編修:</br>
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="煉鋼配料排程編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0105" OpenControlPath="SMPWork@DosingScheduleEditForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="標準樣本上下限編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0110" OpenControlPath="SMPWork@StandSampleRangeEditForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="溫濕度編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0111" OpenControlPath="SMPWork@HumitureEditForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="AS400爐號成份編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0112" OpenControlPath="SMPWork@AS400StoveElementEditForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="即時訊息Email編修" 
                    CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0113" 
                    OpenControlPath="SMPWork@MailMsgEditForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="成品判定編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0114" OpenControlPath="SMPWork@JudgeEditForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="標準樣本標準差管制編修" CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0116" OpenControlPath="SMPWork@StandSampleStdDevEditForm.aspx" />

    </br>報表:</br>
                 <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="成品輻射劑量檢測紀錄表" 
        CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0104" OpenControlPath="SMPWork@RadiationReportMakerForm.aspx" />
                 <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="儀器校驗記錄A" 
        CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0108" OpenControlPath="SMPWork@EquipmentCheckPrintForm.aspx" />
                <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="化驗報告單印表" 
        CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0109" OpenControlPath="SMPWork@LaboratoryReportMakerForm.aspx" />
    </br>其它:</br>
                 <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
                    AutoValidMode="VaildToEnableOrDisable" Text="煉鋼即時通工作平台" 
        CssClass="Button1" AuthorizePath="SMPWRK01@SMPWRK0107" 
        OpenControlPath="SMPIMClient@SMPIMClient.application" />

</asp:Content>
