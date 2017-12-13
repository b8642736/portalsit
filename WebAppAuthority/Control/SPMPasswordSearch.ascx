<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SPMPasswordSearch.ascx.vb" Inherits="WebAppAuthority.SPMPasswordSearch" %>
<p>
    查詢工號:<asp:TextBox ID="tbEmployeeID" 
        runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查詢" />
    </br>密碼:<asp:Label ID="lbPassword" runat="server"></asp:Label>
    </br>
    <asp:Button ID="btnGotoEIPWeb" runat="server" Text="前往EIP網站" />
</p>


