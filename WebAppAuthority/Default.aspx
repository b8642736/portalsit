<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="Default.aspx.vb" Inherits="WebAppAuthority._Default" %>

<%@ Register Assembly="WebAppAuthority" Namespace="WebAppAuthority" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    系統授基權本資料:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton1" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="新增/編修系統"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebSystem.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton2" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="新增/編修系統功能"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebSystemFunction.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton3" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="新增/編修使用者"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebUser.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton4" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="新增/編修用戶端電腦"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebClientPC.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton5" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="新增/編修群組"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebGroup.aspx" />
    <br />
    個別方式授權:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton6" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="個人授權"
        CssClass="Button1" AuthorizePath="Auth01@Auth0102"
        OpenControlPath="WebAppAuthority@WebUserAuthority.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton8" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="電腦IP授權"
        CssClass="Button1" AuthorizePath="Auth01@Auth0102"
        OpenControlPath="WebAppAuthority@WebClientPCAuthority.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton7" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="個人複製授權"
        CssClass="Button1" AuthorizePath="Auth01@Auth0102"
        OpenControlPath="WebAppAuthority@WebUserAuthorityCopys.aspx" />
    <br />
    群組方式授權:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton9" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="群組成員編修"
        CssClass="Button1" AuthorizePath="Auth01@Auth0102"
        OpenControlPath="WebAppAuthority@WebMemberForGroup.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton10" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="群組授權"
        CssClass="Button1" AuthorizePath="Auth01@Auth0101"
        OpenControlPath="WebAppAuthority@WebGroupAuthority.aspx" />
    <br />
    查詢:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton11" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="系統使用權限查詢"
        CssClass="Button1" AuthorizePath="Auth01@Auth0103"
        OpenControlPath="WebAppAuthority@WebUserOrIPAllAuthoritySearchForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton12" runat="server"
        AutoValidMode="VaildToVisible" Text="電子表單密碼查詢"
        CssClass="Button1" AuthorizePath="Auth01@Auth0104"
        OpenControlPath="WebAppAuthority@SPMPasswordSearchForm.aspx" />
    <br />
    CCMail:<br />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton13" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="電子郵件密碼變更"
        CssClass="Button1" AuthorizePath="Auth01@Auth0105"
        OpenControlPath="WebAppAuthority@CCMailPWDForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton15" runat="server"
        AutoValidMode="VaildToEnableOrDisable" Text="同步與維護"
        CssClass="Button1" AuthorizePath="Auth01@Auth0106"
        OpenControlPath="WebAppAuthority@CCMailExcuteForm.aspx" />
    <cc1:ucAuthorizeButton ID="ucAuthorizeButton16" runat="server" 
        AuthorizePath="Auth01@Auth0107" AutoValidMode="VaildToEnableOrDisable" 
        CssClass="Button1" 
        OpenControlPath="ColdRollingProcess@SystemNoteEditForm_WebAppAuthority_CCMail.aspx"
        Text="片語編修_CCMail" />
    
    </asp:Content>
