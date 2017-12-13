<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetTransferSearch.ascx.vb" Inherits="AST500LB.AssetTransferSearch" %>
<style type="text/css">



    .style1
    {
        width: 101px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            資產編號:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            資產名稱:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            公司廠別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="SA">不銹鋼</asp:ListItem>
                <asp:ListItem Value="AA">總公司(舊)</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <TR>
    <TD />
        狀態:<TD />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="INUSE">使用中</asp:ListItem>
                <asp:ListItem Value="NOUSE">報廢</asp:ListItem>
            </asp:RadioButtonList>
    </TR>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" PageSize="20" Width="100%" 
    EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="資產編號" HeaderText="資產編號" SortExpression="資產編號" />
        <asp:BoundField DataField="資產名稱" HeaderText="資產名稱" SortExpression="資產名稱" />
        <asp:BoundField DataField="入帳年月" HeaderText="入帳年月" SortExpression="入帳年月" />
        <asp:BoundField DataField="使用單位" HeaderText="使用單位" SortExpression="使用單位" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
        <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="總價" HeaderText="總價" SortExpression="總價" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="移轉日期" HeaderText="移轉日期" SortExpression="移轉日期" />
        <asp:BoundField DataField="移出單位" HeaderText="移出單位" SortExpression="移出單位" />
        <asp:BoundField DataField="移入單位" HeaderText="移入單位" SortExpression="移入單位" />
        <asp:BoundField DataField="目前狀態" HeaderText="目前狀態" SortExpression="目前狀態" />
        <asp:BoundField DataField="報廢日期" HeaderText="報廢日期" SortExpression="報廢日期" />
        <asp:BoundField DataField="殘值" HeaderText="殘值" SortExpression="殘值">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search" TypeName="AST500LB.AssetTransferSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="RadioButtonList1" Name="USEState" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="TextBox1" Name="AssetNumber" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="TextBox2" Name="AssetName" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="RadioButtonList2" Name="PlanCode" PropertyName="SelectedValue" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
