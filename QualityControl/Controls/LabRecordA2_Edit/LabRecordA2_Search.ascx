<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Search.ascx.vb" Inherits="QualityControl.LabRecordA2_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="QualityControl" %>
<style type="text/css">
    .QueryTable {
        width: 85%;
        border-width: 4px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

    .QueryTable_tab {
    }

    .QueryTable_Lable {
        width: 90px;
    }

    .QueryTable_TextBox {
        width: auto;
    }
    .detail_tr1 {
    }

    .completionListElement {
        visibility: hidden;
        margin: 0px !important;
        background-color: inherit;
        color: black;
        border: solid 1px gray;
        cursor: pointer;
        text-align: left;
        list-style-type: none;
        font-family: Verdana;
        font-size: 12px;
        padding: 0;
    }

    .listItem {
        background-color: white;
        padding: 1px;
    }

    .highlightedListItem {
        background-color: #c3ebf9;
        padding: 1px;
    }

    .View2-Table {
        width: 85%;
        border-width: 0px;
        border-style: none;
        border-collapse: collapse;
        border-color: #cccccc;
    }

    .View2_TD_B {
        width: 40px;
        border-right-width: 4px;
        border-right-width: 4px;
        border-right-style: dotted;
        border-right-color: #cccccc;
    }

    .View2_TD_A {
        width: 40px;
    }

    .auto-style19 {
        height: 35px;
    }

    .auto-style22 {
        height: 20px;
    }
    .auto-style23 {
        width: 90px;
        height: 24px;
    }
    .auto-style24 {
        width: auto;
        height: 24px;
    }

    </style>


<table class="QueryTable">
    <tr>
        <td class="QueryTable_tab" colspan="3">一、查詢單據</td>
    </tr>
    <tr>
        <td class="QueryTable_tab" rowspan="7">&nbsp;</td>
        <td class="QueryTable_Lable">查詢種類：</td>
        <td class="QueryTable_TextBox">
            <asp:DropDownList ID="ddl_UI_Type" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">工作清單</asp:ListItem>
                <asp:ListItem Value="1">材證報表</asp:ListItem>
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">日期<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label3">：</span></td>
        <td class="QueryTable_TextBox">
            <asp:TextBox ID="tbDateS" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateS">
            </cc1:CalendarExtender>
            &nbsp;~
            <asp:TextBox ID="tbDateE" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateE">
            </cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">提貨單號<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label4">：</span>


        </td>
        <td class="QueryTable_TextBox">
            <asp:TextBox ID="tb_deliveryNo" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:Label ID="lb_cus" runat="server" Text="客戶代碼： "></asp:Label>


        </td>
        <td class="auto-style24">
            <asp:TextBox ID="tbBuyer" runat="server"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="tbBuyer_AutoCompleteExtender" runat="server" MinimumPrefixLength="1" ServiceMethod="getCompanyInfo" TargetControlID="tbBuyer" ServicePath="WebService_autocomplete.asmx" CompletionListCssClass="completionListElement" CompletionListHighlightedItemCssClass="highlightedListItem" CompletionListItemCssClass="listItem">
            </cc1:AutoCompleteExtender>
            <asp:Label ID="lb_buyerRemark" runat="server" Text="(輸入客戶代碼)"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">鋼捲號碼<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label6">：</span> </td>
        <td class="QueryTable_TextBox">
            <asp:TextBox ID="tbCoilno" runat="server"></asp:TextBox>

            (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">單據種類<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label7">：</span></td>
        <td class="QueryTable_TextBox">
            <asp:DropDownList ID="ddl_labkind" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="align-self: center" colspan="2" class="auto-style19">
            <asp:Button ID="btnSearch" runat="server" Height="33px" Text="查詢" Width="112px" />

<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
            



<asp:ObjectDataSource ID="ods" runat="server" SelectMethod="Search" TypeName="QualityControl.LabRecordA2_Search">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
        </td>
    </tr>
    </table>


    <asp:Button ID="btnSelectAll" runat="server" Text="全選" Height="25px" />
    <asp:Button ID="btnClearAll" runat="server" Height="25px" Text="清除" />
    <asp:Button ID="btnMakelab" runat="server" Height="25px" Text="列印勾選項目" Width="100px" />
    <asp:Button ID="btnMakeAll" runat="server" Text="列印所有項目" Height="25px" Width="100px" />
    <br />
<asp:ListView ID="ListView2" runat="server" DataSourceID="ods" EnableModelValidation="True">
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFF8DC;">
                            <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td>                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" Text='<%# Eval("BOL02") %>' />
                            </td>
                             <td>
                                <asp:Label ID="lb_contract" runat="server" Text='<%# Eval("BOL03")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lb_date" runat="server" Text='<%# Eval("BOL01")%>' />
                            </td>
                            <td>
                            <%-- <td>
                                <asp:Label ID="lb_contract" runat="server" Text='<%# FS_ContractNo(Eval("BOL02"))%>' />
                            </td>
                            <td>
                                <asp:Label ID="lb_date" runat="server" Text='<%# FS_DeliveryDate(Eval("BOL02"))%>' />
                            </td>
                            <td>--%>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("BOL02")%>' Enabled ="false" Visible ="false"  />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否停用該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="預覽" OnClick="preview" ToolTip='<%# Eval("BOL02")%>'  />
                                <asp:DropDownList ID="ddl_Specification" runat="server" AutoPostBack="True" ToolTip ='<%# Eval("BOL02")%>'/>
                                    
                                </asp:DropDownList>
                            </td> 
                            <%--<td>
                                <asp:Button ID="btn_ShowDetail" runat="server" CommandName="Edit" OnClick="btn_ShowDetail_Click" Text="檢視明細" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btnPreview" runat="server" OnClick="preview" Text="預覽" ToolTip='<%# Eval("BOL02") %>' />
                            </td>--%>
                            <%--                <td>
                    <asp:Label ID="BOL03Label" runat="server" Text='<%# Eval("BOL03") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL04Label" runat="server" Text='<%# Eval("BOL04") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL05Label" runat="server" Text='<%# Eval("BOL05") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL06Label" runat="server" Text='<%# Eval("BOL06") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL07Label" runat="server" Text='<%# Eval("BOL07") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL08Label" runat="server" Text='<%# Eval("BOL08") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL09Label" runat="server" Text='<%# Eval("BOL09") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL10Label" runat="server" Text='<%# Eval("BOL10") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL11Label" runat="server" Text='<%# Eval("BOL11") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL12Label" runat="server" Text='<%# Eval("BOL12") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL13Label" runat="server" Text='<%# Eval("BOL13") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL14Label" runat="server" Text='<%# Eval("BOL14") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL15Label" runat="server" Text='<%# Eval("BOL15") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL16Label" runat="server" Text='<%# Eval("BOL16") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL17Label" runat="server" Text='<%# Eval("BOL17") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL18Label" runat="server" Text='<%# Eval("BOL18") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL19Label" runat="server" Text='<%# Eval("BOL19") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL20Label" runat="server" Text='<%# Eval("BOL20") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL21Label" runat="server" Text='<%# Eval("BOL21") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL22Label" runat="server" Text='<%# Eval("BOL22") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL23Label" runat="server" Text='<%# Eval("BOL23") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL24Label" runat="server" Text='<%# Eval("BOL24") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL25Label" runat="server" Text='<%# Eval("BOL25") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL26Label" runat="server" Text='<%# Eval("BOL26") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL27Label" runat="server" Text='<%# Eval("BOL27") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL28Label" runat="server" Text='<%# Eval("BOL28") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL29Label" runat="server" Text='<%# Eval("BOL29") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL30Label" runat="server" Text='<%# Eval("BOL30") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL33Label" runat="server" Text='<%# Eval("BOL33") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL34Label" runat="server" Text='<%# Eval("BOL34") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL35Label" runat="server" Text='<%# Eval("BOL35") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL31Label" runat="server" Text='<%# Eval("BOL31") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL32Label" runat="server" Text='<%# Eval("BOL32") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL91Label" runat="server" Text='<%# Eval("BOL91") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL92Label" runat="server" Text='<%# Eval("BOL92") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL93Label" runat="server" Text='<%# Eval("BOL93") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL94Label" runat="server" Text='<%# Eval("BOL94") %>' />
                </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="background-color: #008A8C; color: #FFFFFF;">
                            <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td>                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" Text='<%# Eval("BOL02") %>' />
                            </td>
                             <td>
                                <asp:Label ID="lb_contract" runat="server" Text='<%# Eval("BOL03")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lb_date" runat="server" Text='<%# Eval("BOL01")%>' />
                            </td>
                             <td>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="隱藏設定" OnClick="btn_hideSetting_Click" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("BOL02")%>' Enabled ="false" Visible ="false"  />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否停用該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="預覽" OnClick="preview" ToolTip='<%# Eval("BOL02")%>'  />
                                 <asp:DropDownList ID="ddl_Specification" runat="server" AutoPostBack="True" ToolTip ='<%# Eval("BOL02")%>'/>
                            </td> 
                            <%--<td>
                                <asp:Button ID="btn_ShowDetail" runat="server" CommandName="Edit" OnClick="btn_ShowDetail_Click" Text="檢視明細" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btnPreview" runat="server" OnClick="preview" Text="預覽" ToolTip='<%# Eval("BOL02") %>' />
                            </td>--%>
                            <%--                <td>
                    <asp:Label ID="BOL03Label" runat="server" Text='<%# Eval("BOL03") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL04Label" runat="server" Text='<%# Eval("BOL04") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL05Label" runat="server" Text='<%# Eval("BOL05") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL06Label" runat="server" Text='<%# Eval("BOL06") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL07Label" runat="server" Text='<%# Eval("BOL07") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL08Label" runat="server" Text='<%# Eval("BOL08") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL09Label" runat="server" Text='<%# Eval("BOL09") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL10Label" runat="server" Text='<%# Eval("BOL10") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL11Label" runat="server" Text='<%# Eval("BOL11") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL12Label" runat="server" Text='<%# Eval("BOL12") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL13Label" runat="server" Text='<%# Eval("BOL13") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL14Label" runat="server" Text='<%# Eval("BOL14") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL15Label" runat="server" Text='<%# Eval("BOL15") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL16Label" runat="server" Text='<%# Eval("BOL16") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL17Label" runat="server" Text='<%# Eval("BOL17") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL18Label" runat="server" Text='<%# Eval("BOL18") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL19Label" runat="server" Text='<%# Eval("BOL19") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL20Label" runat="server" Text='<%# Eval("BOL20") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL21Label" runat="server" Text='<%# Eval("BOL21") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL22Label" runat="server" Text='<%# Eval("BOL22") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL23Label" runat="server" Text='<%# Eval("BOL23") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL24Label" runat="server" Text='<%# Eval("BOL24") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL25Label" runat="server" Text='<%# Eval("BOL25") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL26Label" runat="server" Text='<%# Eval("BOL26") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL27Label" runat="server" Text='<%# Eval("BOL27") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL28Label" runat="server" Text='<%# Eval("BOL28") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL29Label" runat="server" Text='<%# Eval("BOL29") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL30Label" runat="server" Text='<%# Eval("BOL30") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL33Label" runat="server" Text='<%# Eval("BOL33") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL34Label" runat="server" Text='<%# Eval("BOL34") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL35Label" runat="server" Text='<%# Eval("BOL35") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL31Label" runat="server" Text='<%# Eval("BOL31") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL32Label" runat="server" Text='<%# Eval("BOL32") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL91Label" runat="server" Text='<%# Eval("BOL91") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL92Label" runat="server" Text='<%# Eval("BOL92") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL93Label" runat="server" Text='<%# Eval("BOL93") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL94Label" runat="server" Text='<%# Eval("BOL94") %>' />
                </td>--%>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr>
                                <td>未傳回資料。</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                                <asp:Button ID="CancelButton0" runat="server" CommandName="Cancel" Text="清除" />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL01TextBox0" runat="server" Text='<%# Bind("BOL01") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL02TextBox0" runat="server" Text='<%# Bind("BOL02") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL03TextBox0" runat="server" Text='<%# Bind("BOL03") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL04TextBox0" runat="server" Text='<%# Bind("BOL04") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL05TextBox0" runat="server" Text='<%# Bind("BOL05") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL06TextBox0" runat="server" Text='<%# Bind("BOL06") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL07TextBox0" runat="server" Text='<%# Bind("BOL07") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL08TextBox0" runat="server" Text='<%# Bind("BOL08") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL09TextBox0" runat="server" Text='<%# Bind("BOL09") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL10TextBox0" runat="server" Text='<%# Bind("BOL10") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL11TextBox0" runat="server" Text='<%# Bind("BOL11") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL12TextBox0" runat="server" Text='<%# Bind("BOL12") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL13TextBox0" runat="server" Text='<%# Bind("BOL13") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL14TextBox0" runat="server" Text='<%# Bind("BOL14") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL15TextBox0" runat="server" Text='<%# Bind("BOL15") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL16TextBox0" runat="server" Text='<%# Bind("BOL16") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL17TextBox0" runat="server" Text='<%# Bind("BOL17") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL18TextBox0" runat="server" Text='<%# Bind("BOL18") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL19TextBox0" runat="server" Text='<%# Bind("BOL19") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL20TextBox0" runat="server" Text='<%# Bind("BOL20") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL21TextBox0" runat="server" Text='<%# Bind("BOL21") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL22TextBox0" runat="server" Text='<%# Bind("BOL22") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL23TextBox0" runat="server" Text='<%# Bind("BOL23") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL24TextBox0" runat="server" Text='<%# Bind("BOL24") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL25TextBox0" runat="server" Text='<%# Bind("BOL25") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL26TextBox0" runat="server" Text='<%# Bind("BOL26") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL27TextBox0" runat="server" Text='<%# Bind("BOL27") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL28TextBox0" runat="server" Text='<%# Bind("BOL28") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL29TextBox0" runat="server" Text='<%# Bind("BOL29") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL30TextBox0" runat="server" Text='<%# Bind("BOL30") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL33TextBox0" runat="server" Text='<%# Bind("BOL33") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL34TextBox0" runat="server" Text='<%# Bind("BOL34") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL35TextBox0" runat="server" Text='<%# Bind("BOL35") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL31TextBox0" runat="server" Text='<%# Bind("BOL31") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL32TextBox0" runat="server" Text='<%# Bind("BOL32") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL91TextBox0" runat="server" Text='<%# Bind("BOL91") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL92TextBox0" runat="server" Text='<%# Bind("BOL92") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL93TextBox0" runat="server" Text='<%# Bind("BOL93") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL94TextBox0" runat="server" Text='<%# Bind("BOL94") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsAlreadyOutOfFactoryCheckBox0" runat="server" Checked='<%# Bind("IsAlreadyOutOfFactory") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsHomeSellCheckBox0" runat="server" Checked='<%# Bind("IsHomeSell") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CoilNumberTextBox0" runat="server" Text='<%# Bind("CoilNumber") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CarNumberTextBox0" runat="server" Text='<%# Bind("CarNumber") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="BOL04_DateFormatTextBox0" runat="server" Text='<%# Bind("BOL04_DateFormat") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsCanOutFactoryNowCheckBox0" runat="server" Checked='<%# Bind("IsCanOutFactoryNow") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CanNotOutFactoryNowReasonTextBox0" runat="server" Text='<%# Bind("CanNotOutFactoryNowReason") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CustomerNameTextBox0" runat="server" Text='<%# Bind("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CROrHRTextBox0" runat="server" Text='<%# Bind("CROrHR") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="SQLQueryAdapterByThisObjectTextBox0" runat="server" Text='<%# Bind("SQLQueryAdapterByThisObject") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCurrentUseSQLQueryAdapterTextBox0" runat="server" Text='<%# Bind("CDBCurrentUseSQLQueryAdapter") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBLibraryNameTextBox0" runat="server" Text='<%# Bind("CDBLibraryName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBFileNameTextBox0" runat="server" Text='<%# Bind("CDBFileName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBMemberNameTextBox0" runat="server" Text='<%# Bind("CDBMemberName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBFullAS400DBPathTextBox0" runat="server" Text='<%# Bind("CDBFullAS400DBPath") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBInsertSQLStringTextBox0" runat="server" Text='<%# Bind("CDBInsertSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBUpdateSQLStringTextBox0" runat="server" Text='<%# Bind("CDBUpdateSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBDeleteSQLStringTextBox0" runat="server" Text='<%# Bind("CDBDeleteSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBClassFieldNamesTextBox0" runat="server" Text='<%# Bind("CDBClassFieldNames") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBPKFieldsPropertyInfoTextBox0" runat="server" Text='<%# Bind("CDBPKFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBFieldsPropertyInfoTextBox0" runat="server" Text='<%# Bind("CDBFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBSelectByThisRecordSQLStringTextBox0" runat="server" Text='<%# Bind("CDBSelectByThisRecordSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBOrginDataRowTextBox0" runat="server" Text='<%# Bind("CDBOrginDataRow") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBClassDBPropertyFieldNamesTextBox0" runat="server" Text='<%# Bind("CDBClassDBPropertyFieldNames") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDClassTextBox0" runat="server" Text='<%# Bind("CDBCRUDClass") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlSourceTextBox0" runat="server" Text='<%# Bind("CDBCRUDXmlSource") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlInsertTextBox0" runat="server" Text='<%# Bind("CDBCRUDXmlInsert") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlUpdateTextBox0" runat="server" Text='<%# Bind("CDBCRUDXmlUpdate") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlDeleteTextBox0" runat="server" Text='<%# Bind("CDBCRUDXmlDelete") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td>                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" Text='<%# Eval("BOL02") %>' />
                            </td>
                             <td>
                                <asp:Label ID="lb_contract" runat="server" Text='<%# Eval("BOL03")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lb_date" runat="server" Text='<%# Eval("BOL01")%>' />
                            </td>
                            <td>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("BOL02")%>' Enabled ="false" Visible ="false"  />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否停用該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="預覽" OnClick="preview" ToolTip='<%# Eval("BOL02")%>'  />
                                <asp:DropDownList ID="ddl_Specification" runat="server" AutoPostBack="True" ToolTip ='<%# Eval("BOL02")%>'/>
                            </td> 
                            <%--<td>
                                <asp:Button ID="btn_ShowDetail" runat="server" CommandName="Edit" OnClick="btn_ShowDetail_Click" Text="檢視明細" ToolTip='<%# Eval("BOL02") %>' />
                                <asp:Button ID="btnPreview" runat="server" OnClick="preview" Text="預覽" ToolTip='<%# Eval("BOL02") %>' />
                            </td>--%>
                            <%--               <td>
                    <asp:Label ID="BOL03Label" runat="server" Text='<%# Eval("BOL03") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL04Label" runat="server" Text='<%# Eval("BOL04") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL05Label" runat="server" Text='<%# Eval("BOL05") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL06Label" runat="server" Text='<%# Eval("BOL06") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL07Label" runat="server" Text='<%# Eval("BOL07") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL08Label" runat="server" Text='<%# Eval("BOL08") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL09Label" runat="server" Text='<%# Eval("BOL09") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL10Label" runat="server" Text='<%# Eval("BOL10") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL11Label" runat="server" Text='<%# Eval("BOL11") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL12Label" runat="server" Text='<%# Eval("BOL12") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL13Label" runat="server" Text='<%# Eval("BOL13") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL14Label" runat="server" Text='<%# Eval("BOL14") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL15Label" runat="server" Text='<%# Eval("BOL15") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL16Label" runat="server" Text='<%# Eval("BOL16") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL17Label" runat="server" Text='<%# Eval("BOL17") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL18Label" runat="server" Text='<%# Eval("BOL18") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL19Label" runat="server" Text='<%# Eval("BOL19") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL20Label" runat="server" Text='<%# Eval("BOL20") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL21Label" runat="server" Text='<%# Eval("BOL21") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL22Label" runat="server" Text='<%# Eval("BOL22") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL23Label" runat="server" Text='<%# Eval("BOL23") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL24Label" runat="server" Text='<%# Eval("BOL24") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL25Label" runat="server" Text='<%# Eval("BOL25") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL26Label" runat="server" Text='<%# Eval("BOL26") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL27Label" runat="server" Text='<%# Eval("BOL27") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL28Label" runat="server" Text='<%# Eval("BOL28") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL29Label" runat="server" Text='<%# Eval("BOL29") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL30Label" runat="server" Text='<%# Eval("BOL30") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL33Label" runat="server" Text='<%# Eval("BOL33") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL34Label" runat="server" Text='<%# Eval("BOL34") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL35Label" runat="server" Text='<%# Eval("BOL35") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL31Label" runat="server" Text='<%# Eval("BOL31") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL32Label" runat="server" Text='<%# Eval("BOL32") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL91Label" runat="server" Text='<%# Eval("BOL91") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL92Label" runat="server" Text='<%# Eval("BOL92") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL93Label" runat="server" Text='<%# Eval("BOL93") %>' />
                </td>
                <td>
                    <asp:Label ID="BOL94Label" runat="server" Text='<%# Eval("BOL94") %>' />
                </td>--%>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                            <th runat="server">選取</th>                                            
                                            <th runat="server">提貨單號</th>
                                            <th runat="server">訂單號碼</th>
                                            <th runat="server">提貨單日期</th>
                                            <th runat="server">動作</th>
                                            <%--<th runat="server">BOL03</th>
                                <th runat="server">BOL04</th>
                                <th runat="server">BOL05</th>
                                <th runat="server">BOL06</th>
                                <th runat="server">BOL07</th>
                                <th runat="server">BOL08</th>
                                <th runat="server">BOL09</th>
                                <th runat="server">BOL10</th>
                                <th runat="server">BOL11</th>
                                <th runat="server">BOL12</th>
                                <th runat="server">BOL13</th>
                                <th runat="server">BOL14</th>
                                <th runat="server">BOL15</th>
                                <th runat="server">BOL16</th>
                                <th runat="server">BOL17</th>
                                <th runat="server">BOL18</th>
                                <th runat="server">BOL19</th>
                                <th runat="server">BOL20</th>
                                <th runat="server">BOL21</th>
                                <th runat="server">BOL22</th>
                                <th runat="server">BOL23</th>
                                <th runat="server">BOL24</th>
                                <th runat="server">BOL25</th>
                                <th runat="server">BOL26</th>
                                <th runat="server">BOL27</th>
                                <th runat="server">BOL28</th>
                                <th runat="server">BOL29</th>
                                <th runat="server">BOL30</th>
                                <th runat="server">BOL33</th>
                                <th runat="server">BOL34</th>
                                <th runat="server">BOL35</th>
                                <th runat="server">BOL31</th>
                                <th runat="server">BOL32</th>
                                <th runat="server">BOL91</th>
                                <th runat="server">BOL92</th>
                                <th runat="server">BOL93</th>
                                <th runat="server">BOL94</th>             --%>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
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
                                <asp:Label ID="BOL01Label" runat="server" Text='<%# Eval("BOL01") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL02Label1" runat="server" Text='<%# Eval("BOL02") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL03Label" runat="server" Text='<%# Eval("BOL03") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL04Label" runat="server" Text='<%# Eval("BOL04") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL05Label" runat="server" Text='<%# Eval("BOL05") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL06Label" runat="server" Text='<%# Eval("BOL06") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL07Label" runat="server" Text='<%# Eval("BOL07") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL08Label" runat="server" Text='<%# Eval("BOL08") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL09Label" runat="server" Text='<%# Eval("BOL09") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL10Label" runat="server" Text='<%# Eval("BOL10") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL11Label" runat="server" Text='<%# Eval("BOL11") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL12Label" runat="server" Text='<%# Eval("BOL12") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL13Label" runat="server" Text='<%# Eval("BOL13") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL14Label" runat="server" Text='<%# Eval("BOL14") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL15Label" runat="server" Text='<%# Eval("BOL15") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL16Label" runat="server" Text='<%# Eval("BOL16") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL17Label" runat="server" Text='<%# Eval("BOL17") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL18Label" runat="server" Text='<%# Eval("BOL18") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL19Label" runat="server" Text='<%# Eval("BOL19") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL20Label" runat="server" Text='<%# Eval("BOL20") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL21Label" runat="server" Text='<%# Eval("BOL21") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL22Label" runat="server" Text='<%# Eval("BOL22") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL23Label" runat="server" Text='<%# Eval("BOL23") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL24Label" runat="server" Text='<%# Eval("BOL24") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL25Label" runat="server" Text='<%# Eval("BOL25") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL26Label" runat="server" Text='<%# Eval("BOL26") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL27Label" runat="server" Text='<%# Eval("BOL27") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL28Label" runat="server" Text='<%# Eval("BOL28") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL29Label" runat="server" Text='<%# Eval("BOL29") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL30Label" runat="server" Text='<%# Eval("BOL30") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL33Label" runat="server" Text='<%# Eval("BOL33") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL34Label" runat="server" Text='<%# Eval("BOL34") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL35Label" runat="server" Text='<%# Eval("BOL35") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL31Label" runat="server" Text='<%# Eval("BOL31") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL32Label" runat="server" Text='<%# Eval("BOL32") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL91Label" runat="server" Text='<%# Eval("BOL91") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL92Label" runat="server" Text='<%# Eval("BOL92") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL93Label" runat="server" Text='<%# Eval("BOL93") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL94Label" runat="server" Text='<%# Eval("BOL94") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsAlreadyOutOfFactoryCheckBox1" runat="server" Checked='<%# Eval("IsAlreadyOutOfFactory") %>' Enabled="false" />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsHomeSellCheckBox1" runat="server" Checked='<%# Eval("IsHomeSell") %>' Enabled="false" />
                            </td>
                            <td>
                                <asp:Label ID="CoilNumberLabel" runat="server" Text='<%# Eval("CoilNumber") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CarNumberLabel" runat="server" Text='<%# Eval("CarNumber") %>' />
                            </td>
                            <td>
                                <asp:Label ID="BOL04_DateFormatLabel" runat="server" Text='<%# Eval("BOL04_DateFormat") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="IsCanOutFactoryNowCheckBox1" runat="server" Checked='<%# Eval("IsCanOutFactoryNow") %>' Enabled="false" />
                            </td>
                            <td>
                                <asp:Label ID="CanNotOutFactoryNowReasonLabel" runat="server" Text='<%# Eval("CanNotOutFactoryNowReason") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CROrHRLabel" runat="server" Text='<%# Eval("CROrHR") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SQLQueryAdapterByThisObjectLabel" runat="server" Text='<%# Eval("SQLQueryAdapterByThisObject") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCurrentUseSQLQueryAdapterLabel" runat="server" Text='<%# Eval("CDBCurrentUseSQLQueryAdapter") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBLibraryNameLabel" runat="server" Text='<%# Eval("CDBLibraryName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBFileNameLabel" runat="server" Text='<%# Eval("CDBFileName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBMemberNameLabel" runat="server" Text='<%# Eval("CDBMemberName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBFullAS400DBPathLabel" runat="server" Text='<%# Eval("CDBFullAS400DBPath") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBInsertSQLStringLabel" runat="server" Text='<%# Eval("CDBInsertSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBUpdateSQLStringLabel" runat="server" Text='<%# Eval("CDBUpdateSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBDeleteSQLStringLabel" runat="server" Text='<%# Eval("CDBDeleteSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBClassFieldNamesLabel" runat="server" Text='<%# Eval("CDBClassFieldNames") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBPKFieldsPropertyInfoLabel" runat="server" Text='<%# Eval("CDBPKFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBFieldsPropertyInfoLabel" runat="server" Text='<%# Eval("CDBFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBSelectByThisRecordSQLStringLabel" runat="server" Text='<%# Eval("CDBSelectByThisRecordSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBOrginDataRowLabel" runat="server" Text='<%# Eval("CDBOrginDataRow") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBClassDBPropertyFieldNamesLabel" runat="server" Text='<%# Eval("CDBClassDBPropertyFieldNames") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDClassLabel" runat="server" Text='<%# Eval("CDBCRUDClass") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlSourceLabel" runat="server" Text='<%# Eval("CDBCRUDXmlSource") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlInsertLabel" runat="server" Text='<%# Eval("CDBCRUDXmlInsert") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlUpdateLabel" runat="server" Text='<%# Eval("CDBCRUDXmlUpdate") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlDeleteLabel" runat="server" Text='<%# Eval("CDBCRUDXmlDelete") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
 <asp:ListView ID="ListView1" runat="server" DataSourceID="ods0" EnableModelValidation="True" Visible="False">
                    <AlternatingItemTemplate>
                        <tr style="background-color:#FFF8DC;">
                            <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td> 
                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" ToolTip='<%# Eval("LABREPORT_NO")%>' Text='<%# Eval("DELIVERY_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CONTRACT_NOLabel" runat="server" Text='<%# Eval("CONTRACT_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_ConvertToTaiwanDate(Eval("SAVE_DATATIME"))%>' />
                            </td>        
                            <td>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="作廢" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  Visible ="false" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否作廢該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                            </td>                    
                        </tr>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                              <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td> 
                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" ToolTip='<%# Eval("LABREPORT_NO")%>' Text='<%# Eval("DELIVERY_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CONTRACT_NOLabel" runat="server" Text='<%# Eval("CONTRACT_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_ConvertToTaiwanDate(Eval("SAVE_DATATIME"))%>' />
                            </td>        
                             <td>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="隱藏設定" OnClick="btn_hideSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="作廢" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  Visible ="false" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否作廢該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                            </td>     
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>未傳回資料。</td>
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
                                <asp:TextBox ID="LABREPORT_NOTextBox" runat="server" Text='<%# Bind("LABREPORT_NO") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CUSTOMERTextBox" runat="server" Text='<%# Bind("CUSTOMER") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CONTRACT_NOTextBox" runat="server" Text='<%# Bind("CONTRACT_NO") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LC_NOTextBox" runat="server" Text='<%# Bind("LC_NO") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="DELIVERY_NOTextBox" runat="server" Text='<%# Bind("DELIVERY_NO") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="SAVE_DATATIMETextBox" runat="server" Text='<%# Bind("SAVE_DATATIME") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="REMARK_LISTTextBox" runat="server" Text='<%# Bind("REMARK_LIST") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EFF_FLAGTextBox" runat="server" Text='<%# Bind("EFF_FLAG") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="SQLQueryAdapterByThisObjectTextBox" runat="server" Text='<%# Bind("SQLQueryAdapterByThisObject") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCurrentUseSQLQueryAdapterTextBox" runat="server" Text='<%# Bind("CDBCurrentUseSQLQueryAdapter") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBClassFieldNamesTextBox" runat="server" Text='<%# Bind("CDBClassFieldNames") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBPKFieldsPropertyInfoTextBox" runat="server" Text='<%# Bind("CDBPKFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBFieldsPropertyInfoTextBox" runat="server" Text='<%# Bind("CDBFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBInsertSQLStringTextBox" runat="server" Text='<%# Bind("CDBInsertSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBUpdateSQLStringTextBox" runat="server" Text='<%# Bind("CDBUpdateSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBDeleteSQLStringTextBox" runat="server" Text='<%# Bind("CDBDeleteSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBSelectByThisRecordSQLStringTextBox" runat="server" Text='<%# Bind("CDBSelectByThisRecordSQLString") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBOrginDataRowTextBox" runat="server" Text='<%# Bind("CDBOrginDataRow") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBClassDBPropertyFieldNamesTextBox" runat="server" Text='<%# Bind("CDBClassDBPropertyFieldNames") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDClassTextBox" runat="server" Text='<%# Bind("CDBCRUDClass") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlSourceTextBox" runat="server" Text='<%# Bind("CDBCRUDXmlSource") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlInsertTextBox" runat="server" Text='<%# Bind("CDBCRUDXmlInsert") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlUpdateTextBox" runat="server" Text='<%# Bind("CDBCRUDXmlUpdate") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CDBCRUDXmlDeleteTextBox" runat="server" Text='<%# Bind("CDBCRUDXmlDelete") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color:#DCDCDC;color: #000000;">
                              <td>
                                <asp:CheckBox ID="cb_Select" runat="server" />
                            </td> 
                            
                            <td>
                                <asp:Label ID="BOL02Label" runat="server" ToolTip='<%# Eval("LABREPORT_NO")%>' Text='<%# Eval("DELIVERY_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CONTRACT_NOLabel" runat="server" Text='<%# Eval("CONTRACT_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_ConvertToTaiwanDate(Eval("SAVE_DATATIME"))%>' />
                            </td>        
                            <td>
                                <asp:Button  Width="103px" ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                                <asp:Button ID="btn_invalid" runat="server" Text="作廢" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  Visible ="false" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_invalid" ConfirmText="是否作廢該單據?" />
                                <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                            </td>     
                            
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                            
                                            <th runat="server">選取</th>
                                            <th runat="server">提貨單號</th>
                                            <th runat="server">訂單號碼</th>
                                            <%--<th runat="server">信用狀號碼</th>--%>
                                            
                                            <th runat="server">儲存日期</th>
                                            <th runat="server">動作</th>
                                            <%--<th runat="server">REMARK_LIST</th>--%>
                                            
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
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
                        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                            <td>
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                            </td>
                            <td>
                                <asp:Label ID="LABREPORT_NOLabel" runat="server" Text='<%# Eval("LABREPORT_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CUSTOMERLabel" runat="server" Text='<%# Eval("CUSTOMER") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CONTRACT_NOLabel" runat="server" Text='<%# Eval("CONTRACT_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LC_NOLabel" runat="server" Text='<%# Eval("LC_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DELIVERY_NOLabel" runat="server" Text='<%# Eval("DELIVERY_NO") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# Eval("SAVE_DATATIME") %>' />
                            </td>
                            <td>
                                <asp:Label ID="REMARK_LISTLabel" runat="server" Text='<%# Eval("REMARK_LIST") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SQLQueryAdapterByThisObjectLabel" runat="server" Text='<%# Eval("SQLQueryAdapterByThisObject") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCurrentUseSQLQueryAdapterLabel" runat="server" Text='<%# Eval("CDBCurrentUseSQLQueryAdapter") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBClassFieldNamesLabel" runat="server" Text='<%# Eval("CDBClassFieldNames") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBPKFieldsPropertyInfoLabel" runat="server" Text='<%# Eval("CDBPKFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBFieldsPropertyInfoLabel" runat="server" Text='<%# Eval("CDBFieldsPropertyInfo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBInsertSQLStringLabel" runat="server" Text='<%# Eval("CDBInsertSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBUpdateSQLStringLabel" runat="server" Text='<%# Eval("CDBUpdateSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBDeleteSQLStringLabel" runat="server" Text='<%# Eval("CDBDeleteSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBSelectByThisRecordSQLStringLabel" runat="server" Text='<%# Eval("CDBSelectByThisRecordSQLString") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBOrginDataRowLabel" runat="server" Text='<%# Eval("CDBOrginDataRow") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBClassDBPropertyFieldNamesLabel" runat="server" Text='<%# Eval("CDBClassDBPropertyFieldNames") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDClassLabel" runat="server" Text='<%# Eval("CDBCRUDClass") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlSourceLabel" runat="server" Text='<%# Eval("CDBCRUDXmlSource") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlInsertLabel" runat="server" Text='<%# Eval("CDBCRUDXmlInsert") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlUpdateLabel" runat="server" Text='<%# Eval("CDBCRUDXmlUpdate") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CDBCRUDXmlDeleteLabel" runat="server" Text='<%# Eval("CDBCRUDXmlDelete") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>


                <asp:Panel ID="Panel_detail" runat="server" Height="421px" Visible="False" Width="100%">
                    <cc1:TabContainer ID="tabc_showdetail" runat="server" ActiveTabIndex="0" Height="374px" ScrollBars="Both" Width="100%" Font-Size="12pt">
                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                            <HeaderTemplate>
                                鋼捲資訊
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_coils" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Font-Size="12pt">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            <asp:GridView ID="gv_chemical" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Font-Size="12pt">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                檢驗項目
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="detail_tr1">
                                            <asp:Label ID="lb_4Key1" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_assay_res_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Font-Size="12pt">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style22">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_assay_dat_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                            <HeaderTemplate>
                                附註項目
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="detail_tr1">
                                            <asp:Label ID="lb_4Key2" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_remark_res_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Font-Size="12pt">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_remark_dat_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                                                <AlternatingRowStyle BackColor="White" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </asp:Panel>


                    <asp:Button ID="btn_hideSetting" runat="server" Text="隱藏設定" ToolTip='<%# Eval("DELIVERY_NO") %>' Visible="False" />


<br />


<p>
                <asp:Label ID="lb_labno" runat="server" ForeColor="Black"></asp:Label>
                <asp:Button ID="btn_hidedetail" runat="server" Text="確定" Visible="False" Font-Size="12pt" Height="24px" Width="69px" />
                <asp:GridView ID="gv_detail" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
    <br />


                                    </p>


                                    <p>


<asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Search_SQL" TypeName="QualityControl.LabRecordA2_Search" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.LabRecordA2_M" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL0" Name="fromSQL" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQL0" runat="server" />

    <asp:HiddenField ID="hf_all_lab" runat="server" />

                                        <br />
                                    </p>


<asp:DropDownList ID="ddl_specif_mother" runat="server" Visible="False">
</asp:DropDownList>


<p>
    <asp:CheckBox ID="cb_debugmode" runat="server" AutoPostBack="True" Font-Size="8pt" Text="顯示除錯資訊" Visible="False" />

    <br />
</p>





<asp:HiddenField ID="hfSQL" runat="server" />


<asp:GridView ID="GridView3" runat="server">
</asp:GridView>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
<asp:GridView ID="GridView2" runat="server">
</asp:GridView>


