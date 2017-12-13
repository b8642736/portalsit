<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FAMExtendUse.ascx.vb" Inherits="AST500LB.FAMExtendUse" %>
<style type="text/css">
    .auto-style1
    {
        width: 105px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">民國年月 份:</td>
        <td>
            <asp:TextBox ID="tbYearMonth" runat="server" Width="100px"></asp:TextBox>
        </td>
            <td class="auto-style2">廠別:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="SA">SA</asp:ListItem>
                    <asp:ListItem>AA</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>QA</asp:ListItem>
                    <asp:ListItem>RA</asp:ListItem>
                    <asp:ListItem>RC</asp:ListItem>
                    <asp:ListItem>RD</asp:ListItem>
                </asp:RadioButtonList>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td colspan="3">
            <asp:Button ID="btnSearch" runat="server" Text="重整編修" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearhResult" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="FACNAMLabel" runat="server" Text='<%# Eval("FACNAM") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="YDATELabel" runat="server" Text='<%# Eval("YDATE") %>' />
            </td>
            <td>
                <asp:Label ID="EXTYERLabel" runat="server" Text='<%# Eval("EXTYER") %>' />
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
                <%--<asp:TextBox ID="FACNAMTextBox" runat="server" Text='<%# Bind("FACNAM") %>' />--%>
                <asp:DropDownList ID="FACNAMDropDownList" runat="server" DataTextField='<%# Bind("FACNAM") %>'>
                    <asp:ListItem Value="SA">SA</asp:ListItem>
                    <asp:ListItem Value="AA">AA</asp:ListItem>
                    <asp:ListItem Value="AB">AB</asp:ListItem>
                    <asp:ListItem Value="NA">NA</asp:ListItem>
                    <asp:ListItem Value="QA">QA</asp:ListItem>
                    <asp:ListItem Value="RA">RA</asp:ListItem>
                    <asp:ListItem Value="RC">RC</asp:ListItem>
                    <asp:ListItem Value="RD">RD</asp:ListItem>
               </asp:DropDownList>            
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="YDATETextBox" runat="server" Text='<%# Bind("YDATE") %>' />
            </td>
            <td>
                <asp:TextBox ID="EXTYERTextBox" runat="server" Text='<%# Bind("EXTYER") %>' />
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
        <%--<tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:DropDownList ID="FACNAMDropDownList" runat="server" DataTextField='<%# Bind("FACNAM") %>'>
                    <asp:ListItem Value="SA">SA</asp:ListItem>
                    <asp:ListItem Value="AA">AA</asp:ListItem>
                    <asp:ListItem Value="AB">AB</asp:ListItem>
                    <asp:ListItem Value="NA">NA</asp:ListItem>
                    <asp:ListItem Value="QA">QA</asp:ListItem>
                    <asp:ListItem Value="RA">RA</asp:ListItem>
                    <asp:ListItem Value="RC">RC</asp:ListItem>
                    <asp:ListItem Value="RD">RD</asp:ListItem>
               </asp:DropDownList>            
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="YDATETextBox" runat="server" Text='<%# Bind("YDATE") %>' />
            </td>
            <td>
                <asp:TextBox ID="EXTYERTextBox" runat="server" Text='<%# Bind("EXTYER") %>' />
            </td>
        </tr>--%>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="FACNAMLabel" runat="server" Text='<%# Eval("FACNAM") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="YDATELabel" runat="server" Text='<%# Eval("YDATE") %>' />
            </td>
            <td>
                <asp:Label ID="EXTYERLabel" runat="server" Text='<%# Eval("EXTYER") %>' />
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
                            <th runat="server">廠別</th>
                            <th runat="server">資產名稱</th>
                            <th runat="server">資產編號</th>
                            <th runat="server">延用日年月</th>
                            <th runat="server">延用年數</th>
                            <th id="Th1" runat="server">訊息</th>
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
                <asp:Label ID="FACNAMLabel" runat="server" Text='<%# Eval("FACNAM") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="YDATELabel" runat="server" Text='<%# Eval("YDATE") %>' />
            </td>
            <td>
                <asp:Label ID="EXTYERLabel" runat="server" Text='<%# Eval("EXTYER") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>

<asp:ObjectDataSource ID="odsSearhResult" runat="server" DataObjectTypeName="CompanyORMDB.AST501LB.ASTEXTPF" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="AST500LB.FAMExtendUse" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />



