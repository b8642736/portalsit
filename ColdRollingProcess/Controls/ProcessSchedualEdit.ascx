<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProcessSchedualEdit.ascx.vb" Inherits="ColdRollingProcess.ProcessSchedualEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="ProcessToInOutOperationLineNameEdit.ascx" tagname="ProcessToInOutOperationLineNameEdit" tagprefix="uc1" %>
<%--<%@ Register src="ProcessToWebClientPCAccountEdit.ascx" tagname="ProcessToWebClientPCAccountEdit" tagprefix="uc2" %>
--%><style type="text/css">
    .style1
    {
        width: 111px;
    }
</style>


<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server" >
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    最終表面:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="168px"></asp:TextBox>
                            (範例:BA,2B,2D,SH...)
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    設備名稱:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="168px"></asp:TextBox>
                    (範例:APL,ZML,....)</td>
            </tr>
            <tr>
                <td class="style1">
                    查詢節點範圍:</td>
                <td>
                    &nbsp;</td>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                        <asp:HiddenField ID="hfQryString" runat="server" />
                    </td>
                </tr>
            </tr>
        </table>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
            DataSourceID="odsSearchResult" InsertItemPosition="LastItem">
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="注意:刪除會連帶刪除此程序之後的所有程序(會自動排除已被其他節點共用的節點)!" 
                            TargetControlID="DeleteButton" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="btnNameTransEdit" runat="server" CommandName="Select" Text="名稱轉換設定" Width="90" OnPreRender="btnEditConnect_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FinalFishLabel" runat="server" Text='<%# Eval("FinalFish") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EquipmentNameLabel" runat="server" 
                            Text='<%# Eval("EquipmentName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("OverProcessFish") %>' />
                    </td>
                     <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                    <td>
                        <asp:Button ID="btnEditConnect" runat="server" CommandName="Select" 
                            Text="設定連結"  OnPreRender="btnEditConnect_Click"  />
                        <asp:Label ID="PreProcessSchedualIDLabels" runat="server" 
                            Text='<%# Eval("PreProcessSchedualEquipmentNames") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="注意:刪除會連帶刪除此程序之後的所有程序(會自動排除已被其他節點共用的節點)!" 
                            TargetControlID="DeleteButton" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="btnNameTransEdit" runat="server" CommandName="Select" Text="名稱轉換設定"  Width="90"  OnPreRender="btnEditConnect_Click"  />
                        <%--<asp:Button ID="btnIPMAP" runat="server" CommandName="Select" Text="電腦IP對應" Width="80"  OnPreRender="btnEditConnect_Click"  />--%>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FinalFishLabel" runat="server" Text='<%# Eval("FinalFish") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EquipmentNameLabel" runat="server" 
                            Text='<%# Eval("EquipmentName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("OverProcessFish") %>' />
                    </td>
                     <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("StationName") %>' />
                    </td>
                   <td>
                        <asp:Button ID="btnEditConnect" runat="server" CommandName="Select" 
                            Text="設定連結" OnPreRender="btnEditConnect_Click"  />
                        <asp:Label ID="NextProcessSchedualIDLabels" runat="server" 
                            Text='<%# Eval("PreProcessSchedualEquipmentNames") %>' />
                    </td>
                </tr>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("ID") %>' />
                       
                    </td>
                    <td>
                        <asp:Label ID="FinalFishLabel" runat="server" Text='<%# Bind("FinalFish") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EquipmentNameTextBox" runat="server" 
                            Text='<%# Bind("EquipmentName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("OverProcessFish") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true"  DataSourceID="odsStationSearch" DataTextField="StationName" DataValueField="StationName">
                        <asp:ListItem Value="">指定站台名稱</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfStationName" Value='<%# Eval("FK_StationName") %>' runat="server" />
                    </td>
                    <td>
                     <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Bind("PreProcessSchedualIDs") %>' />
                        <%--<asp:TextBox ID="NextProcessSchedualIDTextBox" runat="server" 
                    Text='<%# Bind("NextProcessSchedualID") %>' />--%>
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
                        <asp:TextBox ID="FinalFishTextBox" runat="server" 
                            Text='<%# Bind("FinalFish") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EquipmentNameTextBox" runat="server" 
                            Text='<%# Bind("EquipmentName") %>' />
                    </td>
                   <td>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("OverProcessFish") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true"  DataSourceID="odsStationSearch" DataTextField="StationName" DataValueField="StationName">
                        <asp:ListItem Value="">指定站台名稱</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
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
                                        最終表面</th>
                                    <th runat="server">
                                        設備名稱</th>
                                    <th runat="server">
                                        處理後表面</th>
                                    <th id="Th2" runat="server">
                                        現場站台名稱</th>
                                    <th id="Th1" runat="server">
                                        前一站設備名稱</th>
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
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FinalFishLabel" runat="server" Text='<%# Eval("FinalFish") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EquipmentNameLabel" runat="server" 
                            Text='<%# Eval("EquipmentName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("OverProcessFish") %>' />
                    </td>
                    <td>
                        <asp:Button ID="btnEditConnect" runat="server" CommandName="Select" 
                            Text="設定前站連結" />
                        <asp:Label ID="PreProcessSchedualIDLabels" runat="server" 
                            Text='<%# Eval("PreProcessSchedualEquipmentNames") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" 
            DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual" 
            DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" 
            TypeName="ColdRollingProcess.ProcessSchedualEdit" UpdateMethod="Update">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="TextBox1" Name="FilterEquipmentNames" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsStationSearch" runat="server" 
            SelectMethod="SearchAllStation" 
            TypeName="ColdRollingProcess.ProcessSchedualEdit"></asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:Button ID="btnCancelToSet" runat="server" Text="取消設定" />
        <asp:Button ID="btnClearAllConnect" runat="server" Text="清除所有連結設定" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" TargetControlID="btnClearAllConnect" ConfirmText="是否確定清除所有連結?" runat="server">
        </cc1:ConfirmButtonExtender>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="odsSearchResult1">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="設定為前一站" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="FinalFish" HeaderText="最終表面" 
                    SortExpression="FinalFish" />
                <asp:BoundField DataField="EquipmentName" HeaderText="設備名稱" 
                    SortExpression="EquipmentName" />
                <asp:BoundField DataField="PreProcessSchedualEquipmentNames" 
                    HeaderText="前站設備名稱" ReadOnly="True" 
                    SortExpression="PreProcessSchedualEquipmentNames" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
            SelectMethod="SearchConnectNodes" 
            TypeName="ColdRollingProcess.ProcessSchedualEdit">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfConnectNodeID" 
                    Name="SetConnectProcessSchedualID" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View3" runat="server">
        <asp:Button ID="btnGoBack" runat="server" Text="返回" Width="100px" />
        <uc1:ProcessToInOutOperationLineNameEdit ID="ProcessToInOutOperationLineNameEdit1" 
            runat="server" />
    </asp:View>
</asp:MultiView>



<asp:HiddenField ID="hfConnectNodeID" runat="server" />




