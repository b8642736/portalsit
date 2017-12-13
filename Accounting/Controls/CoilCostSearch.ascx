<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilCostSearch.ascx.vb" Inherits="Accounting.CoilCostSearch" %>
<style type="text/css">
    .auto-style1
    {
        width: 75px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">批次:</td>
        <td>
            <asp:TextBox ID="tbBatch" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 例 : XXXX,XXXX,XXXX)</td>
    </tr>
    <tr>
        <td class="auto-style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 例 : 304,201)</td>
    </tr>
    <tr>
        <td class="auto-style1">表面:</td>
        <td>
            <asp:TextBox ID="tbFace" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 例 : 2B,2D)</td>
    </tr>
    <tr>
        <td class="auto-style1">厚度:</td>
        <td>
            <asp:TextBox ID="tbThick1" runat="server" Width="50px">-1</asp:TextBox>
            ~<asp:TextBox ID="tbThick2" runat="server" Width="50px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">銷售別:</td>
        <td>
            <asp:RadioButtonList ID="rblSellKind" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value=" ">內銷</asp:ListItem>
                <asp:ListItem Value="X">外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">料別:</td>
        <td>
            <asp:TextBox ID="tbMaterialKind" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 例 : L,G)</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="cbYear" runat="server" Text="年月:" TextAlign="Left" /></td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="50px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="50px"></asp:TextBox>
            (民國年/月 例:102/01)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
            <asp:DropDownList ID="DropDownList1" runat="server" Width="120px">
                <asp:ListItem Value="DETAILFORMAT" Selected="True">細目格式</asp:ListItem>
                <asp:ListItem Value="SUMFORMAT">彙總格式</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="GridView1" runat="server" Width="4000px" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="批次" HeaderText="批次" SortExpression="批次" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="銷售別" HeaderText="銷售別" SortExpression="銷售別" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="鋼捲" HeaderText="鋼捲" SortExpression="鋼捲" />
                <asp:BoundField DataField="斷捲" HeaderText="斷捲" SortExpression="斷捲" />
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                <asp:BoundField DataField="繳庫線別" HeaderText="繳庫線別" SortExpression="繳庫線別" />
                <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                <asp:BoundField DataField="投入重量" HeaderText="投入重量" SortExpression="投入重量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="軋鋼變動原料" HeaderText="軋鋼變動原料" SortExpression="軋鋼變動原料" />
                <asp:BoundField DataField="軋鋼變動燃料" HeaderText="軋鋼變動燃料" SortExpression="軋鋼變動燃料" />
                <asp:BoundField DataField="軋鋼變動物料" HeaderText="軋鋼變動物料" SortExpression="軋鋼變動物料" />
                <asp:BoundField DataField="軋鋼變動人工" HeaderText="軋鋼變動人工" SortExpression="軋鋼變動人工" />
                <asp:BoundField DataField="軋鋼變動間接費用" HeaderText="軋鋼變動間接費用" SortExpression="軋鋼變動間接費用" />
                <asp:BoundField DataField="軋鋼固定人工" HeaderText="軋鋼固定人工" SortExpression="軋鋼固定人工" />
                <asp:BoundField DataField="軋鋼固定間接費用" HeaderText="軋鋼固定間接費用" SortExpression="軋鋼固定間接費用" />
                <asp:BoundField DataField="軋鋼磅差" HeaderText="軋鋼磅差" SortExpression="軋鋼磅差" />
                <asp:BoundField DataField="軋鋼繳庫單號" HeaderText="軋鋼繳庫單號" SortExpression="軋鋼繳庫單號" />
                <asp:BoundField DataField="軋鋼型別" HeaderText="軋鋼型別" SortExpression="軋鋼型別" />
                <asp:BoundField DataField="軋鋼等級" HeaderText="軋鋼等級" SortExpression="軋鋼等級" />
                <asp:BoundField DataField="煉鋼變動原料" HeaderText="煉鋼變動原料" SortExpression="煉鋼變動原料" />
                <asp:BoundField DataField="煉鋼變動燃料" HeaderText="煉鋼變動燃料" SortExpression="煉鋼變動燃料" />
                <asp:BoundField DataField="煉鋼變動物料" HeaderText="煉鋼變動物料" SortExpression="煉鋼變動物料" />
                <asp:BoundField DataField="煉鋼變動人工" HeaderText="煉鋼變動人工" SortExpression="煉鋼變動人工" />
                <asp:BoundField DataField="煉鋼變動間接費用" HeaderText="煉鋼變動間接費用" SortExpression="煉鋼變動間接費用" />
                <asp:BoundField DataField="煉鋼固定人工" HeaderText="煉鋼固定人工" SortExpression="煉鋼固定人工" />
                <asp:BoundField DataField="煉鋼固定間接費用" HeaderText="煉鋼固定間接費用" SortExpression="煉鋼固定間接費用" />
                <asp:BoundField DataField="軋壞損耗" HeaderText="軋壞損耗" SortExpression="軋壞損耗" />
                <asp:BoundField DataField="代軋費" HeaderText="代軋費" SortExpression="代軋費" />
                <asp:BoundField DataField="訂單年月" HeaderText="訂單年月" SortExpression="訂單年月" />
                <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
                <asp:BoundField DataField="銷售金額" HeaderText="銷售金額" SortExpression="銷售金額" />
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" Width="4000px" AutoGenerateColumns="False" DataSourceID="odsSearchResult1" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="批次" HeaderText="批次" SortExpression="批次" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="銷售別" HeaderText="銷售別" SortExpression="銷售別" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="鋼捲" HeaderText="鋼捲" SortExpression="鋼捲" />
                <asp:BoundField DataField="斷捲" HeaderText="斷捲" SortExpression="斷捲" />
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                <asp:BoundField DataField="繳庫線別" HeaderText="繳庫線別" SortExpression="繳庫線別" />
                <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                <asp:BoundField DataField="投入重量" HeaderText="投入重量" SortExpression="投入重量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="軋鋼變動原料" HeaderText="軋鋼變動原料" SortExpression="軋鋼變動原料" />
                <asp:BoundField DataField="軋鋼變動燃料" HeaderText="軋鋼變動燃料" SortExpression="軋鋼變動燃料" />
                <asp:BoundField DataField="軋鋼變動物料" HeaderText="軋鋼變動物料" SortExpression="軋鋼變動物料" />
                <asp:BoundField DataField="軋鋼變動人工" HeaderText="軋鋼變動人工" SortExpression="軋鋼變動人工" />
                <asp:BoundField DataField="軋鋼變動間接費用" HeaderText="軋鋼變動間接費用" SortExpression="軋鋼變動間接費用" />
                <asp:BoundField DataField="軋鋼固定人工" HeaderText="軋鋼固定人工" SortExpression="軋鋼固定人工" />
                <asp:BoundField DataField="軋鋼固定間接費用" HeaderText="軋鋼固定間接費用" SortExpression="軋鋼固定間接費用" />
                <asp:BoundField DataField="軋鋼磅差" HeaderText="軋鋼磅差" SortExpression="軋鋼磅差" />
                <asp:BoundField DataField="軋鋼繳庫單號" HeaderText="軋鋼繳庫單號" SortExpression="軋鋼繳庫單號" />
                <asp:BoundField DataField="軋鋼型別" HeaderText="軋鋼型別" SortExpression="軋鋼型別" />
                <asp:BoundField DataField="軋鋼等級" HeaderText="軋鋼等級" SortExpression="軋鋼等級" />
                <asp:BoundField DataField="煉鋼變動原料" HeaderText="煉鋼變動原料" SortExpression="煉鋼變動原料" />
                <asp:BoundField DataField="煉鋼變動燃料" HeaderText="煉鋼變動燃料" SortExpression="煉鋼變動燃料" />
                <asp:BoundField DataField="煉鋼變動物料" HeaderText="煉鋼變動物料" SortExpression="煉鋼變動物料" />
                <asp:BoundField DataField="煉鋼變動人工" HeaderText="煉鋼變動人工" SortExpression="煉鋼變動人工" />
                <asp:BoundField DataField="煉鋼變動間接費用" HeaderText="煉鋼變動間接費用" SortExpression="煉鋼變動間接費用" />
                <asp:BoundField DataField="煉鋼固定人工" HeaderText="煉鋼固定人工" SortExpression="煉鋼固定人工" />
                <asp:BoundField DataField="煉鋼固定間接費用" HeaderText="煉鋼固定間接費用" SortExpression="煉鋼固定間接費用" />
                <asp:BoundField DataField="軋壞損耗" HeaderText="軋壞損耗" SortExpression="軋壞損耗" />
                <asp:BoundField DataField="代軋費" HeaderText="代軋費" SortExpression="代軋費" />
                <asp:BoundField DataField="訂單年月" HeaderText="訂單年月" SortExpression="訂單年月" />
                <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
                <asp:BoundField DataField="銷售金額" HeaderText="銷售金額" SortExpression="銷售金額" />
            </Columns>
        </asp:GridView>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfQryString" runat="server" />
<asp:HiddenField ID="hfQryString1" runat="server" />
<asp:HiddenField ID="hfSubQryString" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Accounting.CoilCostSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SqlString" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfSubQryString" Name="SqlString1" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsSearchResult1" runat="server" SelectMethod="Search1" TypeName="Accounting.CoilCostSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString1" Name="SqlString" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfSubQryString" Name="SqlString1" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


