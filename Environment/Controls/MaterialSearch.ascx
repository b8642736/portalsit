<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MaterialSearch.ascx.vb" Inherits="Environment.MaterialSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1
    {
        width: 61px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">&nbsp;期間:&nbsp;</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbStartDate" Format="yyyy/MM/dd"></cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbEndDate" Format="yyyy/MM/dd"></cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult" Height="123px" Width="655px">
    <Columns>
        <asp:BoundField DataField="用途單位" HeaderText="用途單位" SortExpression="用途單位" />
        <asp:BoundField DataField="料號" HeaderText="料號" SortExpression="料號" />
        <asp:BoundField DataField="年月" HeaderText="年月" SortExpression="年月" />
        <asp:BoundField DataField="品名" HeaderText="品名" SortExpression="品名" />
        <asp:BoundField DataField="規範" HeaderText="規範" SortExpression="規範" />
        <asp:BoundField DataField="計量單位" HeaderText="計量單位" SortExpression="計量單位" />
        <asp:BoundField DataField="實收數量" HeaderText="實收數量" SortExpression="實收數量" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Environment.MaterialSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfQry" runat="server" />



