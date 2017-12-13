<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HRLeaveDetail.ascx.vb" Inherits="Personnel.HRLeaveDetail" %>
<style type="text/css">
    .style1 {
        width: 81px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style1">單位代碼:</td>
        <td>
            <asp:TextBox ID="tbDepts" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分EX:W331,W332)</td>
    </tr>
    <tr>
        <td class="style1">工號/姓名:</td>
        <td>
            <asp:TextBox ID="tbEmployeeNameOrID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">日期範圍:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">假別:</td>
        <td>
            <asp:DropDownList ID="ddQueryType" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Personnel.HRLeaveDetail">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" PropertyName="Value" Type="String" />
                    <asp:Parameter Name="fromStartDate" Type="DateTime" />
                    <asp:Parameter Name="fromEndDate" Type="DateTime" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfSQLString" runat="server" />
            <asp:HiddenField ID="hfStartDate" runat="server" />
            <asp:HiddenField ID="hfEndDate" runat="server" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True" Width="70%">
    <Columns>
        <asp:BoundField DataField="單位代號" HeaderText="單位代號" SortExpression="單位代號" />
        <asp:BoundField DataField="工號" HeaderText="工號" SortExpression="工號" />
        <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
        <asp:BoundField DataField="假別" HeaderText="假別" SortExpression="假別" />
        <asp:BoundField DataField="起始時間" HeaderText="起始時間" SortExpression="起始時間" />
        <asp:BoundField DataField="終訖時間" HeaderText="終訖時間" SortExpression="終訖時間" />
        <asp:BoundField DataField="合計日時" HeaderText="合計日時" SortExpression="合計日時" HtmlEncode="false" />
    </Columns>
</asp:GridView>


