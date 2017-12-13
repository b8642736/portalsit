<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ScrapValueReport.ascx.vb" Inherits="AST500LB.ScrapValueReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<style type="text/css">
    .style1
    {
        width: 79px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢重整報表" />
        </td>
    </tr>

</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="614px" InteractiveDeviceInfos="(集合)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportPath="Controls\MonthWroks\ScrapValueReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>

<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="AST500LB.AddDeleteReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQuery" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQuery" runat="server" />