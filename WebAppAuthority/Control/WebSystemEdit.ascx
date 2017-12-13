<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebSystemEdit.ascx.vb" Inherits="WebAppAuthority.WebSystemEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<table style="WIDTH: 504px; HEIGHT: 88px">
    <tr>
        <td style="WIDTH: 104px">
            系統代碼</td>
        <td style="WIDTH: 194px">
            <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 104px">
            系統名稱</td>
        <td style="WIDTH: 194px">
            <asp:TextBox ID="TextBox2" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearchField" runat="server" Text="清除" Width="120px" />
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 104px">
            描述</td>
        <td style="WIDTH: 194px">
            <asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="120px" />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="SystemCode" DataSourceID="LDSWebAPPAuthorityDataSource" 
    Height="72px" Width="240px">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        系統代碼:
        <asp:Label ID="SystemCodeLabel1" runat="server" 
            Text='<%# Eval("SystemCode") %>'></asp:Label>
        <br />
        系統名稱:
        <asp:TextBox ID="SystemNameTextBox" runat="server" 
            Text='<%# Bind("SystemName") %>'></asp:TextBox>
        <br />
        描述:
        <asp:TextBox ID="DescriptionTextBox" runat="server" 
            Text='<%# Bind("Description") %>'></asp:TextBox>
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
            CommandName="Update" Text="更新"></asp:LinkButton>
        <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" 
            CommandName="Cancel" Text="取消"></asp:LinkButton>
    </EditItemTemplate>
    <InsertItemTemplate>
        系統代碼:
        <asp:TextBox ID="SystemCodeTextBox" runat="server" 
            Text='<%# Bind("SystemCode") %>'></asp:TextBox>
        <br />
        系統名稱:
        <asp:TextBox ID="SystemNameTextBox0" runat="server" 
            Text='<%# Bind("SystemName") %>'></asp:TextBox>
        <br />
        描述:
        <asp:TextBox ID="DescriptionTextBox0" runat="server" 
            Text='<%# Bind("Description") %>'></asp:TextBox>
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入"></asp:LinkButton>
        <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" 
            CommandName="Cancel" Text="取消"></asp:LinkButton>
    </InsertItemTemplate>
    <ItemTemplate>
        系統代碼:
        <asp:Label ID="SystemCodeLabel" runat="server" Text='<%# Eval("SystemCode") %>'></asp:Label>
        <br />
        系統名稱:
        <asp:Label ID="SystemNameLabel" runat="server" Text='<%# Bind("SystemName") %>'></asp:Label>
        <br />
        描述:
        <asp:Label ID="DescriptionLabel" runat="server" 
            Text='<%# Bind("Description") %>'></asp:Label>
        <br />
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="btnInsertSystem" runat="server" OnClick="btnInsertSystem_Click" 
            Text="新增系統" />
    </EmptyDataTemplate>
    <HeaderTemplate>
        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="新增" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="修改" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
            ConfirmText="是否確定要刪除此筆資料!" TargetControlID="btnDelete">
        </cc1:ConfirmButtonExtender>
    </HeaderTemplate>
</asp:FormView>
<asp:LinqDataSource ID="LDSWebAPPAuthorityDataSource" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="WebSystem">
    <SelectParameters>
        <asp:Parameter Name="SetSystemCode" />
        <asp:Parameter Name="SetSystemName" />
        <asp:Parameter Name="SetDescription" />
    </SelectParameters>
</asp:LinqDataSource>
