<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PayMoneySearch.ascx.vb" Inherits="Financial.PayMoneySearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 155px;
    }
    .style2
    {
        width: 100%;
    }
</style>
<table class="style2">
    <tr>
        <td>
            <span lang="zh-tw">付款日:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <span lang="zh-tw">~</span></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnConvertToExcel" runat="server" Text="轉換下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="ODSPayMoneySearchDisplayItem" ForeColor="#333333" 
    GridLines="None" Height="260px" PageSize="30" Width="980px">
    <PagerSettings PageButtonCount="20" Position="Top" />
    <RowStyle BackColor="#E3EAEB" />
    <Columns>
        <asp:BoundField DataField="DEPART" HeaderText="單位別" SortExpression="DEPART" />
        <asp:BoundField DataField="ACITEM" HeaderText="支出科目" SortExpression="ACITEM" />
        <asp:BoundField DataField="USEFOR" HeaderText="用途" SortExpression="USEFOR" />
        <asp:BoundField DataField="RECEPR" HeaderText="受款人" SortExpression="RECEPR" />
        <asp:BoundField DataField="CHKAMT" HeaderText="支票金額" SortExpression="CHKAMT" 
            DataFormatString="{0:###,###.00}" />
        <asp:BoundField DataField="DisplayPayDay" HeaderText="付款日" 
            SortExpression="DisplayPayDay" />
        <asp:BoundField DataField="BANKN1" HeaderText="銀行別" SortExpression="BANKN1" />
    </Columns>
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<asp:ObjectDataSource ID="ODSPayMoneySearchDisplayItem" runat="server" 
    SelectMethod="PayMoneySearch" 
    TypeName="Financial.PayMoneySearchDisplayItem" EnableCaching="True">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="StartPayDay" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="TextBox2" Name="EndPayDay" PropertyName="Text" 
            Type="DateTime" />
    </SelectParameters>
</asp:ObjectDataSource>

<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="Textbox1">
</cc1:CalendarExtender>


<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
    TargetControlID="Textbox2">
</cc1:CalendarExtender>
<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
    Mask="9999/99/99" MaskType="Date" TargetControlID="Textbox1">
</cc1:MaskedEditExtender>
<cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
    Mask="9999/99/99" MaskType="Date" TargetControlID="Textbox2">
</cc1:MaskedEditExtender>



