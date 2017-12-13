<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetExtendUseReport.ascx.vb" Inherits="AST500LB.AssetExtendUseReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 103px;
        text-align:right;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">重估年月</td>
        <td>
            <asp:TextBox ID="tbSearchYearMonth" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td  class="auto-style1">
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
    <%--<tr>
        <td class="auto-style1">報表類型:</td>
        <td>
            <asp:RadioButtonList ID="rblReportType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">總表</asp:ListItem>
                <asp:ListItem Value="2">100萬以下</asp:ListItem>
                <asp:ListItem Value="3">100萬(含)以上</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>--%>
    <tr>
        <td class="auto-style1">報表類型:</td>
        <td>
           <asp:RadioButtonList ID="rblReportType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">彙總表</asp:ListItem>
                <asp:ListItem Value="2">明細表</asp:ListItem>
            </asp:RadioButtonList>
        </td>

    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="產生報表" Width="100px" />
        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="406px">
    <LocalReport  ReportPath ="Controls\AssetExtendUseReport\AssetExtendUseReportV3.rdlc" ReportEmbeddedResource="AST500LB.AssetExtendUseReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server"  SelectMethod="Search" TypeName="AST500LB.AssetExtendUseReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry1" Name="QryString1" PropertyName="Value" Type="String" />
        <asp:Parameter DefaultValue="1" Name="ShowReportType" Type="String" />
        <asp:ControlParameter ControlID="RadioButtonList1" Name="ManagerDept" PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry1" runat="server" />


