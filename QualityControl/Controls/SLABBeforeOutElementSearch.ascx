<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SLABBeforeOutElementSearch.ascx.vb" Inherits="QualityControl.SLABBeforeOutElementSearch" %>
<style type="text/css">
    .style1
    {
        width: 106px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            批號:</td>
        <td>
            <asp:TextBox ID="btBatchNumber" runat="server" Width="227px"></asp:TextBox>
                        (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">狀態:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>進入CCM</asp:ListItem>
                <asp:ListItem Value="A">研磨中</asp:ListItem>
                <asp:ListItem Selected="True" Value="B">繳庫可外送</asp:ListItem>
                <asp:ListItem Value="C">已外送</asp:ListItem>
                <asp:ListItem Value="*">回廠或繳庫</asp:ListItem>
                <asp:ListItem Value="R">重磨</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="252px"></asp:TextBox>
        (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            元素加入篩選:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="False" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="&amp;">並且</asp:ListItem>
                <asp:ListItem Value="|">或</asp:ListItem>
            </asp:RadioButtonList>
            <asp:DropDownList ID="DropDownList2" runat="server" Width="60px">
                <asp:ListItem Value="MD">MD30</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem Value="QCA07">C</asp:ListItem>
                <asp:ListItem Value="QCA08">SI</asp:ListItem>
                <asp:ListItem Value="QCA09">MN</asp:ListItem>
                <asp:ListItem Value="QCA10">P</asp:ListItem>
                <asp:ListItem Value="QCA11">S</asp:ListItem>
                <asp:ListItem Value="QCA12">CR</asp:ListItem>
                <asp:ListItem Value="QCA13">NI</asp:ListItem>
                <asp:ListItem Value="QCA14">CU</asp:ListItem>
                <asp:ListItem Value="QCA15">MO</asp:ListItem>
                <asp:ListItem Value="QCA16">CO</asp:ListItem>
                <asp:ListItem Value="QCA17">AL</asp:ListItem>
                <asp:ListItem Value="QCA18">SN</asp:ListItem>
                <asp:ListItem Value="QCA19">PB</asp:ListItem>
                <asp:ListItem Value="QCA20">TI</asp:ListItem>
                <asp:ListItem Value="QCA21">NB</asp:ListItem>
                <asp:ListItem Value="QCA22">V</asp:ListItem>
                <asp:ListItem Value="QCA23">W</asp:ListItem>
                <asp:ListItem Value="QCA24">O2</asp:ListItem>
                <asp:ListItem Value="QCA25">N2</asp:ListItem>
                <asp:ListItem Value="QCA26">H2</asp:ListItem>
                <asp:ListItem Value="QCA27">B</asp:ListItem>
                <asp:ListItem Value="QCA28">Ca</asp:ListItem>
                <asp:ListItem Value="QCA29">Mg</asp:ListItem>
                <asp:ListItem Value="QCA30">Fe</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="&gt;=">大於等於</asp:ListItem>
                <asp:ListItem Value="&lt;=">小於等於</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox2" runat="server" Width="121px"></asp:TextBox>
            <asp:Button ID="btnADD" runat="server" Text="加入篩選" Width="78px" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style1">
            已加入篩選:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBox1" runat="server" Height="64px" Width="263px" 
                    AutoPostBack="True">
                </asp:ListBox>
                <asp:Button ID="btnRemove" runat="server" Enabled="False" Text="移除篩選" />
                <asp:Button ID="btnRemove0" runat="server" Text="全部移除" />
            </ContentTemplate>
            </asp:UpdatePanel>  
        </td>
    </tr>
    <tr>
        <td class="style1">
            訊息:</td>
        <td>
            <asp:Label ID="lbMessage" runat="server" ForeColor="#FF3300"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="批次" HeaderText="批次" SortExpression="批次" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
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
    TypeName="QualityControl.SLABBeforeOutElementSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfControlWhereMaker" Name="WhereAfterString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfControlWhereMaker" runat="server" />

<asp:HiddenField ID="hfDFAndMD30Range" runat="server" />


