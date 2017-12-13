<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StandSampleRangeEdit.ascx.vb" Inherits="SMPWork.StandSampleRangeEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style1 {
        width: 118px;
    }
</style>
<table style="width: 100%; height: 50px;">
    <tr>
        <td class="style1">樣本編號:</td>
        <td>
            <asp:TextBox ID="tbSampleNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="SampleNumber"
    DataSourceID="ldsSearchResult" EnableModelValidation="True"
    InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td rowspan="2">
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="SampleNumberLabel" runat="server"
                    Text='<%# Eval("SampleNumber") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CLabel" runat="server" Text='<%# Eval("UP_C") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SiLabel" runat="server" Text='<%# Eval("UP_Si") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MnLabel" runat="server" Text='<%# Eval("UP_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PLabel" runat="server" Text='<%# Eval("UP_P") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SLabel" runat="server" Text='<%# Eval("UP_S") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CrLabel" runat="server" Text='<%# Eval("UP_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NiLabel" runat="server" Text='<%# Eval("UP_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CuLabel" runat="server" Text='<%# Eval("UP_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MoLabel" runat="server" Text='<%# Eval("UP_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CoLabel" runat="server" Text='<%# Eval("UP_Co") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ALLabel" runat="server" Text='<%# Eval("UP_AL") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SnLabel" runat="server" Text='<%# Eval("UP_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PbLabel" runat="server" Text='<%# Eval("UP_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TiLabel" runat="server" Text='<%# Eval("UP_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NbLabel" runat="server" Text='<%# Eval("UP_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_VLabel" runat="server" Text='<%# Eval("UP_V") %>' />
            </td>
            <td>
                <asp:Label ID="UP_WLabel" runat="server" Text='<%# Eval("UP_W") %>' />
            </td>
            <td>
                <asp:Label ID="UP_N2Label" runat="server" Text='<%# Eval("UP_N2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_O2Label" runat="server" Text='<%# Eval("UP_O2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BLabel" runat="server" Text='<%# Eval("UP_B") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CaLabel" runat="server" Text='<%# Eval("UP_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MgLabel" runat="server" Text='<%# Eval("UP_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="UP_AsLabel" runat="server" Text='<%# Eval("UP_As") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BiLabel" runat="server" Text='<%# Eval("UP_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SbLabel" runat="server" Text='<%# Eval("UP_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZnLabel" runat="server" Text='<%# Eval("UP_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZrLabel" runat="server" Text='<%# Eval("UP_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_FeLabel" runat="server" Text='<%# Eval("UP_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TaLabel" runat="server" Text='<%# Eval("UP_Ta") %>' />
            </td>
        </tr>
        <tr style="background-color: #FFF8DC;">
            <td></td>
            <td>
                <asp:Label ID="Down_CLabel" runat="server" Text='<%# Eval("Down_C") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SiLabel" runat="server" Text='<%# Eval("Down_Si") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MnLabel" runat="server" Text='<%# Eval("Down_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PLabel" runat="server" Text='<%# Eval("Down_P") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SLabel" runat="server" Text='<%# Eval("Down_S") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CrLabel" runat="server" Text='<%# Eval("Down_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NiLabel" runat="server" Text='<%# Eval("Down_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CuLabel" runat="server" Text='<%# Eval("Down_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MoLabel" runat="server" Text='<%# Eval("Down_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CoLabel" runat="server" Text='<%# Eval("Down_Co") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ALLabel" runat="server" Text='<%# Eval("Down_AL") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SnLabel" runat="server" Text='<%# Eval("Down_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PbLabel" runat="server" Text='<%# Eval("Down_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TiLabel" runat="server" Text='<%# Eval("Down_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NbLabel" runat="server" Text='<%# Eval("Down_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_VLabel" runat="server" Text='<%# Eval("Down_V") %>' />
            </td>
            <td>
                <asp:Label ID="Down_WLabel" runat="server" Text='<%# Eval("Down_W") %>' />
            </td>
            <td>
                <asp:Label ID="Down_N2Label" runat="server" Text='<%# Eval("Down_N2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_O2Label" runat="server" Text='<%# Eval("Down_O2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BLabel" runat="server" Text='<%# Eval("Down_B") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CaLabel" runat="server" Text='<%# Eval("Down_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MgLabel" runat="server" Text='<%# Eval("Down_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="Down_AsLabel" runat="server" Text='<%# Eval("Down_As") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BiLabel" runat="server" Text='<%# Eval("Down_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SbLabel" runat="server" Text='<%# Eval("Down_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZnLabel" runat="server" Text='<%# Eval("Down_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZrLabel" runat="server" Text='<%# Eval("Down_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_FeLabel" runat="server" Text='<%# Eval("Down_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TaLabel" runat="server" Text='<%# Eval("Down_Ta") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td rowspan="2">
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="SampleNumberLabel1" runat="server"
                    Text='<%# Eval("SampleNumber") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CTextBox" runat="server" Text='<%# Bind("UP_C") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SiTextBox" runat="server" Text='<%# Bind("UP_Si") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MnTextBox" runat="server" Text='<%# Bind("UP_Mn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_PTextBox" runat="server" Text='<%# Bind("UP_P") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_STextBox" runat="server" Text='<%# Bind("UP_S") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CrTextBox" runat="server" Text='<%# Bind("UP_Cr") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_NiTextBox" runat="server" Text='<%# Bind("UP_Ni") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CuTextBox" runat="server" Text='<%# Bind("UP_Cu") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MoTextBox" runat="server" Text='<%# Bind("UP_Mo") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CoTextBox" runat="server" Text='<%# Bind("UP_Co") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ALTextBox" runat="server" Text='<%# Bind("UP_AL") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SnTextBox" runat="server" Text='<%# Bind("UP_Sn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_PbTextBox" runat="server" Text='<%# Bind("UP_Pb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_TiTextBox" runat="server" Text='<%# Bind("UP_Ti") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_NbTextBox" runat="server" Text='<%# Bind("UP_Nb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_VTextBox" runat="server" Text='<%# Bind("UP_V") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_WTextBox" runat="server" Text='<%# Bind("UP_W") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_N2TextBox" runat="server" Text='<%# Bind("UP_N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_O2TextBox" runat="server" Text='<%# Bind("UP_O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_BTextBox" runat="server" Text='<%# Bind("UP_B") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CaTextBox" runat="server" Text='<%# Bind("UP_Ca") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MgTextBox" runat="server" Text='<%# Bind("UP_Mg") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_AsTextBox" runat="server" Text='<%# Bind("UP_As") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_BiTextBox" runat="server" Text='<%# Bind("UP_Bi") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SbTextBox" runat="server" Text='<%# Bind("UP_Sb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ZnTextBox" runat="server" Text='<%# Bind("UP_Zn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ZrTextBox" runat="server" Text='<%# Bind("UP_Zr") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_FeTextBox" runat="server" Text='<%# Bind("UP_Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_TaTextBox" runat="server" Text='<%# Bind("UP_Ta") %>' />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:TextBox ID="Down_CTextBox" runat="server" Text='<%# Bind("Down_C") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SiTextBox" runat="server" Text='<%# Bind("Down_Si") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MnTextBox" runat="server" Text='<%# Bind("Down_Mn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_PTextBox" runat="server" Text='<%# Bind("Down_P") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_STextBox" runat="server" Text='<%# Bind("Down_S") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CrTextBox" runat="server" Text='<%# Bind("Down_Cr") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_NiTextBox" runat="server" Text='<%# Bind("Down_Ni") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CuTextBox" runat="server" Text='<%# Bind("Down_Cu") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MoTextBox" runat="server" Text='<%# Bind("Down_Mo") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CoTextBox" runat="server" Text='<%# Bind("Down_Co") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ALTextBox" runat="server" Text='<%# Bind("Down_AL") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SnTextBox" runat="server" Text='<%# Bind("Down_Sn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_PbTextBox" runat="server" Text='<%# Bind("Down_Pb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_TiTextBox" runat="server" Text='<%# Bind("Down_Ti") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_NbTextBox" runat="server" Text='<%# Bind("Down_Nb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_VTextBox" runat="server" Text='<%# Bind("Down_V") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_WTextBox" runat="server" Text='<%# Bind("Down_W") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_N2TextBox" runat="server" Text='<%# Bind("Down_N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_O2TextBox" runat="server" Text='<%# Bind("Down_O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_BTextBox" runat="server" Text='<%# Bind("Down_B") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CaTextBox" runat="server" Text='<%# Bind("Down_Ca") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MgTextBox" runat="server" Text='<%# Bind("Down_Mg") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_AsTextBox" runat="server" Text='<%# Bind("Down_As") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_BiTextBox" runat="server" Text='<%# Bind("Down_Bi") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SbTextBox" runat="server" Text='<%# Bind("Down_Sb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ZnTextBox" runat="server" Text='<%# Bind("Down_Zn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ZrTextBox" runat="server" Text='<%# Bind("Down_Zr") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_FeTextBox" runat="server" Text='<%# Bind("Down_Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_TaTextBox" runat="server" Text='<%# Bind("Down_Ta") %>' />
            </td>
        </tr>
    </EditItemTemplate>
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
            <td rowspan="2">
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:HiddenField ID="HiddenField1" Value='<%# Bind("SampleNumber") %>' runat="server" />
                <asp:DropDownList ID="DropDownList2" runat="server"
                    DataSourceID="LDSSMPStandSample" DataTextField="SampleNumber"
                    DataValueField="SampleNumber" Width="100px">
                </asp:DropDownList>
                <%--<asp:TextBox ID="SampleNumberTextBox" runat="server" 
                    Text='<%# Bind("SampleNumber") %>' />--%>
            </td>
            <td>
                <asp:TextBox ID="UP_CTextBox" runat="server" Text='<%# Bind("UP_C") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SiTextBox" runat="server" Text='<%# Bind("UP_Si") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MnTextBox" runat="server" Text='<%# Bind("UP_Mn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_PTextBox" runat="server" Text='<%# Bind("UP_P") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_STextBox" runat="server" Text='<%# Bind("UP_S") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CrTextBox" runat="server" Text='<%# Bind("UP_Cr") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_NiTextBox" runat="server" Text='<%# Bind("UP_Ni") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CuTextBox" runat="server" Text='<%# Bind("UP_Cu") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MoTextBox" runat="server" Text='<%# Bind("UP_Mo") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CoTextBox" runat="server" Text='<%# Bind("UP_Co") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ALTextBox" runat="server" Text='<%# Bind("UP_AL") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SnTextBox" runat="server" Text='<%# Bind("UP_Sn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_PbTextBox" runat="server" Text='<%# Bind("UP_Pb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_TiTextBox" runat="server" Text='<%# Bind("UP_Ti") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_NbTextBox" runat="server" Text='<%# Bind("UP_Nb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_VTextBox" runat="server" Text='<%# Bind("UP_V") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_WTextBox" runat="server" Text='<%# Bind("UP_W") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_N2TextBox" runat="server" Text='<%# Bind("UP_N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_O2TextBox" runat="server" Text='<%# Bind("UP_O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_BTextBox" runat="server" Text='<%# Bind("UP_B") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_CaTextBox" runat="server" Text='<%# Bind("UP_Ca") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_MgTextBox" runat="server" Text='<%# Bind("UP_Mg") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_AsTextBox" runat="server" Text='<%# Bind("UP_As") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_BiTextBox" runat="server" Text='<%# Bind("UP_Bi") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_SbTextBox" runat="server" Text='<%# Bind("UP_Sb") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ZnTextBox" runat="server" Text='<%# Bind("UP_Zn") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_ZrTextBox" runat="server" Text='<%# Bind("UP_Zr") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_FeTextBox" runat="server" Text='<%# Bind("UP_Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="UP_TaTextBox" runat="server" Text='<%# Bind("UP_Ta") %>' />
            </td>
        </tr>
        <tr style="">
            <td></td>
            <td>
                <asp:TextBox ID="Down_CTextBox" runat="server" Text='<%# Bind("Down_C") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SiTextBox" runat="server" Text='<%# Bind("Down_Si") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MnTextBox" runat="server" Text='<%# Bind("Down_Mn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_PTextBox" runat="server" Text='<%# Bind("Down_P") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_STextBox" runat="server" Text='<%# Bind("Down_S") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CrTextBox" runat="server" Text='<%# Bind("Down_Cr") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_NiTextBox" runat="server" Text='<%# Bind("Down_Ni") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CuTextBox" runat="server" Text='<%# Bind("Down_Cu") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MoTextBox" runat="server" Text='<%# Bind("Down_Mo") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CoTextBox" runat="server" Text='<%# Bind("Down_Co") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ALTextBox" runat="server" Text='<%# Bind("Down_AL") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SnTextBox" runat="server" Text='<%# Bind("Down_Sn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_PbTextBox" runat="server" Text='<%# Bind("Down_Pb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_TiTextBox" runat="server" Text='<%# Bind("Down_Ti") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_NbTextBox" runat="server" Text='<%# Bind("Down_Nb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_VTextBox" runat="server" Text='<%# Bind("Down_V") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_WTextBox" runat="server" Text='<%# Bind("Down_W") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_N2TextBox" runat="server" Text='<%# Bind("Down_N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_O2TextBox" runat="server" Text='<%# Bind("Down_O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_BTextBox" runat="server" Text='<%# Bind("Down_B") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_CaTextBox" runat="server" Text='<%# Bind("Down_Ca") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_MgTextBox" runat="server" Text='<%# Bind("Down_Mg") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_AsTextBox" runat="server" Text='<%# Bind("Down_As") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_BiTextBox" runat="server" Text='<%# Bind("Down_Bi") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_SbTextBox" runat="server" Text='<%# Bind("Down_Sb") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ZnTextBox" runat="server" Text='<%# Bind("Down_Zn") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_ZrTextBox" runat="server" Text='<%# Bind("Down_Zr") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_FeTextBox" runat="server" Text='<%# Bind("Down_Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="Down_TaTextBox" runat="server" Text='<%# Bind("Down_Ta")%>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td rowspan="2">
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />

            </td>
            <td>
                <asp:Label ID="SampleNumberLabel" runat="server"
                    Text='<%# Eval("SampleNumber") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CLabel" runat="server" Text='<%# Eval("UP_C") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SiLabel" runat="server" Text='<%# Eval("UP_Si") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MnLabel" runat="server" Text='<%# Eval("UP_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PLabel" runat="server" Text='<%# Eval("UP_P") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SLabel" runat="server" Text='<%# Eval("UP_S") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CrLabel" runat="server" Text='<%# Eval("UP_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NiLabel" runat="server" Text='<%# Eval("UP_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CuLabel" runat="server" Text='<%# Eval("UP_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MoLabel" runat="server" Text='<%# Eval("UP_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CoLabel" runat="server" Text='<%# Eval("UP_Co") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ALLabel" runat="server" Text='<%# Eval("UP_AL") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SnLabel" runat="server" Text='<%# Eval("UP_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PbLabel" runat="server" Text='<%# Eval("UP_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TiLabel" runat="server" Text='<%# Eval("UP_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NbLabel" runat="server" Text='<%# Eval("UP_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_VLabel" runat="server" Text='<%# Eval("UP_V") %>' />
            </td>
            <td>
                <asp:Label ID="UP_WLabel" runat="server" Text='<%# Eval("UP_W") %>' />
            </td>
            <td>
                <asp:Label ID="UP_N2Label" runat="server" Text='<%# Eval("UP_N2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_O2Label" runat="server" Text='<%# Eval("UP_O2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BLabel" runat="server" Text='<%# Eval("UP_B") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CaLabel" runat="server" Text='<%# Eval("UP_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MgLabel" runat="server" Text='<%# Eval("UP_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="UP_AsLabel" runat="server" Text='<%# Eval("UP_As") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BiLabel" runat="server" Text='<%# Eval("UP_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SbLabel" runat="server" Text='<%# Eval("UP_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZnLabel" runat="server" Text='<%# Eval("UP_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZrLabel" runat="server" Text='<%# Eval("UP_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_FeLabel" runat="server" Text='<%# Eval("UP_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TaLabel" runat="server" Text='<%# Eval("UP_Ta") %>' />
            </td>
        </tr>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td></td>
            <td>
                <asp:Label ID="Down_CLabel" runat="server" Text='<%# Eval("Down_C") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SiLabel" runat="server" Text='<%# Eval("Down_Si") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MnLabel" runat="server" Text='<%# Eval("Down_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PLabel" runat="server" Text='<%# Eval("Down_P") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SLabel" runat="server" Text='<%# Eval("Down_S") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CrLabel" runat="server" Text='<%# Eval("Down_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NiLabel" runat="server" Text='<%# Eval("Down_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CuLabel" runat="server" Text='<%# Eval("Down_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MoLabel" runat="server" Text='<%# Eval("Down_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CoLabel" runat="server" Text='<%# Eval("Down_Co") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ALLabel" runat="server" Text='<%# Eval("Down_AL") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SnLabel" runat="server" Text='<%# Eval("Down_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PbLabel" runat="server" Text='<%# Eval("Down_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TiLabel" runat="server" Text='<%# Eval("Down_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NbLabel" runat="server" Text='<%# Eval("Down_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_VLabel" runat="server" Text='<%# Eval("Down_V") %>' />
            </td>
            <td>
                <asp:Label ID="Down_WLabel" runat="server" Text='<%# Eval("Down_W") %>' />
            </td>
            <td>
                <asp:Label ID="Down_N2Label" runat="server" Text='<%# Eval("Down_N2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_O2Label" runat="server" Text='<%# Eval("Down_O2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BLabel" runat="server" Text='<%# Eval("Down_B") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CaLabel" runat="server" Text='<%# Eval("Down_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MgLabel" runat="server" Text='<%# Eval("Down_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="Down_AsLabel" runat="server" Text='<%# Eval("Down_As") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BiLabel" runat="server" Text='<%# Eval("Down_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SbLabel" runat="server" Text='<%# Eval("Down_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZnLabel" runat="server" Text='<%# Eval("Down_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZrLabel" runat="server" Text='<%# Eval("Down_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_FeLabel" runat="server" Text='<%# Eval("Down_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TaLabel" runat="server" Text='<%# Eval("Down_Ta") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1"
                        style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">樣本編號</th>
                            <th runat="server">上限C</th>
                            <th runat="server">上限Si</th>
                            <th runat="server">上限Mn</th>
                            <th runat="server">上限P</th>
                            <th runat="server">上限S</th>
                            <th runat="server">上限Cr</th>
                            <th runat="server">上限Ni</th>
                            <th runat="server">上限Cu</th>
                            <th runat="server">上限Mo</th>
                            <th runat="server">上限Co</th>
                            <th runat="server">上限AL</th>
                            <th runat="server">上限Sn</th>
                            <th runat="server">上限Pb</th>
                            <th runat="server">上限Ti</th>
                            <th runat="server">上限Nb</th>
                            <th runat="server">上限V</th>
                            <th runat="server">上限W</th>
                            <th runat="server">上限N</th>
                            <th runat="server">上限O</th>
                            <th runat="server">上限B</th>
                            <th runat="server">上限Ca</th>
                            <th runat="server">上限Mg</th>
                            <th runat="server">上限As</th>
                            <th runat="server">上限Bi</th>
                            <th runat="server">上限Sb</th>
                            <th runat="server">上限Zn</th>
                            <th runat="server">上限Zr</th>
                            <th runat="server">上限Fe</th>
                            <th runat="server">上限Ta</th>
                        </tr>
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th id="Th1" runat="server"></th>
                            <th></th>
                            <th runat="server">下限C</th>
                            <th runat="server">下限Si</th>
                            <th runat="server">下限Mn</th>
                            <th runat="server">下限P</th>
                            <th runat="server">下限S</th>
                            <th runat="server">下限Cr</th>
                            <th runat="server">下限Ni</th>
                            <th runat="server">下限Cu</th>
                            <th runat="server">下限Mo</th>
                            <th runat="server">下限Co</th>
                            <th runat="server">下限AL</th>
                            <th runat="server">下限Sn</th>
                            <th runat="server">下限Pb</th>
                            <th runat="server">下限Ti</th>
                            <th runat="server">下限Nb</th>
                            <th runat="server">下限V</th>
                            <th runat="server">下限W</th>
                            <th runat="server">下限N</th>
                            <th runat="server">下限O</th>
                            <th runat="server">下限B</th>
                            <th runat="server">下限Ca</th>
                            <th runat="server">下限Mg</th>
                            <th runat="server">下限As</th>
                            <th runat="server">下限Bi</th>
                            <th runat="server">下限Sb</th>
                            <th runat="server">下限Zn</th>
                            <th runat="server">下限Zr</th>
                            <th runat="server">下限Fe</th>
                            <th runat="server">下限Ta</th>
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
                                ShowLastPageButton="True" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td rowspan="2">
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="SampleNumberLabel" runat="server"
                    Text='<%# Eval("SampleNumber") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CLabel" runat="server" Text='<%# Eval("UP_C") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SiLabel" runat="server" Text='<%# Eval("UP_Si") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MnLabel" runat="server" Text='<%# Eval("UP_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PLabel" runat="server" Text='<%# Eval("UP_P") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SLabel" runat="server" Text='<%# Eval("UP_S") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CrLabel" runat="server" Text='<%# Eval("UP_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NiLabel" runat="server" Text='<%# Eval("UP_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CuLabel" runat="server" Text='<%# Eval("UP_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MoLabel" runat="server" Text='<%# Eval("UP_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CoLabel" runat="server" Text='<%# Eval("UP_Co") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ALLabel" runat="server" Text='<%# Eval("UP_AL") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SnLabel" runat="server" Text='<%# Eval("UP_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_PbLabel" runat="server" Text='<%# Eval("UP_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TiLabel" runat="server" Text='<%# Eval("UP_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="UP_NbLabel" runat="server" Text='<%# Eval("UP_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_VLabel" runat="server" Text='<%# Eval("UP_V") %>' />
            </td>
            <td>
                <asp:Label ID="UP_WLabel" runat="server" Text='<%# Eval("UP_W") %>' />
            </td>
            <td>
                <asp:Label ID="UP_N2Label" runat="server" Text='<%# Eval("UP_N2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_O2Label" runat="server" Text='<%# Eval("UP_O2") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BLabel" runat="server" Text='<%# Eval("UP_B") %>' />
            </td>
            <td>
                <asp:Label ID="UP_CaLabel" runat="server" Text='<%# Eval("UP_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="UP_MgLabel" runat="server" Text='<%# Eval("UP_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="UP_AsLabel" runat="server" Text='<%# Eval("UP_As") %>' />
            </td>
            <td>
                <asp:Label ID="UP_BiLabel" runat="server" Text='<%# Eval("UP_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="UP_SbLabel" runat="server" Text='<%# Eval("UP_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZnLabel" runat="server" Text='<%# Eval("UP_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="UP_ZrLabel" runat="server" Text='<%# Eval("UP_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="UP_FeLabel" runat="server" Text='<%# Eval("UP_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="UP_TaLabel" runat="server" Text='<%# Eval("UP_Ta") %>' />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="Down_CLabel" runat="server" Text='<%# Eval("Down_C") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SiLabel" runat="server" Text='<%# Eval("Down_Si") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MnLabel" runat="server" Text='<%# Eval("Down_Mn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PLabel" runat="server" Text='<%# Eval("Down_P") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SLabel" runat="server" Text='<%# Eval("Down_S") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CrLabel" runat="server" Text='<%# Eval("Down_Cr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NiLabel" runat="server" Text='<%# Eval("Down_Ni") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CuLabel" runat="server" Text='<%# Eval("Down_Cu") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MoLabel" runat="server" Text='<%# Eval("Down_Mo") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CoLabel" runat="server" Text='<%# Eval("Down_Co") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ALLabel" runat="server" Text='<%# Eval("Down_AL") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SnLabel" runat="server" Text='<%# Eval("Down_Sn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_PbLabel" runat="server" Text='<%# Eval("Down_Pb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TiLabel" runat="server" Text='<%# Eval("Down_Ti") %>' />
            </td>
            <td>
                <asp:Label ID="Down_NbLabel" runat="server" Text='<%# Eval("Down_Nb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_VLabel" runat="server" Text='<%# Eval("Down_V") %>' />
            </td>
            <td>
                <asp:Label ID="Down_WLabel" runat="server" Text='<%# Eval("Down_W") %>' />
            </td>
            <td>
                <asp:Label ID="Down_N2Label" runat="server" Text='<%# Eval("Down_N2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_O2Label" runat="server" Text='<%# Eval("Down_O2") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BLabel" runat="server" Text='<%# Eval("Down_B") %>' />
            </td>
            <td>
                <asp:Label ID="Down_CaLabel" runat="server" Text='<%# Eval("Down_Ca") %>' />
            </td>
            <td>
                <asp:Label ID="Down_MgLabel" runat="server" Text='<%# Eval("Down_Mg") %>' />
            </td>
            <td>
                <asp:Label ID="Down_AsLabel" runat="server" Text='<%# Eval("Down_As") %>' />
            </td>
            <td>
                <asp:Label ID="Down_BiLabel" runat="server" Text='<%# Eval("Down_Bi") %>' />
            </td>
            <td>
                <asp:Label ID="Down_SbLabel" runat="server" Text='<%# Eval("Down_Sb") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZnLabel" runat="server" Text='<%# Eval("Down_Zn") %>' />
            </td>
            <td>
                <asp:Label ID="Down_ZrLabel" runat="server" Text='<%# Eval("Down_Zr") %>' />
            </td>
            <td>
                <asp:Label ID="Down_FeLabel" runat="server" Text='<%# Eval("Down_Fe") %>' />
            </td>
            <td>
                <asp:Label ID="Down_TaLabel" runat="server" Text='<%# Eval("Down_Ta") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server"
    ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True"
    EnableInsert="True" EnableUpdate="True" TableName="標準樣本接收資料上下限">
</asp:LinqDataSource>


<asp:LinqDataSource ID="LDSSMPStandSample" runat="server"
    ContextTypeName="CompanyLINQDB.SMPDataContext" Select="new (SampleNumber)"
    TableName="SMPStandardSample">
</asp:LinqDataSource>





