<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetChangeReport.ascx.vb" Inherits="AST500LB.AssetChangeReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">廠別:</span></td>
        <td colspan="2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>

<asp:Button ID="btnSearch" runat="server" Text="查詢產生報表" Width="100px" />

        </td>
    </tr>
</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="567px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport  ReportPath="Controls\AssetChangeReport\AssetChangeReportV2.rdlc" >
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="AST500LB.AssetChangeReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry1" Name="QryString1" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQry2" Name="QryString2" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry1" runat="server" />
<asp:HiddenField ID="hfQry2" runat="server" />

