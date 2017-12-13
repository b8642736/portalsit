<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductCashStatistics.ascx.vb" Inherits="Accounting.ProductCashStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 181px;
    }
   
    .auto-style3 {
        width: 181px;
        height: 20px;
    }
    .auto-style4 {
        height: 20px;
    }
   
</style>

<table class="auto-style1">

    <tr>
        <td class="auto-style3"></td>
        <td class="auto-style4"></td>
    </tr>

    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="起始年月(報價單日期)"></asp:Label>
        </td>
        <td >
            <asp:TextBox ID="tbOrderStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                 OnClientHidden="onCalendarHidden"  OnClientShown="onCalendarShown" BehaviorID="calendar1"
                Format="yyyy/MM" TargetControlID="tbOrderStartDate">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="提貨單截止日期"></asp:Label>
        </td>
        <td >
            <asp:TextBox ID="tbTakeEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbTakeEndDate_CalendarExtender" runat="server" TargetControlID="tbTakeEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">
            統計至『表面』</td>
        <td >
            <asp:RadioButtonList ID="rdListBol06" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y">是</asp:ListItem>
                <asp:ListItem Value="N" Selected ="True" >否</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">鋼種:
        </td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201,301)
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            扣除金額</td>
        <td >
            <asp:Label ID="Label2" runat="server" Text="外銷"></asp:Label>
            <asp:TextBox ID="tbMoneyX" runat="server">1500</asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="內銷 "></asp:Label>
            <asp:TextBox ID="tbMoney" runat="server">3800</asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">
            &nbsp;</td>
        <td >
            &nbsp;</td>
    </tr>

    <tr>
        <td class="auto-style2"></td>
        <td >
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>       </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="Accounting.ProductCashStatistics">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLF3" Name="fromSQLF3" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfSQLF4" Name="fromSQLF4" PropertyName="Value"
            Type="String" />
        <asp:ControlParameter ControlID="hfSQLF5" Name="fromSQLF5" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfSQLF4" runat="server" />
<asp:HiddenField ID="hfSQLF3" runat="server" />
<asp:HiddenField ID="hfSQLF5" runat ="server" />
<asp:HiddenField ID="hfSearchDateRange" runat="server" />


 <script language="javascript">
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