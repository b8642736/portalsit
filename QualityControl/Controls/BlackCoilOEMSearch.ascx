<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlackCoilOEMSearch.ascx.vb" Inherits="QualityControl.BlackCoilOEMSearch" %>
<style type="text/css">

    .style1
    {
        width: 101px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            熱軋批號:</td>
        <td>
            <asp:TextBox ID="tbBatchNumber" runat="server"></asp:TextBox>
                    (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            熱軋號碼:</td>
        <td>
            <asp:TextBox ID="tbCSCNumber" runat="server" Width="224px"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="125px"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
    </tr>
    <tr>
        <td class="style1">
            鋼胚編號:</td>
        <td>
            <asp:TextBox ID="tbSlabNumber" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
    </tr>
    <tr>
        <td class="style1">
            鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumber" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
    </tr>
    <tr>
        <td class="style1">煉鋼異常代碼:</td>
        <td>
            <asp:TextBox ID="tbErrCode" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
    </tr>
    <tr>
        <td class="style1">輸出格式</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="TYPE0">格式一</asp:ListItem>
                <asp:ListItem Value="TYPE1">格式二</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbSearch0" runat="server" Text="查詢下載Excel" Width="100px" />
            <asp:HiddenField ID="hfControlSQLMaker" runat="server" />
            <asp:HiddenField ID="hfErrCodes" runat="server" />
            <asp:HiddenField ID="hfControlSQLMaker1" runat="server" />
            </td>
    </tr>

</table>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" DataSourceID="odsSearchResult" 
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="鋼胚編號" HeaderText="鋼胚編號" SortExpression="鋼胚編號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
                <asp:BoundField DataField="派工單號碼" HeaderText="派工單號碼" SortExpression="派工單號碼" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
                <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                <asp:BoundField DataField="煉鋼異常代碼" HeaderText="煉鋼異常代碼" 
                    SortExpression="煉鋼異常代碼" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="QualityControl.BlackCoilOEMSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfControlSQLMaker" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfErrCodes" Name="FilterErrorCodes" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" DataSourceID="odsSearchResult1" 
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="鋼胚編號" HeaderText="鋼胚編號" SortExpression="鋼胚編號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
                <asp:BoundField DataField="派工單號碼" HeaderText="派工單號碼" SortExpression="派工單號碼" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
                <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                <asp:BoundField DataField="起始線別1" HeaderText="起始線別1" SortExpression="起始線別1" />
                <asp:BoundField DataField="完成日期" HeaderText="完成日期" SortExpression="完成日期" />
                <asp:BoundField DataField="代工重捲" HeaderText="代工重捲" SortExpression="代工重捲" />
                <asp:BoundField DataField="起始線別2" HeaderText="起始線別2" SortExpression="起始線別2" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
            SelectMethod="Search1" TypeName="QualityControl.BlackCoilOEMSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfControlSQLMaker1" Name="SQLString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>




