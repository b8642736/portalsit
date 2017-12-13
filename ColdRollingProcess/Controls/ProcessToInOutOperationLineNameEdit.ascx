<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProcessToInOutOperationLineNameEdit.ascx.vb" Inherits="ColdRollingProcess.ProcessToInOutOperationLineNameEdit" %>
<style type="text/css">
    .style1
    {
        width: 242px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td colspan="2">
        <table style="width:100%;">
    <tr>
        <td class="style1">
            上一站之下一站產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            (例:AP1H)</td>
    </tr>
    <tr>
        <td class="style1">
            上一站之處理後表面:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            (例:NO1)</td>
    </tr>
    <tr>
        <td class="style1">
            處理過後的產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            (例:NO1)</td>
    </tr>
    <tr>
        <td class="style1">
            處理過後的下一站產線名稱:</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            (例:AP1H)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="未加入查詢篩選" Width="100px" />
            <asp:Button ID="btnSearch0" runat="server" Text="已加入查詢篩選" Width="100px" />
            <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
                        <asp:HiddenField ID="hfQryString1" runat="server" />
                        <asp:HiddenField ID="hfQryString2" runat="server" />
                    </td>
    </tr>
</table>

        </td>
    </tr>
    <tr>
        <td>
            未加入名稱轉換</td>
        <td>
            已加入名稱轉換</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="odsSearchResult1" 
                EnableModelValidation="True" PageSize="15" style="margin-right: 0px" 
                DataKeyNames="ID">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="加入" ShowSelectButton="True" />
                    <asp:BoundField DataField="InNextOperationLineName" HeaderText="上一站之下一站產線名稱" 
                        SortExpression="InNextOperationLineName" />
                    <asp:BoundField DataField="InCurrentFish" HeaderText="上一站之處理後表面" 
                        SortExpression="InCurrentFish" />
                    <asp:BoundField DataField="OutOperationLineName" HeaderText="處理後產線名稱" 
                        SortExpression="OutOperationLineName" />
                    <asp:BoundField DataField="OutNextOperationLineName" HeaderText="處理後下站產線名稱" 
                        SortExpression="OutNextOperationLineName" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
                SelectMethod="Search1" 
                TypeName="ColdRollingProcess.ProcessToInOutOperationLineNameEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString1" Name="QryString" 
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        <td>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="odsSearchResult2" 
                EnableModelValidation="True" PageSize="15" DataKeyNames="ID">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="移除" ShowSelectButton="True" />
                    <asp:BoundField DataField="InNextOperationLineName" HeaderText="上一站之下一站產線名稱" 
                        SortExpression="InNextOperationLineName" />
                    <asp:BoundField DataField="InCurrentFish" HeaderText="上一站之處理後表面" 
                        SortExpression="InCurrentFish" />
                    <asp:BoundField DataField="OutOperationLineName" HeaderText="處理後產線名稱" 
                        SortExpression="OutOperationLineName" />
                    <asp:BoundField DataField="OutNextOperationLineName" HeaderText="處理後下站產線名稱" 
                        SortExpression="OutNextOperationLineName" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsSearchResult2" runat="server" 
                SelectMethod="Search2" 
                TypeName="ColdRollingProcess.ProcessToInOutOperationLineNameEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString2" Name="QryString" 
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>

</table>

