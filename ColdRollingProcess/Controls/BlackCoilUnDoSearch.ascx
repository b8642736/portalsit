<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlackCoilUnDoSearch.ascx.vb" Inherits="ColdRollingProcess.BlackCoilUnDoSearch" %>
<style type="text/css">
    .style1
    {
        width: 108px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39;區分,EX: 201,304,...)</td>
    </tr>
    <tr>
        <td class="style1">
            TYPE:</td>
        <td>
            <asp:TextBox ID="tbSteelType" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39;區分,EX: TE,TE1,...)</td>
    </tr>
    <tr>
        <td class="style1">
            厚度:</td>
        <td>
            <asp:TextBox ID="tbGuage1" runat="server" Width="62px">0</asp:TextBox>
            ~<asp:TextBox ID="tbGuage2" runat="server" Width="62px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
                    </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="740px">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="中鋼熱軋號碼" HeaderText="中鋼熱軋號碼" 
            SortExpression="中鋼熱軋號碼" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="批次" HeaderText="批次" SortExpression="批次" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
        <asp:BoundField DataField="捲數" HeaderText="捲數" SortExpression="捲數" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="ColdRollingProcess.BlackCoilUnDoSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


