<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InvoiceOfReceivables_Search.ascx.vb" Inherits="Financial.InvoiceOfReceivables_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Financial" %>
<%@ Import Namespace="PublicClassLibrary" %>

<style type="text/css">
    .auto-style2 {
    }

    .View2-Table {
        width: 80%;
        border-width: 4px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

    .View2_TD_A {
        width: 40px;
    }

    .View2_TD_B {
        width: 40px;
        border-right-width: 4px;
        border-right-width: 4px;
        border-right-style: dotted;
        border-right-color: #cccccc;
    }

    .auto-style4 {
        width: 40px;
        height: 23px;
    }

    .auto-style5 {
        height: 23px;
    }
</style>


<table class="View2-Table">
    <tr>
        <td colspan="2">一、新增單據</td>
        <td class="View2_TD_B">&nbsp;</td>
        <td>&nbsp;</td>
        <td colspan="2">二、查詢單據</td>
    </tr>
    <tr>
        <td class="View2_TD_A " rowspan="7">&nbsp;</td>
        <td class="View2_TD_A ">&nbsp;</td>
        <td class="View2_TD_B" rowspan="7">&nbsp;</td>
        <td class="View2_TD_A " rowspan="7">&nbsp;</td>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="日期："></asp:Label>
            <asp:TextBox ID="tbDateS" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateS_CalendarExtender" runat="server" BehaviorID="calendar1"
                Enabled="True" TargetControlID="tbDateS" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>

            <asp:Label ID="Label2" runat="server" Text="&amp;nbsp~&amp;nbsp"></asp:Label>
            <asp:TextBox ID="tbDateE" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateE_CalendarExtender" runat="server" BehaviorID="calendar2"
                Enabled="True" TargetControlID="tbDateE" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="部門："></asp:Label>
            <asp:DropDownList ID="ddUnit" runat="server" Height="19px" Width="148px">
            </asp:DropDownList>


        </td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style5">
            <asp:Label ID="Label4" runat="server" Text="員工編號："></asp:Label>
            <asp:TextBox ID="tbOperator" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="單據號碼："></asp:Label>
            <asp:TextBox ID="tbInvoice_Number" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td class="View2_TD_A ">
            <asp:Button ID="btnAdd" runat="server" Text="新增單據" Height="59px" Width="228px" />


        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Height="59px" Text="查詢" Width="228px" />


        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td>
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:ObjectDataSource ID="odsSearch" runat="server" DataObjectTypeName="CompanyORMDB.COME.KIND01PF" SelectMethod="Search" TypeName="Financial.InvoiceOfReceivables_Search" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="SQLString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>


        </td>
    </tr>
</table>


<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
<br />
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True" DataKeyNames="KD101,KD102">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯"    
                                Enabled ='<%# showEditButtonStatus(Eval("KD109"), Eval("KD107"))%>'/>
                <asp:Button ID="btnDetail" runat="server" Text="明細" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnDetail_Click" />
               <asp:Button ID="btnPrint" runat="server" Text="列印" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnPrint_Click" />
            </td>
            <td>
                <asp:Label ID="KDInfoForLabel_Number" runat="server" Text='<%# showInfoForLabel_Number(Eval("KD101"), Eval("KD102"), Eval("KD116"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInfoKeyInLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD105"), Eval("KD106"), Eval("KD104"), Eval("KD103") ) %>' />
            </td>

            <td>
                <asp:Label ID="KDInforMoneyLabel" runat="server" Text='<%# ModTools.showInfoForMoney(Eval("KD111"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInforPlayMethodLabel" runat="server" Text='<%# showInfoForPlayMethod( Eval("KD113"), Eval("KD114"), Eval("KD115") ) %>' />
            </td>
            <td>
                <asp:Label ID="KD112Label" runat="server" Text='<%# showInvoice_Status(Eval("KD112")) %>' />
            </td>
            <td>
                <asp:Label ID="KDInfoInvoiceLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD109"), Eval("KD110"), Eval("KD108"), Eval("KD107") ) %>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                
