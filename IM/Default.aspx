<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="IM._Default" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</br>查詢:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton1" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="1.訊息定義編修" 
                CssClass="Button1" AuthorizePath="IM01@IM0104" 
                OpenControlPath="IM@MessageEditForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton2" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="2.站台編修" 
                CssClass="Button1" AuthorizePath="IM01@IM0102" 
                OpenControlPath="IM@SiteEditForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton3" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="3.站台群組編修" 
                CssClass="Button1" AuthorizePath="IM01@IM0103" 
                OpenControlPath="IM@SiteGroupEditForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton4" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="4.站台使用者編修" 
                CssClass="Button1" AuthorizePath="IM01@IM0101" 
                OpenControlPath="IM@SiteUserEditForm.aspx" />
</br>對應:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton5" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="5.站台群組對應站台" 
                CssClass="Button1" AuthorizePath="IM01@IM0107" 
                OpenControlPath="IM@SiteGroupToSiteEditForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton6" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="6.站台群組對應訊息定義" 
                CssClass="Button1" AuthorizePath="IM01@IM0105" 
                OpenControlPath="IM@SiteGroupToMessageEditForm.aspx" />
</br>發送訊息:</br>
            <cc1:ucauthorizebutton ID="ucAuthorizeButton7" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="發送訊息" 
                CssClass="Button1" AuthorizePath="IM01@IM0109" 
                OpenControlPath="IM@MessageSenderForm.aspx" />
            <cc1:ucauthorizebutton ID="ucAuthorizeButton8" runat="server" 
                AutoValidMode="VaildToEnableOrDisable" Text="用戶設定即時通知變更" 
                CssClass="Button1" AuthorizePath="IM01@IM0110" 
                OpenControlPath="IM@RemoteClentPCConfigForm.aspx" />
</asp:Content>
