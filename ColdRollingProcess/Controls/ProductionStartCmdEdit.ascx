<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductionStartCmdEdit.ascx.vb" Inherits="ColdRollingProcess.ProductionStartCmdEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="width:100%;">
    <tr>
        <td class="style1">
            線別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem>CPL</asp:ListItem>
                <asp:ListItem>APL</asp:ListItem>
                <asp:ListItem>ZML</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種+TYPE:</td>
        <td>
            <asp:TextBox ID="tbSteelKindType" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔,EX:304L,201,...)</td>
    </tr>
    <tr>
        <td class="style1">
            黑皮寬度:</td>
        <td>
            <asp:TextBox ID="tbWidth" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔&nbsp; 或 以 &#39;~&#39; 表示範圍)</td>
    </tr>
    <tr>
        <td class="style1">
            黑皮厚:</td>
        <td>
            <asp:TextBox ID="tbThick" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔&nbsp; 或 以 &#39;~&#39; 表示範圍)</td>
    </tr>
    <tr>
        <td class="style1">
            處理程序:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">組合料</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">黑皮直軋</asp:ListItem>
                <asp:ListItem Selected="True" Value="3">直投ZML</asp:ListItem>
                <asp:ListItem Selected="True" Value="4">直投NO1</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">數量篩選:</td>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" 
                Text="派工量大於零" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>
