<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SteelPlantSendOutSearch.ascx.vb" Inherits="StockStatic.SteelPlantSendOutSearch" %>
<style type="text/css">
    .style1
    {
        width: 42px;
    }
    .style2
    {
        width: 92px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            批號:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="164px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
            (兩種以上請以&#39;,&#39;區分 EX:304,201)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchReset" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="轉換Excel下載" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="ODSSearchResult" AllowPaging="True" BackColor="White" 
    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
    GridLines="Vertical" PageSize="20" EnableModelValidation="True">
    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    <Columns>
        <asp:BoundField DataField="鋼種尺寸" HeaderText="鋼種尺寸" SortExpression="鋼種尺寸" />
        <asp:BoundField DataField="計劃數量" HeaderText="計劃數量" SortExpression="計劃數量" />
        <asp:BoundField DataField="計劃重量" HeaderText="計劃重量" SortExpression="計劃重量" />
        <asp:BoundField DataField="已外送數量" HeaderText="已外送數量" SortExpression="已外送數量" />
        <asp:BoundField DataField="已外送重量" HeaderText="已外送重量" SortExpression="已外送重量" />
        <asp:BoundField DataField="平均重量" HeaderText="平均重量" SortExpression="平均重量" />
        <asp:BoundField DataField="研磨率" HeaderText="研磨率" SortExpression="研磨率" />
        <asp:BoundField DataField="頭塊研磨率" HeaderText="頭塊研磨率" SortExpression="頭塊研磨率" />
        <asp:BoundField DataField="非頭塊研磨率" HeaderText="非頭塊研磨率" 
            SortExpression="非頭塊研磨率" />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="#DCDCDC" />
</asp:GridView>
<asp:ObjectDataSource ID="ODSSearchResult" runat="server" SelectMethod="Search" 
    TypeName="StockStatic.SteelPlantSendOutSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField ID="hfQry" runat="server" />

<table>
    <tr>
        <td colspan="2" >
        其它資訊</td>
    </tr>
    <tr>
        <td  class="style2" >
            A爐起訖:</td>
        <td>
            <asp:Label ID="lbOtherMsg1" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td class="style2">
            B爐起訖:</td>
        <td>
            <asp:Label ID="lbOtherMsg2" runat="server" Text=""></asp:Label></td>
    </tr>
</table>


