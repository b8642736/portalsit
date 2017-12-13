<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BillSended.ascx.vb" Inherits="Business.BillSended" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">



    .style1
    {
        width: 84px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="TextBox1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="TextBox2">
            </cc1:CalendarExtender>
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
    Font-Size="8pt" Height="800px" Width="100%" Visible="False">
    <LocalReport ReportPath="Controls\BillSended\BillSendedReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="SLS300LB_BillSendedPrint" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.BillSended">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="Date1" PropertyName="Text" 
            Type="DateTime" />
        <asp:ControlParameter ControlID="TextBox2" Name="Date2" 
            PropertyName="Text" Type="DateTime" />
    </SelectParameters>
</asp:ObjectDataSource>

