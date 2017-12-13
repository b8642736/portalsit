<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StandardSampleCS_InstrReceiveEdit.ascx.vb" Inherits="SMP.StandardSampleCS_InstrReceiveEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 150px;
    }

    .auto-style3
    {
        width: 150px;
        height: 26px;
    }

    .auto-style4
    {
        height: 26px;
    }
</style>

<p></p>
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
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td>
            <asp:CheckBox ID="chkTopData" runat="server" Text="各時段取前幾筆資料" Checked="true" />
            &nbsp;<asp:TextBox ID="tbTopDataNum" runat="server" Width="43px">2</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">查驗樣品</td>
        <td>
            <asp:TextBox ID="tbFK_SampleNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">分析程式</td>
        <td>
            <asp:TextBox ID="tbMethod" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="34px" Width="123px" />
            <asp:HiddenField ID="hfQryString" runat="server" />
            <asp:HiddenField ID="hfTopDataNum" runat="server" />
            <asp:HiddenField ID="hfSearchDate" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料CS_儀器匯入" SelectMethod="Search" TypeName="SMP.StandardSampleCS_InstrReceiveEdit" UpdateMethod="CDBUpdate" DeleteMethod="CDBDelete">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfTopDataNum" Name="fromTopDataNum" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSearchDate" Name="fromSearchDate" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>



<asp:ListView ID="ListView1" runat="server" DataKeyNames="SampleID,日期時間" DataSourceID="odsSearchResult">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf重量" runat="server" Value='<%# Eval("重量") %>' />
                <asp:HiddenField ID="hf匯入日期時間" runat="server" Value='<%# Eval("匯入日期時間") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method")%>' />
            </td>
            <td>
                <asp:Label ID="SampleIDLabel" runat="server" Text='<%# Eval("SampleID") %>' />
            </td>


            <td>
                <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
            </td>
            <td>
                <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
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
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Bind("日期時間")%>' />
                <asp:HiddenField ID="hf重量" runat="server" Value='<%# Bind("重量") %>' />
                <asp:HiddenField ID="hf匯入日期時間" runat="server" Value='<%# Bind("匯入日期時間") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Bind("Method")%>' />
            </td>
            <td>
                <asp:Label ID="SampleIDLabel" runat="server" Text='<%# Bind("SampleID")%>' />
            </td>

            <td>
                <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
            </td>
            <td>
                <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
            </td>

        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td></td>
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
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf重量" runat="server" Value='<%# Eval("重量") %>' />
                <asp:HiddenField ID="hf匯入日期時間" runat="server" Value='<%# Eval("匯入日期時間") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method")%>' />
            </td>
            <td>
                <asp:Label ID="SampleIDLabel" runat="server" Text='<%# Eval("SampleID")%>' />
            </td>


            <td>
                <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
            </td>
            <td>
                <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
            </td>

        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>


            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf重量" runat="server" Value='<%# Eval("重量") %>' />
                <asp:HiddenField ID="hf匯入日期時間" runat="server" Value='<%# Eval("匯入日期時間") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method")%>' />
            </td>
            <td>
                <asp:Label ID="SampleIDLabel" runat="server" Text='<%# Eval("SampleID") %>' />
            </td>


            <td>
                <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
            </td>
            <td>
                <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="Table2" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr id="Tr2" runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th id="Th1" runat="server"></th>

                            <th id="Th2" runat="server">日期</th>
                            <th id="Th3" runat="server">班別</th>

                            <th id="Th11" runat="server">分析程式</th>
                            <th id="Th12" runat="server">查驗樣品</th>

                            <th id="Th6" runat="server">C</th>
                            <th id="Th7" runat="server">S</th>


                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td id="Td2" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf重量" runat="server" Value='<%# Eval("重量") %>' />
                <asp:HiddenField ID="hf匯入日期時間" runat="server" Value='<%# Eval("匯入日期時間") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='' />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method")%>' />
            </td>
            <td>
                <asp:Label ID="SampleIDLabel" runat="server" Text='<%# Eval("SampleID") %>' />
            </td>

            <td>
                <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
            </td>
            <td>
                <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>






