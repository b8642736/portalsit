<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CashPayEdit.ascx.vb" Inherits="Accounting.CashPayEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<table style="width:100%;">
    <tr>
        <td>
            期間:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="Textbox1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="Textbox2">
            </cc1:CalendarExtender>
        </td>
        <td>
            &nbsp;</td>
   </tr>
    <tr>
        <td>
            號數:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            ~<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            摘要:</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Height="21px" Text="清除查詢條件" 
                Width="100px" />
            <asp:Button ID="btnInsert" runat="server" Height="21px" Text="新增模式" 
                Width="100px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="SearchResultView" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            DataSourceID="LDSSearchResult" AutoGenerateColumns="False" 
            DataKeyNames="RecDate,Number" PageSize="20">
            <PagerSettings Position="Top" PageButtonCount="30" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="編修選取" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RecDate" HeaderText="日期" ReadOnly="True" 
                    SortExpression="RecDate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Number" HeaderText="號數" ReadOnly="True" 
                    SortExpression="Number" />
                <asp:BoundField DataField="Descript" HeaderText="摘要" 
                    SortExpression="Descript" />
                <asp:BoundField DataField="PutMoney" HeaderText="金額" 
                    SortExpression="PutMoney" />
                <asp:BoundField DataField="SaveTime" HeaderText="儲存時間" 
                    SortExpression="SaveTime" />
                <asp:TemplateField HeaderText="使用單位">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                                DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                                DataValueField="DepCode" Enabled="False" SelectedValue='<%# Eval("DepCode") %>' 
                                Width="150px"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LDSSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.PCashDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" TableName="PCash1">
        </asp:LinqDataSource>
    </asp:View>
    <asp:View ID="EditView" runat="server">
        <asp:Button ID="btnReturnSearchResultView" runat="server" Text="返回查詢結果" 
            Visible="False" Width="168px" />
        <br />
        <asp:LinqDataSource ID="LDSEditData" runat="server" 
            ContextTypeName="CompanyLINQDB.PCashDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" TableName="PCash1">
        </asp:LinqDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:FormView ID="FormView2" runat="server" DataKeyNames="RecDate,Number" 
                    DataSourceID="LDSEditData" Width="359px">
                    <EditItemTemplate>
                        日期:
                        <asp:Label ID="RecDateLabel1" runat="server" Text='<%# Eval("RecDate") %>' />
                        <br />
                        號數:
                        <asp:Label ID="NumberLabel1" runat="server" Text='<%# Eval("Number") %>' />
                        <br />
                        使用單位:<asp:DropDownList ID="DropDownList3" runat="server" 
                            DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                            DataValueField="DepCode" SelectedValue='<%# Bind("DepCode") %>' Width="150px">
                        </asp:DropDownList>
                        <br />
                        摘要:
                        <asp:TextBox ID="DescriptTextBox" runat="server" 
                            Text='<%# Bind("Descript") %>' />
                        <br />
                        金額:
                        <asp:TextBox ID="PutMoneyTextBox" runat="server" 
                            Text='<%# Bind("PutMoney") %>' />
                        <br />
                        儲存時間:
                        <asp:TextBox ID="SaveTimeTextBox" runat="server" Enabled="False" 
                            Text='<%# Bind("SaveTime") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="更新" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="取消" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        日期:<asp:TextBox ID="RecDateTextBox" runat="server" AutoPostBack="True" 
                            ontextchanged="RecDateTextBox_TextChanged1" Text='<%# Bind("RecDate") %>' />
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy/MM/dd" 
                            TargetControlID="RecDateTextBox">
                        </cc1:CalendarExtender>
                        <br />
                        號數:<asp:TextBox ID="NumberTextBox" runat="server" Enabled="False" 
                            Text='<%# Bind("Number") %>' />
                        &nbsp;<br />
                        使用單位:<asp:DropDownList ID="DropDownList2" runat="server" 
                            DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                            DataValueField="DepCode" SelectedValue='<%# Bind("DepCode") %>' Width="150px">
                        </asp:DropDownList>
                        <br />
                        摘要:
                        <asp:TextBox ID="DescriptTextBox" runat="server" 
                            Text='<%# Bind("Descript") %>' />
                        <br />
                        金額:
                        <asp:TextBox ID="PutMoneyTextBox" runat="server" 
                            Text='<%# Bind("PutMoney") %>' />
                        <br />
                        儲存時間:
                        <asp:TextBox ID="SaveTimeTextBox" runat="server" Enabled="False" 
                            Text='<%# Bind("SaveTime") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="插入" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="取消" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        日期:
                        <asp:Label ID="RecDateLabel" runat="server" Text='<%# Eval("RecDate") %>' />
                        <br />
                        號數:
                        <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
                        <br />
                        使用單位:<asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="LDSDepartmentShow" DataTextField="DepName" 
                            DataValueField="DepCode" Enabled="False" SelectedValue='<%# Eval("DepCode") %>' 
                            Width="150px">
                        </asp:DropDownList>
                        <br />
                        摘要:
                        <asp:Label ID="DescriptLabel" runat="server" Text='<%# Bind("Descript") %>' />
                        <br />
                        金額:
                        <asp:Label ID="PutMoneyLabel" runat="server" Text='<%# Bind("PutMoney") %>' />
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
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                        </cc1:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:FormView>
                <asp:LinqDataSource ID="LDSDepartmentShow" runat="server" 
                    ContextTypeName="CompanyLINQDB.PCashDataContext" OrderBy="DepCode" 
                    Select="new (DepCode, DepName)" TableName="PCash4">
                </asp:LinqDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:View>
</asp:MultiView>

