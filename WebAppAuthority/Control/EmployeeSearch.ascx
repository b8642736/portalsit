<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EmployeeSearch.ascx.vb" Inherits="WebAppAuthority.EmployeeSearch" %>
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
            <span lang="zh-tw">使用者查詢:</span></td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TableLeftText">
            <span lang="zh-tw">工號:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnClearSearch" runat="server" Text="清除" Width="65px" />
        </td>
    </tr>
    <tr>
        <td class="TableLeftText">
            <span lang="zh-tw">姓名:</span></td>
        <td class="style1">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
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
                AutoGenerateColumns="False" DataSourceID="LDSWebUserLogin" Height="117px" 
                PageSize="15" Width="238px" DataKeyNames="WindowLoginName">
                <PagerSettings Position="Top" PageButtonCount="30" />
                <Columns>
                    <asp:BoundField DataField="WindowLoginName" HeaderText="登入名稱" 
                        SortExpression="WindowLoginName" ReadOnly="True" />
                    <asp:BoundField DataField="DisplayName" HeaderText="顯示名稱" 
                        SortExpression="DisplayName" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>
            <span lang="zh-tw">選擇員工：<asp:Label ID="lblSelectEmployee" runat="server"></asp:Label>
            </span>
        </td>
    </tr>
</table>
<asp:LinqDataSource ID="LDSWebUserLogin" runat="server" 
    ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
    TableName="WebLoginAccount">
</asp:LinqDataSource>


