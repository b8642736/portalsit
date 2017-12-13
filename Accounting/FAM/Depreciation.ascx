<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Depreciation.ascx.vb" Inherits="Accounting.Depreciation" %>
<p>
    <table style="width:100%;">
        <tr>
            <td>
                <span lang="zh-tw">廠別:</span></td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem Selected="True">SA</asp:ListItem>
                            <asp:ListItem>AA</asp:ListItem>
                            <asp:ListItem>AB</asp:ListItem>
                            <asp:ListItem>BA</asp:ListItem>
                            <asp:ListItem>QA</asp:ListItem>
                            <asp:ListItem>NA</asp:ListItem>
                            <asp:ListItem>RA</asp:ListItem>
                            <asp:ListItem>RC</asp:ListItem>
                            <asp:ListItem>RD</asp:ListItem>
                            <asp:ListItem>全部</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td>狀態:</td>
        <td>
            <asp:CheckBoxList ID="CheckBoxList2" runat="server" 
                RepeatDirection="Horizontal" Width="207px">
                <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">閒置</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">出租</asp:ListItem>
            </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <span lang="zh-tw">單位:</span>
                    </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="16" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                        <asp:Button ID="btnSelectAll" runat="server" Text="全選" Width="80px" />
                        <asp:Button ID="btnClearAll" runat="server" Text="全部清除" Width="80px" />
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="執行查詢" />
                <asp:Button ID="btnExcelFileDownload" runat="server" Text="Excel檔案轉換下載" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</p>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="ODSSearchReslut" CellPadding="4" 
    ForeColor="#333333" GridLines="None" PageSize="30">
    <PagerSettings PageButtonCount="20" Position="Top" />
    <RowStyle BackColor="#E3EAEB" />
    <Columns>
        <asp:BoundField DataField="DisplayName" HeaderText="項次" 
            SortExpression="DisplayName" />
        <asp:BoundField DataField="DEPTSA" HeaderText="單位代碼" 
            SortExpression="DEPTSA" />
        <asp:BoundField DataField="Number" HeaderText="資產編號" 
            SortExpression="Number" >
        </asp:BoundField>
        <asp:BoundField DataField="Name" HeaderText="資產名稱" 
            SortExpression="Name" />
        <asp:BoundField DataField="Quant" HeaderText="數量" SortExpression="Quant" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="Amount" HeaderText="帳面金額" SortExpression="Amount" 
            DataFormatString="{0:###,###.00}" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="StartDate" HeaderText="入帳年月" 
            SortExpression="StartDate" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="Uslaff" HeaderText="使用年限" 
            SortExpression="Uslaff" />
        <asp:BoundField DataField="Depr" HeaderText="本月累計折舊" 
            SortExpression="Depr" DataFormatString="{0:###,###.00}" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="ThisMonthDepr" HeaderText="本月折舊" 
            SortExpression="ThisMonthDepr" DataFormatString="{0:###,###.00}" 
            ReadOnly="True" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="ACD2_ChineseName" HeaderText="狀態" 
            SortExpression="ACD2_ChineseName" />
    </Columns>
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<asp:ObjectDataSource ID="ODSSearchReslut" runat="server" SelectMethod="Search" 
    TypeName="Accounting.DepreciationDisplayItem" EnableCaching="True">
    <SelectParameters>
        <asp:ControlParameter ControlID="RadioButtonList1" Name="FactoryName" 
            PropertyName="SelectedValue" Type="String" />
        <asp:Parameter Name="SearchDepartmentString" Type="String" />
        <asp:Parameter Name="SearchACD2String" />
    </SelectParameters>
</asp:ObjectDataSource>

