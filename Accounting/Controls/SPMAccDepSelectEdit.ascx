<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SPMAccDepSelectEdit.ascx.vb" Inherits="Accounting.SPMAccDepSelectEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 103px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            表單類別:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                <asp:ListItem Value="1">外修申請單</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            使用單位:</td>
        <td>
            <asp:TextBox ID="tbAC0002Search" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            會計科目:</td>
        <td>
            <asp:TextBox ID="tbAC0003Search" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            明細科目:</td>
        <td>
            <asp:TextBox ID="tbAC0004Search" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" CausesValidation="false"  Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
    EnableModelValidation="True" InsertItemPosition="LastItem" 
    DataKeyNames="AC0001,AC0002,AC0003,AC0004">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="false"  />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="false"  />
            </td>
            <td>
                <asp:Label ID="AC0001Label" runat="server" Text='<%# Eval("AC0001Chinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0002Label" runat="server" Text='<%# Eval("AC0002NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0003Label" runat="server" Text='<%# Eval("AC0003NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0004Label" runat="server" Text='<%# Eval("AC0004NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0005Label" runat="server" Text='<%# Eval("AC0005") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" CausesValidation="false"  />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" CausesValidation="false"  />
            </td>
            <td>
                <%--<asp:TextBox ID="AC0001TextBox" runat="server" Text='<%# Bind("AC0001") %>' />--%>
                <asp:DropDownList ID="DropDownList1" Enabled="false" SelectedValue='<%# Bind("AC0001") %>' runat="server"  Width="150px">
                    <asp:ListItem Value="1">外修申請單</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="AC0002TextBox" Enabled="false"  runat="server" Text='<%# Bind("AC0002") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0003TextBox" Enabled="false"  runat="server" Text='<%# Bind("AC0003") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0004TextBox" Enabled="false"  runat="server" Text='<%# Bind("AC0004") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0005TextBox" runat="server" Text='<%# Bind("AC0005") %>' />
            </td>
        </tr>
    </EditItemTemplate>
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
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" CausesValidation="false" />
            </td>
            <td>
                <%--<asp:TextBox ID="AC0001TextBox" runat="server" Text='<%# Bind("AC0001") %>' />--%>
                <asp:DropDownList ID="DropDownList1" SelectedValue='<%# Bind("AC0001") %>' runat="server"  Width="150px">
                    <asp:ListItem Value="1">外修申請單</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="AC0002TextBox" runat="server" Text='<%# Bind("AC0002") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0003TextBox" runat="server" Text='<%# Bind("AC0003") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0004TextBox" runat="server" Text='<%# Bind("AC0004") %>' />
            </td>
            <td>
                <asp:TextBox ID="AC0005TextBox" runat="server" Text='<%# Bind("AC0005") %>' />
            </td>
        </tr>
        <tr>
            <td>訊息:</td>
            <td colspan="5">
                <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage=""></asp:CustomValidator></td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="false"  />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="false"  />
            </td>
            <td>
                <asp:Label ID="AC0001Label" runat="server" Text='<%# Eval("AC0001Chinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0002Label" runat="server" Text='<%# Eval("AC0002NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0003Label" runat="server" Text='<%# Eval("AC0003NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0004Label" runat="server" Text='<%# Eval("AC0004NOAndChinese") %>' />
            </td>
            <td>
                <asp:Label ID="AC0005Label" runat="server" Text='<%# Eval("AC0005") %>' />
            </td>
        </tr>
    </ItemTemplate>
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
                                電子表單類別</th>
                            <th runat="server">
                                使用單位代碼</th>
                            <th runat="server">
                                會計科目代號</th>
                            <th runat="server">
                                明細科目代號</th>
                            <th runat="server">
                                使用說明</th>
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
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="false"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="false"  />
            </td>
            <td>
                <asp:Label ID="AC0001Label" runat="server" Text='<%# Eval("AC0001") %>' />
            </td>
            <td>
                <asp:Label ID="AC0002Label" runat="server" Text='<%# Eval("AC0002") %>' />
            </td>
            <td>
                <asp:Label ID="AC0003Label" runat="server" Text='<%# Eval("AC0003") %>' />
            </td>
            <td>
                <asp:Label ID="AC0004Label" runat="server" Text='<%# Eval("AC0004") %>' />
            </td>
            <td>
                <asp:Label ID="AC0005Label" runat="server" Text='<%# Eval("AC0005") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect" 
    DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" 
    TypeName="Accounting.SPMAccDepSelectEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SqlString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />
                </td>
