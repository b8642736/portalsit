<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderRealBuyAnalysis.ascx.vb" Inherits="Business.OrderRealBuyAnalysis" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 95px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            期間(年月):</td>
        <td>
            <asp:TextBox ID="tbStartYear" runat="server" Width="37px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth" runat="server" Width="37px"></asp:TextBox>
            月~<asp:TextBox ID="tbEndYear" runat="server" Width="37px"></asp:TextBox>
            年<asp:TextBox ID="tbEndMonth" runat="server" Width="37px"></asp:TextBox>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
            <asp:HiddenField ID="hfQry" runat="server" />
        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
    Width="100%" Font-Names="Verdana" Font-Size="8pt" 
    InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\OrderRealBuyAnalysis\OrderRealBuyAnalysisReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="OrderRealBuyAnalysisData" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>


<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.OrderRealBuyAnalysis">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLQry" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>



