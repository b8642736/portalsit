<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StoveElementEdit.ascx.vb" Inherits="SMPWork.StoveElementEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 56px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server" Width="97px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" AutoPostBack="True" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" AutoPostBack="True" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
        </td>
    </tr>
    <tr>
        <td class="style1">
            站別:</td>
        <td>
            <asp:DropDownList ID="DDLStationName" runat="server" Width="115px" 
                DataTextField="StationName" DataValueField="StationID">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">電爐A</asp:ListItem>
                <asp:ListItem Value="E2">電爐B</asp:ListItem>
                <asp:ListItem Value="A1">AOD</asp:ListItem>
                <asp:ListItem Value="L1">LADLE</asp:ListItem>
                <asp:ListItem Value="C">TUNISH</asp:ListItem>
            </asp:DropDownList></td>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>

</table>

<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" 
    Text="注意:此作業資料之變更會同時更新SQLServer與AS400"></asp:Label>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="爐號,站別,序號,日期" 
    DataSourceID="ldsSearchResult" EnableModelValidation="True" 
    InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除此筆資料?" >
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="爐號Label" runat="server" Text='<%# Eval("爐號") %>' />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="站別Label" runat="server" Text='<%# Eval("站別") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="判定Label" runat="server" Text='<%# Eval("判定") %>' />
            </td>
            <td>
                <asp:Label ID="日期Label" runat="server" Text='<%# Eval("日期") %>' />
            </td>
            <td>
                <asp:Label ID="時間Label" runat="server" Text='<%# Eval("時間") %>' />
            </td>
            <td>
                <asp:Label ID="操作員Label" runat="server" Text='<%# Eval("操作員") %>' />
            </td>
            <td>
                <asp:Label ID="DFLabel" runat="server" Text='<%# Eval("DF") %>' />
            </td>
            <td>
                <asp:Label ID="MD30Label" runat="server" Text='<%# Eval("MD30") %>' />
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
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
            </td>
            <td>
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="H2Label" runat="server" Text='<%# Eval("H2") %>' />
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
                <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
            </td>
            <td>
                <asp:Label ID="N1Label" runat="server" Text='<%# Eval("N1") %>' />
            </td>
            <td>
                <asp:Label ID="O1Label" runat="server" Text='<%# Eval("O1") %>' />
            </td>
            <td>
                <asp:Label ID="C2Label" runat="server" Text='<%# Eval("C2") %>' />
            </td>
            <td>
                <asp:Label ID="S2Label" runat="server" Text='<%# Eval("S2") %>' />
            </td>
            <td>
                <asp:Label ID="分光儀編號Label" runat="server" Text='<%# Eval("分光儀編號") %>' />
            </td>
            <td>
                <asp:Label ID="輻射Label" runat="server" Text='<%# Eval("輻射") %>' />
            </td>
            <td>
                <asp:Label ID="連鑄爐次Label" runat="server" Text='<%# Eval("連鑄爐次") %>' />
            </td>
            <td>
                <asp:Label ID="最後爐Label" runat="server" Text='<%# Eval("最後爐") %>' />
            </td>
            <td>
                <asp:Label ID="驗收料Label" runat="server" Text='<%# Eval("驗收料") %>' />
            </td>
            <td>
                <asp:Label ID="備註1Label" runat="server" Text='<%# Eval("備註1") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:Label ID="爐號Label1" runat="server" Text='<%# Eval("爐號") %>' />
            </td>
            <td>
                <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' />
            </td>
            <td>
                <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' />
            </td>
            <td>
                <asp:Label ID="站別Label1" runat="server" Text='<%# Eval("站別") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label1" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:TextBox ID="判定TextBox" runat="server" Text='<%# Bind("判定") %>' />
            </td>
            <td>
                <asp:Label ID="日期Label1" runat="server" Text='<%# Eval("日期") %>' />
            </td>
            <td>
                <asp:TextBox ID="時間TextBox" runat="server" Text='<%# Bind("時間") %>' />
                <cc1:MaskedEditExtender ID="TextBox1_MaskedEditExtender" runat="server" 
                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="99時99分99秒" TargetControlID="時間TextBox" UserTimeFormat="TwentyFourHour">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="操作員TextBox" runat="server" Text='<%# Bind("操作員") %>' />
            </td>
            <td>
                <asp:TextBox ID="DFTextBox" runat="server" Text='<%# Bind("DF") %>' />
            </td>
            <td>
                <asp:TextBox ID="MD30TextBox" runat="server" Text='<%# Bind("MD30") %>' />
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
                <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="H2TextBox" runat="server" Text='<%# Bind("H2") %>' />
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
                <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="N1TextBox" runat="server" Text='<%# Bind("N1") %>' />
            </td>
            <td>
                <asp:TextBox ID="O1TextBox" runat="server" Text='<%# Bind("O1") %>' />
            </td>
            <td>
                <asp:TextBox ID="C2TextBox" runat="server" Text='<%# Bind("C2") %>' />
            </td>
            <td>
                <asp:TextBox ID="S2TextBox" runat="server" Text='<%# Bind("S2") %>' />
            </td>
            <td>
                <asp:TextBox ID="分光儀編號TextBox" runat="server" Text='<%# Bind("分光儀編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="輻射TextBox" runat="server" Text='<%# Bind("輻射") %>' />
            </td>
            <td>
                <asp:TextBox ID="連鑄爐次TextBox" runat="server" Text='<%# Bind("連鑄爐次") %>' />
            </td>
            <td>
                <asp:TextBox ID="最後爐TextBox" runat="server" Text='<%# Bind("最後爐") %>' />
            </td>
            <td>
                <asp:TextBox ID="驗收料TextBox" runat="server" Text='<%# Bind("驗收料") %>' />
            </td>
            <td>
                <asp:TextBox ID="備註1TextBox" runat="server" Text='<%# Bind("備註1") %>' />
            </td>
        </tr>
    </EditItemTemplate>
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="爐號TextBox" runat="server" BackColor="LightGreen"  Text='<%# Bind("爐號") %>' />
            </td>
            <td>
                <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' />
            </td>
            <td>
                <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' />
            </td>
            <td>
                <asp:TextBox ID="站別TextBox" runat="server" BackColor="LightGreen"  Text='<%# Bind("站別") %>' />
            </td>
            <td>
                <asp:TextBox ID="序號TextBox" runat="server" BackColor="LightGreen"  Text='<%# Bind("序號") %>' />
            </td>
            <td>
                <asp:TextBox ID="判定TextBox" runat="server" Text='<%# Bind("判定") %>' />
            </td>
            <td>
                <asp:TextBox ID="日期TextBox" runat="server" BackColor="LightGreen" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="民國999年99月99日" TargetControlID="日期TextBox">
                </cc1:MaskedEditExtender>
            </td>
            <td>
               <asp:TextBox ID="時間TextBox" runat="server" />
                <cc1:MaskedEditExtender ID="TextBox1_MaskedEditExtender" runat="server" 
                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="99時99分99秒" TargetControlID="時間TextBox" UserTimeFormat="TwentyFourHour">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:TextBox ID="操作員TextBox" runat="server" Text='<%# Bind("操作員") %>' />
            </td>
            <td>
                <asp:TextBox ID="DFTextBox" runat="server" Text='<%# Bind("DF") %>' />
            </td>
            <td>
                <asp:TextBox ID="MD30TextBox" runat="server" Text='<%# Bind("MD30") %>' />
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
                <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
            </td>
            <td>
                <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="H2TextBox" runat="server" Text='<%# Bind("H2") %>' />
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
                <asp:TextBox ID="FeTextBox" runat="server" Text='<%# Bind("Fe") %>' />
            </td>
            <td>
                <asp:TextBox ID="N1TextBox" runat="server" Text='<%# Bind("N1") %>' />
            </td>
            <td>
                <asp:TextBox ID="O1TextBox" runat="server" Text='<%# Bind("O1") %>' />
            </td>
            <td>
                <asp:TextBox ID="C2TextBox" runat="server" Text='<%# Bind("C2") %>' />
            </td>
            <td>
                <asp:TextBox ID="S2TextBox" runat="server" Text='<%# Bind("S2") %>' />
            </td>
            <td>
                <asp:TextBox ID="分光儀編號TextBox" runat="server" Text='<%# Bind("分光儀編號") %>' />
            </td>
            <td>
                <asp:TextBox ID="輻射TextBox" runat="server" Text='<%# Bind("輻射") %>' />
            </td>
            <td>
                <asp:TextBox ID="連鑄爐次TextBox" runat="server" Text='<%# Bind("連鑄爐次") %>' />
            </td>
            <td>
                <asp:TextBox ID="最後爐TextBox" runat="server" Text='<%# Bind("最後爐") %>' />
            </td>
            <td>
                <asp:TextBox ID="驗收料TextBox" runat="server" Text='<%# Bind("驗收料") %>' />
            </td>
            <td>
                <asp:TextBox ID="備註1TextBox" runat="server" Text='<%# Bind("備註1") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除此筆資料?" >
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="爐號Label" runat="server" Text='<%# Eval("爐號") %>' />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="站別Label" runat="server" Text='<%# Eval("站別") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="判定Label" runat="server" Text='<%# Eval("判定") %>' />
            </td>
            <td>
                <asp:Label ID="日期Label" runat="server" Text='<%# Eval("日期") %>' />
            </td>
            <td>
                <asp:Label ID="時間Label" runat="server" Text='<%# Eval("時間") %>' />
            </td>
            <td>
                <asp:Label ID="操作員Label" runat="server" Text='<%# Eval("操作員") %>' />
            </td>
            <td>
                <asp:Label ID="DFLabel" runat="server" Text='<%# Eval("DF") %>' />
            </td>
            <td>
                <asp:Label ID="MD30Label" runat="server" Text='<%# Eval("MD30") %>' />
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
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
            </td>
            <td>
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="H2Label" runat="server" Text='<%# Eval("H2") %>' />
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
                <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
            </td>
            <td>
                <asp:Label ID="N1Label" runat="server" Text='<%# Eval("N1") %>' />
            </td>
            <td>
                <asp:Label ID="O1Label" runat="server" Text='<%# Eval("O1") %>' />
            </td>
            <td>
                <asp:Label ID="C2Label" runat="server" Text='<%# Eval("C2") %>' />
            </td>
            <td>
                <asp:Label ID="S2Label" runat="server" Text='<%# Eval("S2") %>' />
            </td>
            <td>
                <asp:Label ID="分光儀編號Label" runat="server" Text='<%# Eval("分光儀編號") %>' />
            </td>
            <td>
                <asp:Label ID="輻射Label" runat="server" Text='<%# Eval("輻射") %>' />
            </td>
            <td>
                <asp:Label ID="連鑄爐次Label" runat="server" Text='<%# Eval("連鑄爐次") %>' />
            </td>
            <td>
                <asp:Label ID="最後爐Label" runat="server" Text='<%# Eval("最後爐") %>' />
            </td>
            <td>
                <asp:Label ID="驗收料Label" runat="server" Text='<%# Eval("驗收料") %>' />
            </td>
            <td>
                <asp:Label ID="備註1Label" runat="server" Text='<%# Eval("備註1") %>' />
            </td>
        </tr>
    </ItemTemplate>
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
                                爐號</th>
                            <th runat="server">
                                鋼種</th>
                            <th runat="server">
                                材質</th>
                            <th runat="server">
                                站別</th>
                            <th runat="server">
                                序號</th>
                            <th runat="server">
                                判定</th>
                            <th runat="server">
                                日期</th>
                            <th runat="server">
                                時間</th>
                            <th runat="server">
                                操作員</th>
                            <th runat="server">
                                DF</th>
                            <th runat="server">
                                MD30</th>
                            <th runat="server">
                                C</th>
                            <th runat="server">
                                Si</th>
                            <th runat="server">
                                Mn</th>
                            <th runat="server">
                                P</th>
                            <th runat="server">
                                S</th>
                            <th runat="server">
                                Cr</th>
                            <th runat="server">
                                Ni</th>
                            <th runat="server">
                                Cu</th>
                            <th runat="server">
                                Mo</th>
                            <th runat="server">
                                Co</th>
                            <th runat="server">
                                AL</th>
                            <th runat="server">
                                Sn</th>
                            <th runat="server">
                                Pb</th>
                            <th runat="server">
                                Ti</th>
                            <th runat="server">
                                Nb</th>
                            <th runat="server">
                                V</th>
                            <th runat="server">
                                W</th>
                            <th runat="server">
                                O2</th>
                            <th runat="server">
                                N2</th>
                            <th runat="server">
                                H2</th>
                            <th runat="server">
                                B</th>
                            <th runat="server">
                                Ca</th>
                            <th runat="server">
                                Mg</th>
                            <th runat="server">
                                Fe</th>
                            <th runat="server">
                                N1</th>
                            <th runat="server">
                                O1</th>
                            <th runat="server">
                                C2</th>
                            <th runat="server">
                                S2</th>
                            <th runat="server">
                                分光儀編號</th>
                            <th runat="server">
                                輻射值</th>
                            <th runat="server">
                                連鑄爐次</th>
                            <th runat="server">
                                最後爐</th>
                            <th runat="server">
                                驗收料</th>
                            <th runat="server">
                                背景值</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>

            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" style="">
                    <asp:DataPager PageSize="20"  ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField ButtonCount="20" />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>

            <%--<tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </td>
            </tr>--%>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="爐號Label" runat="server" Text='<%# Eval("爐號") %>' />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="站別Label" runat="server" Text='<%# Eval("站別") %>' />
            </td>
            <td>
                <asp:Label ID="序號Label" runat="server" Text='<%# Eval("序號") %>' />
            </td>
            <td>
                <asp:Label ID="判定Label" runat="server" Text='<%# Eval("判定") %>' />
            </td>
            <td>
                <asp:Label ID="日期Label" runat="server" Text='<%# Eval("日期") %>' />
            </td>
            <td>
                <asp:Label ID="時間Label" runat="server" Text='<%# Eval("時間") %>' />
            </td>
            <td>
                <asp:Label ID="操作員Label" runat="server" Text='<%# Eval("操作員") %>' />
            </td>
            <td>
                <asp:Label ID="DFLabel" runat="server" Text='<%# Eval("DF") %>' />
            </td>
            <td>
                <asp:Label ID="MD30Label" runat="server" Text='<%# Eval("MD30") %>' />
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
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
            </td>
            <td>
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="H2Label" runat="server" Text='<%# Eval("H2") %>' />
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
                <asp:Label ID="FeLabel" runat="server" Text='<%# Eval("Fe") %>' />
            </td>
            <td>
                <asp:Label ID="N1Label" runat="server" Text='<%# Eval("N1") %>' />
            </td>
            <td>
                <asp:Label ID="O1Label" runat="server" Text='<%# Eval("O1") %>' />
            </td>
            <td>
                <asp:Label ID="C2Label" runat="server" Text='<%# Eval("C2") %>' />
            </td>
            <td>
                <asp:Label ID="S2Label" runat="server" Text='<%# Eval("S2") %>' />
            </td>
            <td>
                <asp:Label ID="分光儀編號Label" runat="server" Text='<%# Eval("分光儀編號") %>' />
            </td>
            <td>
                <asp:Label ID="輻射Label" runat="server" Text='<%# Eval("輻射") %>' />
            </td>
            <td>
                <asp:Label ID="連鑄爐次Label" runat="server" Text='<%# Eval("連鑄爐次") %>' />
            </td>
            <td>
                <asp:Label ID="最後爐Label" runat="server" Text='<%# Eval("最後爐") %>' />
            </td>
            <td>
                <asp:Label ID="驗收料Label" runat="server" Text='<%# Eval("驗收料") %>' />
            </td>
            <td>
                <asp:Label ID="備註1Label" runat="server" Text='<%# Eval("備註1") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" OrderBy="爐號, 日期, 時間" TableName="分析資料">
</asp:LinqDataSource>




<asp:HiddenField ID="hfIsCanEdit" runat="server" Value="True" />








