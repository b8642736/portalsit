<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VoucherSearch.ascx.vb" Inherits="WELFARE.VoucherSearch" %>
<style type="text/css">
    .auto-style1 {
        width: 96px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">入帳日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">會計科目:</td>
        <td>
            <asp:TextBox ID="tbAccCodes" runat="server" Width="250px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">款項目:</td>
        <td>
            <asp:TextBox ID="tbAccItems" runat="server" Width="250px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">明細項:</td>
        <td>
            <asp:TextBox ID="tbAccDetailCodes" runat="server" Width="250px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">摘要:</td>
        <td>
            <asp:TextBox ID="tbAccMemos" runat="server" Width="250px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="傳票編號" HeaderText="傳票編號" SortExpression="傳票編號" />
        <asp:BoundField DataField="傳票日期" HeaderText="傳票日期" SortExpression="傳票日期" />
        <asp:BoundField DataField="入帳日期" HeaderText="入帳日期" SortExpression="入帳日期" />
        <asp:BoundField DataField="會計科目" HeaderText="會計科目" SortExpression="會計科目" />
        <asp:BoundField DataField="款項目" HeaderText="款項目" SortExpression="款項目" />
        <asp:BoundField DataField="明細項" HeaderText="明細項" SortExpression="明細項" />
        <asp:BoundField DataField="借貸別" HeaderText="借貸別" SortExpression="借貸別" />
        <asp:BoundField DataField="金額" HeaderText="金額" SortExpression="金額" />
        <asp:BoundField DataField="科目別" HeaderText="科目別" SortExpression="科目別" />
        <asp:BoundField DataField="摘要" HeaderText="摘要" SortExpression="摘要" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="WELFARE.VoucherSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />


