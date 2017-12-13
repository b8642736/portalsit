<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DepreciationSumByDeptReport.ascx.vb" Inherits="AST500LB.DepreciationSumByDeptReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 87px;
        text-align: right;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">查詢:</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportPath="Controls\DepreciationSumByDeptReport\DepreciationSumByDept.rdlc" >
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="AST500LB.DepreciationSumByDeptReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString1" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />


