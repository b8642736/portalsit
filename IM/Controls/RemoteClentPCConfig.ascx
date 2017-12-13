<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RemoteClentPCConfig.ascx.vb" Inherits="IM.RemoteClentPCConfig" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <style type="text/css">
            .style1
            {
                width: 122px;
            }
            .style2
            {
                width: 122px;
                height: 23px;
            }
            .style3
            {
                height: 23px;
            }
            .style4
            {
                 text-align:center;
            }
        </style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    Window登入名稱:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    電腦IP:</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnSearchClear" runat="server" Text="清除查詢條件" Width="100px" />
                    <asp:Button ID="btnSelectSet" runat="server" Text="選取設定" Width="100px" 
                        Enabled="False" />
                </td>
            </tr>
        </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="CPUNumber,RegisterClassName,Port,RemoteProtocol"
                    DataSourceID="ldsSearchResult">
                    <Columns>
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                            <HeaderTemplate>
                                <asp:Button ID="btnSelectItem" runat="server" Text="選取/反選取"  OnClick="btnSelectItem_Click" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1"  runat="server" OnCheckedChanged="CheckBox1_OnCheckedChanged" AutoPostBack="True" />
                            </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CPUNumber" HeaderText="CPU編號" ReadOnly="True" 
                            SortExpression="CPUNumber" />
                        <asp:BoundField DataField="RegisterClassName" HeaderText="系統名稱" ReadOnly="True" 
                            SortExpression="RegisterClassName" />
                        <asp:BoundField DataField="Port" HeaderText="連線Port" ReadOnly="True" 
                            SortExpression="Port" />
                        <asp:BoundField DataField="RemoteProtocol" HeaderText="連線協定" ReadOnly="True" 
                            SortExpression="RemoteProtocol" />
                        <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP" />
                        <asp:BoundField DataField="Mode" HeaderText="連線模式" SortExpression="Mode" />
                        <asp:BoundField DataField="LastRegisteredTime" HeaderText="最後登入時間" 
                            SortExpression="LastRegisteredTime" />
                        <asp:BoundField DataField="LastUnRegisteredTime" HeaderText="最後登出時間" 
                            SortExpression="LastUnRegisteredTime" />
                        <asp:BoundField DataField="WindowLoginName" HeaderText="Window登入名稱" 
                            SortExpression="WindowLoginName" />
                    </Columns>
                </asp:GridView>
        
        <asp:LinqDataSource ID="ldsSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="RemoteServer" 
            OrderBy="LastRegisteredTime desc">
        </asp:LinqDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
            <style type="text/css">
            .style4
            {
                 text-align:center;
            }
        </style>

        <asp:Button ID="btnSetAndBack" runat="server" Text="通知變更設定並返回" Width="140px" 
                Enabled="False" />
        <asp:Button ID="btnRefreshOnly" runat="server" Text="通知重整但不變更設定" Width="140px"/>
        <asp:Button ID="btnCancelAndBack" runat="server" Text="取消並返回" Width="100px" />
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                ConfirmText="是否確定變更?" TargetControlID="btnSetAndBack">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                ConfirmText="是否確定現在通知?" TargetControlID="btnRefreshOnly">
            </cc1:ConfirmButtonExtender>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    選擇變更選項</td>
                <td class="style5">
                    資料庫設定</td>
                <td>選擇變更選項</td>
                <td>線上用戶端設定</td>
            </tr>
             <tr>
                <td class="style4">
                    <asp:CheckBox ID="cbSetWebIP1" runat="server" AutoPostBack="True" 
                        Text="網頁伺服器設定" TextAlign="Left" />
                 </td>
                <td class="style5">
                    <asp:TextBox ID="tbSetDefaultWebServerIP1" runat="server" style="width: 148px">10.1.4.12</asp:TextBox>
                 </td>
                <td>
                    <asp:CheckBox ID="cbSetWebIP2" runat="server" Text="網頁伺服器設定" TextAlign="Left" 
                        AutoPostBack="True" />
                 </td>
                <td>
                    <asp:TextBox ID="tbSetDefaultWebServerIP2" runat="server">10.1.4.12</asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbSetAuthority2" runat="server" Text="授權方式" 
                        TextAlign="Left" AutoPostBack="True" />
                 </td>
                <td>
                    <asp:RadioButtonList ID="rblSetAuthority2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="2">Window登入授權</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">本機IP授權</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
            </tr>
       </table>
    </asp:View>
</asp:MultiView>


