<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowEdit.ascx.vb" Inherits="Financial.BorrowEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<table style="width: 100%;">
    <tr>
        <td>
<cc1:TabContainer ID="TabContainer1" runat="server"   TabIndex ="0"
    Width="100%" ActiveTabIndex="0">
<cc1:TabPanel ID="TabPanel1" runat="server">
    <HeaderTemplate>
銀行篩選
</HeaderTemplate>
        
<ContentTemplate>
            <style type="text/css">
                .style1
                {
                    width: 85px;
                }
            </style> <table style="width:100%;">
                <tr>
                    <td class="style1">
                        篩選選項:</td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ODSBankInfo" 
                                DataTextField="BANKNM" DataValueField="BANKN1" Width="300px"></asp:DropDownList>


                            <asp:ObjectDataSource ID="ODSBankInfo" runat="server" 
                                SelectMethod="SearchBankInfo" TypeName="Financial.BorrowEdit"></asp:ObjectDataSource>


                        </asp:Panel>


                    </td>
                </tr>
            </table>
        
        
</ContentTemplate>


</cc1:TabPanel>
<cc1:TabPanel ID="TabPanel2" runat="server" >
    <HeaderTemplate>
    合約種類篩選
    
    
</HeaderTemplate>
    
<ContentTemplate>
        <style type="text/css">
            .style1
            {
                width: 100px;
            }
        </style> <table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp; 篩選選項:</td>
                <td >
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="ALL">全部</asp:ListItem>
                            <asp:ListItem Value="S1">短期借款</asp:ListItem>
                            <asp:ListItem Value="S2">透支</asp:ListItem>
                            <asp:ListItem Value="S3">LC</asp:ListItem>
                            <asp:ListItem Value="S4">商業本票</asp:ListItem>
                            <asp:ListItem Value="S5">工程保證</asp:ListItem>
                            <asp:ListItem Value="L1">長期借款</asp:ListItem>
                            <asp:ListItem Value="L2">長期循環</asp:ListItem>
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            

        </table>
    
    
</ContentTemplate>


</cc1:TabPanel>
<cc1:TabPanel ID="TabPanel3"  runat="server" >
<HeaderTemplate>
綜合額度金額分配順序
</HeaderTemplate>
<ContentTemplate>
    <style type="text/css">
        .style1
        {
            width: 123px;
        }
    </style> <table style="width:100%;">
        <tr>
            <td class="style1">
                綜合額度金額分配順序:</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="ListBox2" runat="server" Rows="8" Width="100px">
                            <asp:ListItem Value="BR">利率</asp:ListItem>
                            <asp:ListItem Value="S1">短期借款</asp:ListItem>
                            <asp:ListItem Value="S2">透支</asp:ListItem>
                            <asp:ListItem Value="S3">LC</asp:ListItem>
                            <asp:ListItem Value="S4">商業本票</asp:ListItem>
                            <asp:ListItem Value="S5">工程保證</asp:ListItem>
                            <asp:ListItem Value="L1">長期借款</asp:ListItem>
                            <asp:ListItem Value="L2">長期循環</asp:ListItem>
                        </asp:ListBox>
                        <asp:Button ID="btnUpQuatoPriority" runat="server" Text="優先分配提升" />
                        <asp:Button ID="btnDownQuatoPriority" runat="server" Text="優先分配降低" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel ID="TabPanel4" runat="server">
