<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilNatureAndChemistryAttributeSearch.ascx.vb" Inherits="QualityControl.CoilNatureAndChemistryAttributeSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style1 {
        width: 126px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style1">鋼種:
        </td>
        <td>
            <asp:TextBox ID="tbSteelKind1" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201,301,304L1)
        </td>
    </tr>
    <tr>
        <td class="style1">TYPE:
        </td>
        <td>
            <asp:TextBox ID="tbSteelKind2" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 )
        </td>
    </tr>
    <tr>
        <td class="style1">爐號:</td>
        <td>
            <asp:TextBox ID="tbNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔 或 以&#39;~&#39;表示範圍)</td>
    </tr>
    <tr>
        <td class="style1">鋼捲號碼:
        </td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="248px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">表面:
        </td>
        <td>
            <asp:TextBox ID="tbCoiType" runat="server" Width="248px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">厚度:</td>
        <td>
            <asp:TextBox ID="tbStartThick" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndThick" runat="server" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="日期:"
                TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchField" runat="server" Text="清除查詢條件"
                Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" Width="100px" />
            <asp:HiddenField ID="hfControlSQLMaker" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" EnableViewState="False"
    AutoGenerateColumns="False" DataSourceID="odsSearchResult"
    EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼種Type" HeaderText="鋼種Type" SortExpression="鋼種Type" />
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="厚度" HeaderText="厚度(mm)" SortExpression="厚度" />
        <asp:BoundField DataField="C" HeaderText="C%" SortExpression="C" />
        <asp:BoundField DataField="Si" HeaderText="Si%" SortExpression="Si" />
        <asp:BoundField DataField="Mn" HeaderText="Mn%" SortExpression="Mn" />
        <asp:BoundField DataField="P" HeaderText="P%" SortExpression="P" />
        <asp:BoundField DataField="S" HeaderText="S%" SortExpression="S" />
        <asp:BoundField DataField="Cr" HeaderText="Cr%" SortExpression="Cr" />
        <asp:BoundField DataField="Ni" HeaderText="Ni%" SortExpression="Ni" />
        <asp:BoundField DataField="Cu" HeaderText="Cu%" SortExpression="Cu" />
        <asp:BoundField DataField="N" HeaderText="N%" SortExpression="N" />
        <asp:BoundField DataField="YS" HeaderText="YS(N/mm²)" SortExpression="YS" />
        <asp:BoundField DataField="RP10" HeaderText="RP1.0%" SortExpression="RP10" />
        <asp:BoundField DataField="TS" HeaderText="TS(N/mm²)" SortExpression="TS" />
        <asp:BoundField DataField="Elongation" HeaderText="Elongation%" SortExpression="Elongation" />
        <asp:BoundField DataField="HRB" HeaderText="HRB" SortExpression="HRB" />
        <asp:BoundField DataField="HV" HeaderText="HV" SortExpression="HV" />
        <asp:BoundField DataField="物理性能日期" HeaderText="物理_日期" SortExpression="物理性能日期" />
        <asp:BoundField DataField="物理性能線別" HeaderText="物理_線別" SortExpression="物理性能線別" />
        <asp:BoundField DataField="物理性能方向" HeaderText="物理_方向" SortExpression="物理性能方向" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="QualityControl.CoilNatureAndChemistryAttributeSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfControlSQLMaker" Name="SQLString"
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
