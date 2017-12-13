<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Setting_Remark_RES_V2.ascx.vb" Inherits="QualityControl.LabRecordA2_Setting_Remark_RES_V2" %>

<link href="CSS/LabRecordA2_Setting_CSS.css" rel="stylesheet" type="text/css" />



<table id="HtmlTab1" class="myTab1">
    <tr>
        <td style="width: 95%">
            <%--HtmlTab1_A-------------------------------------------------------%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table id="HtmlTab1_A" class="myTab1" style="width: 100%">

                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="鋼種：" />
                            </td>
                            <td>
                                <asp:CheckBox ID="queryKey3CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey3DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                            <td>
                                <asp:Label ID="Label1" runat="server" Text="材質：" />
                            </td>
                            <td>
                                <asp:CheckBox ID="queryKey4CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey4DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>
                        </tr>


                        <tr>
                            <td style="width: 10%">
                                <asp:Label ID="Label6" runat="server" Text="參照規範：" />
                            </td>
                            <td style="width: 30%">
                                <asp:CheckBox ID="queryKey1CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey1DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged"  AutoPostBack="True" />
                            </td>

                            <td style="width: 10%">
                                <asp:Label ID="Label5" runat="server" Text="表面類別：" />
                            </td>
                            <td style="width: 30%; font-weight: 700;">
                                <asp:CheckBox ID="queryKey2CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey2DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="片語項目：" />
                            </td>
                            <td>
                                <asp:CheckBox ID="queryKey5CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey5DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                            <td>
                                <asp:Label ID="Label3" runat="server" Text="停用否："></asp:Label>

                            </td>
                            <td>

                                <asp:DropDownList ID="queryEFF_FLAGDropDown" runat="server"></asp:DropDownList>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>

            </asp:UpdatePanel>
            <%--HtmlTab1_A-------------------------------------------------------%>
        </td>

        <td>
            <%--HtmlTab1_B-------------------------------------------------------%>
            <asp:Button ID="btnSerach" runat="server" Height="35px" Text="查詢" Width="143px" />

            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:HiddenField ID="hfCheckNeed_Not" runat="server" />
            <asp:ObjectDataSource ID="ods" runat="server" InsertMethod="Insert" SelectMethod="Search" TypeName="QualityControl.LabRecordA2_Setting_Remark_RES_V2" UpdateMethod="Update" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES" DeleteMethod="Delete">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <%--HtmlTab1_B-------------------------------------------------------%>
        </td>
    </tr>
</table>



<asp:ListView ID="ListView1" runat="server" DataKeyNames="參照規範,表面類別,鋼種,材質,REMARK_ID" DataSourceID="ods" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td class="td_key">
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="REMARK_IDLabel" runat="server" Text='<%# showRemarkInfo(Eval("REMARK_ID")) %>' />
            </td>
            <td>
                <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
            </td>


            <td>
                <asp:Label ID="SAVE_OPERLabel" runat="server" Text='<%# Eval("SAVE_OPER") %>' />
                <br />
                <asp:Label ID="SAVE_DATELabel" runat="server" Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1) %>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>

            <td class="td_key">
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Bind("鋼種") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="材質Label" runat="server" Text='<%# Bind("材質") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="參照規範Label" runat="server" Text='<%# Bind("參照規範") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="表面類別Label" runat="server" Text='<%# Bind("表面類別") %>' />
            </td>

            <td class="td_key">
                <asp:HiddenField ID="EditREMARK_IDHiddenField" runat="server" Value='<% Bind("REMARK_ID") %>' />
                <asp:Label ID="REMARK_IDLabel" runat="server" Text='<%# showRemarkInfo(Eval("REMARK_ID"))%>' />
            </td>
            <td>
                <asp:TextBox ID="EFF_FLAGTextBox" runat="server" Text='<%# Bind("EFF_FLAG") %>' Visible="false" />
                <asp:DropDownList ID="EditEFF_FLAGDropDownList" runat="server" />
            </td>

            <td>
                <asp:TextBox ID="SAVE_OPERTextBox" runat="server" CssClass="ListView1CSS_Lock" ReadOnly ="true"  Text='<%# Eval("SAVE_OPER") %>' />
                <br />
                <asp:TextBox ID="SAVE_DATETextBox" runat="server" CssClass="ListView1CSS_Lock" ReadOnly ="true"  Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1) %>' />
            </td>

        </tr>
        <td>訊息:</td>
        <td colspan="20">&nbsp&nbsp
                            <asp:CustomValidator ID="CV_EditItem" runat="server" ErrorMessage=""
                                OnServerValidate="CustomValidator_1_Insert_ServerValidate" ForeColor="Red" />
        </td>

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

            <td class="td_key">
                <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' Visible="false" />
                <asp:DropDownList ID="EditKey3DropDownList" runat="server" OnSelectedIndexChanged="editKey3DropDownList_SelectedIndexChanged" AutoPostBack="True" />
            </td>
            <td class="td_key">
                <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' Visible="false" />
                <asp:DropDownList ID="EditKey4DropDownList" runat="server" />
            </td>


            <td class="td_key">
                <asp:TextBox ID="參照規範TextBox" runat="server" Text='<%# Bind("參照規範") %>' Visible="false" />
                <asp:DropDownList ID="EditKey1DropDownList" runat="server" />
            </td>
            <td class="td_key">
                <asp:TextBox ID="表面類別TextBox" runat="server" Text='<%# Bind("表面類別") %>' Visible="false" />
                <asp:DropDownList ID="EditKey2DropDownList" runat="server" />
            </td>        

            <td class="td_key">
                <asp:TextBox ID="REMARK_IDTextBox" runat="server" Text='<%# Bind("REMARK_ID") %>' Visible="false" />
                <asp:DropDownList ID="EditKey5DropDownList" runat="server" />
                <%--                                <br />
                                <asp:Button ID="BtnReadDefault" runat="server" Text="讀取預設值" OnClick="ListView1_BtnReadDefault_Click" CommandName ="ReadDefault"  />--%>
            </td>

            <td> 
                <asp:TextBox ID="EFF_FLAGTextBox" runat="server" Text='<%# Bind("EFF_FLAG") %>' Visible="false"  />
                <asp:DropDownList ID="EditEFF_FLAGDropDownList" runat="server" />
            </td>




            <td>
                <asp:TextBox ID="SAVE_OPERTextBox" runat="server" CssClass="ListView1CSS_Lock" ReadOnly ="true"  />
                <br />
                <asp:TextBox ID="SAVE_DATETextBox" runat="server" CssClass="ListView1CSS_Lock" ReadOnly ="true"  />
            </td>




        </tr>
        <td>訊息:</td>
        <td colspan="20">&nbsp&nbsp
                            <asp:CustomValidator ID="CV_EditItem" runat="server" ErrorMessage=""
                                OnServerValidate="CustomValidator_1_Insert_ServerValidate" ForeColor="Red" />
        </td>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td class="td_key">
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="REMARK_IDLabel" runat="server" Text='<%# showRemarkInfo(Eval("REMARK_ID")) %>' />
            </td>
            <td>
                <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
            </td>


            <td>
                <asp:Label ID="SAVE_OPERLabel" runat="server" Text='<%# Eval("SAVE_OPER") %>' />
                <br />
                <asp:Label ID="SAVE_DATELabel" runat="server" Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1) %>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server" class="ListView1CSS">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>

                            <th runat="server">鋼種</th>
                            <th runat="server">材質</th>

                            <th runat="server">參照規範</th>
                            <th runat="server">表面類別</th>

                            <th runat="server">片語項目</th>
                            <th runat="server">停用否</th>

                            <th runat="server">存檔人員<br />
                                存檔日期</th>

                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
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

            <td class="td_key">
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>


            <td class="td_key">
                <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
            </td>
            <td class="td_key">
                <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
            </td>

            <td class="td_key">
                <asp:Label ID="REMARK_IDLabel" runat="server" Text='<%# showRemarkInfo(Eval("REMARK_ID")) %>' />
            </td>
            <td>
                <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
            </td>


            <td>
                <asp:Label ID="SAVE_OPERLabel" runat="server" Text='<%# Eval("SAVE_OPER") %>' />
                <br />
                <asp:Label ID="SAVE_DATELabel" runat="server" Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1)%>' />
            </td>

        </tr>
    </SelectedItemTemplate>
</asp:ListView>





