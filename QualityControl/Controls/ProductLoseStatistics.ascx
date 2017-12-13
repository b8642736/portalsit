<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductLoseStatistics.ascx.vb" Inherits="QualityControl.ProductLoseStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 50px;
    }
   
</style>

<table class="auto-style1">

    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="日期"></asp:Label>
        </td>
        <td >
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
        <td class="auto-style2"></td>
        <td >
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" /></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="QualityControl.ProductLoseStatistics">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL1All" Name="fromSQL1All" PropertyName="Value"
            Type="String" />
        <asp:ControlParameter ControlID="hfSQL1One" Name="fromSQL1One" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfSQL2" Name="fromSQL2" PropertyName="Value" Type="String" />        
        <asp:ControlParameter ControlID="hfSearchDateOfMoney" Name="fromDateOfMoney" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfSQL1All" runat="server" />
<asp:HiddenField ID="hfSQL1One" runat="server" />
<asp:HiddenField ID="hfSQL2" runat="server" />
<asp:HiddenField ID="hfSearchDateRange" runat="server" />
<asp:HiddenField ID="hfSearchDateOfMoney" runat="server" />