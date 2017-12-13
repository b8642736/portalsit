<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetTransferUser.ascx.vb" Inherits="AST500LB.AssetTransferUser" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="AssetSearch.ascx" tagname="AssetSearch" tagprefix="uc1" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
    
<style type="text/css">
    .style1
    {
        width: 115px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            移轉日期:</td>
        <td>
            <asp:TextBox ID="btStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="btEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            原/新資產編號:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchCondictionClear" runat="server" Text="清除查詢條件" 
                Width="100px" />
        </td>
    </tr>
</table>
    
<asp:ListView ID="ListView1" runat="server" 
    DataKeyNames="TRNDATE,TRNTIME,FNUMBER,TNUMBER" DataSourceID="odsSearchResult" 
    InsertItemPosition="LastItem" >
    <ItemTemplate>
        <tr style="background-color: #E0FFFF;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" >
                </cc1:ConfirmButtonExtender>
                <%--<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />--%>
            </td>
            <td>
                <asp:Label ID="TRNDATELabel" runat="server" Text='<%# Eval("TRNDATE") %>' />
            </td>
            <td>
                <asp:Label ID="TRNTIMELabel" runat="server" Text='<%# Eval("TRNTIME") %>' />
            </td>
            <td>
                <asp:Label ID="FNUMBERLabel" runat="server" Text='<%# Eval("FNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="TNUMBERLabel" runat="server" Text='<%# Eval("TNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="FDEPTSALabel" runat="server" Text='<%# Eval("FDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TDEPTSALabel" runat="server" Text='<%# Eval("TDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TRNCOUNTLabel" runat="server" Text='<%# Eval("TRNCOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="MEMO1Label" runat="server" Text='<%# Eval("MEMO1") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color: #FFFFFF;color: #284775;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" >
                </cc1:ConfirmButtonExtender>
                <%--<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />--%>
            </td>
            <td>
                <asp:Label ID="TRNDATELabel" runat="server" Text='<%# Eval("TRNDATE") %>' />
            </td>
            <td>
                <asp:Label ID="TRNTIMELabel" runat="server" Text='<%# Eval("TRNTIME") %>' />
            </td>
            <td>
                <asp:Label ID="FNUMBERLabel" runat="server" Text='<%# Eval("FNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="TNUMBERLabel" runat="server" Text='<%# Eval("TNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="FDEPTSALabel" runat="server" Text='<%# Eval("FDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TDEPTSALabel" runat="server" Text='<%# Eval("TDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TRNCOUNTLabel" runat="server" Text='<%# Eval("TRNCOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="MEMO1Label" runat="server" Text='<%# Eval("MEMO1") %>' />
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
                <asp:TextBox ID="TRNDATETextBox" runat="server" Text='<%# Bind("TRNDATEDateFormat") %>' Width="100px" CausesValidation="False" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TRNDATETextBox" Mask="9999/99/99" MaskType="Date">
                </cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TRNDATETextBox" Format="yyyy/MM/dd" >
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="現在(自動)"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="FNUMBERTextBox" runat="server" Text='<%# Bind("FNUMBER") %>' Width="100px" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="FNUMBERTextBox" Mask="??????????????">
                </cc1:MaskedEditExtender>
                <asp:Button ID="btnAssetSearch" runat="server" Text="查詢" Width="40px" OnClick="btnAssetSearch_Click" />
            </td>
            <td>
                <asp:TextBox ID="TNUMBERTextBox" runat="server" Text='<%# Bind("TNUMBER") %>' Width="100px"  />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TNUMBERTextBox" Mask="??????????????">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FDEPTSA") %>'  Width="40px" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TDEPTSATextBox" runat="server" Text='<%# Bind("TDEPTSA") %>' Width="40px" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="TDEPTSATextBox" Mask="????">
                </cc1:MaskedEditExtender>
       </td>
            <td>
                <asp:TextBox ID="TRNCOUNTTextBox" runat="server" 
                    Text='<%# Bind("TRNCOUNT") %>' Width="40px" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="TRNCOUNTTextBox" Mask="9999">
                </cc1:MaskedEditExtender>
                <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="TRNCOUNTTextBox" WatermarkText="不輸入則移轉全部數量!">
                </cc1:TextBoxWatermarkExtender>--%>    
            </td>
            <td>
                <asp:TextBox ID="MEMO1TextBox" runat="server" Text='<%# Bind("MEMO1") %>' />
            </td>
        </tr>
        <tr>
            <td>訊息:</td>
            <td colspan="8">
                <asp:CustomValidator ID="InsertDataValidator1" runat="server" ErrorMessage="CustomValidator" ControlToValidate="TRNDATETextBox" OnServerValidate="InsertDataValidator1_ServerValidation"></asp:CustomValidator>
            </td>
        </tr>
    </InsertItemTemplate>
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
                                移轉日期</th>
                            <th runat="server">
                                移轉時間</th>
                            <th runat="server">
                                原資產編號</th>
                            <th runat="server">
                                新資產編號</th>
                            <th runat="server">
                                原單位</th>
                            <th runat="server">
                                新單位</th>
                            <th runat="server">
                                移轉數量</th>
                            <th runat="server">
                                備註1</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align:left ;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="15"  >
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField  ButtonCount="20" />
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
            </td>
            <td>
                <asp:TextBox ID="TRNDATETextBox" runat="server" Text='<%# Bind("TRNDATE") %>' />
            </td>
            <td>
                <asp:TextBox ID="TRNTIMETextBox" runat="server" Text='<%# Bind("TRNTIME") %>' />
            </td>
            <td>
                <asp:TextBox ID="FNUMBERTextBox" runat="server" Text='<%# Bind("FNUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="TNUMBERTextBox" runat="server" Text='<%# Bind("TNUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="FDEPTSATextBox" runat="server" Text='<%# Bind("FDEPTSA") %>' />
            </td>
            <td>
                <asp:TextBox ID="TDEPTSATextBox" runat="server" Text='<%# Bind("TDEPTSA") %>' />
            </td>
            <td>
                <asp:TextBox ID="TRNCOUNTTextBox" runat="server" 
                    Text='<%# Bind("TRNCOUNT") %>' />
            </td>
            <td>
                <asp:TextBox ID="MEMO1TextBox" runat="server" Text='<%# Bind("MEMO1") %>' />
            </td>
            <td>
                <asp:TextBox ID="SQLQueryAdapterByThisObjectTextBox" runat="server" 
                    Text='<%# Bind("SQLQueryAdapterByThisObject") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBCurrentUseSQLQueryAdapterTextBox" runat="server" 
                    Text='<%# Bind("CDBCurrentUseSQLQueryAdapter") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBLibraryNameTextBox" runat="server" 
                    Text='<%# Bind("CDBLibraryName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFileNameTextBox" runat="server" 
                    Text='<%# Bind("CDBFileName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBMemberNameTextBox" runat="server" 
                    Text='<%# Bind("CDBMemberName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFullAS400DBPathTextBox" runat="server" 
                    Text='<%# Bind("CDBFullAS400DBPath") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBInsertSQLStringTextBox" runat="server" 
                    Text='<%# Bind("CDBInsertSQLString") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBUpdateSQLStringTextBox" runat="server" 
                    Text='<%# Bind("CDBUpdateSQLString") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBDeleteSQLStringTextBox" runat="server" 
                    Text='<%# Bind("CDBDeleteSQLString") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBClassFieldNamesTextBox" runat="server" 
                    Text='<%# Bind("CDBClassFieldNames") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBPKFieldsPropertyInfoTextBox" runat="server" 
                    Text='<%# Bind("CDBPKFieldsPropertyInfo") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFieldsPropertyInfoTextBox" runat="server" 
                    Text='<%# Bind("CDBFieldsPropertyInfo") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBClassDBPropertyFieldNamesTextBox" runat="server" 
                    Text='<%# Bind("CDBClassDBPropertyFieldNames") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="TRNDATELabel" runat="server" Text='<%# Eval("TRNDATE") %>' />
            </td>
            <td>
                <asp:Label ID="TRNTIMELabel" runat="server" Text='<%# Eval("TRNTIME") %>' />
            </td>
            <td>
                <asp:Label ID="FNUMBERLabel" runat="server" Text='<%# Eval("FNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="TNUMBERLabel" runat="server" Text='<%# Eval("TNUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="FDEPTSALabel" runat="server" Text='<%# Eval("FDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TDEPTSALabel" runat="server" Text='<%# Eval("TDEPTSA") %>' />
            </td>
            <td>
                <asp:Label ID="TRNCOUNTLabel" runat="server" Text='<%# Eval("TRNCOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="MEMO1Label" runat="server" Text='<%# Eval("MEMO1") %>' />
            </td>
            <td>
                <asp:Label ID="SQLQueryAdapterByThisObjectLabel" runat="server" 
                    Text='<%# Eval("SQLQueryAdapterByThisObject") %>' />
            </td>
            <td>
                <asp:Label ID="CDBCurrentUseSQLQueryAdapterLabel" runat="server" 
                    Text='<%# Eval("CDBCurrentUseSQLQueryAdapter") %>' />
            </td>
            <td>
                <asp:Label ID="CDBLibraryNameLabel" runat="server" 
                    Text='<%# Eval("CDBLibraryName") %>' />
            </td>
            <td>
                <asp:Label ID="CDBFileNameLabel" runat="server" 
                    Text='<%# Eval("CDBFileName") %>' />
            </td>
            <td>
                <asp:Label ID="CDBMemberNameLabel" runat="server" 
                    Text='<%# Eval("CDBMemberName") %>' />
            </td>
            <td>
                <asp:Label ID="CDBFullAS400DBPathLabel" runat="server" 
                    Text='<%# Eval("CDBFullAS400DBPath") %>' />
            </td>
            <td>
                <asp:Label ID="CDBInsertSQLStringLabel" runat="server" 
                    Text='<%# Eval("CDBInsertSQLString") %>' />
            </td>
            <td>
                <asp:Label ID="CDBUpdateSQLStringLabel" runat="server" 
                    Text='<%# Eval("CDBUpdateSQLString") %>' />
            </td>
            <td>
                <asp:Label ID="CDBDeleteSQLStringLabel" runat="server" 
                    Text='<%# Eval("CDBDeleteSQLString") %>' />
            </td>
            <td>
                <asp:Label ID="CDBClassFieldNamesLabel" runat="server" 
                    Text='<%# Eval("CDBClassFieldNames") %>' />
            </td>
            <td>
                <asp:Label ID="CDBPKFieldsPropertyInfoLabel" runat="server" 
                    Text='<%# Eval("CDBPKFieldsPropertyInfo") %>' />
            </td>
            <td>
                <asp:Label ID="CDBFieldsPropertyInfoLabel" runat="server" 
                    Text='<%# Eval("CDBFieldsPropertyInfo") %>' />
            </td>
            <td>
                <asp:Label ID="CDBClassDBPropertyFieldNamesLabel" runat="server" 
                    Text='<%# Eval("CDBClassDBPropertyFieldNames") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.AST500LB.AST401PF" DeleteMethod="CDBDelete" 
    InsertMethod="CDBInsert" SelectMethod="Search" 
    TypeName="AST500LB.AssetTransferUser" UpdateMethod="CDBUpdate" 
    EnableCaching="True">
    <SelectParameters>
        <asp:ControlParameter ControlID="btStartDate" Name="TransStartDate" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="btEndDate" Name="TransEndDate" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="TextBox3" Name="AssetNumber" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

    </asp:View>
    <asp:View ID="View2" runat="server">

        <uc1:AssetSearch ID="AssetSearch1" runat="server" />

    </asp:View>
</asp:MultiView>

