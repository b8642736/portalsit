<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LineWeightStatistics.ascx.vb" Inherits="ColdRollingProcess.LineWeightStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style3
    {
        width: 150px;
        height: 26px;
    }
</style>

<p />
<table class="auto-style1">
    <tr>
        <td class="auto-style3">期間</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbDateStart" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateStart_CalendarExtender" runat="server" TargetControlID="tbDateStart" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
            <asp:TextBox ID="tbDateEnd" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateEnd_CalendarExtender" runat="server" TargetControlID="tbDateEnd" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
        <tr>
            <td>線別</td>
            <td>

                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>APL</asp:ListItem>
                    <asp:ListItem>BAL</asp:ListItem>
                    <asp:ListItem>CPL</asp:ListItem>
                    <asp:ListItem>GPL</asp:ListItem>
                    <asp:ListItem>SBL</asp:ListItem>
                    <asp:ListItem>SPL</asp:ListItem>
                    <asp:ListItem>TLL</asp:ListItem>
                    <asp:ListItem>ZML</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>

        <tr>
            <td>資料類型</td>
            <td>

                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>明細</asp:ListItem>
                    <asp:ListItem>統計</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

            <tr>
            <td>同產線同鋼捲計算</td>
            <td>

                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>每次都算</asp:ListItem>
                    <asp:ListItem>只算一次</asp:ListItem>
                    <asp:ListItem>PASS</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:HiddenField ID="hfQryString" runat="server" />
            <asp:HiddenField ID="hfLineName2Char" runat="server" />
            <asp:HiddenField ID="hfLineName1Char" runat="server" />
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="ColdRollingProcess.LineWeightStatistics">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfLineName2Char" Name="fromLineName2Char" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfLineName1Char" Name="fromLineName1Char" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<br />
<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" />



