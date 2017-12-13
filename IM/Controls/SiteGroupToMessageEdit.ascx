<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SiteGroupToMessageEdit.ascx.vb" Inherits="IM.SiteGroupToMessageEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
    
    <style type="text/css">
        .style1
        {
            width: 74px;
        }
    </style>
    <table style="width:100%;">
    <tr>
        <td class="style1">
            群組名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            訊息文字:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>


<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%">
    <cc1:TabPanel runat="server" ID="TabPanel1">
    <HeaderTemplate>將訊息加入群組</HeaderTemplate>
    <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        站台群組選擇</td>
                    <td>
                        &nbsp;
                        訊息選擇</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="ID" DataSourceID="ldsSearchResult1" AllowPaging="True">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                    SortExpression="ID" />
                                <asp:BoundField DataField="GroupName" HeaderText="群組名稱" 
                                    SortExpression="GroupName" />
                            </Columns>
                            <SelectedRowStyle BackColor="#99FFCC" />
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSearchResult1" runat="server" 
                            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="SiteGroup">
                        </asp:LinqDataSource>
                    </td>
                    <td>
                        &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="ID" DataSourceID="ldsSearchResult2" AllowPaging="True">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                    SortExpression="ID" />
                                <asp:BoundField DataField="MsgText" HeaderText="訊息文字" 
                                    SortExpression="MsgText" />
                            </Columns>
                            <SelectedRowStyle BackColor="#99FFCC" />
                        </asp:GridView>
                        <asp:LinqDataSource ID="ldsSearchResult2" runat="server" 
                            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="Message">
                        </asp:LinqDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        群組對訊息的權限:<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Selected="True" Value="0">可發送與接收</asp:ListItem>
                            <asp:ListItem Value="1">只可發送</asp:ListItem>
                            <asp:ListItem Value="2">只可接收</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="將訊息加入群組" Enabled="False" />
                        <br />
                        訊息:<br />
                        <asp:Label ID="lbMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>    
        </ContentTemplate>
        </asp:UpdatePanel>
    
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server">
    <HeaderTemplate>將訊息自群組中移除</HeaderTemplate>
    <ContentTemplate>
    
    
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="FK_SiteGroupID,FK_MessageID" 
            DataSourceID="ldsSearchResult">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button1" ConfirmText="是否確定刪除?" >
                        </cc1:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SiteGroup_GroupName" HeaderText="群組名稱" 
                    SortExpression="SiteGroup_GroupName" />
                <asp:BoundField DataField="AboutMessage_MsgText" HeaderText="傳送訊息" 
                    SortExpression="AboutMessage_MsgText" />
                <asp:BoundField DataField="ReadWriteModeString" HeaderText="傳送接收模式" 
                    SortExpression="ReadWriteModeString" />
                <asp:BoundField DataField="FK_SiteGroupID" HeaderText="站台群組ID" ReadOnly="True" 
                    SortExpression="FK_SiteGroupID" />
                <asp:BoundField DataField="FK_MessageID" HeaderText="訊息ID" ReadOnly="True" 
                    SortExpression="FK_MessageID" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="ldsSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.IMDataContext" EnableDelete="True" 
            TableName="SiteGroupToMessage">
        </asp:LinqDataSource>
    
    
    </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>

