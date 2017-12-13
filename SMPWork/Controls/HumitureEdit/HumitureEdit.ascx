<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HumitureEdit.ascx.vb" Inherits="SMPWork.HumitureEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 84px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="期間:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="SaveDateTime" 
    DataSourceID="ldsSearchResult" EnableModelValidation="True" 
    InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color: #FAFAD2;color: #284775;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server" 
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="TempertureLabel" runat="server" 
                    Text='<%# Eval("Temperture") %>' />
            </td>
            <td>
                <asp:Label ID="HumidityLabel" runat="server" Text='<%# Eval("Humidity") %>' />%
            </td>
            <td>
                <asp:Label ID="DataDateTimeLabel" runat="server" 
                    Text='<%# Eval("DataDateTime") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #FFCC66;color: #000080;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("SaveDateTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="TempertureTextBox" runat="server" 
                    Text='<%# Bind("Temperture") %>' />
            </td>
            <td>
                <asp:TextBox ID="HumidityTextBox" runat="server" 
                    Text='<%# Bind("Humidity") %>' />%
            </td>
            <td>
                <asp:HiddenField ID="HFDataDateTime" runat="server" Value='<%# Bind("DataDateTime") %>' />
                <asp:TextBox ID="DataDateTextBox" Width="100" runat="server"/>日<asp:TextBox ID="DataHourTextBox" Width="20" runat="server"/>時<asp:TextBox ID="DataMinuteTextBox" Width="20" runat="server"/>分
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="DataDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" 
            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>
                    未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                <asp:HiddenField ID="HFSaveDateTime" runat="server" Value='<%# Bind("SaveDateTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="TempertureTextBox" runat="server" 
                    Text='<%# Bind("Temperture") %>' />
            </td>
            <td>
                <asp:TextBox ID="HumidityTextBox" runat="server" 
                    Text='<%# Bind("Humidity") %>' />%
            </td>
            <td>
                <asp:HiddenField ID="HFDataDateTime" runat="server" Value='<%# Bind("DataDateTime") %>' />
                <asp:TextBox ID="DataDateTextBox" Width="100" runat="server"/>日<asp:TextBox ID="DataHourTextBox" Width="20" runat="server"/>時<asp:TextBox ID="DataMinuteTextBox" Width="20" runat="server"/>分
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="DataDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #FFFBD6;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server" 
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="TempertureLabel" runat="server" 
                    Text='<%# Eval("Temperture") %>' />
            </td>
            <td>
                <asp:Label ID="HumidityLabel" runat="server" Text='<%# Eval("Humidity") %>' />%
            </td>
            <td>
                <asp:Label ID="DataDateTimeLabel" runat="server" 
                    Text='<%# Eval("DataDateTime") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                            <th runat="server">
                            </th>
                            <th runat="server">
                                溫度</th>
                            <th runat="server">
                                濕度</th>
                            <th runat="server">
                                時間</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #FFCC66;font-weight: bold;color: #000080;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="TempertureLabel" runat="server" 
                    Text='<%# Eval("Temperture") %>' />
            </td>
            <td>
                <asp:Label ID="HumidityLabel" runat="server" Text='<%# Eval("Humidity") %>' />%
            </td>
            <td>
                <asp:Label ID="DataDateTimeLabel" runat="server" 
                    Text='<%# Eval("DataDateTime") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="溫濕度記錄">
</asp:LinqDataSource>


