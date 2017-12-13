<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AS400SQLQuery.ascx.vb" Inherits="OtherOperator.AS400SQLQuery" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Height="1000px" Width="100%" TabIndex="1">
    <cc1:TabPanel runat="server" HeaderText="AS400 SQL查詢" ID="TabPanel1">
   <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td>
                    <span lang="zh-tw">查詢指令:</span></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="50px" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnRunSQL" runat="server" Text="執行查詢指令" style="width: 118px" />
                    <asp:Button ID="btnClear" runat="server" Text="清除查詢指令" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        ConfirmText="是否確定要對AS400執行查詢?" Enabled="True" TargetControlID="btnRunSQL">
                    </cc1:ConfirmButtonExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <span lang="zh-tw">說明:</span></td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" 
                        Text="例:Select * from @#Library.File.Member as A Where A.欄位='XXX'"></asp:Label>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="http://publib.boulder.ibm.com/pubs/html/as400/v5r1/ic2987/index.htm?info/db2/rbafzmst02.htm">(AS400SQL參考)</asp:HyperLink>
                </td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="SearchQueryView" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td align="right" >
                            <span lang="zh-tw">資料轉換下載:</span></td>
                        <td>
                            <asp:Button ID="btnConverToExcel" runat="server" Text="將查詢結果轉換為EXCEL並下載" 
                                Width="248px" />
                            <asp:HiddenField ID="HFSQLString" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <span lang="zh-tw">查詢結果:</span></td>
                        <td>
                            <asp:Label ID="labSearchResult0" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" EnableViewState="False">
                </asp:GridView>
            </asp:View>
            <asp:View ID="DynamicQueryView" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td align="right" >
                            <span lang="zh-tw">您執行的查詢類型:</span></td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                RepeatDirection="Horizontal" Enabled="False">
                                <asp:ListItem>新增查詢</asp:ListItem>
                                <asp:ListItem>修改查詢</asp:ListItem>
                                <asp:ListItem>刪除查詢</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <span lang="zh-tw">查詢結果:</span></td>
                        <td>
                            <asp:Label ID="labSearchResult" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="SQL查詢記錄搜尋" ID="TabPanel2">
   <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td>
                    <span lang="zh-tw">查詢類型:</span></td>
                <td >
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">查詢</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">新增</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">修改</asp:ListItem>
                        <asp:ListItem Selected="True" Value="4">刪除</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <span lang="zh-tw">查詢時間:</span></td>
                <td >
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="Textbox2" Enabled="True" Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TextBox3" Enabled="True" Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <span lang="zh-tw">~</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <span lang="zh-tw">查詢IP:</span></td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <span lang="zh-tw">查詢使用者:</span></td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="搜尋" />
                    <asp:Button ID="btnClearSearch" runat="server" Text="清除" Height="21px" />
                    <asp:Button ID="btnDeleteHistory" runat="server" Text="清除歷史資料" 
                        Visible="False" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        ConfirmText="是否確定要刪除?" TargetControlID="btnDeleteHistory">
                    </cc1:ConfirmButtonExtender>
                 </td>
            </tr>
      </table>
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="QueryString" 
            DataSourceID="LDSSearchResult" PageSize="50">
            <PagerSettings PageButtonCount="30" Position="Top" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="再次執行此查詢" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="QueryTypeExposition" HeaderText="查詢類型" 
                    ReadOnly="True" SortExpression="QueryTypeExposition" />
                <asp:BoundField DataField="QueryString" HeaderText="查詢字串" ReadOnly="True" 
                    SortExpression="QueryString" />
                <asp:BoundField DataField="ModifyRecordCount" HeaderText="執行筆數" ReadOnly="True" 
                    SortExpression="ModifyRecordCount" />
                <asp:BoundField DataField="RunPCIP" HeaderText="用戶端IP" ReadOnly="True" 
                    SortExpression="RunPCIP" />
                <asp:BoundField DataField="RunUser" HeaderText="Window帳號" ReadOnly="True" 
                    SortExpression="RunUser" />
                <asp:BoundField DataField="RunTime" HeaderText="執行時間" ReadOnly="True" 
                    SortExpression="RunTime" />
                <asp:CheckBoxField DataField="IsRunSuccess" HeaderText="是否執行成功" ReadOnly="True" 
                    SortExpression="IsRunSuccess" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LDSSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.OtherOperatorDataContext" 
            Select="new (QueryTypeExposition, QueryString, ModifyRecordCount, RunPCIP, RunUser, RunTime, IsRunSuccess)" 
            TableName="AS400QueryRecord">
        </asp:LinqDataSource>
    </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>

