<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowLCBillPayMoneyEdit.ascx.vb" Inherits="Financial.BorrowLCBillPayMoneyEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 148px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            銀行:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="odsSearchBankInfo" DataTextField="BANKNM" DataValueField="BANKN1" 
                Width="300px">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsSearchBankInfo" runat="server" 
                SelectMethod="SearchBankInfo" 
                TypeName="Financial.BorrowLCBillPayMoneyEdit">
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
            </cc1:CalendarExtender>~
            <asp:TextBox ID="tbsFK_StartDate2" runat="server" Width="100px"></asp:TextBox>
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
            </cc1:CalendarExtender>~
            <asp:TextBox ID="tbsFK_BorrowStartDate2" runat="server" Width="100px"></asp:TextBox>
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
            </cc1:CalendarExtender>~
            <asp:TextBox ID="tbsBillStartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsBillStartDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            付款/到單未使用日:</td>
        <td>
            <asp:CheckBox ID="CheckBox4" runat="server" Text="執行篩選　" />
            <asp:TextBox ID="tbsPayMoneyDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsPayMoneyDate1">
            </cc1:CalendarExtender>~
            <asp:TextBox ID="tbsPayMoneyDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbsPayMoneyDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            LC編號:</td>
        <td>
            <asp:TextBox ID="tbLCNumber" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="重設查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" 
    DataKeyNames="FK_BankNumber,FK_ContractKind,FK_StartDate,FK_BorrowID,FK_BorrowLCBillID,ID" 
    DataSourceID="ldsSearchResult" InsertItemPosition="LastItem">
    <ItemTemplate>
        <tr style="background-color: #E0FFFF;color: #333333;">
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
                <asp:Label ID="FK_BillStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowLCBillID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney","{0:N0}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server"  Width="80"
                    Text='<%# Eval("PayRateMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                    Text='<%# Eval("CreditMoneyName") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRateLabel" runat="server" 
                    Text='<%# Eval("ExchangeRate") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNoPayMoneyAndUseCheckBox" runat="server" 
                    Checked='<%# Eval("IsNoPayMoneyAndUse") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color: #FFFFFF;color: #284775;">
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
                <asp:Label ID="FK_BillStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowLCBillID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney","{0:N0}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server"  Width="80"
                    Text='<%# Eval("PayRateMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                    Text='<%# Eval("CreditMoneyName") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRateLabel" runat="server" 
                    Text='<%# Eval("ExchangeRate") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNoPayMoneyAndUseCheckBox" runat="server" 
                    Checked='<%# Eval("IsNoPayMoneyAndUse") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" Enabled="false"  />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                <asp:HiddenField ID="HFFK_BankNumber"  Value='<%# Bind("FK_BankNumber") %>' runat="server" Visible="true"  />
                <asp:HiddenField ID="HFFK_ContractKind" runat="server"   Value='<%# Bind("FK_ContractKind") %>' />
                <asp:HiddenField ID="HFFK_StartDate" runat="server"  Value='<%# Bind("FK_StartDate","{0:d}") %>' />
                <asp:HiddenField ID="HFFK_BorrowID" runat="server"  Value='<%# Bind("FK_BorrowID") %>' />
                <asp:HiddenField ID="HFFK_BorrowLCBillID" runat="server"  Value='<%# Bind("FK_BorrowLCBillID") %>' />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="300"  DataSourceID="odsSearchBankInfo2" DataTextField="BANKNM" DataValueField="BANKN1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="100" DataSourceID="ldsSubLCBorrowContract"  DataTextField="StartDate" DataValueField="StartDate"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" OnDataBound="DropDownList3_DataBound"  DataTextFormatString="{0:d}">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="50" DataSourceID="ldsSubBorrow"  DataTextField="ID" DataValueField="ID"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"  OnDataBound="DropDownList4_DataBound">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server" Width="50" DataSourceID="ldsSubBorrowLCBill"  DataTextField="ID" DataValueField="ID"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" OnDataBound="DropDownList5_DataBound">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='自動' />
            </td>
            <td>
                <asp:TextBox ID="PayMoneyDateTextBox" runat="server"  Width="80"
                    Text='<%# Bind("PayMoneyDate","{0:d}") %>' />
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="PayMoneyDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>    
            </td>
            <td>
                <asp:TextBox ID="PayUseMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayUseMoney","{0:N0}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyTextBox" runat="server" Width="80"
                    Text='<%# Bind("PayRateMoney") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyCritdialDateTextBox" runat="server"   Width="80"
                    Text='<%# Bind("PayRateMoneyCritdialDate","{0:d}") %>' />
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="PayRateMoneyCritdialDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>    
            </td>
            <td>
                <asp:Label ID="CreditMoneyNameLabel" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="ExchangeRateTextBox" runat="server" Width="50"
                    Text='<%# Bind("ExchangeRate") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNoPayMoneyAndUseCheckBox" runat="server" 
                    Checked='<%# Bind("IsNoPayMoneyAndUse") %>' />
            </td>
             <td>
                 <asp:Label ID="FK_BankNumberLabel" runat="server" Text=""></asp:Label>    
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
                                銀行名稱</th>
                            <th runat="server">
                                合約起始日</th>
                            <th runat="server">
                                開狀編號</th>
                            <th runat="server">
                                到單編號</th>
                            <th id="Th4" runat="server">
                                編號</th>
                            <th runat="server">
                                付款日</th>
                            <th runat="server">
                                付款本金</th>
                            <th runat="server">
                                付款利息</th>
                            <th id="Th2" runat="server">
                                付息基準日</th>
                            <th id="Th3" runat="server">
                                幣別</th>
                            <th runat="server">
                                匯率</th>
                            <th runat="server">
                                開狀不使用</th>
                            <th id="Th1" runat="server">
                                銀行編號</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
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
        <tr style="background-color: #999999;">
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
                <asp:Label ID="FK_BillStartDateLabel1" runat="server" 
                    Text='<%# Eval("FK_BorrowLCBillID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel1" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayUseMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayUseMoney","{0:F0}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayRateMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyCritdialDateTextBox" runat="server" 
                    Text='<%# Bind("PayRateMoneyCritdialDate","{0:d}") %>' />
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="PayRateMoneyCritdialDateTextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>    
            </td>
            <td>
                <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                    Text='<%# Eval("CreditMoneyName") %>' />
            </td>
            <td>
                <asp:TextBox ID="ExchangeRateTextBox" runat="server" 
                    Text='<%# Bind("ExchangeRate") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNoPayMoneyAndUseCheckBox" runat="server" 
                    Checked='<%# Bind("IsNoPayMoneyAndUse") %>' />
            </td>
             <td>
                <asp:Label ID="FK_BankNumberLabel1" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
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
                <asp:Label ID="FK_BillStartDateLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowLCBillID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" 
                    Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney","{0:N0}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server" 
                    Text='<%# Eval("PayRateMoney","{0:N0}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="CreditMoneyNameLabel" runat="server" 
                    Text='<%# Eval("CreditMoneyName") %>' />
            </td>
            <td>
                <asp:Label ID="ExchangeRateLabel" runat="server" 
                    Text='<%# Eval("ExchangeRate") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsNoPayMoneyAndUseCheckBox" runat="server" 
                    Checked='<%# Eval("IsNoPayMoneyAndUse") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" 
                    Text='<%# Eval("FK_BankNumber") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="BorrowLCBillPayMoney">
</asp:LinqDataSource>

<asp:ObjectDataSource ID="odsSearchBankInfo2" runat="server" 
    SelectMethod="SearchBankInfo2" 
    TypeName="Financial.BorrowLCBillPayMoneyEdit">
</asp:ObjectDataSource>


<asp:LinqDataSource ID="ldsSubLCBorrowContract" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="BorrowContract">
</asp:LinqDataSource>

<asp:LinqDataSource ID="ldsSubBorrow" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" 
    TableName="Borrow">
</asp:LinqDataSource>





<asp:LinqDataSource ID="ldsSubBorrowLCBill" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="BorrowLCBill">
</asp:LinqDataSource>






