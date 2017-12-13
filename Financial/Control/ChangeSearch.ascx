<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ChangeSearch.ascx.vb" Inherits="Financial.ChangeSearch" %>
<style type="text/css">
    .auto-style1
    {
        width: 122px;
    }
    .auto-style2
    {
        width: 122px;
        height: 20px;
    }
    .auto-style3
    {
        height: 20px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">客戶編號:</td>
        <td>
            <asp:TextBox ID="tbCustIDs" runat="server" Width="240px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分 ex:111,222)</td>
    </tr>
    <tr>
        <td class="auto-style2">統一編號:</td>
        <td class="auto-style3">
            <asp:TextBox ID="tbCustCompanyIDs" runat="server" Width="240px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分 ex:111,222)</td>
    </tr>
    <tr>
        <td class="auto-style1">押匯日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%">
    <Columns>
        <asp:BoundField DataField="客戶編號" HeaderText="客戶編號" SortExpression="客戶編號" />
        <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
        <asp:BoundField DataField="統一編號" HeaderText="統一編號" SortExpression="統一編號" />
        <asp:BoundField DataField="押匯日期" HeaderText="押匯日期" SortExpression="押匯日期" />
        <asp:BoundField DataField="匯票號碼" HeaderText="匯票號碼" SortExpression="匯票號碼" />
        <asp:BoundField DataField="銀行別" HeaderText="銀行別" SortExpression="銀行別" />
        <asp:BoundField DataField="金額" HeaderText="金額" SortExpression="金額" />
        <asp:BoundField DataField="收款單" HeaderText="收款單" SortExpression="收款單" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Financial.ChangeSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


