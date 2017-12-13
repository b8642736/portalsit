<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SteelPlantSendInOutSearch.ascx.vb" Inherits="StockStatic.SteelPlantSendInOutSearch" %>
<style type="text/css">
    .style1
    {
        width: 42px;
    }
</style>
<br /><br />
<table style="width: 100%;">
    <tr>
        <td class="style1">批號:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
            (兩種以上請以&#39;,&#39;區分 EX:304,201)</td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchReset" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="轉換Excel下載"
                Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:ObjectDataSource ID="ODSSearchResult" runat="server" SelectMethod="Search"
                TypeName="StockStatic.SteelPlantSendInOutSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQry" Name="SQLString"
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfQry" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" HtmlEncode="false" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" HtmlEncode="false" />
        <asp:BoundField DataField="送至中鋼數量" HeaderText="送至中鋼數量" SortExpression="送至中鋼數量" HtmlEncode="false" />
        <asp:BoundField DataField="送至中鋼重量" HeaderText="送至中鋼重量" SortExpression="送至中鋼重量" HtmlEncode="false" />
        <asp:BoundField DataField="回廠日期" HeaderText="回廠日期" SortExpression="回廠日期" HtmlEncode="false" />
        <asp:BoundField DataField="未壓數量" HeaderText="未壓數量" SortExpression="未壓數量" HtmlEncode="false" />
        <asp:BoundField DataField="未壓重量" HeaderText="未壓重量" SortExpression="未壓重量" HtmlEncode="false" />
        <asp:BoundField DataField="正常品數量" HeaderText="正常品數量" SortExpression="正常品數量" HtmlEncode="false" />
        <asp:BoundField DataField="正常品重量" HeaderText="正常品重量" SortExpression="正常品重量" HtmlEncode="false" />
        <asp:BoundField DataField="中鋼會判數量" HeaderText="中鋼會判數量" SortExpression="中鋼會判數量" HtmlEncode="false" />
        <asp:BoundField DataField="中鋼會判重量" HeaderText="中鋼會判重量" SortExpression="中鋼會判重量" HtmlEncode="false" />
        <asp:BoundField DataField="捲型不良數量" HeaderText="捲型不良數量" SortExpression="捲型不良數量" HtmlEncode="false" />
        <asp:BoundField DataField="捲型不良重量" HeaderText="捲型不良重量" SortExpression="捲型不良重量" HtmlEncode="false" />
        <asp:BoundField DataField="中鋼壓壞數量" HeaderText="中鋼壓壞數量" SortExpression="中鋼壓壞數量" HtmlEncode="false" />
        <asp:BoundField DataField="中鋼壓壞重量" HeaderText="中鋼壓壞重量" SortExpression="中鋼壓壞重量" HtmlEncode="false" />
    </Columns>
</asp:GridView>
