<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NonConsumFAMEdit.ascx.vb" Inherits="Accounting.NonConsumFAMEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="EmployeeSampleSearch.ascx" tagname="EmployeeSampleSearch" tagprefix="uc1" %>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server" >
<style type="text/css">
    .style1
    {
        font-size: 12px;
        width: 100px;
    }
</style>
<table style="width:100%">
    <tr>
        <td class="style1">
            財產編號:</td>
        <td>
            <asp:TextBox ID="tbAS301" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            序號:</td>
        <td>
            <asp:TextBox ID="tbAS302" runat="server" Width="65px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            入帳日:</td>
        <td>
            <asp:TextBox ID="btStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="btEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            保管人:</td>
        <td>
            <asp:TextBox ID="tbAS311" runat="server" Width="131px"></asp:TextBox>(可輸入部份姓名或工號)
            <asp:Button ID="btnEmployeeSearch" runat="server" Text="&lt;=查詢" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            部門:</td>
        <td>
            <asp:TextBox ID="tbAS306" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            名稱說明:</td>
        <td>
            <asp:TextBox ID="tbAS310" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">備註1:</td>
        <td>
            <asp:TextBox ID="tbAS393" runat="server" Width="342px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除" Width="100px" />
            <asp:Button ID="btnConvertToExcel" runat="server" Text="下載轉換EXCEL" 
                Width="110px" />
            <asp:HiddenField ID="hfSearchSQLString" runat="server" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult"
    InsertItemPosition="LastItem" DataKeyNames="AS301,AS302,AS303,AS304" >
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="AS301Label" runat="server" Text='<%# Eval("AS301") %>' />
            </td>
            <td>
                <asp:Label ID="AS302Label" runat="server" Text='<%# Eval("AS302") %>' />
            </td>
            <td>
                <asp:Label ID="AS303Label" runat="server" Text='<%# Eval("AS303") %>' />
            </td>
            <td>
                <asp:Label ID="AS304Label" runat="server" Text='<%# Eval("AS304_DateTimeFormat","{0:yyyy/MM/dd}") %>' />
            </td>
            <%--<td>
                <asp:Label ID="AS305Label" runat="server" Text='<%# Eval("AS305") %>' />
            </td>--%>
            <td>
                <asp:Label ID="AS306Label" runat="server" Text='<%# Eval("AS306") %>' />
            </td>
            <td>
                <asp:Label ID="AS307Label" runat="server" Text='<%# Eval("AS307") %>' />
            </td>
            <td>
                <asp:Label ID="AS308Label" runat="server" Text='<%# Eval("AS308") %>' />
            </td>
            <td>
                <asp:Label ID="AS309Label" runat="server" Text='<%# Eval("AS309") %>' />
            </td>
            <td>
                <asp:Label ID="AS310Label" runat="server" Text='<%# Eval("AS310") %>' />
            </td>
            <td>
                <asp:Label ID="AS311Label" runat="server" Text='<%# Eval("AS311_EmployeeName") %>' />
            </td>
             <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AS312_Explain") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AS393") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="AS301Label" runat="server" Text='<%# Eval("AS301") %>' />
            </td>
            <td>
                <asp:Label ID="AS302Label" runat="server" Text='<%# Eval("AS302") %>' />
            </td>
            <td>
                <asp:Label ID="AS303Label" runat="server" Text='<%# Eval("AS303") %>' />
            </td>
            <td>
                <asp:Label ID="AS304Label" runat="server" Text='<%# Eval("AS304_DateTimeFormat","{0:yyyy/MM/dd}") %>' />
            </td>
            <%--<td>
                <asp:Label ID="AS305Label" runat="server" Text='<%# Eval("AS305") %>' />
            </td>--%>
            <td>
                <asp:Label ID="AS306Label" runat="server" Text='<%# Eval("AS306") %>' />
            </td>
            <td>
                <asp:Label ID="AS307Label" runat="server" Text='<%# Eval("AS307") %>' />
            </td>
            <td>
                <asp:Label ID="AS308Label" runat="server" Text='<%# Eval("AS308") %>' />
            </td>
            <td>
                <asp:Label ID="AS309Label" runat="server" Text='<%# Eval("AS309") %>' />
            </td>
            <td>
                <asp:Label ID="AS310Label" runat="server" Text='<%# Eval("AS310") %>' />
            </td>
            <td>
                <asp:Label ID="AS311Label" runat="server" Text='<%# Eval("AS311_EmployeeName") %>' />
            </td>
             <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AS312_Explain") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AS393") %>' />
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
            </td>
            <td>
                <asp:TextBox ID="AS301TextBox" runat="server" Text='<%# Bind("AS301") %>' Width="90" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="AS301TextBox" Mask="??????????">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS302TextBox" runat="server" Text='<%# Bind("AS302") %>' Width="40" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="AS302TextBox" Mask="????">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS303TextBox" runat="server" Text='<%# Bind("AS303") %>' Width="60" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="AS303TextBox" Mask="????????">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS304TextBox" runat="server" Text='<%# Bind("AS304_DateTimeFormat") %>' Width="70" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="AS304TextBox" Mask="9999/99/99" MaskType="Date">
                </cc1:MaskedEditExtender>--%>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="AS304TextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
            <%--<td>
                <asp:TextBox ID="AS305TextBox" runat="server" Text='<%# Bind("AS305") %>' Width="100" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="AS305TextBox" Mask="????????">
                </cc1:MaskedEditExtender>
            </td>--%>
            <td>
                <asp:TextBox ID="AS306TextBox" runat="server" Text='<%# Bind("AS306") %>' Width="40" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="AS306TextBox" Mask="????">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS307TextBox" runat="server" Text='<%# Bind("AS307") %>' Width="20" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="AS307TextBox" Mask="9999">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS308TextBox" runat="server" Text='<%# Bind("AS308") %>' Width="60" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="AS308TextBox" Mask="999999.99" MaskType="Number"   InputDirection="RightToLeft">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS309TextBox" runat="server" Text='<%# Bind("AS309") %>' Width="30" />
                 <%--<cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="AS309TextBox" Mask="99">
                </cc1:MaskedEditExtender>--%>
           </td>
            <td>
                <asp:TextBox ID="AS310TextBox" runat="server" Text='<%# Bind("AS310") %>' Width="100" />
           </td>
            <td>
                <asp:TextBox ID="AS311TextBox" runat="server" Text='<%# Bind("AS311") %>' Width="50" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="AS311TextBox" Mask="99999">
                </cc1:MaskedEditExtender>--%>
                <asp:Button ID="btnEmployeeSearch1" runat="server" Text="查詢" OnClick="btnEmployeeSearch1_Click" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("AS312") %>' >
                <asp:ListItem Value="01" >使用中</asp:ListItem>
                <asp:ListItem Value="02" >已報廢</asp:ListItem>
                <asp:ListItem Value="03" >已繳回</asp:ListItem>
                <asp:ListItem Value="04" >已變賣</asp:ListItem>
              </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="AS393TextBox" runat="server" Text='<%# Bind("AS393") %>' Width="100" />
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
                                財產編號</th>
                            <th runat="server">
                                序號</th>
                            <th runat="server">
                                請購憑證</th>
                            <th runat="server">
                                入帳日</th>
                            <%--<th runat="server">
                                領料單</th>--%>
                            <th runat="server">
                                部門</th>
                            <th runat="server">
                                數量</th>
                            <th runat="server">
                                金額</th>
                            <th runat="server">
                                年限</th>
                            <th runat="server">
                                名稱說明</th>
                            <th runat="server">
                                保管人/工號</th>
                            <th id="Th1" runat="server">
                                狀態</th>
                            <th id="Th2" runat="server">
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
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="AS301Label" runat="server" Text='<%# Bind("AS301") %>' Width="90" />
            </td>
            <td>
                <asp:Label ID="AS302Label" runat="server" Text='<%# Bind("AS302") %>' Width="40" />
            </td>
            <td>
                <asp:Label ID="AS303Label" runat="server" Text='<%# Bind("AS303") %>' Width="60" />
            </td>
            <td>
                <asp:Label ID="AS304Label" runat="server" Text='<%# Bind("AS304_DateTimeFormat","{0:yyyy/MM/dd}") %>' Width="70" />
            </td>
            <%--<td>
                <asp:TextBox ID="AS305TextBox" runat="server" Text='<%# Bind("AS305") %>' Width="100" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="AS305TextBox" Mask="????????">
                </cc1:MaskedEditExtender>
            </td>--%>
            <td>
                <asp:TextBox ID="AS306TextBox" runat="server" Text='<%# Bind("AS306") %>'  Width="40" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="AS306TextBox" Mask="????">
                </cc1:MaskedEditExtender>--%>            
            </td>
            <td>
                <asp:TextBox ID="AS307TextBox" runat="server" Text='<%# Bind("AS307") %>'  Width="20" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="AS307TextBox" Mask="9999">
                </cc1:MaskedEditExtender> --%>               
            </td>
            <td>
                <asp:TextBox ID="AS308TextBox" runat="server" Text='<%# Bind("AS308","{0:0.00}") %>' Width="60" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="AS308TextBox" Mask="999999.99" MaskType="Number"   InputDirection="RightToLeft" DisplayMoney="Left">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS309TextBox" runat="server" Text='<%# Bind("AS309") %>' Width="30" />
                 <%--<cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="AS309TextBox" Mask="99">
                </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                <asp:TextBox ID="AS310TextBox" runat="server" Text='<%# Bind("AS310") %>' Width="100" />
            </td>
            <td>
                <asp:TextBox ID="AS311TextBoxEdit" runat="server" Text='<%# Bind("AS311") %>' Width="50" />
                <%--<cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="AS311TextBoxEdit" Mask="99999">
                </cc1:MaskedEditExtender>--%>
                <asp:Button ID="btnEmployeeSearchEdit" runat="server" Text="查詢" OnClick="btnEmployeeSearch2_Click" />
            </td>
             <td>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("AS312") %>' >
                <asp:ListItem Value="01" >使用中</asp:ListItem>
                <asp:ListItem Value="02" >已報廢</asp:ListItem>
                <asp:ListItem Value="03" >已繳回</asp:ListItem>
                <asp:ListItem Value="04" >已變賣</asp:ListItem>
               </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="AS393TextBox" runat="server" Text='<%# Bind("AS393") %>' Width="100" />
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
                <asp:Label ID="AS301Label" runat="server" Text='<%# Eval("AS301") %>' />
            </td>
            <td>
                <asp:Label ID="AS302Label" runat="server" Text='<%# Eval("AS302") %>' />
            </td>
            <td>
                <asp:Label ID="AS303Label" runat="server" Text='<%# Eval("AS303") %>' />
            </td>
            <td>
                <asp:Label ID="AS304Label" runat="server" Text='<%# Eval("AS304") %>' />
            </td>
            <%--<td>
                <asp:Label ID="AS305Label" runat="server" Text='<%# Eval("AS305") %>' />
            </td>--%>
            <td>
                <asp:Label ID="AS306Label" runat="server" Text='<%# Eval("AS306") %>' />
            </td>
            <td>
                <asp:Label ID="AS307Label" runat="server" Text='<%# Eval("AS307") %>' />
            </td>
            <td>
                <asp:Label ID="AS308Label" runat="server" Text='<%# Eval("AS308") %>' />
            </td>
            <td>
                <asp:Label ID="AS309Label" runat="server" Text='<%# Eval("AS309") %>' />
            </td>
            <td>
                <asp:Label ID="AS310Label" runat="server" Text='<%# Eval("AS310") %>' />
            </td>
            <td>
                <asp:Label ID="AS311Label" runat="server" Text='<%# Eval("AS311") %>' />
            </td>
              <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AS312_Explain") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AS393") %>' />
            </td>
       </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.AST500LB.AST103PF" 
    DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" 
    TypeName="Accounting.NonConsumFAMEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSearchSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <uc1:EmployeeSampleSearch ID="EmployeeSampleSearch1" runat="server" />
    </asp:View>
</asp:MultiView>


