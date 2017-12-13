<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCMailPWD_Edit.ascx.vb" Inherits="WebAppAuthority.CCMailPWD_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="WebAppAuthority" %>

<style type="text/css">
    .View2-Table {
        border: 4px dotted #cccccc;
        width: 60%;
        border-collapse: collapse;
        height: 180px;
        margin-right: 0px;
    }
    .View3-Table {       
        border-style: none;
        border-color: inherit;
        border-width: medium;
width: 307px;   
        height: 80px;
        margin-right: 12px;
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

    .auto-style5 {
        height: 23px;
        width: 556px;
    }

        .auto-style14 {
        text-align:left;
        width: 142px;
        height: 40px;
    }
    .auto-style15 {
        width: 100px;
        height: 40px;
    }
    .auto-style16 {
        text-align: right;
        width: 100px;
        height: 40px;
    }
    .auto-style20 {
        text-align: right;
        width: 100px;
        height: 20px;
    }
    .auto-style21 {
        width: 100px;
        height: 20px;
    }
    .auto-style22 {
        text-align: left;
        width: 142px;
        height: 20px;
    }
    .auto-style23 {
        height: 20px;
    }
    .auto-style24 {
        width: 556px;
    }
    </style>

 


<table class="View2-Table">
    <tr>
        <td colspan="2">一、查詢使用者</td>
    </tr>
    <tr>
        <td class="View2_TD_A " rowspan="6">&nbsp;</td>
        <td class="auto-style5">
            <asp:Label ID="Label7" runat="server" Text="部門："></asp:Label>
            <asp:DropDownList ID="ddl_department" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>


        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="Label8" runat="server" Text="員工姓名："></asp:Label>
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="Label4" runat="server" Text="員工編號："></asp:Label>
            <asp:TextBox ID="tbEmpNum" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="auto-style24">Email<asp:Label ID="Label5" runat="server" Text="帳號："></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>


            <asp:Label ID="Label6" runat="server" Text="註 : (輸入@前即可)"></asp:Label>


        </td>
    </tr>
    <tr>
        <td class="auto-style24">
            <asp:Button ID="btnSearch" runat="server" Height="23px" Text="查詢" Width="77px" />


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href ="http://mail.tangeng.com.tw/cc_login.php" target ="_blank">CCMail登入頁面</a></td>
    </tr>
    <tr>
        <td class="auto-style24">
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="WebAppAuthority.CCMailPWD_Edit" UpdateMethod="Search">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="SQLString" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SQLString" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>


        </td>
    </tr>
</table>


<asp:Label ID="lb_Message" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
<br />
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True" DataKeyNames="uid_XML">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />

            </td>
            <td>
                <asp:Label ID="uid_XMLLabel" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
               <asp:Label ID="kindLabel" runat="server" Text='<%# FS_getKindName(Eval("kind"))%>' />
            </td>
            <%-- <td>
                <asp:Label ID="password_XMLLabel" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>--%>
            <td>
                <asp:Label ID="employeeNum_XMLLabel" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>
            <td>
                <asp:Label ID="o_XMLLabel" runat="server" Text='<%# Eval("o_XML") & ":" & FS_o_name(Eval("o_XML"))%>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <table class="View3-Table">
                    <tr>
                        <td class="auto-style21">
                            <asp:RadioButton ID="rb_default" runat="server" AutoPostBack="True" OnCheckedChanged="switch_rb" Font-Size="Small" Text="預設密碼" GroupName="pwd" Checked="True"/><br />
                        </td>
                        <td class="auto-style20"> 預設密碼:</td>
                        <td class="auto-style22"> <%# S_CCMail_Default_Password%> </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:RadioButton ID="rb_config" runat="server" AutoPostBack="True" OnCheckedChanged="switch_rb" Font-Size="Small" Text="自訂密碼" GroupName="pwd" /><br />
                        </td>
                        <td class="auto-style16">
                            新密碼:<br />
                            確認密碼:<br />
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="tb_pwd1" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
                            <asp:TextBox ID="tb_pwd2" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style23" colspan="3">
                            <asp:Button ID="bt_Reset" runat="server" OnClick="DoReset" Text="立即重設" ToolTip='<%# Eval("uid_XML")%>' />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="bt_Reset" ConfirmText="是否確定重設密碼?" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
               <asp:Label ID="kindLabel" runat="server" Text='<%# FS_getKindName(Eval("kind"))%>' />
            </td>
            <%-- <td>
                <asp:Label ID="password_XMLLabel" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>--%>
            <td>
                <asp:Label ID="employeeNum_XMLLabel" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>
            <td>
                <asp:Label ID="o_XMLLabel" runat="server" Text='<%# Eval("o_XML") & ":" & FS_o_name(Eval("o_XML"))%>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
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
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
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
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel" runat="server" Text='<%# Eval("uid_XML") %>' />
            </td>
            <td>
                <asp:Label ID="kindLabel" runat="server" Text='<%# FS_getKindName(Eval("kind"))%>' />
            </td>
            <%--<td>
                <asp:Label ID="password_XMLLabel" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML") %>' />
            </td>--%>
            <td>
                <asp:Label ID="employeeNum_XMLLabel" runat="server" Text='<%# Eval("employeeNum_XML") %>' />
            </td>
            <td>
                <asp:Label ID="cn_XMLLabel" runat="server" Text='<%# Eval("cn_XML") %>' />
            </td>
            <td>
                <asp:Label ID="o_XMLLabel" runat="server" Text='<%# Eval("o_XML") & ":" & FS_o_name(Eval("o_XML"))%>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">帳號</th>
                            <th runat="server">來源</th>
                            <%-- <th runat="server">預設密碼</th>
                            <th runat="server">Email</th>--%>
                            <th runat="server">員工編號</th>
                            <th runat="server">顯示名稱</th>
                            <th runat="server">部門</th>
                            <th runat="server">狀態</th>
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
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
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








<asp:TextBox ID="tb_result" runat="server" Height="132px" TextMode="MultiLine" Width="486px"></asp:TextBox>


























