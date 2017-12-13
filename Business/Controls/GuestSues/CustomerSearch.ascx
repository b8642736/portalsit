<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomerSearch.ascx.vb" Inherits="Business.CustomerSearch" %>
<style type="text/css">
    .style1
    {
        width: 80px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            客戶名稱:</td>
        <td>
            <asp:TextBox ID="tbCustomerName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            客戶編號:</td>
        <td>
            <asp:TextBox ID="tbCustomerID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            地址:</td>
        <td>
            <asp:TextBox ID="tbCustomerAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnCancelReturn" runat="server" Text="取消返回" Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%" 
    DataKeyNames="CUA01">
    <Columns>
        <asp:CommandField ButtonType="Button" SelectText="選取並返回" 
        ShowSelectButton="True" />
        <asp:BoundField DataField="CUA01" HeaderText="客戶編號" SortExpression="CUA01" />
        <asp:BoundField DataField="CUA11" HeaderText="簡稱" SortExpression="CUA11" />
        <asp:BoundField DataField="CUA02" HeaderText="公司全名" SortExpression="CUA02" />
        <asp:BoundField DataField="CUA05" HeaderText="地址1" SortExpression="CUA05" />
        <asp:BoundField DataField="CUA08" HeaderText="地址2" SortExpression="CUA08" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfSearchSQLString" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.CustomerSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSearchSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


