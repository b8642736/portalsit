<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MaterialBuyInComeSearch.ascx.vb" Inherits="Buy.MaterialBuyInComeSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">

    .style1
    {
        width: 98px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">供應商名稱:</td>
        <td>
            <asp:TextBox ID="tbSupplyName" runat="server" Width="235px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            料號:</td>
        <td>
            <asp:TextBox ID="tbMaterialID" runat="server" Width="235px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="98px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="98px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="合約案號" HeaderText="合約案號" SortExpression="合約案號" />
        <asp:BoundField DataField="項次" HeaderText="項次" SortExpression="項次" />
        <asp:BoundField DataField="物料編號" HeaderText="物料編號" SortExpression="物料編號" />
        <asp:BoundField DataField="品名" HeaderText="品名" SortExpression="品名" />
        <asp:BoundField DataField="供應商" HeaderText="供應商" SortExpression="供應商" />
        <asp:BoundField DataField="合約日期" HeaderText="合約日期" SortExpression="合約日期" />
        <asp:BoundField DataField="履約期限" HeaderText="履約期限" SortExpression="履約期限" />
        <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
        <asp:BoundField DataField="幣別" HeaderText="幣別" SortExpression="幣別" />
        <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
        <asp:BoundField DataField="總價" HeaderText="總價" SortExpression="總價" />
        <asp:BoundField DataField="已驗收數量" HeaderText="已驗收數量" SortExpression="已驗收數量" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQry" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Buy.MaterialBuyInComeSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>





