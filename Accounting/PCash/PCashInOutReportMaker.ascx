<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PCashInOutReportMaker.ascx.vb" Inherits="Accounting.PCashInOutReportMaker" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<table style="width:100%;">
    <tr>
        <td>
            年度:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            單位:</td>
        <td>

            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LDSPCCash4" 
                DataTextField="DepName" DataValueField="DepCode" Width="120px">
            </asp:DropDownList>
            <asp:LinqDataSource ID="LDSPCCash4" runat="server" 
                ContextTypeName="CompanyLINQDB.PCashDataContext" OrderBy="DepCode" 
                TableName="PCash4">
            </asp:LinqDataSource>

        </td>
    </tr>
   <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="400px" Width="100%" Visible="False">
    <LocalReport ReportPath="PCash\PCashInOutReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="LDSSearchResult" Name="PCash1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:LinqDataSource ID="LDSSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.PCashDataContext" TableName="PCash1">
</asp:LinqDataSource>

