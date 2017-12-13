<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VoucherDetailEdit.ascx.vb" Inherits="WELFARE.VoucherDetailEdit" %>
<table style="width:100%;">
    <tr>
        <td>傳票編號:</td>
        <td>
            <asp:TextBox ID="tbVoucherNumber" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">會計科目:</td>
        <td>
            <asp:TextBox ID="tbAccItem" runat="server"></asp:TextBox>
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
<asp:ListView ID="ListView1" runat="server" DataKeyNames="傳票編號,序號" DataSourceID="odsSearchResult" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick="javascript:return confirm('是否確定刪除?');"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="會計科目Label" runat="server" Text='<%# Eval("會計科目") %>' />
            </td>
            <td>
                <asp:Label ID="科目別Label" runat="server" Text='<%# Eval("科目別") %>'  />
            </td>
            <td>
                <asp:Label ID="款項目Label" runat="server" Text='<%# Eval("款項目") %>' />
            </td>
            <td>
                <asp:Label ID="明細項Label" runat="server" Text='<%# Eval("明細項") %>' />
            </td>
            <td>
                <asp:Label ID="借貸別Label" runat="server" Text='<%# Eval("借貸別") %>'  />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") %>' />
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
                <asp:TextBox ID="序號TextBox" runat="server" Text='<%# Bind("序號") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="會計科目TextBox" runat="server" Text='<%# Bind("會計科目") %>' Width="80px" />
            </td>
            <td>
                <asp:TextBox ID="科目別TextBox" runat="server" Text='<%# Bind("科目別") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="款項目TextBox" runat="server" Text='<%# Bind("款項目") %>' Width="60px"  />
            </td>
            <td>
                <asp:TextBox ID="明細項TextBox" runat="server" Text='<%# Bind("明細項") %>' />
            </td>
            <td>
                <asp:TextBox ID="借貸別TextBox" runat="server" Text='<%# Bind("借貸別") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="金額TextBox" runat="server" Text='<%# Bind("金額") %>' Width="100px" />
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
        <tr style="visibility:hidden;">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="傳票編號TextBox" runat="server" Text='<%# Bind("傳票編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="序號TextBox" runat="server" Text='<%# Bind("序號") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="會計科目TextBox" runat="server" Text='<%# Bind("會計科目") %>' Width="80px"  />
            </td>
            <td>
                <asp:TextBox ID="科目別TextBox" runat="server" Text='<%# Bind("科目別") %>' Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="款項目TextBox" runat="server" Text='<%# Bind("款項目") %>' Width="60px"  />
            </td>
            <td>
                <asp:TextBox ID="明細項TextBox" runat="server" Text='<%# Bind("明細項") %>' />
            </td>
            <td>
                <asp:TextBox ID="借貸別TextBox" runat="server" Text='<%# Bind("借貸別") %>' Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="金額TextBox" runat="server" Text='<%# Bind("金額") %>'  Width="100px"  />
            </td>
            <td>
                <asp:TextBox ID="摘要TextBox" runat="server" Text='<%# Bind("摘要") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"   OnClientClick="javascript:return confirm('是否確定刪除?');"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="會計科目Label" runat="server" Text='<%# Eval("會計科目") %>' />
            </td>
            <td>
                <asp:Label ID="科目別Label" runat="server" Text='<%# Eval("科目別") %>' />
            </td>
            <td>
                <asp:Label ID="款項目Label" runat="server" Text='<%# Eval("款項目") %>' />
            </td>
            <td>
                <asp:Label ID="明細項Label" runat="server" Text='<%# Eval("明細項") %>' />
            </td>
            <td>
                <asp:Label ID="借貸別Label" runat="server" Text='<%# Eval("借貸別") %>' />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") %>' />
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
                            <th runat="server">序號</th>
                            <th runat="server">會計科目</th>
                            <th runat="server">科目別</th>
                            <th runat="server">款項目</th>
                            <th runat="server">明細項</th>
                            <th runat="server">借貸別</th>
                            <th runat="server">金額</th>
                            <th runat="server">摘要</th>
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
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="傳票編號Label" runat="server" Text='<%# Eval("傳票編號") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="會計科目Label" runat="server" Text='<%# Eval("會計科目") %>' />
            </td>
            <td>
                <asp:Label ID="科目別Label" runat="server" Text='<%# Eval("科目別") %>' />
            </td>
            <td>
                <asp:Label ID="款項目Label" runat="server" Text='<%# Eval("款項目") %>' />
            </td>
            <td>
                <asp:Label ID="明細項Label" runat="server" Text='<%# Eval("明細項") %>' />
            </td>
            <td>
                <asp:Label ID="借貸別Label" runat="server" Text='<%# Eval("借貸別") %>' />
            </td>
            <td>
                <asp:Label ID="金額Label" runat="server" Text='<%# Eval("金額") %>' />
            </td>
            <td>
                <asp:Label ID="摘要Label" runat="server" Text='<%# Eval("摘要") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="WELFARE.VoucherDetailEdit" DataObjectTypeName="CompanyORMDB.SQLServer.WELFARE.傳票明細" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />



