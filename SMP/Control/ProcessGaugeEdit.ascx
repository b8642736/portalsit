<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProcessGaugeEdit.ascx.vb" Inherits="SMP.ProcessGaugeEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="GridViewStyleSheet.css" rel="stylesheet" type="text/css" />
<link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
<table style="width: 100%;">
    <tr>
        <td>
            <span lang="zh-tw">鋼種:</span></td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>
            <span lang="zh-tw">材質:</span></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">站別:</span></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <span lang="zh-tw">序號:</span></td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">上下限:</span></td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="H">上限</asp:ListItem>
                <asp:ListItem Value="L">下限</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="100px" />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" AllowPaging="True"
    DataKeyNames="鋼種,材質,站別,序號,上下限" DataSourceID="LDSEditDataSource"
    Width="750px">
    <PagerSettings PageButtonCount="30" Position="Top" />
    <EditItemTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">鋼種:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="鋼種Label1" runat="server" Text='<%# Eval("鋼種") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">材質:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="材質Label1" runat="server" Text='<%# Eval("材質") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">站別:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="站別Label1" runat="server" Text='<%# Eval("站別") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">序號:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="序號Label1" runat="server" Text='<%# Eval("序號") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">上下限:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="上下限Label1" runat="server" Text='<%# Eval("上下限") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">DF:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="DFTextBox" runat="server" Text='<%# Bind("DF") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">MD30:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MD30TextBox" runat="server" Text='<%# Bind("MD30") %>' />
                </td>
                <td class="TableEditColumn1">C<span lang="zh-tw">:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Si:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SiTextBox" runat="server" Text='<%# Bind("Si") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mn:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MnTextBox" runat="server" Text='<%# Bind("Mn") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">P<span lang="zh-tw">:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Cr:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CrTextBox" runat="server" Text='<%# Bind("Cr") %>' />
                </td>
                <td class="TableEditColumn1">N<span lang="zh-tw">i:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="NiTextBox" runat="server" Text='<%# Bind("Ni") %>' />
                </td>
                <td class="TableEditColumn1">C<span lang="zh-tw">u:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CuTextBox" runat="server" Text='<%# Bind("Cu") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mo:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MoTextBox" runat="server" Text='<%# Bind("Mo") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Co:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CoTextBox" runat="server" Text='<%# Bind("Co") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">AL:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ALTextBox" runat="server" Text='<%# Bind("AL") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sn:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SnTextBox" runat="server" Text='<%# Bind("Sn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Pb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="PbTextBox" runat="server" Text='<%# Bind("Pb") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ti</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="TiTextBox" runat="server" Text='<%# Bind("Ti") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Nb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="NbTextBox" runat="server" Text='<%# Bind("Nb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">V:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="VTextBox" runat="server" Text='<%# Bind("V") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">W:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="WTextBox" runat="server" Text='<%# Bind("W") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">H2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="H2TextBox" runat="server" Text='<%# Bind("H2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">B:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="BTextBox" runat="server" Text='<%# Bind("B") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ca:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CaTextBox" runat="server" Text='<%# Bind("Ca") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mg:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MgTextBox" runat="server" Text='<%# Bind("Mg") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Fe:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N1:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="N1TextBox" runat="server" Text='<%# Bind("N1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O1:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="O1TextBox" runat="server" Text='<%# Bind("O1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O2</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="C2TextBox" runat="server" Text='<%# Bind("C2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="S2TextBox" runat="server" Text='<%# Bind("S2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">As:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="AsTextBox" runat="server" Text='<%# Bind("As") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Bi:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="BiTextBox" runat="server" Text='<%# Bind("Bi") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SbTextBox" runat="server" Text='<%# Bind("Sb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zn</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ZnTextBox" runat="server" Text='<%# Bind("Zn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zr:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ZrTextBox" runat="server" Text='<%# Bind("Zr") %>' />
                </td>
            </tr>

            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">GP:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="GPTextBox" runat="server" Text='<%# Bind("GP") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ta:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta") %>' />
                </td>

                <td class="TableEditColumn1">
                    <span lang="zh-tw">CAndN:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CAndNTextBox" runat="server" Text='<%# Bind("CAndN") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">NbAndTa:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="NbAndTaTextBox" runat="server" Text='<%# Bind("NbAndTa") %>' />
                </td>

                <td class="TableEditColumn1">
                    <span lang="zh-tw"></span></td>
                <td class="TableEditColumn2"></td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw"></span></td>
                <td class="TableEditColumn2"></td>
            </tr>

        </table>
        最後更新時間:
        <asp:TextBox ID="最後更新時間TextBox" runat="server" Enabled="False"
            Text='<%# Bind("最後更新時間") %>' />
        <span lang="zh-tw">(儲存時會更新時間)</span><br />
        更新來源IP:
        <asp:TextBox ID="更新來源IPTextBox" runat="server" Enabled="False"
            Text='<%# Bind("更新來源IP") %>' />
        <br />
        <span lang="zh-tw">更新者:</span><asp:TextBox ID="更新者TextBox" runat="server"
            Enabled="False" Text='<%# Bind("更新者") %>'></asp:TextBox>
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True"
            CommandName="Update" Text="更新" OnClick="UpdateButton_Click" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server"
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="TableEditColumn1">鋼種:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="?????"
                        TargetControlID="鋼種TextBox">
                    </cc1:MaskedEditExtender>
                    <asp:CustomValidator ID="CustomValidatorAllPK" runat="server"
                        ControlToValidate="鋼種TextBox" ErrorMessage="CustomValidator"
                        OnServerValidate="CustomValidatorAllPK_ServerValidate">鋼種+材質+站別+序號+上下限 不可重覆!</asp:CustomValidator>
                </td>
                <td class="TableEditColumn1">材質:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="????"
                        TargetControlID="材質TextBox">
                    </cc1:MaskedEditExtender>
                </td>
                <td class="TableEditColumn1">站別:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="站別TextBox" runat="server" Text='<%# Bind("站別") %>' />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="???"
                        TargetControlID="站別TextBox">
                    </cc1:MaskedEditExtender>
                </td>
                <td class="TableEditColumn1">序號:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="序號TextBox" runat="server" Text='<%# Bind("序號") %>' />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99"
                        TargetControlID="序號TextBox">
                    </cc1:MaskedEditExtender>
                </td>
                <td class="TableEditColumn1">上下限:</td>
                <td class="TableEditColumn2">
                    <asp:DropDownList ID="DropDownList1" runat="server"
                        SelectedValue='<%# Bind("上下限") %>' Width="100px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="H">上限</asp:ListItem>
                        <asp:ListItem Value="L">下限</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">DF:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="DFTextBox" runat="server" Text='<%# Bind("DF") %>' />
                </td>
                <td class="TableEditColumn1">MD30:</td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MD30TextBox" runat="server" Text='<%# Bind("MD30") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">C:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CTextBox" runat="server" Text='<%# Bind("C") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Si:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SiTextBox" runat="server" Text='<%# Bind("Si") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mn:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MnTextBox" runat="server" Text='<%# Bind("Mn") %>' />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server"
                        InputDirection="RightToLeft" Mask="999.999" MaskType="Number"
                        TargetControlID="MnTextbox">
                    </cc1:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">P:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="STextBox" runat="server" Text='<%# Bind("S") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Cr:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CrTextBox" runat="server" Text='<%# Bind("Cr") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ni:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="NiTextBox" runat="server" Text='<%# Bind("Ni") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Cu:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CuTextBox" runat="server" Text='<%# Bind("Cu") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mo:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MoTextBox" runat="server" Text='<%# Bind("Mo") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Co:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CoTextBox" runat="server" Text='<%# Bind("Co") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">AL:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ALTextBox" runat="server" Text='<%# Bind("AL") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sn:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SnTextBox" runat="server" Text='<%# Bind("Sn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Pb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="PbTextBox" runat="server" Text='<%# Bind("Pb") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ti</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="TiTextBox" runat="server" Text='<%# Bind("Ti") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Nb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="NbTextBox" runat="server" Text='<%# Bind("Nb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">V:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="VTextBox" runat="server" Text='<%# Bind("V") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">W:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="WTextBox" runat="server" Text='<%# Bind("W") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">H2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="H2TextBox" runat="server" Text='<%# Bind("H2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">B:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="BTextBox" runat="server" Text='<%# Bind("B") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ca:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="CaTextBox" runat="server" Text='<%# Bind("Ca") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mg:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="MgTextBox" runat="server" Text='<%# Bind("Mg") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Fe:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N1:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="N1TextBox" runat="server" Text='<%# Bind("N1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O1:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="O1TextBox" runat="server" Text='<%# Bind("O1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">C2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="C2TextBox" runat="server" Text='<%# Bind("C2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S2:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="S2TextBox" runat="server" Text='<%# Bind("S2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">As:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="AsTextBox" runat="server" Text='<%# Bind("As") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Bi:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="BiTextBox" runat="server" Text='<%# Bind("Bi") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sb:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="SbTextBox" runat="server" Text='<%# Bind("Sb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zn:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ZnTextBox" runat="server" Text='<%# Bind("Zn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zr:</span></td>
                <td class="TableEditColumn2">
                    <asp:TextBox ID="ZrTextBox" runat="server" Text='<%# Bind("Zr") %>' />
                </td>

                <tr>
                    <td class="TableEditColumn1">
                        <span lang="zh-tw">GP:</span></td>
                    <td class="TableEditColumn2">
                        <asp:TextBox ID="GPTextBox" runat="server" Text='<%# Bind("GP") %>' />
                    </td>
                    <td class="TableEditColumn1">
                        <span lang="zh-tw">Ta:</span></td>
                    <td class="TableEditColumn2">
                        <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta") %>' />
                    </td>

                    <td class="TableEditColumn1">
                        <span lang="zh-tw">CAndN:</span></td>
                    <td class="TableEditColumn2">
                        <asp:TextBox ID="CAndNTextBox" runat="server" Text='<%# Bind("CAndN") %>' />
                    </td>
                    <td class="TableEditColumn1">
                        <span lang="zh-tw">NbAndTa:</span></td>
                    <td class="TableEditColumn2">
                        <asp:TextBox ID="NbAndTaTextBox" runat="server" Text='<%# Bind("NbAndTa") %>' />
                    </td>


                    <td class="TableEditColumn1">
                        <span lang="zh-tw"></span></td>
                    <td class="TableEditColumn2"></td>
                    <td class="TableEditColumn1">
                        <span lang="zh-tw"></span></td>
                    <td class="TableEditColumn2"></td>

        </table>
        最後更新時間:
        <asp:TextBox ID="最後更新時間TextBox" runat="server"
            Text='<%# Bind("最後更新時間") %>' Enabled="False" />
        <span lang="zh-tw">(儲存時會更新時間)</span><br />
        更新來源IP:
        <asp:TextBox ID="更新來源IPTextBox" runat="server"
            Text='<%# Bind("更新來源IP") %>' Enabled="False" />
        <br />
        <span lang="zh-tw">更新者:</span><asp:TextBox ID="更新者TextBox" runat="server"
            Enabled="False" Text='<%# Bind("更新者") %>'></asp:TextBox>
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True"
            CommandName="Insert" Text="插入" OnClick="InsertButton_Click" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server"
            CausesValidation="False" CommandName="Cancel" Text="取消" />
    </InsertItemTemplate>
    <ItemTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="TableEditColumn1">鋼種:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
                </td>
                <td class="TableEditColumn1">材質:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
                </td>
                <td class="TableEditColumn1">站別:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="站別Label" runat="server" Text='<%# Eval("站別") %>' />
                </td>
                <td class="TableEditColumn1">序號:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
                </td>
                <td class="TableEditColumn1">上下限:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="上下限Label" runat="server" Text='<%# Eval("上下限") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">DF:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="DFLabel" runat="server" Text='<%# Bind("DF") %>' />
                </td>
                <td class="TableEditColumn1">MD30:</td>
                <td class="TableEditColumn2">
                    <asp:Label ID="MD30Label" runat="server" Text='<%# Bind("MD30") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">C:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CLabel" runat="server" Text='<%# Bind("C") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Si:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="SiLabel" runat="server" Text='<%# Bind("Si") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mn:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="MnLabel" runat="server" Text='<%# Bind("Mn") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">P:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="PLabel" runat="server" Text='<%# Bind("P") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="SLabel" runat="server" Text='<%# Bind("S") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Cr:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CrLabel" runat="server" Text='<%# Bind("Cr") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ni:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="NiLabel" runat="server" Text='<%# Bind("Ni") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Cu:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CuLabel" runat="server" Text='<%# Bind("Cu") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mo:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="MoLabel" runat="server" Text='<%# Bind("Mo") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Co:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CoLabel" runat="server" Text='<%# Bind("Co") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">AL:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="ALLabel" runat="server" Text='<%# Bind("AL") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sn:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="SnLabel" runat="server" Text='<%# Bind("Sn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Pb:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="PbLabel" runat="server" Text='<%# Bind("Pb") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ti</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="TiLabel" runat="server" Text='<%# Bind("Ti") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Nb:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="NbLabel" runat="server" Text='<%# Bind("Nb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">V:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="VLabel" runat="server" Text='<%# Bind("V") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">W:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="WLabel" runat="server" Text='<%# Bind("W") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O2:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="O2Label" runat="server" Text='<%# Bind("O2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N2:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="N2Label" runat="server" Text='<%# Bind("N2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">H2:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="H2Label" runat="server" Text='<%# Bind("H2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">B:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="BLabel" runat="server" Text='<%# Bind("B") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ca:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CaLabel" runat="server" Text='<%# Bind("Ca") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Mg:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="MgLabel" runat="server" Text='<%# Bind("Mg") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Fe:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="FeLabel" runat="server" Text='<%# Bind("Fe") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">N1:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="N1Label" runat="server" Text='<%# Bind("N1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">O1:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="O1Label" runat="server" Text='<%# Bind("O1") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">C2:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="C2Label" runat="server" Text='<%# Bind("C2") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">S2:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="S2Label" runat="server" Text='<%# Bind("S2") %>' />
                </td>
            </tr>
            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">As:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="AsLabel" runat="server" Text='<%# Bind("As") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Bi:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="BiLabel" runat="server" Text='<%# Bind("Bi") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Sb:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="SbLabel" runat="server" Text='<%# Bind("Sb") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zn:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="ZnLabel" runat="server" Text='<%# Bind("Zn") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Zr:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="ZrLabel" runat="server" Text='<%# Bind("Zr") %>' />
                </td>
            </tr>

            <tr>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">GP:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="GPLabel" runat="server" Text='<%# Bind("GP") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">Ta:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="TaLabel" runat="server" Text='<%# Bind("Ta") %>' />
                </td>

                <td class="TableEditColumn1">
                    <span lang="zh-tw">CAndN:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="CAndNLabel" runat="server" Text='<%# Bind("CAndN") %>' />
                </td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw">NbAndTa:</span></td>
                <td class="TableEditColumn2">
                    <asp:Label ID="NbAndTaLabel" runat="server" Text='<%# Bind("NbAndTa") %>' />
                </td>

                <td class="TableEditColumn1">
                    <span lang="zh-tw"></span></td>
                <td class="TableEditColumn2"></td>
                <td class="TableEditColumn1">
                    <span lang="zh-tw"></span></td>
                <td class="TableEditColumn2"></td>
            </tr>

        </table>
        最後更新時間:
        <asp:Label ID="最後更新時間Label" runat="server" Text='<%# Bind("最後更新時間") %>' />
        <br />
        更新來源IP:
        <asp:Label ID="更新來源IPLabel" runat="server" Text='<%# Bind("更新來源IP") %>' />
        <br />
        <span lang="zh-tw">更新者:</span><asp:Label ID="更新者Label" runat="server"
            Text='<%# Eval("更新者") %>'></asp:Label>
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False"
            CommandName="Edit" Text="編輯" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
            CommandName="Delete" Text="刪除" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False"
            CommandName="New" Text="新增" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
            ConfirmText="是否確定要刪除資料?" TargetControlID="DeleteButton">
        </cc1:ConfirmButtonExtender>
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Button ID="btnToInsertMode" runat="server" Text="新增一筆資料"
            CommandName="New" />
    </EmptyDataTemplate>
</asp:FormView>
<asp:LinqDataSource ID="LDSEditDataSource" runat="server"
    ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True"
    EnableInsert="True" EnableUpdate="True" TableName="製程判定">
</asp:LinqDataSource>