<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="DataSaveTime">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?"></cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <%--<asp:HiddenField ID="HiddenField1" Value='<%# Bind("DataSaveTime","{0:yyyy/MM/dd HH:mm:ss}")%>' runat="server" />--%>
            </td>
            <td>
                <asp:Label ID="CIW15Label" runat="server" Text='<%# Eval("CIW15") %>' />
            </td>
            <td>
                <asp:Label ID="CIW0ALabel" runat="server" Text='<%# Eval("CIW0A") %>' />
            </td>
            <td>
                <asp:Label ID="CIW02Label" runat="server" Text='<%# Eval("CIW02") %>' />
            </td>
            <td>
                <asp:Label ID="CIW03Label" runat="server" Text='<%# Eval("CIW03") %>' />
            </td>
            <td>
                <asp:Label ID="CIW04Label" runat="server" Text='<%# Eval("CIW04") %>' />
            </td>
            <td>
                <asp:Label ID="CIW05Label" runat="server" Text='<%# Eval("CIW05") %>' />
            </td>
            <td>
                <asp:Label ID="CIW06Label" runat="server" Text='<%# Eval("CIW06Descript") %>' />
            </td>
            <td>
                <asp:Label ID="CIW12Label" runat="server" Text='<%# Eval("CIW12") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?"></cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                <%--<asp:HiddenField ID="HiddenField1" Value='<%# Bind("DataSaveTime","{0:yyyy/MM/dd HH:mm:ss}")%>' runat="server" />--%>
            </td>
            <td>
                <asp:Label ID="CIW15Label" runat="server" Text='<%# Eval("CIW15") %>' />
            </td>
            <td>
                <asp:Label ID="CIW0ALabel" runat="server" Text='<%# Eval("CIW0A") %>' />
            </td>
            <td>
                <asp:Label ID="CIW02Label" runat="server" Text='<%# Eval("CIW02") %>' />
            </td>
            <td>
                <asp:Label ID="CIW03Label" runat="server" Text='<%# Eval("CIW03") %>' />
            </td>
            <td>
                <asp:Label ID="CIW04Label" runat="server" Text='<%# Eval("CIW04") %>' />
            </td>
            <td>
                <asp:Label ID="CIW05Label" runat="server" Text='<%# Eval("CIW05") %>' />
            </td>
            <td>
                <asp:Label ID="CIW06Label" runat="server" Text='<%# Eval("CIW06Descript") %>' />
            </td>
            <td>
                <asp:Label ID="CIW12Label" runat="server" Text='<%# Eval("CIW12") %>' />
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
                <asp:HiddenField ID="HiddenField1" Value='<%# Bind("DataSaveTime","{0:yyyy/MM/dd HH:mm:ss}")%>' runat="server" />
                <asp:TextBox ID="CIW15TextBox" runat="server" Width="50"  Text='<%# Bind("CIW15") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW0ATextBox" runat="server" Width="50"  Text='<%# Bind("CIW0A") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW02TextBox" runat="server" Width="70"  Text='<%# Bind("CIW02") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW03TextBox" runat="server" Width="50"  Text='<%# Bind("CIW03") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW04TextBox" runat="server" Width="40"  Text='<%# Bind("CIW04") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW05TextBox" runat="server" Width="60"  Text='<%# Bind("CIW05") %>' />
            </td>
            <td>
                <%--<asp:TextBox ID="CIW06TextBox" runat="server" Text='<%# Bind("CIW06") %>' />--%>
                <asp:DropDownList ID="DDLCIW06" runat="server" SelectedValue='<%# Bind("CIW06") %>'>
                    <asp:ListItem Value="1">組合料</asp:ListItem>
                    <asp:ListItem Value="2">黑皮直軋</asp:ListItem>
                    <asp:ListItem Value="3">直投ZML</asp:ListItem>
                    <asp:ListItem Value="4">直投NO1</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="CIW12TextBox" runat="server" Width="60" Text='<%# Bind("CIW12") %>' />
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
                <asp:TextBox ID="CIW15TextBox" runat="server" Width="50" Text='<%# Bind("CIW15") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW0ATextBox" runat="server" Width="50" Text='<%# Bind("CIW0A") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW02TextBox" runat="server" Width="70" Text='<%# Bind("CIW02") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW03TextBox" runat="server" Width="50" Text='<%# Bind("CIW03") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW04TextBox" runat="server" Width="40" Text='<%# Bind("CIW04") %>' />
            </td>
            <td>
                <asp:TextBox ID="CIW05TextBox" runat="server" Width="60" Text='<%# Bind("CIW05") %>' />
            </td>
            <td>
                <%--<asp:TextBox ID="CIW06TextBox" runat="server" Width="60" Text='<%# Bind("CIW06") %>' />--%>
                <asp:DropDownList ID="DDLCIW06" runat="server" SelectedValue='<%# Bind("CIW06") %>'>
                    <asp:ListItem Value="1">組合料</asp:ListItem>
                    <asp:ListItem Value="2">黑皮直軋</asp:ListItem>
                    <asp:ListItem Value="3">直投ZML</asp:ListItem>
                    <asp:ListItem Value="4">直投NO1</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="CIW12TextBox" runat="server" Width="60" Text='<%# Bind("CIW12") %>' />
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
                            <th runat="server">排序</th>
                            <th runat="server">線別</th>
                            <th runat="server">黑皮寬度</th>
                            <th runat="server">鋼種</th>
                            <th runat="server">Type</th>
                            <th runat="server">黑皮厚度</th>
                            <th runat="server">處理程序</th>
                            <th runat="server">現場派工量</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField ButtonCount="20" />
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
                <asp:Label ID="CIW15Label" runat="server" Text='<%# Eval("CIW15") %>' />
            </td>
            <td>
                <asp:Label ID="CIW0ALabel" runat="server" Text='<%# Eval("CIW0A") %>' />
            </td>
            <td>
                <asp:Label ID="CIW02Label" runat="server" Text='<%# Eval("CIW02") %>' />
            </td>
            <td>
                <asp:Label ID="CIW03Label" runat="server" Text='<%# Eval("CIW03") %>' />
            </td>
            <td>
                <asp:Label ID="CIW04Label" runat="server" Text='<%# Eval("CIW04") %>' />
            </td>
            <td>
                <asp:Label ID="CIW05Label" runat="server" Text='<%# Eval("CIW05") %>' />
            </td>
            <td>
                <asp:Label ID="CIW06Label" runat="server" Text='<%# Eval("CIW06Descript") %>' />
            </td>
            <td>
                <asp:Label ID="CIW12Label" runat="server" Text='<%# Eval("CIW12") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:HiddenField ID="hfSQLQry" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="ColdRollingProcess.ProductionStartCmdEdit" DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLQry" Name="SQLSQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>



