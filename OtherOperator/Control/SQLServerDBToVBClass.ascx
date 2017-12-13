<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SQLServerDBToVBClass.ascx.vb" Inherits="OtherOperator.SQLServerDBToVBClass" %>
<style type="text/css">
    .style1
    {
        width: 107px;
    }
    .style2
    {
        width: 175px;
    }
</style>
<p>
    SQLServer資料庫定義轉VB類別程式:</p>
<table style="width:100%;">
    <tr>
        <td class="style1">
            SQL伺服器:</td>
        <td class="style2">
            <asp:DropDownList ID="ddlServer" runat="server" Width="120px">
                <asp:ListItem>Server0sm</asp:ListItem>
                <asp:ListItem>Server04m</asp:ListItem>
                <asp:ListItem>ServerSPM</asp:ListItem>
           </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            資料庫名稱:</td>
        <td class="style2">
            <asp:TextBox ID="tbDBName" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <%--<tr>
        <td class="style1">資料庫名稱</td>
        <td class="style2"><asp:TextBox ID="tbDBName" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>--%>
    <tr>
        <td class="style1">
            資料表名稱:</td>
        <td class="style2">
            <asp:TextBox ID="tbTableName" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="btnConvertToVBFile" runat="server" Text="轉換為VB程式碼" 
                Width="150px" />
            </td>
        <td>
            <asp:Button ID="btnDownLoad" runat="server" Text="下載轉換結果" Width="150px" />
        </td>
    </tr>
</table>
<p>
    <asp:TextBox ID="TextBox1" runat="server" Height="400px" TextMode="MultiLine" 
        Width="100%"></asp:TextBox>
</p>

