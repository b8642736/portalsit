<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProcessToWebClientPCAccountEdit.ascx.vb" Inherits="ColdRollingProcess.ProcessToWebClientPCAccountEdit" %>
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
            電腦名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            (例:PC1)</td>
    </tr>
    <tr>
        <td class="style1">
            電腦IP:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            (例:XXX.XXX.XXX.XXX,XXX.XXX...)</td>
    </tr>
    <tr>
        <td class="style1">
            備註:</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
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
                DataKeyNames="ClientIP">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="加入" ShowSelectButton="True" />
                    <asp:BoundField DataField="ClientIP" HeaderText="電腦IP" 
                        SortExpression="ClientIP" />
                    <asp:BoundField DataField="PCName" HeaderText="電腦名稱" 
                        SortExpression="PCName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註" 
                        SortExpression="Memo1" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
                SelectMethod="Search1" 
                TypeName="ColdRollingProcess.ProcessToWebClientPCAccountEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString1" Name="QryString" 
                        PropertyName="Value" Type="String" />
                    <asp:SessionParameter Name="CurrentProcessSchedualID" 
                        SessionField="_ProcessSchedualID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        <td>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="odsSearchResult2" 
                EnableModelValidation="True" PageSize="15" DataKeyNames="ClientIP">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="移除" ShowSelectButton="True" />
                    <asp:BoundField DataField="ClientIP" HeaderText="電腦IP" 
                        SortExpression="ClientIP" />
                    <asp:BoundField DataField="PCName" HeaderText="電腦名稱" 
                        SortExpression="PCName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註" 
                        SortExpression="Memo1" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsSearchResult2" runat="server" 
                SelectMethod="Search2" 
                TypeName="ColdRollingProcess.ProcessToWebClientPCAccountEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString2" Name="QryString" 
                        PropertyName="Value" Type="String" />
                    <asp:SessionParameter Name="CurrentProcessSchedualID" 
                        SessionField="_ProcessSchedualID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>

</table>


