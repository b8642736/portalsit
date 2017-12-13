<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CasherIn.ascx.vb" Inherits="Financial.CasherIn" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 97px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">六連單編號:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="收入項目:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            收款日:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="TextBox2">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="TextBox3" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="TextBox3">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢轉換Excel" 
                Width="100px" />
            <asp:HiddenField ID="HFSQLQry" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsSearchResult" 
    PageSize="20" Width="100%">
    <Columns>
        <asp:BoundField DataField="收入項目" HeaderText="收入項目" SortExpression="收入項目">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="六聯單編號" HeaderText="六聯單編號" SortExpression="六聯單編號">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="收入金額" HeaderText="收入金額" SortExpression="收入金額">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="財務收款日" HeaderText="財務收款日" SortExpression="財務收款日">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="摘要" HeaderText="摘要" SortExpression="摘要">
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Financial.CasherIn">
    <SelectParameters>
        <asp:ControlParameter ControlID="HFSQLQry" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

