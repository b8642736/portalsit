<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EquipmentCheckPrint.ascx.vb" Inherits="SMPWork.EquipmentCheckPrint" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 211px;
    }
    .style3
    {
        width: 103px;
    }
    .style5
    {
        width: 105px;
    }
    .style6
    {
        width: 172px;
    }
</style>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%" AutoPostBack="True">
    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
    <HeaderTemplate>查詢印表</HeaderTemplate>
        <ContentTemplate>
        <style type="text/css">
            .style1
            {
                width: 108px;
            }
        </style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    資料日期:</td>
                <td>
                    <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:LinkButton ID="lbSearchMode" runat="server" Font-Overline="False" 
                        Font-Underline="False" ForeColor="Black">查詢=&gt;</asp:LinkButton>
                </td>
                <td>
                    <asp:Button ID="tbSearchPrint" runat="server" Text="查詢印表" Width="100px" />
                    <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
                        TypeName="SMPWork.EquipmentCheckPrint">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbStartDate" Name="StartDate" 
                                PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="hfIsShowRealDataMode" Name="IsRealDataMode" 
                                PropertyName="Value" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:HiddenField ID="hfIsShowRealDataMode" runat="server" />
                </td>
            </tr>
        </table>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" Height="580px" Width="100%" ZoomPercent="70" 
                InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
                WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="Controls\儀器檢測查詢編修\EquipmentCheckReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                            Name="ReportUseDataSet_EquipmentCheckDataTable" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
    <HeaderTemplate>印表參數設定</HeaderTemplate>
    <ContentTemplate>
        <br />
        表頭參數設定:<br />
        <table style="width:100%;">
            <tr>
                <td class="style6">
                    </td>
                <td class="style3">
                    廠型</td>
                <td class="style5">
                    編號</td>
                <td class="style3">
                    室編號</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">Metalys #1表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr1_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr1_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr1_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">Metalys #2表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr2_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr2_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr2_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">N/O表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr3_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr3_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr3_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">C/S表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr4_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr4_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr4_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">XRF表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr5_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr5_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr5_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">JY-56E表頭參數設定
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr6_1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="tbr6_2" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbr6_3" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="tbReadSet" runat="server" Text="重新載設定" />
        <asp:Button ID="tbSaveSet" runat="server" Text="設定儲存" Enabled="False" />
        <cc1:ConfirmButtonExtender runat="server" ConfirmText="是否確定存儲設定?" 
            TargetControlID="tbSaveSet" ID="ctl001" Enabled="True">
        </cc1:ConfirmButtonExtender>
    </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>




