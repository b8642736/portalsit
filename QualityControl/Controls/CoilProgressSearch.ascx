<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilProgressSearch.ascx.vb" Inherits="QualityControl.CoilProgressSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 116px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            熱軋批號:</td>
        <td>
                    <asp:TextBox ID="tbLotsNumbers" runat="server"></asp:TextBox>
                    (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            最終生產日期:</td>
        <td>
                    <asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbEndDate">
                    </cc1:CalendarExtender>
                    </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                        <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                            Width="100px" />
                        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="熱軋批號" HeaderText="熱軋批號" SortExpression="熱軋批號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="分捲號碼" HeaderText="分捲號碼" SortExpression="分捲號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="完成日期" HeaderText="完成日期" SortExpression="完成日期" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="公稱厚度" HeaderText="公稱厚度" SortExpression="公稱厚度" />
        <asp:BoundField DataField="製程名稱" HeaderText="製程名稱" SortExpression="製程名稱" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
    </Columns>
</asp:GridView>

<asp:HiddenField ID="hfSQLString" runat="server" />


<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilProgressSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>



