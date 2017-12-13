<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MainSubAssetEdit.ascx.vb" Inherits="AST500LB.MainSubAssetEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  
    Width="100%">
    <cc1:TabPanel runat="server"  ID="TabPanel1">
    <HeaderTemplate>主/備品設備關聯查詢及刪除</HeaderTemplate>
    <ContentTemplate>
        <style type="text/css">
            .style1
            {
                width: 128px;
            }
        </style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    主設備資產編號:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    備品設備資產編號:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>

                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="107px" />
                            <asp:Button ID="btnSearchClear" runat="server" Text="清除查詢條件" Width="107px" />
                        </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult" DataKeyNames="Number">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="是否確定刪除?" >
                        </cc1:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MASTER" HeaderText="主設備編號" SortExpression="MASTER" />
                <asp:BoundField DataField="MasterAssetName" HeaderText="主設備名稱" ReadOnly="True" 
                    SortExpression="MasterAssetName" />
                <asp:BoundField DataField="NUMBER" HeaderText="備品編號" SortExpression="NUMBER" />
                <asp:BoundField DataField="SubAssetName" HeaderText="備品名稱" ReadOnly="True" 
                    SortExpression="SubAssetName" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="AST500LB.MainSubAssetEdit" 
            DataObjectTypeName="CompanyORMDB.AST500LB.AST107PF" DeleteMethod="Delete">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="MasterAsset" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBox2" Name="SubAsset" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="TabPanel2">
    <HeaderTemplate>主/備品設備關聯新增</HeaderTemplate>
    <ContentTemplate>
        <style type="text/css">
            .style1
            {
                width: 139px;
            }
             .style2
            {
                width: 50%;
            }
       </style>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                   主設備資產編號:
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style1">
                   備品設備資產編號:
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="style1" />
                <td>
                    <asp:Button ID="btnSearch1" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnSearch1Clear" runat="server" Text="清除查詢條件" Width="100px" />
               </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    主設備/備品設備 加入配對:
                </td>
                <td>
                    <asp:Button ID="btnAddMatch" runat="server" Text="新增關聯配對" Enabled="False" 
                        Width="100px"  />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        TargetControlID="btnAddMatch" ConfirmText="是否確定新增關聯配對?" >
                    </cc1:ConfirmButtonExtender>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    訊息:
                </td>
                <td>
                    <asp:Label ID="lbMessage" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    主設備選擇:
                </td>
                <td>
                    備品設備選擇:</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="odsMatchSearch1" AllowPaging="True" DataKeyNames="Number">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                        CommandName="Select" Text="選取" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NUMBER" HeaderText="資產編號" SortExpression="NUMBER" />
                            <asp:BoundField DataField="NAME" HeaderText="資產名稱" SortExpression="NAME" />
                        </Columns>
                        <SelectedRowStyle BackColor="#CCFFFF" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsMatchSearch1" runat="server" 
                        SelectMethod="MatchSearch1" TypeName="AST500LB.MainSubAssetEdit" 
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox3" Name="MasterAsset" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" DataSourceID="odsMatchSearch2" 
                        DataKeyNames="Number">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                        CommandName="Select" Text="選取" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NUMBER" HeaderText="資產編號" SortExpression="NUMBER" />
                            <asp:BoundField DataField="NAME" HeaderText="資產名稱" SortExpression="NAME" />
                        </Columns>
                        <SelectedRowStyle BackColor="#CCFFFF" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsMatchSearch2" runat="server" 
                        SelectMethod="MatchSearch2" TypeName="AST500LB.MainSubAssetEdit" 
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox4" Name="SubAsset" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
              </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>        
        
    </ContentTemplate>
   </cc1:TabPanel>
</cc1:TabContainer>

