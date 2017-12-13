<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CSSearch.ascx.vb" Inherits="QualityControl.CSSearch" %>
<style type="text/css">
    .auto-style1 {
        width: 160px;
        text-align:right;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="cbSUA06" runat="server" Text="業務收文日:" TextAlign="Left" Checked="True" />
        </td>
        <td>
            <asp:TextBox ID="tbSUA06StartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbSUA06EndDate" runat="server" Width="100px"></asp:TextBox>
            (民國年 ex:1050101~1050131)</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="cbSUA37" runat="server" Text="品管簽結日:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbSUA37StartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbSUA37EndDate" runat="server" Width="100px"></asp:TextBox>
            (民國年 ex:1050101~1050131)</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="cbSUA07" runat="server" Text="結案日:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbSUA07StartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbSUA07EndDate" runat="server" Width="100px"></asp:TextBox>
            (民國年 ex:1050101~1050131)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>


</table>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="繳庫時間" HeaderText="繳庫時間" SortExpression="繳庫時間" />
        <asp:BoundField DataField="客訴案號" HeaderText="客訴案號" SortExpression="客訴案號" />
        <asp:BoundField DataField="代碼" HeaderText="代碼" SortExpression="代碼" />
        <asp:BoundField DataField="客戶" HeaderText="客戶" SortExpression="客戶" />
        <asp:BoundField DataField="鋼捲編號" HeaderText="鋼捲編號" SortExpression="鋼捲編號" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="責任單位" HeaderText="責任單位" SortExpression="責任單位" />
        <asp:BoundField DataField="缺陷編號" HeaderText="缺陷編號" SortExpression="缺陷編號" />
        <asp:BoundField DataField="缺陷" HeaderText="缺陷" SortExpression="缺陷" />
        <asp:BoundField DataField="折讓方式" HeaderText="折讓方式" SortExpression="折讓方式" />
        <asp:BoundField DataField="要求重量" HeaderText="要求重量" SortExpression="要求重量" />
        <asp:BoundField DataField="要求金額" HeaderText="要求金額" SortExpression="要求金額" />
        <asp:BoundField DataField="核定重量" HeaderText="核定重量" SortExpression="核定重量" />
        <asp:BoundField DataField="核定金額" HeaderText="核定金額" SortExpression="核定金額" />
        <asp:BoundField DataField="業務收文" HeaderText="業務收文" SortExpression="業務收文" />
        <asp:BoundField DataField="品管查驗" HeaderText="品管查驗" SortExpression="品管查驗" />
        <asp:BoundField DataField="品管簽結" HeaderText="品管簽結" SortExpression="品管簽結" />
        <asp:BoundField DataField="結案日" HeaderText="結案日" SortExpression="結案日" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQuery" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="QualityControl.CSSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQuery" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


