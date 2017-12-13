<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PortalSite.Master" CodeBehind="StartContent.aspx.vb" Inherits="PortalSit.StartContent"
    Title="��a���q�{���@�~�J�f����" Culture="zh-TW" UICulture="zh-CHT" %>

<%@ Register Src="Control/MessageDisplay.ascx" TagName="MessageDisplay" TagPrefix="uc1" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StartContent.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnEIS" runat="server" AuthorizePath="EIS01"
                        AutoValidMode="VaildToEnableOrDisable" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="EIS@Default.aspx" Text="�����T�@�~" /></td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnSMP" runat="server" AuthorizePath="Smp01"
                        AutoValidMode="VaildToEnableOrDisable" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="SMP@Default.aspx" Text="�����ǧ@�~" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnSPMWork" runat="server"
                        AuthorizePath="SMPWRK01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="SMPWork" Text="�����Ǥu�@��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnStockStatic" runat="server"
                        AuthorizePath="Stock01" AutoValidMode="VaildToEnableOrDisable"
                        class="ButtonStyle" CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="StockStatic" Text="�ҿ�/�w�s" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnQualityControl" runat="server"
                        AuthorizePath="QTYCTL01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="QualityControl" Text="�~�O�B" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnColdRollingProcess" runat="server"
                        AuthorizePath="COLD01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="ColdRollingProcess" Text="�N��{���@�~" />
                </td>

            </tr>
            <tr>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnAST500LB" runat="server"
                        AuthorizePath="AST01" AutoValidMode="VaildToEnableOrDisable"
                        class="ButtonStyle" CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="AST500LB@Default.aspx" Text="�T�w�겣" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnAccounting" runat="server"
                        AuthorizePath="ACC01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="Accounting@Default.aspx" Text="�|�p�t��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnFinancial" runat="server" AuthorizePath="FIN01"
                        AutoValidMode="None"  class="ButtonStyle" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="Financial" Text="�]��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnBUY" runat="server" AuthorizePath="BUY01"
                        AutoValidMode="VaildToEnableOrDisable" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="BUY" Text="����" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnBusiness" runat="server" AuthorizePath="BUS01"
                        AutoValidMode="VaildToEnableOrDisable" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="Business@Default.aspx" Text="�~��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnBusiness0" runat="server" AuthorizePath="PSN01"
                        AutoValidMode="None" CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="Personnel@Default.aspx" Text="��F�B" />
                </td>

            </tr>
            <tr>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnIM" runat="server"
                        AuthorizePath="IM01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="IM@Default.aspx" Text="�Y�ɳq�T�t��" /></td>
                <td>
                    <cc2:ucAuthorizeButton ID="UcAuthorizeButton1" runat="server"
                        AuthorizePath="ECO01" AutoValidMode="None"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="Environment@Default.aspx" Text="���O��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnCamera" runat="server"
                        AuthorizePath="CAMERA" AutoValidMode="None"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="Camera@Default.aspx" Text="�ʵ����t��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="UcAuthorizeButton2" runat="server"
                        AuthorizePath="WELF01" AutoValidMode="None"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="WELFARE@Default.aspx" Text="�֩e�|�t��" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnOtherOperator" runat="server"
                        AuthorizePath="Other01" AutoValidMode="VaildToEnableOrDisable"
                        CssClass="Button1" Font-Size="14pt"
                        OpenControlPath="OtherOperator@Default.aspx" Text="�䥦�@�~" />
                </td>
                <td>
                    <cc2:ucAuthorizeButton ID="ucbtnWebAppAuthority" runat="server"
                        AuthorizePath="Auth01" AutoValidMode="VaildToVisible" CssClass="Button1"
                        Font-Size="14pt" OpenControlPath="WebAppAuthority@Default.aspx" Text="�t���v���޲z" />
                </td>


            </tr>

        </table>
    </asp:Panel>

    <uc1:MessageDisplay ID="MessageDisplay1" runat="server" />
    <asp:HyperLink ID="HyperLink1" NavigateUrl="mailto:kuku@mail.tangeng.com.tw" runat="server">�t�κ޲z��:�j�F�� ����:1319</asp:HyperLink>
   <br /> �@�@�@�@�@ <asp:HyperLink ID="HyperLink2" NavigateUrl="mailto:renhsin@mail.tangeng.com.tw" runat="server">�����Y ����:1318</asp:HyperLink>

</asp:Content>
