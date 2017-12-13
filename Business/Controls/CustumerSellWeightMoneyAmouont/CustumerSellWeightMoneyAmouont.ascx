<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustumerSellWeightMoneyAmouont.ascx.vb" Inherits="Business.CustumerSellWeightMoneyAmouont" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 73px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            
            
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
            
            
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableViewState="False" Width="100%">
    <Columns>
        <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="客戶別" HeaderText="客戶別" SortExpression="客戶別" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="CRHR" HeaderText="CR/HR" SortExpression="CRHR" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="噸數" HeaderText="噸數" SortExpression="噸數" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="金額" HeaderText="金額" SortExpression="金額" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="內外銷噸數百分比" HeaderText="內外銷噸數%" 
            SortExpression="內外銷噸數百分比">
        <HeaderStyle Width="120px" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQryString" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.CustumerSellWeightMoneyAmouont">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SQLString" 
            PropertyName="Value" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>

