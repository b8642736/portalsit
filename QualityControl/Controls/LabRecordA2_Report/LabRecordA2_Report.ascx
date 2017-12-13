<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Report.ascx.vb" Inherits="QualityControl.LabRecordA2_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />
<link href="CSS/LabRecordA2_Report_CSS.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .styleTableEdit {
        width: 90%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
    }

        .styleTableEdit TD {
            border-width: 2px;
            border-style: dotted;
            border-collapse: collapse;
            border-color: #9b9898;
            width: 30%;
            text-align: center;
            padding: 7px;
        }

    .btnKeyInUnit {
        font-size: Large;
        width: 250px;
        height: 100px;
    }


    .styleTableEdit2 {
        width: 90%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
        padding: 10px;
    }

    .styleTableEdit2_TD2 {
        height: 30px;
        width: 25%;
        padding: 10px;
    }

    .styleTableEdit2 TD {
        border-width: 0.5px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
    }




    .styleTableEdit3 {
        width: 90%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
        padding: 10px;
    }

    .styleTableEdit3_TD2 {
        height: 25px;
        width: 25%;
        padding: 10px;
    }

    .styleTableEdit3_TD3 {
        width: 20%;
    }

    .styleTableEdit3 TD {
        border-width: 0.5px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #9b9898;
        /*padding: 10px;*/
    }


    #myDiv1A {
        width: 40%;
        float: left;
    }

    #myDiv1B {
        width: 5px;
        float: left;
    }

    #myDiv2 {
        width: 55%;
        float: left;
    }

    .styleButton1 {
        Width: 150px;
        Height: 35px;
    }

    .styleButton2 {
        Width: 250px;
        Height: 35px;
    }


    .MyCalendar .ajax__calendar_container {
        border: 1px solid #000000;
        background-color: white;
        color: black;
    }

    .MyCalendar .ajax__calendar_other .ajax__calendar_day,
    .MyCalendar .ajax__calendar_other .ajax__calendar_year {
        /*上下年月日 預設*/
        /*color: #817c7c;*/
    }

    .MyCalendar .ajax__calendar_hover .ajax__calendar_day,
    .MyCalendar .ajax__calendar_hover .ajax__calendar_month,
    .MyCalendar .ajax__calendar_hover .ajax__calendar_year {
        /*上下年月日 滑鼠移上去*/
        /*color: #9b9898;*/
    }

    .MyCalendar .ajax__calendar_active .ajax__calendar_day,
    .MyCalendar .ajax__calendar_active .ajax__calendar_month,
    .MyCalendar .ajax__calendar_active .ajax__calendar_year {
        /*今天年月日*/
        /*color: blue;*/
        /*font-weight: bold;*/
    }
</style>

