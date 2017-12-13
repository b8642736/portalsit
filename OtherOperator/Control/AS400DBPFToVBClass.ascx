<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AS400DBPFToVBClass.ascx.vb" Inherits="OtherOperator.AS400DBPFToVBClass" %>
<style type="text/css">
    .style1
    {
        width: 170px;
    }
</style>
AS400資料庫定義轉VB類別程式:<br />
<br />
<table style="width:100%;">
    <tr>
        <td class="style1">
            Library Name:</td>
        <td>
            <asp:TextBox ID="tbLibraryName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            DDS File Name:</td>
        <td>
            <asp:TextBox ID="tbFileName" runat="server">QDDSSRC</asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="style1">
            Member Name:</td>
        <td>
            <asp:TextBox ID="tbMemberName" runat="server"></asp:TextBox>
        </td>
    </tr>
   <tr>
        <td class="style1">
            <asp:Label ID="Label1" runat="server" Text="訊息:"></asp:Label>
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnConvertToVBFile" runat="server" Text="轉換為VB程式碼" 
                Width="150px" />
            <asp:Button ID="btnDownLoad" runat="server" Text="下載轉換結果" Visible="False" 
                Width="150px" />
        </td>
    </tr>
</table>
<p>
    <asp:TextBox ID="TextBox1" runat="server" Height="400px" TextMode="MultiLine" 
        Width="100%"></asp:TextBox>
</p>

