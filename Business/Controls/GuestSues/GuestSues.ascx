<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GuestSues.ascx.vb" Inherits="Business.GuestSues" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="EmployeeSampleSearch.ascx" tagname="EmployeeSampleSearch" tagprefix="uc1" %>
<%@ Register src="CustomerSearch.ascx" tagname="CustomerSearch" tagprefix="uc2" %>
<style type="text/css">
    .style1
    {
        width: 152px;
    }
    .style3
    {
        width: 187px;
    }
</style>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    案件序號:</td>
                <td>
                    <asp:TextBox ID="tbID" runat="server" Width="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    客戶代號:</td>
                <td>
                    <asp:TextBox ID="tbCustomerID" runat="server" Width="50px"></asp:TextBox>
                    <asp:Button ID="btnCustomerSearch" runat="server" Text="查詢" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    承辦人工號:</td>
                <td>
                    <asp:TextBox ID="tbUndertaker" runat="server" Width="80px"></asp:TextBox>
                    <asp:Button ID="btnEmployeeSearch" runat="server" Text="查詢" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:CheckBox ID="cbRecordTime" runat="server" Text="接案時間:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                    ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    處理狀態:</td>
                <td>
                    <asp:DropDownList ID="ddCaseState" runat="server" Width="100px">
                        <asp:ListItem Value="ALL">全部狀態</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">未結案</asp:ListItem>
                        <asp:ListItem Value="2">已結案</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    系統登入帳號:</td>
                <td>
                    <asp:TextBox ID="tbWindowLoginName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:CheckBox ID="CBOverTime" runat="server" Text="接案到現在時間:" TextAlign="Left" />
                </td>
                <td>
                    超過<asp:TextBox ID="tbOverDays" 
                        runat="server" Width="49px">1</asp:TextBox>
                    天<asp:TextBox ID="tbOverHours" runat="server" Width="49px">0</asp:TextBox>
                    小時</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                        Width="100px" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:Button ID="btnBackSearchForm" runat="server" Text="返回案件查尋畫面" Height="50px" 
            Width="185px" />
    </asp:View>
</asp:MultiView>

<asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
    <asp:View ID="MV2View1" runat="server">
