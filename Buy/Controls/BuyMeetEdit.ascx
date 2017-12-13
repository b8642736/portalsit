<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BuyMeetEdit.ascx.vb" Inherits="Buy.BuyMeetEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 104px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="開標日期:" 
                TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbMeetDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">輸入工號:</td>
        <td>
            <asp:TextBox ID="tbEmployeeID" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            金額種類:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="1">100萬(不含)以下1室</asp:ListItem>
                <asp:ListItem Value="2">100~1000(不含)萬2室</asp:ListItem>
                <asp:ListItem Value="3">1000萬以上3室</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" 
                CausesValidation="False" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
    EnableModelValidation="True" InsertItemPosition="LastItem" 
    DataKeyNames="MTSB01">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="False" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="False"  />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
            </td>
            <td style="display: none">
                <asp:Label ID="MTSB01Label" runat="server" Text='<%# Eval("MTSB01") %>' />
                <asp:HiddenField ID="hfMTSB08" runat="server" Value='<%# Eval("MTSB08") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB02Label" runat="server" Text='<%# Eval("MTSB02") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB03Label" runat="server" Text='<%# Eval("MTSB03") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB04Label" runat="server" Text='<%# Eval("MTSB04") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB05Label" runat="server" Text='<%# Eval("MTSB05Descript") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB06Label" runat="server" Text='<%# Eval("MTSB06Descript") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB07Label" runat="server" Text='<%# Eval("MTSB07") %>' />
            </td>
             <td>
                <asp:Label ID="MTSB08Label" runat="server" Text='<%# Eval("MTSB08") %>' />
            </td>
       </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" CausesValidation="False"  />
            </td>
            <td style="display: none">
                <asp:TextBox ID="MTSB01TextBox" runat="server" Text='<%# Bind("MTSB01") %>' />
                <asp:HiddenField ID="hfMTSB08" runat="server" Value='<%# Bind("MTSB08") %>' />
            </td>
            <td>
                <asp:TextBox ID="MTSB02TextBox" runat="server" Text='<%# Bind("MTSB02") %>'  Width="80"/>
            </td>
            <td>
                <asp:TextBox ID="MTSB03TextBox" runat="server" Text='<%# Bind("MTSB03") %>' />
            </td>
            <td>
                <asp:TextBox ID="MTSB04TextBox" runat="server" Text='<%# Bind("MTSB04") %>' />
            </td>
            <td>
                <%--<asp:TextBox ID="MTSB05TextBox" runat="server" Text='<%# Bind("MTSB05") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("MTSB05") %>'  Width="120px">
                    <asp:ListItem Value="1">100(不含)萬以下</asp:ListItem>
                    <asp:ListItem Value="2">100~1000(不含)萬</asp:ListItem>
                    <asp:ListItem Value="3">1000萬以上</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="MTSB06TextBox" runat="server" Text='<%# Bind("MTSB06") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("MTSB06") %>'  Width="50px">
                    <asp:ListItem Value="1">1室</asp:ListItem>
                    <asp:ListItem Value="2">2室</asp:ListItem>
                    <asp:ListItem Value="3">3室</asp:ListItem>
                    <asp:ListItem Value="4">4室</asp:ListItem>
                    <asp:ListItem Value="5">1樓</asp:ListItem>
                    <asp:ListItem Value="6">5室</asp:ListItem>
                    <asp:ListItem Value="7">6室</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="MTSB07TextBox" runat="server" Text='<%# Bind("MTSB07") %>' />
            </td>
             <td>
                <asp:Label ID="MTSB08Label" runat="server" Text='自動取得' />
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
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" CausesValidation="False"  />
            </td>
            <td style="display: none">
                <asp:TextBox ID="MTSB01TextBox" runat="server" Text='<%# Bind("MTSB01") %>' />
                <asp:HiddenField ID="hfMTSB08" runat="server" Value='<%# Bind("MTSB08") %>' />
            </td>
            <td>
                <asp:TextBox ID="MTSB02TextBox" runat="server" Text='<%# Bind("MTSB02") %>' Width="80"/>
            </td>
            <td>
                <asp:TextBox ID="MTSB03TextBox" runat="server" Text='<%# Bind("MTSB03") %>' Width="80" />
            </td>
            <td>
                <asp:TextBox ID="MTSB04TextBox" runat="server" Text='<%# Bind("MTSB04") %>' Width="80" />
            </td>
            <td>
                <%--<asp:TextBox ID="MTSB05TextBox" runat="server" Text='<%# Bind("MTSB05") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("MTSB05") %>'  Width="120px">
                    <asp:ListItem Value="1">100(不含)萬以下</asp:ListItem>
                    <asp:ListItem Value="2">100~1000(不含)萬</asp:ListItem>
                    <asp:ListItem Value="3">1000萬以上</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="MTSB06TextBox" runat="server" Text='<%# Bind("MTSB06") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("MTSB06") %>'  Width="50px">
                    <asp:ListItem Value="1">1室</asp:ListItem>
                    <asp:ListItem Value="2">2室</asp:ListItem>
                    <asp:ListItem Value="3">3室</asp:ListItem>
                    <asp:ListItem Value="4">4室</asp:ListItem>
                    <asp:ListItem Value="5">1樓</asp:ListItem>
                    <asp:ListItem Value="6">5室</asp:ListItem>
                    <asp:ListItem Value="7">6室</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="MTSB07TextBox" runat="server" Text='<%# Bind("MTSB07") %>' Width="260" />
            </td>
             <td>
                <asp:Label ID="MTSB08Label" runat="server" Text='自動取得' />
            </td>
        </tr>
        <tr>
            <td>訊息:</td>
            <td style="display: none"></td>
            <td colspan="7">
                <asp:CustomValidator ID="InsertCustomValidator1" runat="server" OnServerValidate="InsertCustomValidator1_ServerValidate" ></asp:CustomValidator>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="False"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="False"  />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
            </td>
            <td style="display: none">
                <asp:Label ID="MTSB01Label" runat="server" Text='<%# Eval("MTSB01") %>' />
                <asp:HiddenField ID="hfMTSB08" runat="server" Value='<%# Eval("MTSB08") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB02Label" runat="server" Text='<%# Eval("MTSB02") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB03Label" runat="server" Text='<%# Eval("MTSB03") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB04Label" runat="server" Text='<%# Eval("MTSB04") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB05Label" runat="server" Text='<%# Eval("MTSB05Descript") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB06Label" runat="server" Text='<%# Eval("MTSB06Descript") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB07Label" runat="server" Text='<%# Eval("MTSB07") %>' />
            </td>
             <td>
                <asp:Label ID="MTSB08Label" runat="server" Text='<%# Eval("MTSB08") %>' />
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
                            <th runat="server" style="display: none">
                                記錄時間</th>
                            <th runat="server">
                                開標日期</th>
                            <th runat="server">
                                開標時間起</th>
                            <th runat="server">
                                開標時間訖</th>
                            <th runat="server">
                                開標金額類別</th>
                            <th runat="server">
                                使用開標室</th>
                            <th runat="server">
                                案號品名</th>
                            <th id="Th1" runat="server">
                                輸入工號</th>
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
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="False"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="False"  />
            </td>
            <td style="display: none">
                <asp:Label ID="MTSB01Label" runat="server" Text='<%# Eval("MTSB01") %>' />
                <asp:HiddenField ID="hfMTSB08" runat="server" Value='<%# Eval("MTSB08") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB02Label" runat="server" Text='<%# Eval("MTSB02") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB03Label" runat="server" Text='<%# Eval("MTSB03") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB04Label" runat="server" Text='<%# Eval("MTSB04") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB05Label" runat="server" Text='<%# Eval("MTSB05") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB06Label" runat="server" Text='<%# Eval("MTSB06") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB07Label" runat="server" Text='<%# Eval("MTSB07") %>' />
            </td>
            <td>
                <asp:Label ID="MTSB08Label" runat="server" Text='<%# Eval("MTSB08") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.MTS600LB.MTSBC1PF" DeleteMethod="CDBDelete" 
    InsertMethod="CDBInsert" SelectMethod="Search" TypeName="Buy.BuyMeetEdit" 
    UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQrystring" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQrystring" runat="server" />


