<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MessageBoardEdit.ascx.vb" Inherits="OtherOperator.MessageBoardEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        height: 22px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">啟始時間:</span></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                TargetControlID="TextBox1">
            </cc1:CalendarExtender>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">終止時間:</span></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                TargetControlID="TextBox2">
            </cc1:CalendarExtender>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            <span lang="zh-tw">訊息內容:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td class="style1">
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" />
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSMessageBoard" runat="server" 
    ContextTypeName="CompanyLINQDB.OtherOperatorDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="MessageBoard">
</asp:LinqDataSource>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="ID" DataSourceID="LDSMessageBoard" Height="148px" Width="556px">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        <span lang="zh-tw">訊息內容</span>:
        <asp:TextBox ID="MessageContentTextBox" runat="server" 
            Text='<%# Bind("MessageContent") %>' />
        <br />
        <span lang="zh-tw">顯示順序</span>:
        <asp:TextBox ID="DisplayOrderTextBox" runat="server" 
            Text='<%# Bind("DisplayOrder") %>' />
        <br />
        <span lang="zh-tw">啟始時間</span>:
        <asp:TextBox ID="StartDateTimeTextBox" runat="server" 
            Text='<%# Bind("StartDateTime") %>' />
        <br />
        <span lang="zh-tw">結束時間</span>:
        <asp:TextBox ID="EndDateTimeTextBox" runat="server" 
            Text='<%# Bind("EndDateTime") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
            CommandName="Update" Text="更新" />
&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" 
            CommandName="Cancel" Text="取消" />
    </EditItemTemplate>
    <InsertItemTemplate>
        <span lang="zh-tw">訊息內容</span>:
        <asp:TextBox ID="MessageContentTextBox" runat="server" 
            Text='<%# Bind("MessageContent") %>' />
        <br />
        <span lang="zh-tw">顯示順序</span>:
        <asp:TextBox ID="DisplayOrderTextBox" runat="server" 
            Text='<%# Bind("DisplayOrder") %>' />
        <br />
        <span lang="zh-tw">始始時間</span>:
        <asp:TextBox ID="StartDateTimeTextBox" runat="server" 
            Text='<%# Bind("StartDateTime") %>' />
        <br />
        <span lang="zh-tw">結束時間</span>:
        <asp:TextBox ID="EndDateTimeTextBox" runat="server" 
            Text='<%# Bind("EndDateTime") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </InsertItemTemplate>
    <ItemTemplate>
        <span lang="zh-tw">訊息內容</span>:
        <asp:Label ID="MessageContentLabel" runat="server" 
            Text='<%# Bind("MessageContent") %>' />
        <br />
        <span lang="zh-tw">顯示順序</span>:
        <asp:Label ID="DisplayOrderLabel" runat="server" 
            Text='<%# Bind("DisplayOrder") %>' />
        <br />
        <span lang="zh-tw">啟始時間</span>:
        <asp:Label ID="StartDateTimeLabel" runat="server" 
            Text='<%# Bind("StartDateTime") %>' />
        <br />
        <span lang="zh-tw">結束時間</span>:
        <asp:Label ID="EndDateTimeLabel" runat="server" 
            Text='<%# Bind("EndDateTime") %>' />
        <br />
        <span lang="zh-tw">存</span><span lang="zh-tw">檔時間</span>:
        <asp:Label ID="DataSaveDateTeimeLabel" runat="server" 
            Text='<%# Bind("DataSaveDateTeime") %>' />
        <br />
        <span lang="zh-tw">存檔使用者</span>:
        <asp:Label ID="DataSaveUserLabel" runat="server" 
            Text='<%# Bind("DataSaveUser") %>' />
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
            CommandName="Edit" Text="編輯" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
            CommandName="Delete" Text="刪除" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
            CommandName="New" Text="新增" />
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="btnNew" runat="server" onclick="btnNew_Click" Text="新增" />
    </EmptyDataTemplate>
</asp:FormView>
