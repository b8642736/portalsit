<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Edit.ascx.vb" Inherits="QualityControl.LabRecordA2_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc11" %>
<%@ Import Namespace="QualityControl"%>
<style type="text/css">
    .QueryTable {
        width: 85%;
        border-width: 4px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }
    .QueryTable_tab {
        width:40px;
    }
    .QueryTable_Lable {
        width:90px;
    }
    .QueryTable_TextBox {
        width: auto;
    }

    .View2-Table {
        width: 70%;
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

    
    .auto-style18 {
        height: 20px;
    }
    

    .auto-style19 {
        height: 39px;
    }
    

    .auto-style20 {
        width: 643px;
    }
    

    </style>


<table class="QueryTable">
    <tr>
        <td class="QueryTable_tab"></td>
        <td class="QueryTable_Lable" colspan="2">二、查詢單據</td>
    </tr>
    <tr>
        <td class="QueryTable_tab " rowspan="7">&nbsp;</td>
        <td class="QueryTable_Lable">
            日期<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label8">：</span>
&nbsp;<asp:CheckBox ID="ckBydate" runat="server" Checked="True" AutoPostBack="True" />

        </td>
        <td class="auto-style20">
            <asp:TextBox ID="tbDateS" runat="server"></asp:TextBox>
<cc1:CalendarExtender ID="tbDateS_CalendarExtender" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateS">
</cc1:CalendarExtender>
            &nbsp;~ <asp:TextBox ID="tbDateE" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateE_CalendarExtender" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateE">
</cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">
            材證單號<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label9">：</span>


        </td>
        <td class="auto-style20">
            <asp:TextBox ID="tbLabno" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">
            客戶名稱<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label10">：</span>


        </td>
        <td class="auto-style20">
            <asp:TextBox ID="tbBuyer" runat="server"></asp:TextBox>


            (輸入客戶名稱)</td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">
            提貨單號<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label6">：</span> </td>
        <td class="auto-style20">
            <asp:TextBox ID="tb_deliveryNo" runat="server"></asp:TextBox>

                    (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="QueryTable_Lable">
            訂單號碼<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label7">：</span></td>
        <td class="auto-style20">
            <asp:TextBox ID="tb_orderNo" runat="server"></asp:TextBox>

                    (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="QueryTable_Lable"></td>
        <td class="auto-style20">
    </tr>
    <tr>
        <td style="align-self:center " colspan="2" class="auto-style19">
            <asp:Button ID="btnSearch" runat="server" Height="37px" Text="查詢" Width="107px" />
        </td>
    </tr>
    </table>


<asp:ObjectDataSource ID="ods" runat="server" SelectMethod="Search" TypeName="QualityControl.LabRecordA2_Edit" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.LabRecordA2_M" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQL" runat="server" />

<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>


            <asp:Panel ID="Panel_detail" runat="server" Height="421px" Width="85%" Visible="False">
                <cc1:TabContainer ID="tabc_showdetail" runat="server" ActiveTabIndex="0" Height="374px" Width="100%" ScrollBars="Both">
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            鋼捲資訊
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_coils" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                        <asp:GridView ID="gv_chemical" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
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
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            檢驗項目
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td class="auto-style18">對照檔</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_assay_res_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
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
                                    <td>基本檔</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_assay_dat_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
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
                                    <td class="auto-style18">對照檔</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_remark_res_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
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
                                    <td>基本檔</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_remark_dat_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
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

<p>
    
<asp:Button ID="btn_hideSetting" runat="server" Text="隱藏設定" ToolTip='<%# Eval("DELIVERY_NO") %>' Visible="False" />

    <asp:ListView ID="ListView1" runat="server" DataSourceID="ods" EnableModelValidation="True">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Button ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                    <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                    <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
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
                <%--<td>
                    <asp:Label ID="LC_NOLabel" runat="server" Text='<%# Eval("LC_NO") %>' />
                </td>--%>
                <td>
                    <asp:Label ID="DELIVERY_NOLabel" runat="server" Text='<%# Eval("DELIVERY_NO") %>' />
                </td>
                <td>
                    <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_24H(Eval("SAVE_DATATIME"))%>' />
                </td>
                
                <td>
                    <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
                </td>
               
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color:#008A8C;color: #FFFFFF;">
                <td>
                    <asp:Button ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                    <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                    <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
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
               <%-- <td>
                    <asp:Label ID="LC_NOLabel" runat="server" Text='<%# Eval("LC_NO") %>' />
                </td>--%>
                <td>
                    <asp:Label ID="DELIVERY_NOLabel" runat="server" Text='<%# Eval("DELIVERY_NO") %>' />
                </td>
                <td>
                    <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_24H(Eval("SAVE_DATATIME"))%>' />
                </td>
                
                <td>
                    <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
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
                    <asp:Button ID="btn_showSetting" runat="server" Text="檢視設定" CommandName="Edit" OnClick="btn_showSetting_Click" ToolTip='<%# Eval("DELIVERY_NO") %>' />
                    <asp:Button ID="btn_invalid" runat="server" Text="停用" OnClick="btn_invalid_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
                    <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" ToolTip='<%# Eval("LABREPORT_NO")%>'  />
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
                <%--<td>
                    <asp:Label ID="LC_NOLabel" runat="server" Text='<%# Eval("LC_NO") %>' />
                </td>--%>
                <td>
                    <asp:Label ID="DELIVERY_NOLabel" runat="server" Text='<%# Eval("DELIVERY_NO") %>' />
                </td>
                <td>
                    <asp:Label ID="SAVE_DATATIMELabel" runat="server" Text='<%# FS_24H(Eval("SAVE_DATATIME"))%>' />
                </td>                
                <td>
                    <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
                </td>
               
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">表單編號</th>
                                <th runat="server">客戶名稱</th>
                                <th runat="server">訂單號碼</th>
                                <%--<th runat="server">信用狀號碼</th>--%>
                                <th runat="server">提貨單號碼</th>
                                <th runat="server">儲存日期</th>
                                <%--<th runat="server">REMARK_LIST</th>--%>
                                <th runat="server">是否停用</th>
                                
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
    <asp:CheckBox ID="cb_debugmode" runat="server" AutoPostBack="True" Font-Size="8pt" Text="顯示除錯資訊" Visible="False" />

</p>
<p>
    
    &nbsp;</p>



