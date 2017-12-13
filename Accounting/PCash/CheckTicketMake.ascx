<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CheckTicketMake.ascx.vb" Inherits="Accounting.CheckTicketMake" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
        <table style="width:100%;">
            <tr>
                <td>
                    年度:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server">2008</asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    號數:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server">1</asp:TextBox>
                    ~<asp:TextBox ID="TextBox3" runat="server">9999</asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    是否已兌現:</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal" Width="233px">
                        <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">已兌現</asp:ListItem>
                        <asp:ListItem Value="2">未兌現</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    支票查詢:</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:LinqDataSource ID="LDSSearchReslut" runat="server" 
            ContextTypeName="CompanyLINQDB.PCashDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" TableName="PCash2">
        </asp:LinqDataSource>
        
        <asp:FormView ID="FormView2" runat="server" AllowPaging="True" 
    DataKeyNames="RecDate,Number" DataSourceID="LDSSearchReslut" 
Width="100%">
            <PagerSettings PageButtonCount="30" Position="Top" />
            <EditItemTemplate>
                日期時間:
                <asp:Label ID="RecDateLabel1" runat="server" Text='<%# Eval("RecDate") %>' />
                <br />
                號數:
                <asp:Label ID="NumberLabel1" runat="server" Text='<%# Eval("Number") %>' />
                <br />
                支票編號:
                <asp:TextBox ID="TicketNumberTextBox" runat="server" 
            Text='<%# Bind("TicketNumber") %>' />
                <br />
                是否兌現:<asp:CheckBox ID="IsToCashedCheckBox" runat="server" 
            Checked='<%# Bind("IsToCashed") %>' 
                    oncheckedchanged="IsToCashedCheckBox_CheckedChanged1" />
                <br />
                兌現時間:
                <asp:TextBox ID="ToCashDateTimeTextBox" runat="server" 
            Text='<%# Bind("ToCashDateTime", "{0:d}") %>' />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="ToCashDateTimeTextBox">
                </cc1:CalendarExtender>
                <br />
                是否為起始支票:
                <asp:CheckBox ID="IsNewYearStartTicketCheckBox" runat="server" 
            Checked='<%# Bind("IsNewYearStartTicket") %>' 
                    oncheckedchanged="IsNewYearStartTicketCheckBox_CheckedChanged1" />
                <br />
                起始支票金額:
                <asp:TextBox ID="NewYearStartMoneyTextBox" runat="server" 
            Text='<%# Bind("NewYearStartMoney") %>' />
                <br />
                儲存時間:
                <asp:TextBox ID="SaveTimeTextBox" runat="server" 
            Text='<%# Bind("SaveTime") %>' Enabled="False" />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
            CommandName="Update" Text="更新" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <InsertItemTemplate>
                日期時間:
                <asp:TextBox ID="RecDateTextBox" runat="server" Text='<%# Bind("RecDate") %>' />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
            TargetControlID="RecDateTextBox">
                </cc1:CalendarExtender>
                <br />
                號數:
                <asp:TextBox ID="NumberTextBox" runat="server" Text='<%# Bind("Number") %>' 
            Enabled="False" />
                <br />
                支票編號:
                <asp:TextBox ID="TicketNumberTextBox" runat="server" 
            Text='<%# Bind("TicketNumber") %>' />
                <br />
                是否兌現:<asp:CheckBox ID="IsToCashedCheckBox" runat="server" 
            Checked='<%# Bind("IsToCashed") %>' 
                    oncheckedchanged="IsToCashedCheckBox_CheckedChanged" />
                <br />
                兌現時間:
                <asp:TextBox ID="ToCashDateTimeTextBox" runat="server" 
            Text='<%# Bind("ToCashDateTime") %>' />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="ToCashDateTimeTextBox">
                </cc1:CalendarExtender>
                <br />
                是否為起始支票:
                <asp:CheckBox ID="IsNewYearStartTicketCheckBox" runat="server" 
            Checked='<%# Bind("IsNewYearStartTicket") %>' 
                    oncheckedchanged="IsNewYearStartTicketCheckBox_CheckedChanged" />
                <br />
                起始支票金額:
                <asp:TextBox ID="NewYearStartMoneyTextBox" runat="server" 
            Text='<%# Bind("NewYearStartMoney") %>' />
                <br />
                儲存時間:
                <asp:TextBox ID="SaveTimeTextBox" runat="server" 
            Text='<%# Bind("SaveTime") %>' Enabled="False" />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            CommandName="Insert" Text="插入" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
            CausesValidation="False" CommandName="Cancel" Text="取消" />
            </InsertItemTemplate>
            <ItemTemplate>
                日期:
                <asp:Label ID="RecDateLabel" runat="server" 
                    Text='<%# Format(Eval("RecDate"),"yyyy/MM/dd") %>' />
                <br />
                號數:
                <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
                <br />
                支票編號:
                <asp:Label ID="TicketNumberLabel" runat="server" 
            Text='<%# Bind("TicketNumber") %>' />
                <br />
                是否已兌現:<asp:CheckBox ID="IsToCashedCheckBox" runat="server" 
            Checked='<%# Bind("IsToCashed") %>' Enabled="false" />
                <br />
                兌現時間:
                <asp:Label ID="ToCashDateTimeLabel" runat="server" 
            Text='<%# Eval("ToCashDateTime", "{0:d}") %>' />
                <br />
                是否為起始支票:
                <asp:CheckBox ID="IsNewYearStartTicketCheckBox" runat="server" 
            Checked='<%# Bind("IsNewYearStartTicket") %>' Enabled="false" />
                <br />
                起始支票金額:
                <asp:Label ID="NewYearStartMoneyLabel" runat="server" 
            Text='<%# Bind("NewYearStartMoney") %>' />
                <br />
                儲存時間:
                <asp:Label ID="SaveTimeLabel" runat="server" Text='<%# Bind("SaveTime") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
            CommandName="Edit" Text="編輯" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
            CommandName="Delete" Text="刪除" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
            CommandName="New" Text="新增" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" 
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
            </ItemTemplate>
            <EmptyDataTemplate>
                <asp:Button ID="btnInsertNew" runat="server" CommandName="New" Text="新增一筆支票" />
            </EmptyDataTemplate>
        </asp:FormView>

