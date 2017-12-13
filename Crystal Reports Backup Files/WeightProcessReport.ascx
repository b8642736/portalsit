<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WeightProcessReport.ascx.vb" Inherits="Business.WeightProcessReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 75px;
    }
    .style2
    {
        width: 75px;
        height: 19px;
    }
    .style3
    {
        height: 19px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            日期:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="TextBox1">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style2">
            序號:</td>
        <td class="style3">
            <asp:TextBox ID="TextBox2" runat="server" Width="50px">1</asp:TextBox>
            ~<asp:TextBox ID="TextBox3" runat="server" Width="50px">200</asp:TextBox>
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
    Font-Size="8pt" Height="400px" Width="100%" Visible="False">
    <LocalReport ReportPath="Controls\WeightProcessReport\WeightProcessReportDoc.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="WeightProcessDataSet_WeightProcessDataTable" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.WeightProcessReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="FindDate" PropertyName="Text" 
            Type="DateTime" />
        <asp:ControlParameter ControlID="TextBox2" Name="StartNumber" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="TextBox3" Name="EndNumber" PropertyName="Text" 
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