<HeaderTemplate>
其它選項
</HeaderTemplate>
<ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                合約有效期:
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">現在合約有效期內</asp:ListItem>
                    <asp:ListItem Value="1">不限制(所有合約)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                可用金額:
            </td>
            <td>
                必須大於等於新台幣<asp:TextBox ID="tbSearchMaxNTDollar" runat="server" Width="80px">0</asp:TextBox>
                元</td>
        </tr>
    </table>
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="執行查詢" Width="120" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" Width="120" />
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
<cc1:TabContainer ID="TabContainer2" runat="server" Width="1600px" 
    ActiveTabIndex="3" AutoPostBack="True"  >
    
    <cc1:TabPanel runat="server" ID="TabPanel21">
    <HeaderTemplate>查詢結果</HeaderTemplate>
    <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="BankNumber,ContractKind,StartDate" 
                    DataSourceID="LDSSearchResult" Width="1500px" style="text-align: center">
                    <Columns>
                        <asp:CommandField ButtonType="Button" HeaderText="預備借款名單增修" SelectText="新增/修改" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="BankName" HeaderText="銀行名稱" ReadOnly="True" 
                            SortExpression="BankName" />
                        <asp:BoundField DataField="ContractKindName" HeaderText="合約種類" 
                            ReadOnly="True" SortExpression="ContractKindName" />
                        <asp:BoundField DataField="BankNumber" HeaderText="銀行編號" 
                            ReadOnly="True" SortExpression="BankNumber" />
                        <asp:BoundField DataField="ContractRate" HeaderText="合約利率" 
                            SortExpression="ContractRate" />
                        <asp:BoundField DataField="SubBorrowContractCanUseMoneyByOrderAndFilder" 
                            HeaderText="可借款金額" 
                            SortExpression="SubBorrowContractCanUseMoneyByOrderAndFilder" 
                            DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="CreditMoneyName" HeaderText="幣別名稱" 
                            SortExpression="CreditMoneyName" />
                        <asp:BoundField DataField="RepaymentMonthsToYearMonthString" 
                            HeaderText="還款期限" 
                            SortExpression="RepaymentMonthsToYearMonthString" />
                        <asp:BoundField DataField="StartDate" HeaderText="合約起始日" SortExpression="StartDate" 
                            DataFormatString="{0:d}" ReadOnly="True" />
                        <asp:BoundField DataField="EndDate" HeaderText="合約終止日" 
                            SortExpression="EndDate" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="CreditMoney" HeaderText="合約金額" 
                            SortExpression="CreditMoney" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="RePaymentTimes" HeaderText="還款期數" 
                            SortExpression="RePaymentTimes" />
                        <asp:BoundField DataField="Memo1" HeaderText="備註1" 
                            SortExpression="Memo1" />
                        <asp:BoundField DataField="FK_CompostBankNumber" HeaderText="主約銀行編號" 
                            SortExpression="FK_CompostBankNumber" />
                        <asp:BoundField DataField="FK_CompostStartDate" HeaderText="主約啟始日期" 
                            SortExpression="FK_CompostStartDate" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="AlreadyBorrowMoney" HeaderText="已借款金額" 
                            SortExpression="AlreadyBorrowMoney" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="AlreadyPayUseMoney" DataFormatString="{0:N0}" 
                            HeaderText="已還款金額" SortExpression="AlreadyPayUseMoney" />
                    </Columns>
                    <SelectedRowStyle BackColor="#CCFFFF" BorderColor="#66CCFF" />
                </asp:GridView>
                <asp:LinqDataSource ID="LDSSearchResult" runat="server" 
                    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="BorrowContract">
                </asp:LinqDataSource>
            
            </asp:View>
            <asp:View ID="View2" runat="server">
                    <table class="style4">
                        <tr>
                            <td class="style10">
                                借款/開狀金額:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetBorrowMoney" runat="server"></asp:TextBox>
                                <asp:Label ID="lbPreSetBorrowMoneyKindName" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style7">
                                最高可用額度:</td>
                            <td class="style8">
                                <asp:Label ID="lbMaxCanUseMoney" runat="server"></asp:Label>
                                <asp:Label ID="lbPreSetBorrowMoneyKindName0" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                借款利率:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetBorrowRate" runat="server"></asp:TextBox>
                            </td>
                            <td class="style7">
                                匯率:
                            </td>
                            <td class="style8">
                                <asp:TextBox ID="tbPreSetExchangeRage" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                啟始日:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetStartDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                                    TargetControlID="tbPreSetStartDate" Format="yyyy/MM/dd" Enabled="True">
                                </cc1:CalendarExtender>
                            </td>
                             <td class="style7">
                                 終止日:
                            </td>
                            <td class="style8">
                                <asp:TextBox ID="tbPreSetEndDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                                    TargetControlID="tbPreSetEndDate" Format="yyyy/MM/dd" Enabled="True">
                                </cc1:CalendarExtender>
                            </td>
                       </tr>
                        <tr>
                            <td class="style10">
                                寬緩月數:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetLatePayMonths" runat="server"></asp:TextBox>
                                個月</td>
                             <td class="style7">
                                 &nbsp;</td>
                            <td class="style8">
                                &nbsp;</td>
                       </tr>
                       <tr>
                       <td>付息方式:</td>
                       <td colspan="3">
                           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           <ContentTemplate>
                           <table>
                           <tr>
                               <td>
                                   <asp:DropDownList ID="ddlPreSetPayRateKind" runat="server" Width="160px" 
                                       AutoPostBack="True">
                                       <asp:ListItem Value="1">以月計息</asp:ListItem>
                                       <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
                                       <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
                                       <asp:ListItem Value="4">借款時付息</asp:ListItem>
                                       <asp:ListItem Value="5">到期一次付息</asp:ListItem>
                                   </asp:DropDownList>
                               </td>
                               <td>
                                   <asp:Panel ID="Panel3" Enabled="false" runat="server">
                                   借款付息金額:
                                   <asp:TextBox ID="btPreSetPayRateMoney" runat="server"></asp:TextBox>
                                   </asp:Panel>
                               </td>
                           </tr>
                           </table>
                           </ContentTemplate>
                           </asp:UpdatePanel>
                       </td>
                           
                       </tr>
                        <tr>
                            <td class="style10">
                                還款期數:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetRePaymentTimes" runat="server"></asp:TextBox>
                                期</td>
                             <td class="style7">
                                 存入帳號:
                            </td>
                            <td class="style8">
                                <asp:DropDownList ID="ddlPreSetRePaymentBankNumber" runat="server" 
                                    DataSourceID="ODSPreSetBankInfo" DataTextField="BANKNM" DataValueField="BANKN1" 
                                    Width="300px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ODSPreSetBankInfo" runat="server" 
                                    SelectMethod="SearchBankInfo1" TypeName="Financial.BorrowEdit">
                                </asp:ObjectDataSource>
                            </td>
                       </tr>
                        <tr>
                            <td class="style10">
                                還本日:</td>
                            <td class="style9">
                                <asp:TextBox ID="btPreSetPayPrincipalMoneyDayNumber" runat="server"></asp:TextBox>
                                日</td>
                             <td class="style7">
                                 每月付息日:
                            </td>
                            <td class="style8">
                                <asp:TextBox ID="btPreSetPayRateMoneyDayNumber" runat="server"></asp:TextBox>
                                日</td>
                       </tr>
                        <tr>
                            <td class="style10">
                                備註1:
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="tbPreSetMemo1" runat="server" Width="900px"></asp:TextBox>
                            </td>
                       </tr>
                       
                       
                       
                       
                        <tr>
                            <td class="style10">
                                LCNumber:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="tbPreSetLCNumber" runat="server"></asp:TextBox>
                            </td>
                             <td class="style7">
                                LC案號
                            </td>
                            <td class="style8">
                                <asp:TextBox ID="tbPreSetLCCaseNumber" runat="server"></asp:TextBox>
                            </td>
                       </tr>
                       <tr>
                       <td colspan="4">
                       
                           訊息:<asp:Label ID="LBMsg" runat="server" BackColor="#FF3300"></asp:Label>
                       
                       </td>
                       </tr>
                       <tr>
                            <td class="style10"></td>
                            <td colspan="3">
                                <asp:Button ID="btnAddPreBorrowMenu" runat="server" Text="加入/變更預備借款名單" />
                                <asp:Button ID="btnCancelPreBorrowMenu" runat="server" Text="取消返回查詢結果" />
                            </td>
                       </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="TabPane22">
    <HeaderTemplate>查詢結果統計</HeaderTemplate>
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    銀行數量:<asp:Label ID="lbSumBankCount" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    可借金額合計(台幣):<asp:Label ID="lbSumCanBorrowMoney" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    平均利率:<asp:Label ID="lbAvgContractRate" runat="server" Text="0.0"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="TabPanel23">
    <HeaderTemplate>預計借款分析與決定借款</HeaderTemplate>
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td>
                    銀行數量:<asp:Label ID="lbBankTotalCount" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                預計借款金額合計(台幣):<asp:Label ID="lbTotalPreBorrowMoney" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDesignBorrow" runat="server" Text="決定  借款/LC開狀" 
                        Width="170px" />
                    <asp:Button ID="btnClearPreBorrowItems" runat="server" Text="清除所有預備  借款/開狀清單" 
                        Width="170px" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        ConfirmText="是否確定將以下清單轉為正式借款?" Enabled="True" TargetControlID="btnDesignBorrow">
                    </cc1:ConfirmButtonExtender>
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        ConfirmText="是否確定清除?" Enabled="True" TargetControlID="btnClearPreBorrowItems">
                    </cc1:ConfirmButtonExtender>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" 
            DataKeyNames="BankNumber,ContractKind,ContractStartDate" 
            DataSourceID="ODSPrepareBorrowSearchResult">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <HeaderTemplate>
                        刪除
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" Text="刪除"></asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="LinkButton1" ConfirmText="是否確定刪除?">
                        </cc1:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BankName" HeaderText="銀行名稱" 
                    SortExpression="BankName" ReadOnly="True" />
                <asp:BoundField DataField="ContractKindName" HeaderText="合約種類" 
                    SortExpression="ContractKindName" ReadOnly="True" />
                <asp:BoundField DataField="PrepareBorrowMoney" HeaderText="預備借款金額" 
                    SortExpression="PrepareBorrowMoney" />
                <asp:BoundField DataField="CreditMoneyName" HeaderText="幣別" 
                    SortExpression="CreditMoneyName" ReadOnly="True" />
                <asp:BoundField DataField="PrePareBorrowNTMoney" HeaderText="預備借款台幣" 
                    SortExpression="PrePareBorrowNTMoney" ReadOnly="True" 
                    DataFormatString="{0:N0}" />
                <asp:BoundField DataField="NowBorrowRate" HeaderText="利率" 
                    SortExpression="NowBorrowRate" />
                <asp:BoundField DataField="LCNumber" HeaderText="LCNumber" 
                    SortExpression="LCNumber" />
                <asp:BoundField DataField="ExchangeRate" HeaderText="匯率" 
                    SortExpression="ExchangeRate" />
                <asp:BoundField DataField="LCCaseNumber" HeaderText="LC案號" 
                    SortExpression="LCCaseNumber" />
                <asp:BoundField DataField="BorrowStartDate" HeaderText="借款啟始日" 
                    SortExpression="BorrowStartDate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="BorrowEndDate" HeaderText="借款終止日" 
                    SortExpression="BorrowEndDate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="BankNumber" HeaderText="銀行代碼" 
                    SortExpression="BankNumber" />
                <asp:BoundField DataField="ContractStartDate" HeaderText="合約啟始日期" 
                    SortExpression="ContractStartDate" DataFormatString="{0:d}" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSPrepareBorrowSearchResult" runat="server" 
            SelectMethod="DisplayPrepareBorrorItems" TypeName="Financial.BorrowEdit">
            <SelectParameters>
                <asp:SessionParameter Name="SourceBorrowItem" SessionField="_PrepareBorrowItem" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel24" runat="server" Width="2000px">
    <HeaderTemplate>借款記錄查詢編修</HeaderTemplate>
    <ContentTemplate>
    
        <table width="800PX">
            <tr>
                <td class="style3">
                    借款銀行:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ODSBankInfo1" 
                        DataTextField="BANKNM" DataValueField="BANKN1" style="margin-left: 0px" 
                        Width="300px">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSBankInfo1" runat="server" 
                        SelectMethod="SearchBankInfo" TypeName="Financial.BorrowEdit">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    借款期間:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                        Format="yyyy/MM/dd" TargetControlID="TextBox2">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                        Format="yyyy/MM/dd" TargetControlID="TextBox3">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    執行查詢:</td>
                <td>
                    <asp:Button ID="btnSearchHistory" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnClearHistorySearch" runat="server" Text="清除查詢條件" />
                </td>
            </tr>
        </table>
        <asp:ListView ID="ListView1" runat="server" 
            DataKeyNames="FK_BankNumber,FK_ContractKind,FK_StartDate,ID" 
            DataSourceID="ldsHistorySearchResult" >
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="BorrowMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                            Text='<%# Eval("CreditMoneyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowRateLabel1" runat="server" 
                            Text='<%# Eval("BorrowRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExchangeRateLabel" runat="server" 
                            Text='<%# Eval("ExchangeRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BankNameLabel" runat="server" 
                            Text='<%# Eval("BankName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContractKindNameLabel" runat="server" 
                            Text='<%# Eval("ContractKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" 
                            Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AlreadyPayMoneyLabel" runat="server" 
                            Text='<%# Eval("AlreadyPayUseMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowNTMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowNTMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_BankNumberLabel" runat="server" 
                            Text='<%# Eval("FK_BankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_StartDateLabel" runat="server" 
                            Text='<%# Eval("FK_StartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowDateLabel" runat="server" 
                            Text='<%# Eval("BorrowStartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowENDDateLabel" runat="server" 
                            Text='<%# Eval("BorrowENDDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("LatePayMonths","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("RePaymentTimes","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Eval("RePaymentBankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("PayRateKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("PayPrincipalMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Eval("PayRateMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LCNumberLabel" runat="server" 
                            Text='<%# Eval("LCNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LCCaseNumberLabel" runat="server" 
                            Text='<%# Eval("LCCaseNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PayRateMoneyLabel" runat="server" 
                            Text='<%# Eval("PayRateMoney") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" 
                            Text='<%# Eval("Memo1") %>' />
                    </td>
                    
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="BorrowMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                            Text='<%# Eval("CreditMoneyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowRateLabel" runat="server" 
                            Text='<%# Eval("BorrowRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExchangeRateLabel" runat="server" 
                            Text='<%# Eval("ExchangeRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BankNameLabel" runat="server" 
                            Text='<%# Eval("BankName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContractKindNameLabel" runat="server" 
                            Text='<%# Eval("ContractKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" 
                            Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AlreadyPayMoneyLabel" runat="server" 
                            Text='<%# Eval("AlreadyPayUseMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowNTMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowNTMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_BankNumberLabel" runat="server" 
                            Text='<%# Eval("FK_BankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_StartDateLabel" runat="server" 
                            Text='<%# Eval("FK_StartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowDateLabel" runat="server" 
                            Text='<%# Eval("BorrowStartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowENDDateLabel" runat="server" 
                            Text='<%# Eval("BorrowENDDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("LatePayMonths","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("RePaymentTimes","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Eval("RePaymentBankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("PayRateKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("PayPrincipalMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Eval("PayRateMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LCNumberLabel" runat="server" 
                            Text='<%# Eval("LCNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LCCaseNumberLabel" runat="server" 
                            Text='<%# Eval("LCCaseNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PayRateMoneyLabel" runat="server" 
                            Text='<%# Eval("PayRateMoney") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" 
                            Text='<%# Eval("Memo1") %>' />
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
                        <asp:TextBox ID="BorrowMoneyTextBox" runat="server" 
                            Text='<%# Bind("BorrowMoney","{0:#0}") %>' />
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ControlToValidate="BorrowMoneyTextBox" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>    
                        <asp:HiddenField ID="HFOrginBorrowMoney" runat="server" Value='<%# Eval("BorrowMoney") %>' />
                        <asp:HiddenField ID="HFBorrowContract_CanUseMoney" runat="server" Value='<%# Eval("BorrowContract_CanUseMoney") %>' />
                        <asp:HiddenField ID="HFFK_ContractKind" runat="server" Value='<%# Eval("FK_ContractKind") %>' />
                        <asp:HiddenField ID="HFID" runat="server" Value='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameTextBox" runat="server" 
                            Text='<%# Eval("CreditMoneyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowRateTextBox" runat="server"  Width="50"
                            Text='<%# Bind("BorrowRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ExchangeRateTextBox" runat="server"  Enabled='<%# Bind("IsForeignMoneyKind") %>'
                            Text='<%# Bind("ExchangeRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BankNameTextBox" runat="server" 
                            Text='<%# Eval("BankName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContractKindNameTextBox" runat="server" 
                            Text='<%# Eval("ContractKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" 
                            Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AlreadyPayMoneyTextBox" runat="server" 
                            Text='<%# Eval("AlreadyPayUseMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowNTMoneyTextBox" runat="server" 
                            Text='<%# Eval("BorrowNTMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_BankNumberLabel1" runat="server" 
                            Text='<%# Eval("FK_BankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_StartDateLabel1" runat="server" 
                            Text='<%# Eval("FK_StartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowStartDateTextBox" runat="server"  Width="80"
                            Text='<%# Bind("BorrowStartDate","{0:d}") %>' />
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="BorrowStartDateTextBox" Format="yyyy/MM/dd">
                        </cc1:CalendarExtender>                    </td>
                    <td>
                        <asp:TextBox ID="BorrowEndDateTextBox" runat="server"  Width="80"
                            Text='<%# Bind("BorrowEndDate","{0:d}") %>' />
                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="BorrowEndDateTextBox" Format="yyyy/MM/dd">
                        </cc1:CalendarExtender>                    </td>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="LatePayMonthsTextBox" runat="server"  Width="30"
                            Text='<%# Bind("LatePayMonths","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="RePaymentTimesTextBox" runat="server"  Width="30"
                            Text='<%# Bind("RePaymentTimes","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPreSetRePaymentBankNumber" runat="server" 
                            DataSourceID="ODSPreSetBankInfo" DataTextField="BANKNM" DataValueField="BANKN1" SelectedValue='<%# Bind("RePaymentBankNumber") %>'
                            Width="300px">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ODSPreSetBankInfo" runat="server" 
                            SelectMethod="SearchBankInfo1" TypeName="Financial.BorrowEdit">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPayRateKind" SelectedValue='<%# Bind("PayRateKind") %>' runat="server" Width="120px">
                            <asp:ListItem Value="1">以月計息</asp:ListItem>
                            <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
                            <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
                            <asp:ListItem Value="4">借款時付息</asp:ListItem>
                            <asp:ListItem Value="5">到期一次付息</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="PayPrincipalMoneyDayNumberTextBox" runat="server"  Width="30"
                            Text='<%# Bind("PayPrincipalMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PayRateMoneyDayNumberTextBox" runat="server"  Width="30"
                            Text='<%# Bind("PayRateMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LCNumberTextBox" runat="server"  Width="90"
                            Text='<%# Bind("LCNumber") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LCCaseNumberTextBox" runat="server"  Width="90"
                            Text='<%# Bind("LCCaseNumber") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PayRateMoneyTextBox" runat="server"  Width="90"
                            Text='<%# Bind("PayRateMoney","{0:f2}") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Memo1TextBox" runat="server"  Width="90"
                            Text='<%# Bind("Memo1") %>' />
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
                    </td>
                    <td>
                        <asp:TextBox ID="BankNameTextBox" runat="server" 
                            Text='<%# Bind("BankName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ContractKindNameTextBox" runat="server" 
                            Text='<%# Bind("ContractKindName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AlreadyPayMoneyTextBox" runat="server" 
                            Text='<%# Bind("AlreadyPayUseMoney") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CreditMoneyNameTextBox" runat="server" 
                            Text='<%# Bind("CreditMoneyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowNTMoneyTextBox" runat="server" 
                            Text='<%# Bind("BorrowNTMoney") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="About_BorrowContractTextBox" runat="server" 
                            Text='<%# Bind("About_BorrowContract") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FK_BankNumberTextBox" runat="server" 
                            Text='<%# Bind("FK_BankNumber") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FK_ContractKindTextBox" runat="server" 
                            Text='<%# Bind("FK_ContractKind") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FK_StartDateTextBox" runat="server" 
                            Text='<%# Bind("FK_StartDate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowDateTextBox" runat="server" 
                            Text='<%# Bind("BorrowStartDate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowMoneyTextBox" runat="server" 
                            Text='<%# Bind("BorrowMoney") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PayMoneyTextBox" runat="server" 
                            Text='<%# Bind("PayMoney") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BorrowContractTextBox" runat="server" 
                            Text='<%# Bind("BorrowContract") %>' />
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
                                        借款金額</th>
                                    <th runat="server">
                                        幣別</th>
                                    <th runat="server">
                                        利率</th>
                                    <th runat="server">
                                        匯率</th>
                                    <th runat="server">
                                        銀行名稱</th>
                                    <th runat="server">
                                        合約種類</th>
                                    <th id="Th10" runat="server">
                                        編號</th>
                                    <th runat="server">
                                        還款金額</th>
                                    <th runat="server">
                                        借款台幣</th>
                                    <th runat="server">
                                        銀行編號</th>
                                    <th runat="server">
                                        合約啟始日</th>
                                    <th runat="server">
                                        借款起始日</th>
                                    <th id="Th8" runat="server">
                                        借款終止日</th>
                                    <th id="Th1" runat="server">
                                        寬緩月數</th>
                                    <th id="Th3" runat="server">
                                        還款期數</th>
                                    <th id="Th4" runat="server">
                                        存入帳號(還款帳號)</th>
                                    <th id="Th5" runat="server">
                                        付息方式</th>
                                    <th id="Th11" runat="server">
                                        還本日</th>
                                    <th id="Th6" runat="server">
                                        付息日</th>
                                    <th id="Th2" runat="server">
                                        LC開狀編號</th>
                                    <th id="Th9" runat="server">
                                        LC案號</th>
                                    <th id="Th12" runat="server">
                                        利息金額</th>
                                    <th id="Th7" runat="server">
                                        備註1</th>
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
                    </td>
                    <td>
                        <asp:Label ID="BorrowMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                            Text='<%# Eval("CreditMoneyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BankNameLabel" runat="server" 
                            Text='<%# Eval("BankName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExchangeRateLabel" runat="server" 
                            Text='<%# Eval("ExchangeRate","{0:N5}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContractKindNameLabel" runat="server" 
                            Text='<%# Eval("ContractKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AlreadyPayMoneyLabel" runat="server" 
                            Text='<%# Eval("AlreadyPayUseMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowNTMoneyLabel" runat="server" 
                            Text='<%# Eval("BorrowNTMoney","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_BankNumberLabel" runat="server" 
                            Text='<%# Eval("FK_BankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FK_StartDateLabel" runat="server" 
                            Text='<%# Eval("FK_StartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BorrowDateLabel" runat="server" 
                            Text='<%# Eval("BorrowStartDate","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("LatePayMonths","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("RePaymentTimes","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" 
                            Text='<%# Eval("PayPrincipalMoneyDayNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Eval("RePaymentBankNumber") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("PayRateKindName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Eval("PayRateMoneyDayNumber","{0:N0}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" 
                            Text='<%# Eval("Memo1") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:LinqDataSource ID="ldsHistorySearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
            EnableUpdate="True" TableName="Borrow">
        </asp:LinqDataSource>
    </ContentTemplate>
    </cc1:TabPanel>

    
</cc1:TabContainer>
</ContentTemplate>
</asp:UpdatePanel>           
