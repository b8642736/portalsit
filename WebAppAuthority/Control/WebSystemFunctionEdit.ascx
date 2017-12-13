<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebSystemFunctionEdit.ascx.vb" Inherits="WebAppAuthority.WebSystemFunctionEdit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<link href="Common.css" rel="stylesheet" type="text/css" />

<table style="WIDTH: 496px; HEIGHT: 72px">
    <tr>
        <td align="right" class="TableLeftText" >
            系統:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        DataSourceID="LDSWebSystem" DataTextField="SystemName" 
                        DataValueField="SystemCode" 
                        Width="150px">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LDSWebSystem" runat="server" 
                        ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                        Select="new (SystemName, SystemCode)" TableName="WebSystem">
                    </asp:LinqDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="right" class="TableLeftText" >
            功能:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" 
                        DataSourceID="LDSWebSystemFunction" DataTextField="FunctionName" 
                        DataValueField="FunctionCode" 
                        Width="150px">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LDSWebSystemFunction" runat="server" 
                        ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                        Select="new (FunctionName, FunctionCode)" TableName="WebSystemFunction">
                    </asp:LinqDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="TableLeftText">
            功能名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearchField" runat="server" Text="清除" Width="96px" />
        </td>
    </tr>
    <tr>
        <td class="TableLeftText">
            功能描述:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebSystemFunction" EnableDelete="True" EnableInsert="True" 
    EnableUpdate="True">
</asp:LinqDataSource>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
    DataKeyNames="FunctionCode,SystemCode" DataSourceID="LDSSearchResult" 
    Height="136px" Width="500px" HorizontalAlign="Left">
    <PagerSettings Position="Top" />
    <EditItemTemplate>
        功能代碼:
        <asp:Label ID="FunctionCodeLabel1" runat="server" 
            Text='<%# Eval("FunctionCode") %>'></asp:Label>
        <br />
        系統代碼:
        <asp:Label ID="SystemCodeLabel1" runat="server" 
            Text='<%# Eval("SystemCode") %>'></asp:Label>
        <br />
        功能名稱:
        <asp:TextBox ID="FunctionNameTextBox" runat="server" 
            Text='<%# Bind("FunctionName") %>'></asp:TextBox>
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
        功能代碼:
        <asp:TextBox ID="FunctionCodeTextBox" runat="server" 
            Text='<%# Bind("FunctionCode") %>'></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="FunctionCodeTextBox" ErrorMessage="CustomValidator" 
            OnServerValidate="CustomValidator1_ServerValidate">錯誤:系統代碼+功能代碼 重覆!</asp:CustomValidator>
        <br />
        系統代碼:
        <asp:DropDownList ID="DropDownList3" runat="server" 
            DataSourceID="LDSSysCodeForInsert" DataTextField="SystemName" 
            DataValueField="SystemCode" SelectedValue='<%# BIND("SystemCode") %>' 
            Width="150px">
        </asp:DropDownList>
        <asp:LinqDataSource ID="LDSSysCodeForInsert" runat="server" 
            ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
            Select="new (SystemCode, SystemName)" TableName="WebSystem">
        </asp:LinqDataSource>
        <br />
        功能名稱:
        <asp:TextBox ID="FunctionNameTextBox0" runat="server" 
            Text='<%# Bind("FunctionName") %>'></asp:TextBox>
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
        功能代碼:
        <asp:Label ID="FunctionCodeLabel" runat="server" 
            Text='<%# Eval("FunctionCode") %>'></asp:Label>
        <br />
        系統代碼:
        <asp:Label ID="SystemCodeLabel" runat="server" Text='<%# Eval("SystemCode") %>'></asp:Label>
        <br />
        功能名稱:
        <asp:Label ID="FunctionNameLabel" runat="server" 
            Text='<%# Bind("FunctionName") %>'></asp:Label>
        <br />
        描述:
        <asp:Label ID="DescriptionLabel" runat="server" 
            Text='<%# Bind("Description") %>'></asp:Label>
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
            CommandName="Edit" Text="編輯"></asp:LinkButton>
        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
            CommandName="Delete" Text="刪除"></asp:LinkButton>
        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
            CommandName="New" Text="新增"></asp:LinkButton>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
            ConfirmText="是否確定要刪除此筆資料!" TargetControlID="DeleteButton">
        </cc1:ConfirmButtonExtender>
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="btnInsertRecord" runat="server" OnClick="btnInsertRecord_Click" 
            Text="新增一筆資料" />
    </EmptyDataTemplate>
</asp:FormView>
