<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MonitorClientPCEdit.ascx.vb" Inherits="SMP.MonitorClientPCEdit" %>
<table style="width:100%;">
    <tr>
        <td>
            未監看PC</td>
        <td>
            已監看PC</td>
    </tr>
    <tr>
        <td >
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                DataSourceID="LDSUnMonitorClientPC" AutoGenerateColumns="False" 
                DataKeyNames="ClientIP">
                <Columns>
                    <asp:BoundField DataField="ClientIP" HeaderText="用戶端IP" ReadOnly="True" 
                        SortExpression="ClientIP" />
                    <asp:BoundField DataField="PCName" HeaderText="電腦名稱" SortExpression="PCName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
                    <asp:CommandField ButtonType="Button" SelectText="加入監看" 
                        ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td >
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="ClientIP" 
                DataSourceID="LDSMonitorClientPC">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="移除監看" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="ClientIP" HeaderText="用戶端IP" ReadOnly="True" 
                        SortExpression="ClientIP" />
                    <asp:BoundField DataField="PCName" HeaderText="電腦名稱" SortExpression="PCName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSUnMonitorClientPC" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebClientPCAccount">
</asp:LinqDataSource>

<asp:LinqDataSource ID="LDSMonitorClientPC" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebClientPCAccount">
</asp:LinqDataSource>

