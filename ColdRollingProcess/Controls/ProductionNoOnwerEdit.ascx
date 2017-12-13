<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductionNoOnwerEdit.ascx.vb" Inherits="ColdRollingProcess.ProductionNoOnwerEdit" %>

<style type="text/css">
    .styleTableEdit {
        width: 90%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
    }

    .styleTableEdit_TD {
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
        /*width: 30%;*/
        text-align: left;
        padding: 7px;
    }

    .ListView1_TD0 {
        width: 70px;
        height: 30px;
        padding-left: 5px;
    }

    .ListView1_TD1 {
        width: 100px;
        padding-left: 5px;
    }

    .ListView1_TD2 {
        width: 200px;
        padding-left: 5px;
    }
</style>

<p />
<table class="styleTableEdit">
    <tr>
        <td class="styleTableEdit_TD ">無主管理：</td>
        <td class="styleTableEdit_TD ">
            <asp:DropDownList ID="ddNoOnwerStatus" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="styleTableEdit_TD ">鋼種：</td>
        <td class="styleTableEdit_TD ">
            <asp:TextBox ID="tbCIA05" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="  (兩個以上請以','分隔)"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="styleTableEdit_TD">表面：</td>
        <td class="styleTableEdit_TD">
            <asp:TextBox ID="tbCIA06" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="  (兩個以上請以','分隔)"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="styleTableEdit_TD ">鋼捲號碼：</td>
        <td class="styleTableEdit_TD ">
            <asp:TextBox ID="tbCIA02_03" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="  (兩個以上請以','分隔)"></asp:Label>
        </td>
    </tr>

    <tr>
        <td class="styleTableEdit_TD ">&nbsp;</td>
        <td class="styleTableEdit_TD ">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="48px" Width="168px" />&nbsp;<asp:HiddenField ID="hfSQL" runat="server" />
            <asp:ObjectDataSource ID="ods" runat="server" DataObjectTypeName="CompanyORMDB.PPS100LB.PPSCIAPF" SelectMethod="Search" TypeName="ColdRollingProcess.ProductionNoOnwerEdit" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>



