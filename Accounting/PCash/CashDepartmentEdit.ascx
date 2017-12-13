<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CashDepartmentEdit.ascx.vb" Inherits="Accounting.CashDepartmentEdit" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="DepCode" 
    DataSourceID="LDSSearchResult" InsertItemPosition="LastItem">
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="DepCodeLabel" runat="server" Text='<%# Eval("DepCode") %>' />
            </td>
            <td>
                <asp:Label ID="DepNameLabel" runat="server" Text='<%# Eval("DepName") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="DepCodeLabel" runat="server" Text='<%# Eval("DepCode") %>' />
            </td>
            <td>
                <asp:Label ID="DepNameLabel" runat="server" Text='<%# Eval("DepName") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" 
            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>
                    未傳回資料。</td>
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
                <asp:TextBox ID="DepCodeTextBox" runat="server" Text='<%# Bind("DepCode") %>' />
            </td>
            <td>
                <asp:TextBox ID="DepNameTextBox" runat="server" Text='<%# Bind("DepName") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th runat="server">
                            </th>
                            <th runat="server">
                                單位代碼</th>
                            <th runat="server">
                                單位名稱</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="DepCodeLabel1" runat="server" Text='<%# Eval("DepCode") %>' />
            </td>
            <td>
                <asp:TextBox ID="DepNameTextBox" runat="server" Text='<%# Bind("DepName") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="DepCodeLabel" runat="server" Text='<%# Eval("DepCode") %>' />
            </td>
            <td>
                <asp:Label ID="DepNameLabel" runat="server" Text='<%# Eval("DepName") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="LDSSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.PCashDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" OrderBy="DepCode" TableName="PCash4">
</asp:LinqDataSource>
