<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InsuranceEdit.ascx.vb" Inherits="AST500LB.InsuranceEdit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%" AutoPostBack="True" BorderStyle="Ridge">
    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
    <HeaderTemplate>資產保險查詢編修作業</HeaderTemplate>
    <ContentTemplate>
        <style type="text/css">
        .style1
        {
            width: 141px;
        }
    </style>
    <table style="width:100%;">
        <tr>
            <td class="style1">
                資產編號:</td>
            <td>
                <asp:TextBox ID="tbAssetNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                資產名稱:</td>
            <td class="style3">
                <asp:TextBox ID="tbAssetName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                置放地點:</td>
            <td>
                <asp:TextBox ID="UseDepart" runat="server" Width="71px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                保險期間:</td>
            <td>
                <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="tbStartDate" Enabled="True">
                </cc1:CalendarExtender>
                ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="tbEndDate" Enabled="True">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style1">
                保險種類:</td>
            <td>
                <asp:CheckBoxList ID="cblInsurceKind" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">火險</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">爆炸險</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                廠別:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" >SA</asp:ListItem>
                    <asp:ListItem>AA</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>QA</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>RA</asp:ListItem>
                    <asp:ListItem>RC</asp:ListItem>
                    <asp:ListItem>RD</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                <asp:Button ID="btnConvertToOutCompanyDownload" runat="server" Text="下載保險公司格式" Width="160px" />
               <asp:HiddenField ID="hfQryString" runat="server" />
                <asp:HiddenField ID="hfQryString1" runat="server" />
            </td>
        </tr>
    </table>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult"
            InsertItemPosition="LastItem" DataKeyNames="NUMBER,FACKIND,SDATE,SAVKIND" EnableModelValidation="True">
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssetNameLabel" runat="server" Text='<%# Eval("AssetName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FACKINDLabel" runat="server" Text='<%# Eval("FACKIND") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SDATELabel" runat="server" Text='<%# Eval("SDATEDateFormat","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EDATELabel" runat="server" Text='<%# Eval("EDATEDateFormat","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SAVKINDLabel" runat="server" Text='<%# Eval("SAVKINDChinese") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssetNameLabel" runat="server" Text='<%# Eval("AssetName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FACKINDLabel" runat="server" Text='<%# Eval("FACKIND") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SDATELabel" runat="server" Text='<%# Eval("SDATEDateFormat","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EDATELabel" runat="server" Text='<%# Eval("EDATEDateFormat","{0:d}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SAVKINDLabel" runat="server" Text='<%# Eval("SAVKINDChinese") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                    </td>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            未傳回資料。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="true" 
                            CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssetNameLabel" runat="server" Text="自動取得" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Selected="True" Value="SA">SA</asp:ListItem>
                            <asp:ListItem Value="AA">AA</asp:ListItem>
                            <asp:ListItem Value="AB">AB</asp:ListItem>
                            <asp:ListItem Value="QA">QA</asp:ListItem>
                            <asp:ListItem Value="NA">NA</asp:ListItem>
                            <asp:ListItem Value="RA">RA</asp:ListItem>
                            <asp:ListItem Value="RC">RC</asp:ListItem>
                            <asp:ListItem Value="RD">RD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="SDATETextBox" runat="server" 
                            Text='<%# Bind("SDATEDateFormat") %>' Width="100px" />
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy/MM/dd" 
                            TargetControlID="SDATETextBox">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="EDATETextBox" runat="server" Text='<%# Bind("EDATEDateFormat") %>' Width="100px" />
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="EDATETextBox" Format="yyyy/MM/dd" >
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" 
                            >
                            <asp:ListItem Selected="True" Value="1">火險</asp:ListItem>
                            <asp:ListItem Value="2">爆炸險</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="MEMOTextBox" runat="server" Text='<%# Bind("MEMO") %>' />
                    </td>
                 </tr>
                 <tr>
                     
                    <td>
                        訊息:</td>
                     
                    <td colspan="7">
                        
                        <asp:CustomValidator ID="InsertCustomValidator1" runat="server" 
                            OnServerValidate="InsertCustomValidator1_ServerValidate"></asp:CustomValidator>
                     </td>
                     
                 </tr>
                 <%--<tr>
                    <td></td>
                    <td colspan="7">
                 </tr>--%>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">
                                    </th>
                                    <th runat="server">
                                        資產編號</th>
                                    <th runat="server">
                                        資產名稱</th>
                                    <th runat="server">
                                        廠別</th>
                                    <th runat="server">
                                        保險啟始日</th>
                                    <th runat="server">
                                        保險終止日</th>
                                    <th runat="server">
                                        保險種類</th>
                                    <th runat="server">
                                        備註1</th>
                                </tr>
                                <tr runat="server" ID="itemPlaceholder">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" CausesValidation="false" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Bind("NUMBER") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="AssetNameLabel" runat="server" Text='自動取得' />
                    </td>
                    <td>
                        <asp:Label ID="FACKINDLabel" runat="server" Text='<%# Bind("FACKIND") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SDATELabel" runat="server" Text='<%# Bind("SDATEDateFormat","{0:d}") %>' />

                    </td>
                    <td>
                        <asp:TextBox ID="EDATETextBox" runat="server" Text='<%# Bind("EDATEDateFormat","{0:d}") %>' />
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="EDATETextBox" Format="yyyy/MM/dd" >
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:Label ID="SAVKINDLabel" runat="server" Text='<%# Bind("SAVKIND") %>'></asp:Label>                        
                    </td>
                    <td>
                        <asp:TextBox ID="MEMOTextBox" runat="server" Text='<%# Bind("MEMO") %>' />
                    </td>
                 </tr>
            </EditItemTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td>
                        <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssetNameLabel" runat="server" Text='<%# Eval("AssetName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FACKINDLabel" runat="server" Text='<%# Eval("FACKIND") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SDATELabel" runat="server" Text='<%# Eval("SDATE") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EDATELabel" runat="server" Text='<%# Eval("EDATE") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SAVKINDLabel" runat="server" Text='<%# Eval("SAVKIND") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:Label ID="lbMessage" runat="server"></asp:Label>

        <asp:ObjectDataSource ID="odsSearchResult" runat="server" 
            DataObjectTypeName="CompanyORMDB.AST500LB.AST501PF" DeleteMethod="CDBDelete" 
            InsertMethod="CDBInsert" SelectMethod="Search" 
            TypeName="AST500LB.InsuranceEdit" UpdateMethod="CDBUpdate">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
    <HeaderTemplate>複製新增資產保險作業</HeaderTemplate>
    <ContentTemplate>
        <style type="text/css">
        .style1
        {
            width: 122px;
        }
        </style>
        <br />
        <br />
        複製篩選條件:
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    保險基準日:</td>
                <td>
                    <asp:TextBox ID="tbCopyFilterDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" 
                        Format="yyyy/MM/dd" TargetControlID="tbCopyFilterDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    廠別:</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">SA</asp:ListItem>
                        <asp:ListItem>AA</asp:ListItem>
                        <asp:ListItem>AB</asp:ListItem>
                        <asp:ListItem>QA</asp:ListItem>
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>RA</asp:ListItem>
                        <asp:ListItem>RC</asp:ListItem>
                        <asp:ListItem>RD</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>            
        </table>
        <br />
        <br />
        <br />
        複製產生資料之預設值:
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    設定保險起始日:
                </td>
                <td>
                    <asp:TextBox ID="tbSetStartDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy/MM/dd" 
                        TargetControlID="tbSetStartDate" Enabled="True">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    設定保險終止日:
                </td>
                <td>
                    <asp:TextBox ID="tbSetEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy/MM/dd" 
                        TargetControlID="tbSetEndDate" Enabled="True">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">訊息:</td>
                <td>
                    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        
        <br />
        <asp:Label ID="Label1" runat="server" BorderStyle="Dotted" ForeColor="Red" 
            Text="注意:複製前請先確認  設定保險起始日及終止日是否正確!"></asp:Label>
        <br />
        <br />
        
        <asp:Button ID="btnStartCopy" runat="server" Text="開始複製" Width="120px" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
            ConfirmText="是否確定開始複製?" TargetControlID="btnStartCopy">
        </cc1:ConfirmButtonExtender>
        
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
