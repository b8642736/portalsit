<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MaterialStatusSearch.ascx.vb" Inherits="EIS.MaterialStatusSearch" %>
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
        <td class="auto-style2">黑皮進場截止日</td>
        <td class="auto-style2">
            <asp:TextBox ID="tb黑皮進場截止日" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tb黑皮進場截止日_CalendarExtender" runat="server" TargetControlID="tb黑皮進場截止日" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">在製品截止日</td>
        <td class="auto-style2">
            <asp:TextBox ID="tb在製品截止日" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tb在製品截止日_CalendarExtender" runat="server" TargetControlID="tb在製品截止日" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">鋼胚生產截止日</td>
        <td class="auto-style2">                       
            <asp:TextBox ID="tb鋼胚生產截止日" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tb鋼胚生產截止日" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>


    <tr>
        <td class="auto-style2">承訂落後量起訖年月</td>
        <td class="auto-style2">

            <asp:TextBox ID="tb承訂落後量StartMonth" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartMonth_CalendarExtender" runat="server"
                OnClientHidden="onCalendarHiddenStart" OnClientShown="onCalendarShownStart" BehaviorID="calendarStart"
                TargetControlID="tb承訂落後量StartMonth" Format="yyyy/MM">
            </cc1:CalendarExtender>
            ~
            <asp:TextBox ID="tb承訂落後量EndMonth" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndMonth_CalendarExtender" runat="server"
                OnClientHidden="onCalendarHiddenEnd" OnClientShown="onCalendarShownEnd" BehaviorID="calendarEnd"
                TargetControlID="tb承訂落後量EndMonth" Format="yyyy/MM">
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
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="EIS.MaterialStatusSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL00_LOT對照檔" Name="fromSQL00_LOT對照檔" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL01_成品繳庫" Name="fromSQL01_成品繳庫" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL02_在製品_03場內黑皮" Name="fromSQL02_在製品_03場內黑皮" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL02_在製品_03場內黑皮_LOT" Name="fromSQL02_在製品_03場內黑皮_LOT" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL02_在製品_05外送代軋鋼胚A" Name="fromSQL02_在製品_05外送代軋鋼胚A" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL04_場內鋼胚" Name="fromSQL04_場內鋼胚" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL05_外送代軋鋼胚B" Name="fromSQL05_外送代軋鋼胚B" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL06_承訂落後量" Name="fromSQL06_承訂落後量" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:HiddenField ID="hfSQL00_LOT對照檔" runat="server" />
            <asp:HiddenField ID="hfSQL01_成品繳庫" runat="server" />
            <asp:HiddenField ID="hfSQL02_在製品_03場內黑皮" runat="server" />
            <asp:HiddenField ID="hfSQL02_在製品_03場內黑皮_LOT" runat="server" />
            <asp:HiddenField ID="hfSQL02_在製品_05外送代軋鋼胚A" runat="server" />
            <asp:HiddenField ID="hfSQL04_場內鋼胚" runat="server" />
            <asp:HiddenField ID="hfSQL05_外送代軋鋼胚B" runat="server" />
            <asp:HiddenField ID="hfSQL06_承訂落後量" runat="server" />
        </td>
    </tr>
</table>
<p>
    &nbsp;
</p>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="COL1" HeaderText="項目" SortExpression="COL1" HtmlEncode="false" />
        <asp:BoundField DataField="COL2" HeaderText="" SortExpression="COL2" HtmlEncode="false" />
        <asp:BoundField DataField="304" HeaderText="304" SortExpression="304" HtmlEncode="false" />
        <asp:BoundField DataField="202" HeaderText="202" SortExpression="202" HtmlEncode="false" />
        <asp:BoundField DataField="201" HeaderText="201" SortExpression="201" HtmlEncode="false" />
        <asp:BoundField DataField="301" HeaderText="301" SortExpression="301" HtmlEncode="false" />
        <asp:BoundField DataField="其他" HeaderText="其他" SortExpression="其他" HtmlEncode="false" />
        <asp:BoundField DataField="合計" HeaderText="合計" SortExpression="合計" HtmlEncode="false" />
        <asp:BoundField DataField="成品當量" HeaderText="成品當量(公噸)" SortExpression="成品當量" HtmlEncode="false" />
    </Columns>
</asp:GridView>

