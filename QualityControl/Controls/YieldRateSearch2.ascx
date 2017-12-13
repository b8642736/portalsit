<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YieldRateSearch2.ascx.vb" Inherits="QualityControl.YieldRateSearch2" %>
<style type="text/css">
    .style1
    {
        width: 106px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="繳庫期間:" 
                TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" style="margin-bottom: 0px" 
                Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style1">唐榮批號:</td>
        <td>
            <asp:TextBox ID="tbLotsNumbers" runat="server" Width="150px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbSearchToExcel" runat="server" Text="Excel查詢下載" 
                Width="100px" />
        </td>
    </tr>

</table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSSearchResult" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="繳庫單位" HeaderText="繳庫單位" SortExpression="繳庫單位" />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="投入量" HeaderText="投入量" SortExpression="投入量" />
                <asp:BoundField DataField="產出量" HeaderText="產出量" SortExpression="產出量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="一級品率" HeaderText="一級品率" SortExpression="一級品率" />
                <asp:BoundField DataField="熱軋投入量" HeaderText="熱軋投入量" SortExpression="熱軋投入量" />
                <asp:BoundField DataField="熱軋產出量" HeaderText="熱軋產出量" SortExpression="熱軋產出量" />
                <asp:BoundField DataField="熱軋產出率" HeaderText="熱軋產出率" SortExpression="熱軋產出率" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSSearchResult" runat="server" 
            SelectMethod="Search" TypeName="QualityControl.YieldRateSearch2">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>



<asp:HiddenField ID="hfSQLString" runat="server" />







