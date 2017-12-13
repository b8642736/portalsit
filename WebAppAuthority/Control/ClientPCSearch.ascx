<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ClientPCSearch.ascx.vb" Inherits="WebAppAuthority.ClientPCSearch" %>
<style type="text/css">


    .style1
    {
        width: 262px;
    }
.TableLeftText
{
	text-align: right;
}</style>
<table style="width:100%;" class="style1">
    <tr>
        <td class="TableLeftText">
            <span lang="zh-tw">IP:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TableLeftText">
            電<span lang="zh-tw">腦名稱:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="65px" />
        </td>
    </tr>
    <tr>
        <td class="TableLeftText">
            <span lang="zh-tw">備註:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="65px" />
        </td>
    </tr>
    <tr>
        <td class="TableLeftText">
            <span lang="zh-tw">查詢結果:</span></td>
        <td class="style1">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="LDSWebClientPC" Height="117px" 
                PageSize="5" Width="238px" DataKeyNames="ClientIP">
                <PagerSettings Position="Top" PageButtonCount="30" />
                <Columns>
                    <asp:BoundField DataField="ClientIP" HeaderText="用戶端IP" 
                        SortExpression="ClientIP" ReadOnly="True" />
                    <asp:BoundField DataField="PCName" HeaderText="電腦名稱" 
                        SortExpression="PCName" />
                    <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>
            <span lang="zh-tw">選擇IP：<asp:Label ID="lblSelectCleintPCIP" runat="server"></asp:Label>
            </span>
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSWebClientPC" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebClientPCAccount">
</asp:LinqDataSource>


