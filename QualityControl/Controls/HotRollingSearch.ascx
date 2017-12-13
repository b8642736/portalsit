<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HotRollingSearch.ascx.vb" Inherits="QualityControl.HotRollingSearch" %>
<style type="text/css">
    .style1
    {
        width: 116px;
        text-align:right;
    }
</style>
<link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
<table style="width:100%;">
    <tr>
        <td class="style1">
            熱軋批次:</td>
        <td>
            <asp:TextBox ID="tbLotsNumbers" runat="server"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)<asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLotsNumbers" 
                ErrorMessage="欄位必須有值">欄位必須有值</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201,301)</td>
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
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="批號" HeaderText="批號" SortExpression="批號" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="切號" HeaderText="切號" SortExpression="切號" />
        <asp:BoundField DataField="項目" HeaderText="項目" SortExpression="項目" />
        <asp:BoundField DataField="肧重" HeaderText="肧重" SortExpression="肧重" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="平均厚度" HeaderText="平均厚度" SortExpression="平均厚度" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="平均寬度" HeaderText="平均寬度" SortExpression="平均寬度" />
        <asp:BoundField DataField="捲重" HeaderText="捲重" SortExpression="捲重" />
        <asp:BoundField DataField="軋數" HeaderText="軋數" SortExpression="軋數" />
        <asp:BoundField DataField="出爐溫度" HeaderText="出爐溫度" SortExpression="出爐溫度" />
        <asp:BoundField DataField="在爐時間" HeaderText="在爐時間" SortExpression="在爐時間" />
        <asp:BoundField DataField="捲機" HeaderText="捲機" SortExpression="捲機" />
        <asp:BoundField DataField="攤檢記錄" HeaderText="攤檢記錄" SortExpression="攤檢記錄" />
        <asp:BoundField DataField="C25" HeaderText="C25" SortExpression="C25" />
        <asp:BoundField DataField="W25" HeaderText="W25" SortExpression="W25" />
        <asp:BoundField DataField="C40" HeaderText="C40" SortExpression="C40" />
        <asp:BoundField DataField="WEDGE" HeaderText="WEDGE" SortExpression="WEDGE" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.HotRollingSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />


