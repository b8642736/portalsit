<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BorrowContractEdit.ascx.vb" Inherits="Financial.BorrowContractEdit"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>




<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="SearchContractView" runat="server">
<table style="width:100%;">
    <tr>
        <td>
            銀行:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" 
                DataSourceID="ODSBankInfo" DataTextField="BANKNM" DataValueField="BANKN1">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ODSBankInfo" runat="server" 
                SelectMethod="SearchBankInfo" TypeName="Financial.BorrowContractEdit">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>
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
                <asp:ListItem Value="99">綜合額度</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            有效期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td>
            查詢:</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="查詢" Width="80px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢" 
                Width="80px" />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
DataKeyNames="BankNumber,ContractKind,StartDate" 
DataSourceID="ldsSearchResult" Width="462px">
    <PagerSettings PageButtonCount="30" />
    <EditItemTemplate>
        銀行代碼:
        <asp:Label ID="BankNumberLabel1" runat="server" 
    Text='<%# Eval("BankNumber") %>' />
        <br />
        合約種類:
        <asp:Label ID="ContractKindLabel1" runat="server" 
    Text='<%# Eval("ContractKindName") %>' />
        <br />
        啟始日期:
        <asp:Label ID="StartDateLabel1" runat="server" 
    Text='<%# Eval("StartDate", "{0:d}") %>' />
        <br />
        截止日期:
        <asp:TextBox ID="EndDateTextBox" runat="server" 
    Text='<%# Bind("EndDate", "{0:d}") %>' Width="148px" />
        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy/MM/dd" 
    TargetControlID="EndDateTextBox">
        </cc1:CalendarExtender>
        <asp:CustomValidator ID="CustomValidator5" runat="server" 
    ControlToValidate="EndDateTextBox" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator5_ServerValidate" ></asp:CustomValidator>
        <br />
        合約金額:
        <asp:TextBox ID="CreditMoneyTextBox" runat="server" 
    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" 
    InputDirection="RightToLeft" Mask="9999999999999" MaskType="Number" 
    TargetControlID="CreditMoneyTextBox">
        </cc1:MaskedEditExtender>
        <asp:CustomValidator ID="CustomValidator6" runat="server" 
    ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator3_ServerValidate" 
    ControlToValidate="CreditMoneyTextBox"></asp:CustomValidator>
        <br />
        幣別:<asp:DropDownList ID="DropDownList10" runat="server" 
            DataSourceID="ODSSearchMoneyKind" DataTextField="TYPENM" 
            DataValueField="TYPENO" SelectedValue='<%# Bind("CreditMoneyKind") %>' 
            Width="150px">
        </asp:DropDownList>
        <br />
        承辦人:
        <asp:TextBox ID="ProcessEmployeeTextBox" runat="server" 
            Text='<%# Bind("ProcessEmployee", "{0}") %>' Width="148px"></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" 
    InputDirection="RightToLeft" Mask="????????????????" 
    TargetControlID="ProcessEmployeeTextBox">
        </cc1:MaskedEditExtender>
        <br />
        寬緩月數:<asp:TextBox ID="TextBox5" runat="server" 
    Text='<%# Bind("LatePayMonths", "{0}") %>'></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99999" 
    MaskType="Number" TargetControlID="TextBox5">
        </cc1:MaskedEditExtender>
        <br />
        還款期限:<asp:TextBox ID="TextBox21" runat="server" 
            Text='<%# Bind("RepaymentMonths") %>'></asp:TextBox>
        個月<cc1:MaskedEditExtender ID="MaskedEditExtender21" runat="server" 
            InputDirection="RightToLeft" Mask="99999" MaskType="Number" 
            TargetControlID="TextBox21">
        </cc1:MaskedEditExtender>
        <br />
        還款期數:<asp:TextBox ID="TextBox6" runat="server" 
    Text='<%# Bind("RepaymentTimes", "{0}") %>'></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" 
    InputDirection="RightToLeft" Mask="9999" MaskType="Number" 
    TargetControlID="TextBox6">
        </cc1:MaskedEditExtender>
        <asp:CustomValidator ID="CustomValidator7" runat="server" 
    ControlToValidate="TextBox6" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator7_ServerValidate" ></asp:CustomValidator>
        <br />
        還款帳號:<asp:DropDownList ID="DropDownList8" runat="server" 
            DataSourceID="ODSBankInfo1" DataTextField="BANKNM" DataValueField="BANKN1" 
            SelectedValue='<%# Bind("RePaymentBankNumber") %>' Width="300px">
        </asp:DropDownList>
        <br />
        付息方式:<asp:DropDownList ID="DropDownList9" runat="server" 
    SelectedValue='<%# Bind("PayRateKind") %>' Width="150px">
            <asp:ListItem Value="1">以月計息</asp:ListItem>
            <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
            <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
            <asp:ListItem Value="4">借款時付息</asp:ListItem>
            <asp:ListItem Value="5">到期一次付息</asp:ListItem>
        </asp:DropDownList>
        <br />
        付息日:<asp:TextBox ID="TextBox9" runat="server" 
    Text='<%# Bind("PayRateMoneyDayNumber") %>'></asp:TextBox>
        <br />
        備註:<asp:TextBox ID="TextBox10" runat="server" Height="50px" 
    Text='<%# Bind("Memo1") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" 
    CommandName="Update" Text="更新"  />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
    CausesValidation="False" CommandName="Cancel" Text="取消" />
    </EditItemTemplate>
    <InsertItemTemplate>
        銀行代碼:
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ODSBankInfo1" 
    DataTextField="BANKNM" DataValueField="BANKN1" 
    SelectedValue='<%# Bind("BankNumber") %>' Width="300px">
        </asp:DropDownList>
        <br />
        合約種類:
        <asp:DropDownList ID="DropDownList2" runat="server" 
    SelectedValue='<%# Bind("ContractKind") %>' Width="120px">
            <asp:ListItem Value="S1">短期借款</asp:ListItem>
            <asp:ListItem Value="S2">透支</asp:ListItem>
            <asp:ListItem Value="S3">LC</asp:ListItem>
            <asp:ListItem Value="S4">商業本票</asp:ListItem>
            <asp:ListItem Value="S5">工程保證</asp:ListItem>
            <asp:ListItem Value="L1">長期借款</asp:ListItem>
            <asp:ListItem Value="L2">長期循環</asp:ListItem>
            <asp:ListItem Value="99">綜合額度</asp:ListItem>
        </asp:DropDownList>
        <br />
        啟始日期:
        <asp:TextBox ID="StartDateTextBox" runat="server" 
    Text='<%# Bind("StartDate") %>' />
        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" 
    TargetControlID="StartDateTextBox">
        </cc1:CalendarExtender>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
    ControlToValidate="StartDateTextBox" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
        截止日期:
        <asp:TextBox ID="EndDateTextBox" runat="server" Text='<%# Bind("EndDate") %>' />
        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy/MM/dd" 
    TargetControlID="EndDateTextBox">
        </cc1:CalendarExtender>
        <asp:CustomValidator ID="CustomValidator2" runat="server" 
    ControlToValidate="EndDateTextBox" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
        <br />
        合約金額:
        <asp:TextBox ID="CreditMoneyTextBox" runat="server" 
    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
        <asp:CustomValidator ID="CustomValidator3" runat="server" 
    ControlToValidate="CreditMoneyTextBox" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" 
    InputDirection="RightToLeft" Mask="9999999999999" MaskType="Number" 
    TargetControlID="CreditMoneyTextBox">
        </cc1:MaskedEditExtender>
        <br />
        幣別:
        <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="TYPENM" 
    DataValueField="TYPENO" SelectedValue='<%# Bind("CreditMoneyKind") %>' 
    Width="140px" DataSourceID="ODSSearchMoneyKind"  >
        </asp:DropDownList>
        <br />
        承辦人:
        <asp:TextBox ID="ProcessEmployeeTextBox" runat="server" 
    Text='<%# Bind("ProcessEmployee") %>' />
        <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" 
    InputDirection="RightToLeft" Mask="????????????????" 
    TargetControlID="ProcessEmployeeTextBox">
        </cc1:MaskedEditExtender>
        <br />
        寬緩月數:<asp:TextBox ID="TextBox2" runat="server" 
    Text='<%# Bind("LatePayMonths", "{0}") %>'></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
    InputDirection="RightToLeft" Mask="99999" MaskType="Number" 
    TargetControlID="TextBox2">
        </cc1:MaskedEditExtender>
        <br />
        還款期限:<asp:TextBox ID="TextBox19" runat="server" 
            Text='<%# Bind("RepaymentMonths", "數字格式 - {0:N0}") %>'></asp:TextBox>
        個月<cc1:MaskedEditExtender ID="MaskedEditExtender19" runat="server" 
            InputDirection="RightToLeft" Mask="99999" MaskType="Number" 
            TargetControlID="TextBox19">
        </cc1:MaskedEditExtender>
        <br />
        還款期數:<asp:TextBox ID="TextBox3" runat="server" 
    Text='<%# Bind("RepaymentTimes", "{0}") %>'></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
    InputDirection="RightToLeft" Mask="9999" MaskType="Number" 
    TargetControlID="TextBox3">
        </cc1:MaskedEditExtender>
        <asp:CustomValidator ID="CustomValidator4" runat="server" 
    ControlToValidate="TextBox3" ErrorMessage="CustomValidator" 
    onservervalidate="CustomValidator4_ServerValidate"></asp:CustomValidator>
        <br />
        還款帳號:<asp:DropDownList ID="DropDownList6" runat="server" 
    DataSourceID="ODSBankInfo1" DataTextField="BANKNM" DataValueField="BANKN1" 
    SelectedValue='<%# Bind("RePaymentBankNumber") %>' Width="300px">
        </asp:DropDownList>
        <br />
        付息方式:<asp:DropDownList ID="DropDownList7" runat="server" 
    SelectedValue='<%# Bind("PayRateKind") %>' Width="150px">
            <asp:ListItem Value="1">以月計息</asp:ListItem>
            <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
            <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
            <asp:ListItem Value="4">借款時付息</asp:ListItem>
            <asp:ListItem Value="5">到期一次付息</asp:ListItem>
        </asp:DropDownList>
        <br />
        付息日:<asp:TextBox ID="TextBox7" runat="server" 
    Text='<%# Bind("PayRateMoneyDayNumber", "{0}") %>'></asp:TextBox>
        <br />
        備註:<asp:TextBox ID="TextBox8" runat="server" Height="50px" TextMode="MultiLine" 
    Width="500px"></asp:TextBox>
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
    CommandName="Insert" Text="插入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
    CausesValidation="False" CommandName="Cancel" Text="取消" />
    </InsertItemTemplate>
    <ItemTemplate>
        銀行代碼:
        <asp:Label ID="BankNumberLabel" runat="server" 
    Text='<%# Eval("BankNumber") %>' />
        <br />
        銀行名稱:<asp:Label ID="Label1" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
        <br />
        合約種類:
        <asp:Label ID="ContractKindLabel" runat="server" 
    Text='<%# Eval("ContractKindName") %>' />
        <br />
        啟始日期:
        <asp:Label ID="StartDateLabel" runat="server" 
    Text='<%# Eval("StartDate", "{0:d}") %>' />
        <br />
        截止日期:
        <asp:Label ID="EndDateLabel" runat="server" 
    Text='<%# Bind("EndDate", "{0:d}") %>' />
        <br />
        合約金額:
        <asp:Label ID="CreditMoneyLabel" runat="server" 
    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
        <br />
        幣別:
        <asp:Label ID="CreditMoneyKindLabel" runat="server" 
    Text='<%# Bind("CreditMoneyName", "{0}") %>' />
        <br />
        承辦人:
        <asp:Label ID="ProcessEmployeeLabel" runat="server" 
    Text='<%# Bind("ProcessEmployee") %>' />
        <br />
        寬緩月數:<asp:Label ID="Label3" runat="server" 
    Text='<%# Eval("LatePayMonths", "{0}個月") %>'></asp:Label>
        <br />
        還款期限:<asp:Label ID="Label18" runat="server" 
            Text='<%# Eval("RepaymentMonthsToYearMonthString") %>'></asp:Label>
        <br />
        還款期數:<asp:Label ID="Label4" runat="server" 
    Text='<%# Eval("RepaymentTimes", "{0}期") %>'></asp:Label>
        <br />
        還款帳號:<asp:Label ID="Label5" runat="server" 
    Text='<%# Eval("RePaymentBankName") %>'></asp:Label>
        <br />
        付息方式:<asp:Label ID="Label6" runat="server" 
    Text='<%# Eval("PayRateKindName") %>'></asp:Label>
        <br />
        付息日:<asp:Label ID="Label7" runat="server" 
    Text='<%# Eval("PayRateMoneyDayNumber", "每月{0}號") %>'></asp:Label>
        <br />
        備註:<asp:Label ID="Label8" runat="server" Text='<%# Eval("Memo1") %>'></asp:Label>
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
    CommandName="Edit" Text="編輯" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
    CommandName="Delete" Text="刪除" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
    CommandName="New" Text="新增" />
        &nbsp;<asp:LinkButton ID="lbEditSubContract" runat="server" 
            onclick="lbEditSubContract_Click" 
            Visible='<%# Eval("IsCompostBorrowContract") %>'>編修/新增子合約</asp:LinkButton>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
    ConfirmText="是否確認刪除?" TargetControlID="DeleteButton">
        </cc1:ConfirmButtonExtender>
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="Button2" runat="server" CommandName="New" Text="新增" 
    Width="100px" />
    </EmptyDataTemplate>
