<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EmployeeSampleSearch.ascx.vb" Inherits="Accounting.EmployeeSampleSearch" %>
<style type="text/css">
    .style1
    {
        width: 133px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            員工編號:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            員工姓名:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除" Width="100px" />
            <asp:Button ID="btnCancelReturn" runat="server" Text="取消返回" Width="100px" />
            <asp:HiddenField ID="hfSearchSQLString" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" Width="434px" 
    DataKeyNames="PT0102">
    <Columns>
        <asp:CommandField ButtonType="Button" SelectText="選取並返回" 
            ShowSelectButton="True" />
        <asp:BoundField DataField="PT0101" HeaderText="姓名" SortExpression="PT0101" />
        <asp:BoundField DataField="PT0102" HeaderText="工號" SortExpression="PT0102" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Accounting.EmployeeSampleSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSearchSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

