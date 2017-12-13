<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="Financial._Default" %>
<%@ Register src="Control/InvoiceXMLDownload.ascx" tagname="InvoiceXMLDownload" tagprefix="uc1" %>
<%@ Register assembly="UCAjaxServerControl1" namespace="UCAjaxServerControl1" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />查詢:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server" 
        CssClass="Button1" Text="付款查詢" AuthorizePath="FIN01@FIN0101" 
        OpenControlPath="Financial@PayMoneySearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server" 
        CssClass="Button1" Text="財務收入查詢" AuthorizePath="FIN01@FIN0104" 
        OpenControlPath="Financial@CasherInForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server" 
        CssClass="Button1" Text="出納支出查詢" AuthorizePath="FIN01@FIN0105" 
        OpenControlPath="Financial@CashierOutForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server" 
        CssClass="Button1" Text="每日發票收款查詢" AuthorizePath="FIN01@FIN0107" 
        OpenControlPath="Financial@InvoiceDayMoneySumSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton14" runat="server" 
        CssClass="Button1" Text="國內押匯查詢" AuthorizePath="FIN01@FIN0108" 
        OpenControlPath="Financial@ChangeSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
        <cc1:ucauthorizebutton ID="ucAuthorizeButton16" runat="server" 
        CssClass="Button1" Text="債務信用狀查詢" AuthorizePath="FIN01@FIN0109" 
        OpenControlPath="Financial@DebtLetterofCreditSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton18" runat="server" 
        CssClass="Button1" Text="待付款傳票資料" AuthorizePath="FIN01@FIN0113" 
        OpenControlPath="Financial@PendingPaymentSearchForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    
    <br />銀行借款作業:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server" 
        CssClass="Button1" Text="銀行額度編修" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@BorrowContract.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server" 
        CssClass="Button1" Text="銀行額度利率編修" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@BorrowContractRate.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server" 
        CssClass="Button1" Text="借款/LC開狀作業" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@Borrow.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server" 
        CssClass="Button1" Text="一般還款作業" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@BorrowPayMoney.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server" 
        CssClass="Button1" Text="LC發生/到單作業" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@BorrowLCBill.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server" 
        CssClass="Button1" Text="LC還款作業" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@BorrowLCBillPayMoney.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server" 
        CssClass="Button1" Text="長期借款明細表" AuthorizePath="FIN01@FIN0102" 
        OpenControlPath="Financial@LongBorrowDetailForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br />電子發票/交運清單轉XML下載:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server" 
        CssClass="Button1" Text="電子發票/交運清單轉XML下載" AuthorizePath="FIN01@FIN0103" 
        OpenControlPath="Financial@InvoiceXMLDownloadForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br />AS400作業:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server" 
        CssClass="Button1" Text="LC債務查詢編修" AuthorizePath="FIN01@FIN0106" 
        OpenControlPath="Financial@LCDebitEditForm.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <br />收款通知單:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server" 
        CssClass="Button1" Text="片語編修_收款通知單" AuthorizePath="FIN01@FIN0110" 
        OpenControlPath="ColdRollingProcess@SystemNoteEditForm_Financial_InvoiceOfReceivables.aspx" 
        AutoValidMode="VaildToEnableOrDisable" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton17" runat="server" 
        CssClass="Button1" Text="收款通知單編修" AuthorizePath="FIN01@FIN0112" 
        OpenControlPath="Financial@InvoiceOfReceivablesForm.aspx" 
        AutoValidMode="None"  />
</asp:Content>
