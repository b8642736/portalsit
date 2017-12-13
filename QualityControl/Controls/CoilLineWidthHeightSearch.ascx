<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilLineWidthHeightSearch.ascx.vb" Inherits="QualityControl.CoilLineWidthHeightSearch" %>
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
                    (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            公稱厚度:</td>
        <td>
            <asp:TextBox ID="tbStartThick" runat="server" Width="70px">0.0</asp:TextBox>
            ~<asp:TextBox ID="tbEndThick" runat="server" Width="70px">9.99</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            公稱寬度:</td>
        </td>
        <td>
            <asp:TextBox ID="tbStartWidth" runat="server" Width="70px">0</asp:TextBox>
            ~<asp:TextBox ID="tbEndWidth" runat="server" Width="70px">9999</asp:TextBox>
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
        <td>產線:</td>
        <td>
            <asp:TextBox ID="tbProductLines" runat="server" Width="200px"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="標準差計算點:" TextAlign="Left" /></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="H1">厚度1</asp:ListItem>
                        <asp:ListItem Value="H2">厚度2</asp:ListItem>
                        <asp:ListItem Value="H3">厚度3</asp:ListItem>
                        <asp:ListItem Value="H4">厚度4</asp:ListItem>
                        <asp:ListItem Value="H5">厚度5</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="W1">寬度1</asp:ListItem>
                        <asp:ListItem Value="W2">寬度2</asp:ListItem>
                        <asp:ListItem Value="W3">寬度3</asp:ListItem>
                        <asp:ListItem Value="W4">寬度4</asp:ListItem>
                        <asp:ListItem Value="W5">寬度5</asp:ListItem>
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
            <asp:HiddenField ID="hfControlSTDArgs" runat="server" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" EnableViewState="False" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="鋼胚產日" HeaderText="鋼胚產日" SortExpression="鋼胚產日" />
        <asp:BoundField DataField="產線別" HeaderText="產線別" SortExpression="產線別" />
        <asp:BoundField DataField="公稱厚度" HeaderText="公稱厚度" SortExpression="公稱厚度" />
        <asp:BoundField DataField="厚度1" HeaderText="厚度1" SortExpression="厚度1" />
        <asp:BoundField DataField="厚度2" HeaderText="厚度2" SortExpression="厚度2" />
        <asp:BoundField DataField="厚度3" HeaderText="厚度3" SortExpression="厚度3" />
        <asp:BoundField DataField="厚度4" HeaderText="厚度4" SortExpression="厚度4" />
        <asp:BoundField DataField="厚度5" HeaderText="厚度5" SortExpression="厚度5" />
        <asp:BoundField DataField="寬度1" HeaderText="寬度1" SortExpression="寬度1" />
        <asp:BoundField DataField="寬度2" HeaderText="寬度2" SortExpression="寬度2" />
        <asp:BoundField DataField="寬度3" HeaderText="寬度3" SortExpression="寬度3" />
        <asp:BoundField DataField="寬度4" HeaderText="寬度4" SortExpression="寬度4" />
        <asp:BoundField DataField="寬度5" HeaderText="寬度5" SortExpression="寬度5" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilLineWidthHeightSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfControlSQLMaker" Name="SQLString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfControlSTDArgs" Name="STDArgs" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>