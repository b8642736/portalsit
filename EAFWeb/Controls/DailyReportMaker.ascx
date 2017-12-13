<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DailyReportMaker.ascx.vb" Inherits="EAFWeb.DailyReportMaker" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style2
    {
        width: 363px;
    }
</style>
<p>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        列印期間:        
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">今天</asp:ListItem>
            <asp:ListItem Value="1">昨天</asp:ListItem>
            <asp:ListItem Value="2">自訂期間</asp:ListItem>
        </asp:RadioButtonList>

    </ContentTemplate>
</asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" 
    UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                            <table width="400px">
                                <tr>
                                    <td width="200" align="right">
                                        啟始時間:</td>
                                    <td class="style2">
                                        <asp:TextBox ID="txStartDate" runat="server" 
                        AutoPostBack="True"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="txStartDate" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <span lang="zh-tw">結束時間:</span></td>
                                    <td class="style2">
                                        <asp:TextBox ID="txEndDate" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                            TargetControlID="txEndDate" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                </tr>
                            </table>
                    </asp:Panel>
       </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnCreateReport" runat="server" Text="產生報表" />

        <br />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="400px" Width="100%">
    <LocalReport ReportPath="Controls\Daily.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="LDSEAFDataSrouce" 
                Name="UserControl_EAFT1ReportTemp" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:LinqDataSource ID="LDSEAFDataSrouce" runat="server" 
        ContextTypeName="CompanyLINQDB.EAFDataContext" TableName="EAFT1">
    </asp:LinqDataSource>
        
<asp:HiddenField ID="HFIsDStartSearchData" runat="server" Value="False" />
      
        </p>
