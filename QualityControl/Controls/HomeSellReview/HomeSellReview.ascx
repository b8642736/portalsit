<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HomeSellReview.ascx.vb" Inherits="QualityControl.HomeSellReview" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 111px;
    }
    .style2
    {
        width: 254px;
    }
    .style3
    {
        width: 153px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="會計時段1" 
                TextAlign="Left" />
        </td>
        <td class="style2">
            <asp:TextBox ID="tbStartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate1_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate1">
            </cc1:CalendarExtender>
        </td>
        <td class="style3">
            <asp:CheckBox ID="CheckBox3" runat="server" Text="會計時段3" TextAlign="Left" />
        </td>
         <td>
            <asp:TextBox ID="tbStartDate3" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate3">
            </cc1:CalendarExtender>
             ~<asp:TextBox ID="tbEndDate3" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate3">
            </cc1:CalendarExtender>
        </td>
   </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox2" runat="server" Text="會計時段2" TextAlign="Left" />
        </td>
        <td class="style2">
            <asp:TextBox ID="tbStartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate2">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate2">
            </cc1:CalendarExtender>
        <td class="style3">
            <asp:CheckBox ID="CheckBox4" runat="server" Text="會計時段4" TextAlign="Left" />
        </td>
         <td>
            <asp:TextBox ID="tbStartDate4" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate4">
            </cc1:CalendarExtender>
             ~<asp:TextBox ID="tbEndDate4" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate4">
            </cc1:CalendarExtender>
        </td>
        </td>
    </tr>
    <tr>
        <td class="style1">
            內外銷</td>
        <td class="style2" colspan="3">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem>內銷</asp:ListItem>
                <asp:ListItem>外銷</asp:ListItem>
            </asp:RadioButtonList>
    </tr>
    <tr>
        <td class="style1">目標合格率==&gt;</td>
        <td>大於等於<asp:TextBox ID="tbTargetRate"  runat="server" Width="31px" 
                style="text-align: right">91</asp:TextBox> %</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2" colspan="3">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<p>
    <br />
</p>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(集合)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\HomeSellReview\HomeSellReviewReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>


<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.HomeSellReview">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfDateArgs" Name="DateArgs" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />
<asp:HiddenField ID="hfDateArgs" runat="server" />



