<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InvoiceDayMoneySumSearch.ascx.vb" Inherits="Financial.InvoiceDayMoneySumSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 69px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                TargetControlID="tbStartDate" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbSearch0" runat="server" Text="查詢轉換Excel" Width="100px" />
            <asp:HiddenField ID="hfSQLString" runat="server" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="500px">
    <Columns>
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="類別" HeaderText="類別" SortExpression="類別" />
        <asp:BoundField DataField="台幣金額" HeaderText="台幣金額" SortExpression="台幣金額" />
        <asp:BoundField DataField="美金轉台幣金類" HeaderText="美金轉台幣金類" 
            SortExpression="美金轉台幣金類" />
        <asp:BoundField DataField="金額合計" HeaderText="金額合計" SortExpression="金額合計" />
    </Columns>
    <RowStyle HorizontalAlign="Right" />
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Financial.InvoiceDayMoneySumSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


