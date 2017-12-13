<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SMPStandardSampleEdit.ascx.vb" Inherits="SMP.SMPStandardSampleEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
            Width="5000px" AutoPostBack="True">
            <cc1:TabPanel runat="server" ID="TabPanel1">
                <HeaderTemplate>標準樣本編修</HeaderTemplate>
                <ContentTemplate>
                    <asp:ListView ID="ListView1" runat="server" DataKeyNames="SampleNumber"
                        DataSourceID="LDSSMPStandardSample" InsertItemPosition="LastItem">
                        <ItemTemplate>
                            <tr style="background-color: #DCDCDC; color: #000000;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="SampleNumberLabel" runat="server"
                                        Text='<%# Eval("SampleNumber") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                                <td>
                                    <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SiLabel" runat="server" Text='<%# Eval("Si") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MnLabel" runat="server" Text='<%# Eval("Mn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PLabel" runat="server" Text='<%# Eval("P") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CrLabel" runat="server" Text='<%# Eval("Cr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NiLabel" runat="server" Text='<%# Eval("Ni") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CuLabel" runat="server" Text='<%# Eval("Cu") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MoLabel" runat="server" Text='<%# Eval("Mo") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CoLabel" runat="server" Text='<%# Eval("Co") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ALLabel" runat="server" Text='<%# Eval("AL") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SnLabel" runat="server" Text='<%# Eval("Sn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PbLabel" runat="server" Text='<%# Eval("Pb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TiLabel" runat="server" Text='<%# Eval("Ti") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NbLabel" runat="server" Text='<%# Eval("Nb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="VLabel" runat="server" Text='<%# Eval("V") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="WLabel" runat="server" Text='<%# Eval("W") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NLabel" runat="server" Text='<%# Eval("N") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BLabel" runat="server" Text='<%# Eval("B") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CaLabel" runat="server" Text='<%# Eval("Ca") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MgLabel" runat="server" Text='<%# Eval("Mg") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="AsLabel" runat="server" Text='<%# Eval("As") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BiLabel" runat="server" Text='<%# Eval("Bi") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SbLabel" runat="server" Text='<%# Eval("Sb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZnLabel" runat="server" Text='<%# Eval("Zn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZrLabel" runat="server" Text='<%# Eval("Zr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyUserLabel" runat="server"
                                        Text='<%# Eval("ModifyUser") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyDateLabel" runat="server"
                                        Text='<%# Eval("ModifyDate","{0:d}") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #FFF8DC;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="SampleNumberLabel" runat="server"
                                        Text='<%# Eval("SampleNumber") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                                <td>
                                    <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SiLabel" runat="server" Text='<%# Eval("Si") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MnLabel" runat="server" Text='<%# Eval("Mn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PLabel" runat="server" Text='<%# Eval("P") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CrLabel" runat="server" Text='<%# Eval("Cr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NiLabel" runat="server" Text='<%# Eval("Ni") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CuLabel" runat="server" Text='<%# Eval("Cu") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MoLabel" runat="server" Text='<%# Eval("Mo") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CoLabel" runat="server" Text='<%# Eval("Co") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ALLabel" runat="server" Text='<%# Eval("AL") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SnLabel" runat="server" Text='<%# Eval("Sn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PbLabel" runat="server" Text='<%# Eval("Pb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TiLabel" runat="server" Text='<%# Eval("Ti") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NbLabel" runat="server" Text='<%# Eval("Nb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="VLabel" runat="server" Text='<%# Eval("V") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="WLabel" runat="server" Text='<%# Eval("W") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NLabel" runat="server" Text='<%# Eval("N") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BLabel" runat="server" Text='<%# Eval("B") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CaLabel" runat="server" Text='<%# Eval("Ca") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MgLabel" runat="server" Text='<%# Eval("Mg") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="AsLabel" runat="server" Text='<%# Eval("As") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BiLabel" runat="server" Text='<%# Eval("Bi") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SbLabel" runat="server" Text='<%# Eval("Sb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZnLabel" runat="server" Text='<%# Eval("Zn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZrLabel" runat="server" Text='<%# Eval("Zr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyUserLabel" runat="server"
                                        Text='<%# Eval("ModifyUser") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyDateLabel" runat="server"
                                        Text='<%# Eval("ModifyDate","{0:d}") %>' />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server"
                                style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
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
                                    <asp:TextBox ID="SampleNumberTextBox" runat="server"
                                        Text='<%# Bind("SampleNumber") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Bind("IsNOUse") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SiTextBox" runat="server" Text='<%# Bind("Si") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MnTextBox" runat="server" Text='<%# Bind("Mn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CrTextBox" runat="server" Text='<%# Bind("Cr") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NiTextBox" runat="server" Text='<%# Bind("Ni") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CuTextBox" runat="server" Text='<%# Bind("Cu") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MoTextBox" runat="server" Text='<%# Bind("Mo") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CoTextBox" runat="server" Text='<%# Bind("Co") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ALTextBox" runat="server" Text='<%# Bind("AL") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SnTextBox" runat="server" Text='<%# Bind("Sn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="PbTextBox" runat="server" Text='<%# Bind("Pb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="TiTextBox" runat="server" Text='<%# Bind("Ti") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NbTextBox" runat="server" Text='<%# Bind("Nb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="VTextBox" runat="server" Text='<%# Bind("V") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="WTextBox" runat="server" Text='<%# Bind("W") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NTextBox" runat="server" Text='<%# Bind("N") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="BTextBox" runat="server" Text='<%# Bind("B") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CaTextBox" runat="server" Text='<%# Bind("Ca") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MgTextBox" runat="server" Text='<%# Bind("Mg") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="AsTextBox" runat="server" Text='<%# Bind("As") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="BiTextBox" runat="server" Text='<%# Bind("Bi") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SbTextBox" runat="server" Text='<%# Bind("Sb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ZnTextBox" runat="server" Text='<%# Bind("Zn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ZrTextBox" runat="server" Text='<%# Bind("Zr") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta")%>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyUserTextBox" runat="server" Enabled="false"
                                        Text='<%# Bind("ModifyUser") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyDateTextBox" runat="server" Enabled="false"
                                        Text='<%# Bind("ModifyDate","{0:d}") %>' />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="ModifyDateTextBox" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="itemPlaceholderContainer" runat="server" border="1"
                                            style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                <th runat="server"></th>
                                                <th runat="server">樣本編號</th>
                                                <th id="Th1" runat="server">是否停用</th>
                                                <th runat="server">C</th>
                                                <th runat="server">Si</th>
                                                <th runat="server">Mn</th>
                                                <th runat="server">P</th>
                                                <th runat="server">S</th>
                                                <th runat="server">Cr</th>
                                                <th runat="server">Ni</th>
                                                <th runat="server">Cu</th>
                                                <th runat="server">Mo</th>
                                                <th runat="server">Co</th>
                                                <th runat="server">AL</th>
                                                <th runat="server">Sn</th>
                                                <th runat="server">Pb</th>
                                                <th runat="server">Ti</th>
                                                <th runat="server">Nb</th>
                                                <th runat="server">V</th>
                                                <th runat="server">W</th>
                                                <th runat="server">N</th>
                                                <th runat="server">B</th>
                                                <th runat="server">Ca</th>
                                                <th runat="server">Mg</th>
                                                <th runat="server">As</th>
                                                <th runat="server">Bi</th>
                                                <th runat="server">Sb</th>
                                                <th runat="server">Zn</th>
                                                <th runat="server">Zr</th>
                                                <th runat="server">Fe</th>
                                                <th runat="server">Ta</th>
                                                <th runat="server">修改者</th>
                                                <th runat="server">修改日期</th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server"
                                        style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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
                            <tr style="background-color: #008A8C; color: #FFFFFF;">
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                                </td>
                                <td>
                                    <asp:Label ID="SampleNumberLabel1" runat="server"
                                        Text='<%# Eval("SampleNumber") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Bind("IsNOUse") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SiTextBox" runat="server" Text='<%# Bind("Si") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MnTextBox" runat="server" Text='<%# Bind("Mn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CrTextBox" runat="server" Text='<%# Bind("Cr") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NiTextBox" runat="server" Text='<%# Bind("Ni") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CuTextBox" runat="server" Text='<%# Bind("Cu") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MoTextBox" runat="server" Text='<%# Bind("Mo") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CoTextBox" runat="server" Text='<%# Bind("Co") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ALTextBox" runat="server" Text='<%# Bind("AL") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SnTextBox" runat="server" Text='<%# Bind("Sn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="PbTextBox" runat="server" Text='<%# Bind("Pb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="TiTextBox" runat="server" Text='<%# Bind("Ti") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NbTextBox" runat="server" Text='<%# Bind("Nb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="VTextBox" runat="server" Text='<%# Bind("V") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="WTextBox" runat="server" Text='<%# Bind("W") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="NTextBox" runat="server" Text='<%# Bind("N") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="BTextBox" runat="server" Text='<%# Bind("B") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CaTextBox" runat="server" Text='<%# Bind("Ca") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="MgTextBox" runat="server" Text='<%# Bind("Mg") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="AsTextBox" runat="server" Text='<%# Bind("As") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="BiTextBox" runat="server" Text='<%# Bind("Bi") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SbTextBox" runat="server" Text='<%# Bind("Sb") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ZnTextBox" runat="server" Text='<%# Bind("Zn") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ZrTextBox" runat="server" Text='<%# Bind("Zr") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta")%>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyUserTextBox" runat="server"
                                        Text='<%# Bind("ModifyUser") %>' Enabled="false" />
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyDateTextBox" runat="server"
                                        Text='<%# Bind("ModifyDate","{0:d}") %>' Enabled="false" />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <SelectedItemTemplate>
                            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="SampleNumberLabel" runat="server"
                                        Text='<%# Eval("SampleNumber") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                                <td>
                                    <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SiLabel" runat="server" Text='<%# Eval("Si") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MnLabel" runat="server" Text='<%# Eval("Mn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PLabel" runat="server" Text='<%# Eval("P") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SLabel" runat="server" Text='<%# Eval("S") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CrLabel" runat="server" Text='<%# Eval("Cr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NiLabel" runat="server" Text='<%# Eval("Ni") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CuLabel" runat="server" Text='<%# Eval("Cu") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MoLabel" runat="server" Text='<%# Eval("Mo") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CoLabel" runat="server" Text='<%# Eval("Co") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ALLabel" runat="server" Text='<%# Eval("AL") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SnLabel" runat="server" Text='<%# Eval("Sn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PbLabel" runat="server" Text='<%# Eval("Pb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TiLabel" runat="server" Text='<%# Eval("Ti") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NbLabel" runat="server" Text='<%# Eval("Nb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="VLabel" runat="server" Text='<%# Eval("V") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="WLabel" runat="server" Text='<%# Eval("W") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="NLabel" runat="server" Text='<%# Eval("N") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BLabel" runat="server" Text='<%# Eval("B") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="CaLabel" runat="server" Text='<%# Eval("Ca") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MgLabel" runat="server" Text='<%# Eval("Mg") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="AsLabel" runat="server" Text='<%# Eval("As") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BiLabel" runat="server" Text='<%# Eval("Bi") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="SbLabel" runat="server" Text='<%# Eval("Sb") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZnLabel" runat="server" Text='<%# Eval("Zn") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ZrLabel" runat="server" Text='<%# Eval("Zr") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyUserLabel" runat="server"
                                        Text='<%# Eval("ModifyUser") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ModifyDateLabel" runat="server"
                                        Text='<%# Eval("ModifyDate","{0:d}") %>' />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <asp:LinqDataSource ID="LDSSMPStandardSample" runat="server"
                        ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True"
                        EnableInsert="True" EnableUpdate="True" TableName="SMPStandardSample">
                    </asp:LinqDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" ID="TabPanel2">
                <HeaderTemplate>Method編修</HeaderTemplate>
                <ContentTemplate>
                    <asp:ListView ID="ListView2" runat="server" DataKeyNames="MethodNumber"
                        DataSourceID="LDSSMPMethod" InsertItemPosition="LastItem">
                        <ItemTemplate>
                            <tr style="background-color: #DCDCDC; color: #000000;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="MethodNumberLabel" runat="server"
                                        Text='<%# Eval("MethodNumber") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #FFF8DC;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="MethodNumberLabel" runat="server"
                                        Text='<%# Eval("MethodNumber") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server"
                                style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
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
                                    <asp:TextBox ID="MethodNumberTextBox" runat="server"
                                        Text='<%# Bind("MethodNumber") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Bind("IsNOUse") %>' />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="itemPlaceholderContainer" runat="server" border="1"
                                            style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                <th runat="server"></th>
                                                <th runat="server">Method編號</th>
                                                <th runat="server">備註1</th>
                                                <th runat="server">是否停用</th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server"
                                        style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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
                            <tr style="background-color: #008A8C; color: #FFFFFF;">
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                                </td>
                                <td>
                                    <asp:Label ID="MethodNumberLabel1" runat="server"
                                        Text='<%# Eval("MethodNumber") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="Memo1TextBox" runat="server" Text='<%# Bind("Memo1") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Bind("IsNOUse") %>' />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <SelectedItemTemplate>
                            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                                </td>
                                <td>
                                    <asp:Label ID="MethodNumberLabel" runat="server"
                                        Text='<%# Eval("MethodNumber") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Memo1Label" runat="server" Text='<%# Eval("Memo1") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsNOUseCheckBox" runat="server"
                                        Checked='<%# Eval("IsNOUse") %>' Enabled="false" />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <asp:LinqDataSource ID="LDSSMPMethod" runat="server"
                        ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True"
                        EnableInsert="True" EnableUpdate="True" TableName="SMPMethod">
                    </asp:LinqDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server">
                <HeaderTemplate>Method對樣本分群及排序</HeaderTemplate>
                <ContentTemplate>
                    <table style="width: 626px; height: 377px;">
                        <tr>
                            <td class="style1">METHOD:<br />
                                <asp:ListBox ID="ListBox1" runat="server" Rows="10"
                                    Width="120px" DataSourceID="LDSMethod" DataTextField="MethodNumber"
                                    DataValueField="MethodNumber" AutoPostBack="True"></asp:ListBox>
                                <asp:LinqDataSource ID="LDSMethod" runat="server"
                                    ContextTypeName="CompanyLINQDB.SMPDataContext" OrderBy="MethodNumber"
                                    TableName="SMPMethod">
                                </asp:LinqDataSource>
                            </td>
                            <td class="style1">標準樣本:<br />
                                <asp:ListBox ID="ListBox2" runat="server" Rows="10"
                                    Width="120px" DataSourceID="LDSStandSample" DataTextField="SampleNumber"
                                    DataValueField="SampleNumber" AutoPostBack="True"></asp:ListBox>
                                <asp:LinqDataSource ID="LDSStandSample" runat="server"
                                    ContextTypeName="CompanyLINQDB.SMPDataContext" OrderBy="SampleNumber"
                                    TableName="SMPStandardSample">
                                </asp:LinqDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnAddItem" runat="server" Text="加入" Width="60px"
                                    Enabled="False" />
                                <asp:Button ID="btnDelete" runat="server" Text="移除" Width="60px"
                                    Enabled="False" />
                                <asp:Button ID="btnUPPriority" runat="server" Text="提升優先順序" Enabled="False" />
                                <asp:Button ID="btnDownPriority" runat="server" Text="降低優先順序" Enabled="False" />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="SMPMethodNumber,SMPSampleNumber,SortOrder"
                                    DataSourceID="LDSEditResult" Width="600px">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="SMPMethodNumber" HeaderText="Method編號"
                                            ReadOnly="True" SortExpression="SMPMethodNumber" />
                                        <asp:BoundField DataField="SMPSampleNumber" HeaderText="樣本編號" ReadOnly="True"
                                            SortExpression="SMPSampleNumber" />
                                        <asp:BoundField DataField="SortOrder" DataFormatString="{0:n0}"
                                            HeaderText="優先順序" ReadOnly="True" SortExpression="SortOrder" />
                                        <asp:BoundField DataField="IsNOUseString" HeaderText="是否停用中"
                                            SortExpression="IsNOUseString" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#CCFFFF" />
                                </asp:GridView>
                                <asp:LinqDataSource ID="LDSEditResult" runat="server"
                                    ContextTypeName="CompanyLINQDB.SMPDataContext"
                                    OrderBy="SortOrder"
                                    TableName="SMPMethodToSMPStandardSample">
                                </asp:LinqDataSource>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>

    </ContentTemplate>
</asp:UpdatePanel>
