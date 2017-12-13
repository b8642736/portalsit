<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserEdit.ascx.vb" Inherits="WebAppAuthority.WebUserEdit" %>
<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">登入帳號:</span></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw"><span lang="zh-tw">顯示名稱</span>:</span></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="100px" />
        </td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">備註1</span></td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" Width="100px" />
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSWebLoginAccount" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebLoginAccount" EnableDelete="True" EnableInsert="True" 
    EnableUpdate="True">
</asp:LinqDataSource>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="WindowLoginName" DataSourceID="LDSWebLoginAccount" Height="134px" 
    Width="405px">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        <span lang="zh-tw">登入帳號</span>:
        <asp:Label ID="WindowLoginNameLabel1" runat="server" 
            Text='<%# Eval("WindowLoginName") %>' />
        <br />
        <span lang="zh-tw">顯示名稱</span>:
        <asp:TextBox ID="DisplayNameTextBox" runat="server" 
            Text='<%# Bind("DisplayName") %>' />
        <br />
        Email:<asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' 
            Width="200px"></asp:TextBox>
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
        <span lang="zh-tw">登入帳號</span>:
        <asp:TextBox ID="WindowLoginNameTextBox" runat="server" 
            Text='<%# Bind("WindowLoginName") %>' />
        <br />
        <span lang="zh-tw">顯示名稱</span>:
        <asp:TextBox ID="DisplayNameTextBox" runat="server" 
            Text='<%# Bind("DisplayName") %>' />
        <br />
        Email:<asp:TextBox ID="EmailTextBox" runat="server"  
            Text='<%# Bind("Email") %>' Width="200px"></asp:TextBox>
        <br />
        <span lang="zh-tw">備註1</span>:
        <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="WindowLoginNameTextBox" 
            onservervalidate="CustomValidator1_ServerValidate1"></asp:CustomValidator>
    </InsertItemTemplate>
    <ItemTemplate>
        <span lang="zh-tw">登入帳號</span>:
        <asp:Label ID="WindowLoginNameLabel" runat="server" 
            Text='<%# Eval("WindowLoginName") %>' />
        <br />
        <span lang="zh-tw">顯示名稱</span>:
        <asp:Label ID="DisplayNameLabel" runat="server" 
            Text='<%# Bind("DisplayName") %>' />
        <br />
        Email:<asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
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
        <asp:Button ID="btnInsert" runat="server" Height="21px" 
            onclick="btnInsert_Click" Text="新增" Width="104px" />
    </EmptyDataTemplate>
</asp:FormView>

