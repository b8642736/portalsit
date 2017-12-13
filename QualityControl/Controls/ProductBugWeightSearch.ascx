<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductBugWeightSearch.ascx.vb" Inherits="QualityControl.ProductBugWeightSearch" %>
<style type="text/css">

    .style1
    {
        width: 106px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            批號:</td>
        <td>
            <asp:TextBox ID="tbLotNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 或 以&#39;~&#39;表示範圍)</td>
    </tr>
    <tr>
        <td class="style1">
            缺陷:</td>
        <td>
            <asp:TextBox ID="tbBugs" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
        <asp:BoundField DataField="黑皮號碼" HeaderText="黑皮號碼" SortExpression="黑皮號碼" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="等級" HeaderText="等級" SortExpression="等級" />
        <asp:BoundField DataField="繳庫淨重" HeaderText="繳庫淨重" SortExpression="繳庫淨重" />
    </Columns>
    <RowStyle HorizontalAlign="Right" />
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.ProductBugWeightSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="HFQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="HFQry" runat="server" />





