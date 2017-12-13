<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetDetailReport.ascx.vb" Inherits="AST500LB.AssetDetailReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 85px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <span lang="zh-tw">廠別:</span></td>
        <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Selected="True">SA</asp:ListItem>
                        <asp:ListItem>AA</asp:ListItem>
                        <asp:ListItem>AB</asp:ListItem>
                        <asp:ListItem>QA</asp:ListItem>
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>RA</asp:ListItem>
                        <asp:ListItem>RC</asp:ListItem>
                        <asp:ListItem>RD</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>

<asp:Button ID="btnSearch" runat="server" Text="查詢產生報表" Width="100px" />

        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="470px" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\AssetDetailReport\AssetDetailReportV2.rdlc"  >
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
            <rsweb:ReportDataSource DataSourceId="odsSearchResultTotal" Name="DataSet2" />
        </DataSources>
    </LocalReport>

</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="AST500LB.AssetDetailReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry1" Name="QryString1" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQry2" Name="QryString2" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsSearchResultTotal" runat="server" SelectMethod="SearchTotal" TypeName="AST500LB.AssetDetailReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry1" Name="QryString1" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQry2" Name="QryString2" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry1" runat="server" />
<asp:HiddenField ID="hfQry2" runat="server" />


