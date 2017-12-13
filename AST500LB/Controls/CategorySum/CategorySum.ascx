<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CategorySum.ascx.vb" Inherits="AST500LB.CategorySum" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 91px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            事業單位:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="SA">SA不銹鋼</asp:ListItem>
                <asp:ListItem Selected="True" Value="AA">AA總公司</asp:ListItem>
                <asp:ListItem Selected="True" Value="AB">AB總公司(新豐)</asp:ListItem>
                <asp:ListItem Selected="True" Value="NA">NA台北辦事處</asp:ListItem>
                <asp:ListItem Selected="True" Value="QA">QA營建部</asp:ListItem>
                <asp:ListItem Selected="True" Value="RA">RA機械廠</asp:ListItem>
                <asp:ListItem Selected="True" Value="RC">RC公路車輛</asp:ListItem>
                <asp:ListItem Selected="True" Value="RD">RD鋼構組</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="523px" InteractiveDeviceInfos="(集合)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportPath="Controls\CategorySum\CategorySumReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="AST500LB.CategorySum">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLQry" Name="SQLQry" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLQry" runat="server" />


