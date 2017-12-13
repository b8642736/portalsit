<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebClientPCEdit.ascx.vb" Inherits="WebAppAuthority.WebClientPCEdit" %>
<table style="width:100%;">
    <tr>
        <td>
            電腦IP:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            電腦名稱:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="100px" />
        </td>
    </tr>
    <tr>
        <td>
            備註:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" Width="100px" />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="ClientIP" DataSourceID="LDSWebClientPCAccount" Height="115px" 
    Width="251px">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        電腦IP:
        <asp:Label ID="ClientIPLabel1" runat="server" Text='<%# Eval("ClientIP") %>' />
        <br />
        電腦名稱:
        <asp:TextBox ID="PCNameTextBox" runat="server" Text='<%# Bind("PCName") %>' />
        <br />
        Email:<asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' 
            Width="200px"></asp:TextBox>
        <br />
        備註1:
        <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
            CommandName="Update" Text="更新" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </EditItemTemplate>
    <InsertItemTemplate>
        電腦IP:
        <asp:TextBox ID="ClientIPTextBox" runat="server" 
            Text='<%# Bind("ClientIP") %>' />
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="ClientIPTextBox" ErrorMessage="CustomValidator" 
            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
        電腦名稱:
        <asp:TextBox ID="PCNameTextBox" runat="server" Text='<%# Bind("PCName") %>' />
        <br />
        Email:<asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' 
            Width="200px"></asp:TextBox>
        <br />
        備註1:
        <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </InsertItemTemplate>
    <ItemTemplate>
        電腦IP:
        <asp:Label ID="ClientIPLabel" runat="server" Text='<%# Eval("ClientIP") %>' />
        <br />
        電腦名稱:
        <asp:Label ID="PCNameLabel" runat="server" Text='<%# Bind("PCName") %>' />
        <br />
        Email:<asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
        <br />
        備註1:
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
        <asp:Button ID="btnNew" runat="server" onclick="btnNew_Click" Text="新增一筆資料" />
    </EmptyDataTemplate>
</asp:FormView>
<asp:LinqDataSource ID="LDSWebClientPCAccount" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="WebClientPCAccount">
</asp:LinqDataSource>
