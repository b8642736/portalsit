<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StoveElementSearch.ascx.vb" Inherits="QualityControl.StoveElementSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 137px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>熱軋批號:</td>
        <td>
            <asp:TextBox ID="tbLotsNumbers" runat="server" Width="225px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 )</td>
    </tr>
    <tr>
        <td>鋼種材質:</td>
        <td><asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
                (兩個以上以 &#39;,&#39; 分隔 ex:201TE1,301)
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp; DF:</td>
        <td>
            <asp:TextBox ID="txDF1" runat="server" Width="85px">-999</asp:TextBox>
            ~<asp:TextBox ID="txDF2" runat="server" Width="85px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp; MD30</td>
        <td>
            <asp:TextBox ID="txMD301" runat="server" Width="85px">-999</asp:TextBox>
            ~<asp:TextBox ID="txMD302" runat="server" Width="85px">999</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            爐號範圍:</td>
        <td>
            <asp:TextBox ID="tbStove" runat="server" Width="349px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔及以&#39;~&#39;指定範圍 Ex:A0001~A0010,B00001~B0010,...)<asp:CustomValidator 
                ID="CustomValidator1" runat="server" ControlToValidate="tbStove" 
                ErrorMessage="必須輸入資料!">必須輸入資料!</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            成份篩選:</td>
        <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="70px">
                                    <asp:ListItem Value="07">C</asp:ListItem>
                                    <asp:ListItem Value="08">Si</asp:ListItem>
                                    <asp:ListItem Value="09">Mn</asp:ListItem>
                                    <asp:ListItem Value="10">P</asp:ListItem>
                                    <asp:ListItem Value="11">S</asp:ListItem>
                                    <asp:ListItem Value="12">CR</asp:ListItem>
                                    <asp:ListItem Value="13">NI</asp:ListItem>
                                    <asp:ListItem Value="14">CU</asp:ListItem>
                                    <asp:ListItem Value="15">MO</asp:ListItem>
                                    <asp:ListItem Value="16">CO</asp:ListItem>
                                    <asp:ListItem Value="17">AL</asp:ListItem>
                                    <asp:ListItem Value="18">SN</asp:ListItem>
                                    <asp:ListItem Value="19">PB</asp:ListItem>
                                    <asp:ListItem Value="20">TI</asp:ListItem>
                                    <asp:ListItem Value="21">NB</asp:ListItem>
                                    <asp:ListItem Value="22">V</asp:ListItem>
                                    <asp:ListItem Value="23">W</asp:ListItem>
                                    <asp:ListItem Value="24">O2</asp:ListItem>
                                    <asp:ListItem Value="25">N2</asp:ListItem>
                                    <asp:ListItem Value="16">H2</asp:ListItem>
                                    <asp:ListItem Value="27">B</asp:ListItem>
                                    <asp:ListItem Value="28">Ca</asp:ListItem>
                                    <asp:ListItem Value="29">Mg</asp:ListItem>
                                    <asp:ListItem Value="30">Fe</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="tbElementStartValue" runat="server" Width="50" Text="0"></asp:TextBox>~
                                <asp:TextBox ID="tbElementEndValue" runat="server" Width="50" Text="9"></asp:TextBox>
                                <asp:Button ID="btnAddElement" runat="server" Text="加入篩選" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lbElements" Height="100px" Width="300px" runat="server"></asp:ListBox>
                                <asp:Button ID="btnDeleteElement" runat="server" Text="移除篩選" />
                            </td>
                        </tr>
                    </table>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="期間:" TextAlign="Left" /></td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                TargetControlID="tbStartDate" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbStartHour" runat="server" Width="20px">08</asp:TextBox>
            <cc1:CalendarExtender ID="tbStartHour_CalendarExtender" runat="server" 
                TargetControlID="tbStartHour" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            時<asp:TextBox ID="tbStartMinute" runat="server" Width="20px">00</asp:TextBox>
            <cc1:CalendarExtender ID="tbStartMinute_CalendarExtender" runat="server" 
                TargetControlID="tbStartMinute" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            分~<asp:TextBox ID="tbEndDate" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                TargetControlID="tbEndDate" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            日<asp:TextBox ID="tbEndHour" runat="server" Width="20px">07</asp:TextBox>
            <cc1:CalendarExtender ID="tbEndHour_CalendarExtender" runat="server" 
                TargetControlID="tbEndHour" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            時<asp:TextBox ID="tbEndMinute" runat="server" Width="20px">59</asp:TextBox>
            <cc1:CalendarExtender ID="tbEndMinute_CalendarExtender" runat="server" 
                TargetControlID="tbEndMinute" Format="yyyy/MM/dd" >
            </cc1:CalendarExtender>
            分</td>
    </tr>
    <tr>
        <td class="style1">輸出格式:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">預設格式</asp:ListItem>
                <asp:ListItem Value="1">顯示平均</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
                    </td>
    </tr>
</table>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
                <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" />
                <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" />
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
                <asp:BoundField DataField="SI" HeaderText="SI" SortExpression="SI" />
                <asp:BoundField DataField="MN" HeaderText="MN" SortExpression="MN" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="CR" HeaderText="CR" SortExpression="CR" />
                <asp:BoundField DataField="NI" HeaderText="NI" SortExpression="NI" />
                <asp:BoundField DataField="CU" HeaderText="CU" SortExpression="CU" />
                <asp:BoundField DataField="MO" HeaderText="MO" SortExpression="MO" />
                <asp:BoundField DataField="CO" HeaderText="CO" SortExpression="CO" />
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="PB" HeaderText="PB" SortExpression="PB" />
                <asp:BoundField DataField="TI" HeaderText="TI" SortExpression="TI" />
                <asp:BoundField DataField="NB" HeaderText="NB" SortExpression="NB" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" />
                <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
                <asp:BoundField DataField="H2" HeaderText="H2" SortExpression="H2" />
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
                <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
                <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="QualityControl.StoveElementSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult1" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
                <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" />
                <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" />
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
                <asp:BoundField DataField="SI" HeaderText="SI" SortExpression="SI" />
                <asp:BoundField DataField="MN" HeaderText="MN" SortExpression="MN" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="CR" HeaderText="CR" SortExpression="CR" />
                <asp:BoundField DataField="NI" HeaderText="NI" SortExpression="NI" />
                <asp:BoundField DataField="CU" HeaderText="CU" SortExpression="CU" />
                <asp:BoundField DataField="MO" HeaderText="MO" SortExpression="MO" />
                <asp:BoundField DataField="CO" HeaderText="CO" SortExpression="CO" />
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="PB" HeaderText="PB" SortExpression="PB" />
                <asp:BoundField DataField="TI" HeaderText="TI" SortExpression="TI" />
                <asp:BoundField DataField="NB" HeaderText="NB" SortExpression="NB" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" />
                <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
                <asp:BoundField DataField="H2" HeaderText="H2" SortExpression="H2" />
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
                <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
                <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
            SelectMethod="Search1" TypeName="QualityControl.StoveElementSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfSQLString" runat="server" />
<asp:HiddenField ID="hfDFAndMD30Range" runat="server" />

