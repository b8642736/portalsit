<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ExpenseDetailSearch.ascx.vb" Inherits="Accounting.ExpenseDetailSearch" %>
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
            <%--<cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>--%>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <%--<cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>--%>
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
        <td class="style1">明細科目:</td>
        <td>
            <asp:TextBox ID="tbDETLNO" runat="server" Width="250px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">費用單位:</td>
        <td>
            <asp:TextBox ID="tbDEPTNO" runat="server" Width="250px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="style1">使用單位:</td>
        <td>
            <asp:TextBox ID="tbUseDepts" runat="server" Width="250px"></asp:TextBox>
            (兩個以上以&nbsp; &#39;,&#39; 分隔 或 以&#39;*&#39;取代其細項單位(EX:W*)</td>
    </tr>
    <tr>
        <td class="style1">廠別:</td>
        <td>
            <asp:RadioButtonList ID="rblFactory" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">SA</asp:ListItem>
                <asp:ListItem>AA</asp:ListItem>
                <asp:ListItem>QA</asp:ListItem>
            </asp:RadioButtonList>
        </td>
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
        <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
        <asp:BoundField DataField="使用單位" HeaderText="使用單位" SortExpression="使用單位" />
        <asp:BoundField DataField="固定金額" HeaderText="固定金額" SortExpression="固定金額" />
        <asp:BoundField DataField="變動金額" HeaderText="變動金額" SortExpression="變動金額" />
        <asp:BoundField DataField="摘要" HeaderText="摘要" SortExpression="摘要" />
        <asp:BoundField DataField="入帳日期" HeaderText="入帳日期" SortExpression="入帳日期" />
        <asp:BoundField DataField="傳票編號" HeaderText="傳票編號" SortExpression="傳票編號" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Accounting.ExpenseDetailSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SqlString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
                <asp:HiddenField ID="hfQryString" runat="server" />
                


