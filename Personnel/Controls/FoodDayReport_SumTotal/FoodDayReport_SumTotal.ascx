<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FoodDayReport_SumTotal.ascx.vb" Inherits="Personnel.FoodDayReport_SumTotal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 63%;
    }

    .auto-style2 {
        width: 186px;
        height :25px;
    }

    .auto-style3 {
        width: 273px;
        height :25px;
    }
    .auto-style4 {
        width: 186px;
    }
    .auto-style5 {
        width: 273px;
    }
</style>


<table class="auto-style1">
    <tr>
        <td class="auto-style2">日期：</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtQueryDate" runat="server" ></asp:TextBox>
            <cc1:CalendarExtender ID="txtQueryDate_CalendarExtender" runat="server" TargetControlID="txtQueryDate">
            </cc1:CalendarExtender>
        </td>
        <td rowspan="4">
            <asp:Button ID="btnExec" runat="server" Text="執行" Height="61px" Width="150px" />

        </td>
    </tr>
    <tr>
        <td class="auto-style2">餐別：</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddFoodKind" runat="server" Height="30px" Width="150px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">輸出格式：</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddReportKind" runat="server" Height="30px" Width="150px"/>
        </td>

    </tr>
    <tr>
        <td class="auto-style2">
            &nbsp;</td>
        <td class="auto-style3">
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="驗證輸入查詢條件"></asp:CustomValidator>
            <asp:HiddenField ID="hfQryString" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="PersonnelTableAdapters."></asp:ObjectDataSource>
        </td>

    </tr>

</table>

<br />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="12pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="500px">
    <LocalReport  ReportPath="bin\Controls\FoodDayReport_SumTotal\FoodDayReport_SumTotalReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>

</rsweb:ReportViewer>






