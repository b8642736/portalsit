<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SellStatic.ascx.vb" Inherits="EISTest.SellStatic" %>
<style type="text/css">
    .auto-style1
    {
        width: 50px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" AutoGenerateColumns="False" Width="703px">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="CR_HR" HeaderText="CR_HR" SortExpression="CR_HR" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
        <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
        <asp:BoundField DataField="金額" HeaderText="金額" SortExpression="金額" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search1" TypeName="EISTest.SellStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="hyfQry" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField ID="hyfQry" runat="server" />




