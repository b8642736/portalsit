<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilExamineRec.ascx.vb" Inherits="QualityControl.CoilExamineRec" %>
<style type="text/css">
    .style1
    {
        width: 86px;
    }
    </style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            熱軋批次:</td>
        <td>
            <asp:TextBox ID="tbBatchNumers" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="style1">
            追蹤線別:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">AP1H</asp:ListItem>
                <asp:ListItem Selected="True">AP2C</asp:ListItem>
                <asp:ListItem Selected="True">BALC</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            品檢員:</td>
        <td>
            <asp:TextBox ID="tbEmployees" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="style1">
            鋼種</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="追蹤線別" HeaderText="追蹤線別" SortExpression="追蹤線別" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="品檢員1" HeaderText="品檢員1" SortExpression="品檢員1" />
        <asp:BoundField DataField="品檢員2" HeaderText="品檢員2" SortExpression="品檢員2" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilExamineRec">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />






<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="Search1" TypeName="QualityControl.CoilExamineRec">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>







