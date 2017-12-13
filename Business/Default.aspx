<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Business._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <BR />查詢編修作業:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="訂單提貨查詢" AuthorizePath="BUS01@BUS0101" 
        OpenControlPath="Business@TakeGoodSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="客戶基本資料查詢" AuthorizePath="BUS01@BUS0102" 
        OpenControlPath="Business@CustomerBasicDataSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="客戶出貨噸數金額統計表" AuthorizePath="BUS01@BUS0108" 
        OpenControlPath="Business@CustumerSellWeightMoneyAmouontForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="客戶訂單平均厚度統計表" AuthorizePath="BUS01@BUS0114" 
        OpenControlPath="Business@OrderAvgThickSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="客戶毛利分析" AuthorizePath="BUS01@BUS0115" 
        OpenControlPath="Business@CustomerIncomeAnalysisForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="客訴查詢編修" AuthorizePath="BUS01@BUS0116" 
        OpenControlPath="Business@GuestSuesForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton21" runat="server" 
        CssClass="Button1" Text="媒體申報檔刪除" AuthorizePath="BUS01@BUS0120" 
        OpenControlPath="Business@ElectronicMediaForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton22" runat="server" 
        CssClass="Button1" Text="客戶對帳單查詢" AuthorizePath="BUS01@BUS0121" 
        OpenControlPath="Business@PickGoodDetailSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />

    <BR />成品庫作業:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="產品出貨車輛登入" AuthorizePath="BUS01@BUS0105" 
        OpenControlPath="Business@ProductOutCheckForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" Visible ="false"  />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="鋼捲過磅作業" AuthorizePath="BUS01@BUS0106" 
        OpenControlPath="Business@WeightProcessForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" Visible ="false" />
        <cc1:ucAuthorizeButton ID="ucAuthorizeButton19" runat="server" 
        CssClass="Button1" Text="鋼捲過磅紀錄查詢" AuthorizePath="BUS01@BUS0118" 
        OpenControlPath="Business@WeightProcessForm2.aspx" 
        AutoValidMode="VaildToEnableOrDisable"  />
        <cc1:ucAuthorizeButton ID="ucAuthorizeButton20" runat="server" 
        CssClass="Button1" Text="成品庫夾襯紙鋼捲查詢" AuthorizePath="BUS01@BUS0119" 
        OpenControlPath="Business@ClipPaperForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable"  />


    <BR />報表:<BR/>
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
        CssClass="Button1" Text="訂單彙整列印" AuthorizePath="BUS01@BUS0101" 
        OpenControlPath="Business@OrderSummaryPrintForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
        CssClass="Button1" Text="訂單承訂未交列印" AuthorizePath="BUS01@BUS0103" 
        OpenControlPath="Business@OrderNotSendForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
        CssClass="Button1" Text="成品無主庫存印列" AuthorizePath="BUS01@BUS0104" 
        OpenControlPath="Business@NoMasterStockForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
        CssClass="Button1" Text="成品有主庫存印列" AuthorizePath="BUS01@BUS0117" 
        OpenControlPath="Business@MasterStockForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
        CssClass="Button1" Text="成品繳庫單抄本印列" AuthorizePath="BUS01@BUS0107" 
        OpenControlPath="Business@WeightProcessReportWebForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
        CssClass="Button1" Text="訂單發貨量統計表" AuthorizePath="BUS01@BUS0109" 
        OpenControlPath="Business@OrderSendedForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
        CssClass="Button1" Text="外銷出貨各月訂單統計表" AuthorizePath="BUS01@BUS0110" 
        OpenControlPath="Business@OrderMonthAnalysisControlForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
        CssClass="Button1" Text="提貨單發貨量統計表" AuthorizePath="BUS01@BUS0111" 
        OpenControlPath="Business@BillSendedForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
        CssClass="Button1" Text="客戶外銷訂單發貨量統計表" AuthorizePath="BUS01@BUS0112" 
        OpenControlPath="Business@OrderRealBuyAnalysisForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton18" runat="server" 
        CssClass="Button1" Text="客戶外銷訂單每月發貨量統計表" AuthorizePath="BUS01@BUS0113" 
        OpenControlPath="Business@OrderMonthBuyAnalysisForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
        
</asp:Content>
