<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WorkOrRestDetailSearch.ascx.vb" Inherits="Personnel.WorkOrRestDetailSearch" %>
<style type="text/css">

    .style1
    {
        width: 81px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            單位代碼:</td>
        <td>
            <asp:TextBox ID="tbDepts" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分EX:W331,W332)</td>
    </tr>
    <tr>
        <td class="style1">
            工號/姓名:</td>
        <td>
            <asp:TextBox ID="tbEmployeeNameOrID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            日期範圍:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
        <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
        <asp:BoundField DataField="工號" HeaderText="工號" SortExpression="工號" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="值勤" HeaderText="值勤" SortExpression="值勤" />
        <asp:BoundField DataField="應出勤時間" HeaderText="應出勤時間" SortExpression="應出勤時間" />
        <asp:BoundField DataField="刷卡時時間" HeaderText="刷卡時時間" SortExpression="刷卡時時間" />
        <asp:BoundField DataField="請假時數" HeaderText="請假時數" SortExpression="請假時數" HtmlEncode="false" />
        <asp:BoundField DataField="加班" HeaderText="加班" SortExpression="加班" />
        <asp:BoundField DataField="說明" HeaderText="說明" SortExpression="說明" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Personnel.WorkOrRestDetailSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />



