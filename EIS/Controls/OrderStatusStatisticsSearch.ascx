<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderStatusStatisticsSearch.ascx.vb" Inherits="EIS.OrderStatusStatisticsSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        height: 30px;
    }
</style>

<script lang="javascript">

    var GridViewObjName = '';


    function onCalendarShownStart() {
        GridViewObjName = 'calendarStart';
        onCalendarShown();
    }

    function onCalendarHiddenStart() {
        GridViewObjName = 'calendarStart';
        onCalendarHidden();
    }

    function onCalendarShownEnd() {
        GridViewObjName = 'calendarEnd';
        onCalendarShown();
    }

    function onCalendarHiddenEnd() {
        GridViewObjName = 'calendarEnd';
        onCalendarHidden();
    }

    function onCalendarShownOrder() {
        GridViewObjName = 'calendarOrder';
        onCalendarShown();
    }

    function onCalendarHiddenOrder() {
        GridViewObjName = 'calendarOrder';
        onCalendarHidden();
    }

    function onCalendarShown() {
        var cal = $find(GridViewObjName);
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
        var cal = $find(GridViewObjName);

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
                var cal = $find(GridViewObjName);

                cal._visibleDate = target.date;
                cal.set_selectedDate(target.date);
                cal._switchMonth(target.date);
                cal._blur.post(true);
                cal.raiseDateSelectionChanged();
                break;
        }
    }


    </script>



<p />

<table class="auto-style1">
    <tr>
        <td class="auto-style2">未交量/落後量 起訖月份</td>
        <td class="auto-style2">

            <asp:TextBox ID="tbStartMonth" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartMonth_CalendarExtender" runat="server"
                OnClientHidden="onCalendarHiddenStart"  OnClientShown="onCalendarShownStart" BehaviorID="calendarStart"
                TargetControlID="tbStartMonth" Format="yyyy/MM">
            </cc1:CalendarExtender>
            ~
            <asp:TextBox ID="tbEndMonth" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndMonth_CalendarExtender" runat="server"
                OnClientHidden="onCalendarHiddenEnd"  OnClientShown="onCalendarShownEnd" BehaviorID="calendarEnd"
                TargetControlID="tbEndMonth" Format="yyyy/MM">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">訂單量 月份</td>
        <td class="auto-style2">
            <asp:TextBox ID="tbOrderMonth" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbOrderMonth_CalendarExtender" runat="server"
               OnClientHidden="onCalendarHiddenOrder"  OnClientShown="onCalendarShownOrder" BehaviorID="calendarOrder"
                TargetControlID="tbOrderMonth" Format="yyyy/MM">
            </cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style2">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel"
                Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style2">
            <asp:HiddenField ID="hfSQL1Other" runat="server" />
            <asp:HiddenField ID="hfSQL2Order" runat="server" />
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="EIS.OrderStatusStatisticsSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL1Other" Name="fromSQL1Other" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL2Order" Name="fromSQL2Order" PropertyName="Value" Type="String" />                 
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="項目" HeaderText="項目" SortExpression="項目" HtmlEncode="false" ItemStyle-Width ="8%" />
        <asp:BoundField DataField="類別" HeaderText="　" SortExpression="類別" HtmlEncode="false" ItemStyle-Width ="8%" />
        <asp:BoundField DataField="304" HeaderText="304" SortExpression="304" HtmlEncode="false" ItemStyle-Width ="8%" />
        <asp:BoundField DataField="202" HeaderText="202" SortExpression="202" HtmlEncode="false"  ItemStyle-Width ="8%" />
        <asp:BoundField DataField="201" HeaderText="201" SortExpression="201" HtmlEncode="false"  ItemStyle-Width ="8%" />
        <asp:BoundField DataField="301" HeaderText="301" SortExpression="301" HtmlEncode="false"  ItemStyle-Width ="8%" />
        <asp:BoundField DataField="其他" HeaderText="其他" SortExpression="其他" HtmlEncode="false" ItemStyle-Width ="8%"  />
        <asp:BoundField DataField="合計" HeaderText="合計" SortExpression="合計" HtmlEncode="false"  ItemStyle-Width ="8%" />
        <asp:BoundField DataField="備註" HeaderText="備註" SortExpression="備註" HtmlEncode="false" />
    </Columns>
</asp:GridView>

