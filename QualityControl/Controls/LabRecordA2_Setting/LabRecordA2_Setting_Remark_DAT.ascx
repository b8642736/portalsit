<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Setting_Remark_DAT.ascx.vb" Inherits="QualityControl.LabRecordA2_Setting_Remark_DAT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />
<link href="CSS/LabRecordA2_Setting_CSS.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    #myDiv1A {
        width: 30%;
        float: left;
    }

    #myDiv1B {
        width: 20px;
        float: left;
    }

    #myDiv2 {
        width: 50%;
        float: left;
    }

    #myDiv3 {
        width: 70%;
        clear: both;
    }
</style>

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
    Width="100%" Height="500px" CssClass="ajax__myTab">
    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
        <HeaderTemplate>[3A]清單</HeaderTemplate>
        <ContentTemplate>
            <div id="myDiv1A">
                <table class="myTab1">
                    <tr>
                        <td />
                        <asp:Label ID="Label1a0" runat="server" Text="新增：" />
                        <td>
                            <asp:Button ID="btnInserNewRecord1" runat="server" Text="新增一筆內容" Width="143px" Height="35px" /></td>
                    </tr>
                    <tr>
                        <td />
                        <td />
                    </tr>

                    <tr>
                        <td style="width: 120px">
                            <asp:Label ID="Label1a" runat="server" Text="片語代號類別：" />
                        </td>
                        <td>
                            <asp:DropDownList ID="queryREMARK_IDDropDownList" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1b" runat="server" Text="片語代號序號：" />
                        </td>
                        <td>
                            <asp:TextBox ID="queryREMARK_IDTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Labelc" runat="server" Text="片語內容：" />
                        </td>
                        <td>
                            <asp:TextBox ID="queryCONTEXTTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="群組序號："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="queryDISPLAY_SEQTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="是否顯示："></asp:Label>

                        </td>
                        <td>

                            <asp:DropDownList ID="queryDISPLAY_FLAGDropDown" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="條件檢查："></asp:Label>

                        </td>
                        <td>

                            <asp:DropDownList ID="queryCHECK_ASSAY_ITEMDropDown" runat="server"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="停用否："></asp:Label>

                        </td>
                        <td>

                            <asp:DropDownList ID="queryEFF_FLAGDropDown" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSerach_Master" runat="server" Height="35px" Text="查詢" Width="143px" />
                            <asp:HiddenField ID="hfSQL_Master" runat="server" />
                            <asp:ObjectDataSource ID="ods_Master" runat="server" SelectMethod="Search_Master" TypeName="QualityControl.LabRecordA2_Setting_Remark_DAT">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfSQL_Master" Name="fromSQL" PropertyName="Value" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                        </td>
                    </tr>
                </table>
            </div>
            <div id="myDiv1B">&nbsp;</div>
            <div id="myDiv2">
                <table class="myTab2 ">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ods_Master"
                                EnableModelValidation="True"
                                DataKeyNames="REMARK_ID" Width="100%" AllowPaging="True"
                                PageSize="5">

                                <Columns>
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="明細">
                                        <ItemStyle Height="35px" HorizontalAlign="Center" Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="REMARK_ID" HeaderText="片語代號" SortExpression="REMARK_ID">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CONTEXT" HeaderText="片語內容" SortExpression="CONTEXT"></asp:BoundField>

                                    <asp:BoundField DataField="DISPLAY_SEQ" HeaderText="群組<BR>序號" SortExpression="DISPLAY_SEQ" HtmlEncode="False">
                                        <ItemStyle Width="40px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="EFF_FLAG" HeaderText="停用<BR>否" SortExpression="EFF_FLAG" HtmlEncode="False">
                                        <ItemStyle Width="40px" />
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue"
                                    HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" Height="30px" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>


        </ContentTemplate>
    </cc1:TabPanel>


    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
        <HeaderTemplate>[3B]內容</HeaderTemplate>
        <ContentTemplate>
            <div id="myDiv3">

                <asp:Button ID="btnBackTo1A" runat="server" Text="返回至清單" Width="143px" Height="35px" />
                <asp:HiddenField ID="hfRemark_ID" runat="server" />
                <asp:HiddenField ID="hfSQL_Detail" runat="server" />
                <asp:ObjectDataSource ID="ods_Detail" runat="server" SelectMethod="Search_Detail" TypeName="QualityControl.LabRecordA2_Setting_Remark_DAT" DataObjectTypeName="CompanyORMDB.SQLServer.QCdb01.LabRecordA2_Remark_DAT" InsertMethod="Insert" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfSQL_Detail" Name="fromSQL" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ListView ID="ListView1" runat="server" DataSourceID="ods_Detail"
                    EnableModelValidation="True" InsertItemPosition="LastItem">
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr>
                                <td>未傳回資料。</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <%--      <table runat="server" style="width: 80%">
            <tr runat="server" class="ListView1CSS ">--%>
                        <table runat="server" class="ListView1CSS">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server"
                                        border="1"
                                        style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif; width: 100%">
                                        <tr runat="server" style="background-color: #DCDCDC; color: #000000; font-size: larger;">
                                            <th runat="server" style="width: 60px"></th>
                                            <th runat="server" style="width: 130px"></th>
                                            <th runat="server">片語基本資料</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>

                            </tr>

                        </table>
                    </LayoutTemplate>

                    <EditItemTemplate>
                        <tr>
                            <td rowspan="20">
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                                <br />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                            </td>

                            <td>
                                <asp:Label ID="REMARK_IDLabelT" runat="server" Text="片語代號：" /></td>
                            <td>
                                <asp:HiddenField ID="REMARK_IDHiddenField" runat="server" Value='<%# Bind("REMARK_ID") %>' />
                                <asp:DropDownList ID="REMARK_IDDropDown" runat="server" />
                                <asp:TextBox ID="REMARK_IDTextBox" runat="server" CssClass="ListView1CSS_Lock" ReadOnly ="true" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="CONTEXTLabelT" runat="server" Text="片語內容：" /></td>
                            <td>
                                <asp:TextBox ID="CONTEXTTextBox" runat="server" Text='<%# Bind("CONTEXT")%>' CssClass="ListView1CSS_Input "
                                    TextMode="MultiLine" Rows="3" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_SEQLabelT" runat="server" Text="群組序號：" /></td>
                            <td>
                                <asp:TextBox ID="DISPLAY_SEQTextBox" runat="server" Text='<%# Bind("DISPLAY_SEQ") %>' CssClass="ListView1CSS_Input " /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_FLAGLabelT" runat="server" Text="是否顯示：" /></td>
                            <td>
                                <asp:HiddenField ID="DISPLAY_FLAGHiddenField" runat="server" Value='<%# Bind("DISPLAY_FLAG") %>' />
                                <asp:DropDownList ID="DISPLAY_FLAGDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="CHECK_ASSAY_ITEMLabelT" runat="server" Text="條件檢查：" /></td>
                            <td>
                                <asp:HiddenField ID="CHECK_ASSAY_ITEMHiddenField" runat="server" Value='<%# Bind("CHECK_ASSAY_ITEM") %>' />
                                <asp:DropDownList ID="CHECK_ASSAY_ITEMDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="EFF_FLAGLabelT" runat="server" Text="停用否：" /></td>
                            <td>
                                <asp:HiddenField ID="EFF_FLAGHiddenField" runat="server" Value='<%# Bind("EFF_FLAG") %>' />
                                <asp:DropDownList ID="EFF_FLAGDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="SAVE_INFOLabelT" runat="server" Text="存檔人員：" /></td>
                            <td>

                                <asp:TextBox ID="SAVE_OPERTextBox" runat="server"  CssClass="ListView1CSS_Lock" ReadOnly ="true"  Text='<%# Eval("SAVE_OPER") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="SAVE_DATELabelT" runat="server" Text="存檔日期：" /></td>
                            <td>

                                <asp:TextBox ID="SAVE_DATETextBox" runat="server"  CssClass="ListView1CSS_Lock" ReadOnly ="true"   Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1) %>' />
                            </td>
                        </tr>

                        <tr>
                            <td>訊息:</td>
                            <td colspan="20">
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate" />
                            </td>
                        </tr>

                    </EditItemTemplate>

                    <InsertItemTemplate>
                        <tr style="">
                            <td rowspan="20">
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                            </td>

                            <td>
                                <asp:Label ID="REMARK_IDLabelT" runat="server" Text="片語代號：" />
                            </td>
                            <td>
                                <asp:HiddenField ID="REMARK_IDHiddenField" runat="server" Value='<%# Bind("REMARK_ID")%>' />
                                <asp:DropDownList ID="REMARK_IDDropDown" runat="server" />
                                <asp:TextBox ID="REMARK_IDTextBox" runat="server" CssClass ="ListView1CSS_Lock" ReadOnly ="true"  />
                            </td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="CONTEXTLabelT" runat="server" Text="片語內容：" /></td>
                            <td>
                                <asp:TextBox ID="CONTEXTTextBox" runat="server" Text='<%# Bind("CONTEXT") %>' CssClass="ListView1CSS_Input "
                                    TextMode="MultiLine" Rows="3" /></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_SEQLabelT" runat="server" Text="群組序號：" /></td>
                            <td>
                                <asp:TextBox ID="DISPLAY_SEQTextBox" runat="server" Text='<%# Bind("DISPLAY_SEQ") %>' CssClass="ListView1CSS_Input " /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_FLAGLabelT" runat="server" Text="是否顯示：" /></td>
                            <td>
                                <asp:HiddenField ID="DISPLAY_FLAGHiddenField" runat="server" Value='<%# Bind("DISPLAY_FLAG") %>' />
                                <asp:DropDownList ID="DISPLAY_FLAGDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="CHECK_ASSAY_ITEMLabelT" runat="server" Text="條件檢查：" /></td>
                            <td>
                                <asp:HiddenField ID="CHECK_ASSAY_ITEMHiddenField" runat="server" Value='<%# Bind("CHECK_ASSAY_ITEM") %>' />
                                <asp:DropDownList ID="CHECK_ASSAY_ITEMDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="EFF_FLAGLabelT" runat="server" Text="停用否：" /></td>
                            <td>
                                <asp:HiddenField ID="EFF_FLAGHiddenField" runat="server" Value='<%# Bind("EFF_FLAG") %>' />
                                <asp:DropDownList ID="EFF_FLAGDropDown" runat="server" CssClass="ListView1CSS_Input" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="SAVE_OPERLabelT" runat="server" Text="存檔人員：" />
                            </td>
                            <td>
                                <asp:TextBox ID="SAVE_OPERTextBox" runat="server"  CssClass="ListView1CSS_Lock" ReadOnly ="true"  />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="SAVE_DATELabelT" runat="server" Text="存檔日期：" />
                            </td>
                            <td>
                                <asp:TextBox ID="SAVE_DATETextBox" runat="server" CssClass="ListView1CSS_Lock"  ReadOnly ="true"  />
                            </td>
                        </tr>

                        <tr>
                            <td>訊息:</td>
                            <td colspan="20">
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate" />
                            </td>
                        </tr>

                    </InsertItemTemplate>


                    <ItemTemplate>
                        <%--<tr style="background-color: #DCDCDC; color: #000000;">--%>
                        <tr>
                            <td rowspan="20">
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                            </td>
                            <td>
                                <asp:Label ID="REMARK_IDLabelT" runat="server" Text="片語代號：" />
                            </td>
                            <td>
                                <asp:Label ID="REMARK_IDLabel" runat="server" Text='<%# Eval("REMARK_ID")%>' /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="CONTEXTLabelT" runat="server" Text="片語內容：" /></td>
                            <td>
                                <asp:Label ID="CONTEXTLabel" runat="server" Text='<%# Eval("CONTEXT")%>' /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_SEQLabelT" runat="server" Text="群組序號：" /></td>
                            <td>
                                <asp:Label ID="DISPLAY_SEQLabel" runat="server" Text='<%# Eval("DISPLAY_SEQ") %>' /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="DISPLAY_FLAGLabelT" runat="server" Text="是否顯示：" /></td>
                            <td>
                                <asp:Label ID="DISPLAY_FLAGLabel" runat="server" Text='<%# FS_DropDownList_GetItem(Enum_DropDownList.檢驗項目基本檔_是否顯示, Eval("DISPLAY_FLAG"))%>' /></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="CHECK_ASSAY_ITEMLabelT" runat="server" Text="條件檢查：" /></td>
                            <td>
                                <asp:Label ID="CHECK_ASSAY_ITEMLabel" runat="server" Text='<%# FS_DropDownList_GetItem(Enum_DropDownList.片語基本檔_條件檢查, Eval("CHECK_ASSAY_ITEM"))%>' /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="EFF_FLAGLabelT" runat="server" Text="停用否：" /></td>
                            <td>
                                <asp:Label ID="EFF_FLAGLabel" runat="server" Text='<%# FS_DropDownList_GetItem (Enum_DropDownList.檢驗項目基本檔_停用否 , Eval("EFF_FLAG") )%>' /></td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="SAVE_OPERLabelT" runat="server" Text="存檔人員：" /></td>
                            <td>
                                <asp:Label ID="SAVE_OPERLabel" runat="server" Text='<%# Eval("SAVE_OPER") %>' />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="SAVE_DATELabelT" runat="server" Text="存檔日期：" /></td>
                            <td>
                                <asp:Label ID="SAVE_DATELabel" runat="server" Text='<%# FS_DATE_FORMAT(Eval("SAVE_DATE"), 1) %>' />
                            </td>
                        </tr>


                    </ItemTemplate>

                </asp:ListView>


            </div>

        </ContentTemplate>
    </cc1:TabPanel>



</cc1:TabContainer>