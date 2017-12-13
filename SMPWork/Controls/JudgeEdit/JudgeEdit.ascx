<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="JudgeEdit.ascx.vb" Inherits="SMPWork.JudgeEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 84px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="244px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分ex:304,201)</td>
    </tr>
    <tr>
        <td class="style1">
            材質:</td>
        <td>
            <asp:TextBox ID="tbMaterial" runat="server" Width="117px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分ex:TE,TE1)</td>
    </tr>
    <tr>
        <td class="style1">
            管制種類:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="CH">管制上限</asp:ListItem>
                <asp:ListItem Selected="True" Value="CL">管制下限</asp:ListItem>
                <asp:ListItem Selected="True" Value="SH">銷售上限</asp:ListItem>
                <asp:ListItem Selected="True" Value="SL">銷售下限</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" 
    EnableModelValidation="True" DataKeyNames="鋼種,材質,管制種類" 
    InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" runat="server">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="管制種類Label" runat="server" Text='<%# Eval("管制種類") %>' />
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
                <asp:Label ID="CAndNLabel" runat="server" Text='<%# Eval("CAndN") %>' />
            </td>

                        <td>
                <asp:Label ID="AsLabel" runat="server" Text='<%# Eval("As")%>' />
            </td>
                        <td>
                <asp:Label ID="BiLabel" runat="server" Text='<%# Eval("Bi")%>' />
            </td>
                        <td>
                <asp:Label ID="SbLabel" runat="server" Text='<%# Eval("Sb")%>' />
            </td>
                        <td>
                <asp:Label ID="ZnLabel" runat="server" Text='<%# Eval("Zn")%>' />
            </td>
                        <td>
                <asp:Label ID="ZrLabel" runat="server" Text='<%# Eval("Zr")%>' />
            </td>
                        <td>
                <asp:Label ID="GPLabel" runat="server" Text='<%# Eval("GP")%>' />
            </td>
                        <td>
                <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta")%>' />
            </td>
                        <td>
                <asp:Label ID="NbAndTaLabel" runat="server" Text='<%# Eval("NbAndTa")%>' />
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
                <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' ReadOnly="true" BackColor="Gray" />
            </td>
            <td>
                <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' ReadOnly="true" BackColor="Gray"  />
            </td>
            <td>
                <asp:TextBox ID="管制種類TextBox" runat="server" Text='<%# Bind("管制種類") %>' ReadOnly="true" BackColor="Gray"  />
                <%--<asp:DropDownList ID="DropDownList2" runat="server"  Value='<%# Bind("管制種類") %>'  Width="60px"  >
                    <asp:ListItem Text="SH" Value="SH" />
                    <asp:ListItem Text="SL" Value="SL" />
                    <asp:ListItem Text="CH" Value="CH" />
                    <asp:ListItem Text="CL" Value="CL" />
                </asp:DropDownList>--%>
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
                <asp:TextBox ID="CAndNTextBox" runat="server" Text='<%# Bind("CAndN") %>' />
            </td>

            <td>
                <asp:TextBox ID="AsTextBox" runat="server" Text='<%# Bind("As")%>' />
            </td>
                        <td>
                <asp:TextBox ID="BiTextBox" runat="server" Text='<%# Bind("Bi")%>' />
            </td>
                        <td>
                <asp:TextBox ID="SbTextBox" runat="server" Text='<%# Bind("Sb")%>' />
            </td>
                        <td>
                <asp:TextBox ID="ZnTextBox" runat="server" Text='<%# Bind("Zn")%>' />
            </td>
                        <td>
                <asp:TextBox ID="ZrTextBox" runat="server" Text='<%# Bind("Zr")%>' />
            </td>
                        <td>
                <asp:TextBox ID="GPTextBox" runat="server" Text='<%# Bind("GP")%>' />
            </td>
                        <td>
                <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta") %>' />
            </td>
                        <td>
                <asp:TextBox ID="NbAndTaTextBox" runat="server" Text='<%# Bind("NbAndTa")%>' />
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
                <asp:TextBox ID="鋼種TextBox" runat="server" Text='<%# Bind("鋼種") %>' />
            </td>
            <td>
                <asp:TextBox ID="材質TextBox" runat="server" Text='<%# Bind("材質") %>' />
            </td>
            <td>
                <asp:TextBox ID="管制種類TextBox" runat="server" Text='<%# Bind("管制種類") %>' />
                <%--<asp:DropDownList ID="DropDownList2" runat="server"  Value='<%# Bind("管制種類") %>'  Width="60px"  >
                    <asp:ListItem Text="SH" Value="SH" />
                    <asp:ListItem Text="SL" Value="SL" />
                    <asp:ListItem Text="CH" Value="CH" />
                    <asp:ListItem Text="CL" Value="CL" />
                </asp:DropDownList>--%>
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
                <asp:TextBox ID="CAndNTextBox" runat="server" Text='<%# Bind("CAndN") %>' />
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
                <asp:TextBox ID="GPTextBox" runat="server" Text='<%# Bind("GP") %>' />
            </td>
                        <td>
                <asp:TextBox ID="TaTextBox" runat="server" Text='<%# Bind("Ta") %>' />
            </td>
                        <td>
                <asp:TextBox ID="NbAndTaTextBox" runat="server" Text='<%# Bind("NbAndTa") %>' />
            </td>


        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" runat="server">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="管制種類Label" runat="server" Text='<%# Eval("管制種類") %>' />
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
                <asp:Label ID="CAndNLabel" runat="server" Text='<%# Eval("CAndN") %>' />
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
                <asp:Label ID="GPLabel" runat="server" Text='<%# Eval("GP")%>' />
            </td>
                        <td>
                <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta") %>' />
            </td>
                        <td>
                <asp:Label ID="NbAndTaLabel" runat="server" Text='<%# Eval("NbAndTa") %>' />
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
                                鋼種</th>
                            <th runat="server">
                                材質</th>
                            <th runat="server">
                                管制種類</th>
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
                            <th id="Th1" runat="server">
                                碳加氮</th>

                                                        <th id="Th2" runat="server">
                                As</th>
                                                        <th id="Th3" runat="server">
                                Bi</th>
                                                        <th id="Th4" runat="server">
                                Sb</th>
                                                        <th id="Th5" runat="server">
                                Zn</th>
                                                        <th id="Th6" runat="server">
                                Zr</th>
                                                        <th id="Th7" runat="server">
                                GP</th>
                                                        <th id="Th8" runat="server">
                                Ta</th>
                                                        <th id="Th9" runat="server">
                                NbAndTa</th>
                                 



                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
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
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="鋼種Label" runat="server" Text='<%# Eval("鋼種") %>' />
            </td>
            <td>
                <asp:Label ID="材質Label" runat="server" Text='<%# Eval("材質") %>' />
            </td>
            <td>
                <asp:Label ID="管制種類Label" runat="server" Text='<%# Eval("管制種類") %>' />
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
                <asp:Label ID="CAndNLabel" runat="server" Text='<%# Eval("CAndN") %>' />
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
                <asp:Label ID="GPLabel" runat="server" Text='<%# Eval("GP")%>' />
            </td>
                        <td>
                <asp:Label ID="TaLabel" runat="server" Text='<%# Eval("Ta") %>' />
            </td>
                        <td>
                <asp:Label ID="NbAndTaLabel" runat="server" Text='<%# Eval("NbAndTa") %>' />
            </td>



        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.成品判定_公式" 
    DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" 
    TypeName="SMPWork.JudgeEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString1" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfQry" runat="server" />



