<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TestList.ascx.vb" Inherits="QualityControl.TestList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>
<p>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="odsResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="LAB_REPORTNO">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                    <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                        ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="LAB_REPORTNOLabel" runat="server" Text='<%# Eval("LAB_REPORTNO") %>' />
                </td>
                <td>
                    <asp:Label ID="標題1Label" runat="server" Text='<%# Eval("標題1") %>' />
                </td>
                <td>
                    <asp:Label ID="標題2Label" runat="server" Text='<%# Eval("標題2") %>' />
                </td>
                <td>
                    <asp:Label ID="說明1Label" runat="server" Text='<%# Eval("說明1") %>' />
                </td>
                <td>
                    <asp:Label ID="說明2Label" runat="server" Text='<%# Eval("說明2") %>' />
                </td>
                <td>
                    <asp:Label ID="原能會字號Label" runat="server" Text='<%# Eval("原能會字號") %>' />
                </td>
                <td>
                    <asp:Label ID="檢驗人員字號Label" runat="server" Text='<%# Eval("檢驗人員字號") %>' />
                </td>
                <td>
                    <asp:Label ID="客戶名稱Label" runat="server" Text='<%# Eval("客戶名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司名稱Label" runat="server" Text='<%# Eval("公司名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司地址Label" runat="server" Text='<%# Eval("公司地址") %>' />
                </td>
                <td>
                    <asp:Label ID="公司負責人Label" runat="server" Text='<%# Eval("公司負責人") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢主管Label" runat="server" Text='<%# Eval("品檢主管") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_起Label" runat="server" Text='<%# Eval("品檢日期_起", "{0:yyyy/MM/dd}")%>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_迄Label" runat="server" Text='<%# Eval("品檢日期_迄") %>' />
                </td>
                <td>
                    <asp:Label ID="資料日期Label" runat="server" Text='<%# Eval("資料日期") %>' />
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
                    <asp:Label ID="LAB_REPORTNOTextBox" runat="server" Text='<%# Bind("LAB_REPORTNO") %>' />
                </td>
                <td>
                    <asp:TextBox ID="標題1TextBox" runat="server" Text='<%# Bind("標題1") %>' />                    
                </td>
                <td>
                    <asp:TextBox ID="標題2TextBox" runat="server" Text='<%# Bind("標題2") %>'  Visible="False"/>
                    <cc1:DropDownListEx ID="ddlisTitle2" runat="server" AutoPostBack="false" Width="60px">
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>D</asp:ListItem>
                    </cc1:DropDownListEx>
                </td>
                <td>
                    <asp:TextBox ID="說明1TextBox" runat="server" Text='<%# Bind("說明1") %>' />
                </td>
                <td>
                    <asp:TextBox ID="說明2TextBox" runat="server" Text='<%# Bind("說明2") %>' />
                </td>
                <td>
                    <asp:TextBox ID="原能會字號TextBox" runat="server" Text='<%# Bind("原能會字號") %>' />
                </td>
                <td>
                    <asp:TextBox ID="檢驗人員字號TextBox" runat="server" Text='<%# Bind("檢驗人員字號") %>' />
                </td>
                <td>
                    <asp:TextBox ID="客戶名稱TextBox" runat="server" Text='<%# Bind("客戶名稱") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司名稱TextBox" runat="server" Text='<%# Bind("公司名稱") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司地址TextBox" runat="server" Text='<%# Bind("公司地址") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司負責人TextBox" runat="server" Text='<%# Bind("公司負責人") %>' />
                </td>
                <td>
                    <asp:TextBox ID="品檢主管TextBox" runat="server" Text='<%# Bind("品檢主管") %>' />
                </td>
                <td>
                    <asp:TextBox ID="品檢日期_起TextBox" runat="server" Text='<%# Bind("品檢日期_起") %>' />                 
                </td>
                <td>
                    <asp:TextBox ID="品檢日期_迄TextBox" runat="server" Text='<%# Bind("品檢日期_迄") %>' />
                </td>
                <td>
                    <asp:TextBox ID="資料日期TextBox" runat="server" Text='<%# Bind("資料日期") %>' />
                </td>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="品檢日期_起TextBox">
</cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="品檢日期_迄TextBox">
</cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" TargetControlID="資料日期TextBox">
</cc1:CalendarExtender>
                
            </tr> 
            <tr>
                <td>訊息:</td>
                <td colspan="20">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    <%--<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
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
                    <asp:TextBox ID="LAB_REPORTNOTextBox" runat="server" Text='<%# Bind("LAB_REPORTNO") %>' />
                </td>
                <td>
                    <asp:TextBox ID="標題1TextBox" runat="server" Text='<%# Bind("標題1") %>'/>                    
                </td>
                <td>
                    <asp:TextBox ID="標題2TextBox" runat="server" Text='<%# Bind("標題2") %>'/>                    
                </td>
                <td>
                    <asp:TextBox ID="說明1TextBox" runat="server" Text='<%# Bind("說明1") %>' />
                </td>
                <td>
                    <asp:TextBox ID="說明2TextBox" runat="server" Text='<%# Bind("說明2") %>' />
                </td>
                <td>
                    <asp:TextBox ID="原能會字號TextBox" runat="server" Text='<%# Bind("原能會字號") %>' />
                </td>
                <td>
                    <asp:TextBox ID="檢驗人員字號TextBox" runat="server" Text='<%# Bind("檢驗人員字號") %>' />
                </td>
                <td>
                    <asp:TextBox ID="客戶名稱TextBox" runat="server" Text='<%# Bind("客戶名稱") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司名稱TextBox" runat="server" Text='<%# Bind("公司名稱") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司地址TextBox" runat="server" Text='<%# Bind("公司地址") %>' />
                </td>
                <td>
                    <asp:TextBox ID="公司負責人TextBox" runat="server" Text='<%# Bind("公司負責人") %>' />
                </td>
                <td>
                    <asp:TextBox ID="品檢主管TextBox" runat="server" Text='<%# Bind("品檢主管") %>' />
                </td>
                <td>
                    <asp:TextBox ID="品檢日期_起TextBox" runat="server" Text='<%# Bind("品檢日期_起") %>' />
                </td>
                <td>
                    <asp:TextBox ID="品檢日期_迄TextBox" runat="server" Text='<%# Bind("品檢日期_迄") %>' />
                </td>
                <td>
                    <asp:TextBox ID="資料日期TextBox" runat="server" Text='<%# Bind("資料日期") %>' />
                </td>
               <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="品檢日期_起TextBox">
</cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="品檢日期_迄TextBox">
</cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" TargetControlID="資料日期TextBox">
</cc1:CalendarExtender>
            </tr>
            <tr>
                <td>訊息:</td>
                <td colspan="20">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    <%--<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                    <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                        ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="LAB_REPORTNOLabel" runat="server" Text='<%# Eval("LAB_REPORTNO") %>' />
                </td>
                <td>
                    <asp:Label ID="標題1Label" runat="server" Text='<%# Eval("標題1") %>' />
                </td>
                <td>
                    <asp:Label ID="標題2Label" runat="server" Text='<%# Eval("標題2") %>' />
                </td>
                <td>
                    <asp:Label ID="說明1Label" runat="server" Text='<%# Eval("說明1") %>' />
                </td>
                <td>
                    <asp:Label ID="說明2Label" runat="server" Text='<%# Eval("說明2") %>' />
                </td>
                <td>
                    <asp:Label ID="原能會字號Label" runat="server" Text='<%# Eval("原能會字號") %>' />
                </td>
                <td>
                    <asp:Label ID="檢驗人員字號Label" runat="server" Text='<%# Eval("檢驗人員字號") %>' />
                </td>
                <td>
                    <asp:Label ID="客戶名稱Label" runat="server" Text='<%# Eval("客戶名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司名稱Label" runat="server" Text='<%# Eval("公司名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司地址Label" runat="server" Text='<%# Eval("公司地址") %>' />
                </td>
                <td>
                    <asp:Label ID="公司負責人Label" runat="server" Text='<%# Eval("公司負責人") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢主管Label" runat="server" Text='<%# Eval("品檢主管") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_起Label" runat="server" Text='<%# Eval("品檢日期_起", "{0:yyyy/MM/dd}")%>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_迄Label" runat="server" Text='<%# Eval("品檢日期_迄") %>' />
                </td>
                <td>
                    <asp:Label ID="資料日期Label" runat="server" Text='<%# Eval("資料日期") %>' />
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
                                <th runat="server">LAB_REPORTNO</th>
                                <th runat="server">標題1</th>
                                <th runat="server">標題2</th>
                                <th runat="server">說明1</th>
                                <th runat="server">說明2</th>
                                <th runat="server">原能會字號</th>
                                <th runat="server">檢驗人員字號</th>
                                <th runat="server">客戶名稱</th>
                                <th runat="server">公司名稱</th>
                                <th runat="server">公司地址</th>
                                <th runat="server">公司負責人</th>
                                <th runat="server">品檢主管</th>
                                <th runat="server">品檢日期_起</th>
                                <th runat="server">品檢日期_迄</th>
                                <th runat="server">資料日期</th>
                                
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
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                    
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="LAB_REPORTNOLabel" runat="server" Text='<%# Eval("LAB_REPORTNO") %>' />
                </td>
                <td>
                    <asp:Label ID="標題1Label" runat="server" Text='<%# Eval("標題1") %>' />
                </td>
                <td>
                    <asp:Label ID="標題2Label" runat="server" Text='<%# Eval("標題2") %>' />
                </td>
                <td>
                    <asp:Label ID="說明1Label" runat="server" Text='<%# Eval("說明1") %>' />
                </td>
                <td>
                    <asp:Label ID="說明2Label" runat="server" Text='<%# Eval("說明2") %>' />
                </td>
                <td>
                    <asp:Label ID="原能會字號Label" runat="server" Text='<%# Eval("原能會字號") %>' />
                </td>
                <td>
                    <asp:Label ID="檢驗人員字號Label" runat="server" Text='<%# Eval("檢驗人員字號") %>' />
                </td>
                <td>
                    <asp:Label ID="客戶名稱Label" runat="server" Text='<%# Eval("客戶名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司名稱Label" runat="server" Text='<%# Eval("公司名稱") %>' />
                </td>
                <td>
                    <asp:Label ID="公司地址Label" runat="server" Text='<%# Eval("公司地址") %>' />
                </td>
                <td>
                    <asp:Label ID="公司負責人Label" runat="server" Text='<%# Eval("公司負責人") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢主管Label" runat="server" Text='<%# Eval("品檢主管") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_起Label" runat="server" Text='<%# Eval("品檢日期_起") %>' />
                </td>
                <td>
                    <asp:Label ID="品檢日期_迄Label" runat="server" Text='<%# Eval("品檢日期_迄") %>' />
                </td>
                <td>
                    <asp:Label ID="資料日期Label" runat="server" Text='<%# Eval("資料日期") %>' />
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
</p>
<asp:ObjectDataSource ID="odsResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCdb01.LabRecordA1_M" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="QualityControl.TestList" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQL" runat="server" />

