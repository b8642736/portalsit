<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ExpenseSearch.ascx.vb" Inherits="Accounting.ExpenseSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 121px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            入帳期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            會計科目:</td>
        <td>
            <asp:TextBox ID="tbACCTNO" runat="server"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                <asp:Button ID="btnExcelFileDownload" runat="server" Text="Excel檔案轉換下載" />
            </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="會計科目" HeaderText="會計科目" SortExpression="會計科目" />
        <asp:BoundField DataField="明細科目" HeaderText="明細科目" SortExpression="明細科目" />
        <asp:BoundField DataField="成本單位" HeaderText="成本單位" SortExpression="成本單位" />
        <asp:BoundField DataField="固定金額" HeaderText="固定金額" SortExpression="固定金額" />
        <asp:BoundField DataField="變動金額" HeaderText="變動金額" SortExpression="變動金額" />
        <asp:BoundField DataField="固定預算" HeaderText="固定預算" SortExpression="固定預算" />
        <asp:BoundField DataField="變動預算" HeaderText="變動預算" 
            SortExpression="變動預算" />
        <asp:BoundField DataField="科目明細說明" HeaderText="科目明細說明" 
            SortExpression="科目明細說明" />
        <asp:BoundField DataField="狀態說明" HeaderText="狀態說明" SortExpression="狀態說明" />
    </Columns>
    <RowStyle HorizontalAlign="Right" />
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Accounting.ExpenseSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SqlString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQryString0" Name="SqlString0" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQryString1" Name="SqlString1" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
                <asp:HiddenField ID="hfQryString" runat="server" />
                

                <asp:HiddenField ID="hfQryString0" runat="server" />
                

                <asp:HiddenField ID="hfQryString1" runat="server" />
                

