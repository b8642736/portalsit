<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CashierOut.ascx.vb" Inherits="Financial.CashierOut" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 101px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="支出科目:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Height="19px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            付款日:</td>
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
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" AllowSorting="True" DataSourceID="odsSearchResult" 
    Width="100%">
    <Columns>
        <asp:BoundField DataField="支出科目" HeaderText="支出科目" SortExpression="支出科目" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="傳票" HeaderText="傳票" SortExpression="傳票" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="用途" HeaderText="用途" SortExpression="用途" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="支票金額" HeaderText="支票金額" SortExpression="支票金額">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="付款日" HeaderText="付款日" SortExpression="付款日" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Financial.CashierOut">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox2" Name="PayStartDate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="TextBox3" Name="PayEndDate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="CheckBox1" Name="IsFilterAccounItem" 
            PropertyName="Checked" Type="Boolean" />
        <asp:ControlParameter ControlID="TextBox1" Name="FilterAccounItem" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