<br />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">

        <br />

        <br />
        <table id="tableEdit1" class="styleTableEdit" runat="server">

            <tr>
                <td style="text-align: left;" colspan ="3">
                    <asp:Label ID="Label1" runat="server" Text="【請點選輸入單位】" Font-Size="X-Large" />
                </td>
            </tr>

            <%--            <tr>
                <td>
                    <asp:Button ID="btnKeyInUnit_C" runat="server" Text="品保處" CssClass="btnKeyInUnit " /></td>
                <td>
                    <asp:Button ID="btnKeyInUnit_D" runat="server" Text="煉鋼廠" CssClass="btnKeyInUnit " /></td>
                <td>
                    <asp:Button ID="btnKeyInUnit_E" runat="server" Text="軋鋼廠" CssClass="btnKeyInUnit " /></td>
            </tr>--%>
        </table>


    </asp:View>

    <asp:View ID="View2" runat="server">
        <asp:Button ID="btnKeyInUnit_GoBack" runat="server" Text="【返回輸入單位】" CssClass="styleButton2" Font-Size="Large" />

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
            Width="100%" Height="500px" CssClass="ajax__myTab">
            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>[1A]清單</HeaderTemplate>
                <ContentTemplate>


                    <div id="myDiv1A">
                        <table id="tableEdit2" class="styleTableEdit2">
                            <tr>
                                <td class="styleTableEdit2_TD2">
                                    <asp:Label ID="Label1a0" runat="server" Text="新增：" /></td>
                                <td>
                                    <asp:Button ID="btnInserNewRecord1" runat="server" Text="新增一筆內容" Width="143px" Height="35px" /></td>
                            </tr>
                            <tr>
                                <td class="styleTableEdit2_TD2">輸入單位：</td>
                                <td>
                                    <asp:Label ID="lbSample_Unit_Name" runat="server" Text="Label" Font-Size="X-Large" />
                                    &nbsp&nbsp&nbsp
                    
                    <asp:HiddenField ID="hfSample_Unit" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td class="styleTableEdit2_TD2">檢驗日期：</td>
                                <td>

                                    <asp:TextBox ID="tbStartDate" runat="server" Width="90px" Style="z-index: 1" />
                                    <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" TargetControlID="tbStartDate" Format="yyyy/MM/dd" Enabled="True" CssClass="MyCalendar">
                                    </cc1:CalendarExtender>
                                    <asp:Label ID="Label4" runat="server" Text=" ~ " />
                                    <asp:TextBox ID="tbEndDate" runat="server" Width="90px" />
                                    <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" TargetControlID="tbEndDate" Format="yyyy/MM/dd" Enabled="True" CssClass="MyCalendar">
                                    </cc1:CalendarExtender>

                                </td>
                            </tr>

                            <tr>
                                <td class="styleTableEdit2_TD2">
                                    <asp:Label ID="lbhfSample_Kind_Name_Query" runat="server" Text="XXXX"></asp:Label>：
                                </td>
                                <td>
                                    <asp:TextBox ID="tbSAMPLE_ID" runat="server" /><br />
                                    &nbsp&nbsp(兩個以上以 &#39;,&#39; 分隔)
                                </td>
                            </tr>
                            <tr>
                                <td class="styleTableEdit2_TD2">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="styleTableEdit2_TD2"></td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="48px" Width="168px" />
                                    <asp:HiddenField ID="hfSQL_Master" runat="server" />
                                    <asp:HiddenField ID="hfSample_Kind_ID" runat="server" />
                                    <asp:HiddenField ID="hfSample_Kind_Name" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="myDiv1B">&nbsp;</div>

                    <div id="myDiv2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize='<%# GridView1_PageSize() %>' CssClass="GridView1_CSS" EnableModelValidation="True"
                            DataKeyNames="SAMPLE_UNIT,SAMPLE_DATE,SAMPLE_ID">
                            <Columns>
                                <asp:CommandField ButtonType="Button" SelectText="編輯" ShowSelectButton="True">
                                    <ItemStyle Width="4%" />
                                </asp:CommandField>

                                <asp:TemplateField HeaderText="檢驗日期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label099" runat="server" Visible="false" />
                                        <asp:Label ID="Label0" runat="server" Text='<%# FS_Convert_Date_YYYYMMDD(Eval("SAMPLE_DATE")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="XXXX">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("SAMPLE_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="檢驗項目">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# showAssayInfo(Eval("ASSAY_ID"))%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="24%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="檢驗結果">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("RESULT_VALUE")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="24%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="存檔資訊">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# showSaveInfo(Eval("SAVE_OPER"), Eval("SAVE_DATE"))%>' Font-Size ="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                            <EmptyDataTemplate>找不到符合條件的資料，請重新輸入。</EmptyDataTemplate>

                            <HeaderStyle CssClass="GridView1_CSS_HeaderStyle" />
                            <PagerStyle CssClass="GridView1_CSS_PagerStyle" />
                        </asp:GridView>

                    </div>

                </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                <HeaderTemplate>[1B]內容</HeaderTemplate>
                <ContentTemplate>
                    <div id="myDiv3">

                        <asp:Button ID="btnBackTo1A" runat="server" Text="返回至清單" CssClass="styleButton1" />
                        <asp:HiddenField ID="hfDetailPK" runat="server" />
                        <asp:HiddenField ID="hfDetailDoModeIsEdit" runat="server" />
                        <asp:HiddenField ID="hfSQL_Detail" runat="server" />


                        <table id="tableEdit3" class="styleTableEdit3" runat="server">
                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server"></td>
                                <td colspan="2" runat="server">
                                    <asp:Button ID="btnEdit_Save" runat="server" CssClass="styleButton1" Text="儲存" />
                                    &nbsp&nbsp
                                    <asp:Button ID="btnEdit_Cancel" runat="server" CssClass="styleButton1" Text="清除" />

                                </td>
                            </tr>
                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server">訊息：</td>
                                <td colspan="2" runat="server">
                                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                                      ForeColor="Red" />
                                </td>
                            </tr>


                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server">檢驗日期：</td>
                                <td colspan="2" runat="server">
                                    <asp:TextBox ID="editSAMPLE_DATETextBox" runat="server" />
                                    <cc1:CalendarExtender ID="editSAMPLE_DATETextBox_CalendarExtender" runat="server" TargetControlID="editSAMPLE_DATETextBox" Format="yyyy/MM/dd" Enabled="True" CssClass="MyCalendar">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server">
                                    <asp:Label ID="lbhfSample_Kind_Name_Edit" runat="server" Text="XXXX"></asp:Label>：
                                </td>
                                <td colspan="2" runat="server">
                                    <asp:TextBox ID="editSAMPLE_IDTextBox" runat="server" />
                                </td>
                            </tr>
                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server">存檔資訊：</td>
                                <td colspan="2" runat="server">
                                    <asp:TextBox ID="editSAVE_INFORMATTextBox" runat="server" TextMode="MultiLine" Style="overflow: hidden" Height="50px" />
                                </td>
                            </tr>
                            <tr runat="server">
                                <td class="styleTableEdit3_TD2" runat="server"></td>
                                <td class="styleTableEdit3_TD3" runat="server">檢驗項目：</td>
                                <td runat="server"></td>
                            </tr>

                        </table>



                    </div>
                </ContentTemplate>
            </cc1:TabPanel>


        </cc1:TabContainer>


    </asp:View>
</asp:MultiView>

