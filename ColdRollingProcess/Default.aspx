<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="Default.aspx.vb" Inherits="ColdRollingProcess._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />現場作業:<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="軋鋼現場作業站平台" AuthorizePath="COLD01@COLD0103" 
        OpenControlPath="ColdRollingClient@ColdRollingClient.application" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="軋鋼現場作業備援轉換" AuthorizePath="COLD01@COLD0108" 
        OpenControlPath="ColdRollingClientRowChange@ColdRollingClientRowChange.application" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
        CssClass="Button1" Text="STK過磅平台" AuthorizePath="COLD01@COLD0111" 
        OpenControlPath="POUNDProcess@POUNDProcess.application" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br/>查詢:<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="鋼捲產線狀況查詢" AuthorizePath="COLD01@COLD0105" 
        OpenControlPath="ColdRollingProcess@CoilStationStateSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="黑皮未組查詢" AuthorizePath="COLD01@COLD0106" 
        OpenControlPath="ColdRollingProcess@BlackCoilUnDoSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
        CssClass="Button1" Text="產線重量統計查詢" AuthorizePath="COLD01@COLD0112" 
        OpenControlPath="ColdRollingProcess@LineWeightStatisticsForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
        CssClass="Button1" Text="AS400鋼捲包裝查詢" AuthorizePath="COLD01@COLD0114" 
        OpenControlPath="ColdRollingProcess@PackSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
        CssClass="Button1" Text="軋鋼品管缺陷作業站平台" AuthorizePath="COLD01@COLD0115" 
        OpenControlPath="QAColdRollingClient@QAColdRollingClient.application" 
        AutoValidMode="VaildToEnableOrDisable" />

    <BR />編修:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="生產排程計劃編修" AuthorizePath="COLD01@COLD0101" 
        OpenControlPath="ColdRollingProcess@ProcessSchedualEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="製程作業名稱轉換編修" AuthorizePath="COLD01@COLD0102" 
        OpenControlPath="ColdRollingProcess@InOutOperationLineNameEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="冷軋站台編修" AuthorizePath="COLD01@COLD0104" 
        OpenControlPath="ColdRollingProcess@StationEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
            CssClass="Button1" Text="ZML更換紀錄表編修" AuthorizePath="COLD01@COLD0109" 
            OpenControlPath="ColdRollingProcess@ZmlReplaceHistoryEditForm.aspx" 
            AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
            CssClass="Button1" Text="系統片語編修" AuthorizePath="COLD01@COLD0110" 
            OpenControlPath="ColdRollingProcess@SystemNoteEditForm.aspx" 
            AutoValidMode="VaildToEnableOrDisable" />
    
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
        CssClass="Button1" Text="RGS自主檢查表編修" AuthorizePath="COLD01@COLD0113" 
        OpenControlPath="ColdRollingProcess@RGSGrindRecordEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
        
    
    <p /><p /><hr />
    生計處:<p/>
    編修:<br/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="生計派工編修" AuthorizePath="COLD01@COLD0107" 
        OpenControlPath="ColdRollingProcess@ProductionStartCmdEditbForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
        CssClass="Button1" Text="生計無主庫存鋼捲註記編修" AuthorizePath="COLD01@COLD0117" 
        OpenControlPath="ColdRollingProcess@ProductionNoOnwerEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
            CssClass="Button1" Text="片語編修_鋼捲註記" AuthorizePath="COLD01@COLD0118" 
            OpenControlPath="ColdRollingProcess@SystemNoteEditForm_ProductionNoOnwerEdit.aspx" 
            AutoValidMode="VaildToEnableOrDisable" />
    
    
</asp:Content>
