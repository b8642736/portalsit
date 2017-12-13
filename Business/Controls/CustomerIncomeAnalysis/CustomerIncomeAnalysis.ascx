<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomerIncomeAnalysis.ascx.vb" Inherits="Business.CustomerIncomeAnalysis" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 132px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            發票日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownLoadExcel" runat="server" Text="下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%">
    <Columns>
        <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" />
        <asp:BoundField DataField="客戶" HeaderText="客戶" SortExpression="客戶" />
        <asp:BoundField DataField="CR/HR" HeaderText="CR/HR" 
            SortExpression="CR_HR" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
        <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="收入" HeaderText="收入" SortExpression="收入" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="預估加工外銷沖退" HeaderText="預估加工外銷沖退" 
            SortExpression="預估加工外銷沖退" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="固定成本" HeaderText="固定成本" SortExpression="固定成本" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="匯差" HeaderText="匯差" SortExpression="匯差" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="履約獎勵" HeaderText="履約獎勵" SortExpression="履約獎勵" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="變動成本" HeaderText="變動成本" SortExpression="變動成本" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="客戶貢獻度" HeaderText="客戶貢獻度" SortExpression="客戶貢獻度" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="毛利" HeaderText="毛利" SortExpression="毛利" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
            <asp:HiddenField ID="hfQry" runat="server" />
            <asp:HiddenField ID="hfQryACSSKBLA" runat="server" />
            <asp:HiddenField ID="hfQrySL3X04PF" runat="server" />
            <asp:HiddenField ID="hfQrySL2EXRPF" runat="server" />
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search" TypeName="Business.CustomerIncomeAnalysis">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
                    Type="String" />
                <asp:ControlParameter ControlID="hfQryACSSKBLA" Name="ACSSKBPFResultSQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfQrySL3X04PF" Name="SL3X04PFResultSQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfQrySL2EXRPF" Name="SL2EXRPFResultSQLString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
</asp:ObjectDataSource>