</asp:FormView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.FincialDataContext" 
    TableName="BorrowContract" EnableDelete="True" EnableInsert="True" 
    EnableUpdate="True">
</asp:LinqDataSource>
<asp:ObjectDataSource ID="ODSBankInfo1" runat="server" 
    SelectMethod="SearchBankInfo1" 
TypeName="Financial.BorrowContractEdit">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ODSSearchMoneyKind" runat="server" 
SelectMethod="SearchMoneyKind" TypeName="Financial.BorrowContractEdit">
</asp:ObjectDataSource>    
    </asp:View>
    <asp:View ID="SubContractEditView" runat="server">
        <asp:FormView ID="FormView2" runat="server" AllowPaging="True" 
            DataKeyNames="BankNumber,ContractKind,StartDate" 
            DataSourceID="LDSSubContractSearchResult" Width="462px">
            <PagerSettings PageButtonCount="30" />
            <EditItemTemplate>
                銀行代碼:
                <asp:Label ID="BankNumberLabel2" runat="server" 
                    Text='<%# Eval("BankNumber") %>' />
                <br />
                合約種類:
                <asp:Label ID="ContractKindLabel2" runat="server" 
                    Text='<%# Eval("ContractKindName") %>' />
                <br />
                啟始日期:
                <asp:Label ID="StartDateLabel2" runat="server" 
                    Text='<%# Eval("StartDate", "{0:d}") %>' />
                <br />
                截止日期:
                <asp:TextBox ID="EndDateTextBox0" runat="server" 
                    Text='<%# Bind("EndDate", "{0:d}") %>' Width="148px" />
                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="EndDateTextBox0">
                </cc1:CalendarExtender>
                <asp:CustomValidator ID="CustomValidator8" runat="server" 
                    ControlToValidate="EndDateTextBox0" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator5_ServerValidate"></asp:CustomValidator>
                <br />
                合約金額:
                <asp:TextBox ID="CreditMoneyTextBox0" runat="server" 
                    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" 
                    InputDirection="RightToLeft" Mask="9999999999999" MaskType="Number" 
                    TargetControlID="CreditMoneyTextBox0">
                </cc1:MaskedEditExtender>
                <asp:CustomValidator ID="CustomValidator9" runat="server" 
                    ControlToValidate="CreditMoneyTextBox0" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                <br />
                幣別:<asp:DropDownList ID="DropDownList11" runat="server" 
                    DataSourceID="ODSSearchMoneyKind" DataTextField="TYPENM" 
                    DataValueField="TYPENO" SelectedValue='<%# Bind("CreditMoneyKind") %>' 
                    Width="150px">
                </asp:DropDownList>
                <br />
                承辦人:
                <asp:TextBox ID="ProcessEmployeeTextBox0" runat="server" 
                    Text='<%# Bind("ProcessEmployee", "{0}") %>' Width="148px"></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" 
                    InputDirection="RightToLeft" Mask="????????????????" 
                    TargetControlID="ProcessEmployeeTextBox0">
                </cc1:MaskedEditExtender>
                <br />
                寬緩月數:<asp:TextBox ID="TextBox11" runat="server" 
                    Text='<%# Bind("LatePayMonths", "{0}") %>'></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" Mask="99999" 
                    MaskType="Number" TargetControlID="TextBox11">
                </cc1:MaskedEditExtender>
                <br />
                還款期限:<asp:TextBox ID="TextBox22" runat="server" 
                    Text='<%# Bind("RepaymentMonths") %>'></asp:TextBox>
                個月<cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" 
                    InputDirection="RightToLeft" Mask="99999" MaskType="Number" 
                    TargetControlID="TextBox22">
                </cc1:MaskedEditExtender>
                <br />
                還款期數:<asp:TextBox ID="TextBox12" runat="server" 
                    Text='<%# Bind("RepaymentTimes", "{0}") %>'></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" 
                    InputDirection="RightToLeft" Mask="9999" MaskType="Number" 
                    TargetControlID="TextBox12">
                </cc1:MaskedEditExtender>
                <asp:CustomValidator ID="CustomValidator10" runat="server" 
                    ControlToValidate="TextBox12" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator7_ServerValidate"></asp:CustomValidator>
                <br />
                還款帳號:<asp:DropDownList ID="DropDownList12" runat="server" 
                    DataSourceID="ODSBankInfo1" DataTextField="BANKNM" DataValueField="BANKN1" 
                    SelectedValue='<%# Bind("RePaymentBankNumber") %>' Width="300px">
                </asp:DropDownList>
                <br />
                付息方式:<asp:DropDownList ID="DropDownList13" runat="server" 
                    SelectedValue='<%# Bind("PayRateKind") %>' Width="150px">
                    <asp:ListItem Value="1">以月計息</asp:ListItem>
                    <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
                    <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
                    <asp:ListItem Value="4">借款時付息</asp:ListItem>
                    <asp:ListItem Value="5">到期一次付息</asp:ListItem>

                </asp:DropDownList>
                <br />
                付息日:<asp:TextBox ID="TextBox13" runat="server" 
                    Text='<%# Bind("PayRateMoneyDayNumber") %>'></asp:TextBox>
                <br />
                備註:<asp:TextBox ID="TextBox14" runat="server" Height="50px" 
                    Text='<%# Bind("Memo1") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
                <br />
                <asp:LinkButton ID="UpdateButton0" runat="server" CommandName="Update" 
                    Text="更新" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton0" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:HiddenField ID="HFBankNumber" runat="server" 
                    Value='<%# Bind("BankNumber") %>' />
                合約種類:
                <asp:DropDownList ID="DropDownList15" runat="server" 
                    SelectedValue='<%# Bind("ContractKind") %>' Width="120px">
                    <asp:ListItem Value="S1">短期借款</asp:ListItem>
                    <asp:ListItem Value="S2">透支</asp:ListItem>
                    <asp:ListItem Value="S3">LC</asp:ListItem>
                    <asp:ListItem Value="S4">商業本票</asp:ListItem>
                    <asp:ListItem Value="S5">工程保證</asp:ListItem>
                    <asp:ListItem Value="L1">長期借款</asp:ListItem>
                    <asp:ListItem Value="L2">長期循環</asp:ListItem>
                </asp:DropDownList>
                <br />
                啟始日期:
                <asp:TextBox ID="StartDateTextBox0" runat="server" 
                    Text='<%# Bind("StartDate") %>' />
                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="StartDateTextBox0">
                </cc1:CalendarExtender>
                <asp:CustomValidator ID="CustomValidator11" runat="server" 
                    ControlToValidate="StartDateTextBox0" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                <br />
                截止日期:
                <asp:TextBox ID="EndDateTextBox1" runat="server" 
                    Text='<%# Bind("EndDate") %>' />
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="EndDateTextBox1">
                </cc1:CalendarExtender>
                <asp:CustomValidator ID="CustomValidator12" runat="server" 
                    ControlToValidate="EndDateTextBox1" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                <br />
                合約金額:
                <asp:TextBox ID="CreditMoneyTextBox1" runat="server" 
                    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
                <asp:CustomValidator ID="CustomValidator13" runat="server" 
                    ControlToValidate="CreditMoneyTextBox1" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" 
                    InputDirection="RightToLeft" Mask="9999999999999" MaskType="Number" 
                    TargetControlID="CreditMoneyTextBox1">
                </cc1:MaskedEditExtender>
                <br />
                幣別:
                <asp:DropDownList ID="DropDownList16" runat="server" 
                    DataSourceID="ODSSearchMoneyKind" DataTextField="TYPENM" DataValueField="TYPENO" 
                    SelectedValue='<%# Bind("CreditMoneyKind") %>' Width="140px">
                </asp:DropDownList>
                <br />
                承辦人:
                <asp:TextBox ID="ProcessEmployeeTextBox1" runat="server" 
                    Text='<%# Bind("ProcessEmployee") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" 
                    InputDirection="RightToLeft" Mask="????????????????" 
                    TargetControlID="ProcessEmployeeTextBox1">
                </cc1:MaskedEditExtender>
                <br />
                寬緩月數:<asp:TextBox ID="TextBox15" runat="server" 
                    Text='<%# Bind("LatePayMonths", "{0}") %>'></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" 
                    InputDirection="RightToLeft" Mask="99999" MaskType="Number" 
                    TargetControlID="TextBox15">
                </cc1:MaskedEditExtender>
                <br />
                還款期限:<asp:TextBox ID="TextBox20" runat="server" 
                    Text='<%# Bind("RepaymentMonths", "數字格式 - {0:N0}") %>'></asp:TextBox>
                個月<cc1:MaskedEditExtender ID="MaskedEditExtender20" runat="server" 
                    InputDirection="RightToLeft" Mask="99999個月" MaskType="Number" 
                    TargetControlID="TextBox20">
                </cc1:MaskedEditExtender>
                <br />
                還款期數:<asp:TextBox ID="TextBox16" runat="server" 
                    Text='<%# Bind("RepaymentTimes", "{0}") %>'></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" 
                    InputDirection="RightToLeft" Mask="9999" MaskType="Number" 
                    TargetControlID="TextBox16">
                </cc1:MaskedEditExtender>
                <asp:CustomValidator ID="CustomValidator14" runat="server" 
                    ControlToValidate="TextBox16" ErrorMessage="CustomValidator" 
                    onservervalidate="CustomValidator4_ServerValidate"></asp:CustomValidator>
                <br />
                還款帳號:<asp:DropDownList ID="DropDownList17" runat="server" 
                    DataSourceID="ODSBankInfo1" DataTextField="BANKNM" DataValueField="BANKN1" 
                    SelectedValue='<%# Bind("RePaymentBankNumber") %>' Width="300px">
                </asp:DropDownList>
                <br />
                付息方式:<asp:DropDownList ID="DropDownList18" runat="server" 
                    SelectedValue='<%# Bind("PayRateKind") %>' Width="150px">
                    <asp:ListItem Value="1">以月計息</asp:ListItem>
                    <asp:ListItem Value="2">以日計息(算頭不算尾)</asp:ListItem>
                    <asp:ListItem Value="3">以日計息(頭尾都算)</asp:ListItem>
                    <asp:ListItem Value="4">借款時付息</asp:ListItem>
                    <asp:ListItem Value="5">到期一次付息</asp:ListItem>                    
                </asp:DropDownList>
                <br />
                付息日:<asp:TextBox ID="TextBox17" runat="server" 
                    Text='<%# Bind("PayRateMoneyDayNumber", "{0}") %>'></asp:TextBox>
                <br />
                備註:<asp:TextBox ID="TextBox18" runat="server" Height="50px" 
                    TextMode="MultiLine" Width="500px"></asp:TextBox>
                <asp:CheckBox ID="CHIsHaveParentContract" runat="server" 
                    Checked='<%# Bind("IsHaveParentBorrowContract") %>' Visible="False" />
                <asp:HiddenField ID="HFFK_CompostBankNumber" runat="server" 
                    Value='<%# Bind("FK_CompostBankNumber") %>' />
                <asp:HiddenField ID="HFFK_CompostContractKind" runat="server" 
                    Value='<%# Bind("FK_CompostContractKind") %>' />
                <asp:TextBox ID="tbFK_CompostStartDate" runat="server" 
                    Text='<%# Bind("FK_CompostStartDate") %>' Visible="False"></asp:TextBox>
                <br />
                <asp:LinkButton ID="InsertButton0" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="插入" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton0" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="取消" />
            </InsertItemTemplate>
            <ItemTemplate>
                銀行代碼:
                <asp:Label ID="BankNumberLabel3" runat="server" 
                    Text='<%# Eval("BankNumber") %>' />
                <br />
                銀行名稱:<asp:Label ID="Label10" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
                <br />
                合約種類:
                <asp:Label ID="ContractKindLabel3" runat="server" 
                    Text='<%# Eval("ContractKindName") %>' />
                <br />
                啟始日期:
                <asp:Label ID="StartDateLabel3" runat="server" 
                    Text='<%# Eval("StartDate", "{0:d}") %>' />
                <br />
                截止日期:
                <asp:Label ID="EndDateLabel0" runat="server" 
                    Text='<%# Bind("EndDate", "{0:d}") %>' />
                <br />
                合約金額:
                <asp:Label ID="CreditMoneyLabel0" runat="server" 
                    Text='<%# Bind("CreditMoney", "{0:N0}") %>' />
                <br />
                幣別:
                <asp:Label ID="CreditMoneyKindLabel0" runat="server" 
                    Text='<%# Bind("CreditMoneyName", "{0}") %>' />
                <br />
                承辦人:
                <asp:Label ID="ProcessEmployeeLabel0" runat="server" 
                    Text='<%# Bind("ProcessEmployee") %>' />
                <br />
                寬緩月數:<asp:Label ID="Label11" runat="server" 
                    Text='<%# Eval("LatePayMonths", "{0}個月") %>'></asp:Label>
                <br />
                還款期限:<asp:Label ID="Label19" runat="server" 
                    Text='<%# Eval("RepaymentMonthsToYearMonthString") %>'></asp:Label>
                <br />
                還款期數:<asp:Label ID="Label12" runat="server" 
                    Text='<%# Eval("RepaymentTimes", "{0}期") %>'></asp:Label>
                <br />
                還款帳號:<asp:Label ID="Label13" runat="server" 
                    Text='<%# Eval("RePaymentBankName") %>'></asp:Label>
                <br />
                付息方式:<asp:Label ID="Label14" runat="server" 
                    Text='<%# Eval("PayRateKindName") %>'></asp:Label>
                <br />
                付息日:<asp:Label ID="Label15" runat="server" 
                    Text='<%# Eval("PayRateMoneyDayNumber", "每月{0}號") %>'></asp:Label>
                <br />
                是否為綜合額度合約:<asp:Label ID="Label16" runat="server" 
                    Text='<%# Eval("IsCompostBorrowContractChinese") %>'></asp:Label>
                <br />
                備註:<asp:Label ID="Label17" runat="server" Text='<%# Eval("Memo1") %>'></asp:Label>
                <br />
                <asp:LinkButton ID="EditButton0" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="編輯" />
                &nbsp;<asp:LinkButton ID="DeleteButton0" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="刪除" />
                &nbsp;<asp:LinkButton ID="NewButton0" runat="server" CausesValidation="False" 
                    CommandName="New" Text="新增" />
                &nbsp;<asp:LinkButton ID="Backup" runat="server" CommandName="Backup" 
                    onclick="Backup_Click">返回主合約</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                    ConfirmText="是否確認刪除?" TargetControlID="DeleteButton0">
                </cc1:ConfirmButtonExtender>
            </ItemTemplate>
            <EmptyDataTemplate>
                <asp:Button ID="Button3" runat="server" CommandName="New" 
                    Text="新增子合約" Width="100px" />
                <asp:Button ID="btnCancelBackup" runat="server" onclick="btnCancelBackup_Click" 
                    Text="取消返回" />
            </EmptyDataTemplate>
        </asp:FormView>
        <asp:LinqDataSource ID="LDSSubContractSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.FincialDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" TableName="BorrowContract">
        </asp:LinqDataSource>
    </asp:View>
</asp:MultiView>




