<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RadiationReportMaker.ascx.vb" Inherits="SMPWork.RadiationReportMaker" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        height: 23px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>
            爐號生產期間:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>~<asp:TextBox ID="TextBox2"
                runat="server"></asp:TextBox>
            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="Textbox1" >
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="Textbox2" >
            </cc1:CalendarExtender>--%>
        </td>
    </tr>
    <tr>
    <td />
        &nbsp;<td />
            &nbsp;</tr>
    <tr>
        <td class="style1">
        </td>
        <td class="style1">
            <asp:Button ID="btnReportMaker" runat="server" Text="產生報表" Width="119px" />
        </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Width="100%" InteractiveDeviceInfos="(集合)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px">
    <LocalReport ReportPath="Controls\RadiationReport\RadiationReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="ReportUseDataSet_AB爐分析資料" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>






<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="SMPWork.RadiationReportMaker">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="StartDate" PropertyName="Text" 
            Type="DateTime" />
        <asp:ControlParameter ControlID="TextBox2" Name="EndDate" PropertyName="Text" 
            Type="DateTime" />
    </SelectParameters>
</asp:ObjectDataSource>







