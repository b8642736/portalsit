<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetExtendUseEdit.ascx.vb" Inherits="AST500LB.AssetExtendUseEdit" %>
<table style="width:100%;">

    <tr>
        <td><asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" /></td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="NUMBER,DEPT"  DataSourceID="odsSearchResult">
    <AlternatingItemTemplate>
        <tr style="background-color: #FAFAD2;color: #284775;">
            <td >
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" style="visibility:hidden;width:0;" />
            </td>
            <%--<td style="visibility:hidden;width:0;">
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>--%>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <%--<td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="AMTLabel" runat="server" Text='<%# Eval("AMT") %>' />
            </td>
            <td>
                <asp:Label ID="BMTLabel" runat="server" Text='<%# Eval("BMT") %>' />
            </td>
            <td>
                <asp:Label ID="CMTLabel" runat="server" Text='<%# Eval("CMT") %>' />
            </td>
            <td>
                <asp:Label ID="CDTLabel" runat="server" Text='<%# Eval("CDT") %>' />
            </td>
            <td>
                <asp:Label ID="ACD1Label" runat="server" Text='<%# Eval("ACD1") %>' />
            </td>
            <td>
                <asp:Label ID="ACD2Label" runat="server" Text='<%# Eval("ACD2") %>' />
            </td>
            <td>
                <asp:Label ID="ACD3Label" runat="server" Text='<%# Eval("ACD3") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>--%>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #FFCC66;color: #000080;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' style="visibility:hidden;width:0;" />
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="DEPRTextBox" runat="server" Text='<%# Bind("DEPR") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="AMTTextBox" runat="server" Text='<%# Bind("AMT") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="BMTTextBox" runat="server" Text='<%# Bind("BMT") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="CMTTextBox" runat="server" Text='<%# Bind("CMT") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="CDTTextBox" runat="server" Text='<%# Bind("CDT") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="ACD1TextBox" runat="server" Text='<%# Bind("ACD1") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="ACD2TextBox" runat="server" Text='<%# Bind("ACD2") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="ACD3TextBox" runat="server" Text='<%# Bind("ACD3") %>' style="visibility:hidden;width:0;"  />
                <asp:TextBox ID="V7611TextBox" runat="server" Text='<%# Bind("V7611") %>' style="visibility:hidden;width:0;"  />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' ReadOnly="true" BackColor="LightGray" Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>' ReadOnly="true" BackColor="LightGray" Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>' ReadOnly="true" BackColor="LightGray" Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' ReadOnly="true" BackColor="LightGray" Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="AMOUNTTextBox" runat="server" Text='<%# Bind("AMOUNT") %>' ReadOnly="true" BackColor="LightGray" Width="80px" />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>' ReadOnly="true" BackColor="LightGray" Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>' ReadOnly="true" BackColor="LightGray" Width="50px" />
            </td>
           <%-- <td>
            </td>

            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>--%>
            <td>
                <asp:TextBox ID="N7611TextBox" runat="server" Text='<%# Bind("N7611") %>' Width="50px" MaxLength="2" />
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
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>' />
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>' />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' />
            </td>
            <td>
                <asp:TextBox ID="AMOUNTTextBox" runat="server" Text='<%# Bind("AMOUNT") %>' />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>' />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>' />
            </td>
            <td>
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' />
            </td>
            <td>
                <asp:TextBox ID="DEPRTextBox" runat="server" Text='<%# Bind("DEPR") %>' />
            </td>
            <td>
                <asp:TextBox ID="AMTTextBox" runat="server" Text='<%# Bind("AMT") %>' />
            </td>
            <td>
                <asp:TextBox ID="BMTTextBox" runat="server" Text='<%# Bind("BMT") %>' />
            </td>
            <td>
                <asp:TextBox ID="CMTTextBox" runat="server" Text='<%# Bind("CMT") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDTTextBox" runat="server" Text='<%# Bind("CDT") %>' />
            </td>
            <td>
                <asp:TextBox ID="ACD1TextBox" runat="server" Text='<%# Bind("ACD1") %>' />
            </td>
            <td>
                <asp:TextBox ID="ACD2TextBox" runat="server" Text='<%# Bind("ACD2") %>' />
            </td>
            <td>
                <asp:TextBox ID="ACD3TextBox" runat="server" Text='<%# Bind("ACD3") %>' />
            </td>
            <td>
                <asp:TextBox ID="V7611TextBox" runat="server" Text='<%# Bind("V7611") %>' />
            </td>
            <td>
                <asp:TextBox ID="N7611TextBox" runat="server" Text='<%# Bind("N7611") %>' />
            </td>
            <td>
                <asp:TextBox ID="SQLQueryAdapterByThisObjectTextBox" runat="server" Text='<%# Bind("SQLQueryAdapterByThisObject") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBCurrentUseSQLQueryAdapterTextBox" runat="server" Text='<%# Bind("CDBCurrentUseSQLQueryAdapter") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBLibraryNameTextBox" runat="server" Text='<%# Bind("CDBLibraryName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFileNameTextBox" runat="server" Text='<%# Bind("CDBFileName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBMemberNameTextBox" runat="server" Text='<%# Bind("CDBMemberName") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFullAS400DBPathTextBox" runat="server" Text='<%# Bind("CDBFullAS400DBPath") %>' />
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
                <asp:TextBox ID="CDBClassFieldNamesTextBox" runat="server" Text='<%# Bind("CDBClassFieldNames") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBPKFieldsPropertyInfoTextBox" runat="server" Text='<%# Bind("CDBPKFieldsPropertyInfo") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBFieldsPropertyInfoTextBox" runat="server" Text='<%# Bind("CDBFieldsPropertyInfo") %>' />
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
        <tr style="background-color: #FFFBD6;color: #333333;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" style="visibility:hidden;width:0;" />
            </td>
            <%--<td style="visibility:hidden;width:0;">
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>--%>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
           <%-- <td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="AMTLabel" runat="server" Text='<%# Eval("AMT") %>' />
            </td>
            <td>
                <asp:Label ID="BMTLabel" runat="server" Text='<%# Eval("BMT") %>' />
            </td>
            <td>
                <asp:Label ID="CMTLabel" runat="server" Text='<%# Eval("CMT") %>' />
            </td>
            <td>
                <asp:Label ID="CDTLabel" runat="server" Text='<%# Eval("CDT") %>' />
            </td>
            <td>
                <asp:Label ID="ACD1Label" runat="server" Text='<%# Eval("ACD1") %>' />
            </td>
            <td>
                <asp:Label ID="ACD2Label" runat="server" Text='<%# Eval("ACD2") %>' />
            </td>
            <td>
                <asp:Label ID="ACD3Label" runat="server" Text='<%# Eval("ACD3") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>--%>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                            <th runat="server" ></th>
                            <th runat="server">資產編號</th>
                            <th runat="server">資產名稱</th>
                            <th runat="server">單位</th>
                            <th runat="server">數量</th>
                            <th runat="server">總價</th>
                            <th runat="server">日期</th>
                            <th runat="server">使用年限</th>
                            <%--<th runat="server">DEPT</th>
                            <th runat="server">DEPR</th>
                            <th runat="server">AMT</th>
                            <th runat="server">BMT</th>
                            <th runat="server">CMT</th>
                            <th runat="server">CDT</th>
                            <th runat="server">ACD1</th>
                            <th runat="server">ACD2</th>
                            <th runat="server">ACD3</th>
                            <th runat="server">V7611</th>--%>
                            <th runat="server">延長使用年限</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
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
        <tr style="background-color: #FFCC66;font-weight: bold;color: #000080;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="AMTLabel" runat="server" Text='<%# Eval("AMT") %>' />
            </td>
            <td>
                <asp:Label ID="BMTLabel" runat="server" Text='<%# Eval("BMT") %>' />
            </td>
            <td>
                <asp:Label ID="CMTLabel" runat="server" Text='<%# Eval("CMT") %>' />
            </td>
            <td>
                <asp:Label ID="CDTLabel" runat="server" Text='<%# Eval("CDT") %>' />
            </td>
            <td>
                <asp:Label ID="ACD1Label" runat="server" Text='<%# Eval("ACD1") %>' />
            </td>
            <td>
                <asp:Label ID="ACD2Label" runat="server" Text='<%# Eval("ACD2") %>' />
            </td>
            <td>
                <asp:Label ID="ACD3Label" runat="server" Text='<%# Eval("ACD3") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
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
<asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.AST500LB.AST201PF" SelectMethod="Search" TypeName="AST500LB.AssetExtendUseEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />




