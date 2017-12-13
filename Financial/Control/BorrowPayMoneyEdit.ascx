<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowPayMoneyEdit.ascx.vb" Inherits="Financial.BorrowPayMoneyEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
                SelectMethod="SearchBankInfo2" 
                TypeName="Financial.BorrowPayMoneyEdit">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td >
            合約種類:</td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" Width="120px">
                <asp:ListItem Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="S1">短期借款</asp:ListItem>
                <asp:ListItem Value="S2">透支</asp:ListItem>
                <asp:ListItem Value="S4">商業本票</asp:ListItem>
                <asp:ListItem Value="S5">工程保證</asp:ListItem>
                <asp:ListItem Value="L1">長期借款</asp:ListItem>
                <asp:ListItem Value="L2">長期循環</asp:ListItem>
                <asp:ListItem Value="99">綜合額度</asp:ListItem>
            </asp:DropDownList>
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
            借款日:</td>
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
            付款日:</td>
        <td>
            <asp:CheckBox ID="CheckBox3" runat="server" Text="執行篩選　" />
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
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="重設查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" 
    DataKeyNames="FK_BankNumber,FK_ContractKind,FK_StartDate,FK_BorrowID,ID" 
    DataSourceID="ldsSearchResult" InsertItemPosition="LastItem">
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" >
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit"  Text="編輯" />
            </td>
            <td>
                <asp:Label ID="BorrowBankNumberNameLabel" runat="server" 
                    Text='<%# Eval("BorrowBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="ContractKindNameLabel" runat="server" 
                    Text='<%# Eval("ContractKindName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowIDLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyToolNameLabel" runat="server" 
                    Text='<%# Eval("PayMoneyToolName") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberNameLabel" runat="server" 
                    Text='<%# Eval("PayBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="PayToUserLabel" runat="server" Text='<%# Eval("PayToUser") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server" 
                    Text='<%# Eval("PayRateMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberLabel" runat="server" Text='<%# Eval("PayBankNumber") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" >
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit"  Text="編輯" />
            </td>
            <td>
                <asp:Label ID="BorrowBankNumberNameLabel" runat="server" 
                    Text='<%# Eval("BorrowBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="ContractKindNameLabel" runat="server" 
                    Text='<%# Eval("ContractKindName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowIDLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyToolNameLabel" runat="server" 
                    Text='<%# Eval("PayMoneyToolName") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberNameLabel" runat="server" 
                    Text='<%# Eval("PayBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="PayToUserLabel" runat="server" Text='<%# Eval("PayToUser") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server" 
                    Text='<%# Eval("PayRateMoney","{0:F2}") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberLabel" runat="server" Text='<%# Eval("PayBankNumber") %>' />
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
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="300"  DataSourceID="odsSearchBankInfo3" DataTextField="BANKNM" DataValueField="BANKN1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound" OnPreRender="DropDownList2_OnPreRender" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="100" DataSourceID="ldsSubLCBorrowContract"  DataTextField="StartDate" DataValueField="StartDate"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" OnDataBound="DropDownList4_DataBound" DataTextFormatString="{0:d}" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server" Width="50" DataSourceID="ldsSubBorrow"  DataTextField="ID" DataValueField="ID"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" OnDataBound="DropDownList5_DataBound">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="自動"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PayMoneyDateTextBox" runat="server"  Width="80" Text='<%# Bind("PayMoneyDate") %>' />
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="PayMoneyDateTextBox" Format="yyyy/MM/dd" >
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:DropDownList ID="PayMoneyToolDropDownList" runat="server">
                <asp:ListItem Value="1">支票</asp:ListItem>
                <asp:ListItem Value="2">EDI</asp:ListItem>
                <asp:ListItem Value="3">現轉傳票</asp:ListItem>
                <asp:ListItem Value="4">支票匯款</asp:ListItem>
                <asp:ListItem Value="5">支票劃付</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="PayBankNumberDropDownList" runat="server" Width="300" DataSourceID="odsSubPayBankInfo"  DataTextField="BANKNM" DataValueField="BANKN1" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="PayToUserTextBox" runat="server" 
                    Text='<%# Bind("PayToUser") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayUseMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayUseMoney") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayRateMoney") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyCritdialDateTextBox" runat="server"  Width="80" Text='<%# Bind("PayRateMoneyCritdialDate") %>' />
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="PayRateMoneyCritdialDateTextBox" Format="yyyy/MM/dd" >
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text='' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberLabel" runat="server" Text='' />
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
                                借款銀行</th>
                            <th runat="server">
                                借款種類</th>
                            <th runat="server">
                                合約起始日</th>
                            <th runat="server">
                                借款編號</th>
                            <th runat="server">
                                編號</th>
                            <th runat="server">
                                付款日期</th>
                            <th runat="server">
                                付款工具</th>
                            <th runat="server">
                                付款銀行</th>
                            <th runat="server">
                                受款人</th>
                            <th runat="server">
                                付款本金金額</th>
                            <th runat="server">
                                付款利息金額</th>
                            <th runat="server">
                                付息基準日</th>
                            <th runat="server">
                                備註1</th>
                            <th id="Th1" runat="server">
                                借款銀行代碼</th>
                            <th id="Th2" runat="server">
                                付款銀行代碼</th>
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
                <asp:Label ID="BorrowBankNumberNameLabel1" runat="server" 
                    Text='<%# Eval("BorrowBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="ContractKindNameLabel1" runat="server" 
                    Text='<%# Eval("ContractKindName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel1" runat="server" 
                    Text='<%# Eval("FK_StartDate","{0:d}") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowIDLabel1" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayMoneyDateTextBox" runat="server" 
                    Text='<%# Bind("PayMoneyDate","{0:d}") %>'  Width="100" />
                <cc1:CalendarExtender ID="CalendarExtender11" TargetControlID="PayMoneyDateTextBox" Format="yyyy/MM/dd" runat="server">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:DropDownList ID="PayMoneyToolDropDownList" runat="server" SelectedValue='<%# Bind("PayMoneyTool") %>' >
                <asp:ListItem Value="1">支票</asp:ListItem>
                <asp:ListItem Value="2">EDI</asp:ListItem>
                <asp:ListItem Value="3">現轉傳票</asp:ListItem>
                <asp:ListItem Value="4">支票匯款</asp:ListItem>
                <asp:ListItem Value="5">支票劃付</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="PayBankNumberDropDownList"  SelectedValue='<%# Bind("PayBankNumber") %>' runat="server" Width="300" DataSourceID="odsSubPayBankInfo"  DataTextField="BANKNM" DataValueField="BANKN1" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="PayToUserTextBox" runat="server" 
                    Text='<%# Bind("PayToUser") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayUseMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayUseMoney","{0:f2}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyTextBox" runat="server" 
                    Text='<%# Bind("PayRateMoney","{0:f2}") %>' />
            </td>
            <td>
                <asp:TextBox ID="PayRateMoneyCritdialDateTextBox" runat="server" 
                    Text='<%# Bind("PayRateMoneyCritdialDate","{0:d}") %>' Width="100" />
                <cc1:CalendarExtender ID="CalendarExtender12" TargetControlID="PayRateMoneyCritdialDateTextBox" Format="yyyy/MM/dd" runat="server">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberLabel" runat="server" Text='<%# Eval("PayBankNumber") %>' />
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
                <asp:Label ID="BorrowBankNumberNameLabel" runat="server" 
                    Text='<%# Eval("BorrowBankNumberName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_ContractKindLabel" runat="server" 
                    Text='<%# Eval("FK_ContractKind") %>' />
            </td>
            <td>
                <asp:Label ID="FK_StartDateLabel" runat="server" 
                    Text='<%# Eval("FK_StartDate") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BorrowIDLabel" runat="server" 
                    Text='<%# Eval("FK_BorrowID") %>' />
            </td>
            <td>
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyDateLabel" runat="server" 
                    Text='<%# Eval("PayMoneyDate") %>' />
            </td>
            <td>
                <asp:Label ID="PayMoneyToolLabel" runat="server" 
                    Text='<%# Eval("PayMoneyTool") %>' />
            </td>
            <td>
                <asp:Label ID="PayBankNumberLabel" runat="server" 
                    Text='<%# Eval("PayBankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="PayToUserLabel" runat="server" Text='<%# Eval("PayToUser") %>' />
            </td>
            <td>
                <asp:Label ID="PayUseMoneyLabel" runat="server" 
                    Text='<%# Eval("PayUseMoney") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyLabel" runat="server" 
                    Text='<%# Eval("PayRateMoney") %>' />
            </td>
            <td>
                <asp:Label ID="PayRateMoneyCritdialDateLabel" runat="server" 
                    Text='<%# Eval("PayRateMoneyCritdialDate") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="FK_BankNumberLabel" runat="server" Text='<%# Eval("FK_BankNumber") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("PayBankNumber") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="BorrowPayMoney">
</asp:LinqDataSource>


<asp:ObjectDataSource ID="odsSearchBankInfo2" runat="server" 
    SelectMethod="SearchBankInfo2" 
    TypeName="Financial.BorrowPayMoneyEdit">
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsSearchBankInfo3" runat="server" 
    SelectMethod="SearchBankInfo3" 
    TypeName="Financial.BorrowPayMoneyEdit">
</asp:ObjectDataSource>
<asp:LinqDataSource ID="ldsSubLCBorrowContract" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" TableName="BorrowContract">
</asp:LinqDataSource>
<asp:LinqDataSource ID="ldsSubBorrow" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" OrderBy="ID" 
    Select="new (ID)" TableName="Borrow">
</asp:LinqDataSource>
<asp:ObjectDataSource ID="odsSubPayBankInfo" runat="server" 
    SelectMethod="SearchBankInfo1" TypeName="Financial.BorrowPayMoneyEdit">
</asp:ObjectDataSource>

