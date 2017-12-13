<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebGroupEdit.ascx.vb" Inherits="WebAppAuthority.WebGroupEdit" %>
<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">群組代碼:</span></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">群組名稱:</span></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">備註1:</span></td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" Width="100px" />
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="100px" />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="GroupCode" DataSourceID="LDSEditDataSource" Width="80%">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        <span lang="zh-tw">群組代碼</span>:
        <asp:Label ID="GroupCodeLabel1" runat="server" 
            Text='<%# Eval("GroupCode") %>' />
        <br />
        <span lang="zh-tw">群組名稱</span>:
        <asp:TextBox ID="GroupNameTextBox" runat="server" 
            Text='<%# Bind("GroupName") %>' />
        <br />
        <span lang="zh-tw">備註1</span>:
        <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
            CommandName="Update" Text="更新" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </EditItemTemplate>
    <InsertItemTemplate>
        <span lang="zh-tw">群組代碼</span>:
        <asp:TextBox ID="GroupCodeTextBox" runat="server" 
            Text='<%# Bind("GroupCode") %>' />
        <br />
        <span lang="zh-tw">群組名稱</span>:
        <asp:TextBox ID="GroupNameTextBox" runat="server" 
            Text='<%# Bind("GroupName") %>' />
        <br />
        <span lang="zh-tw">備註1</span>:
        <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </InsertItemTemplate>
    <ItemTemplate>
        <span lang="zh-tw">群組代碼</span>:
        <asp:Label ID="GroupCodeLabel" runat="server" Text='<%# Eval("GroupCode") %>' />
        <br />
        <span lang="zh-tw">群組名稱</span>:
        <asp:Label ID="GroupNameLabel" runat="server" Text='<%# Bind("GroupName") %>' />
        <br />
        <span lang="zh-tw">備註1</span>:
        <asp:Label ID="Memo1Label" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
            CommandName="Edit" Text="編輯" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
            CommandName="Delete" Text="刪除" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
            CommandName="New" Text="新增" />
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="btnInsertNewData" runat="server" Height="22px" Text="新增一筆資料" 
            Width="139px" onclick="btnInsertNewData_Click" />
    </EmptyDataTemplate>
</asp:FormView>
<asp:LinqDataSource ID="LDSEditDataSource" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="WebGroupAccount">
</asp:LinqDataSource>

