<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MessageEdit.ascx.vb" Inherits="IM.MessageEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 127px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            訊息ID:</td>
        <td>
            <asp:TextBox ID="tbMessageID" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="style1">
            訊息:</td>
        <td>
            <asp:TextBox ID="tbMessageString" runat="server"></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
    DataSourceID="ldsSearchResult" InsertItemPosition="LastItem">

    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" runat="server">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="MsgTextLabel" runat="server" Text='<%# Eval("MsgText") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveFinalRecieveTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveFinalRecieveTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FinalRecieveTimeSpanLabel" runat="server" 
                    Text='<%# Eval("FinalRecieveMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveNotSendReplyTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveNotSendReplyTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="NotSendReplyTimeSpanLabel" runat="server" 
                    Text='<%# Eval("NotSendReplyMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNeedSendEmailCheckBox" runat="server" 
                    Checked='<%# Eval("IsNeedSendEmail") %>' Enabled="false" />
            </td>
            <%--<td>
                <asp:Label ID="MessageToFilesLabel" runat="server" 
                    Text='<%# Eval("MessageToFiles") %>' />
            </td>--%>
             <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
          </tr>
    </ItemTemplate>
    <AlternatingItemTemplate >
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" runat="server">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="MsgTextLabel" runat="server" Text='<%# Eval("MsgText") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveFinalRecieveTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveFinalRecieveTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FinalRecieveTimeSpanLabel" runat="server" 
                    Text='<%# Eval("FinalRecieveMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveNotSendReplyTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveNotSendReplyTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="NotSendReplyTimeSpanLabel" runat="server" 
                    Text='<%# Eval("NotSendReplyMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNeedSendEmailCheckBox" runat="server" 
                    Checked='<%# Eval("IsNeedSendEmail") %>' Enabled="false" />
            </td>
            <%--<td>
                <asp:Label ID="MessageToFilesLabel" runat="server" 
                    Text='<%# Eval("MessageToFiles") %>' />
            </td>--%>
             <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="MsgTextTextBox" runat="server" Text='<%# Bind("MsgText") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveFinalRecieveTimeCheckBox" runat="server" 
                    Checked='<%# Bind("IsHaveFinalRecieveTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="FinalRecieveTimeSpanTextBox" runat="server" 
                    Text='<%# Bind("FinalRecieveMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveNotSendReplyTimeCheckBox" runat="server" 
                    Checked='<%# Bind("IsHaveNotSendReplyTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="NotSendReplyTimeSpanTextBox" runat="server" 
                    Text='<%# Bind("NotSendReplyMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNeedSendEmailCheckBox" runat="server" 
                    Checked='<%# Bind("IsNeedSendEmail") %>' />
            </td>
            <%--<td>
                <asp:TextBox ID="MessageToFilesTextBox" runat="server" 
                    Text='<%# Bind("MessageToFiles") %>' />
            </td>--%>
            <td>
                <%--<asp:Label ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />--%>
                <asp:Label ID="IDTextBox" runat="server" Text='自動' />
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table id="Table1" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr id="Tr2" runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th id="Th1" runat="server">
                            </th>
                            <th id="Th2" runat="server">
                                訊息文字</th>
                            <th id="Th3" runat="server">
                                是否有接收限制時間</th>
                            <th id="Th4" runat="server">
                                等待接收限制分鐘數</th>
                            <th id="Th5" runat="server">
                                是否回應未接收訊息</th>
                            <th id="Th6" runat="server">
                                回應未接收等待分鐘數</th>
                            <th id="Th7" runat="server">
                                是否送Mail給站台使用者</th>
                            <%--<th runat="server">
                                MessageToFiles</th>--%>
                             <th id="Th8" runat="server">
                                訊息ID</th>
                       </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td id="Td2" runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
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
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="MsgTextTextBox" runat="server" Text='<%# Bind("MsgText") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveFinalRecieveTimeCheckBox" runat="server" 
                    Checked='<%# Bind("IsHaveFinalRecieveTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="FinalRecieveTimeSpanTextBox" runat="server" 
                    Text='<%# Bind("FinalRecieveMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveNotSendReplyTimeCheckBox" runat="server" 
                    Checked='<%# Bind("IsHaveNotSendReplyTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="NotSendReplyTimeSpanTextBox" runat="server" 
                    Text='<%# Bind("NotSendReplyMinuteSpan") %>' />
           </td>
            <td>
                <asp:CheckBox ID="IsNeedSendEmailCheckBox" runat="server" 
                    Checked='<%# Bind("IsNeedSendEmail") %>' />
            </td>
            <%--<td>
                <asp:TextBox ID="MessageToFilesTextBox" runat="server" 
                    Text='<%# Bind("MessageToFiles") %>' />
            </td>--%>
            <td>
                <asp:Label ID="IDLabel1" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
            </td>
         </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" runat="server">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                <asp:Label ID="MsgTextLabel" runat="server" Text='<%# Eval("MsgText") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveFinalRecieveTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveFinalRecieveTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FinalRecieveTimeSpanLabel" runat="server" 
                    Text='<%# Eval("FinalRecieveMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsHaveNotSendReplyTimeCheckBox" runat="server" 
                    Checked='<%# Eval("IsHaveNotSendReplyTime") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="NotSendReplyTimeSpanLabel" runat="server" 
                    Text='<%# Eval("NotSendReplyMinuteSpan") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNeedSendEmailCheckBox" runat="server" 
                    Checked='<%# Eval("IsNeedSendEmail") %>' Enabled="false" />
            </td>
            <%--<td>
                <asp:Label ID="MessageToFilesLabel" runat="server" 
                    Text='<%# Eval("MessageToFiles") %>' />
            </td>--%>
        </tr>
    </SelectedItemTemplate>

</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.IMDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="Message">
</asp:LinqDataSource>



