<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCClearAndArgReport.ascx.vb" Inherits="StockStatic.CCClearAndArgReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<style type="text/css">
    .style1
    {
        width: 102px;
    }
    </style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1"  Text="澆鑄日期" runat="server" Checked="True" 
                TextAlign="Left" />
            :</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>        </td>
    </tr>
    <tr>
        <td class="style1">
            爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server" Width="250px"></asp:TextBox>
            (兩爐以上請以&#39;,&#39;區隔或以&#39;~&#39;表示範圍 ex:A0001,A5000~A6000,B0200~B0300)</td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="200px"></asp:TextBox>
            (兩種以上請以&#39;,&#39;區隔表示 ex:201,304)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" 
                CausesValidation="False" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px"  CausesValidation="False" />
        </td>
    </tr>
</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportPath="Control\CCClearAndArgReport\CCClearAndArgReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>

<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="StockStatic.CCClearAndArgReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />



