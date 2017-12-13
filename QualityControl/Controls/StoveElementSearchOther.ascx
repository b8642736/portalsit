<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StoveElementSearchOther.ascx.vb" Inherits="QualityControl.StoveElementSearchOther" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 82px;
    }
</style>

<table style="width: 100%;">
    <tr>
        <td class="auto-style1">資料類型:</td>
        <td>
            <asp:DropDownList ID="ddMode" runat="server" AutoPostBack="True">
                <asp:ListItem>外購鋼捲</asp:ListItem>
                <asp:ListItem>委驗</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lbLotsNo" runat="server" Text="批號"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbLotsNo" runat="server"></asp:TextBox>
            <asp:Label ID="lbLotsNoMsg" runat="server" Text=" (兩個以上以&nbsp; &#39;,&#39; 分隔，區間以&#39;~&#39;分隔 )" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lbBuildUpNo" runat="server" Text="鋼捲號碼"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbBuildUpNo" runat="server"></asp:TextBox>
            <asp:Label ID="lbBuildUpNoMsg" runat="server" Text=" (兩個以上以&nbsp; &#39;,&#39; 分隔，區間以&#39;~&#39;分隔 )" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lbLabNo" runat="server" Text="委託單號"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbLabNo" runat="server"></asp:TextBox>
            <asp:Label ID="lbLabNoMsg" runat="server" Text=" (兩個以上以&nbsp; &#39;,&#39; 分隔，區間以&#39;~&#39;分隔 )" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>鋼種材質:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201TE1,301)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="期間:" TextAlign="Left" /></td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server"
                TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbStartHour" runat="server" Width="20px">08</asp:TextBox>
            時<asp:TextBox ID="tbStartMinute" runat="server" Width="20px">00</asp:TextBox>
            分~<asp:TextBox ID="tbEndDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server"
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbEndHour" runat="server" Width="20px">07</asp:TextBox>
            時<asp:TextBox ID="tbEndMinute" runat="server" Width="20px">59</asp:TextBox>
            分</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbClearSearchCondiction" runat="server" Text="清除查詢條件"
                Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel"
                Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
                TypeName="QualityControl.StoveElementSearchOther">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQLString" Name="SQLString"
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>


            <asp:HiddenField ID="hfSQLString" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="Title1" HeaderText="Title1" SortExpression="Title1" />
        <asp:BoundField DataField="Title2" HeaderText="Title2" SortExpression="Title2" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
        <asp:BoundField DataField="SI" HeaderText="SI" SortExpression="SI" />
        <asp:BoundField DataField="MN" HeaderText="MN" SortExpression="MN" />
        <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
        <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
        <asp:BoundField DataField="CR" HeaderText="CR" SortExpression="CR" />
        <asp:BoundField DataField="NI" HeaderText="NI" SortExpression="NI" />
        <asp:BoundField DataField="CU" HeaderText="CU" SortExpression="CU" />
        <asp:BoundField DataField="MO" HeaderText="MO" SortExpression="MO" />
        <asp:BoundField DataField="CO" HeaderText="CO" SortExpression="CO" />
        <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
        <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
        <asp:BoundField DataField="PB" HeaderText="PB" SortExpression="PB" />
        <asp:BoundField DataField="TI" HeaderText="TI" SortExpression="TI" />
        <asp:BoundField DataField="NB" HeaderText="NB" SortExpression="NB" />
        <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
        <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
        <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
    </Columns>
</asp:GridView>

