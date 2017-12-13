<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StockStatic.ascx.vb" Inherits="EIS.StockStatic" %>
<style type="text/css">
    .auto-style1
    {
        width: 81px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="重新查詢" Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="繳庫天數" HeaderText="繳庫天數" SortExpression="繳庫天數" />
        <asp:BoundField DataField="有主內銷" HeaderText="有主內銷" SortExpression="有主內銷" />
        <asp:BoundField DataField="有主外銷" HeaderText="有主外銷" SortExpression="有主外銷" />
        <asp:BoundField DataField="有主小計" HeaderText="有主小計" SortExpression="有主小計" />
        <asp:BoundField DataField="無主內銷" HeaderText="無主內銷" SortExpression="無主內銷" />
        <asp:BoundField DataField="無主外銷" HeaderText="無主外銷" SortExpression="無主外銷" />
        <asp:BoundField DataField="無主小計" HeaderText="無主小計" SortExpression="無主小計" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search1" TypeName="EIS.StockStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="hyfQry" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField ID="hyfQry" runat="server" />


