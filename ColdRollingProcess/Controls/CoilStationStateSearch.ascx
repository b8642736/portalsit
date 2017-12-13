<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilStationStateSearch.ascx.vb" Inherits="ColdRollingProcess.CoilStationStateSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 113px;
    }
    .auto-style1
    {
        width: 113px;
        height: 23px;
    }
    .auto-style2
    {
        height: 23px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            鋼捲編號:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="242px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)
        </td>
    </tr>
    <tr>
        <td class="style1">
            產出時間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server"  
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            產線:</td>
        <td class="auto-style2">
            <asp:Panel ID="paLines" runat="server">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="CPL1" />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="CPL2" />
                <asp:CheckBox ID="CheckBox3" runat="server" Text="APL1" />
                <asp:CheckBox ID="CheckBox4" runat="server" Text="APL2" />
                <asp:CheckBox ID="CheckBox5" runat="server" Text="GPL1" />
                <asp:CheckBox ID="CheckBox6" runat="server" Text="GPL2" />
                <asp:CheckBox ID="CheckBox7" runat="server" Text="ZML1" />
                <asp:CheckBox ID="CheckBox8" runat="server" Text="ZML2" />
                <asp:CheckBox ID="CheckBox9" runat="server" Text="ZML3" />
                <asp:CheckBox ID="CheckBox10" runat="server" Text="BAL" />
                <asp:CheckBox ID="CheckBox11" runat="server" Text="SPL" />
                <asp:CheckBox ID="CheckBox12" runat="server" Text="SBL" />
                <asp:CheckBox ID="CheckBox13" runat="server" Text="TLL" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style1">
            長度:</td>
        <td>
            <asp:TextBox ID="tbLength" runat="server" Width="242px"></asp:TextBox>
            (以 &#39;~&#39;指定範圍 )
        </td>
    </tr>
    <tr>
        <td class="style1">
            重量:</td>
        <td>
            <asp:TextBox ID="tbWeight" runat="server" Width="242px"></asp:TextBox>
            (以 &#39;~&#39;指定範圍 )
        </td>
    </tr>
    <tr>
        <td class="style1">
            厚度:</td>
        <td>
            <asp:TextBox ID="tbGuage" runat="server" Width="242px"></asp:TextBox>
            (以 &#39;~&#39;指定範圍 )
        </td>
    </tr>
    <tr>
        <td class="style1">
            寬度:</td>
        <td>
            <asp:TextBox ID="tbWidth" runat="server" Width="242px"></asp:TextBox>
            (以 &#39;~&#39;指定範圍 )
        </td>
    </tr>
    <tr>
        <td class="style1">
            </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢輸出Excel" 
                Width="100px" />
            <asp:Button ID="btnSearchToExcelAdvance" runat="server" Text="進階查詢輸出Excel" 
                Width="130px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="763px">
    <Columns>
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="線別" HeaderText="線別" SortExpression="線別" />
        <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
        <asp:BoundField DataField="產出時間" HeaderText="產出時間" SortExpression="產出時間" />
        <asp:BoundField DataField="報價單號碼" HeaderText="報價單號碼" SortExpression="報價單號碼" />
        <asp:BoundField DataField="報價單厚度" HeaderText="報價單厚度" SortExpression="報價單厚度" />
        <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="ColdRollingProcess.CoilStationStateSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />


