<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DebtLetterofCreditSearch.ascx.vb" Inherits="Accounting.DebtLetterofCreditSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<p />
<table class="auto-style1">
    <tr>
        <td>到期日期：</td>
        <td>
            <asp:TextBox ID="tbToday_Start" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbToday_Start" />

            <asp:Label ID="Label1" runat="server" Text=" ~ "></asp:Label>
            <asp:TextBox ID="tbToday_End" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                Format="yyyy/MM/dd" TargetControlID="tbToday_End" />

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" Height="40px" Style="margin-right: 0px" />

            &nbsp;
            
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" Height="40px" />
        </td>
    </tr>

    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Accounting.DebtLetterofCreditSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Label ID="到期日Label" runat="server" Text='<%# Eval("到期日") %>' />
            </td>
            <td>
                <asp:Label ID="信用狀編號Label" runat="server" Text='<%# Eval("信用狀編號") %>' />
            </td>
            <td>
                <asp:Label ID="單位別Label" runat="server" Text='<%# Eval("單位別") %>' />
            </td>
            <td>
                <asp:Label ID="幣別Label" runat="server" Text='<%# Eval("幣別") %>' />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") %>' />
            </td>
            <td>
                <asp:Label ID="發行日Label" runat="server" Text='<%# Eval("發行日") %>' />
            </td>
            <td>
                <asp:Label ID="銀行別Label" runat="server" Text='<%# Eval("銀行別") %>' />
            </td>
            <td>
                <asp:Label ID="期限Label" runat="server" Text='<%# Eval("期限") %>' />
            </td>
            <td>
                <asp:Label ID="利率Label" runat="server" Text='<%# Eval("利率") %>' />
            </td>
            <td>
                <asp:Label ID="利息Label" runat="server" Text='<%# Eval("利息") %>' />
            </td>
            <td>
                <asp:Label ID="兌換率Label" runat="server" Text='<%# Eval("兌換率") %>' />
            </td>
            <td>
                <asp:Label ID="新台幣金額Label" runat="server" Text='<%# Eval("新台幣金額") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="到期日TextBox" runat="server" Text='<%# Bind("到期日") %>' />
            </td>
            <td>
                <asp:TextBox ID="信用狀編號TextBox" runat="server" Text='<%# Bind("信用狀編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="單位別TextBox" runat="server" Text='<%# Bind("單位別") %>' />
            </td>
            <td>
                <asp:TextBox ID="幣別TextBox" runat="server" Text='<%# Bind("幣別") %>' />
            </td>
            <td>
                <asp:TextBox ID="金額TextBox" runat="server" Text='<%# Bind("金額") %>' />
            </td>
            <td>
                <asp:TextBox ID="發行日TextBox" runat="server" Text='<%# Bind("發行日") %>' />
            </td>
            <td>
                <asp:TextBox ID="銀行別TextBox" runat="server" Text='<%# Bind("銀行別") %>' />
            </td>
            <td>
                <asp:TextBox ID="期限TextBox" runat="server" Text='<%# Bind("期限") %>' />
            </td>
            <td>
                <asp:TextBox ID="利率TextBox" runat="server" Text='<%# Bind("利率") %>' />
            </td>
            <td>
                <asp:TextBox ID="利息TextBox" runat="server" Text='<%# Bind("利息") %>' />
            </td>
            <td>
                <asp:TextBox ID="兌換率TextBox" runat="server" Text='<%# Bind("兌換率") %>' />
            </td>
            <td>
                <asp:TextBox ID="新台幣金額TextBox" runat="server" Text='<%# Bind("新台幣金額") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="到期日TextBox" runat="server" Text='<%# Bind("到期日") %>' />
            </td>
            <td>
                <asp:TextBox ID="信用狀編號TextBox" runat="server" Text='<%# Bind("信用狀編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="單位別TextBox" runat="server" Text='<%# Bind("單位別") %>' />
            </td>
            <td>
                <asp:TextBox ID="幣別TextBox" runat="server" Text='<%# Bind("幣別") %>' />
            </td>
            <td>
                <asp:TextBox ID="金額TextBox" runat="server" Text='<%# Bind("金額") %>' />
            </td>
            <td>
                <asp:TextBox ID="發行日TextBox" runat="server" Text='<%# Bind("發行日") %>' />
            </td>
            <td>
                <asp:TextBox ID="銀行別TextBox" runat="server" Text='<%# Bind("銀行別") %>' />
            </td>
            <td>
                <asp:TextBox ID="期限TextBox" runat="server" Text='<%# Bind("期限") %>' />
            </td>
            <td>
                <asp:TextBox ID="利率TextBox" runat="server" Text='<%# Bind("利率") %>' />
            </td>
            <td>
                <asp:TextBox ID="利息TextBox" runat="server" Text='<%# Bind("利息") %>' />
            </td>
            <td>
                <asp:TextBox ID="兌換率TextBox" runat="server" Text='<%# Bind("兌換率") %>' />
            </td>
            <td>
                <asp:TextBox ID="新台幣金額TextBox" runat="server" Text='<%# Bind("新台幣金額") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Label ID="到期日Label" runat="server" Text='<%# Eval("到期日") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="信用狀編號Label" runat="server" Text='<%# Eval("信用狀編號") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="單位別Label" runat="server" Text='<%# Eval("單位別") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="幣別Label" runat="server" Text='<%# Eval("幣別") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="發行日Label" runat="server" Text='<%# Eval("發行日")& showSpace(2) %>' />
            </td>
            <td>
                <asp:Label ID="銀行別Label" runat="server" Text='<%# Eval("銀行別") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="期限Label" runat="server" Text='<%# Eval("期限") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="利率Label" runat="server" Text='<%# Eval("利率") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="利息Label" runat="server" Text='<%# Eval("利息") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="兌換率Label" runat="server" Text='<%# Eval("兌換率") & showSpace(2)%>' />
            </td>
            <td>
                <asp:Label ID="新台幣金額Label" runat="server" Text='<%# Eval("新台幣金額") & showSpace(2) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server">到期日</th>
                            <th runat="server">信用狀編號</th>
                            <th runat="server">單位別</th>
                            <th runat="server">幣別</th>
                            <th runat="server">金額</th>
                            <th runat="server">發行日</th>
                            <th runat="server">銀行別</th>
                            <th runat="server">期限</th>
                            <th runat="server">利率</th>
                            <th runat="server">利息</th>
                            <th runat="server">兌換率</th>
                            <th runat="server">新台幣金額</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Label ID="到期日Label" runat="server" Text='<%# Eval("到期日") %>' />
            </td>
            <td>
                <asp:Label ID="信用狀編號Label" runat="server" Text='<%# Eval("信用狀編號") %>' />
            </td>
            <td>
                <asp:Label ID="單位別Label" runat="server" Text='<%# Eval("單位別") %>' />
            </td>
            <td>
                <asp:Label ID="幣別Label" runat="server" Text='<%# Eval("幣別") %>' />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") %>' />
            </td>
            <td>
                <asp:Label ID="發行日Label" runat="server" Text='<%# Eval("發行日") %>' />
            </td>
            <td>
                <asp:Label ID="銀行別Label" runat="server" Text='<%# Eval("銀行別") %>' />
            </td>
            <td>
                <asp:Label ID="期限Label" runat="server" Text='<%# Eval("期限") %>' />
            </td>
            <td>
                <asp:Label ID="利率Label" runat="server" Text='<%# Eval("利率") %>' />
            </td>
            <td>
                <asp:Label ID="利息Label" runat="server" Text='<%# Eval("利息") %>' />
            </td>
            <td>
                <asp:Label ID="兌換率Label" runat="server" Text='<%# Eval("兌換率") %>' />
            </td>
            <td>
                <asp:Label ID="新台幣金額Label" runat="server" Text='<%# Eval("新台幣金額") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>



