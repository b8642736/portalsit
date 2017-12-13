<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PickGoodDetailSearch.ascx.vb" Inherits="Business.PickGoodDetailSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .auto-style2 {
        width: 107px;
    }
    .auto-style3 {
        width: 151px;
    }
</style>

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="868px" Width="100%">
    <cc1:TabPanel runat="server" HeaderText="提貨明細對帳查詢" ID="TabPanel1">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">客戶代碼:</td>
                    <td>
                        <asp:TextBox ID="tbCustomers" runat="server" Width="215px"></asp:TextBox>
                        (兩個以上請以 &#39;,&#39; 區分)</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:CheckBox ID="cbPickGoodDate" runat="server" Text="提貨日期" TextAlign="Left" />
                        :</td>
                    <td>
                        <asp:TextBox ID="tbPickGoodStartDate" runat="server" Width="100px"></asp:TextBox>
                        ~<asp:TextBox ID="tbPickGoodEndDate" runat="server" Width="100px"></asp:TextBox>
                        (民國年)</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:CheckBox ID="cbTypeOrderDate" runat="server" Text="打單日期" TextAlign="Left" />
                        :</td>
                    <td>
                        <asp:TextBox ID="tbTypeOrderStartDate" runat="server" Width="100px"></asp:TextBox>
                        ~<asp:TextBox ID="tbTypeOrderEndDate" runat="server" Width="100px"></asp:TextBox>
                        (民國年)</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearchData" runat="server" Text="資料查詢" Width="100px" />
                        <asp:Button ID="btnSearchDataToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchData" EnableModelValidation="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="客戶" HeaderText="客戶" SortExpression="客戶" />
                    <asp:BoundField DataField="銀行" HeaderText="銀行" SortExpression="銀行" />
                    <asp:BoundField DataField="LC號碼" HeaderText="LC號碼" SortExpression="LC號碼" />
                    <asp:BoundField DataField="收款金額" HeaderText="收款金額" SortExpression="收款金額" />
                    <asp:BoundField DataField="收款單" HeaderText="收款單" SortExpression="收款單" />
                    <asp:BoundField DataField="統一發票" HeaderText="統一發票" SortExpression="統一發票" />
                    <asp:BoundField DataField="提貨單號" HeaderText="提貨單號" SortExpression="提貨單號" />
                    <asp:BoundField DataField="鋼捲編號" HeaderText="鋼捲編號" SortExpression="鋼捲編號" />
                    <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                    <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                    <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                    <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
                    <asp:BoundField DataField="等級" HeaderText="等級" SortExpression="等級" />
                    <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                    <asp:BoundField DataField="報價單號" HeaderText="報價單號" SortExpression="報價單號" />
                    <asp:BoundField DataField="貨款" HeaderText="貨款" SortExpression="貨款" />
                    <asp:BoundField DataField="利息" HeaderText="利息" SortExpression="利息" />
                    <asp:BoundField DataField="稅額" HeaderText="稅額" SortExpression="稅額" />
                    <asp:BoundField DataField="提貨日" HeaderText="提貨日" SortExpression="提貨日" />
                    <asp:BoundField DataField="打單日" HeaderText="打單日" SortExpression="打單日" />
                    <asp:BoundField DataField="一級" HeaderText="一級" SortExpression="一級" />
                    <asp:BoundField DataField="二級" HeaderText="二級" SortExpression="二級" />
                    <asp:BoundField DataField="三級" HeaderText="三級" SortExpression="三級" />
                    <asp:BoundField DataField="頭尾" HeaderText="頭尾" SortExpression="頭尾" />
                    <asp:BoundField DataField="邊料" HeaderText="邊料" SortExpression="邊料" />
                    <asp:BoundField DataField="廢料" HeaderText="廢料" SortExpression="廢料" />
                    <asp:BoundField DataField="一級品金額" HeaderText="一級品金額" SortExpression="一級品金額" />
                    <asp:BoundField DataField="二級品金額" HeaderText="二級品金額" SortExpression="二級品金額" />
                    <asp:BoundField DataField="三級品金額" HeaderText="三級品金額" SortExpression="三級品金額" />
                    <asp:BoundField DataField="頭尾料金額" HeaderText="頭尾料金額" SortExpression="頭尾料金額" />
                    <asp:BoundField DataField="邊緣料金額" HeaderText="邊緣料金額" SortExpression="邊緣料金額" />
                    <asp:BoundField DataField="廢料金金額" HeaderText="廢料金金額" SortExpression="廢料金金額" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfQueryData" runat="server" />
            <asp:ObjectDataSource ID="odsSearchData" runat="server" SelectMethod="SearchData" TypeName="Business.PickGoodDetailSearch">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQueryData" Name="QryString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" HeaderText="查詢/編修授權" runat="server">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">客戶編號:</td>
                    <td>
                        <asp:TextBox ID="tbCustomerID" runat="server"></asp:TextBox>
                        (兩個以上請以&#39;,&#39;區分)</td>
                </tr>
                <tr>
                    <td class="auto-style2">員工編號:</td>
                    <td>
                        <asp:TextBox ID="tbEmployeeID" runat="server"></asp:TextBox>
                        (兩個以上請以&#39;,&#39;區分)</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="有效日期:" TextAlign="Left" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbCanUseAuthorizationTime" runat="server"></asp:TextBox>
                        (西元年)</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    </td>
                </tr>
            </table>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="WindowLoginName,CUA01,AuthorizationTime">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?');" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        </td>
                        <td>
                            <asp:Label ID="WindowLoginNameLabel" runat="server" Text='<%# Eval("WindowLoginName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CUA01Label" runat="server" Text='<%# Eval("CUA01") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationTimeLabel" runat="server" Text='<%# Eval("AuthorizationTime", "{0:yyyy/MM/dd}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationStartTimeLabel" runat="server" Text='<%# Bind("AuthorizationStartTime", "{0:yyyy/MM/dd}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationDueTimeLabel" runat="server" Text='<%# Bind("AuthorizationDueTime", "{0:yyyy/MM/dd}")%>' />
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
                            <asp:TextBox ID="WindowLoginNameTextBox" runat="server" Text='<%# Bind("WindowLoginName") %>' ReadOnly="true"  BackColor="LightGray" />
                        </td>
                        <td>
                            <asp:TextBox ID="CUA01TextBox" runat="server" Text='<%# Bind("CUA01") %>' ReadOnly="true"  BackColor="LightGray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="AuthorizationTimeTextBox" runat="server" Text='<%# Bind("AuthorizationTime", "{0:yyyy/MM/dd HH:mm:ss}")%>' ReadOnly="true"  BackColor="LightGray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="AuthorizationStartTimeTextBox" runat="server" Text='<%# Bind("AuthorizationStartTime", "{0:yyyy/MM/dd}")%>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AuthorizationDueTimeTextBox" runat="server" Text='<%# Bind("AuthorizationDueTime", "{0:yyyy/MM/dd}")%>' />
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
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                        </td>
                        <td>
                            <asp:TextBox ID="WindowLoginNameTextBox" runat="server" Text='<%# Bind("WindowLoginName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CUA01TextBox" runat="server" Text='<%# Bind("CUA01") %>' />
                        </td>
                        <td>
                            <%--<asp:TextBox ID="AuthorizationTimeTextBox" runat="server" Text='<%# Bind("AuthorizationTime") %>' />--%>
                            (自動建立)
                        </td>
                        <td>
                            <asp:TextBox ID="AuthorizationStartTimeTextBox" runat="server" Text='<%# Bind("AuthorizationStartTime") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AuthorizationDueTimeTextBox" runat="server" Text='<%# Bind("AuthorizationDueTime") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?');"  />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        </td>
                        <td>
                            <asp:Label ID="WindowLoginNameLabel" runat="server" Text='<%# Eval("WindowLoginName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CUA01Label" runat="server" Text='<%# Eval("CUA01") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationTimeLabel" runat="server" Text='<%# Eval("AuthorizationTime", "{0:yyyy/MM/dd}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationStartTimeLabel" runat="server" Text='<%# Bind("AuthorizationStartTime", "{0:yyyy/MM/dd}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationDueTimeLabel" runat="server" Text='<%# Bind("AuthorizationDueTime", "{0:yyyy/MM/dd}") %>' />
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
                                        <th runat="server">登入工號</th>
                                        <th runat="server">客戶編號</th>
                                        <th runat="server">建檔時間</th>
                                        <th runat="server">授權起始時間</th>
                                        <th runat="server">授權結束時間</th>
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
                            <asp:Label ID="WindowLoginNameLabel" runat="server" Text='<%# Eval("WindowLoginName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CUA01Label" runat="server" Text='<%# Eval("CUA01") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationTimeLabel" runat="server" Text='<%# Eval("AuthorizationTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationStartTimeLabel" runat="server" Text='<%# Eval("AuthorizationStartTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AuthorizationDueTimeLabel" runat="server" Text='<%# Eval("AuthorizationDueTime") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:HiddenField ID="hfQryString" runat="server" />

            <asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="WebLoginAccountToPickGoodDetailSearch" TypeName="Business.PickGoodDetailSearch" UpdateMethod="CDBUpdate">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="代理人批次授權">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td colspan="4">複製來源條件:</td>
                </tr>
                <tr>
                    <td>授權來源號:</td>
                    <td colspan="3"><asp:TextBox ID="tbCopyLoginEmployeeID" runat="server"></asp:TextBox>
                        <a style="color:red;font-size=12;">(必填,輸入工號代表將此人之所有客戶授權出去)</a></td>
                </tr>
                <tr>
                    <td>授權指定客戶編號:</td>
                    <td colspan="3">
                        <asp:TextBox ID="tbCopyCustomerID" runat="server"></asp:TextBox>
                        (選填,如果輸入客戶編號代表只授權此一客戶,如果空白代表所有客戶)(兩個以上請以 &#39;,&#39; 區分)</td>
                </tr>
                <tr>
                    <td>授權目地工號:</td>
                    <td><asp:TextBox ID="tbCopyToEmployeeID" runat="server"></asp:TextBox><a style="color:red;font-size=12;">(必填)</a></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>授權起始日:</td>
                    <td><asp:TextBox ID="tbCopyStartDate" runat="server"></asp:TextBox><a style="color:red;font-size=12;">(必填)</a>西元年</td>
                    <td>授權終止日:</td>
                    <td><asp:TextBox ID="tbCopyEndDate" runat="server"></asp:TextBox><a style="color:red;font-size=12;">(必填)</a>西元年</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnAuthority" runat="server" Text="複製授權" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            <table style="width: 100%;">
                <tr>
                    <td colspan="4">取銷受權</td>
                </tr>
                <tr>
                    <td>取銷授權工號:</td>
                    <td>
                        <asp:TextBox ID="tbCancelEmployeeID" runat="server"></asp:TextBox>
                        <a style="color:red;font-size=12;">(必填)</a></td>
                    <td>指定客戶編號:</td>
                    <td>
                        <asp:TextBox ID="tbCancelCustomerID" runat="server"></asp:TextBox>
                        (選填,如果空白代表所有客戶)</td>
                </tr>
                <tr>
                    <td>取銷授權起始日:</td>
                    <td>
                        <asp:TextBox ID="tbCancelStartDate" runat="server"></asp:TextBox>
                        <a style="color:red;font-size=12;">(必填)</a>西元年</td>
                    <td>取銷授權終止日:</td>
                    <td>
                        <asp:TextBox ID="tbCancelEndDate" runat="server"></asp:TextBox>
                        <a style="color:red;font-size=12;">(必填)</a>西元年</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelAuthority" runat="server" Text="刪除授權" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            執行訊息:<asp:Label ID="lbMessage" runat="server" Text="無!"></asp:Label>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            <br>
            <br></br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>

