<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilNumberInfos.ascx.vb" Inherits="QualityControl.CoilNumberInfos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 81px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="200px"></asp:TextBox>
            (不含分捲;兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍 Ex:12345~54321,...)</td>
    </tr>
    <tr>
        <td class="style1">
            鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelkind" runat="server" Width="100px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            表面:</td>
        <td>
            <asp:TextBox ID="tbFace" runat="server" Width="100px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            會計期間:</td>
        <td>
            <asp:TextBox ID="tbStarDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStarDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStarDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">煉鋼爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍 Ex:A0001~A0010,B00001~B0010,...)</td>
        </td>
    </tr>
    <tr>
        <td class="style1">熱軋號碼:</td>
        <td>
            <asp:TextBox ID="tbHotCoilNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍)</td>
    </tr>
    <tr>
        <td class="style1">批號:</td>
        <td>
            <asp:TextBox ID="tbbatchNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
                    </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="分捲號碼" HeaderText="分捲號碼" SortExpression="分捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="鋼肧號碼" HeaderText="鋼肧號碼" SortExpression="鋼肧號碼" />
        <asp:BoundField DataField="煉鋼爐號" HeaderText="煉鋼爐號" SortExpression="煉鋼爐號" />
        <asp:BoundField DataField="報價單號碼" HeaderText="報價單號碼" SortExpression="報價單號碼" />
        <asp:BoundField DataField="會計日期" HeaderText="會計日期" SortExpression="會計日期" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilNumberInfos">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


