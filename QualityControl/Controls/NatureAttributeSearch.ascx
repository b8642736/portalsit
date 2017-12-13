<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NatureAttributeSearch.ascx.vb" Inherits="QualityControl.NatureAttributeSearch" %>
<style type="text/css">
    .style1
    {
        width: 126px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
        鋼胚編號:
        </td>
        <td>
            <asp:TextBox ID="tbSLABNumber" runat="server" Width="143px"></asp:TextBox>
            (萬用字元&#39;*&#39; ex:A*-*40)</td>
    </tr>
    <tr>
        <td class="style1">
            熱軋批次:</td>
        <td>
            <asp:TextBox ID="tbLotsNumber" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            熱軋厚度:</td>
        <td>
            <asp:TextBox ID="tbHotStartThick" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbHotEndThick" runat="server" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            熱軋寬度:</td>
        </td>
        <td>
            <asp:TextBox ID="tbHotStartWidth" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbHotEndWidth" runat="server" Width="70px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style1">
            冷軋厚度:</td>
        <td>
            <asp:TextBox ID="tbStartThick" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndThick" runat="server" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            冷軋寬度:</td>
        </td>
        <td>
            <asp:TextBox ID="tbStartWidth" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndWidth" runat="server" Width="70px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種材質:</td>
        <td>
            <asp:TextBox ID="tbSteelKindType" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumber" runat="server" Width="200px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td>產線:</td>
        <td>
            <asp:TextBox ID="tbProductLines" runat="server" Width="200px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)
        </td>
    </tr>
    <tr>
        <td class="style1">方向:</td>
        <td>
            <asp:TextBox ID="tbDriection" runat="server" Width="200px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchField" runat="server" Text="清除查詢條件" 
                Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" Width="100px" />
            <asp:HiddenField ID="hfControlSQLMaker" runat="server" />
            <asp:HiddenField ID="hfPPSSHAPFQry" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" EnableViewState="False" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" 
    EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="檢驗日期" HeaderText="檢驗日期" SortExpression="檢驗日期" />
        <asp:BoundField DataField="產線別" HeaderText="產線別" SortExpression="產線別" />
        <asp:BoundField DataField="熱軋厚度" HeaderText="熱軋厚度" SortExpression="熱軋厚度" />
        <asp:BoundField DataField="熱軋寬度" HeaderText="熱軋寬度" SortExpression="熱軋寬度" />
        <asp:BoundField DataField="冷軋厚度" HeaderText="冷軋厚度" SortExpression="冷軋厚度" />
        <asp:BoundField DataField="冷軋寬度" HeaderText="冷軋寬度" SortExpression="冷軋寬度" />
        <asp:BoundField DataField="方向" HeaderText="方向" SortExpression="方向" />
        <asp:BoundField DataField="t.s" HeaderText="t.s" SortExpression="t.s" />
        <asp:BoundField DataField="y.s" HeaderText="y.s" SortExpression="y.s" />
        <asp:BoundField DataField="elong" HeaderText="elong" SortExpression="elong" />
        <asp:BoundField DataField="HRB" HeaderText="HRB" SortExpression="HRB" />
        <asp:BoundField DataField="HRC" HeaderText="HRC" SortExpression="HRC" />
        <asp:BoundField DataField="Hv" HeaderText="Hv" SortExpression="Hv" />
        <asp:BoundField DataField="R-VAL" HeaderText="R-VAL" SortExpression="R-VAL" />
        <asp:BoundField DataField="N-VAL" HeaderText="N-VAL" SortExpression="N-VAL" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.NatureAttributeSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfControlSQLMaker" Name="SQLString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfPPSSHAPFQry" Name="PPSSHASQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>