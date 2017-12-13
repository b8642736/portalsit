<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="QualityControl._Default" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>查詢<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0101" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilDefectSearchForm.aspx" Text="鋼捲缺陷查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton23" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0123" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilDefectExtendSearchForm.aspx" Text="鋼捲缺陷及煉鋼參數查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0102" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@MainDefectSearchForm.aspx" Text="鋼捲主要缺陷查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0103" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@SLABBeforeOutElementSearchForm.aspx" Text="待熱軋鋼胚查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0104" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="QualityControl@CoilRealWidthSearchForm.aspx" Text="鋼捲實際寬度查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0105" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilDefectEntrustSearchForm.aspx" Text="委託加工鋼捲缺陷查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0106" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilDefectPurchaseSearchForm.aspx" Text="外購鋼捲缺陷查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0107" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@StoveElementSearchForm.aspx" 
        Text="爐號成份查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0110" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="QualityControl@SQLServerStoveElementSearchForm.aspx"
        Text="SQLServer爐號成份查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0108" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilLineWidthHeightSearchForm.aspx"
        Text="鋼捲產線寬厚查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0109" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@BlackCoilSearchForm.aspx"
        Text="黑皮鋼捲資料查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0112" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="QualityControl@YieldRateSearchForm.aspx"
        Text="鋼捲產出率查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton20" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0120" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" OpenControlPath="QualityControl@YieldRateSearch2Form.aspx"
        Text="鋼捲產出率查詢2" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0113" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilProgressSearchForm.aspx"
        Text="鋼捲生產進度查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0114" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@SQLServerElementControlSearchForm.aspx" 
        Text="SQLServer煉鋼成份管制查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0116" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@HotRollingSearchForm.aspx"
        Text="熱軋品管查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0117" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilLevelWeightSearchForm.aspx"
        Text="鋼捲等級重量查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0118" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@ProductBugWeightSearchForm.aspx"
        Text="成品鋼捲等級重量查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0115" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@NatureAttributeSearchForm.aspx"
        Text="物理性能查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton21" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0121" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilNumberInfosForm.aspx"
        Text="發貨鋼捲爐號查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton22" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0122" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@ProductBugSearchForm.aspx"
        Text="成品缺陷細目查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton24" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0124" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilExamineRecForm.aspx"
        Text="鋼捲檢驗記錄查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton25" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0125" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@BlackCoilOEMSearchForm.aspx"
        Text="黑皮代軋資料查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton26" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0126" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CoilNatureAndChemistryAttributeSearchForm.aspx"
        Text="鋼捲物理化學性能查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton27" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0127" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@ProductBugStatisticsForm.aspx"
        Text="缺陷類別統計" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton28" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0128" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@ProductLoseStatisticsForm.aspx"
        Text="產出損失統計" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton29" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0129" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@StoveElementSearchOtherForm.aspx"
        Text="外購與委驗(自驗)成分查詢" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton30" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0130" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@StoveElementOutBuySearchForm.aspx"
        Text="外購爐號成份查詢" />
     <cc1:ucAuthorizeButton ID="ucAuthorizeButton33" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0133" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@InspectionSearchForm.aspx"
        Text="檢驗證明查詢" />
     <cc1:ucAuthorizeButton ID="ucAuthorizeButton40" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0140" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@CSSearchForm.aspx"
        Text="客訴資料查詢" />
       <br/>軋鋼品管編修<br/>
     <cc1:ucAuthorizeButton ID="ucAuthorizeButton31" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0131" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@QAPDIForm.aspx"
        Text="成品線作業規定編修" />
     <cc1:ucAuthorizeButton ID="ucAuthorizeButton32" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0132" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@QABugRecordEditForm.aspx"
        Text="品管缺陷編修作業" />
     <cc1:ucAuthorizeButton ID="ucAuthorizeButton34" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0134" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@QABugEditForm.aspx"
        Text="軋鋼缺陷定義編修" />
   <br/>報表<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton18" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0111" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@SteelKindFaceOutRateAnalysisForm.aspx"
        Text="鋼種面表合格率分析" />    
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton19" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0119" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@HomeSellReviewForm.aspx"
        Text="成品一級品率檢討" />

       <br/>無輻射證明<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton35" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0135" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="ColdRollingProcess@SystemNoteEditForm_QualityControl_NonRadioactive.aspx"
        Text="片語編修_無輻射證明" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton36" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0136" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@NonRadioactiveSearchForm.aspx"
        Text="無輻射證明編修" />


     <br/>檢驗證明書<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton37" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0137" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@LabRecordA2SettingForm.aspx"
        Text="基本檔設定" />

    <cc1:ucAuthorizeButton ID="ucAuthorizeButton38" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0138" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@LabRecordA2ReportForm.aspx"
        Text="檢驗報告輸入" />

    <cc1:ucAuthorizeButton ID="ucAuthorizeButton39" runat="server" 
        AuthorizePath="QTYCTL01@QTYCTL0139" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="QualityControl@LabRecordA2EditForm.aspx"
        Text="檢驗證書編修" />
</asp:Content>
