<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MessageSender.ascx.vb" Inherits="IM.MessageSender" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<a>
    <style type="text/css">
        .style1
        {
            vertical-align:top;
            font-size:20px;
        }
        .style2
        {
             text-align:right;
             vertical-align:text-top;
             font-size:20px;
       }
        .style4
        {    
            
             text-align:left;
             vertical-align:top;
             font-size:20px;
        }
        .accordionHeader
        {
             cursor:crosshair;
             color:White;
             background-color:Gray;
        }
         .accordionHeaderSelected
        {
             cursor:crosshair;
             color:White;
             background-color:Blue;
        }
   </style>
</a>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%" Height="1000px" Font-Size="20px">
    <cc1:TabPanel runat="server" ID="TabPanel1" Font-Size="20px">
    <HeaderTemplate>訊息傳送</HeaderTemplate>
    <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width:100%;font-size:20px;" >
            <tr>
            <td class="style1">訊息:
            </td>
            <td class="style1">
                <asp:Label ID="lbMsg" runat="server" ForeColor="#FF3300" Width="680px"></asp:Label>
            </td>
            </tr>
            <tr>
                <td class="style1" rowspan="2">
                
                <cc1:Accordion ID="Accordion1" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected" SuppressHeaderPostbacks="true">
                <Panes>
                <cc1:AccordionPane ID="AccordionPane1" runat="server" HeaderCssClass="accordionHeader" >
                <Header>訊息傳送</Header>
                <Content>
                    <asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ldsMessage" 
                        PageSize="20" Width="250px">
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                SortExpression="ID" Visible="False"  ItemStyle-Font-Size="20" >
                                <ItemStyle Font-Size="20pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MsgText" HeaderText="訊息名稱" 
                                SortExpression="MsgText" />
                        </Columns>
                        <SelectedRowStyle BackColor="#CCFFFF" VerticalAlign="Top" />
                    </asp:GridView>
                </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane2" runat="server">
                <Header>爐號選擇加入</Header>
                <Content>
                    <asp:Button ID="btnReshAddStoveNumber" runat="server" Text="更新最新爐號" />
                    
                    <asp:GridView ID="GridView3" runat="server" 
                    AutoGenerateColumns="False" 
                    DataSourceID="ldsSelectStoveNumber" DataKeyNames="爐號,站別,序號,日期">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="爐號" HeaderText="爐號" 
                                SortExpression="爐號" ReadOnly="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="ldsSelectStoveNumber" runat="server" 
                        ContextTypeName="CompanyLINQDB.SMPDataContext" 
                        TableName="分析資料">
                    </asp:LinqDataSource>                    
                   
                </Content>
                </cc1:AccordionPane>
                </Panes>
                </cc1:Accordion>                
                
                
                </td>
                <td class="style1">
                    <asp:Button ID="btnSendMsg" runat="server" Text="訊息發送" Width="200px"  Height="42px"
                        Enabled="False" Font-Size="20pt" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        ConfirmText="是否確定發送?" TargetControlID="btnSendMsg" Enabled="True">
                    </cc1:ConfirmButtonExtender>
                </td>
            </tr>
            <tr>
                <td  class="style2">
                    <table style="width: 500px;font-size:20px;">
                         <tr>
                            <td class="style4">
                                發送名稱:<br />
                             </td>
                            <td>
                                <asp:TextBox ID="tbMsgName" runat="server" Width="680px" Font-Size="20pt" 
                                    Height="32px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;附加訊息:<br />
                            </td>
                            <td>
                                <asp:TextBox ID="tbAddMessage" runat="server" Width="680px" 
                                    Font-Size="20pt" TextMode="MultiLine" Height="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="lbReceiverState" runat="server" BackColor="#CCFF99" Text="接收者清單"></asp:Label>
                                :<br />
                                <asp:Button ID="btnReSendMessage" runat="server" Enabled="False" Height="80px" 
                                    Text="未接收重新通知" Width="120px" />
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="tbPrepareReceiverUsers" runat="server" BorderStyle="Dotted" 
                                    Height="250px" ReadOnly="True" TextMode="MultiLine" Width="680px" 
                                    BorderWidth="2px" ForeColor="Blue" Font-Size="14px"></asp:TextBox>
                            </td>
                        </tr>
                   </table>
                </td>
            </tr>
        </table>
        <asp:LinqDataSource ID="ldsMessage" runat="server" 
            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="Message">
        </asp:LinqDataSource>
        
        <asp:HiddenField ID="hfInsertStoveNumberControl" runat="server" />
        
        </ContentTemplate>
        </asp:UpdatePanel>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" Font-Size="20" >
    <HeaderTemplate>傳送訊息狀態查詢</HeaderTemplate>
     <ContentTemplate>
        <style type="text/css">
        .style1
        {
            font-size:20px;
            width: 250px;
        }
        </style>

         <table style="width:100%;">
             <tr>
                 <td class="style1">
                     訊息名稱:</td>
                 <td>
                     <asp:TextBox ID="tbMsg" runat="server" Width="200px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     發送者電腦:</td>
                 <td>
                     <asp:DropDownList ID="ddlSenderPC" runat="server" Width="300px" 
                         DataSourceID="ldsSenderPC" DataTextField="PCIPAndMemo1" 
                         DataValueField="ClientIP">
                     </asp:DropDownList>
                     <asp:LinqDataSource ID="ldsSenderPC" runat="server" 
                         ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                         TableName="WebClientPCAccount">
                     </asp:LinqDataSource>
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     發送者Window登入名稱:</td>
                 <td>
                     <asp:DropDownList ID="ddlSenderWindowsLogin" runat="server" Width="300px" 
                         DataSourceID="ldsSenderWindowLoginUser" DataTextField="WindowLoginNameAndMemo1" 
                         DataValueField="WindowLoginName">
                     </asp:DropDownList>
                     <asp:LinqDataSource ID="ldsSenderWindowLoginUser" runat="server" 
                         ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                         TableName="WebLoginAccount">
                     </asp:LinqDataSource>
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     接收者電腦:</td>
                 <td>
                     <asp:DropDownList ID="ddlRecieverPC" runat="server" Width="300px" 
                         DataSourceID="ldsSenderPC0" DataTextField="PCIPAndMemo1" 
                         DataValueField="ClientIP">
                     </asp:DropDownList>
                     <asp:LinqDataSource ID="ldsSenderPC0" runat="server" 
                         ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                         TableName="WebClientPCAccount">
                     </asp:LinqDataSource>
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     接收者Window登入名稱:</td>
                 <td>
                     <asp:DropDownList ID="ddlReceiverWindowsLogin" runat="server" Width="300px" 
                         DataSourceID="ldsSenderWindowLoginUser0" 
                         DataTextField="WindowLoginNameAndMemo1" DataValueField="WindowLoginName">
                     </asp:DropDownList>
                     <asp:LinqDataSource ID="ldsSenderWindowLoginUser0" runat="server" 
                         ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                         TableName="WebLoginAccount">
                     </asp:LinqDataSource>
                 </td>
             </tr>
             
             
             
             <tr>
                <td class="style1">發送時間:</td>
                <td>
                    <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>~
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="tbStartDate" Format="yyyy/MM/dd" Enabled="True" >
                    </cc1:CalendarExtender>
                    <asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="tbEndDate" Format="yyyy/MM/dd" Enabled="True" >
                    </cc1:CalendarExtender>
                </td>
             </tr>
             <tr>
                <td class="style1">使用者是否已確認</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                        <asp:ListItem Value="TRUE">已確認</asp:ListItem>
                        <asp:ListItem Value="FALSE">未確認</asp:ListItem>
                    </asp:RadioButtonList>
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
         <asp:GridView ID="GridView2" runat="server" 
             AutoGenerateColumns="False" 
             DataKeyNames="FK_MessageID,FK_ToSiteID,FK_ToSiteUsersID,FromClientIP,SendTime" 
             DataSourceID="ldsSearchResult">
             <Columns>
                 <asp:BoundField DataField="MsgText" HeaderText="訊息名稱" 
                     SortExpression="MsgText" />
                 <asp:BoundField DataField="AddMsgContent" HeaderText="附加訊息內容" 
                     SortExpression="AddMsgContent" />
                 <asp:BoundField DataField="SendTime" HeaderText="傳送時間" ReadOnly="True" 
                     SortExpression="SendTime" />
                 <asp:CheckBoxField DataField="IsReceived" HeaderText="是否已確認" 
                     SortExpression="IsReceived" />
                 <asp:TemplateField HeaderText="確認時間" SortExpression="ReceiveTime">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReceiveTime") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReceiveTime") %>' Visible='<%# Bind("IsReceived") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:CheckBoxField DataField="IsHaveNotSendReplye" HeaderText="未接收是否回應發送者" 
                     SortExpression="IsHaveNotSendReplye" />
                 <asp:TemplateField HeaderText="未接收回應發送者時間" SortExpression="NotSendReplyTime">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" 
                             Text='<%# Bind("NotSendReplyTime") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("NotSendReplyTime") %>' Visible='<%# Bind("IsHaveNotSendReplye") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="SenderInformation" HeaderText="發送者資訊" 
                     SortExpression="SenderInformation" />
                 <asp:BoundField DataField="ReceiverInformation" HeaderText="接收者資訊" 
                     SortExpression="ReceiverInformation" />
             </Columns>
         </asp:GridView>
         <asp:LinqDataSource ID="ldsSearchResult" runat="server" 
             ContextTypeName="CompanyLINQDB.IMDataContext" TableName="MessageToSiteUsers">
         </asp:LinqDataSource>
    </ContentTemplate>
   </cc1:TabPanel>
</cc1:TabContainer>

<%--    <asp:GridView ID="GridView3" runat="server" 
    AutoGenerateColumns="False" 
    DataSourceID="ldsSelectStoveNumber" DataKeyNames="爐號,站別,序號,日期">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="爐號" HeaderText="爐號" 
                SortExpression="爐號" ReadOnly="True" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="ldsSelectStoveNumber" runat="server" 
        ContextTypeName="CompanyLINQDB.SMPDataContext" 
        TableName="分析資料">
    </asp:LinqDataSource>--%>