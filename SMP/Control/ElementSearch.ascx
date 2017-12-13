<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ElementSearch.ascx.vb"
    Inherits="SMP.ElementSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style>
    .hidGridColumns {
        display: none;
    }
</style>
<span style="font-size: 18pt; color: #0000ff">煉鋼製程化學成份歷史資料查詢</span><table style="width: 800px; height: 48px">
    <tr>
        <td style="height: 30px">起始日:
        </td>
        <td style="height: 30px">
            <asp:TextBox ID="tbStartDate" runat="server" AutoPostBack="True"></asp:TextBox>(範例:2007/01/01)
        </td>
        <td style="height: 30px">終止日:
        </td>
        <td style="height: 30px">
            <asp:TextBox ID="tbEndDate" runat="server" AutoPostBack="True"></asp:TextBox>(範例:2007/12/31)
        </td>
    </tr>
    <tr>
        <td>查詢爐號:
        </td>
        <td>
            <asp:TextBox ID="tbFurnaceNumber" runat="server"></asp:TextBox>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>站 別:
        </td>
        <td>
            <asp:DropDownList ID="DDLStationName" runat="server" Width="152px" DataTextField="StationName"
                DataValueField="StationID">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">電爐A</asp:ListItem>
                <asp:ListItem Value="E2">電爐B</asp:ListItem>
                <asp:ListItem Value="A1">AOD</asp:ListItem>
                <asp:ListItem Value="L1">LADLE</asp:ListItem>
                <asp:ListItem Value="C%">TUNISH</asp:ListItem>
                <asp:ListItem Value="S1">SLAB</asp:ListItem>
                <asp:ListItem Value="INGOT">INGOT</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>鋼 種:
        </td>
        <td>
            <asp:TextBox ID="tbKind" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td>
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:HiddenField ID="hfSQL" runat="server" />
                        </td>
    </tr>
</table>
<asp:Button ID="btnSearch" runat="server" Text="查詢" Width="88px" />
<asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除" Width="88px" />
<asp:Button ID="btnSearchToExcel" runat="server" Text="下載EXCEL" Width="88px" /><br />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
    AutoGenerateColumns="False" DataSourceID="odsSearch" Width="2224px" PageSize="50" EnableModelValidation="True">
    <PagerSettings Position="Top" />
    <PagerStyle HorizontalAlign="Left" />
    <Columns>
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="站別" HeaderText="站別" SortExpression="站別" />
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="判定" HeaderText="判定" SortExpression="判定" />
        <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" DataFormatString="{0:F2}" />
        <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" DataFormatString="{0:F2}" />
        <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Si" HeaderText="Si" SortExpression="Si" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Mn" HeaderText="Mn" SortExpression="Mn" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Cr" HeaderText="Cr" SortExpression="Cr" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Ni" HeaderText="Ni" SortExpression="Ni" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Cu" HeaderText="Cu" SortExpression="Cu" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Mo" HeaderText="Mo" SortExpression="Mo" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Sn" HeaderText="Sn" SortExpression="Sn" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Pb" HeaderText="Pb" SortExpression="Pb" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
        <asp:BoundField DataField="Co" HeaderText="Co" SortExpression="Co" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Ti" HeaderText="Ti" SortExpression="Ti" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="Nb" HeaderText="Nb" SortExpression="Nb" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" DataFormatString="{0:F3}" />
        <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" DataFormatString="{0:F5}" />
        <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" DataFormatString="{0:F5}" />
        <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" DataFormatString="{0:F5}" />
        <asp:BoundField DataField="材質" HeaderText="材質" ReadOnly="True" SortExpression="材質" />
        <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
        <asp:BoundField DataField="INGOT" HeaderText="INGOT" SortExpression="INGOT" HeaderStyle-CssClass="hidGridColumns"
            ItemStyle-CssClass="hidGridColumns">

            <HeaderStyle CssClass="hidGridColumns"></HeaderStyle>

            <ItemStyle CssClass="hidGridColumns"></ItemStyle>

        </asp:BoundField>
        <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
        <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" />
        <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" />
        <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" />
        <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" />
        <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" />
        <asp:BoundField DataField="GP" HeaderText="GP" SortExpression="GP" />
        <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" />
        <asp:BoundField DataField="CAndN" HeaderText="CAndN" SortExpression="CAndN" />
        <asp:BoundField DataField="NbAndTa" HeaderText="NbAndTa" SortExpression="NbAndTa" />
    </Columns>
</asp:GridView>
&nbsp; &nbsp;
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="tbStartDate">
</cc1:CalendarExtender>
<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="tbEndDate">
</cc1:CalendarExtender>
<asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="SMP.ElementSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

