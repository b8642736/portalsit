<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ZmlReplaceHistory.ascx.vb" Inherits="ColdRollingProcess.ZmlReplaceHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1
    {
        height: 26px;
    }

    .auto-style2
    {
        height: 23px;
    }
</style>
<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
<table style="width: 100%;">
    <tr>
        <td class="style1" colspan="2">查詢條件
            <hr />
        </td>
    </tr>
    <tr>
        <td class="style1">紀錄表類別:</td>
        <td>
            <cc1:DropDownListEx ID="ddlistDataKind" runat="server">
                <asp:ListItem>背輥</asp:ListItem>
                <asp:ListItem>第一中間輥</asp:ListItem>
                <asp:ListItem>第二中間輥</asp:ListItem>
            </cc1:DropDownListEx>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">機別:</td>
        <td class="auto-style2">
            <cc1:CheckBoxListEx ID="checkBoxListInsKind" OnDataBound="checkBoxList_DataBound_SelectAll" runat="server" DataSourceID="ODSInitIns" DataTextField="NOTE_ID" DataValueField="NOTE_ID" RepeatDirection="Horizontal" />
        </td>
    </tr>
    <tr>
        <td class="style1">日期:</td>
        <td>
            <asp:TextBox ID="txtDateStart" runat="server"></asp:TextBox>
            <cc2:CalendarExtender ID="CalendarExtenderStart" TargetControlID="txtDateStart" Format="yyyy/MM/dd" runat="server"></cc2:CalendarExtender>
            &nbsp;<asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
            &nbsp;<asp:TextBox ID="txtDateEnd" runat="server"></asp:TextBox>
            <cc2:CalendarExtender ID="CalendarExtenderEnd" TargetControlID="txtDateEnd" Format="yyyy/MM/dd" runat="server"></cc2:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="auto-style1">班別:</td>
        <td class="auto-style1">

            <cc1:CheckBoxListEx ID="checkBoxListShiftKind" OnDataBound="checkBoxList_DataBound_SelectAll" runat="server" DataSourceID="odsInitShift" DataTextField="NOTE_ID" DataValueField="NOTE_ID" RepeatDirection="Horizontal" />

        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件"
                Width="100px" />


            <asp:ObjectDataSource ID="odsInitIns" runat="server" SelectMethod="SearchSystemNote" TypeName="ColdRollingProcess.ZmlReplaceHistory">
                <SelectParameters>
                    <asp:Parameter DefaultValue="機別" Name="fromNoteType" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsInitShift" runat="server" SelectMethod="SearchSystemNote" TypeName="ColdRollingProcess.ZmlReplaceHistory">
                <SelectParameters>
                    <asp:Parameter DefaultValue="班別" Name="fromNoteType" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ods背輥代號" runat="server" SelectMethod="SearchSystemNote" TypeName="ColdRollingProcess.ZmlReplaceHistory">
                <SelectParameters>
                    <asp:Parameter DefaultValue="背輥代號" Name="fromNoteType" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ods規格" runat="server" SelectMethod="SearchSystemNote" TypeName="ColdRollingProcess.ZmlReplaceHistory">
                <SelectParameters>
                    <asp:Parameter DefaultValue="規格" Name="fromNoteType" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ods原因" runat="server" SelectMethod="SearchSystemNote" TypeName="ColdRollingProcess.ZmlReplaceHistory">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfDataKind" DefaultValue="" Name="fromNoteType" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.ZML更換紀錄表" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="ColdRollingProcess.ZmlReplaceHistory" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:HiddenField ID="hfDataKind" runat="server" />
        </td>
    </tr>
</table>

<hr />
<table style="width: 100%;">
    <tr>
        <td style="width: 200px">紀錄表類別:</td>
        <td>
            <cc1:RadioButtonListEx ID="radioDataKind" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"></cc1:RadioButtonListEx>
        </td>
    </tr>
</table>
<hr />
&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp
    <asp:Label ID="labDataKind1" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp
            
    <asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="GID"
        OnPreRender="ListViewAll_PreRender" OnItemInserting="ListViewAll_ItemInserting" OnItemUpdating="ListViewAll_ItemUpdating">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                     <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="日期Label" runat="server" Text='<%# Bind("日期", "{0:yyyy/MM/dd}")%>' />
                </td>
                <td>
                    <asp:Label ID="班別Label" runat="server" Text='<%# Eval("班別") %>' />
                </td>

                <% If showItem尺寸上輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸上輥Label" runat="server" Text='<%# Eval("尺寸上輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸下輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸下輥Label" runat="server" Text='<%# Eval("尺寸下輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸驅動輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸驅動輥Label" runat="server" Text='<%# Eval("尺寸驅動輥") %>' />
                </td>
                <% End If%>

                <% If showItem背輥代號 = True Then%>
                <td>
                    <asp:Label ID="背輥代號Label" runat="server" Text='<%# Eval("背輥代號") %>' />
                </td>
                <% End If%>

                <% If showItem規格 = True Then%>
                <td>
                    <asp:Label ID="規格Label" runat="server" Text='<%# Eval("規格") %>' />
                </td>
                <% End If%>

                <td>
                    <asp:Label ID="定期更換Label" runat="server" Text='<%# Eval("定期更換") %>' />
                </td>
                <td>
                    <asp:Label ID="損換更換Label" runat="server" Text='<%# Eval("損換更換") %>' />
                </td>
                <td>
                    <asp:Label ID="原因Label" runat="server" Text='<%# Eval("原因") %>' />
                </td>
                <td>
                    <asp:Label ID="班別說明Label" runat="server" Text='<%# Eval("班別說明") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    <asp:HiddenField ID="紀錄表類別HiddenField" runat="server" Value='<%# Bind("紀錄表類別") %>' />
                </td>
                <td>
                    <asp:TextBox ID="txtDateCRUD" runat="server" Text='<%# Bind("日期", "{0:yyyy/MM/dd}")%>' />
                    <cc2:CalendarExtender ID="CalendarExtenderCRUD" runat="server" TargetControlID="txtDateCRUD" Format="yyyy/MM/dd" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlistShiftKindCRUD" runat="server" DataSourceID="odsInitShift" DataTextField="NOTE_ID" DataValueField="NOTE_ID" />
                    <asp:HiddenField ID="hfShiftKindCRUD" Value='<%# Eval("班別")%>' runat="server" />
                </td>

                <% If showItem尺寸上輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸上輥TextBox" runat="server" Text='<%# Bind("尺寸上輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸下輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸下輥TextBox" runat="server" Text='<%# Bind("尺寸下輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸驅動輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸驅動輥TextBox" runat="server" Text='<%# Bind("尺寸驅動輥") %>' />
                </td>
                <% End If%>

                <% If showItem背輥代號 = True Then%>
                <td>
                    <cc1:DropDownListEx ID="ddlist背輥代號"   OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods背輥代號" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="背輥代號TextBox" runat="server" Text='<%# Bind("背輥代號") %>' />
                    <asp:HiddenField ID="hf背輥代號CRUD" Value='<%# Eval("背輥代號")%>' runat="server" />
                </td>
                <% End If%>

                <% If showItem規格 = True Then%>
                <td>
                    <cc1:DropDownListEx ID="ddlist規格"  OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods規格" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="規格TextBox" runat="server" Text='<%# Bind("規格") %>' />
                    <asp:HiddenField ID="hf規格CRUD" Value='<%# Eval("規格")%>' runat="server" />
                </td>
                <% End If%>

                <td>
                    <asp:CheckBox ID="定期更換CheckBoxCRUD" Width="30px" runat="server" />
                    <asp:HiddenField ID="hf定期更換CRUD" Value='<%# Eval("定期更換")%>' runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="損換更換CheckBoxCRUD" Width="30px" runat="server" />
                    <asp:HiddenField ID="hf損換更換CRUD" Value='<%# Eval("損換更換")%>' runat="server" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlist原因"  OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods原因" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="原因TextBox" runat="server" Text='<%# Bind("原因") %>' />
                    <asp:HiddenField ID="hf原因CRUD" Value='<%# Eval("原因")%>' runat="server" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlistShiftSingCRUD" runat="server"></cc1:DropDownListEx>
                    <asp:HiddenField ID="hfShiftSingCRUD" Value='<%# Eval("班別說明")%>' runat="server" />
                </td>
            </tr>
            <tr>
                <td>訊息:</td>
                <td colspan="20">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    <%--<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                </td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>未傳回資料。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateCRUD" runat="server" Text='<%# Bind("日期", "{0:yyyy/MM/dd}")%>'></asp:TextBox>
                    <cc2:CalendarExtender ID="CalendarExtenderCRUD" runat="server" TargetControlID="txtDateCRUD" Format="yyyy/MM/dd" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlistShiftKindCRUD" runat="server" DataSourceID="odsInitShift" DataTextField="NOTE_ID" DataValueField="NOTE_ID" />
                </td>
                <% If showItem尺寸上輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸上輥TextBox" runat="server" Text='<%# Bind("尺寸上輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸下輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸下輥TextBox" runat="server" Text='<%# Bind("尺寸下輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸驅動輥 = True Then%>
                <td>
                    <asp:TextBox ID="尺寸驅動輥TextBox" runat="server" Text='<%# Bind("尺寸驅動輥") %>' />
                </td>
                <% End If%>

                <% If showItem背輥代號 = True Then%>
                <td>
                    <cc1:DropDownListEx ID="ddlist背輥代號"  OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods背輥代號" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="背輥代號TextBox" runat="server" Text='<%# Bind("背輥代號") %>' />
                </td>
                <% End If%>

                <% If showItem規格 = True Then%>
                <td>
                    <cc1:DropDownListEx ID="ddlist規格"  OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods規格" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="規格TextBox" runat="server" Text='<%# Bind("規格") %>' />
                </td>
                <% End If%>
                <td>
                    <asp:CheckBox ID="定期更換CheckBoxCRUD" Width="30px" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="損換更換CheckBoxCRUD" Width="30px" runat="server" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlist原因" OnDataBinding ="SystemNoteDropDownListObj_DataBinding" AppendDataBoundItems="True" runat="server" DataSourceID="ods原因" DataTextField="NOTE_ID" DataValueField="NOTE_ID"/>
                    <br></br>
                    <asp:TextBox ID="原因TextBox" runat="server" Text='<%# Bind("原因") %>' />
                    <asp:HiddenField ID="hf原因CRUD" Value='<%# Eval("原因")%>' runat="server" />
                </td>
                <td>
                    <cc1:DropDownListEx ID="ddlistShiftSingCRUD" runat="server"></cc1:DropDownListEx>
                </td>
            </tr>
            <tr>
                <td>訊息:</td>
                <td colspan="20">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    <%--<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                    <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="日期Label" runat="server" Text='<%# Bind("日期", "{0:yyyy/MM/dd}")%>' />
                </td>
                <td>
                    <asp:Label ID="班別Label" runat="server" Text='<%# Eval("班別") %>' />
                </td>

                <% If showItem尺寸上輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸上輥Label" runat="server" Text='<%# Eval("尺寸上輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸下輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸下輥Label" runat="server" Text='<%# Eval("尺寸下輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸驅動輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸驅動輥Label" runat="server" Text='<%# Eval("尺寸驅動輥") %>' />
                </td>
                <% End If%>

                <% If showItem背輥代號 = True Then%>
                <td>
                    <asp:Label ID="背輥代號Label" runat="server" Text='<%# Eval("背輥代號") %>' />
                </td>
                <% End If%>

                <% If showItem規格 = True Then%>
                <td>
                    <asp:Label ID="規格Label" runat="server" Text='<%# Eval("規格") %>' />
                </td>
                <% End If%>

                <td>
                    <asp:Label ID="定期更換Label" runat="server" Text='<%# Eval("定期更換") %>' />
                </td>
                <td>
                    <asp:Label ID="損換更換Label" runat="server" Text='<%# Eval("損換更換") %>' />
                </td>
                <td>
                    <asp:Label ID="原因Label" runat="server" Text='<%# Eval("原因") %>' />
                </td>
                <td>
                    <asp:Label ID="班別說明Label" runat="server" Text='<%# Eval("班別說明") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="Tr2" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th id="Th1" runat="server"></th>
                                <th id="Th4" runat="server">日期</th>
                                <th id="Th5" runat="server">班別</th>
                                <th id="Th尺寸上輥" runat="server">上輥直徑<br />
                                    (mm)</th>
                                <th id="Th尺寸下輥" runat="server">下輥直徑<br />
                                    (mm)</th>
                                <th id="Th尺寸驅動輥" runat="server">驅動輥<br />
                                    尺寸規格</th>
                                <th id="Th背輥代號" runat="server">背輥代號</th>
                                <th id="Th規格" runat="server">規格</th>
                                <th id="Th11" runat="server">定期更換</th>
                                <th id="Th12" runat="server">損換更換</th>
                                <th id="Th13" runat="server">原因</th>
                                <th id="Th14" runat="server">帶班簽名</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                </td>
                <td>
                    <asp:Label ID="日期Label" runat="server" Text='<%# Eval("日期") %>' />
                </td>
                <td>
                    <asp:Label ID="班別Label" runat="server" Text='<%# Eval("班別") %>' />
                </td>

                <% If showItem尺寸上輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸上輥Label" runat="server" Text='<%# Eval("尺寸上輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸下輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸下輥Label" runat="server" Text='<%# Eval("尺寸下輥") %>' />
                </td>
                <% End If%>

                <% If showItem尺寸驅動輥 = True Then%>
                <td>
                    <asp:Label ID="尺寸驅動輥Label" runat="server" Text='<%# Eval("尺寸驅動輥") %>' />
                </td>
                <% End If%>

                <% If showItem背輥代號 = True Then%>
                <td>
                    <asp:Label ID="背輥代號Label" runat="server" Text='<%# Eval("背輥代號") %>' />
                </td>
                <% End If%>

                <% If showItem規格 = True Then%>
                <td>
                    <asp:Label ID="規格Label" runat="server" Text='<%# Eval("規格") %>' />
                </td>
                <% End If%>

                <td>
                    <asp:Label ID="定期更換Label" runat="server" Text='<%# Eval("定期更換") %>' />
                </td>
                <td>
                    <asp:Label ID="損換更換Label" runat="server" Text='<%# Eval("損換更換") %>' />
                </td>
                <td>
                    <asp:Label ID="原因Label" runat="server" Text='<%# Eval("原因") %>' />
                </td>
                <td>
                    <asp:Label ID="班別說明Label" runat="server" Text='<%# Eval("班別說明") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>