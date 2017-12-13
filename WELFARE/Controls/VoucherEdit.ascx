<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VoucherEdit.ascx.vb" Inherits="WELFARE.VoucherEdit" %>
<style type="text/css">

    .auto-style1 {
        width: 96px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>傳票編號:</td>
        <td>
            <asp:TextBox ID="tbVoucherNumber" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" Text="傳票日期:" /></td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">摘要:</td>
        <td>
            <asp:TextBox ID="tbAccMemos" runat="server" Width="250px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" InsertItemPosition="LastItem" DataKeyNames="傳票編號">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  style="visibility:hidden"  OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="傳票別Label" runat="server" Text='<%# Eval("傳票別") %>' />
            </td>
            <td>
                <asp:Label ID="傳票日期Label" runat="server" Text='<%# Eval("傳票日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳日期Label" runat="server" Text='<%# Eval("入帳日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳編號Label" runat="server" Text='<%# Eval("入帳編號") %>' />
            </td>
            <td>
                <asp:Label ID="摘要Label" runat="server" Text='<%# Eval("摘要") %>' />
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
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Bind("傳票編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="傳票別TextBox" runat="server" Text='<%# Bind("傳票別") %>' />
            </td>
            <td>
                <asp:TextBox ID="傳票日期TextBox" runat="server" Text='<%# Bind("傳票日期") %>' />
            </td>
            <td>
                <asp:TextBox ID="入帳日期TextBox" runat="server" Text='<%# Bind("入帳日期") %>' />
            </td>
            <td>
                <asp:TextBox ID="入帳編號TextBox" runat="server" Text='<%# Bind("入帳編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="摘要TextBox" runat="server" Text='<%# Bind("摘要") %>' />
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
        <tr style="visibility:hidden" >
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="傳票編號TextBox" runat="server" Text='<%# Bind("傳票編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="傳票別TextBox" runat="server" Text='<%# Bind("傳票別") %>' />
            </td>
            <td>
                <asp:TextBox ID="傳票日期TextBox" runat="server" Text='<%# Bind("傳票日期") %>' />
            </td>
            <td>
                <asp:TextBox ID="入帳日期TextBox" runat="server" Text='<%# Bind("入帳日期") %>' />
            </td>
            <td>
                <asp:TextBox ID="入帳編號TextBox" runat="server" Text='<%# Bind("入帳編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="摘要TextBox" runat="server" Text='<%# Bind("摘要") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  style="visibility:hidden"  OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="傳票別Label" runat="server" Text='<%# Eval("傳票別") %>' />
            </td>
            <td>
                <asp:Label ID="傳票日期Label" runat="server" Text='<%# Eval("傳票日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳日期Label" runat="server" Text='<%# Eval("入帳日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳編號Label" runat="server" Text='<%# Eval("入帳編號") %>' />
            </td>
            <td>
                <asp:Label ID="摘要Label" runat="server" Text='<%# Eval("摘要") %>' />
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
                            <th runat="server">傳票編號</th>
                            <th runat="server">傳票別</th>
                            <th runat="server">傳票日期</th>
                            <th runat="server">入帳日期</th>
                            <th runat="server">入帳編號</th>
                            <th runat="server">摘要</th>
                          </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server"  PageSize="30">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"  />
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
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="傳票別Label" runat="server" Text='<%# Eval("傳票別") %>' />
            </td>
            <td>
                <asp:Label ID="傳票日期Label" runat="server" Text='<%# Eval("傳票日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳日期Label" runat="server" Text='<%# Eval("入帳日期") %>' />
            </td>
            <td>
                <asp:Label ID="入帳編號Label" runat="server" Text='<%# Eval("入帳編號") %>' />
            </td>
            <td>
                <asp:Label ID="摘要Label" runat="server" Text='<%# Eval("摘要") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="WELFARE.VoucherEdit" DataObjectTypeName="CompanyORMDB.SQLServer.WELFARE.傳票" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />



