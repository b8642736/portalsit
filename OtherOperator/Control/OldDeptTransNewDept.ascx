<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OldDeptTransNewDept.ascx.vb" Inherits="OtherOperator.OldDeptTransNewDept" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 105px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            資料來源:</td>
        <td valign="middle">
            Update
            @#<asp:TextBox ID="TextBox1" 
                runat="server" Width="239px"></asp:TextBox>
            (格式:LibraryName.FileName.MemberName)</td>
    </tr>
    <tr>
        <td class="style1">
            部門欄位名稱:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            (輸入要轉換的資料庫欄位名稱)</td>
    </tr>
        <td class="style1">Where 條件:<br />
            (可不輸入)</td>
        <td valign="top">Where
            <asp:TextBox ID="TextBox3" runat="server" Height="80px" TextMode="MultiLine" 
                Width="548px"></asp:TextBox>
    </td>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnDEPTransfer" runat="server" Text="執行舊部門代碼轉新部門代碼" 
                Width="200px" />
            <cc1:ConfirmButtonExtender ID="btnDEPTransfer_ConfirmButtonExtender" 
                runat="server" ConfirmText="是否確定轉換?" TargetControlID="btnDEPTransfer">
            </cc1:ConfirmButtonExtender>
        </td>
    </tr>

</table>

<asp:TextBox ID="tbMsg" runat="server" Height="566px" ReadOnly="True" 
    TextMode="MultiLine" Width="100%"></asp:TextBox>


