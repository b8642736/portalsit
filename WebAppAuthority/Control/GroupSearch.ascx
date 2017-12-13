<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GroupSearch.ascx.vb" Inherits="WebAppAuthority.GroupSearch" %>
<style type="text/css">
    .style1
    {
        width: 270px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>
            <span lang="zh-tw">群組代碼:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">群組名稱:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="100px" />
        </td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">備註1:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" Width="100px" />
        </td>
    </tr>
    <tr>
        <td>
            <span lang="zh-tw">查詢結果:</span></td>
        <td class="style1">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                BorderWidth="1px" CellPadding="2" DataSourceID="LDSEditDataSource" 
                ForeColor="Black" GridLines="None" PageSize="5" DataKeyNames="GroupCode">
                <PagerSettings PageButtonCount="30" Position="Top" />
                <Columns>
                    <asp:BoundField DataField="GroupCode" HeaderText="群組代碼" ReadOnly="True" 
                        SortExpression="GroupCode" />
                    <asp:BoundField DataField="GroupName" HeaderText="群組名稱" 
                        SortExpression="GroupName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                    HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
            </asp:GridView>
        </td>
        <td>
            <span lang="zh-tw">選擇群組代碼:<br />
            <asp:Label ID="lblSelectGroup" runat="server"></asp:Label>
            </span>
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSEditDataSource" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebGroupAccount">
</asp:LinqDataSource>

