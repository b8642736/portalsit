<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SteelKindFaceOutRateAnalysis.ascx.vb" Inherits="QualityControl.SteelKindFaceOutRateAnalysis" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 75px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            民國<asp:TextBox ID="tbStartYear" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            月~民國<asp:TextBox ID="tbEndYear" runat="server" Width="40px"></asp:TextBox>
            年<asp:TextBox ID="tbEndMonth" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="628px" InteractiveDeviceInfos="(集合)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportPath="Controls\SteelKindFaceOutRateAnalysis\SteelKindFaceOutRateAnalysisReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ODSSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="ODSSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.SteelKindFaceOutRateAnalysis">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


