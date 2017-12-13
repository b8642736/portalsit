<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowLCBillEdit.ascx.vb" Inherits="Financial.BorrowLCBillEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 115px;
    }
    .style2
    {
        width: 115px;
        height: 23px;
    }
    .style3
    {
        height: 23px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            銀行:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" 
                DataSourceID="odsSearchBankInfo" DataTextField="BANKNM" DataValueField="BANKN1">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsSearchBankInfo" runat="server" 
                SelectMethod="SearchBankInfo" TypeName="Financial.BorrowLCBillEdit">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="style1">
            合約啟始日:</td>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="執行篩選　" />
            <asp:TextBox ID="tbsFK_StartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/d" 
                TargetControlID="tbsFK_StartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbsFK_StartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsFK_StartDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
        <tr>
        <td class="style1">
            開狀啟始日:</td>
        <td>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="執行篩選　" />
            <asp:TextBox ID="tbsFK_BorrowStartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsFK_BorrowStartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbsFK_BorrowStartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsFK_BorrowStartDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            到單(墊款)日:</td>
        <td>
            <asp:CheckBox ID="CheckBox3" runat="server" Text="執行篩選　" />
            <asp:TextBox ID="tbsBillStartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsBillStartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbsBillStartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsBillStartDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style2">
            LC編號:</td>
        <td class="style3">
            <asp:TextBox ID="tbLCNumber" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            查詢:</td>
        <td class="style3">
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchCondiction" runat="server" Text="重設查詢條件" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server"
    DataKeyNames="FK_BankNumber,FK_ContractKind,FK_StartDate,FK_BorrowID,ID" 
    DataSourceID="ldsSearchResult" InsertItemPosition="LastItem" 
    style="width:2000px" >
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除此筆資料?">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="DebtRaiseDateLabel" runat="server" 
                    Text='<%# Eval("DebtRaiseDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="CanUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("CanUseLCBorrowMoney","{0:F2}") %>' />
                <asp:Label ID="CreditMoneyNameLabel" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="IsReceiveBankNotifyCheckBox" Enabled="false" runat="server" Checked='<%# Eval("IsReceiveBankNotify") %>' />
            </td>
            <td>
                <asp:Label ID="BillStartDateLabel" runat="server" 
                    Text='<%# Eval("BillStartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="BillEndDateLabel" runat="server" 
                    Text='<%# Eval("BillEndDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="UseMoneyLabel" runat="server" Text='<%# Eval("UseMoney","{0:F2}") %>' />
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="BillRateLabel" runat="server" Text='<%# Eval("BillRate") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRageLabel" runat="server" 
                    Text='<%# Eval("ExchangeRage") %>' />
            </td>
            <td>
                <asp:Label ID="AlreadyUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("AlreadyUseLCBorrowMoney") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="LCNumberLabel" runat="server" 
                    Text='<%# Eval("LCNumber") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除此筆資料?">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="DebtRaiseDateLabel" runat="server" 
                    Text='<%# Eval("DebtRaiseDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="CanUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("CanUseLCBorrowMoney","{0:F2}") %>' />
                <asp:Label ID="CreditMoneyNameLabel" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="IsReceiveBankNotifyCheckBox" Enabled="false" runat="server" Checked='<%# Eval("IsReceiveBankNotify") %>' />
            </td>
            <td>
                <asp:Label ID="BillStartDateLabel" runat="server" 
                    Text='<%# Eval("BillStartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="BillEndDateLabel" runat="server" 
                    Text='<%# Eval("BillEndDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="UseMoneyLabel" runat="server" Text='<%# Eval("UseMoney","{0:F2}") %>' />
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="BillRateLabel" runat="server" Text='<%# Eval("BillRate") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRageLabel" runat="server" 
                    Text='<%# Eval("ExchangeRage") %>' />
            </td>
            <td>
                <asp:Label ID="AlreadyUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("AlreadyUseLCBorrowMoney") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="LCNumberLabel" runat="server" 
                    Text='<%# Eval("LCNumber") %>' />
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" Enabled="false" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                <asp:HiddenField ID="HFFK_BankNumber"  Value='<%# Bind("FK_BankNumber") %>' runat="server"  />
                <asp:HiddenField ID="HFFK_ContractKind" runat="server"   Value='<%# Bind("FK_ContractKind") %>' />
                <asp:HiddenField ID="HFFK_StartDate" runat="server"  Value='<%# Bind("FK_StartDate","{0:d}") %>' />
                <asp:HiddenField ID="HFFK_BorrowID" runat="server"  Value='<%# Bind("FK_BorrowID") %>' />
           </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="300"  DataSourceID="odsSearchBankInfo2" DataTextField="BANKNM" DataValueField="BANKN1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="100" DataSourceID="ldsSubLCBorrowContract"  DataTextField="StartDate" DataValueField="StartDate"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" OnDataBound="DropDownList3_DataBound"  DataTextFormatString="{0:d}">
                </asp:DropDownList>
            </td>
             <td>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="50" DataSourceID="ldsSubBorrow"  DataTextField="ID" DataValueField="ID"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"  OnDataBound="DropDownList4_DataBound">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='系統自動' />
            </td>
            <td>
                <asp:TextBox ID="DebtRaiseDateTextBox" runat="server" 
                    Text='<%# Bind("DebtRaiseDate","{0:d}") %>' Width="90"/>
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="DebtRaiseDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
            <td>
                <table>
                    <tr>
                    <td>
                        <asp:Label ID="LBCanUseLCBorrowMoney" runat="server" Text="0" Width="100" ></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameLabel1" runat="server" Text="" Font-Size="XX-Small"></asp:Label>
                    </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:CheckBox ID="IsReceiveBankNotifyCheckBox" runat="server"  Checked ='<%# Bind("IsReceiveBankNotify") %>' />
            </td>
            <td>
                <asp:TextBox ID="BillStartDateTextBox" runat="server" 
                    Text='<%# Bind("BillStartDate","{0:d}") %>' Width="90" />
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="BillStartDateTextBox" Format="yyyy/MM/dd" >
                </cc1:CalendarExtender>    
            </td>
            <td>
                <asp:TextBox ID="BillEndDateTextBox" runat="server" 
                    Text='<%# Bind("BillEndDate","{0:d}") %>' Width="90"  />
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="BillEndDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
            <td>
                <table>
                    <tr>
                    <td>
                        <asp:TextBox ID="UseMoneyTextBox" runat="server" Text='<%# Bind("UseMoney") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CreditMoneyNameLabel" runat="server" Text="" Font-Size="XX-Small"></asp:Label>
                    </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:TextBox ID="BillRateTextBox" runat="server" 
                    Text='<%# Bind("BillRate") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="ExchangeRageTextBox" runat="server" 
                    Text='<%# Bind("ExchangeRage") %>'  Width="40" />
            </td>
           <td>
                <asp:Label ID="AlreadyUseLCBorrowMoneyLabel" runat="server"  Width="100"></asp:Label>
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text=""></asp:Label>
           </td>
            <td>
                <asp:Label ID="LCNumberLabel" runat="server"/>
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
                                銀行名稱</th>
                            <th runat="server">
                                合約起始日</th>
                            <th runat="server">
                                開狀編號</th>
                            <th id="Th1" runat="server">
                                編號</th>
                            <th id="Th2" runat="server">
                                負債發生日</th>
                            <th runat="server">
                                最大到單金額</th>
                            <th id="Th3" runat="server">
                                是否到單</th>
                            <th runat="server">
                                到單啟始日</th>
                            <th runat="server">
                                到單到期日</th>
                            <th runat="server">
                                金額</th>
                            <th runat="server">
                                借款利率</th>
                            <th runat="server">
                                匯率</th>
                            <th runat="server">
                                已到單金額</th>
                            <th runat="server">
                                銀行代碼</th>
                            <th runat="server">
                                LC編號</th>
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
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("BankName") %>'/>
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel1" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowStartDateLabel1" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="DebtRaiseDateTextBox" runat="server" 
                    Text='<%# Bind("DebtRaiseDate","{0:d}") %>' Width="90"/>
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="DebtRaiseDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("CanUseLCBorrowMoney") %>' />
                <asp:Label ID="CreditMoneyNameLabel" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="IsReceiveBankNotifyCheckBox" runat="server"  Checked ='<%# Bind("IsReceiveBankNotify") %>' />
            </td>
            <td>
                <asp:Label ID="BillStartDateLabel1" runat="server" 
                    Text='<%# Eval("BillStartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:TextBox ID="BillEndDateTextBox" runat="server" 
                    Text='<%# Bind("BillEndDate","{0:d}") %>' />
                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="BillEndDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>    
            </td>
            <td>
                <asp:TextBox ID="UseMoneyTextBox" runat="server" 
                    Text='<%# Bind("UseMoney","{0:F2}") %>' />
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="BillRateTextBox" runat="server" 
                    Text='<%# Bind("BillRate") %>' />
            </td>
            <td>
                <asp:TextBox ID="ExchangeRageTextBox" runat="server" 
                    Text='<%# Bind("ExchangeRage") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AlreadyUseLCBorrowMoney") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel1" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
                 <asp:Label ID="FK_ContractKindLabel1" runat="server" 
                    Text='<%# Eval("FK_ContractKind") %>' />
           </td>
            <td>
                <asp:Label ID="LCNumberLabel" runat="server" 
                    Text='<%# Eval("LCNumber") %>' />
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
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="CanUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("CanUseLCBorrowMoney") %>' />
                <asp:Label ID="CreditMoneyNameLabel" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="BillStartDateLabel" runat="server" 
                    Text='<%# Eval("BillStartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="BillEndDateLabel" runat="server" 
                    Text='<%# Eval("BillEndDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="UseMoneyLabel" runat="server" Text='<%# Eval("UseMoney","{0:N0}") %>' />
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreditMoneyName") %>' Font-Size="XX-Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="BillRateLabel" runat="server" Text='<%# Eval("BillRate") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRageLabel" runat="server" 
                    Text='<%# Eval("ExchangeRage") %>' />
            </td>
            <td>
                <asp:Label ID="AlreadyUseLCBorrowMoneyLabel" runat="server" 
                    Text='<%# Eval("AlreadyUseLCBorrowMoney") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="LCNumberLabel" runat="server" 
                    Text='<%# Eval("LCNumber") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="BorrowLCBill">
</asp:LinqDataSource>
<asp:ObjectDataSource ID="odsSearchBankInfo2" runat="server" 
    SelectMethod="SearchBankInfo2" TypeName="Financial.BorrowLCBillEdit">
</asp:ObjectDataSource>
<asp:LinqDataSource ID="ldsSubLCBorrowContract" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="BorrowContract">
</asp:LinqDataSource>

<asp:LinqDataSource ID="ldsSubBorrow" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" 
    TableName="Borrow">
</asp:LinqDataSource>


