<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddAsset.ascx.vb" Inherits="AST500LB.AddAsset" %>
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
        <tr style="background-color: #FFFFFF;color: #284775;">
            <td rowspan="2">
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="Javascript:return confirm('是否確定刪除?');" />
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
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRECLabel" runat="server" Text='<%# Eval("DEPREC") %>' />
            </td>
            <td>
                <asp:Label ID="DATENLabel" runat="server" Text='<%# Eval("DATEN") %>' />
            </td>
        </tr>
        <tr style="background-color: #FFFFFF;color: #284775;">
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SEQ")%>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("MTSV01")%>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DEPTSA")%>' />
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PNO")%>' />
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DATE")%>' />
            </td>
            <td colspan="4">
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("SPEC1")%>' />
            </td>
            <td colspan="3">
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("SPEC2")%>' />
            </td>
       </tr>
    </AlternatingItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #E0FFFF;color: #333333;">
            <td rowspan="2">
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
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>'/>
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>'/>
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRECLabel" runat="server" Text='<%# Eval("DEPREC") %>' />
            </td>
            <td>
                <asp:Label ID="DATENLabel" runat="server" Text='<%# Eval("DATEN") %>' />
            </td>

        </tr>
        <tr style="background-color: #E0FFFF;color: #333333;">
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SEQ")%>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("MTSV01")%>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DEPTSA")%>' />
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PNO")%>' />
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DATE")%>' />
            </td>
            <td colspan="4">
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("SPEC1")%>' />
            </td>
            <td colspan="3">
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("SPEC2")%>' />
            </td>
       </tr>
    </ItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #999999;">
            <td rowspan="2">
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' ReadOnly="true" BackColor="LightGray"  Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' ReadOnly="true"  BackColor="LightGray"  Width="100" />
            </td>
            <td>
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' ReadOnly="true" BackColor="LightGray"  Width="30" />
            </td>
            <td>
                <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>' Width="120"/>
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>' Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>'  Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="TAMOUNTextBox" runat="server" Text='<%# Bind("TAMOUN") %>' Width="70"  />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>' Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>'  Width="30"  />
            </td>
            <td>
                <asp:TextBox ID="PRICETextBox" runat="server" Text='<%# Bind("PRICE") %>'  Width="70"  />
            </td>
            <td>
                <asp:TextBox ID="DEPRECTextBox" runat="server" Text='<%# Bind("DEPREC") %>'  Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="DATENTextBox" runat="server" Text='<%# Bind("DATEN") %>'  Width="40"  />
            </td>
        </tr>
        <tr style="background-color: #999999;">
            <td>
                <asp:TextBox ID="SEQTextBox" runat="server" Text='<%# Bind("SEQ") %>'  Width="97%"  BackColor="LightGray"  ReadOnly="true"  />
            </td>
            <td>
                <asp:TextBox ID="MTSV01TextBox" runat="server" Text='<%# Bind("MTSV01")%>' Width="97%" />
            </td>
            <td>
                <asp:TextBox ID="DEPSATextBox" runat="server" Text='<%# Bind("DEPTSA")%>' Width="97%" />
            </td>
            <td>
                <asp:TextBox ID="PNOTextBox" runat="server" Text='<%# Bind("PNO")%>' Width="97%" />
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DATE")%>' Width="97%" />
            </td>
            <td colspan="4">
                <asp:TextBox ID="SPEC1TextBox" runat="server" Text='<%# Bind("SPEC1")%>' Width="97%" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="SPEC2TextBox" runat="server" Text='<%# Bind("SPEC2")%>' Width="97%" />
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
            <td rowspan="2">
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="CODETextBox" runat="server" Text='<%# Bind("CODE") %>' ReadOnly="true" Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>'  Width="100"/>
            </td>
            <td>
                <asp:TextBox ID="DEPTTextBox" runat="server" Text='<%# Bind("DEPT") %>' Width="30"/>
            </td>
            <td>
                <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>'  Width="120"/>
            </td>
            <td>
                <asp:TextBox ID="UNITTextBox" runat="server" Text='<%# Bind("UNIT") %>'  Width="40" />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>'  Width="40" />
            </td>
            <td>
                <asp:TextBox ID="TAMOUNTextBox" runat="server" Text='<%# Bind("TAMOUN") %>'  Width="70"  />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox" runat="server" Text='<%# Bind("DATE") %>'  Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="USLAFFTextBox" runat="server" Text='<%# Bind("USLAFF") %>' Width="30" />
            </td>
            <td>
                <asp:TextBox ID="PRICETextBox" runat="server" Text='<%# Bind("PRICE") %>'  Width="70"  />
            </td>
            <td>
                <asp:TextBox ID="DEPRECTextBox" runat="server" Text='<%# Bind("DEPREC") %>'  Width="40"  />
            </td>
            <td>
                <asp:TextBox ID="DATENTextBox" runat="server" Text='<%# Bind("DATEN") %>'  Width="40"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1"  Value='<%# Bind("SEQ") %>' runat="server" />
                <asp:TextBox ID="SEQTextBox" runat="server" Text='<%# Eval("SEQ")%>'  ReadOnly="true" Width="97%"   />
            </td>
            <td>
                <asp:TextBox ID="MTSV01TextBox" runat="server" Text='<%# Bind("MTSV01")%>' Width="97%"   />
            </td>
            <td>
                <asp:TextBox ID="DEPSATextBox" runat="server" Text='<%# Bind("DEPTSA")%>' Width="97%"  />
            </td>
            <td>
                <asp:TextBox ID="PNOTextBox" runat="server" Text='<%# Bind("PNO")%>' Width="97%"  />
            </td>
            <td>
                <asp:TextBox ID="DATETextBox1" runat="server" Text='<%# Bind("DATE")%>' Width="97%"  />
            </td>
            <td colspan="4">
                <asp:TextBox ID="SPEC1TextBox" runat="server" Text='<%# Bind("SPEC1")%>' Width="97%" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="SPEC2TextBox" runat="server" Text='<%# Bind("SPEC2")%>' Width="97%"  />
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                            <th runat="server"></th>
                            <th runat="server"  Width="40px" >代碼</th>
                            <th runat="server">資產編號</th>
                            <th runat="server">入帳部門</th>
                            <th runat="server">資產名稱</th>
                            <th runat="server">計量單位</th>
                            <th runat="server">數量</th>
                            <th runat="server">總價</th>
                            <th runat="server">入帳年月</th>
                            <th runat="server">使用年限</th>
                            <th runat="server">單價</th>
                            <th runat="server">折舊</th>
                            <th runat="server">發生日期</th>
                        </tr>
                        <tr id="Tr1" runat="server" style="background-color: #E0FFFF;color: #333333;">
                            <th id="Th1" runat="server"></th>
                            <th id="Th2" runat="server"  Width="40px" >序號</th>
                            <th id="Th3" runat="server">供應商編號</th>
                            <th id="Th4" runat="server">單位代號</th>
                            <th id="Th5" runat="server">入帳編號</th>
                            <th id="Th6" runat="server">入帳年月</th>
                            <th id="Th7" runat="server" colspan="4">規格1</th>
                            <th id="Th8" runat="server" colspan="3">規格2</th>
                        </tr>

                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
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
        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
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
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="UNITLabel" runat="server" Text='<%# Eval("UNIT") %>'  Width="80" />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>'  Width="80" />
            </td>
            <td>
                <asp:Label ID="TAMOUNLabel" runat="server" Text='<%# Eval("TAMOUN") %>' />
            </td>
            <td>
                <asp:Label ID="DATELabel" runat="server" Text='<%# Eval("DATE") %>' />
            </td>
            <td>
                <asp:Label ID="USLAFFLabel" runat="server" Text='<%# Eval("USLAFF") %>' />
            </td>
            <td>
                <asp:Label ID="PRICELabel" runat="server" Text='<%# Eval("PRICE") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRECLabel" runat="server" Text='<%# Eval("DEPREC") %>' />
            </td>
            <td>
                <asp:Label ID="DATENLabel" runat="server" Text='<%# Eval("DATEN") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearhResult" runat="server" DataObjectTypeName="CompanyORMDB.AST501LB.AST001PFEx" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="AST500LB.AddAsset" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />

