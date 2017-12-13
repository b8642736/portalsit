<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RepairEdit.ascx.vb" Inherits="MIS.RepairEdit" %>
<style type="text/css">
    .auto-style1 {
        width: 109px;
        text-align:right;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="申請日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">維修項目:</td>
        <td>
            <asp:TextBox ID="tbRepareItem" runat="server" Width="213px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">處理結果:</td>
        <td>
            <asp:TextBox ID="tbProcessResult" runat="server" Width="213px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">申請人或工號:</td>
        <td>
            <asp:TextBox ID="tbApplyEmplyee" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>


<p>
    <br />
</p>


<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ID" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="RepareItem" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ApplyTime" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ProcessResult" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="FinishTime" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ProcessEmployee" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ApplyEmplyee" Mode="ReadOnly" />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="RepareItemTextBox" runat="server" Text='<%# Bind("RepareItem") %>' />
            </td>
            <td>
                <asp:TextBox ID="ApplyTimeTextBox" runat="server" Text='<%# Bind("ApplyTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="ProcessResultTextBox" runat="server" Text='<%# Bind("ProcessResult") %>' />
            </td>
            <td>
                <asp:TextBox ID="FinishTimeTextBox" runat="server" Text='<%# Bind("FinishTime") %>' />
            </td>
            <td>
                <%--<asp:TextBox ID="ProcessEmployeeTextBox" runat="server" Text='<%# Bind("ProcessEmployee") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="曾金寶" Value="12147"></asp:ListItem>
                    <asp:ListItem Text="林漢墩" Value="32050"></asp:ListItem>
                    <asp:ListItem Text="葉青彬" Value="30168"></asp:ListItem>
                    <asp:ListItem Text="涂文宏" Value="31139"></asp:ListItem>
                    <asp:ListItem Text="丁坤道" Value="31128"></asp:ListItem>
                    <asp:ListItem Text="古政剛" Value="30276"></asp:ListItem>
                    <asp:ListItem Text="陳仁欣" Value="30305"></asp:ListItem>
                    <asp:ListItem Text="竇振娟" Value="32591"></asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="ApplyEmplyeeTextBox" runat="server" Text='<%# Bind("ApplyEmplyee") %>' />
            </td>

        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="RepareItemTextBox" runat="server" Text='<%# Bind("RepareItem") %>' />
            </td>
            <td>
                <asp:TextBox ID="ApplyTimeTextBox" runat="server" Text='<%# Bind("ApplyTime") %>' />
            </td>
            <td>
                <asp:TextBox ID="ProcessResultTextBox" runat="server" Text='<%# Bind("ProcessResult") %>' />
            </td>
            <td>
                <asp:TextBox ID="FinishTimeTextBox" runat="server" Text='<%# Bind("FinishTime") %>' />
            </td>
            <td>
               <%-- <asp:TextBox ID="ProcessEmployeeTextBox" runat="server" Text='<%# Bind("ProcessEmployee") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="曾金寶" Value="12147"></asp:ListItem>
                    <asp:ListItem Text="林漢墩" Value="32050"></asp:ListItem>
                    <asp:ListItem Text="葉青彬" Value="30168"></asp:ListItem>
                    <asp:ListItem Text="涂文宏" Value="31139"></asp:ListItem>
                    <asp:ListItem Text="丁坤道" Value="31128"></asp:ListItem>
                    <asp:ListItem Text="古政剛" Value="30276"></asp:ListItem>
                    <asp:ListItem Text="陳仁欣" Value="30305"></asp:ListItem>
                    <asp:ListItem Text="竇振娟" Value="32591"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="ApplyEmplyeeTextBox" runat="server" Text='<%# Bind("ApplyEmplyee") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ID" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="RepareItem" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ApplyTime" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ProcessResult" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="FinishTime" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ProcessEmployee" Mode="ReadOnly" />
            </td>
            <td>
                <asp:DynamicControl runat="server" DataField="ApplyEmplyee" Mode="ReadOnly" />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">案件編號</th>
                            <th runat="server">維修項目</th>
                            <th runat="server">申請時間</th>
                            <th runat="server">處理結果</th>
                            <th runat="server">完成時間</th>
                            <th runat="server">處理人</th>
                            <th runat="server">申請人或工號</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="RepareItemLabel" runat="server" Text='<%# Eval("RepareItem") %>' />
            </td>
            <td>
                <asp:Label ID="ApplyTimeLabel" runat="server" Text='<%# Eval("ApplyTime") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessResultLabel" runat="server" Text='<%# Eval("ProcessResult") %>' />
            </td>
            <td>
                <asp:Label ID="FinishTimeLabel" runat="server" Text='<%# Eval("FinishTime") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessEmployeeLabel" runat="server" Text='<%# Eval("ProcessEmployee") %>' />
            </td>
            <td>
                <asp:Label ID="ApplyEmplyeeLabel" runat="server" Text='<%# Eval("ApplyEmplyee") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>





<asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.MIS.RepairRecord" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="MIS.RepairEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfQryString" runat="server" />










