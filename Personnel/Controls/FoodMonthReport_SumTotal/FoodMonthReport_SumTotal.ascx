<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FoodMonthReport_SumTotal.ascx.vb" Inherits="Personnel.FoodMonthReport_SumTotal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 63%;
    }

    .auto-style2 {
        width: 186px;
        height: 25px;
    }

    .auto-style3 {
        width: 273px;
        height: 25px;
    }
</style>

<script lang="javascript">
    function onCalendarShown() {

        var cal = $find("calendar1");
        //Setting the default mode to month
        cal._switchMode("months", true);

        //Iterate every month Item and attach click event to it
        if (cal._monthsBody) {
            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                var row = cal._monthsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }
    }

    function onCalendarHidden() {
        var cal = $find("calendar1");
        //Iterate every month Item and remove click event from it
        if (cal._monthsBody) {
            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                var row = cal._monthsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }

    }

    function call(eventElement) {
        var target = eventElement.target;
        switch (target.mode) {
            case "month":
                var cal = $find("calendar1");
                cal._visibleDate = target.date;
                cal.set_selectedDate(target.date);
                cal._switchMonth(target.date);
                cal._blur.post(true);
                cal.raiseDateSelectionChanged();
                break;
        }
    }


</script>


<table class="auto-style1">
    <tr>
        <td class="auto-style2">年月：</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtQueryDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtQueryDate_CalendarExtender" runat="server" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" BehaviorID="calendar1"
                Enabled="True" TargetControlID="txtQueryDate" Format="yyyy/MM">
            </cc1:CalendarExtender>

        </td>
        <td rowspan="4">
            <asp:Button ID="btnExec" runat="server" Text="執行" Height="61px" Width="150px" />

        </td>
    </tr>

    <tr>
        <td class="auto-style2">輸出格式：</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddReportKind" runat="server" Height="30px" Width="150px" />
        </td>

    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="驗證輸入查詢條件"></asp:CustomValidator>
            <asp:HiddenField ID="hfQryString" runat="server" />
            <asp:HiddenField ID="hfEEEMM_Last" runat="server" />
            <asp:HiddenField ID="hfEEEMM_Now" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="PersonnelTableAdapters."></asp:ObjectDataSource>
        </td>

    </tr>

</table>

<br />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="12pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="500px">
    <LocalReport ReportPath="bin\Controls\FoodMonthReport_SumTotal\FoodMonthReport_SumTotalReport.rdlc" ReportEmbeddedResource="Personnel.FoodMonthReport_SumTotalReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>

</rsweb:ReportViewer>