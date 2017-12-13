<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowContractRateEdit.ascx.vb" Inherits="Financial.BorrowContractRateEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>





<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%">
    <cc1:TabPanel runat="server" HeaderText="銀行搜尋" ID="TabPanel1">
        <HeaderTemplate>
            銀行搜尋
        </HeaderTemplate>
    <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    銀行:</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" 
                        DataSourceID="ODSBankInfo" DataTextField="BANKNM" DataValueField="BANKN1">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSBankInfo" runat="server" 
                        SelectMethod="SearchBankInfo" TypeName="Financial.BorrowContractRateEdit">
                    </asp:ObjectDataSource>
                    </td>
            </tr>
            <tr>
                <td class="style3">
                    合約種類:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="120px">
                        <asp:ListItem Value="ALL">全部</asp:ListItem>
                        <asp:ListItem Value="S1">短期借款</asp:ListItem>
                        <asp:ListItem Value="S2">透支</asp:ListItem>
                        <asp:ListItem Value="S3">LC</asp:ListItem>
                        <asp:ListItem Value="S4">商業本票</asp:ListItem>
                        <asp:ListItem Value="S5">工程保證</asp:ListItem>
                        <asp:ListItem Value="L1">長期借款</asp:ListItem>
                        <asp:ListItem Value="L2">長期循環</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    查詢:</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢" Width="100px" />
                </td>
            </tr>

        </table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="BankNumber,ContractKind,StartDate" 
            DataSourceID="LDSSearchResult">
            <Columns>
                <asp:CommandField SelectText="編修利率" ShowSelectButton="True" />
                <asp:BoundField DataField="BankName" HeaderText="銀行名稱" ReadOnly="True" 
                    SortExpression="BankName" />
                <asp:BoundField DataField="BankNumber" HeaderText="銀行編號" ReadOnly="True" 
                    SortExpression="BankNumber" />
                <asp:BoundField DataField="ContractKindName" HeaderText="合約種類" ReadOnly="True" 
                    SortExpression="ContractKindName" />
                <asp:BoundField DataField="CreditMoneyName" HeaderText="幣別" ReadOnly="True" 
                    SortExpression="CreditMoneyName" />
                <asp:BoundField DataField="PayRateKindName" HeaderText="付息方式" ReadOnly="True" 
                    SortExpression="PayRateKindName" />
                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" 
                    HeaderText="合約啟始日" ReadOnly="True" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="合約終止日" 
                    SortExpression="EndDate" />
                <asp:BoundField DataField="PayRateMoneyDayNumber" HeaderText="每月付息日" 
                    SortExpression="PayRateMoneyDayNumber" />
                <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
            </Columns>
            <SelectedRowStyle BackColor="#66FF99" />
        </asp:GridView>
        <asp:LinqDataSource ID="LDSSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.FincialDataContext" 
            TableName="BorrowContract" OrderBy="BankNumber">
        </asp:LinqDataSource>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="利率編修" ID="TabPanel2" Visible="False" >
     <ContentTemplate>
     <p>
         <table style="width:100%;">
             <tr>
                 <td class="style1">
                     篩選有效期間:</td>
                 <td>
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                         RepeatDirection="Horizontal" AutoPostBack="True">
                         <asp:ListItem Selected="True" Value="2">不篩選</asp:ListItem>
                         <asp:ListItem Value="1">篩選</asp:ListItem>
                     </asp:RadioButtonList>
                     <asp:Button ID="btnRefresh" runat="server" Text="重整" />
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                         TargetControlID="TextBox1" Enabled="True">
                     </cc1:CalendarExtender>
                     ~<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                         TargetControlID="TextBox2" Enabled="True">
                     </cc1:CalendarExtender>
                 </td>
             </tr>
         </table>
         <asp:LinqDataSource ID="LDSSearchResult1" runat="server" 
             ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
             EnableInsert="True" EnableUpdate="True" TableName="BorrowContractRate">
         </asp:LinqDataSource>
         <asp:ListView ID="ListView1" runat="server" 
             DataKeyNames="BankNumber,ContractKind,StartDate,RateStartDate" 
             DataSourceID="LDSSearchResult1" InsertItemPosition="LastItem">
             <ItemTemplate>
                 <tr style="background-color:#DCDCDC;color: #000000;">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                         <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                         </cc1:ConfirmButtonExtender>
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                     </td>
                     <td>
                         <asp:Label ID="RateStartDateLabel" runat="server" 
                             Text='<%# Eval("RateStartDate","{0:D}") %>'  />
                     </td>
                     <td>
                         <asp:Label ID="RateEndDateLabel" runat="server" 
                             Text='<%# Eval("RateEndDate","{0:D}") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
                     </td>
                 </tr>
             </ItemTemplate>
             <AlternatingItemTemplate>
                 <tr style="background-color:#FFF8DC;">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                         <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                         </cc1:ConfirmButtonExtender>
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                     </td>
                     <td>
                         <asp:Label ID="RateStartDateLabel" runat="server" 
                             Text='<%# Eval("RateStartDate","{0:D}") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateEndDateLabel" runat="server" 
                             Text='<%# Eval("RateEndDate","{0:D}") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
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
                         <asp:TextBox ID="BankNumberTextBox" runat="server" 
                             Text='<%# Bind("BankNumber") %>' Visible="false" />
                         <asp:TextBox ID="ContractKindTextBox" runat="server" 
                             Text='<%# Bind("ContractKind") %>' Visible="false" />
                         <asp:TextBox ID="StartDateTextBox" runat="server" 
                             Text='<%# Bind("StartDate") %>' Visible="false" />
                     </td>
                     <td>
                         <asp:TextBox ID="RateStartDateTextBox" runat="server" 
                             Text='<%# Bind("RateStartDate") %>' />
                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" TargetControlID="RateStartDateTextBox">
                         </cc1:CalendarExtender>
                     </td>
                     <td>
                         <asp:TextBox ID="RateEndDateTextBox" runat="server" 
                             Text='<%# Bind("RateEndDate") %>' />
                         <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy/MM/dd" TargetControlID="RateEndDateTextBox">
                         </cc1:CalendarExtender>
                     </td>
                     <td>
                         <asp:TextBox ID="RateTextBox" runat="server" Text='<%# Bind("Rate") %>' />
                     </td>
                     <td>
                         <asp:CustomValidator ID="CustomValidator1" runat="server" 
                             ControlToValidate="RateStartDateTextBox" ErrorMessage="CustomValidator" 
                             OnServerValidate="CustomValidator1_OnServerValidate"></asp:CustomValidator>
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
                                         利率啟始日期</th>
                                     <th runat="server">
                                         利率終止日期</th>
                                     <th runat="server">
                                         利率</th>
                                     <th ID="Th1" runat="server">
                                         其它訊息</th>
                                </tr>
                                 <tr runat="server" ID="itemPlaceholder">
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
             <EditItemTemplate>
                 <tr style="background-color:#008A8C;color: #FFFFFF;">
                     <td>
                         <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                         <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                          <asp:Label ID="BankNumberLabel1" runat="server" 
                             Text='<%# Eval("BankNumber") %>' Visible="false" />
                         <asp:Label ID="ContractKindLabel1" runat="server" 
                             Text='<%# Eval("ContractKind") %>' Visible="false" />
                         <asp:Label ID="StartDateLabel1" runat="server" 
                             Text='<%# Eval("StartDate") %>' Visible="false" />
                    </td>
                     <td>
                         <asp:Label ID="RateStartDateLabel1" runat="server" 
                             Text='<%# Eval("RateStartDate","{0:D}") %>'/>
                     </td>
                     <td>
                         <asp:TextBox ID="RateEndDateTextBox" runat="server" 
                             Text='<%# Bind("RateEndDate","{0:D}") %>' />
                         <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="RateEndDateTextBox" Format="yyyy/MM/dd">
                         </cc1:CalendarExtender>    
                     </td>
                     <td>
                         <asp:TextBox ID="RateTextBox" runat="server" Text='<%# Bind("Rate") %>' />
                     </td>
                     <td>
                         <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="CustomValidator" ControlToValidate="RateEndDateTextBox" OnServerValidate="CustomValidator2_OnServerValidate"></asp:CustomValidator>
                     </td>
                 </tr>
             </EditItemTemplate>
             <SelectedItemTemplate>
                 <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                     </td>
                     <td>
                         <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="ContractKindNameLabel" runat="server" 
                             Text='<%# Eval("ContractKindName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PayRateKindNameLabel" runat="server" 
                             Text='<%# Eval("PayRateKindName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="About_BorrowContractLabel" runat="server" 
                             Text='<%# Eval("About_BorrowContract") %>' />
                     </td>
                     <td>
                         <asp:Label ID="BankNumberLabel" runat="server" 
                             Text='<%# Eval("BankNumber") %>' />
                     </td>
                     <td>
                         <asp:Label ID="ContractKindLabel" runat="server" 
                             Text='<%# Eval("ContractKind") %>' />
                     </td>
                     <td>
                         <asp:Label ID="StartDateLabel" runat="server" Text='<%# Eval("StartDate") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateStartDateLabel" runat="server" 
                             Text='<%# Eval("RateStartDate") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateEndDateLabel" runat="server" 
                             Text='<%# Eval("RateEndDate") %>' />
                     </td>
                     <td>
                         <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
                     </td>
                     <td>
                         <asp:Label ID="BorrowContractLabel" runat="server" 
                             Text='<%# Eval("BorrowContract") %>' />
                     </td>
                 </tr>
             </SelectedItemTemplate>
         </asp:ListView>
         </p>
    </ContentTemplate>

   </cc1:TabPanel>
</cc1:TabContainer>

