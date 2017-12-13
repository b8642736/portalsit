<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QABugEdit.ascx.vb" Inherits="QualityControl.QABugEdit" %>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">缺陷號碼:</td>
        <td>
            <asp:TextBox ID="tbBugNumbers" runat="server" Width="345px"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分,Ex:1,2,...)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">缺陷名稱:</td>
        <td>
            <asp:TextBox ID="tbBugNames" runat="server" Width="345px"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分,Ex:色表面,退火過度,...)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">排序欄位:</td>
        <td>
            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="NUMBER">缺陷編號</asp:ListItem>
                <asp:ListItem Value="APL1SortNumber">APL1</asp:ListItem>
                <asp:ListItem Value="APL2SortNumber">APL2</asp:ListItem>
                <asp:ListItem Value="BALSortNumber">BAL</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="Number">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" Enabled='<%# Not Eval("IsUsedForUser")%>' OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
            </td>
            <td>
                <asp:Label ID="CNameLabel" runat="server" Text='<%# Eval("CName") %>' />
            </td>
            <td>
                <asp:Label ID="APL1SortNumberLabel" runat="server" Text='<%# Eval("APL1SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="APL2SortNumberLabel" runat="server" Text='<%# Eval("APL2SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="BALSortNumberLabel" runat="server" Text='<%# Eval("BALSortNumber") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsAttentationCheckBox" runat="server" Checked='<%# Eval("IsAttentation") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree")%>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition")%>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionTypeName")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd")%>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNegName")%>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density")%>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle")%>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
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
                <asp:TextBox ID="NumberTextBox" runat="server" Text='<%# Bind("Number") %>' ReadOnly="true" BackColor="LightGray" Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="CNameTextBox" runat="server" Text='<%# Bind("CName") %>' Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="APL1SortNumberTextBox" runat="server" Text='<%# Bind("APL1SortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="APL2SortNumberTextBox" runat="server" Text='<%# Bind("APL2SortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="BALSortNumberTextBox" runat="server" Text='<%# Bind("BALSortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:CheckBox ID="IsAttentationCheckBox" runat="server" Checked='<%# Bind("IsAttentation") %>' />
            </td>
            <td>
                <asp:TextBox ID="DegreeTextBox" runat="server" Text='<%# Bind("Degree") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="StartPositionTextBox" runat="server" Text='<%# Bind("StartPosition") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="EndPositionTextBox" runat="server" Text='<%# Bind("EndPosition") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="DPositionTypeTextBox" runat="server" Text='<%# Bind("DPositionType") %>' />--%>
                <asp:DropDownList ID="RadioButtonList2" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("DPositionType")%>' >
                    <asp:ListItem Selected="True" Value="0" >全</asp:ListItem>
                    <asp:ListItem Value="1">內</asp:ListItem>
                    <asp:ListItem Value="2">中</asp:ListItem>
                    <asp:ListItem Value="3">外</asp:ListItem>
                    <asp:ListItem Value="4">雙</asp:ListItem>
                    <asp:ListItem Value="5">無</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="DPositionStartTextBox" runat="server" Text='<%# Bind("DPositionStart") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="DPositionEndTextBox" runat="server" Text='<%# Bind("DPositionEnd") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="PosOrNegTextBox" runat="server" Text='<%# Bind("PosOrNeg") %>' Width="50px" />--%>
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("PosOrNeg")%>' >
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">正</asp:ListItem>
                    <asp:ListItem Value="2">反</asp:ListItem>
                    <asp:ListItem Value="3">雙</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="DensityTextBox" runat="server" Text='<%# Bind("Density") %>' Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="CycleTextBox" runat="server" Text='<%# Bind("Cycle") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' Width="200px" />
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
        <tr style="visibility:hidden">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="NumberTextBox" runat="server" Text='<%# Bind("Number") %>' Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="CNameTextBox" runat="server" Text='<%# Bind("CName") %>' Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="APL1SortNumberTextBox" runat="server" Text='<%# Bind("APL1SortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="APL2SortNumberTextBox" runat="server" Text='<%# Bind("APL2SortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:TextBox ID="BALSortNumberTextBox" runat="server" Text='<%# Bind("BALSortNumber") %>' Width="60px" />
            </td>
            <td>
                <asp:CheckBox ID="IsAttentationCheckBox" runat="server" Checked='<%# Bind("IsAttentation") %>' />
            </td>
            <td>
                <asp:TextBox ID="DegreeTextBox" runat="server" Text='<%# Bind("Degree") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="StartPositionTextBox" runat="server" Text='<%# Bind("StartPosition") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="EndPositionTextBox" runat="server" Text='<%# Bind("EndPosition") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="DPositionTypeTextBox" runat="server" Text='<%# Bind("DPositionType") %>' />--%>
                <asp:DropDownList ID="RadioButtonList2" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("DPositionType")%>' >
                    <asp:ListItem Selected="True" Value="0" >全</asp:ListItem>
                    <asp:ListItem Value="1">內</asp:ListItem>
                    <asp:ListItem Value="2">中</asp:ListItem>
                    <asp:ListItem Value="3">外</asp:ListItem>
                    <asp:ListItem Value="4">雙</asp:ListItem>
                    <asp:ListItem Value="5">無</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="DPositionStartTextBox" runat="server" Text='<%# Bind("DPositionStart") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="DPositionEndTextBox" runat="server" Text='<%# Bind("DPositionEnd") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="PosOrNegTextBox" runat="server" Text='<%# Bind("PosOrNeg") %>' Width="50px" />--%>
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("PosOrNeg")%>' >
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">正</asp:ListItem>
                    <asp:ListItem Value="2">反</asp:ListItem>
                    <asp:ListItem Value="3">雙</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="DensityTextBox" runat="server" Text='<%# Bind("Density") %>' Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="CycleTextBox" runat="server" Text='<%# Bind("Cycle") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>'  Width="100px"/>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  Enabled='<%# Not Eval("IsUsedForUser")%>' OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
            </td>
            <td>
                <asp:Label ID="CNameLabel" runat="server" Text='<%# Eval("CName") %>' />
            </td>
            <td>
                <asp:Label ID="APL1SortNumberLabel" runat="server" Text='<%# Eval("APL1SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="APL2SortNumberLabel" runat="server" Text='<%# Eval("APL2SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="BALSortNumberLabel" runat="server" Text='<%# Eval("BALSortNumber") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsAttentationCheckBox" runat="server" Checked='<%# Eval("IsAttentation") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree")%>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition")%>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionTypeName")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd")%>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNegName")%>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density")%>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle")%>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
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
                            <th runat="server">缺陷編號</th>
                            <th runat="server">缺陷名稱</th>
                            <th runat="server">APL1排序</th>
                            <th runat="server">APL2排序</th>
                            <th runat="server">BAL排序</th>
                            <th runat="server">重點缺陷</th>
                            <th runat="server">程度</th>
                            <th runat="server">起始長度</th>
                            <th runat="server">終止長度</th>
                            <th runat="server">分佈型態</th>
                            <th runat="server">分佈起始</th>
                            <th runat="server">分佈終止</th>
                            <th runat="server">正反面</th>
                            <th runat="server">密度</th>
                            <th runat="server">周期</th>
                            <th runat="server">備註</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="120">
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
                <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
            </td>
            <td>
                <asp:Label ID="CNameLabel" runat="server" Text='<%# Eval("CName") %>' />
            </td>
            <td>
                <asp:Label ID="APL1SortNumberLabel" runat="server" Text='<%# Eval("APL1SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="APL2SortNumberLabel" runat="server" Text='<%# Eval("APL2SortNumber") %>' />
            </td>
            <td>
                <asp:Label ID="BALSortNumberLabel" runat="server" Text='<%# Eval("BALSortNumber") %>' />
            </td>
            <td>
                <asp:CheckBox ID="IsAttentationCheckBox" runat="server" Checked='<%# Eval("IsAttentation") %>' Enabled="false" />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree")%>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition")%>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionTypeName")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd")%>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNegName")%>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density")%>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle")%>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server"  DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.QABUG" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="QualityControl.QABugEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />

