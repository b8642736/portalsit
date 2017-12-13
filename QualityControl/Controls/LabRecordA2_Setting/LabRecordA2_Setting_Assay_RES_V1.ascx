<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Setting_Assay_RES_V1.ascx.vb" Inherits="QualityControl.LabRecordA2_Setting_Assay_RES_V1" %>

<link href="CSS/LabRecordA2_Setting_CSS.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .myTab1 {
        width: 90%;
        border-collapse: collapse;
        border-style: solid;
        border-width: 1px;
        border-color: #cccccc;
    }

        .myTab1 td {
            height: 30px;
            padding: 2px;
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
            border-color: #cccccc;
        }


    .td_key {
        background: #28c82f;
        border-color: #000000;
        color: #000000;
    }
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <table class="myTab1">
            <tr>
                <td style="width: 10%">
                    <asp:Label ID="Label6" runat="server" Text="參照規範：" />
                </td>
                <td style="width: 30%">
                    <asp:CheckBox ID="queryKey1CheckBox" runat="server" />
                    <asp:DropDownList ID="queryKey1DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                </td>

                <td style="width: 10%">
                    <asp:Label ID="Label5" runat="server" Text="表面類別：" />
                </td>
                <td style="width: 30%; font-weight: 700;">
                    <asp:CheckBox ID="queryKey2CheckBox" runat="server" />
                    <asp:DropDownList ID="queryKey2DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                </td>

                <td style="width: 10%; font-weight: 700;" rowspan="5">
                    <asp:Button ID="btnSerach" runat="server" Height="35px" Text="查詢" Width="143px" />

                    <asp:HiddenField ID="hfSQL" runat="server" />
                    <asp:HiddenField ID="hfCheckNeed_Not" runat="server" />
                    <asp:ObjectDataSource ID="ods" runat="server" InsertMethod="Insert" SelectMethod="Search" TypeName="QualityControl.LabRecordA2_Setting_Assay_RES_V1" UpdateMethod="Update" DataObjectTypeName="CompanyORMDB.SQLServer.QCdb01.LabRecordA2_Assay_RES" DeleteMethod="Delete">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>

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
                <td>
                    <asp:Label ID="Label2" runat="server" Text="檢驗項目：" />
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



<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>

        <%--        <table class="myTab1">

            <tr>
                <td style="width: 120px">&nbsp;</td>
                <td></td>
            </tr>
        </table>--%>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="參照規範,表面類別,鋼種,材質,ASSAY_ID" DataSourceID="ods" EnableModelValidation="True" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFF8DC;">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="ASSAY_IDLabel" runat="server" Text='<%# showAssayInfo ( Eval("ASSAY_ID")) %>' />
                    </td>
                    <td>
                        <asp:Label ID="NORMAL_RANGELabel" runat="server" Text='<%# FS_NORMAL_RANGE( Eval("NORMAL_RANGE_L") , Eval("NORMAL_RANGE_H") ) %>' />
                    </td>
                    <td>
                        <asp:Label ID="RESULT_FORMATLabel" runat="server" Text='<%# Eval("RESULT_FORMAT") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #008A8C; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <%--<asp:Button ID="UpdateButton" runat="server" CommandName="Update_My" OnCommand="ListView1_ItemCommand_My" Text="更新" />--%>
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="參照規範Label" runat="server" Text='<%# Bind("參照規範") %>' />
                        <%--<asp:TextBox ID="參照規範TextBox" runat="server" Text='<%# Bind("參照規範") %>' />--%>
                    </td>
                    <td class="td_key">
                        <asp:Label ID="表面類別Label" runat="server" Text='<%# Bind("表面類別") %>' />
                        <%--<asp:TextBox ID="表面類別TextBox" runat="server" Text='<%# Bind("表面類別") %>' />--%>
                    </td>
                    <td class="td_key">
                        <asp:Label ID="鋼種Label" runat="server" Text='<%# Bind("鋼種") %>' />
                        <%--<asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' />--%>
                    </td>
                    <td class="td_key">
                        <asp:Label ID="材質Label" runat="server" Text='<%# Bind("材質") %>' />
                        <%--<asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' />--%>
                    </td>
                    <td class="td_key">
                        <asp:HiddenField ID="EditASSAY_IDHiddenField" runat="server" Value='<% Bind("ASSAY_ID") %>' />
                        <asp:Label ID="EditASSAY_IDLabel" runat="server" Text='<%# showAssayInfo(Eval("ASSAY_ID"))%>' />
                        <%--<asp:TextBox ID="ASSAY_IDTextBox" runat="server" Text='<%# Bind("ASSAY_ID") %>' />--%>
                        <br />
                        <asp:Button ID="BtnReadDefault" runat="server" Text="讀取預設值" OnClick="ListView1_BtnReadDefault_Click" CommandName ="ReadDefault" />
                    </td>
                    <td>
                        <asp:TextBox ID="EditNORMAL_RANGE_LTextBox" runat="server" Text='<%# Bind("NORMAL_RANGE_L")%>' />
                        <br />
                        <asp:TextBox ID="EditNORMAL_RANGE_HTextBox" runat="server" Text='<%# Bind("NORMAL_RANGE_H") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EditRESULT_FORMATTextBox" runat="server" Text='<%# Bind("RESULT_FORMAT") %>' Width='40' />
                    </td>
                    <td>
                        <asp:HiddenField ID="EFF_FLAGHiddenField" runat="server" Value='<%# Bind("EFF_FLAG") %>' />
                        <asp:DropDownList ID="EditEFF_FLAGDropDownList" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>訊息:</td>
                    <td colspan="20">&nbsp&nbsp
                <asp:CustomValidator ID="CV_EditItem" runat="server" ErrorMessage="" OnServerValidate="CustomValidator_1_Insert_ServerValidate" />
                        <br />
                        <asp:Label ID="Label_EditItem" runat="server" Font-Bold="False" ForeColor="Red" />
                    </td>
                </tr>
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
                        <asp:HiddenField ID="參照規範HiddenField" runat="server" Value='<%# Bind("參照規範") %>' />
                        <asp:DropDownList ID="EditKey1DropDownList" runat="server" />
                    </td>
                    <td class="td_key">
                        <asp:HiddenField ID="表面類別HiddenField" runat="server" Value='<%# Bind("表面類別") %>' />
                        <asp:DropDownList ID="EditKey2DropDownList" runat="server" />
                    </td>

                    <asp:UpdatePanel ID="UpdatePanel_ListView1_InsertItemTemplate2" runat="server">
                        <ContentTemplate>


                            <td class="td_key">
                                <asp:HiddenField ID="鋼種HiddenField" runat="server" Value='<%# Bind("鋼種") %>' />
                                <asp:DropDownList ID="EditKey3DropDownList" runat="server" OnSelectedIndexChanged="editKey3DropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>
                            <td class="td_key">
                                <asp:HiddenField ID="材質HiddenField" runat="server" Value='<%# Bind("材質") %>' />
                                <asp:DropDownList ID="EditKey4DropDownList" runat="server" />
                            </td>


                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel_ListView1_InsertItemTemplate3" runat="server">
                        <ContentTemplate>
                            <td class="td_key">
                                <asp:HiddenField ID="ASSAY_IDHiddenField" runat="server" Value='<%# Bind("ASSAY_ID") %>' />
                                <%--<asp:DropDownList ID="EditKey5DropDownList" runat="server" OnSelectedIndexChanged ="editKey5DropDownList_SelectedIndexChanged" AutoPostBack="true"  />--%>
                                <asp:DropDownList ID="EditKey5DropDownList" runat="server" />
                                <br />
                                <asp:Button ID="BtnReadDefault" runat="server" Text="讀取預設值" OnClick="ListView1_BtnReadDefault_Click" CommandName ="ReadDefault"  />
                            </td>
                            <td>
                                <asp:TextBox ID="EditNORMAL_RANGE_LTextBox" runat="server" Text='<%# Bind("NORMAL_RANGE_L")%>' />
                                <br />
                                <asp:TextBox ID="EditNORMAL_RANGE_HTextBox" runat="server" Text='<%# Bind("NORMAL_RANGE_H")%>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EditRESULT_FORMATTextBox" runat="server" Text='<%# Bind("RESULT_FORMAT") %>' Width='40' />
                            </td>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <td>
                        <asp:HiddenField ID="EFF_FLAGHiddenField" runat="server" Value='<%# Bind("EFF_FLAG")%>' />
                        <asp:DropDownList ID="EditEFF_FLAGDropDownList" runat="server" />
                    </td>
                </tr>
                <td>訊息:</td>
                <td colspan="20">&nbsp&nbsp
                            <asp:CustomValidator ID="CV_EditItem" runat="server" ErrorMessage=""
                                OnServerValidate="CustomValidator_1_Insert_ServerValidate" />
                </td>


            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="ASSAY_IDLabel" runat="server" Text='<%# showAssayInfo(Eval("ASSAY_ID"))%>' />
                    </td>
                    <td>
                        <asp:Label ID="NORMAL_RANGELabel" runat="server" Text='<%# FS_NORMAL_RANGE ( Eval("NORMAL_RANGE_L") , Eval("NORMAL_RANGE_H") ) %>' />
                    </td>
                    <td>
                        <asp:Label ID="RESULT_FORMATLabel" runat="server" Text='<%# Eval("RESULT_FORMAT") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG")%>' />
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
                                    <th runat="server" class="td_key">參照規範</th>
                                    <th runat="server" class="td_key">表面類別</th>
                                    <th runat="server" class="td_key">鋼種</th>
                                    <th runat="server" class="td_key">材質</th>
                                    <th runat="server" class="td_key">檢驗項目</th>
                                    <th runat="server">正常值範圍</th>
                                    <th runat="server">小數點位數</th>
                                    <th runat="server">停用否</th>
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
                        <asp:Label ID="參照規範Label" runat="server" Text='<%# Eval("參照規範") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="表面類別Label" runat="server" Text='<%# Eval("表面類別") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
                    </td>
                    <td class="td_key">
                        <asp:Label ID="ASSAY_IDLabel" runat="server" Text='<%# showAssayInfo ( Eval("ASSAY_ID")) %>' />
                    </td>
                    <td>
                        <asp:Label ID="NORMAL_RANGELabel" runat="server" Text='<%# FS_NORMAL_RANGE ( Eval("NORMAL_RANGE_L") , Eval("NORMAL_RANGE_H")  ) %>' />
                    </td>
                    <td>
                        <asp:Label ID="RESULT_FORMATLabel" runat="server" Text='<%# Eval("RESULT_FORMAT") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# Eval("EFF_FLAG")%>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </ContentTemplate>
</asp:UpdatePanel>
















