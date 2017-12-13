<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCMailExcute_Edit.ascx.vb" Inherits="WebAppAuthority.CCMailExcute_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="WebAppAuthority" %>

<style type="text/css">
    
    .View2-Table {
        border: 4px dotted #cccccc;
width: 58%;
        border-collapse: collapse;
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
        width: 1136px;
    }

    .auto-style6 {
        width: 1136px;
    }

    .auto-style7 {
        height: 28px;
        width: 1136px;
    }

    </style>




<table class="View2-Table">
    <tr>
        <td colspan="2">一、查詢使用者</td>
    </tr>
    <tr>
        <td class="View2_TD_A " rowspan="7">&nbsp;</td>
        <td class="auto-style5">
            <asp:Label ID="Label7" runat="server" Text="部門："></asp:Label>
            <asp:DropDownList ID="ddl_department" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>


        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="Label9" runat="server" Text="員工姓名："></asp:Label>
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
        <td class="auto-style6">Email<asp:Label ID="Label5" runat="server" Text="帳號："></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>


            <asp:Label ID="Label6" runat="server" Text="註 : (輸入@前即可)"></asp:Label>


        </td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Label ID="Label8" runat="server" Text="帳號來源："></asp:Label>
            <asp:DropDownList ID="ddl_kind" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Button ID="btnSearch" runat="server" Height="23px" Text="查詢" Width="77px" />


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href ="http://mail.tangeng.com.tw/cc_login.php" target ="_blank">CCMail登入頁面</a></td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="WebAppAuthority.CCMailExcute_Edit" UpdateMethod="Update" DataObjectTypeName="CompanyORMDB.SQLServer.MIS.CCmail_Users" DeleteMethod="Delete" InsertMethod="Insert">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="SQLString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>


        </td>
    </tr>
</table>
<asp:Label ID="lb_Message" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True" DataKeyNames="uid_XML" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" Text="編輯" CommandName="Edit"/></br>
                <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="Delete"/>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除帳號?" />
            </td>
            <td>
                <asp:Label ID="uid_XMLLabel" runat="server" Text='<%# Eval("uid_XML")%>' />
            </td>
            <td>
                <asp:Label ID="kindLabel" runat="server" Text='<%# Eval("kind") %>' />
            </td>
            <td>
                <asp:Label ID="password_XMLLabel" runat="server" Text='<%# Eval("password_XML") %>' />
            </td>
            <td>
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML").ToString.Replace(";", "</br>")%>' />
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
                <asp:Label ID="sequence_XMLLabel" runat="server" Text='<%# Eval("sequence_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# FS_getStateName(Eval("status"))%>' />
            </td>
            <td>
                <asp:Label ID="modiDateLabel" runat="server" Text='<%# FS_24H(Eval("modiDate"))%>' />
            </td>


        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" /></br>
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="uid_XMLTextBox" runat="server" Text='<%# Bind("uid_XML") %>' />
            </td>
<td>
                <asp:TextBox ID="kindTextBox" runat="server" Text='<%# Bind("kind") %>' Width="20px"/>
            </td>
            <td>
                <asp:label ID="password_XMLTextBox" runat="server" Text='<%# Bind("password_XML") %>' Width="40px"/>
            </td>
            <td>
                <asp:TextBox ID="email_XMLTextBox" runat="server" Text='<%# Bind("email_XML") %>' Width="230px"/>
            </td>
            <td>
                <asp:TextBox ID="employeeNum_XMLTextBox" runat="server" Text='<%# Bind("employeeNum_XML") %>' Width="50px"/>
            </td>
            <td>
                <asp:TextBox ID="cn_XMLTextBox" runat="server" Text='<%# Bind("cn_XML") %>' Width="120px"/>
            </td>
            <td>
                <asp:TextBox ID="o_XMLTextBox" runat="server" Text='<%# Bind("o_XML") %>' Width="40px"/>
            </td>
            <td>
                <asp:TextBox ID="sequence_XMLTextBox" runat="server" Text='<%# Bind("sequence_XML") %>' Width="50px" />
            </td>
            <td>
                <asp:Label ID="statusTextBox" runat="server" Text='<%# Bind("status") %>' />
            </td>
            <td>
                <asp:Label ID="modiDateTextBox" runat="server" Text='<%# FS_24H(Eval("modiDate"))%>' />
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" /></br>
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="uid_XMLTextBox" runat="server" Text='<%# Bind("uid_XML") %>' Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="kindTextBox" runat="server" Text='<%# Bind("kind") %>' Width="20px"/>
            </td>
            <td>
                <asp:TextBox ID="password_XMLTextBox" runat="server" Text='<%# Bind("password_XML") %>' Width="40px"/>
            </td>
            <td>
                <asp:TextBox ID="email_XMLTextBox" runat="server" Text='<%# Bind("email_XML") %>' Width="230px"/>
            </td>
            <td>
                <asp:TextBox ID="employeeNum_XMLTextBox" runat="server" Text='<%# Bind("employeeNum_XML") %>' Width="50px"/>
            </td>
            <td>
                <asp:TextBox ID="cn_XMLTextBox" runat="server" Text='<%# Bind("cn_XML") %>' Width="120px"/>
            </td>
            <td>
                <asp:TextBox ID="o_XMLTextBox" runat="server" Text='<%# Bind("o_XML") %>' Width="40px"/>
            </td>
            <td>
                <asp:TextBox ID="sequence_XMLTextBox" runat="server" Text='<%# Bind("sequence_XML") %>' Width="50px" />
            </td>
            
            
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" Text="編輯" CommandName="Edit"/></br>
                <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="Delete"/>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除帳號?" />
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
                <asp:Label ID="email_XMLLabel" runat="server" Text='<%# Eval("email_XML").ToString.Replace(";", "</br>")%>' />
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
                <asp:Label ID="sequence_XMLLabel" runat="server" Text='<%# Eval("sequence_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# FS_getStateName(Eval("status")) %>' />
            </td>
          <td>
                <asp:Label ID="modiDateLabel" runat="server" Text='<%# FS_24H(Eval("modiDate"))%>' />
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
                            <th runat="server">排序</th>
                             <th runat="server">狀態</th>
                             <th runat="server">修改時間</th>                            
                           
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
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" /> </br>
                <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="Delete"/>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除帳號?" />
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
                <asp:Label ID="sequence_XMLLabel" runat="server" Text='<%# Eval("sequence_XML") %>' />
            </td>
            <td>
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
            </td>
              <td>
                <asp:Label ID="modiDateLabel" runat="server" Text='<%# FS_24H(Eval("modiDate"))%>' />
            </td>
           
        </tr>
    </SelectedItemTemplate>
</asp:ListView>








<asp:TextBox ID="tb_result" runat="server" Height="132px" TextMode="MultiLine" Width="486px"></asp:TextBox>












