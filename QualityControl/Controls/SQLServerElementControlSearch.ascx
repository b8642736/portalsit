<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SQLServerElementControlSearch.ascx.vb" Inherits="QualityControl.SQLServerElementControlSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1 {
        width: 118px;
    }

    .style2 {
        width: 531px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style1">期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server"
                TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbStartHour" runat="server" Width="20px">08</asp:TextBox>
            <cc1:CalendarExtender ID="tbStartHour_CalendarExtender" runat="server"
                TargetControlID="tbStartHour" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            時<asp:TextBox ID="tbStartMinute" runat="server" Width="20px">00</asp:TextBox>
            <cc1:CalendarExtender ID="tbStartMinute_CalendarExtender" runat="server"
                TargetControlID="tbStartMinute" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            分~<asp:TextBox ID="tbEndDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server"
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbEndHour" runat="server" Width="20px">07</asp:TextBox>
            <cc1:CalendarExtender ID="tbEndHour_CalendarExtender" runat="server"
                TargetControlID="tbEndHour" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            時<asp:TextBox ID="tbEndMinute" runat="server" Width="20px">59</asp:TextBox>
            <cc1:CalendarExtender ID="tbEndMinute_CalendarExtender" runat="server"
                TargetControlID="tbEndMinute" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            分</td>
    </tr>

    <tr>
        <td class="style1">鋼種材質:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201,301)
        </td>
    </tr>
    <tr>
        <td class="style1">爐號範圍:</td>
        <td>
            <asp:TextBox ID="tbStove" runat="server" Width="349px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍 Ex:A0001~A0010,B00001~B0010,...)<asp:CustomValidator
                ID="CustomValidator1" runat="server" ControlToValidate="tbStove"
                ErrorMessage="必須輸入資料!">必須輸入資料!</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">不合格成份查詢:</td>
        <td>
            <table>
                <tr>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="70px">
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>Si</asp:ListItem>
                            <asp:ListItem>Mn</asp:ListItem>
                            <asp:ListItem>P</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>CR</asp:ListItem>
                            <asp:ListItem>NI</asp:ListItem>
                            <asp:ListItem>CU</asp:ListItem>
                            <asp:ListItem>MO</asp:ListItem>
                            <asp:ListItem>CO</asp:ListItem>
                            <asp:ListItem>AL</asp:ListItem>
                            <asp:ListItem>SN</asp:ListItem>
                            <asp:ListItem>PB</asp:ListItem>
                            <asp:ListItem>TI</asp:ListItem>
                            <asp:ListItem>NB</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                            <asp:ListItem>W</asp:ListItem>
                            <asp:ListItem>O2</asp:ListItem>
                            <asp:ListItem>N2</asp:ListItem>
                            <asp:ListItem>H2</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>Ca</asp:ListItem>
                            <asp:ListItem>Mg</asp:ListItem>
                            <asp:ListItem>Fe</asp:ListItem>
                            <asp:ListItem>DF</asp:ListItem>
                            <asp:ListItem>MD30</asp:ListItem>

                            <asp:ListItem>As</asp:ListItem>
                            <asp:ListItem>Bi</asp:ListItem>
                            <asp:ListItem>Sb</asp:ListItem>
                            <asp:ListItem>Zn</asp:ListItem>
                            <asp:ListItem>Zr</asp:ListItem>
                            <asp:ListItem>GP</asp:ListItem>
                            <asp:ListItem>Ta</asp:ListItem>

                            <asp:ListItem>CAndN</asp:ListItem>
                            <asp:ListItem>NbAndTa</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:Button ID="btnAddElement" runat="server" Text="加入查詢" />

                        (如不加入預設為全部成份)</td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:ListBox ID="lbElements" Height="100px" Width="300px" runat="server"></asp:ListBox>
                        <asp:Button ID="btnDeleteElement" runat="server" Text="移除查詢" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="style1">驗收料篩選:</td>
        <td>
            <asp:RadioButtonList ID="rbCheckMaterial" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="Y">驗收料</asp:ListItem>
                <asp:ListItem Value="N">非驗收料</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbClearSearchCondiction" runat="server" Text="清除查詢條件"
                Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel"
                Width="100px" />
        </td>
    </tr>
</table>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼種材質" HeaderText="鋼種材質" SortExpression="鋼種材質">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="成份" HeaderText="成份" SortExpression="成份">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="冶煉爐數" HeaderText="冶煉爐數" SortExpression="冶煉爐數">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="平均值" HeaderText="平均值" SortExpression="平均值">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="管制圍範" HeaderText="管制圍範" SortExpression="管制圍範">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="超出上限爐數" HeaderText="超出上限爐數"
            SortExpression="超出上限爐數">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="超出下限爐數" HeaderText="超出下限爐數"
            SortExpression="超出下限爐數">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="不合格爐數" HeaderText="不合格爐數" SortExpression="不合格爐數">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="QualityControl.SQLServerElementControlSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value"
            Type="String" />
        <asp:ControlParameter ControlID="hfLookElements" Name="LookElements"
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />



<asp:HiddenField ID="hfLookElements" runat="server" />