<p />
<asp:ListView ID="ListView1" runat="server" DataSourceID="ods" EnableModelValidation="True" DataKeyNames="CIA02,CIA03,CIA54,CIA55">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td class="ListView1_TD0">
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Enabled='<%# FB_ShowNoOnwer_Flag(Eval("CIA50")) %>' />
            </td>

            <td class="ListView1_TD1">
                <asp:Label ID="CIA02Label" runat="server" Text='<%# String.Concat(Eval("CIA02"), Eval("CIA03"))%>' />
            </td>


            <td class="ListView1_TD1">
                <asp:Label ID="CIA05Label" runat="server" Text='<%# Eval("CIA05") %>' />
            </td>
            <td class="ListView1_TD0">
                <asp:Label ID="CIA06Label" runat="server" Text='<%# Eval("CIA06") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA07Label" runat="server" Text='<%# Eval("CIA07") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA08Label" runat="server" Text='<%# Eval("CIA08") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA09Label" runat="server" Text='<%# Eval("CIA09") %>' />
            </td>
            <td class="ListView1_TD0">
                <asp:Label ID="CIA16Label" runat="server" Text='<%# Eval("CIA16") %>' />
            </td>

            <td class="ListView1_TD2">
                <asp:Label ID="CIA50Label" runat="server" Text='<%# FS_ShowNoOnwer(Eval("CIA50"))%>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA58Label" runat="server" Text='<%# Eval("CIA58") %>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <asp:HiddenField ID="CIA02HiddenField" runat="server" Value='<%# Bind("CIA02") %>' />
                <asp:HiddenField ID="CIA03HiddenField" runat="server" Value='<%# Bind("CIA03") %>' />
                <asp:HiddenField ID="CIA54HiddenField" runat="server" Value='<%# Bind("CIA54") %>' />
                <asp:HiddenField ID="CIA55HiddenField" runat="server" Value='<%# Bind("CIA55") %>' />
            </td>

            <td>
                <asp:Label ID="CIA02Label" runat="server" Text='<%# String.Concat(Eval("CIA02"), Eval("CIA03"))%>' />
            </td>


            <td>
                <asp:Label ID="CIA05Label" runat="server" Text='<%# Bind("CIA05") %>' />
            </td>
            <td>
                <asp:Label ID="CIA06Label" runat="server" Text='<%# Bind("CIA06") %>' />
            </td>
            <td>
                <asp:Label ID="CIA07Label" runat="server" Text='<%# Bind("CIA07") %>' />
            </td>
            <td>
                <asp:Label ID="CIA08Label" runat="server" Text='<%# Bind("CIA08") %>' />
            </td>
            <td>
                <asp:Label ID="CIA09Label" runat="server" Text='<%# Bind("CIA09") %>' />
            </td>
            <td>
                <asp:Label ID="CIA16Label" runat="server" Text='<%# Bind("CIA16") %>' />
            </td>

            <td>
                <asp:HiddenField ID="CIA50HiddenField" runat="server" Value='<%# Bind("CIA50")%>' />
                <asp:DropDownList ID="CIA50DropDownList" runat="server" />
            </td>
            <td>
                <asp:Label ID="CIA58Label" runat="server" Text='<%# Bind("CIA58") %>' />
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

    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td class="ListView1_TD0">
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Enabled='<%# FB_ShowNoOnwer_Flag(Eval("CIA50")) %>' />
            </td>

            <td class="ListView1_TD1">
                <asp:Label ID="CIA02Label" runat="server" Text='<%# String.Concat(Eval("CIA02"), Eval("CIA03"))%>' />
            </td>


            <td class="ListView1_TD1">
                <asp:Label ID="CIA05Label" runat="server" Text='<%# Eval("CIA05") %>' />
            </td>
            <td class="ListView1_TD0">
                <asp:Label ID="CIA06Label" runat="server" Text='<%# Eval("CIA06") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA07Label" runat="server" Text='<%# Eval("CIA07") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA08Label" runat="server" Text='<%# Eval("CIA08") %>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA09Label" runat="server" Text='<%# Eval("CIA09") %>' />
            </td>
            <td class="ListView1_TD0">
                <asp:Label ID="CIA16Label" runat="server" Text='<%# Eval("CIA16") %>' />
            </td>

            <td class="ListView1_TD2 ">
                <asp:Label ID="CIA50Label" runat="server" Text='<%# FS_ShowNoOnwer(Eval("CIA50"))%>' />
            </td>
            <td class="ListView1_TD1">
                <asp:Label ID="CIA58Label" runat="server" Text='<%# Eval("CIA58") %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;height :40px;">
                            <th runat="server"></th>

                            <th runat="server">鋼捲號碼</th>

                            <th runat="server">鋼種</th>
                            <th runat="server">表面</th>
                            <th runat="server">厚度</th>
                            <th runat="server">寬度</th>
                            <th runat="server">長度</th>
                            <th runat="server">等級</th>

                            <th runat="server">無主管理註記</th>
                            <th runat="server">會計日期</th>

                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
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
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Enabled='<%# FB_ShowNoOnwer_Flag(Eval("CIA50")) %>' />
            </td>

            <td>
                <asp:Label ID="CIA02Label" runat="server" Text='<%# String.Concat(Eval("CIA02"), Eval("CIA03"))%>' />
            </td>

            <td>
                <asp:Label ID="CIA05Label" runat="server" Text='<%# Eval("CIA05") %>' />
            </td>
            <td>
                <asp:Label ID="CIA06Label" runat="server" Text='<%# Eval("CIA06") %>' />
            </td>
            <td>
                <asp:Label ID="CIA07Label" runat="server" Text='<%# Eval("CIA07") %>' />
            </td>
            <td>
                <asp:Label ID="CIA08Label" runat="server" Text='<%# Eval("CIA08") %>' />
            </td>
            <td>
                <asp:Label ID="CIA09Label" runat="server" Text='<%# Eval("CIA09") %>' />
            </td>
            <td>
                <asp:Label ID="CIA16Label" runat="server" Text='<%# Eval("CIA16") %>' />
            </td>

            <td>
                <asp:Label ID="CIA50Label" runat="server" Text='<%# FS_ShowNoOnwer(Eval("CIA50"))%>' />
            </td>
            <td>
                <asp:Label ID="CIA58Label" runat="server" Text='<%# Eval("CIA58") %>' />
            </td>

        </tr>
    </SelectedItemTemplate>
</asp:ListView>



