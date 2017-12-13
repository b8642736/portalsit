<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SiteUserEdit.ascx.vb" Inherits="IM.SiteUserEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 149px;
    }
    .style3
    {
        width: 179px;
         vertical-align:top;
    }
    </style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            使用者(登入或顯示)名稱/電腦名稱/IP:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="169px" />
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchClear" runat="server" Text="查詢清除" Width="100px" />
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%" AutoPostBack="True">
    <cc1:TabPanel runat="server" ID="TabPanel1">
    <HeaderTemplate>已加入帳號</HeaderTemplate>
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="FK_SiteID,ID" DataSourceID="ldsSearchResult1" 
                AllowPaging="True">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                CommandName="Delete" Text="刪除" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                     ConfirmText="是否確認刪除?" TargetControlID="DeleteButton">
                                    </cc1:ConfirmButtonExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SiteName" HeaderText="站台名稱" 
                        SortExpression="SiteName" ReadOnly="True" />
                    <asp:BoundField DataField="PCNameOrUserName" HeaderText="電腦/使用者 名稱" 
                        SortExpression="PCNameOrUserName" ReadOnly="True" />
                    <asp:BoundField DataField="DefaultUseServerIP" HeaderText="預設使用Web伺服器IP" 
                        SortExpression="DefaultUseServerIP" />
                    <asp:BoundField DataField="UserPKeyKindName" HeaderText="登入鍵值種類" 
                        SortExpression="UserPKeyKindName" ReadOnly="True" />
                    <asp:BoundField DataField="UserPKey" HeaderText="登入鍵值" 
                        SortExpression="UserPKey" ReadOnly="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                        SortExpression="ID" />
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="ldsSearchResult1" runat="server" 
                ContextTypeName="CompanyLINQDB.IMDataContext" EnableDelete="True" 
                EnableInsert="True" EnableUpdate="True" TableName="SiteUser">
            </asp:LinqDataSource>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="TabPanel2">
    <HeaderTemplate>未加入使用者名稱(Window)帳號</HeaderTemplate>
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="style3" colspan ="2">設定加入時預設Web伺服器IP:<asp:TextBox ID="tbSetADDDefaultWebIP1" runat="server" Text="10.1.4.12" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style3">
                        選擇加入站台:<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="ID" DataSourceID="ldsSiteDS1" Width="200px">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                <asp:BoundField DataField="SiteName" HeaderText="站台名稱" 
                                    SortExpression="SiteName" />
                            </Columns>
                            <SelectedRowStyle BackColor="#CCFFFF" />
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSiteDS1" runat="server" 
                            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="Site">
                        </asp:LinqDataSource>
                    </td>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="ldsSearchResult2" DataKeyNames="WindowLoginName" 
                            Enabled="False">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="加入" CommandName="Select" />
                                <asp:BoundField DataField="WindowLoginName" HeaderText="Window登入名稱" 
                                    ReadOnly="True" SortExpression="WindowLoginName" />
                                <asp:BoundField DataField="DisplayName" HeaderText="顯示名稱" 
                                    SortExpression="DisplayName" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            </Columns>
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSearchResult2" runat="server" 
                            ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                            TableName="WebLoginAccount">
                        </asp:LinqDataSource>
                    </td>
                </tr>
              </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3" runat="server">
    <HeaderTemplate>未加入電腦名稱/IP帳號</HeaderTemplate>

        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="style3" colspan ="2">設定加入時預設Web伺服器IP:<asp:TextBox ID="tbSetADDDefaultWebIP2" runat="server" Text="10.1.4.12"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="style3">
                        選擇加入站台:<asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="ID" DataSourceID="ldsSiteDS" Width="200px" 
                            AllowPaging="True">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                <asp:BoundField DataField="SiteName" HeaderText="站台名稱" 
                                    SortExpression="SiteName" />
                            </Columns>
                            <SelectedRowStyle BackColor="#CCFFFF" />
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSiteDS" runat="server" 
                            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="Site">
                        </asp:LinqDataSource>
                    </td>
                    <td>
                        選擇加入Window帳號:<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="ClientIP" DataSourceID="ldsSearchResult3" Enabled="False" 
                            AllowPaging="True">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="加入" CommandName="Select" />
                                <asp:BoundField DataField="ClientIP" HeaderText="電腦IP" ReadOnly="True" 
                                    SortExpression="ClientIP" />
                                <asp:BoundField DataField="PCName" HeaderText="電腦名稱" SortExpression="PCName" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            </Columns>
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSearchResult3" runat="server" 
                            ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                            TableName="WebClientPCAccount">
                        </asp:LinqDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>

    </cc1:TabPanel>
</cc1:TabContainer>

</ContentTemplate>
</asp:UpdatePanel>