<%--                <br />
                <asp:Button ID="btnDetail" runat="server" Text="明細" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnDetail_Click" />
                <asp:Button ID="btnPrint" runat="server" Text="列印" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnPrint_Click" />--%>

            </td>
            <td>
                <asp:Label ID="KDInfoForLabel_Number" runat="server" Text='<%# showInfoForLabel_Number(Eval("KD101"), Eval("KD102"), Eval("KD116"))%>' />
            </td>

            <td>
                <asp:HiddenField ID="KD103HiddenField" runat="server" Value='<%# Bind("KD103")%>' />
                <asp:HiddenField ID="KD104HiddenField" runat="server" Value='<%# Bind("KD104")%>' />
                <asp:HiddenField ID="KD105HiddenField" runat="server" Value='<%# Bind("KD105")%>' />
                <asp:HiddenField ID="KD106HiddenField" runat="server" Value='<%# Bind("KD106")%>' />
                <asp:Label ID="KDInfoKeyInLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD105"), Eval("KD106"), Eval("KD104"), Eval("KD103") ) %>' />
            </td>

            <td>
                <asp:HiddenField ID="KD111HiddenField" runat="server" Value='<%# Bind("KD111")%>' />
                <asp:Label ID="KDInforMoneyLabel" runat="server" Text='<%# ModTools.showInfoForMoney(Eval("KD111"))%>' />
            </td>

            <td>
                <asp:HiddenField ID="KD113HiddenField" runat="server" Value='<%# Bind("KD113")%>' />
                <asp:HiddenField ID="KD114HiddenField" runat="server" Value='<%# Bind("KD114")%>' />
                <asp:HiddenField ID="KD115HiddenField" runat="server" Value='<%# Bind("KD115")%>' />
                <asp:Label ID="KDInforPlayMethodLabel" runat="server" Text='<%# showInfoForPlayMethod( Eval("KD113"), Eval("KD114"), Eval("KD115") ) %>' />
            </td>
            <td>
                <asp:HiddenField ID="KD112HiddenField" runat="server" Value='<%# Eval("KD112")%>' />
                <asp:DropDownList ID="ddKD112" runat="server" />
            </td>
            <td>
                <asp:Label ID="KDInfoInvoiceLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD109"), Eval("KD110"), Eval("KD108"), Eval("KD107") ) %>' />
            </td>

        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <%--<InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="KD101TextBox" runat="server" Text='<%# Bind("KD101") & Bind("KD102") %>' />
            </td>
            
            <td>
                <asp:TextBox ID="KD103TextBox" runat="server" Text='<%# Bind("KD103") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD104TextBox" runat="server" Text='<%# Bind("KD104") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD105TextBox" runat="server" Text='<%# Bind("KD105") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD106TextBox" runat="server" Text='<%# Bind("KD106") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD107TextBox" runat="server" Text='<%# Bind("KD107") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD108TextBox" runat="server" Text='<%# Bind("KD108") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD109TextBox" runat="server" Text='<%# Bind("KD109") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD110TextBox" runat="server" Text='<%# Bind("KD110") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD111TextBox" runat="server" Text='<%# Bind("KD111") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD112TextBox" runat="server" Text='<%# Bind("KD112") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD113TextBox" runat="server" Text='<%# Bind("KD113") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD114TextBox" runat="server" Text='<%# Bind("KD114") %>' />
            </td>
            <td>
                <asp:TextBox ID="KD115TextBox" runat="server" Text='<%# Bind("KD115") %>' />
            </td>

        </tr>
    </InsertItemTemplate>--%>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯"  
                            Enabled ='<%# showEditButtonStatus(Eval("KD109"), Eval("KD107"))%>' />
                <asp:Button ID="btnDetail" runat="server" Text="明細" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnDetail_Click" />
                <asp:Button ID="btnPrint" runat="server" Text="列印" ToolTip='<%# Eval("KD101") & InvoiceOfReceivables_Model.C_SystemChar  & Eval("KD102") %>' OnClick="btnPrint_Click" />
            </td>
            <td>
                <asp:Label ID="KDInfoForLabel_Number" runat="server" Text='<%# showInfoForLabel_Number(Eval("KD101"), Eval("KD102"), Eval("KD116"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInfoKeyInLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD105"), Eval("KD106"), Eval("KD104"), Eval("KD103") ) %>' />
            </td>

            <td>
                <asp:Label ID="KDInforMoneyLabel" runat="server" Text='<%# ModTools.showInfoForMoney(Eval("KD111"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInforPlayMethodLabel" runat="server" Text='<%# showInfoForPlayMethod( Eval("KD113"), Eval("KD114"), Eval("KD115") ) %>' />
            </td>
            <td>
                <asp:Label ID="KD112Label" runat="server" Text='<%# showInvoice_Status(Eval("KD112"))%>' />
            </td>
            <td>
                <asp:Label ID="KDInfoInvoiceLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD109"), Eval("KD110"), Eval("KD108"), Eval("KD107") ) %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server">
                                <br />
                                動作</th>
                            <th runat="server">單據號碼<br />購案編號</th>
                            <th runat="server">繳款單位</th>

                            <th runat="server">總金額</th>

                            <th runat="server">付款方式</th>
                            <th runat="server">單據狀態</th>
                            <th runat="server">收款單位</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
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
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" 
                            Enabled ='<%# showEditButtonStatus(Eval("KD109"), Eval("KD107"))%>' />
            </td>
            <td></td>
            <td>
                <asp:Label ID="KDInfoForLabel_Number" runat="server" Text='<%# showInfoForLabel_Number(Eval("KD101"), Eval("KD102"), Eval("KD116"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInfoKeyInLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD105"), Eval("KD106"), Eval("KD104"), Eval("KD103") ) %>' />
            </td>


            <td>
                <asp:Label ID="KDInforMoneyLabel" runat="server" Text='<%# ModTools.showInfoForMoney(Eval("KD111"))%>' />
            </td>

            <td>
                <asp:Label ID="KDInforPlayMethodLabel" runat="server" Text='<%# showInfoForPlayMethod( Eval("KD113"), Eval("KD114"), Eval("KD115") ) %>' />
            </td>
            <td>
                <asp:Label ID="KD112Label" runat="server" Text='<%# showInvoice_Status(Eval("KD112")) %>' />
            </td>
            <td>
                <asp:Label ID="KDInfoInvoiceLabel" runat="server" Text='<%# showInfoForLabel(Eval("KD109"), Eval("KD110"), Eval("KD108"), Eval("KD107") ) %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>














































