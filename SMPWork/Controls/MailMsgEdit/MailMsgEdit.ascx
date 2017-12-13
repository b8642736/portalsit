<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MailMsgEdit.ascx.vb" Inherits="SMPWork.MailMsgEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 105px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            收件人名稱:</td>
        <td>
            <asp:TextBox ID="tbReceiveName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Email位址:&nbsp;</td>
        <td>
            <asp:TextBox ID="tbReceiveEmail" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            訊息種類:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="1">驗收料</asp:ListItem>
                <asp:ListItem Value="2">輻射</asp:ListItem>
                <asp:ListItem Value="3">分析超標</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
    DataSourceID="ldsSearchResult" EnableModelValidation="True" 
    InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="MailTypeLabel" runat="server" Text='<%# Eval("MailTypeName") %>' />
            </td>
            <td>
                <asp:Label ID="ReceivePersonNameLabel" runat="server" 
                    Text='<%# Eval("ReceivePersonName") %>' />
            </td>
            <td>
                <asp:Label ID="MailAddressLabel" runat="server" 
                    Text='<%# Eval("MailAddress") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:confirmbuttonextender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:Label Visible="false" ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="MailTypeLabel" runat="server" Text='<%# Eval("MailTypeName") %>' />
            </td>
            <td>
                <asp:Label ID="ReceivePersonNameLabel" runat="server" 
                    Text='<%# Eval("ReceivePersonName") %>' />
            </td>
            <td>
                <asp:Label ID="MailAddressLabel" runat="server" 
                    Text='<%# Eval("MailAddress") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <asp:Label ID="IDLabel1" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("MailType") %>'>
                    <asp:ListItem Value="1">驗收料</asp:ListItem>
                    <asp:ListItem Value="2">輻射</asp:ListItem>
                    <asp:ListItem Value="3">分析超標</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="MailTypeTextBox" runat="server" 
                    Text='<%# Bind("MailType") %>' />--%>
            </td>
            <td>
                <asp:TextBox ID="ReceivePersonNameTextBox" runat="server" 
                    Text='<%# Bind("ReceivePersonName") %>' />
            </td>
            <td>
                <asp:TextBox ID="MailAddressTextBox" runat="server" 
                    Text='<%# Bind("MailAddress") %>' />
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
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                <asp:TextBox Visible="false"  ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("MailType") %>'>
                    <asp:ListItem Value="1">驗收料</asp:ListItem>
                    <asp:ListItem Value="2">輻射</asp:ListItem>
                    <asp:ListItem Value="3">分析超標</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="MailTypeTextBox" runat="server" 
                    Text='<%# Bind("MailType") %>' />--%>
            </td>
            <td>
                <asp:TextBox ID="ReceivePersonNameTextBox" runat="server" 
                    Text='<%# Bind("ReceivePersonName") %>' />
            </td>
            <td>
                <asp:TextBox ID="MailAddressTextBox" runat="server" 
                    Text='<%# Bind("MailAddress") %>' />
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
                            <%--<th runat="server">
                                ID</th>--%>
                            <th runat="server">
                                訊息種類</th>
                            <th runat="server">
                                收件人姓名</th>
                            <th runat="server">
                                Email地址</th>
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
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <%--<td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>--%>
            <td>
                <asp:Label ID="MailTypeLabel" runat="server" Text='<%# Eval("MailType") %>' />
            </td>
            <td>
                <asp:Label ID="ReceivePersonNameLabel" runat="server" 
                    Text='<%# Eval("ReceivePersonName") %>' />
            </td>
            <td>
                <asp:Label ID="MailAddressLabel" runat="server" 
                    Text='<%# Eval("MailAddress") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.Qcdb01DataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" OrderBy="MailType, ReceivePersonName" 
    TableName="MailMsgEdit">
</asp:LinqDataSource>









