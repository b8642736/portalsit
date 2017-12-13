<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PackSearch.ascx.vb" Inherits="ColdRollingProcess.PackSearch" %>
<style type="text/css">
    .auto-style1 {
        width: 102px;
        text-align:right;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="日期:" Checked="true" TextAlign="Left"  /></td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="80px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">線別:</td>
        <td>
            <asp:TextBox ID="tbLines" runat="server" Width="175px"></asp:TextBox>
            (兩線以上請以 &#39;,&#39; 區分 EX: SPL,TLL)</td>
    </tr>
    <tr>
        <td class="auto-style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="175px"></asp:TextBox>
            (未分捲,兩線以上請以 &#39;,&#39; 區分 EX: K1234,K1235)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼捲編號" HeaderText="鋼捲編號" SortExpression="鋼捲編號" />
        <asp:BoundField DataField="線別" HeaderText="線別" SortExpression="線別" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
        <asp:BoundField DataField="襯紙夾整捲" HeaderText="襯紙夾整捲" SortExpression="襯紙夾整捲" />
        <asp:BoundField DataField="襯紙厚薄" HeaderText="襯紙厚薄" SortExpression="襯紙厚薄" />
        <asp:BoundField DataField="襯紙寬" HeaderText="襯紙寬" SortExpression="襯紙寬" />
        <asp:BoundField DataField="襯紙定長" HeaderText="襯紙定長" SortExpression="襯紙定長" />
        <asp:BoundField DataField="襯紙基重" HeaderText="襯紙基重" SortExpression="襯紙基重" />
        <asp:BoundField DataField="是否套筒" HeaderText="是否套筒" SortExpression="是否套筒" />
        <asp:BoundField DataField="套筒外徑" HeaderText="套筒外徑" SortExpression="套筒外徑" />
        <asp:BoundField DataField="套筒內徑" HeaderText="套筒內徑" SortExpression="套筒內徑" />
        <asp:BoundField DataField="套筒重" HeaderText="套筒重" SortExpression="套筒重" />
        <asp:BoundField DataField="奇力龍整捲" HeaderText="奇力龍整捲" SortExpression="奇力龍整捲" />
        <asp:BoundField DataField="奇力龍寬" HeaderText="奇力龍寬" SortExpression="奇力龍寬" />
        <asp:BoundField DataField="奇力龍長" HeaderText="奇力龍長" SortExpression="奇力龍長" />
        <asp:BoundField DataField="奇力龍基重" HeaderText="奇力龍基重" SortExpression="奇力龍基重" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="ColdRollingProcess.PackSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


