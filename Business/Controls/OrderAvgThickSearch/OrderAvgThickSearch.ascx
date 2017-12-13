<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderAvgThickSearch.ascx.vb" Inherits="Business.OrderAvgThickSearch" %>
<style type="text/css">
    .style1
    {
        width: 125px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            客戶編號:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            月份:</td>
        <td>
            <asp:TextBox ID="tbStartYear" runat="server" Width="30px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth" runat="server" Width="30px"></asp:TextBox>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
            <asp:HiddenField ID="hfQryString" runat="server" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
        <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="CR或HR" HeaderText="CR或HR" SortExpression="CR或HR" />
        <asp:BoundField DataField="2D" HeaderText="2D" SortExpression="2D" />
        <asp:BoundField DataField="2B" HeaderText="2B" SortExpression="2B" />
        <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA" />
        <asp:BoundField DataField="SH" HeaderText="SH" SortExpression="SH" />
        <asp:BoundField DataField="NO1" HeaderText="NO1" SortExpression="NO1" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.OrderAvgThickSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


