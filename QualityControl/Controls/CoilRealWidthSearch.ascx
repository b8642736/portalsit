<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilRealWidthSearch.ascx.vb" Inherits="QualityControl.CoilRealWidthSearch" %>
<style type="text/css">
    .style1
    {
        width: 126px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
        鋼胚編號:
        </td>
        <td>
            <asp:TextBox ID="tbSLABNumber" runat="server" Width="143px"></asp:TextBox>
            (萬用字元&#39;*&#39; ex:A*-*40)</td>
    </tr>
    <tr>
        <td class="style1">
            熱軋批次:</td>
        <td>
            <asp:TextBox ID="tbLotsNumber" runat="server" Width="200px"></asp:TextBox>
            (請以設定範圍ex:T0001~T0002或單批T0001)</td>
    </tr>
    <tr>
        <td class="style1">
            AP1H公稱厚度:</td>
        <td>
            <asp:TextBox ID="tbStartThick" runat="server" Width="50px">0.0</asp:TextBox>
            ~<asp:TextBox ID="tbEndThick" runat="server" Width="50px">9.99</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種材質:</td>
        <td>
            <asp:TextBox ID="tbSteelKindType" runat="server" Width="200px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumber" runat="server" Width="200px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">平均量測點:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">第1點</asp:ListItem>
                        <asp:ListItem Value="1">第2點</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">第3點</asp:ListItem>
                        <asp:ListItem Value="3">第4點</asp:ListItem>
                        <asp:ListItem Value="4">第5點</asp:ListItem>
                        <asp:ListItem Value="5">第6點</asp:ListItem>
                    </asp:CheckBoxList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearch0" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" Width="100px" />
            <asp:HiddenField ID="hfControlSQLMaker" runat="server" />
            <asp:HiddenField ID="hfControlSQLMaker2" runat="server" />
            <asp:HiddenField ID="hfAvgPoints" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableViewState="False" 
    EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="鋼胚產日" HeaderText="鋼胚產日" SortExpression="鋼胚產日" />
        <asp:BoundField DataField="AP1H公稱厚度" HeaderText="AP1H公稱厚度" 
            SortExpression="AP1H公稱厚度" />
        <asp:BoundField DataField="AP1H_3寬度" HeaderText="AP1H_3寬度" 
            SortExpression="AP1H_3寬度" />
        <asp:BoundField DataField="AP1H邊夾寬" HeaderText="AP1H邊夾寬" 
            SortExpression="AP1H邊夾寬" />
        <asp:BoundField DataField="CR公稱厚度" HeaderText="CR公稱厚度" 
            SortExpression="CR公稱厚度" />
        <asp:BoundField DataField="CR寬度" HeaderText="CR寬度" SortExpression="CR寬度" />
        <asp:BoundField DataField="CR產線" HeaderText="CR產線" SortExpression="CR產線" />
        <asp:BoundField DataField="邊夾寬" HeaderText="邊夾寬" SortExpression="邊夾寬" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilRealWidthSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfControlSQLMaker" Name="SQLString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfControlSQLMaker2" Name="SQLString2" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfAvgPoints" Name="AVBPoints" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

