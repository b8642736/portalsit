<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SampleStatusReport.ascx.vb" Inherits="SMPWork.SampleStatusReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 94px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            站別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">E1</asp:ListItem>
                <asp:ListItem Value="E2">E2</asp:ListItem>
                <asp:ListItem>A1</asp:ListItem>
                <asp:ListItem>L1</asp:ListItem>
                <asp:ListItem>C1</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate">
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
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
    Font-Names="Verdana" Font-Size="8pt" Height="400px" Visible="False">
    <LocalReport ReportPath="Controls\SampleStatusReport\SampleStatusReportDoc.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="ReportUseDataSet_SampleStatusDataTable" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="SMPWork.SampleStatusReport">
    <SelectParameters>
        <asp:ControlParameter ControlID="RadioButtonList2" Name="SearchStation" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="tbStartDate" Name="StartDate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="tbEndDate" Name="EndDate" 
            PropertyName="Text" Type="DateTime" />
    </SelectParameters>
</asp:ObjectDataSource>

