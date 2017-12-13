<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InsuranceDetailSearch.ascx.vb" Inherits="AST500LB.InsuranceDetailSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 125px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            保險基準日:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate" Enabled="True">
            </cc1:CalendarExtender>
        </td>
    </tr>
        <tr>
            <td class="style1">
                保險種類:</td>
            <td>
                <asp:CheckBoxList ID="cblInsurceKind" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">火險</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">爆炸險</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
    <tr>
        <td class="style1">
            廠別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">SA</asp:ListItem>
                <asp:ListItem>AA</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
                <asp:ListItem Value="QA"></asp:ListItem>
                <asp:ListItem Value="NA"></asp:ListItem>
                <asp:ListItem Value="RA"></asp:ListItem>
                <asp:ListItem Value="RC"></asp:ListItem>
                <asp:ListItem Value="RD"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnToExcel" runat="server" Text="查詢下載Excel" Width="100px" />

                <asp:HiddenField runat="server" ID="hfQryString"></asp:HiddenField>

                <asp:HiddenField ID="hfQryString1" runat="server" />

            <asp:HiddenField ID="hfQAndAArgs" runat="server" />

            </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="資產編號" HeaderText="資產編號" SortExpression="資產編號" />
        <asp:BoundField DataField="資產名稱" HeaderText="資產名稱" SortExpression="資產名稱" />
        <asp:BoundField DataField="置放地點" HeaderText="置放地點" SortExpression="置放地點" />
        <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
        <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
        <asp:BoundField DataField="價值" HeaderText="價值" SortExpression="價值" />
        <asp:BoundField DataField="入帳年月" HeaderText="入帳年月" SortExpression="入帳年月" />
        <asp:BoundField DataField="耐用年限" HeaderText="耐用年限" SortExpression="耐用年限" />
        <asp:BoundField DataField="已提折舊" HeaderText="已提折舊" SortExpression="已提折舊" />
        <asp:BoundField DataField="殘餘價值" HeaderText="殘餘價值" SortExpression="殘餘價值" />
        <asp:BoundField DataField="保險" HeaderText="保險" SortExpression="保險" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="AST500LB.InsuranceDetailSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQryString1" Name="QryString1" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQAndAArgs" Name="QAndAArgs" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

