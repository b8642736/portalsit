<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="Default.aspx.vb" Inherits="OtherOperator._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</br>查詢:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton1" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="AS400SQL查詢" 
                CssClass="Button1" AuthorizePath="Other01@Other0102" 
                OpenControlPath="OtherOperator@AS400SQLQueryForm.aspx" />
</br>編修:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton2" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="公佈欄編修" 
                CssClass="Button1" AuthorizePath="Other01@Other0101" 
                OpenControlPath="OtherOperator@MessageBoard.aspx" />
</br>轉換:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton3" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="AS400資料庫定義轉VB類別" 
                CssClass="Button1" AuthorizePath="Other01@Other0104" 
                OpenControlPath="OtherOperator@AS400DBPFToVBClassForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton4" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="SQLServer資料庫定義轉VB類別" 
                CssClass="Button1" AuthorizePath="Other01@Other0104" 
                OpenControlPath="OtherOperator@SQLServerDBToVBClassForm.aspx" />
</br>其它:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton5" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="檔案共享" 
                CssClass="Button1" AuthorizePath="Other01@Other0106" 
                OpenControlPath="OtherOperator@FileSharedForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton6" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="AS400與SQLServerDB轉檔" 
                CssClass="Button1" AuthorizePath="Other01@Other0107" 
                OpenControlPath="SQLVsAS400DataTransfer@SQLVsAS400DataTransfer.application" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton7" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="舊單位轉換新單位" 
                CssClass="Button1" AuthorizePath="Other01@Other0102" 
                OpenControlPath="OtherOperator@OldDeptTransNewDeptForm.aspx" />
</asp:Content>
