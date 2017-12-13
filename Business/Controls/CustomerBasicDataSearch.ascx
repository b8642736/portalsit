<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomerBasicDataSearch.ascx.vb" Inherits="Business.CustomerBasicDataSearch" %>
<style type="text/css">
    .style1
    {
        width: 80px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            客戶名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            客戶地址:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Width="279px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="查詢條件清除" Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="CUA01" HeaderText="客戶編號" SortExpression="CUA01" />
        <asp:BoundField DataField="CUA02" HeaderText="名稱" SortExpression="CUA02" />
        <asp:BoundField DataField="CUA03" HeaderText="統一編號" SortExpression="CUA03" />
        <asp:BoundField DataField="CUA04" HeaderText="郵遞區號1" SortExpression="CUA04" />
        <asp:BoundField DataField="CUA05" HeaderText="住址1" SortExpression="CUA05" />
        <asp:BoundField DataField="CUA06" HeaderText="電話1" SortExpression="CUA06" />
        <asp:BoundField DataField="CUA07" HeaderText="郵遞區號2" SortExpression="CUA07" />
        <asp:BoundField DataField="CUA08" HeaderText="住址2" SortExpression="CUA08" />
        <asp:BoundField DataField="CUA09" HeaderText="電話2" SortExpression="CUA09" />
        <asp:BoundField DataField="CUA11" HeaderText="客戶名稱簡寫" SortExpression="CUA11" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.CustomerBasicDataSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="CustomerName" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="TextBox2" Name="CustomerAddress" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

