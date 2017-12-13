<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StandardSampleReceiveEdit.ascx.vb" Inherits="SMP.StandardSampleReceiveEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .auto-style2 {
        width: 150px;
    }

    .auto-style3 {
        width: 150px;
        height: 26px;
    }

    .auto-style4 {
        height: 26px;
    }
</style>

<p></p>
<table class="auto-style1">
    <tr>
        <td class="auto-style3">期間</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbDateStart" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateStart_CalendarExtender" runat="server" TargetControlID="tbDateStart" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
            <asp:TextBox ID="tbDateEnd" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateEnd_CalendarExtender" runat="server" TargetControlID="tbDateEnd" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td>
            <asp:CheckBox ID="chkTopData" runat="server" Text="各時段取前幾筆資料" Checked="true" />
            &nbsp;<asp:TextBox ID="tbTopDataNum" runat="server" Width="43px">2</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">設備名稱</td>
        <td>
            <asp:TextBox ID="tbDeviceName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">查驗樣品</td>
        <td>
            <asp:TextBox ID="tbFK_SampleNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">分析程式</td>
        <td>
            <asp:TextBox ID="tbMethod" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="34px" Width="123px" />
            <asp:HiddenField ID="hfQryString" runat="server" />
            <asp:HiddenField ID="hfTopDataNum" runat="server" />
            <asp:HiddenField ID="hfSearchDate" runat="server" />
            <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="SMP.StandardSampleReceiveEdit" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料" DeleteMethod="CDBDelete" UpdateMethod="CDBUpdate">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfTopDataNum" Name="fromTopDataNum" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSearchDate" Name="fromSearchDate" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="爐號,站別,序號,日期時間,點序" DataSourceID="odsSearchResult">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf爐號" runat="server" Value='<%# Eval("爐號") %>' />
                <asp:HiddenField ID="hf站別" runat="server" Value='<%# Eval("站別") %>' />
                <asp:HiddenField ID="hf序號" runat="server" Value='<%# Eval("序號") %>' />
                <asp:HiddenField ID="hf點序" runat="server" Value='<%# Eval("點序") %>' />
                <asp:HiddenField ID="hfSample" runat="server" Value='<%# Eval("Sample") %>' />
                <asp:HiddenField ID="hfComments" runat="server" Value='<%# Eval("Comments") %>' />
                <asp:HiddenField ID="hfTask" runat="server" Value='<%# Eval("Task") %>' />
                <asp:HiddenField ID="hfFurance" runat="server" Value='<%# Eval("Furance") %>' />
                <asp:HiddenField ID="hfMelt" runat="server" Value='<%# Eval("Melt") %>' />
                <asp:HiddenField ID="hf鋼種" runat="server" Value='<%# Eval("鋼種") %>' />
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("Type") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show時間Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show點序Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="SampleMarkLabel" runat="server" Text='<%# Eval("SampleMark") %>' />
            </td>

            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift") %>' />
            </td>
            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method") %>' />
            </td>
            <td>
                <asp:Label ID="DeviceNameLabel" runat="server" Text='<%# Eval("DeviceName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_SampleNumberLabel" runat="server" Text='<%# Eval("FK_SampleNumber") %>' />
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
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
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
                <asp:Label ID="AsLabel" runat="server" Text='<%# Bind("As")%>' />
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

        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>


            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Bind("日期時間")%>' />
                <asp:HiddenField ID="hf爐號" runat="server" Value='<%# Bind("爐號") %>' />
                <asp:HiddenField ID="hf站別" runat="server" Value='<%# Bind("站別") %>' />
                <asp:HiddenField ID="hf序號" runat="server" Value='<%# Bind("序號") %>' />
                <asp:HiddenField ID="hf點序" runat="server" Value='<%# Bind("點序") %>' />
                <asp:HiddenField ID="hfSample" runat="server" Value='<%# Bind("Sample") %>' />
                <asp:HiddenField ID="hfComments" runat="server" Value='<%# Bind("Comments") %>' />
                <asp:HiddenField ID="hfTask" runat="server" Value='<%# Bind("Task") %>' />
                <asp:HiddenField ID="hfFurance" runat="server" Value='<%# Bind("Furance") %>' />
                <asp:HiddenField ID="hfMelt" runat="server" Value='<%# Bind("Melt") %>' />
                <asp:HiddenField ID="hf鋼種" runat="server" Value='<%# Bind("鋼種") %>' />
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Bind("Type") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show時間Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show點序Label" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="SampleMarkTextBox" runat="server" Text='<%# Bind("SampleMark")%>' />
            </td>


            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='<%# Bind("Shift")%>' />
            </td>


            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Bind("Method")%>' />
            </td>
            <td>
                <asp:Label ID="DeviceNameLabel" runat="server" Text='<%# Bind("DeviceName")%>' />
            </td>
            <td>
                <asp:Label ID="FK_SampleNumberLabel" runat="server" Text='<%# Bind("FK_SampleNumber")%>' />
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
                <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
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
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td></td>
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
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf爐號" runat="server" Value='<%# Eval("爐號") %>' />
                <asp:HiddenField ID="hf站別" runat="server" Value='<%# Eval("站別") %>' />
                <asp:HiddenField ID="hf序號" runat="server" Value='<%# Eval("序號") %>' />
                <asp:HiddenField ID="hf點序" runat="server" Value='<%# Eval("點序") %>' />
                <asp:HiddenField ID="hfComments" runat="server" Value='<%# Eval("Comments") %>' />
                <asp:HiddenField ID="hfTask" runat="server" Value='<%# Eval("Task") %>' />
                <asp:HiddenField ID="hfFurance" runat="server" Value='<%# Eval("Furance") %>' />
                <asp:HiddenField ID="hfMelt" runat="server" Value='<%# Eval("Melt") %>' />
                <asp:HiddenField ID="hf鋼種" runat="server" Value='<%# Eval("鋼種") %>' />
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("Type") %>' />


                <asp:Label ID="show日期Label" runat="server" />
            </td>

            <td>
                <asp:Label ID="show時間Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show點序Label" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="SampleMarkTextBox" runat="server" Text='<%# Bind("SampleMark")%>' />
            </td>

            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift")%>' />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method")%>' />
            </td>
            <td>
                <asp:Label ID="DeviceNameLabel" runat="server" Text='<%# Eval("DeviceName")%>' />
            </td>
            <td>
                <asp:Label ID="FK_SampleNumberLabel" runat="server" Text='<%# Eval("FK_SampleNumber")%>' />
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
                <asp:TextBox ID="N2TextBox" runat="server" Text='<%# Bind("N2") %>' />
            </td>
            <td>
                <asp:TextBox ID="O2TextBox" runat="server" Text='<%# Bind("O2") %>' />
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
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>


            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf爐號" runat="server" Value='<%# Eval("爐號") %>' />
                <asp:HiddenField ID="hf站別" runat="server" Value='<%# Eval("站別") %>' />
                <asp:HiddenField ID="hf序號" runat="server" Value='<%# Eval("序號") %>' />
                <asp:HiddenField ID="hf點序" runat="server" Value='<%# Eval("點序") %>' />
                <asp:HiddenField ID="hfSample" runat="server" Value='<%# Eval("Sample") %>' />
                <asp:HiddenField ID="hfComments" runat="server" Value='<%# Eval("Comments") %>' />
                <asp:HiddenField ID="hfTask" runat="server" Value='<%# Eval("Task") %>' />
                <asp:HiddenField ID="hfFurance" runat="server" Value='<%# Eval("Furance") %>' />
                <asp:HiddenField ID="hfMelt" runat="server" Value='<%# Eval("Melt") %>' />
                <asp:HiddenField ID="hf鋼種" runat="server" Value='<%# Eval("鋼種") %>' />
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("Type") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show時間Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show點序Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="SampleMarkLabel" runat="server" Text='<%# Eval("SampleMark")%>' />
            </td>


            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift") %>' />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method") %>' />
            </td>
            <td>
                <asp:Label ID="DeviceNameLabel" runat="server" Text='<%# Eval("DeviceName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_SampleNumberLabel" runat="server" Text='<%# Eval("FK_SampleNumber") %>' />
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
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
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
                <asp:Label ID="AsLabel" runat="server" Text='<%# Bind("As")%>' />
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
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>

                            <th id="Th1" runat="server">日期</th>
                            <th id="Th1B" runat="server">時間</th>
                            <th id="Th2" runat="server">班別</th>
                            <th id="Th2B" runat="server">點序</th>
                            <th id="Th2C" runat="server">樣品註記</th>
                            <th id="Th3" runat="server">分析人員</th>

                            <th id="Th5" runat="server">分析程式</th>
                            <th id="Th11" runat="server">設備名稱</th>
                            <th id="Th12" runat="server">查驗樣品</th>

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
                            <th runat="server">N2</th>
                            <th runat="server">O2</th>
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
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
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
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <cc1:ConfirmButtonExtender ID="btnSearch_ConfirmButtonExtender" runat="server"
                    ConfirmText="是否確定刪除?" TargetControlID="DeleteButton">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>

            <td>
                <asp:HiddenField ID="hf日期時間" runat="server" Value='<%# Eval("日期時間")%>' />
                <asp:HiddenField ID="hf爐號" runat="server" Value='<%# Eval("爐號") %>' />
                <asp:HiddenField ID="hf站別" runat="server" Value='<%# Eval("站別") %>' />
                <asp:HiddenField ID="hf序號" runat="server" Value='<%# Eval("序號") %>' />
                <asp:HiddenField ID="hf點序" runat="server" Value='<%# Eval("點序") %>' />
                <asp:HiddenField ID="hfSample" runat="server" Value='<%# Eval("Sample") %>' />
                <asp:HiddenField ID="hfComments" runat="server" Value='<%# Eval("Comments") %>' />
                <asp:HiddenField ID="hfTask" runat="server" Value='<%# Eval("Task") %>' />
                <asp:HiddenField ID="hfFurance" runat="server" Value='<%# Eval("Furance") %>' />
                <asp:HiddenField ID="hfMelt" runat="server" Value='<%# Eval("Melt") %>' />
                <asp:HiddenField ID="hf鋼種" runat="server" Value='<%# Eval("鋼種") %>' />
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("Type") %>' />

                <asp:Label ID="show日期Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show時間Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show班別Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="show點序Label" runat="server" />
            </td>
            <td>
                <asp:Label ID="SampleMarkLabel" runat="server" Text='<%# Eval("SampleMark")%>' />
            </td>

            <td>
                <asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift") %>' />
            </td>

            <td>
                <asp:Label ID="MethodLabel" runat="server" Text='<%# Eval("Method") %>' />
            </td>
            <td>
                <asp:Label ID="DeviceNameLabel" runat="server" Text='<%# Eval("DeviceName") %>' />
            </td>
            <td>
                <asp:Label ID="FK_SampleNumberLabel" runat="server" Text='<%# Eval("FK_SampleNumber") %>' />
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
                <asp:Label ID="N2Label" runat="server" Text='<%# Eval("N2") %>' />
            </td>
            <td>
                <asp:Label ID="O2Label" runat="server" Text='<%# Eval("O2") %>' />
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
                <asp:Label ID="AsLabel" runat="server" Text='<%# Bind("As")%>' />
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

        </tr>
    </SelectedItemTemplate>
</asp:ListView>