<asp:ListView ID="ListView1" runat="server" DataSourceID="ldsSearchResult" 
    EnableModelValidation="True" DataKeyNames="ID,SubRecordNumber"
    InsertItemPosition="LastItem">
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td rowspan="2">
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="是否確定刪除?" TargetControlID="DeleteButton" runat="server">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="tbDetailLookEdit" runat="server" CommandName="DetailEdit" Text="查看編輯細目" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubRecordNumberLabel" runat="server" 
                            Text='<%# Eval("SubRecordNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                        (<asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerName") %>' />)
                    </td>
                    <td>
                        <asp:Label ID="ContectHumanLabel" runat="server" 
                            Text='<%# Eval("ContectHuman") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UndertakerLabel" runat="server" 
                            Text='<%# Eval("UndertakerName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RecordTimeLabel" runat="server" 
                            Text='<%# Eval("RecordTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProcessStateLabel" runat="server" 
                            Text='<%# Eval("ProcessStateName") %>' />
                    </td>
                    <td>
                        <asp:HiddenField ID="HFWindowLoginName" Value='<%# Eval("WindowLoginName") %>' runat="server" />
                        <asp:Label ID="WindowLoginNameLabel" runat="server" 
                            Text='<%# Eval("WindowLoginNameName") %>' />
                    </td>
                </tr>
                <tr  style="background-color:#DCDCDC;color: #000000;">
                    <td colspan="8">
                        <asp:Label ID="DescribeLabel" runat="server" Text='<%# Eval("Describe") %>' />
                        <%--<asp:TextBox ID="DescribeTextBox" runat="server"  TextMode="MultiLine" Wrap="true" ReadOnly="true" BorderStyle="None"  Text='<%# Eval("Describe") %>'/>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td rowspan="2">
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="是否確定刪除?" TargetControlID="DeleteButton" runat="server">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        <asp:Button ID="tbDetailLookEdit" runat="server" CommandName="DetailEdit" Text="查看編輯細目" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubRecordNumberLabel" runat="server" 
                            Text='<%# Eval("SubRecordNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                        (<asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerName") %>' />)
                    </td>
                    <td>
                        <asp:Label ID="ContectHumanLabel" runat="server" 
                            Text='<%# Eval("ContectHuman") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UndertakerLabel" runat="server" 
                            Text='<%# Eval("UndertakerName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RecordTimeLabel" runat="server" 
                            Text='<%# Eval("RecordTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProcessStateLabel" runat="server" 
                            Text='<%# Eval("ProcessStateName") %>' />
                    </td>
                    <td>
                         <asp:HiddenField ID="HFWindowLoginName" Value='<%# Eval("WindowLoginName") %>' runat="server" />
                       <asp:Label ID="WindowLoginNameLabel" runat="server" 
                            Text='<%# Eval("WindowLoginNameName") %>' />
                    </td>
                </tr>
                <tr style="background-color:#FFF8DC;">
                    <td colspan="8" >
                        <asp:Label ID="DescribeLabel" runat="server" Text='<%# Eval("Describe") %>' />
                        <%--<asp:TextBox ID="DescribeTextBox" runat="server"  TextMode="MultiLine" Wrap="true" ReadOnly="true" BorderStyle="None"  Text='<%# Eval("Describe") %>'/>--%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td rowspan="2">
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubRecordNumberLabel1" runat="server" 
                            Text='<%# Eval("SubRecordNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                        (<asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerName") %>' />)
                    </td>
                    <td>
                        <asp:TextBox ID="ContectHumanTextBox" runat="server"  Width="50" 
                            Text='<%# Bind("ContectHuman") %>' />
                        
                    </td>
                    <td>
                        <asp:TextBox ID="UndertakerTextBoxEdit" runat="server"  Width="50" Text='<%# Bind("Undertaker") %>' />
                        <asp:Button ID="btnEmployeeSearch2" runat="server" Text="查詢" OnClick="btnEmployeeSearch2_Click" />
                    </td>
                    <td>
                        <%--<asp:TextBox ID="RecordTimeTextBox" runat="server" 
                            Text='<%# Bind("RecordTime") %>' />--%>
                        (系統產生)
                    </td>
                    <td>
                        <%--<asp:TextBox ID="ProcessStateTextBox" runat="server" 
                            Text='<%# Bind("ProcessState") %>' />--%>
                        <asp:DropDownList ID="DropDownList1" SelectedValue = '<%# Bind("ProcessState") %>' runat="server">
                            <asp:ListItem Selected="True" Value="1">未結案</asp:ListItem>
                            <asp:ListItem Value="2">已結案</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="WindowLoginNameTextBox" runat="server" 
                            Text='<%# Bind("WindowLoginName") %>' />--%>
                        (系統產生)
                    </td>
                </tr>
                <tr  style="background-color:#008A8C;color: #FFFFFF;">
                    <td  colspan="8" >
                        <asp:TextBox ID="DescribeTextBox" runat="server" Text='<%# Bind("Describe") %>' Height="100" Width="100%" TextMode="MultiLine" />
                       <%--<asp:TextBox ID="DescribeTextBox" runat="server" ReadOnly="true"  Text='<%# Eval("Describe") %>' Width="100%" TextMode="MultiLine" />--%>
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
                    <td rowspan="2">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                       <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <%--<asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />--%>
                        <asp:Label ID="lbID" runat="server" Text="(系統產生)"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="SubRecordNumberTextBox" runat="server" 
                            Text='<%# Bind("SubRecordNumber") %>' />--%>
                            (系統產生)
                    </td>
                    <td>
                        <asp:TextBox ID="CustomerIDTextBox" runat="server" Width="50" Text='<%# Bind("CustomerID") %>' />
                        <asp:Button ID="btnCustomerSearch1" runat="server" Text="查詢" OnClick="btnCustomerSearch1_Click" />
                    </td>
                    <td>
                        <asp:TextBox ID="ContectHumanTextBox" Width="50" runat="server" 
                            Text='<%# Bind("ContectHuman") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="UndertakerTextBox" Width="50" runat="server" 
                            Text='<%# Bind("Undertaker") %>' />
                        <asp:Button ID="btnEmployeeSearch1" runat="server" Text="查詢" OnClick="btnEmployeeSearch1_Click" />
                    </td>
                    <td>
                        <%--<asp:TextBox ID="RecordTimeTextBox" runat="server" 
                            Text='<%# Bind("RecordTime") %>' />--%>
                        (系統產生)
                    </td>
                    <td>
                        <%--<asp:TextBox ID="ProcessStateTextBox" runat="server" 
                            Text='<%# Bind("ProcessState") %>' />--%>
                        <asp:DropDownList ID="DropDownList1"  SelectedValue = '<%# Bind("ProcessState") %>'  runat="server">
                            <asp:ListItem Selected="True" Value="1">未結案</asp:ListItem>
                            <asp:ListItem Value="2">已結案</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="WindowLoginNameTextBox" runat="server" 
                            Text='<%# Bind("WindowLoginName") %>' />--%>
                        (系統產生)
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:TextBox ID="DescribeTextBox" runat="server"  Width="100%" Text='<%# Bind("Describe") %>' TextMode="MultiLine" Height="100" />
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
                                    <th runat="server" rowspan="2">
                                    </th>
                                    <th runat="server">
                                        案件序號</th>
                                    <th runat="server">
                                        訊息編號</th>
                                    <th runat="server">
                                        客戶代號</th>
                                    <th runat="server">
                                        連絡人</th>
                                    <th runat="server">
                                        承辦人工號</th>
                                    <th runat="server">
                                        記錄時間</th>
                                    <th runat="server">
                                        案件狀態</th>
                                    <th runat="server">
                                        系統登入者</th>
                                </tr>
                                <tr style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server" colspan="8">
                                        案件描述</th>
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
                    <tr  runat="server">
                        <td>訊息:<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td rowspan="2">
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubRecordNumberLabel" runat="server" 
                            Text='<%# Eval("SubRecordNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContectHumanLabel" runat="server" 
                            Text='<%# Eval("ContectHuman") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UndertakerLabel" runat="server" 
                            Text='<%# Eval("Undertaker") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RecordTimeLabel" runat="server" 
                            Text='<%# Eval("RecordTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProcessStateLabel" runat="server" 
                            Text='<%# Eval("ProcessState") %>' />
                    </td>
                    <td>
                        <asp:Label ID="WindowLoginNameLabel" runat="server" 
                            Text='<%# Eval("WindowLoginNameName") %>' />
                    </td>
                </tr>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td colspan="8">
                        <asp:Label ID="DescribeLabel" runat="server" Text='<%# Eval("Describe") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="WatchTime,FK_GuestSuesID" DataSourceID="ldsDetailWatchUsers" 
            EnableModelValidation="True" Visible="False">
            <Columns>
                <asp:BoundField DataField="WindowLoginNameName" HeaderText="查看者" 
                    ReadOnly="True" SortExpression="WindowLoginNameName" />
                <asp:BoundField DataField="WatchTime" HeaderText="查看時間" ReadOnly="True" 
                    SortExpression="WatchTime" />
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="MV2View2" runat="server">
        <uc1:EmployeeSampleSearch ID="EmployeeSampleSearch1" runat="server" />
    </asp:View>
    <asp:View ID="MV2View3" runat="server">
        <uc2:CustomerSearch ID="CustomerSearch1" runat="server" />
    </asp:View>
</asp:MultiView>

<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.BusinessDataContext" TableName="GuestSues" 
    EnableDelete="True" EnableInsert="True" EnableUpdate="True">
</asp:LinqDataSource>
<asp:LinqDataSource ID="ldsDetailWatchUsers" runat="server" 
    ContextTypeName="CompanyLINQDB.BusinessDataContext" 
    TableName="GuestSuesWatchRecord">
</asp:LinqDataSource>











