<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RGSGrindRecordEdit.ascx.vb" Inherits="ColdRollingProcess.RGSGrindRecordEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        width: 105px;
        text-align: right;
    }
    .auto-style3 {
        height: 20px;
    }
    .auto-style4 {
        width: 105px;
        text-align: right;
        height: 26px;
    }
    .auto-style5 {
        height: 26px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="日期:" TextAlign="Left" Checked="True" />
        </td>
        <td>
            <asp:TextBox ID="tbSatartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">研磨輥號:</td>
        <td>
            <asp:TextBox ID="tbRollerID" runat="server"></asp:TextBox>(兩個以上請以&quot;,&quot;區分 ex:141,142,...)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">研磨機號:</td>
        <td>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:CheckBox ID="cbRGS1" runat="server" Checked="True" Text="RGS1" />
                <asp:CheckBox ID="cbRGS2" runat="server" Checked="True" Text="RGS2" />
                <asp:CheckBox ID="cbRGS3" runat="server" Checked="True" Text="RGS3" />
                <asp:CheckBox ID="cbRGS4" runat="server" Checked="True" Text="RGS4" />
                <asp:CheckBox ID="cbRGS5" runat="server" Checked="True" Text="RGS5" />
                <asp:CheckBox ID="cbRGS6" runat="server" Checked="True" Text="RGS6" />
                <asp:CheckBox ID="cbRGS7" runat="server" Checked="True" Text="RGS7" />
                <asp:CheckBox ID="cbRGS8" runat="server" Checked="True" Text="RGS8" />
                <asp:CheckBox ID="cbRGS9" runat="server" Checked="True" Text="RGS9" />

            </asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">ZML使用機台:</td>
        <td class="auto-style3">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <asp:CheckBox ID="cbZML1" runat="server" Checked="True" Text="ZML1" />
                <asp:CheckBox ID="cbZML2" runat="server" Checked="True" Text="ZML2" />
                <asp:CheckBox ID="cbZML3" runat="server" Checked="True" Text="ZML3" />
            </asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="203px"></asp:TextBox>
            (兩個以上請以&quot;,&quot;區分 ex:K1234,K1111,...)</td>
    </tr>
    <tr>
        <td class="auto-style1">尺寸:</td>
        <td>
            <asp:TextBox ID="tbSatartSize" runat="server" Width="50px">0</asp:TextBox>
            ~<asp:TextBox ID="tbEndSize" runat="server" Width="50px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">研磨量:</td>
        <td class="auto-style5">
            <asp:TextBox ID="tbSatartGrideWeight" runat="server" Width="50px">0</asp:TextBox>
            ~<asp:TextBox ID="tbENDGrideWeight" runat="server" Width="50px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">冠形:</td>
        <td class="auto-style3">
            <asp:TextBox ID="tbCrownShape" runat="server" Width="203px"></asp:TextBox>
            (兩個以上請以&quot;,&quot;區分 ex:160*0.08,0.03,....)</td>
    </tr>
    <tr>
        <td class="auto-style1">備註:</td>
        <td>
            <asp:TextBox ID="tbMemo1" runat="server" Width="203px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">員工編號:</td>
        <td><asp:TextBox ID="tbEmployees" runat="server" Width="203px"></asp:TextBox>(兩個以上請以&quot;,&quot;區分 ex:11111,11112,....)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="RGSID,RollerID,DataSaveTime">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" Enabled='<%# Eval("IsCanEditDeleteData") %>' />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Enabled='<%# Eval("IsCanEditDeleteData") %>'  />
            </td>
            <td>
                <asp:Label ID="RGSIDLabel" runat="server" Text='<%# Eval("RGSID") %>' />
            </td>
            <td>
                <asp:Label ID="RollerIDLabel" runat="server" Text='<%# Eval("RollerID") %>' />
            </td>
            <td>
                <asp:Label ID="DataSaveTimeLabel" runat="server" Text='<%# Eval("DataSaveTime") %>' />
            </td>
            <td>
                <asp:Label ID="SizeLabel" runat="server" Text='<%# Eval("Size") %>' />
            </td>
            <td>
                <asp:Label ID="CrownShapeLabel" runat="server" Text='<%# Eval("CrownShape") %>' />
            </td>
            <td>
                <asp:Label ID="GrindWeightLabel" runat="server" Text='<%# Eval("GrindWeight") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessedStateLabel" runat="server" Text='<%# Eval("ProcessStateDescript") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessEmployeeIDLabel" runat="server" Text='<%# Eval("ProcessEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_ZMLNameLabel" runat="server" Text='<%# Eval("AboutRunProcessData_ZMLName") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_CoilFullNumberLabel" runat="server" Text='<%# Eval("AboutRunProcessData_CoilFullNumber") %>' />
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
                <asp:TextBox ID="RGSIDTextBox" runat="server" Text='<%# Bind("RGSID") %>' ReadOnly="true" Width="50" BackColor="LightGray" />
            </td>
            <td>
                <asp:TextBox ID="RollerIDTextBox" runat="server" Text='<%# Bind("RollerID") %>' ReadOnly="true" Width="60"  BackColor="LightGray"  />
            </td>
            <td>
                <asp:TextBox ID="DataSaveTimeTextBox" runat="server" Text='<%# Bind("DataSaveTime") %>' ReadOnly="true"  BackColor="LightGray"  Width="80"  />
            </td>
            <td>
                <asp:TextBox ID="SizeTextBox" runat="server" Text='<%# Bind("Size") %>' Width="70" MaxLength="8" />
            </td>
            <td>
                <asp:TextBox ID="CrownShapeTextBox" runat="server" Text='<%# Bind("CrownShape") %>' Width="80" MaxLength="16"  />
            </td>
            <td>
                <%--<asp:TextBox ID="GrindWeightTextBox" runat="server" Text='<%# Bind("GrindWeight") %>'  Width="80"/>--%>
                自動計算
            </td>
            <td>
                <%--<asp:TextBox ID="ProcessedStateTextBox" runat="server" Text='<%# Bind("ProcessedState") %>' />--%>
                <asp:DropDownList ID="ddlProcessedState" runat="server"  Width="60"  SelectedValue='<%# Bind("ProcessedState") %>'>
                    <asp:ListItem Value="0" Selected="True" >正常</asp:ListItem>
                    <asp:ListItem Value="1">裂痕</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="ProcessEmployeeIDTextBox" runat="server" Text='<%# Bind("ProcessEmployeeID") %>' />
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
            </td>
            <td>
                <asp:TextBox ID="AboutRunProcessData_ZMLNameTextBox" runat="server" Text='<%# Eval("AboutRunProcessData_ZMLName")%>'  ReadOnly="true"  BackColor="LightGray"  />
            </td>
            <td>
                <asp:TextBox ID="AboutRunProcessData_CoilFullNumberTextBox" runat="server" Text='<%# Eval("AboutRunProcessData_CoilFullNumber") %>'  ReadOnly="true"  BackColor="LightGray"  />
            </td>
            <tr>
                <td colspan="12">
                    <asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
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
                <%--<asp:TextBox ID="RGSIDTextBox" runat="server" Text='<%# Bind("RGSID") %>' />--%>
                <asp:DropDownList ID="ddlRGS" runat="server" EnableViewState="true" >
                    <asp:ListItem Selected="True"  Value="RGS1">RGS1</asp:ListItem>
                    <asp:ListItem  Value="RGS2">RGS2</asp:ListItem>
                    <asp:ListItem Value="RGS3">RGS3</asp:ListItem>
                    <asp:ListItem Value="RGS4">RGS4</asp:ListItem>
                    <asp:ListItem Value="RGS5">RGS5</asp:ListItem>
                    <asp:ListItem Value="RGS6">RGS6</asp:ListItem>
                    <asp:ListItem Value="RGS7">RGS7</asp:ListItem>
                    <asp:ListItem Value="RGS8">RGS8</asp:ListItem>
                    <asp:ListItem Value="RGS9">RGS9</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="RollerIDTextBox" runat="server" Text='<%# Bind("RollerID") %>' Width="60" MaxLength="7" />
            </td>
            <td>
                <%--<asp:TextBox ID="DataSaveTimeTextBox" runat="server" Text='<%# Bind("DataSaveTime") %>' />--%>
                 <asp:Label ID="Label4" runat="server" Text="自動給值"></asp:Label>                
            </td>
            <td>
                <asp:TextBox ID="SizeTextBox" runat="server" Text='<%# Bind("Size") %>' Width="70" MaxLength="8"  />
            </td>
            <td>
                <asp:TextBox ID="CrownShapeTextBox" runat="server" Text='<%# Bind("CrownShape") %>' Width="80" MaxLength="16"  />
            </td>
            <td>
                <%--<asp:TextBox ID="GrindWeightTextBox" runat="server" Text='<%# Bind("GrindWeight") %>' />--%>
                 <asp:Label ID="Label3" runat="server" Text="自動計算" Width="80"></asp:Label>                
            </td>
            <td>
                <%--<asp:TextBox ID="ProcessedStateTextBox" runat="server" Text='<%# Bind("ProcessedState") %>' />--%>
                <asp:DropDownList ID="ddlProcessedState" runat="server"  Width="60" SelectedValue='<%# Bind("ProcessedState") %>'>
                    <asp:ListItem Value="0" Selected="True" >正常</asp:ListItem>
                    <asp:ListItem Value="1">裂痕</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="ProcessEmployeeIDTextBox" runat="server" Text='<%# Bind("ProcessEmployeeID") %>'  Width="50" MaxLength="7" />
            </td>
            <td>
                <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>'  Width="120" MaxLength="20" />
            </td>
             <td>
                <%--<asp:TextBox ID="AboutRunProcessData_ZMLNameTextBox" runat="server" Text='<%# Bind("AboutRunProcessData_ZMLName") %>' />--%>
                 <asp:Label ID="Label1" runat="server" Text="自動取得"></asp:Label>                
            </td>
            <td>
                <%--<asp:TextBox ID="AboutRunProcessData_CoilFullNumberTextBox" runat="server" Text='<%# Bind("AboutRunProcessData_CoilFullNumber") %>' />--%>
                 <asp:Label ID="Label2" runat="server" Text="自動取得"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" Enabled='<%# Eval("IsCanEditDeleteData") %>'  />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Enabled='<%# Eval("IsCanEditDeleteData") %>'  />
            </td>
            <td>
                <asp:Label ID="RGSIDLabel" runat="server" Text='<%# Eval("RGSID") %>' />
            </td>
            <td>
                <asp:Label ID="RollerIDLabel" runat="server" Text='<%# Eval("RollerID") %>' />
            </td>
            <td>
                <asp:Label ID="DataSaveTimeLabel" runat="server" Text='<%# Eval("DataSaveTime") %>' />
            </td>
            <td>
                <asp:Label ID="SizeLabel" runat="server" Text='<%# Eval("Size") %>' />
            </td>
            <td>
                <asp:Label ID="CrownShapeLabel" runat="server" Text='<%# Eval("CrownShape") %>' />
            </td>
            <td>
                <asp:Label ID="GrindWeightLabel" runat="server" Text='<%# Eval("GrindWeight") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessedStateLabel" runat="server" Text='<%# Eval("ProcessStateDescript") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessEmployeeIDLabel" runat="server" Text='<%# Eval("ProcessEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_ZMLNameLabel" runat="server" Text='<%# Eval("AboutRunProcessData_ZMLName") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_CoilFullNumberLabel" runat="server" Text='<%# Eval("AboutRunProcessData_CoilFullNumber") %>' />
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
                            <th runat="server">研磨機號</th>
                            <th runat="server">研磨輥號</th>
                            <th runat="server">存檔時間</th>
                            <th runat="server">尺寸</th>
                            <th runat="server">冠形</th>
                            <th runat="server">研磨量</th>
                            <th runat="server">處理狀況</th>
                            <th runat="server">員工編號</th>
                            <th runat="server">備註</th>
                            <th runat="server">使用ZML機號</th>
                            <th runat="server">使用鋼捲號碼</th>
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
                <asp:Label ID="RGSIDLabel" runat="server" Text='<%# Eval("RGSID") %>' />
            </td>
            <td>
                <asp:Label ID="RollerIDLabel" runat="server" Text='<%# Eval("RollerID") %>' />
            </td>
            <td>
                <asp:Label ID="DataSaveTimeLabel" runat="server" Text='<%# Eval("DataSaveTime") %>' />
            </td>
            <td>
                <asp:Label ID="SizeLabel" runat="server" Text='<%# Eval("Size") %>' />
            </td>
            <td>
                <asp:Label ID="CrownShapeLabel" runat="server" Text='<%# Eval("CrownShape") %>' />
            </td>
            <td>
                <asp:Label ID="GrindWeightLabel" runat="server" Text='<%# Eval("GrindWeight") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessedStateLabel" runat="server" Text='<%# Eval("ProcessedState") %>' />
            </td>
            <td>
                <asp:Label ID="ProcessEmployeeIDLabel" runat="server" Text='<%# Eval("ProcessEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_ZMLNameLabel" runat="server" Text='<%# Eval("AboutRunProcessData_ZMLName") %>' />
            </td>
            <td>
                <asp:Label ID="AboutRunProcessData_CoilFullNumberLabel" runat="server" Text='<%# Eval("AboutRunProcessData_CoilFullNumber") %>' />
            </td>
         </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.RGSGrindRecord" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="ColdRollingProcess.RGSGrindRecordEdit" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />


