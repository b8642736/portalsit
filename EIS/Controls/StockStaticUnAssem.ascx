<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StockStaticUnAssem.ascx.vb" Inherits="EIS.StockStaticUnAssem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 200px;
        height: 30px;
    }

    .inputTextbox
    {
        width: 250px;
    }
</style>

<p />

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">鋼種</td>
                <td>
                    <asp:TextBox ID="tb鋼種" runat="server" CssClass="inputTextbox"></asp:TextBox>
                    &nbsp;(兩個以上以 &#39;,&#39; 分隔 ex:201,301)</td>
            </tr>
            <tr>
                <td class="auto-style2">等級</td>
                <td>
                    <asp:TextBox ID="tb等級" runat="server" CssClass="inputTextbox"></asp:TextBox>
                    &nbsp;(兩個以上以 &#39;,&#39; 分隔 ex:1,1X)</td>
            </tr>
            <tr>
                <td class="auto-style2">繳庫日期</td>
                <td>

                    <asp:TextBox ID="tb繳庫日期Start" runat="server" Width="90px"></asp:TextBox>
                    <cc1:CalendarExtender ID="tbStart_CalendarExtender" runat="server"
                        TargetControlID="tb繳庫日期Start" Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                    ~
            <asp:TextBox ID="tb繳庫日期End" runat="server" Width="90px"></asp:TextBox>
                    <cc1:CalendarExtender ID="tbEnd_CalendarExtender" runat="server"
                        TargetControlID="tb繳庫日期End" Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
    </asp:View>

    <asp:View ID="View2" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">客戶代號</td>
                <td>
                    <asp:TextBox ID="tb客戶代號" runat="server" CssClass="inputTextbox"></asp:TextBox>
                    &nbsp;(兩個以上以 &#39;,&#39; 分隔 或以 &#39;~&#39;指定範圍)</td>
            </tr>
        </table>
    </asp:View>

</asp:MultiView>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">輸出格式</td>
        <td>
            <asp:DropDownList ID="ddDisplayType" runat="server" Width="150px">
                <asp:ListItem>明細</asp:ListItem>
                <asp:ListItem  Selected="True">合計</asp:ListItem>
                <asp:ListItem>明細與合計</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" /></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="EIS.StockStaticUnAssem">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ddDisplayType" Name="fromDisplayType" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>


<p />
<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult">
    <Columns>
    </Columns>
</asp:GridView>


