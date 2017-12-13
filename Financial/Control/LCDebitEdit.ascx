<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LCDebitEdit.ascx.vb" Inherits="Financial.LCDebitEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 123px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            信用狀編號:</td>
        <td>
            <asp:TextBox ID="tbLCID" runat="server" Width="203px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="發行日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate1">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox2" runat="server" Text="到期日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate2">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate2" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
    InsertItemPosition="LastItem" DataKeyNames="LCUSNO" 
    style="text-align: left" >
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>                
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="LCUSNOLabel" runat="server" Text='<%# Eval("LCUSNO") %>' />
            </td>
            <td>
                <asp:Label ID="DEPARTLabel" runat="server" Text='<%# Eval("DEPARTForPC") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="LODAYLabel" runat="server" Text='<%# Eval("LODAY") %>' />
            </td>
            <td>
                <asp:Label ID="TODAYLabel" runat="server" Text='<%# Eval("TODAY") %>' />
            </td>
            <td>
                <asp:Label ID="PERIODLabel" runat="server" Text='<%# Eval("PERIOD") %>' />
            </td>
            <td>
                <asp:Label ID="IRLabel" runat="server" Text='<%# Eval("IR") %>' />
            </td>
            <td>
                <asp:Label ID="CURRANLabel" runat="server" Text='<%# Eval("CURRAN") %>' />
            </td>
            <td>
                <asp:Label ID="INTERLabel" runat="server" Text='<%# Eval("INTER") %>' />
            </td>
            <td>
                <asp:Label ID="BANKLabel" runat="server" Text='<%# Eval("BANK") %>' />
            </td>
            <td>
                <asp:Label ID="CRLabel" runat="server" Text='<%# Eval("CR") %>' />
            </td>
            <td>
                <asp:Label ID="NTAMTLabel" runat="server" Text='<%# Eval("NTAMT") %>' />
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
                <asp:Label ID="LCUSNOLabel" runat="server" Text='<%# Eval("LCUSNO") %>' />
            </td>
            <td>
                <asp:Label ID="DEPARTLabel" runat="server" Text='<%# Eval("DEPARTForPC") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="LODAYLabel" runat="server" Text='<%# Eval("LODAY") %>' />
            </td>
            <td>
                <asp:Label ID="TODAYLabel" runat="server" Text='<%# Eval("TODAY") %>' />
            </td>
            <td>
                <asp:Label ID="PERIODLabel" runat="server" Text='<%# Eval("PERIOD") %>' />
            </td>
            <td>
                <asp:Label ID="IRLabel" runat="server" Text='<%# Eval("IR") %>' />
            </td>
            <td>
                <asp:Label ID="CURRANLabel" runat="server" Text='<%# Eval("CURRAN") %>' />
            </td>
            <td>
                <asp:Label ID="INTERLabel" runat="server" Text='<%# Eval("INTER") %>' />
            </td>
            <td>
                <asp:Label ID="BANKLabel" runat="server" Text='<%# Eval("BANK") %>' />
            </td>
            <td>
                <asp:Label ID="CRLabel" runat="server" Text='<%# Eval("CR") %>' />
            </td>
            <td>
                <asp:Label ID="NTAMTLabel" runat="server" Text='<%# Eval("NTAMT") %>' />
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" CausesValidation="true"  />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="LCUSNOTextBox" runat="server" Text='<%# Bind("LCUSNO") %>' CausesValidation="true"  />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"  Mask="????????????????????" TargetControlID="LCUSNOTextBox">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="DEPARTTextBox" runat="server" Text='<%# Bind("DEPARTForPC") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server"  Mask="??????????" TargetControlID="DEPARTTextBox">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="AMOUNTTextBox" runat="server" Text='<%# Bind("AMOUNT") %>' />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server"  Mask="9999999999999.99" TargetControlID="AMOUNTTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="LODAYTextBox" runat="server" Text='<%# Bind("LODAY") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server"  Mask="9999999" TargetControlID="LODAYTextBox" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="TODAYTextBox" runat="server" Text='<%# Bind("TODAY") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server"  Mask="9999999" TargetControlID="TODAYTextBox" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="PERIODTextBox" runat="server" Text='<%# Bind("PERIOD") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server"  Mask="999" TargetControlID="PERIODTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="IRTextBox" runat="server" Text='<%# Bind("IR") %>' />
                 <%--<cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server"  Mask="99.9999" TargetControlID="IRTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
           </td>
            <td>
                <%--<asp:TextBox ID="CURRANTextBox" runat="server" Text='<%# Bind("CURRAN") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server"  SelectedValue='<%# Bind("CURRAN") %>' OnPreRender="DropDownList2_OnPreRender" >
               </asp:DropDownList>

            </td>
            <td>
                <%--<asp:TextBox ID="INTERTextBox" runat="server" Text='<%# Bind("INTER") %>' />--%>
                <asp:Label ID="Label1" runat="server" Text="系統自動計算"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="BANKTextBox" runat="server" Text='<%# Bind("BANK") %>' />
                  <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server"  Mask="???????????" TargetControlID="BANKTextBox">
                </cc1:MaskedEditExtender>
           </td>
            <td>
                <asp:TextBox ID="CRTextBox" runat="server" Text='<%# Bind("CR") %>' />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server"  Mask="99.9999" TargetControlID="CRTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <%--<asp:TextBox ID="NTAMTTextBox" runat="server" Text='<%# Bind("NTAMT") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server"  Mask="9999999999999.99" TargetControlID="NTAMTTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
                <asp:Label ID="Label2" runat="server" Text="系統自動計算"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="13">
                <asp:CustomValidator ID="CustomValidator1" runat="server"  ErrorMessage="信用狀編號必須輸入!" ControlToValidate="LCUSNOTextBox" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ></asp:CustomValidator>
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
                                信用狀編號</th>
                            <th runat="server">
                                單位別</th>
                            <th runat="server">
                                金額</th>
                            <th runat="server">
                                發行日</th>
                            <th runat="server">
                                到期日</th>
                            <th runat="server">
                                期限</th>
                            <th runat="server">
                                利率</th>
                            <th runat="server">
                                幣別</th>
                            <th runat="server">
                                利息</th>
                            <th runat="server">
                                銀行別</th>
                            <th runat="server">
                                兌換率</th>
                            <th runat="server">
                                新台幣金額</th>
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
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" CausesValidation="false"  />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <%--<asp:TextBox ID="LCUSNOTextBox" runat="server" Text='<%# Bind("LCUSNO") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"  Mask="????????????????????" TargetControlID="LCUSNOTextBox">
                </cc1:MaskedEditExtender>--%>
                <asp:Label ID="LCUSNOLabel" runat="server" Text='<%# Eval("LCUSNO") %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="DEPARTTextBox" runat="server" Text='<%# Bind("DEPARTForPC") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server"  Mask="??????????" TargetControlID="DEPARTTextBox">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="AMOUNTTextBox" runat="server" Text='<%# Bind("AMOUNT") %>' />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server"  Mask="9999999999999.99" TargetControlID="AMOUNTTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="LODAYTextBox" runat="server" Text='<%# Bind("LODAY") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server"  Mask="9999999" TargetControlID="LODAYTextBox" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="TODAYTextBox" runat="server" Text='<%# Bind("TODAY") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server"  Mask="9999999" TargetControlID="TODAYTextBox" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="PERIODTextBox" runat="server" Text='<%# Bind("PERIOD") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server"  Mask="999" TargetControlID="PERIODTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="IRTextBox" runat="server" Text='<%# Bind("IR") %>' />
                 <%--<cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server"  Mask="99.9999" TargetControlID="IRTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
           </td>
            <td>
                <%--<asp:TextBox ID="CURRANTextBox" runat="server" Text='<%# Bind("CURRAN") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server"  SelectedValue='<%# Bind("CURRAN") %>'   OnInit  ="DropDownList2_OnInit" >
               </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="INTERTextBox" runat="server" Text='<%# Bind("INTER") %>' />--%>
                <asp:Label ID="Label1" runat="server" Text="系統自動計算"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="BANKTextBox" runat="server" Text='<%# Bind("BANK") %>' />
                  <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server"  Mask="???????????" TargetControlID="BANKTextBox">
                </cc1:MaskedEditExtender>
           </td>
            <td>
                <asp:TextBox ID="CRTextBox" runat="server" Text='<%# Bind("CR") %>' />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server"  Mask="99.9999" TargetControlID="CRTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <%--<asp:TextBox ID="NTAMTTextBox" runat="server" Text='<%# Bind("NTAMT") %>' />
                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server"  Mask="9999999999999.99" TargetControlID="NTAMTTextBox" InputDirection="RightToLeft" MaskType="Number">
                </cc1:MaskedEditExtender>--%>
                <asp:Label ID="Label2" runat="server" Text="系統自動計算"></asp:Label>
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
                <asp:Label ID="LCUSNOLabel" runat="server" Text='<%# Eval("LCUSNO") %>' />
            </td>
            <td>
                <asp:Label ID="DEPARTLabel" runat="server" Text='<%# Eval("DEPARTForPC") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="LODAYLabel" runat="server" Text='<%# Eval("LODAY") %>' />
            </td>
            <td>
                <asp:Label ID="TODAYLabel" runat="server" Text='<%# Eval("TODAY") %>' />
            </td>
            <td>
                <asp:Label ID="PERIODLabel" runat="server" Text='<%# Eval("PERIOD") %>' />
            </td>
            <td>
                <asp:Label ID="IRLabel" runat="server" Text='<%# Eval("IR") %>' />
            </td>
            <td>
                <asp:Label ID="CURRANLabel" runat="server" Text='<%# Eval("CURRAN") %>' />
            </td>
            <td>
                <asp:Label ID="INTERLabel" runat="server" Text='<%# Eval("INTER") %>' />
            </td>
            <td>
                <asp:Label ID="BANKLabel" runat="server" Text='<%# Eval("BANK") %>' />
            </td>
            <td>
                <asp:Label ID="CRLabel" runat="server" Text='<%# Eval("CR") %>' />
            </td>
            <td>
                <asp:Label ID="NTAMTLabel" runat="server" Text='<%# Eval("NTAMT") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.DEBSYSLB.LCUSPF" DeleteMethod="DeleteItem" 
    InsertMethod="InsertItem" SelectMethod="SearchItem" 
    TypeName="Financial.LCDebitEdit" UpdateMethod="UpdateItem">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />

<asp:ObjectDataSource ID="ODSMoneyKind" runat="server" 
    SelectMethod="MoneyKindSearch" TypeName="Financial.LCDebitEdit">
</asp:ObjectDataSource>
<%--<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ODSMoneyKind" 
    DataTextField="CURRAN" DataValueField="CURRNO">
</asp:DropDownList>--%>
