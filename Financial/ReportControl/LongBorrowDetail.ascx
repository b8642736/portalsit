<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LongBorrowDetail.ascx.vb" Inherits="Financial.LongBorrowDetail" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 80px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            借款種類:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                <asp:ListItem Value="1">長期借款</asp:ListItem>
                <asp:ListItem Value="2">長期循環</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="450px" Width="100%">
    <LocalReport ReportPath="ReportControl\LongBorrowDetailReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ldsSearchResult" 
                Name="Borrow" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="Borrow">
</asp:LinqDataSource>


