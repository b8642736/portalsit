<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetSearch.ascx.vb" Inherits="AST500LB.AssetSearch" %>
<style type="text/css">
    .style1
    {
        width: 95px;
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
        <TD />
            廠別:<TD />
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="ASTFSA">SA</asp:ListItem>
                            <asp:ListItem Value="ASTFAA">AA</asp:ListItem>
                            <asp:ListItem Value="ASTFAB">AB</asp:ListItem>
                            <asp:ListItem Value="ASTFBA">BA</asp:ListItem>
                            <asp:ListItem Value="ASTFQA">QA</asp:ListItem>
                            <asp:ListItem Value="ASTFNA">NA</asp:ListItem>
                            <asp:ListItem Value="ASTFRA">RA</asp:ListItem>
                            <asp:ListItem Value="ASTFRC">RC</asp:ListItem>
                            <asp:ListItem Value="ASTFRD">RD</asp:ListItem>
                        </asp:RadioButtonList>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchClearCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
            <asp:Button ID="btnCancelAndBack" runat="server" Text="取消返回" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" PageSize="15" 
    Width="302px" DataKeyNames="NUMBER">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                    CommandName="Select" Text="選取" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="NUMBER" HeaderText="資產編號" SortExpression="NUMBER" />
        <asp:BoundField DataField="NAME" HeaderText="資產名稱" SortExpression="NAME" />
        <asp:BoundField DataField="QUANT" HeaderText="數量" SortExpression="QUANT" />
    </Columns>
    <SelectedRowStyle BackColor="#CCFFFF" />
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" EnableCaching="True" 
    SelectMethod="Search" TypeName="AST500LB.AssetSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="AssetNumber" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="TextBox2" Name="AssetName" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="RadioButtonList1" Name="PlanClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

