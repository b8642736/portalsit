<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DBConnectSwitch.ascx.vb" Inherits="OtherOperator.DBConnectSwitch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<p>
    <span lang="zh-tw">網站資料庫伺服切換作業</span></p>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">目前使用資料庫伺服器IP:</span></td>
        <td>
            <asp:Label ID="lblNowUserServerIP" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">訊息:</span></td>
        <td>
            <asp:Label ID="lblChangeMessage" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
    Width="100%" Height="300px">
    <cc1:TabPanel runat="server" HeaderText="主要伺服器" ID="TabPanel1">
        <HeaderTemplate>
            主要伺服器
        </HeaderTemplate>
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td>
                        <span lang="zh-tw">伺服器IP:</span></td>
                    <td>
                        <asp:Label ID="lblDBServer0" runat="server" Text="10.1.4.16"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span lang="zh-tw">網路連線是否正常:</span></td>
                    <td>
                        <asp:Label ID="lblDBServer1Msg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span lang="zh-tw">切換資料庫伺服器:</span></td>
                    <td>
                        <asp:Button ID="btnChangeDBServer1" runat="server" Text="切換為主要伺服器" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="是否確定要切服為主要資料庫?伺服器" TargetControlID="btnChangeDBServer1" 
                            Enabled="True">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="備援伺服器1" ID="TabPanel2">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td>
                        <span lang="zh-tw">伺服器IP:</span></td>
                    <td>
                        <asp:Label ID="lblDBServer1" runat="server" Text="10.1.3.52"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span lang="zh-tw">網路連線是否正常:</span></td>
                    <td>
                        <asp:Label ID="lblDBServer2Msg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span lang="zh-tw">切換資料庫伺服器:</span></td>
                    <td>
                        <asp:Button ID="btnChangeDBServer2" runat="server" Text="切換為備援伺服器" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                            ConfirmText="是否確定要切服為備援資料庫伺服器" Enabled="True" 
                            TargetControlID="btnChangeDBServer2">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
