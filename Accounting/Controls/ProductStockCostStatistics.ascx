<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductStockCostStatistics.ascx.vb" Inherits="Accounting.ProductStockCostStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .auto-style2 {
        width: 79px;
    }
</style>

<table class="auto-style1">

    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td class="auto-style2">結束日期</td>
        <td>
            <asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">資料版本</td>
        <td>
            <asp:DropDownList ID="ddDateVer" runat="server" Width="250px">
                <asp:ListItem Text="Ver1" Value="Ver1" />
                <asp:ListItem Text="Ver2 (104/11起)-繳庫日期" Value="Ver2a" />
                <asp:ListItem Text="Ver2 (104/11起)-訂單日期" Value="Ver2b"  Selected="True" />
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td class="auto-style2"></td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" /></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td></td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="Accounting.ProductStockCostStatistics">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value"
            Type="String" />
        <asp:ControlParameter ControlID="hfDateVer" Name="fromDateVer" PropertyName="Value"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfSQL" runat="server" />
<asp:HiddenField ID="hfSearchEndDate" runat="server" />
<asp:HiddenField ID="hfDateVer" runat="server" />
