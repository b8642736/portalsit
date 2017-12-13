<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SGMWeightSearch.ascx.vb" Inherits="StockStatic.SGMWeightSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 96px;
    }
    .style2
    {
        width: 96px;
        height: 24px;
    }
    .style3
    {
        height: 24px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="澆鑄日期:" Checked="True" 
                TextAlign="Left" /></td>
        <td>
            <asp:TextBox ID="btSearchDate1" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btSearchDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="btEndDate1" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btEndDate1">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">批號:</td>
        <td>
            <asp:TextBox ID="tbBatchSearch" runat="server" Width="200px"></asp:TextBox>
            (輸入範圍請以&#39;~&#39;區隔 ,EX:T663B~T667B)</td>
    </tr>
    <tr>
        <td class="style1">寬度:</td>
        <td>
            <asp:TextBox ID="tbWidth" runat="server"></asp:TextBox>
            (多筆請以&#39;,&#39;區隔,EX:1213,1240,...)</td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server"></asp:TextBox>
            (多筆請以&#39;,&#39;區隔,EX:304,201,...)</td>
    </tr>
    <tr>
        <td class="style2">鋼胚編號:</td>
        <td class="style3">
            <asp:TextBox ID="tbSlabNumber" runat="server"></asp:TextBox>
            (可用萬用字元&#39;*&#39; 篩選,EX:*-1010)</td>
    </tr>
    <tr>
        <td class="style2">爐號範圍:</td>
        <td>
            <asp:TextBox ID="tbStoveNumbers" runat="server"></asp:TextBox>(輸入範圍請以&#39;~&#39;區隔 ,EX:A1200~A1300)</td>
    </tr>
    <tr>
        <td class="style1">執行查詢:
           </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="轉換為Excel" 
                Width="100px" />
        </td>
    </tr>
</table>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="澆鑄日期" HeaderText="澆鑄日期" SortExpression="澆鑄日期" />
        <asp:BoundField DataField="澆鑄序號" HeaderText="澆鑄序號" SortExpression="澆鑄序號" />
        <asp:BoundField DataField="鋼胚編號" HeaderText="鋼胚編號" SortExpression="鋼胚編號" />
        <asp:BoundField DataField="重磨次數" HeaderText="重磨次數" SortExpression="重磨次數" />
        <asp:BoundField DataField="澆鑄班別" HeaderText="澆鑄班別" SortExpression="澆鑄班別" />
        <asp:BoundField DataField="鋼種材質" HeaderText="鋼種材質" SortExpression="鋼種材質" />
        <asp:BoundField DataField="研磨前過磅重" HeaderText="研磨前過磅重" 
            SortExpression="研磨前過磅重" />
        <asp:BoundField DataField="研磨後過磅重" HeaderText="研磨後過磅重" 
            SortExpression="研磨後過磅重" />
        <asp:BoundField DataField="切塊退回重" HeaderText="切塊退回重" SortExpression="切塊退回重" />
        <asp:BoundField DataField="研磨重" HeaderText="研磨重" SortExpression="研磨重" />
        <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
    </Columns>
    <RowStyle HorizontalAlign="Right" />
</asp:GridView>


<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search" TypeName="StockStatic.SGMWeightSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>




<asp:HiddenField ID="hfQry" runat="server" />





