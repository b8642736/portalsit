<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FileShared.ascx.vb" Inherits="OtherOperator.FileShared" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
    DataSourceID="ldsSearchResult" InsertItemPosition="LastItem" >
    <ItemTemplate>
        <tr style="background-color: #E0FFFF;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:HyperLink ID="HLDownLoad" runat="server" ToolTip='<%# Eval("ID") %>'>下載</asp:HyperLink>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText ="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
                 <asp:HiddenField ID="HFID" runat="server" Value='<%# Eval("ID") %>' />
           </td>
            <td>
                <asp:Label ID="DescriptLabel" runat="server" Text='<%# Eval("Descript") %>' />
            </td>
            <td>
                <asp:Label ID="FileNameLabel" runat="server" Text='<%# Eval("FileName") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UploadTime") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("UploadUser") %>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("UploadPCIP") %>' />
            </td>
            <td>
                <asp:Label ID="SaveFileFullPathLabel1" runat="server" Text="無權觀看!"></asp:Label>
                <asp:Label ID="SaveFileFullPathLabel" runat="server" 
                    Text='<%# Eval("SaveFileFullPath") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color: #FFFFFF;color: #284775;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:HyperLink ID="HLDownLoad" runat="server" ToolTip='<%# Eval("ID") %>'>下載</asp:HyperLink>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText ="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
                <asp:HiddenField ID="HFID" runat="server" Value='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptLabel" runat="server" Text='<%# Eval("Descript") %>' />
            </td>
            <td>
                <asp:Label ID="FileNameLabel" runat="server" Text='<%# Eval("FileName") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UploadTime") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("UploadUser") %>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("UploadPCIP") %>' />
            </td>
            <td>
                <asp:Label ID="SaveFileFullPathLabel1" runat="server" Text="無權觀看!"></asp:Label>
                <asp:Label ID="SaveFileFullPathLabel" runat="server" 
                    Text='<%# Eval("SaveFileFullPath") %>' />
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
                <asp:TextBox ID="DescriptTextBox" runat="server" Text='<%# Bind("Descript") %>' />
            </td>
            <td colspan="5" >上傳檔案:<asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server" width="2000">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                            <th runat="server">
                            </th>
                            <th runat="server">
                                描述</th>
                            <th runat="server">
                                檔名</th>
                             <th id="Th1" runat="server">
                                上傳時間</th>
                            <th id="Th2" runat="server">
                                上傳Window帳號</th>
                            <th id="Th3" runat="server">
                                上傳電腦IP</th>
                           <th runat="server">
                                存檔路徑</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
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
        <tr style="background-color: #999999;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                 <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
           </td>
            <td>
                <asp:TextBox ID="DescriptTextBox" runat="server" 
                    Text='<%# Bind("Descript") %>' />
            </td>
            <td colspan="5" >更新檔案(不更新無需輸入):<asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
            </td>
            <td>
                <asp:Label ID="DescriptLabel" runat="server" Text='<%# Eval("Descript") %>' />
            </td>
            <td>
                <asp:Label ID="FileNameLabel" runat="server" Text='<%# Eval("FileName") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UploadTime") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("UploadUser") %>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("UploadPCIP") %>' />
            </td>
            <td>
                <asp:Label ID="SaveFileFullPathLabel" runat="server" 
                    Text='<%# Eval("SaveFileFullPath") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.OtherOperatorDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="FileSharedRecord">
</asp:LinqDataSource>
