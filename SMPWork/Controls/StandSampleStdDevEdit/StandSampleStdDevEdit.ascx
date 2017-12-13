<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StandSampleStdDevEdit.ascx.vb" Inherits="SMPWork.StandSampleStdDevEdit" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .auto-style2 {
        width: 186px;
    }

    .auto-style3 {
        width: 186px;
        height: 20px;
    }

    .auto-style4 {
        height: 20px;
    }

    .auto-style5 {
        height: 23px;
    }

    .CssHtmlTable {
        width: 100%;
        border-collapse: collapse;
    }

        .CssHtmlTable tr td {
            border: 2px solid #A9A9A9;
            padding: 2px;
        }

    .CssHtmlTable_Textbox {
        width: 35px;
    }
</style>

<p />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">標準樣品代號</td>
                <td>
                    <asp:TextBox ID="tbQuerySampleID_EachOneRecord" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbShowLastNew" runat="server" Text="只顯示最新資料" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnQuery_EachOneRecord" runat="server" Text="查詢" Height="36px" Width="94px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="新增" Height="36px" Width="94px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:HiddenField ID="hfSQL_EachOneRecord" runat="server" />
                    <asp:HiddenField ID="hfQueryDate" runat="server" />
                    <asp:ObjectDataSource ID="ODS_EachOneRecord" runat="server" SelectMethod="Search_EachOneRecord" TypeName="SMPWork.StandSampleStdDevEdit" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfSQL_EachOneRecord" Name="fromSQL" PropertyName="Value" Type="String" />
                            <asp:ControlParameter ControlID="hfQueryDate" Name="fromQueryDate" PropertyName="Value" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:HiddenField ID="hfSQL_LastNewRecord" runat="server" />

                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView_EachOneRecord" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_EachOneRecord" EnableModelValidation="True" AllowPaging="True" PageSize="100" style="margin-top: 0px">
            <Columns>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button ID="btnEachOneRecord_Edit" runat="server" Text="編輯" ToolTip ='<%# Eval("SampleID") & "|" & Eval("SampleVer")%>'  OnClick="btnEachOneRecord_Edit_Click" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="SampleID" HeaderText="樣品編號" SortExpression="SampleID" />
                <asp:BoundField DataField="SampleVer" HeaderText="版本" SortExpression="SampleVer" />
                <asp:BoundField DataField="SampleKind" HeaderText="類型" SortExpression="SampleKind" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="ModOperator" HeaderText="存檔人員" SortExpression="ModOperator" />
                <asp:BoundField DataField="ModDate" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}&nbsp;" HeaderText="存檔時間" SortExpression="ModDate" />
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Si" HeaderText="Si" SortExpression="Si" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Mn" HeaderText="Mn" SortExpression="Mn" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Cr" HeaderText="Cr" SortExpression="Cr" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Ni" HeaderText="Ni" SortExpression="Ni" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Cu" HeaderText="Cu" SortExpression="Cu" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Mo" HeaderText="Mo" SortExpression="Mo" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Co" HeaderText="Co" SortExpression="Co" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Sn" HeaderText="Sn" SortExpression="Sn" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Pb" HeaderText="Pb" SortExpression="Pb" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Ti" HeaderText="Ti" SortExpression="Ti" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Nb" HeaderText="Nb" SortExpression="Nb" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" DataFormatString="{0:G}&nbsp;" />
                <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" DataFormatString="{0:G}&nbsp;" />
            </Columns>
        </asp:GridView>
        <br />

    </asp:View>


    <asp:View ID="View2" runat="server">
        &nbsp&nbsp<p />



        <table class="CssHtmlTable">
            <tr>
                <td colspan="30">
                    <asp:Label ID="Label1" runat="server" Text="樣品編號：" /><asp:TextBox ID="tbSampleID" runat="server" />
                    <br />
                </td>
            </tr>
            <tr>
                <td>類型</td>
                <td>C </td>
                <td>Si</td>
                <td>Mn</td>
                <td>P</td>
                <td>S</td>
                <td>Cr</td>
                <td>Ni</td>
                <td>Cu</td>
                <td>Mo</td>
                <td>Co</td>
                <td>AL</td>
                <td>Sn</td>
                <td>Pb</td>
                <td>Ti</td>
                <td>Nb</td>
                <td>V</td>
                <td>W</td>
                <td>N2</td>
                <td>O2</td>
                <td>B</td>
                <td>Ca</td>
                <td>Mg</td>
                <td>As</td>
                <td>Bi</td>
                <td>Sb</td>
                <td>Zn</td>
                <td>Zr</td>
                <td>Fe</td>
                <td>Ta</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbSampleKind_Mean" runat="server" BackColor="#BFBFBF" Enabled="False" ForeColor="Black"  CssClass="CssHtmlTable_Textbox">Mean</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbItemC_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSi_Mean" runat="server" CssClass="CssHtmlTable_Textbox"/></td>
                <td>
                    <asp:TextBox ID="tbItemMn_Mean" runat="server" CssClass="CssHtmlTable_Textbox"   /></td>
                <td>
                    <asp:TextBox ID="tbItemP_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemS_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCr_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemNi_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCu_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemMo_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCo_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemAL_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSn_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemPb_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemTi_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemNb_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemV_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemW_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemN2_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemO2_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemB_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCa_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemMg_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemAs_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemBi_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSb_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemZn_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemZr_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemFe_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemTa_Mean" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbSampleKind_Std" runat="server" BackColor="#BFBFBF" Enabled="False" ForeColor="Black"  CssClass="CssHtmlTable_Textbox">Std</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbItemC_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSi_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemMn_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemP_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemS_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCr_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemNi_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCu_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemMo_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCo_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemAL_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSn_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemPb_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemTi_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemNb_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemV_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemW_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemN2_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemO2_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemB_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemCa_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemMg_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemAs_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemBi_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemSb_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemZn_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemZr_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemFe_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
                <td>
                    <asp:TextBox ID="tbItemTa_Std" runat="server" CssClass="CssHtmlTable_Textbox" /></td>
            </tr>
            <tr>
                <td colspan="30">
                    <asp:Label ID="Label2" runat="server" Text="訊息：" />
                    <asp:TextBox ID="tbMsg" runat="server"  BackColor="#BFBFBF" Enabled="False" ForeColor="Black" Width="80%" />
                </td>
            </tr>
            <tr>
                <td colspan="30">
                    <asp:Button ID="btnSave_OneItemAllRecord" runat="server" Height="36px" Text="存檔" Width="94px" />
                    &nbsp&nbsp<asp:Button ID="btnCancel_OneItemAllRecord" runat="server" Height="36px" Text="取消" Width="94px" />
                </td>
            </tr>
        </table>

    </asp:View>
</asp:MultiView>

