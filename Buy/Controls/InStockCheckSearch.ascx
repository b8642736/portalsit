<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InStockCheckSearch.ascx.vb" Inherits="Buy.InStockCheckSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 51px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            料號:</td>
        <td>
            <asp:TextBox ID="tbMaterialID" runat="server" Width="235px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            特性:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value=" " Selected="True">物料</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">原料</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">配件</asp:ListItem>
                        <asp:ListItem Value="3" Selected="True">燃料</asp:ListItem>
                    </asp:CheckBoxList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="98px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="98px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
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
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="合約案號" HeaderText="合約案號" SortExpression="合約案號" />
        <asp:BoundField DataField="驗收日期" HeaderText="驗收日期" SortExpression="驗收日期" />
        <asp:BoundField DataField="入帳日期" HeaderText="入帳日期" SortExpression="入帳日期" />
        <asp:BoundField DataField="付款期限" HeaderText="付款期限" SortExpression="付款期限" />
        <asp:BoundField DataField="項次" HeaderText="項次" SortExpression="項次" />
        <asp:BoundField DataField="料號" HeaderText="料號" SortExpression="料號" />
        <asp:BoundField DataField="品名" HeaderText="品名" SortExpression="品名" />
        <asp:BoundField DataField="特性" HeaderText="特性" SortExpression="特性" />
        <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
        <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
        <asp:BoundField DataField="總價" HeaderText="總價" SortExpression="總價" />
        <asp:BoundField DataField="罰款或折讓金額" HeaderText="罰款或折讓金額" 
            SortExpression="罰款或折讓金額" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQry" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Buy.InStockCheckSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


