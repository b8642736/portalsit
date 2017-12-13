<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FoodDeskPerson.ascx.vb" Inherits="Personnel.FoodDeskPerson" %>
<style type="text/css">
    .auto-style1 {
        width: 50%;
    }

    .auto-style2 {
        width: 128px;
    }

    .auto-style4 {
        width: 321px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">單位：</td>
        <td class="auto-style4">
            <asp:DropDownList ID="ddUnit_Search" runat="server" Width="100%" />

        </td>
        <td class="auto-style4" rowspan="2">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="39px" Width="74px" />
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">資料是否刪除</td>
        <td class="auto-style4">
            <asp:DropDownList ID="ddDataType_Search" runat="server" Width="100%" />
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style4">
            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="Personnel.FoodDeskPerson" DataObjectTypeName="CompanyORMDB.FOD100LB.FODM03PF" InsertMethod="Insert" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfSQL" runat="server" />
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="FD301,FD302">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="FD301Label" runat="server" Text='<%# showDeptName(Eval("FD301"))%>' />
            </td>
            <td>
                <asp:Label ID="FD302Label" runat="server" Text='<%# showEmployeeName(Eval("FD302"))%>' />
            </td>
            <td>
                <asp:Label ID="FD303Label" runat="server" Text='<%# Eval("FD303") %>' />
            </td>
            <td>
                <asp:Label ID="FD304Label" runat="server" Text='<%# Eval("FD304") %>' />
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
                <asp:Label ID="FD301Label" runat="server" Text='<%# showDeptName(Eval("FD301"))%>' />
            </td>
            <td>
                <asp:Label ID="FD302Label" runat="server" Text='<%# showEmployeeName(Eval("FD302"))%>' />
            </td>
            <td>
                <asp:HiddenField ID="FD303HiddenField" runat="server" Value='<%# Bind("FD303") %>' />
                <asp:DropDownList ID="ddDataType_Edit" runat="server" Width="100%" />
            </td>
            <td>
                <asp:Label ID="FD304Label" runat="server" Text='<%#Eval("FD304")%>' />
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
                <asp:Label ID="FD301Label" runat="server" Text='<%# showDeptName(Eval("FD301"))%>' />
            </td>
            <td>
                <asp:Label ID="FD302Label" runat="server" Text='' />
                <br />
                <asp:TextBox ID="FD302TextBox" runat="server" Text="" />
                <asp:Button ID="btnSearchEmployee" runat="server" Text="查詢" OnClick="btnSearchEmployee_Click" />

            </td>
            <td>
                <%--                <asp:HiddenField  ID="FD303HiddenField" runat="server"  Value ='<%# Bind("FD303") %>' />--%>
                <asp:DropDownList ID="ddDataType_Add" runat="server" Width="100%" />
            </td>
            <td>
                <asp:Label ID="FD304Label" runat="server" Text='<%# Eval("FD304")%>' />
            </td>
        </tr>
        <tr>
            <td>訊息</td>
            <td colspan="4">
                <asp:CustomValidator ID="cv1" runat="server" ErrorMessage="驗證員工編號是否有輸入" OnServerValidate="cv1_ServerValidate" />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="FD301Label" runat="server" Text='<%# showDeptName(Eval("FD301"))%>' />
            </td>
            <td>
                <asp:Label ID="FD302Label" runat="server" Text='<%# showEmployeeName(Eval("FD302"))%>' />
            </td>
            <td>
                <asp:Label ID="FD303Label" runat="server" Text='<%# Eval("FD303") %>' />
            </td>
            <td>
                <asp:Label ID="FD304Label" runat="server" Text='<%# Eval("FD304") %>' />
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
                            <th runat="server">單位</th>
                            <th runat="server">職工編號</th>
                            <th runat="server">是否刪除</th>
                            <th runat="server">異動日期時間</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="FD301Label" runat="server" Text='<%# Eval("FD301") %>' />
            </td>
            <td>
                <asp:Label ID="FD302Label" runat="server" Text='<%# Eval("FD302") %>' />
            </td>
            <td>
                <asp:Label ID="FD303Label" runat="server" Text='<%# Eval("FD303") %>' />
            </td>
            <td>
                <asp:Label ID="FD304Label" runat="server" Text='<%# Eval("FD304") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>


<p>
    &nbsp;
</p>
<p>
    &nbsp;
</p>
<p>
    &nbsp;
</p>



