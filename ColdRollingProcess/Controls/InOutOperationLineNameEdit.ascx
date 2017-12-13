<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InOutOperationLineNameEdit.ascx.vb" Inherits="ColdRollingProcess.InOutOperationLineNameEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 241px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            上一站之下一站產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            (例:AP1H)</td>
    </tr>
    <tr>
        <td class="style1">
            上一站之處理後表面:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            (例:NO1)</td>
    </tr>
    <tr>
        <td class="style1">
            處理過後的產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            (例:NO1)</td>
    </tr>
    <tr>
        <td class="style1">
            處理過後的下一站產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            (例:AP1H)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
                        <asp:HiddenField ID="hfQryString" runat="server" />
                    </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
    EnableModelValidation="True" InsertItemPosition="LastItem" 
    DataKeyNames="ID">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFFFFF;color: #284775;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="InNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("InNextOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="InCurrentFishLabel" runat="server" 
                    Text='<%# Eval("InCurrentFish") %>' />
            </td>
            <td>
                <asp:Label ID="OutOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="OutNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutNextOperationLineName") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #999999;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="InNextOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("InNextOperationLineName") %>' />
            </td>
            <td>
                <asp:TextBox ID="InCurrentFishTextBox" runat="server" 
                    Text='<%# Bind("InCurrentFish") %>' />
            </td>
            <td>
                <asp:TextBox ID="OutOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("OutOperationLineName") %>' />
            </td>
            <td>
                <asp:TextBox ID="OutNextOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("OutNextOperationLineName") %>' />
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
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="InNextOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("InNextOperationLineName") %>' />
            </td>
            <td>
                <asp:TextBox ID="InCurrentFishTextBox" runat="server" 
                    Text='<%# Bind("InCurrentFish") %>' />
            </td>
            <td>
                <asp:TextBox ID="OutOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("OutOperationLineName") %>' />
            </td>
            <td>
                <asp:TextBox ID="OutNextOperationLineNameTextBox" runat="server" 
                    Text='<%# Bind("OutNextOperationLineName") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #E0FFFF;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="InNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("InNextOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="InCurrentFishLabel" runat="server" 
                    Text='<%# Eval("InCurrentFish") %>' />
            </td>
            <td>
                <asp:Label ID="OutOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="OutNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutNextOperationLineName") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                            <th runat="server">
                            </th>
                            <th runat="server">
                                上一站產線名稱</th>
                            <th runat="server">
                                上一站處理後表面</th>
                            <th runat="server">
                                本站處理過後的產線名稱</th>
                            <th runat="server">
                                本站處理過後的下一站產線名稱</th>
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
    <SelectedItemTemplate>
        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="InNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("InNextOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="InCurrentFishLabel" runat="server" 
                    Text='<%# Eval("InCurrentFish") %>' />
            </td>
            <td>
                <asp:Label ID="OutOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutOperationLineName") %>' />
            </td>
            <td>
                <asp:Label ID="OutNextOperationLineNameLabel" runat="server" 
                    Text='<%# Eval("OutNextOperationLineName") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.InOutOperationLineName" 
    DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" 
    TypeName="ColdRollingProcess.InOutOperationLineNameEdit" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


