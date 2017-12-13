<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductionStartCmdSearch.ascx.vb" Inherits="ColdRollingProcess.ProductionStartCmdSearch" %>
<style type="text/css">
    .style1
    {
        width: 99px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            線別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem>CPL</asp:ListItem>
                <asp:ListItem>APL</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            鋼種+TYPE:</td>
        <td>
            <asp:TextBox ID="tbSteelKindType" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔,EX:304L,201,...)</td>
    </tr>
    <tr>
        <td class="style1">
            黑皮寬度:</td>
        <td>
            <asp:TextBox ID="tbWidth" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔)</td>
    </tr>
    <tr>
        <td class="style1">
            黑皮厚:</td>
        <td>
            <asp:TextBox ID="tbThick" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區隔)</td>
    </tr>
    <tr>
        <td class="style1">
            處理程序:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">組合料</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">黑皮直軋</asp:ListItem>
                <asp:ListItem Selected="True" Value="3">直投ZML</asp:ListItem>
                <asp:ListItem Selected="True" Value="4">直投NO1</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style1">數量篩選:</td>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" 
                Text="生計派工量+現場派工量 需大於零" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="優先順序" HeaderText="優先順序" SortExpression="優先順序" />
        <asp:BoundField DataField="線別" HeaderText="線別" SortExpression="線別" />
        <asp:BoundField DataField="鋼種Type" HeaderText="鋼種Type" 
            SortExpression="鋼種Type" />
        <asp:BoundField DataField="黑皮寬度" HeaderText="黑皮寬度" SortExpression="黑皮寬度" />
        <asp:BoundField DataField="黑皮厚度" HeaderText="黑皮厚度" SortExpression="黑皮厚度" />
        <asp:BoundField DataField="生技派工量" HeaderText="生計派工量" SortExpression="生技派工量" />
        <asp:BoundField DataField="現場派工量" HeaderText="現場派工量" SortExpression="現場派工量" />
        <asp:BoundField DataField="處理程序" HeaderText="處理程序" SortExpression="處理程序" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfAS400Qry" runat="server" />
<asp:HiddenField ID="hfSQLQry" runat="server" />
<asp:HiddenField ID="hfIsDispatchNoneZero" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="ColdRollingProcess.ProductionStartCmdSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfAS400Qry" Name="AS400SQLString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfSQLQry" Name="SQLSQLString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfIsDispatchNoneZero" 
            Name="IsDispatchNoneZero" PropertyName="Value" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>


