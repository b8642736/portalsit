<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductBugStatistics.ascx.vb" Inherits="QualityControl.ProductBugStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        height: 20px;
    }
    .auto-style3
    {
        width: 308px;
    }
    .auto-style4
    {
        height: 20px;
        width: 308px;
    }
</style>

<table class="auto-style1">

    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label1" runat="server" Text="日期"></asp:Label>
        </td>
        <td class="auto-style2">
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~ <asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>

    <tr>
        <td class="auto-style4">新的缺陷代號  <asp:RadioButtonList ID="radioBugCode" runat="server" RepeatDirection="Horizontal" AutoPostBack ="true" >
                <asp:ListItem Selected="True" >自行輸入</asp:ListItem>
                <asp:ListItem>次級品</asp:ListItem>
                <asp:ListItem>頭尾廢料</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="auto-style2">
            <asp:TextBox ID="tbBugCodeNew" runat="server" Width="248px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style2">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" /></td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="QualityControl.ProductBugStatistics">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfStartDate" Name="fromStartDate" PropertyName="Value"
            Type="String" />
        <asp:ControlParameter ControlID="hfEndDate" Name="fromEndDate" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="tbBugCodeNew" Name="fromBugCodeNew" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfStartDate" runat="server" />
<asp:HiddenField ID="hfEndDate" runat="server" />
<asp:HiddenField ID="hfBugCodeNew" runat="server" />