<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%">
            <cc1:TabPanel runat="server" HeaderText="已核銷項目" ID="TabPanel1">
                <ContentTemplate>
                    <asp:LinqDataSource ID="LDSWaitTicketToCash" runat="server" 
                ContextTypeName="CompanyLINQDB.PCashDataContext" OrderBy="Number, RecDate" 
                Select="new (Number, Descript, PutMoney, RecDate, DepCode)" TableName="PCash1">
                    </asp:LinqDataSource>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="LDSWaitTicketToCash" Width="100%" 
                        DataKeyNames="RecDate,Number">
                        <PagerSettings PageButtonCount="30" Position="Top" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" SelectText="取消核銷" 
                        ShowSelectButton="True" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:CommandField>
                            <asp:BoundField DataField="RecDate" HeaderText="日期" ReadOnly="True" 
                        SortExpression="RecDate" DataFormatString="{0:d}" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Number" HeaderText="號數" ReadOnly="True" 
                        SortExpression="Number" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descript" HeaderText="摘要" ReadOnly="True" 
                        SortExpression="Descript" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PutMoney" HeaderText="金額" ReadOnly="True" 
                        SortExpression="PutMoney" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="使用單位">
                            <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" 
                                            DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                                            DataValueField="DepCode" Enabled="False" SelectedValue='<%# Eval("DepCode") %>' 
                                            Width="150px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="待核銷項目">
            <ContentTemplate>
                <asp:LinqDataSource ID="LDSTicketToCash" runat="server" 
                    ContextTypeName="CompanyLINQDB.PCashDataContext" OrderBy="RecDate, Number" 
                    TableName="PCash1">
                </asp:LinqDataSource>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="RecDate,Number" 
                    DataSourceID="LDSTicketToCash" Width="100%">
                    <PagerSettings Position="Top" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Button" 
                            SelectText="納入核銷" ItemStyle-HorizontalAlign="Right"  />
                        <asp:BoundField DataField="RecDate" HeaderText="日期" ReadOnly="True" 
                            SortExpression="RecDate" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="Number" HeaderText="號數" ReadOnly="True" 
                            SortExpression="Number" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="Descript" HeaderText="摘要" 
                            SortExpression="Descript" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="PutMoney" HeaderText="金額" 
                            SortExpression="PutMoney" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateField HeaderText="使用單位">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" 
                                        DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                                        DataValueField="DepCode" Enabled="False" SelectedValue='<%# Eval("DepCode") %>' 
                                        Width="150px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="批次核銷項目處理">
            <ContentTemplate>
               <table style="width:100%;">
                    <tr>
                        <td>
                            日期範圍:</td>
                        <td>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" 
                                Format="yyyy/MM/dd" TargetControlID="TextBox4">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" 
                                Format="yyyy/MM/dd" TargetControlID="TextBox5">
                            </cc1:CalendarExtender>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            ~<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                ConfirmText="是否確定執行?" Enabled="True" TargetControlID="btnBatchP1">
                            </cc1:ConfirmButtonExtender>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                                ConfirmText="是否確定執行?" Enabled="True" TargetControlID="btnBatchC1">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnBatchP1" runat="server" Text="核銷" Width="100px" />
                            <asp:Button ID="btnBatchC1" runat="server" Text="取消核銷" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            號數範圍:</td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server">0</asp:TextBox>
                            ~<asp:TextBox ID="TextBox7" runat="server">9999</asp:TextBox>
                        </td>
                        <td>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                                ConfirmText="是否確定執行?" Enabled="True" TargetControlID="btnBatchP2">
                            </cc1:ConfirmButtonExtender>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" 
                                ConfirmText="是否確定執行?" Enabled="True" TargetControlID="btnBatchC2">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnBatchP2" runat="server" Text="核銷" Width="100px" />
                            <asp:Button ID="btnBatchC2" runat="server" Text="取消核銷" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            訊息:</td>
                        <td>
                            <asp:Label ID="lbMessage" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </ContentTemplate>
</asp:UpdatePanel>



<asp:LinqDataSource ID="LDSDepartmentShow" runat="server" 
    ContextTypeName="CompanyLINQDB.PCashDataContext" OrderBy="DepCode" 
    Select="new (DepCode, DepName)" TableName="PCash4">
</asp:LinqDataSource>




<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~\PCash\Jscript1.js" />
    </Scripts>
</asp:ScriptManagerProxy>





