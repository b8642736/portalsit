<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SL2S01Search.ascx.vb" Inherits="EIS.SL2S01Search" %>
<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 304px;
    }

    .auto-style3
    {
        height: 30px;
    }
</style>

<p />
<table class="auto-style1">
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="報價單號碼"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:TextBox ID="TxtOrderNo" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">資料顯示</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddShowType" runat="server">
                <asp:ListItem Value="1">厚度清單</asp:ListItem>
                <asp:ListItem Value="2">鋼捲明細</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px"  />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel"
                Width="100px" />
        </td>
    </tr>
</table>

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">

        <asp:HiddenField ID="hfOrderNoNo1" runat="server" />
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search1" TypeName="EIS.SL2S01Search">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfOrderNoNo1" Name="fromOrderNo" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult">
            <Columns>
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="CODE3" HeaderText="CODE3" SortExpression="CODE3" />
                <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
                <asp:BoundField DataField="毛_修邊" HeaderText="毛/修邊" SortExpression="毛_修邊" />
                <asp:BoundField DataField="長度" HeaderText="長度" SortExpression="長度" />
                <asp:BoundField DataField="C_S" HeaderText="C/S" SortExpression="C_S" />
                <asp:BoundField DataField="訂單量" HeaderText="訂單量" SortExpression="訂單量" />
                <asp:BoundField DataField="發貨量" HeaderText="發貨量" SortExpression="發貨量" />
                <asp:BoundField DataField="待發貨" HeaderText="待發貨" SortExpression="待發貨" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="未交量" HeaderText="未交量" SortExpression="未交量" />
                <asp:BoundField DataField="內徑" HeaderText="內徑" SortExpression="內徑" />
            </Columns>
        </asp:GridView>
    </asp:View>



    <asp:View ID="View2" runat="server">
        <asp:HiddenField ID="hfOrderNoNo2" runat="server" />
        <asp:ObjectDataSource ID="odsSearchAllResult" runat="server" SelectMethod="Search2" TypeName="EIS.SL2S01Search">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfOrderNoNo2" Name="fromOrderNo" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchAllResult" Width="100%">
            <Columns>
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" HtmlEncode ="false"  />
                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" HtmlEncode ="false"  />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" HtmlEncode ="false"  />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" HtmlEncode ="false"  />
                <asp:BoundField DataField="CODE3" HeaderText="CODE3" SortExpression="CODE3" HtmlEncode ="false"  />
                <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" HtmlEncode ="false"  />
                <asp:BoundField DataField="毛_修邊" HeaderText="毛/修邊" SortExpression="毛_修邊" HtmlEncode ="false"  />
                <asp:BoundField DataField="長度" HeaderText="長度" SortExpression="長度" HtmlEncode ="false"  />
                <asp:BoundField DataField="C_S" HeaderText="C/S" SortExpression="C_S" HtmlEncode ="false"  />
                <asp:BoundField DataField="訂單量" HeaderText="訂單量" SortExpression="訂單量" HtmlEncode ="false"  />
                <asp:BoundField DataField="發貨量" HeaderText="發貨量" SortExpression="發貨量" HtmlEncode ="false"  />
                <asp:BoundField DataField="待發貨" HeaderText="待發貨" SortExpression="待發貨" HtmlEncode ="false"  />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" HtmlEncode ="false"  />
                <asp:BoundField DataField="未交量" HeaderText="未交量" SortExpression="未交量" HtmlEncode ="false"  />
                <asp:BoundField DataField="內徑" HeaderText="內徑" SortExpression="內徑" HtmlEncode ="false"  />
                <asp:BoundField DataField="提貨單號D" HeaderText="提貨單號" SortExpression="提貨單號D" HtmlEncode ="false"  />
                <asp:BoundField DataField="鋼捲號碼D" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼D" HtmlEncode ="false"  />
                <asp:BoundField DataField="鋼種D" HeaderText="鋼種" SortExpression="鋼種D" HtmlEncode ="false"  />
                <asp:BoundField DataField="表面D" HeaderText="表面" SortExpression="表面D" HtmlEncode ="false"  />
                <asp:BoundField DataField="厚度D" HeaderText="厚度" SortExpression="厚度D" HtmlEncode ="false"  />
                <asp:BoundField DataField="寬度D" HeaderText="寬度" SortExpression="寬度D" HtmlEncode ="false"  />
                <asp:BoundField DataField="長度D" HeaderText="長度" SortExpression="長度D" HtmlEncode ="false"  />
                <asp:BoundField DataField="C_SD" HeaderText="C/S" SortExpression="C_SD" HtmlEncode ="false"  />
                <asp:BoundField DataField="淨重D" HeaderText="淨重" SortExpression="淨重D" HtmlEncode ="false"  />
                <asp:BoundField DataField="等級D" HeaderText="等級" SortExpression="等級D" HtmlEncode ="false"  />
                <asp:BoundField DataField="繳庫D" HeaderText="繳庫" SortExpression="繳庫D" HtmlEncode ="false"  />
                <asp:BoundField DataField="發貨D" HeaderText="發貨" SortExpression="發貨D" HtmlEncode ="false"  />
                <asp:BoundField DataField="沖銷D" HeaderText="沖銷" SortExpression="沖銷D" HtmlEncode ="false"  />
            </Columns>
        </asp:GridView>
    </asp:View>
</asp:MultiView>





<%--<table class="auto-style1" style="display: none">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch2" runat="server" Text="查詢" />
            <asp:HiddenField ID="hfParam2" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult2" runat="server" SelectMethod="SearchDetail" TypeName="EIS.SL2S01Search">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfParam2" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult2" Style="display: none">
    <Columns>
        <asp:BoundField DataField="提貨單號" HeaderText="提貨單號" SortExpression="提貨單號" />
        <asp:BoundField DataField="鋼捲號碼1" HeaderText="鋼捲號碼1" SortExpression="鋼捲號碼1" />
        <asp:BoundField DataField="鋼捲號碼2" HeaderText="鋼捲號碼2" SortExpression="鋼捲號碼2" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="長度" HeaderText="長度" SortExpression="長度" />
        <asp:BoundField DataField="C_S" HeaderText="C/S" SortExpression="C_S" />
        <asp:BoundField DataField="淨重" HeaderText="淨重" SortExpression="淨重" />
        <asp:BoundField DataField="等級" HeaderText="等級" SortExpression="等級" />
        <asp:BoundField DataField="繳庫" HeaderText="繳庫" SortExpression="繳庫" />
    </Columns>
</asp:GridView>






--%>




