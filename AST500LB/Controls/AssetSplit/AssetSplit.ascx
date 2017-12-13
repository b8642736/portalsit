<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetSplit.ascx.vb" Inherits="AST500LB.AssetSplit" %>
<style type="text/css">
    .auto-style1 {
        width: 129px;
        text-align:right;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="auto-style1">資產編號:</td>
        <td>
            <asp:TextBox ID="tbNumbers" runat="server" Width="200px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">資產名稱:</td>
        <td>
            <asp:TextBox ID="tbName" runat="server" Width="200px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">單位代碼:</td>
        <td>
            <asp:TextBox ID="tbDept" runat="server" Width="200px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearInput" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="OdsSearchResult" DataKeyNames="NUMBER,DEPT">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="TRANSButton" runat="server" CommandName="Update" Text="移轉"  OnClientClick="javascript:return confirm('是否確定轉移至新單位?');" />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="AboutAST906PF_UseDeptLabel" runat="server" Text='<%# Eval("AboutAST106PF_UseDept")%>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
            <td>
                <asp:Textbox ID="TransNewNumberTextbox" runat="server" Text='<%# Bind("TransferNewNumber")%>' Width="120px" />
            </td>
            <td>
                <asp:Textbox ID="TransferCountTextbox" runat="server" Text='<%# Bind("TransferCount")%>' Width="60px" />
            </td>
            <td>
                <asp:Textbox ID="TransferNewDEPTSATextbox" runat="server" Text='<%# Bind("TransferNewDEPTSA")%>' Width="60px" />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <%--<EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="AboutAST906PF_UseDeptLabel" runat="server" Text='<%# Eval("AboutAST106PF_UseDept")%>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
        </tr>
    </EditItemTemplate>--%>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <%-- <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' />
            </td>
            <td>
                <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="AboutAST906PF_UseDeptTextBox" runat="server" Text='<%# Bind("AboutAST106PF_UseDept")%>' />
            </td>
            <td>
                <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' />
            </td>
            <td>
                <asp:TextBox ID="AMOUNTTextBox" runat="server" Text='<%# Bind("AMOUNT") %>' />
            </td>
            <td>
                <asp:TextBox ID="DEPRTextBox" runat="server" Text='<%# Bind("DEPR") %>' />
            </td>
            <td>
                <asp:TextBox ID="V7611TextBox" runat="server" Text='<%# Bind("V7611") %>' />
            </td>
            <td>
                <asp:TextBox ID="N7611TextBox" runat="server" Text='<%# Bind("N7611") %>' />
            </td>
        </tr>
    </InsertItemTemplate>--%>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <%--<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />--%>
                <asp:Button ID="TRANSButton" runat="server" CommandName="Update" Text="移轉"  OnClientClick="javascript:return confirm('是否確定轉移至新單位?');" />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="AboutAST906PF_UseDeptLabel" runat="server" Text='<%# Eval("AboutAST106PF_UseDept")%>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
            <td>
                <asp:Textbox ID="TransNewNumberTextbox" runat="server" Text='<%# Bind("TransferNewNumber")%>' Width="120px" />
            </td>
            <td>
                <asp:Textbox ID="TransferCountTextbox" runat="server" Text='<%# Bind("TransferCount")%>' Width="60px" />
            </td>
            <td>
                <asp:Textbox ID="TransferNewDEPTSATextbox" runat="server" Text='<%# Bind("TransferNewDEPTSA")%>' Width="60px" />
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
                            <th runat="server">資產編號</th>
                            <th runat="server">名稱</th>
                            <th runat="server">使用單位</th>
                            <th runat="server">數量</th>
                            <th runat="server">總價</th>
                            <th runat="server">折舊金額</th>
                            <th runat="server">重估殘值</th>
                            <th runat="server">重估年限</th>
                            <th runat="server">移轉之新資產編號</th>
                            <th runat="server">移轉數量</th>
                            <th runat="server">使用單位</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>訊息:<asp:Label ID="MessageLabel"  ForeColor="Red" Font-Bold="true" runat="server" Text="" ></asp:Label></td>
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
                <%--<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />--%>
                <asp:Button ID="TRANSButton" runat="server" CommandName="TRANSFER" Text="移轉" />
            </td>
            <td>
                <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
            </td>
            <td>
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
            </td>
            <td>
                <asp:Label ID="AboutAST906PF_UseDeptLabel" runat="server" Text='<%# Eval("AboutAST106PF_UseDept")%>' />
            </td>
            <td>
                <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
            </td>
            <td>
                <asp:Label ID="AMOUNTLabel" runat="server" Text='<%# Eval("AMOUNT") %>' />
            </td>
            <td>
                <asp:Label ID="DEPRLabel" runat="server" Text='<%# Eval("DEPR") %>' />
            </td>
            <td>
                <asp:Label ID="V7611Label" runat="server" Text='<%# Eval("V7611") %>' />
            </td>
            <td>
                <asp:Label ID="N7611Label" runat="server" Text='<%# Eval("N7611") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="OdsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.AST500LB.AST101PF" SelectMethod="Search" TypeName="AST500LB.AssetSplit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />

