<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StationEdit.ascx.vb" Inherits="ColdRollingProcess.StationEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="StationToWebClientPCAccountEdit.ascx" tagname="StationToWebClientPCAccountEdit" tagprefix="uc1" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" 
    EnableViewState="False">
    <asp:View ID="View1" runat="server">
        <style type="text/css">
            .style1
            {
                width: 70px;
            }
        </style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    站台名稱:</td>
                <td>
                    <asp:TextBox ID="tbStationName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:HiddenField ID="hfQryString" runat="server" />
                    <asp:HiddenField ID="hfQryString0" runat="server" />
                </td>
            </tr>
        </table>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
            EnableModelValidation="True" InsertItemPosition="LastItem" 
            DataKeyNames="StationName">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除相關子站台及清除排程站台設定?" />
                       <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="btnClientPCSet" runat="server" CommandName="Select" Text="電腦IP對應" />
                    </td>
                    <td>
                        <asp:Label ID="StationNameLabel" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_ParentStationNameLabel" runat="server" 
                            Text='<%# Eval("FK_ParentStationName") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除相關子站台及清除排程站台設定?" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="btnClientPCSet" runat="server" CommandName="Select"  Text="電腦IP對應" />
                    </td>
                    <td>
                        <asp:Label ID="StationNameLabel" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_ParentStationNameLabel" runat="server" 
                            Text='<%# Eval("FK_ParentStationName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:Label ID="StationNameLabel" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true"  DataSourceID="odsParentStationSearch" DataTextField="StationName" DataValueField="StationName" Width="100" >
                            <asp:ListItem Value="">無上層站台</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfFK_ParentStationName" Value='<%# Eval("FK_ParentStationName") %>' runat="server" />
                    </td>
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
                    </td>
                    <td>
                        <asp:TextBox ID="StationNameTextBox" runat="server" 
                            Text='<%# Bind("StationName") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true"  DataSourceID="odsParentStationSearch" DataTextField="StationName" DataValueField="StationName" Width="100" >
                            <asp:ListItem Value="">無上層站台</asp:ListItem>
                        </asp:DropDownList>
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
                                    <th runat="server">
                                        站台名稱</th>
                                    <th id="Th1" runat="server">
                                        上層站台</th>
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
                        <asp:Button ID="btnClientPCSet" runat="server" CommandName="Select"  Text="電腦IP對應" />
                   </td>
                    <td>
                        <asp:Label ID="StationNameLabel" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_ParentStationNameLabel" runat="server" 
                            Text='<%# Eval("FK_ParentStationName") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" 
            DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.Station" 
            DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" 
            TypeName="ColdRollingProcess.StationEdit" UpdateMethod="Update">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsParentStationSearch" runat="server" 
            SelectMethod="ParentStationSearch" TypeName="ColdRollingProcess.StationEdit">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQryString0" Name="QryString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:Button ID="btnBack" runat="server" Text="返回" Width="100px" />
        <uc1:StationToWebClientPCAccountEdit ID="StationToWebClientPCAccountEdit1" 
            runat="server" />
    </asp:View>
</asp:MultiView>



