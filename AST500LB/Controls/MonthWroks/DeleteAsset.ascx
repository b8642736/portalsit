<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DeleteAsset.ascx.vb" Inherits="AST500LB.DeleteAsset" %>
    <style type="text/css">
        .auto-style1
        {
            width: 62px;
        }
        .auto-style2
        {
            width: 65px;
        }
        .auto-style3
        {
            width: 145px;
        }
        .auto-style5
        {
            width: 90px;
            color:red;
        }
        </style>

    <table style="width:100%;">
        <tr>
            <td class="auto-style5">作業設定=></td>
            <td class="auto-style1">年月:</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbYearMonth" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style2">廠別:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="SA">SA</asp:ListItem>
                    <asp:ListItem>AA</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>QA</asp:ListItem>
                    <asp:ListItem>RA</asp:ListItem>
                    <asp:ListItem>RC</asp:ListItem>
                    <asp:ListItem>RD</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="查詢重整" />
            </td>
        </tr>
    </table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearhResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="NUMBER,DEPT">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="Javascript:return confirm('是否確定刪除?');"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DATECLabel" runat="server" Text='<%# Eval("DATEC") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="WHYLabel" runat="server" Text='<%# Eval("WHY") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="DEPREBLabel" runat="server" Text='<%# Eval("DEPREB") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>' />
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>' />
            </td>
            <td>
                <asp:Label ID="CNAMELabel" runat="server" Text='<%# Eval("CNAME") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick="Javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>'/>
            </td>
            <td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DATECLabel" runat="server" Text='<%# Eval("DATEC") %>'   />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>'   />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>'/>
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="WHYLabel" runat="server" Text='<%# Eval("WHY") %>'/>
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="DEPREBLabel" runat="server" Text='<%# Eval("DEPREB") %>'/>
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>'/>
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>'  />
            </td>
            <td>
                <asp:Label ID="CNAMELabel" runat="server" Text='<%# Eval("CNAME") %>'  />
            </td>
        </tr>
    </ItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' Width="30px"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' Width="100"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' Width="30" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID="DATECTextBox" runat="server" Text='<%# Bind("DATEC") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="WHYTextBox" runat="server" Text='<%# Bind("WHY") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="DEPRTextBox" runat="server" Text='<%# Bind("DEPR") %>' Width="100" />
            </td>
            <td>
                <asp:TextBox ID="DEPREBTextBox" runat="server" Text='<%# Bind("DEPREB") %>' Width="100" />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="PRICETextBox" runat="server" Text='<%# Bind("PRICE") %>' Width="70" />
            </td>
            <td>
                <asp:TextBox ID="TAMOUNTextBox" runat="server" Text='<%# Bind("TAMOUN") %>' Width="100" />
            </td>
            <td>
                <asp:TextBox ID="CNAMETextBox" runat="server" Text='<%# Bind("CNAME") %>' Width="100" />
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
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' Width="30px"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' Width="100"  />
            </td>
            <td>
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="DATECTextBox" runat="server" Text='<%# Bind("DATEC") %>' Width="40"/>
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>' Width="40"/>
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>'  Width="40" />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' Width="40" />
            </td>
            <td>
                <asp:TextBox ID="WHYTextBox" runat="server" Text='<%# Bind("WHY") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="DEPRTextBox" runat="server" Text='<%# Bind("DEPR") %>' Width="100" />
            </td>
            <td>
                <asp:TextBox ID="DEPREBTextBox" runat="server" Text='<%# Bind("DEPREB") %>'  Width="100" />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="PRICETextBox" runat="server" Text='<%# Bind("PRICE") %>' Width="70"  />
            </td>
            <td>
                <asp:TextBox ID="TAMOUNTextBox" runat="server" Text='<%# Bind("TAMOUN") %>' Width="100"/>
            </td>
            <td>
                <asp:TextBox ID="CNAMETextBox" runat="server" Text='<%# Bind("CNAME") %>' Width="100"/>
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">代碼</th>
                            <th runat="server">資產編號</th>
                            <th runat="server">入帳部門</th>
                            <th runat="server">發生日期</th>
                            <th runat="server">入帳日期</th>
                            <th runat="server">單位</th>
                            <th runat="server">數量</th>
                            <th runat="server">原因</th>
                            <th runat="server">減少總額</th>
                            <th runat="server">剩於價值/殘值</th>
                            <th runat="server">使用年限</th>
                            <th runat="server">單價</th>
                            <th runat="server">總價</th>
                            <th runat="server">資產名稱</th>
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
                <asp:Label ID="CODELabel" runat="server" Text='<%# Eval("CODE") %>' />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="DEPTLabel" runat="server" Text='<%# Eval("DEPT") %>' />
            </td>
            <td>
                <asp:Label ID="DATECLabel" runat="server" Text='<%# Eval("DATEC") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="WHYLabel" runat="server" Text='<%# Eval("WHY") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="DEPREBLabel" runat="server" Text='<%# Eval("DEPREB") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>' />
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>' />
            </td>
            <td>
                <asp:Label ID="CNAMELabel" runat="server" Text='<%# Eval("CNAME") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearhResult" runat="server" DataObjectTypeName="CompanyORMDB.AST501LB.AST003PF" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="AST500LB.DeleteAsset" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />


