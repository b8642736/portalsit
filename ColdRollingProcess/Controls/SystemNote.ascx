<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SystemNote.ascx.vb" Inherits="ColdRollingProcess.SystemNote" %>


<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<style type="text/css">
    .style1 {
        height: 20px;
        width: 111px;
    }
</style>


<table style="width: 100%;">
    <tr>
        <td class="style1">片語系統</td>
        <td>
            <cc1:DropDownListEx ID="ddlistSYSTEM_TYPE" runat="server" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
        <td class="style1">片語類別</td>
        <td>
            <cc1:DropDownListEx ID="ddlistNOTE_TYPE" runat="server" Style="margin-left: 0px; height: 19px;" AutoPostBack="True" />
        </td>
    </tr>

    <tr>
        <td class="style1">是否停用</td>
        <td>
            <cc1:DropDownListEx ID="ddlistDel_Flag" runat="server" Style="margin-left: 0px" AutoPostBack="True">
                <asp:ListItem>ALL：全部資料</asp:ListItem>
                <asp:ListItem>N：未停用</asp:ListItem>
                <asp:ListItem>Y：已停用</asp:ListItem>
            </cc1:DropDownListEx>
        </td>
    </tr>

    <tr>
        <td class="style1"></td>
        <td>
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.SystemNote" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="ColdRollingProcess.SystemNote" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfSQL" runat="server" />
        </td>
    </tr>

    <tr>
        <td class="style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>






<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="SYSTEM_TYPE,NOTE_TYPE,NOTE_ID">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  Enabled ="<%# showDeleteButton()%>"/>
                <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="SYSTEM_TYPELabel" runat="server" Text='<%# Eval("SYSTEM_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_TYPELabel" runat="server" Text='<%# Eval("NOTE_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_IDLabel" runat="server" Text='<%# Eval("NOTE_ID") %>' />
            </td>

            <td>
                <asp:Label ID="CONTENTLabel" runat="server" Text='<%# Eval("CONTENT") %>' />
            </td>
            <td>
                <asp:Label ID="DISPLAY_SEQLabel" runat="server" Text='<%# Eval("DISPLAY_SEQ") %>' />
            </td>
            <td>
                <asp:Label ID="DEL_FLAGLabel" runat="server" Text='<%# Eval("DEL_FLAG") %>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="SYSTEM_TYPELabel" runat="server" Text='<%# Bind("SYSTEM_TYPE")%>' />
            </td>
            <td>
                <asp:Label ID="NOTE_TYPELabel" runat="server" Text='<%# Bind("NOTE_TYPE")%>' />
            </td>
            <td>
                <asp:Label ID="NOTE_IDLabel" runat="server" Text='<%# Bind("NOTE_ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="CONTENTTextBox" runat="server" Text='<%# Bind("CONTENT") %>' />
            </td>
            <td>
                <asp:TextBox ID="DISPLAY_SEQTextBox" runat="server" Text='<%# Bind("DISPLAY_SEQ") %>' />
            </td>
            <td>
                <asp:TextBox ID="DEL_FLAGTextBox" runat="server" Text='<%# Bind("DEL_FLAG") %>' Visible="false" />
                <cc1:DropDownListEx ID="DEL_FLAGDropDownListEx" runat="server">
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                </cc1:DropDownListEx>
            </td>


        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
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
                <asp:TextBox ID="SYSTEM_TYPETextBox" runat="server" Text='<%# Bind("SYSTEM_TYPE") %>' />
            </td>
            <td>
                <asp:TextBox ID="NOTE_TYPETextBox" runat="server" Text='<%# Bind("NOTE_TYPE") %>' />
            </td>
            <td>
                <asp:TextBox ID="NOTE_IDTextBox" runat="server" Text='<%# Bind("NOTE_ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="CONTENTTextBox" runat="server" Text='<%# Bind("CONTENT") %>' />
            </td>
            <td>
                <asp:TextBox ID="DISPLAY_SEQTextBox" runat="server" Text='<%# Bind("DISPLAY_SEQ") %>' />
            </td>
            <td>
                <asp:TextBox ID="DEL_FLAGTextBox" runat="server" Text='<%# Bind("DEL_FLAG")%>' Visible="false" />
                <cc1:DropDownListEx ID="DEL_FLAGDropDownListEx" runat="server">
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                </cc1:DropDownListEx>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  Enabled ="<%# showDeleteButton()%>"/>
                <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="SYSTEM_TYPELabel" runat="server" Text='<%# Eval("SYSTEM_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_TYPELabel" runat="server" Text='<%# Eval("NOTE_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_IDLabel" runat="server" Text='<%# Eval("NOTE_ID") %>' />
            </td>
            <td>
                <asp:Label ID="CONTENTLabel" runat="server" Text='<%# Eval("CONTENT") %>' />
            </td>
            <td>
                <asp:Label ID="DISPLAY_SEQLabel" runat="server" Text='<%# Eval("DISPLAY_SEQ") %>' />
            </td>
            <td>
                <asp:Label ID="DEL_FLAGLabel" runat="server" Text='<%# Eval("DEL_FLAG") %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">片語系統</th>
                            <th runat="server">片語類別</th>
                            <th runat="server">片語代號</th>
                            <th runat="server">片語說明</th>
                            <th runat="server">排序</th>
                            <th runat="server">是否停用</th>

                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  Enabled ="<%# showDeleteButton()%>"/>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="SYSTEM_TYPELabel" runat="server" Text='<%# Eval("SYSTEM_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_TYPELabel" runat="server" Text='<%# Eval("NOTE_TYPE") %>' />
            </td>
            <td>
                <asp:Label ID="NOTE_IDLabel" runat="server" Text='<%# Eval("NOTE_ID") %>' />
            </td>
            <td>
                <asp:Label ID="CONTENTLabel" runat="server" Text='<%# Eval("CONTENT") %>' />
            </td>
            <td>
                <asp:Label ID="DISPLAY_SEQLabel" runat="server" Text='<%# Eval("DISPLAY_SEQ") %>' />
            </td>
            <td>
                <asp:Label ID="DEL_FLAGLabel" runat="server" Text='<%# Eval("DEL_FLAG") %>' />
            </td>

        </tr>
    </SelectedItemTemplate>
</asp:ListView>
















