<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCMailExcute_RunAPI.ascx.vb" Inherits="WebAppAuthority.CCMailExcute_RunAPI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="WebAppAuthority" %>
<style type="text/css">

    
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

    </style>
<p>
            <asp:Button ID="btnSearch" runat="server" Height="27px" Text="更新頁面" Width="73px" />


            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="WebAppAuthority.CCMailExcute_RunAPI" UpdateMethod="Search">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="SQLString" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SQLString" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>


            <asp:HiddenField ID="hfSQL" runat="server" />
            </p>


<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="False"></asp:CustomValidator>
<br />
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" Text="立即執行" OnClick ="Excute" ToolTip='<%# Eval("uid_XML") %>'/>
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
                <asp:Label ID="kindLabel" runat="server" Text='<%# Eval("kind") %>' />
            </td>
            <td>
                <asp:Label ID="password_XMLLabel" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>
            <td>
                <asp:Label ID="employeeNum_XMLLabel" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>
            
            <td>
                <asp:Label ID="o_XMLLabel" runat="server" Text='<%# Eval("o_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
            </td>
            <td>
                <asp:Label ID="modiDateLabel" runat="server" Text='<%# Eval("modiDate") %>' />
            </td>
            <td>
                <asp:Label ID="executeDateLabel" runat="server" Text='<%# Eval("executeDate") %>' />
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
                <asp:TextBox ID="uid_XMLTextBox" runat="server" Text='<%# Bind("uid_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="kindTextBox" runat="server" Text='<%# Bind("kind") %>' />
            </td>
            <td>
                <asp:TextBox ID="password_XMLTextBox" runat="server" Text='<%# Bind("password_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="email_XMLTextBox" runat="server" Text='<%# Bind("email_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="employeeNum_XMLTextBox" runat="server" Text='<%# Bind("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="cn_XMLTextBox" runat="server" Text='<%# Bind("cn_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="o_XMLTextBox" runat="server" Text='<%# Bind("o_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="statusTextBox" runat="server" Text='<%# Bind("status") %>' />
            </td>
            <td>
                <asp:TextBox ID="modiDateTextBox" runat="server" Text='<%# Bind("modiDate") %>' />
            </td>
            <td>
                <asp:TextBox ID="executeDateTextBox" runat="server" Text='<%# Bind("executeDate") %>' />
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
                <asp:Button ID="CancelButton0" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="uid_XMLTextBox0" runat="server" Text='<%# Bind("uid_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="kindTextBox0" runat="server" Text='<%# Bind("kind") %>' />
            </td>
            <td>
                <asp:TextBox ID="password_XMLTextBox0" runat="server" Text='<%# Bind("password_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="email_XMLTextBox0" runat="server" Text='<%# Bind("email_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="employeeNum_XMLTextBox0" runat="server" Text='<%# Bind("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="cn_XMLTextBox0" runat="server" Text='<%# Bind("cn_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="o_XMLTextBox0" runat="server" Text='<%# Bind("o_XML") %>' />
            </td>
            <td>
                <asp:TextBox ID="statusTextBox0" runat="server" Text='<%# Bind("status") %>' />
            </td>
            <td>
                <asp:TextBox ID="modiDateTextBox0" runat="server" Text='<%# Bind("modiDate") %>' />
            </td>
            <td>
                <asp:TextBox ID="executeDateTextBox0" runat="server" Text='<%# Bind("executeDate") %>' />
            </td>
            <td>
                <asp:TextBox ID="SQLQueryAdapterByThisObjectTextBox0" runat="server" Text='<%# Bind("SQLQueryAdapterByThisObject") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBCurrentUseSQLQueryAdapterTextBox0" runat="server" Text='<%# Bind("CDBCurrentUseSQLQueryAdapter") %>' />
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
                <asp:TextBox ID="CDBInsertSQLStringTextBox0" runat="server" Text='<%# Bind("CDBInsertSQLString") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBUpdateSQLStringTextBox0" runat="server" Text='<%# Bind("CDBUpdateSQLString") %>' />
            </td>
            <td>
                <asp:TextBox ID="CDBDeleteSQLStringTextBox0" runat="server" Text='<%# Bind("CDBDeleteSQLString") %>' />
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
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" Text="立即執行" OnClick ="Excute" ToolTip='<%# Eval("uid_XML") %>'/>
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel0" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
                <asp:Label ID="kindLabel0" runat="server" Text='<%# Eval("kind") %>' />
            </td>
            <td>
                <asp:Label ID="password_XMLLabel0" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel0" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>
            <td>
                <asp:Label ID="employeeNum_XMLLabel0" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel0" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>           
            
            <td>
                <asp:Label ID="o_XMLLabel0" runat="server" Text='<%# Eval("o_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel0" runat="server" Text='<%# Eval("status") %>' />
            </td>
            <td>
                <asp:Label ID="modiDateLabel0" runat="server" Text='<%# Eval("modiDate") %>' />
            </td>
            <td>
                <asp:Label ID="executeDateLabel0" runat="server" Text='<%# Eval("executeDate") %>' />
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
                            <th runat="server">帳號</th>
                            <th runat="server">來源</th>
                            <th runat="server">預設密碼</th>
                            <th runat="server">Email</th>
                            <th runat="server">員工編號</th>
                            <th runat="server">顯示名稱</th>                      
                             <th runat="server">組織</th>
                             <th runat="server">狀態</th>
                             <th runat="server">修改時間</th>
                             <th runat="server">執行時間</th>
                             
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
                <asp:Button ID="EditButton1" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel1" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
                <asp:Label ID="kindLabel1" runat="server" Text='<%# Eval("kind") %>' />
            </td>
            <td>
                <asp:Label ID="password_XMLLabel1" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel1" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>
            <td>
                <asp:Label ID="employeeNum_XMLLabel1" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel1" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>
            <td>
                <asp:Label ID="o_XMLLabel1" runat="server" Text='<%# Eval("o_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel1" runat="server" Text='<%# Eval("status") %>' />
            </td>
            <td>
                <asp:Label ID="modiDateLabel1" runat="server" Text='<%# Eval("modiDate") %>' />
            </td>
            <td>
                <asp:Label ID="executeDateLabel1" runat="server" Text='<%# Eval("executeDate") %>' />
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


<p>








<asp:TextBox ID="tb_result" runat="server" Height="132px" TextMode="MultiLine" Width="486px"></asp:TextBox>









</p>



