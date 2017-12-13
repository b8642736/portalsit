<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ExpenseOfDepartment.ascx.vb" Inherits="Accounting.ExpenseOfDepartment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<style type="text/css">
    .auto-style1
    {
        height: 30px;
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
        <td class="auto-style1">
            資料類別:</td>
        <td class="auto-style1">
            <asp:RadioButtonList ID="rdDisplayType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Sum" Selected="True">單位統計</asp:ListItem>
                <asp:ListItem Value="Detail">清單明細</asp:ListItem>
                <asp:ListItem Value="Detail2">傳票明細</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            部門:</td>
        <td>
            <asp:TextBox ID="tbDept" runat="server"></asp:TextBox>
            &nbsp;(兩個以上以&nbsp; &#39;,&#39; 分隔 )</td>
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
<p>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="會計科目" HeaderText="會計科目" SortExpression="會計科目" />
            <asp:BoundField DataField="明細科目" HeaderText="明細科目" SortExpression="明細科目" />
            <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位" />
            <asp:BoundField DataField="金額" HeaderText="金額" SortExpression="金額" />
        </Columns>
    </asp:GridView>--%>
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True" >
    </asp:GridView>
    
</p>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Accounting.ExpenseOfDepartment">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQtemp_Acd010P2" Name="fromSQLQtemp_Acd010P2" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQtemp_Qqr1" Name="fromSQLQtemp_Qqr1" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="rdDisplayType" Name="fromDisplayType" PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="tbDept" Name="fromDisplayDept" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="hfQryAcd010pf" Name="fromQryAcd010pf" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--<asp:HiddenField ID="hfQry5141InMtst01pf" runat="server" />
<asp:HiddenField ID="hfQry5141NotInMtst01pf_A" runat="server" />
<asp:HiddenField ID="hfQry5141NotInMtst01pf_B" runat="server" />
<asp:HiddenField ID="hfQryOtherInMtst01pf" runat="server" />--%>

<asp:HiddenField ID="hfQtemp_Acd010P2" runat="server" />
<asp:HiddenField ID="hfQtemp_Qqr1" runat="server" />

<asp:HiddenField ID="hfQryDisplayType" runat="server" />
<asp:HiddenField ID="hfQryDisplayDept" runat="server" />
<asp:HiddenField ID="hfQryAcd010pf" runat="server" />