<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserAuthorityCopy.ascx.vb" Inherits="WebAppAuthority.WebUserAuthorityCopy" %>
<%@ Register src="EmployeeSearch.ascx" tagname="EmployeeSearch" tagprefix="uc1" %>
<style type="text/css">


    .style1
    {
        width: 262px;
    }
.TableLeftText
{
	text-align: right;
}
    .style2
    {
        width: 120px;
    }
</style>
<p>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="DefaultView" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="style2">
                        <span lang="zh-tw">權限來源登入者:</span></td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSelectSource" runat="server" Height="21px" Text="選擇授權來源" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <span lang="zh-tw">接受權限登入者:</span></td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnSelectTarget" runat="server" Text="選擇授權目地" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <span lang="zh-tw">複製受權方式:</span></td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Selected="True" Value="1">將來源使用者之權限附加至目地使用者</asp:ListItem>
                            <asp:ListItem Value="2">移除目地使用者所有權限後再將來源使用者之權限附加至目地使用者</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:Button ID="btnStartCopy" runat="server" Text="開始複製" Enabled="False" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="btnMessageLabel" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
        </asp:View>
        <asp:View ID="SourceUserSelectView" runat="server">
            <span lang="zh-tw">權限來源登入者:</span><br />
            <uc1:EmployeeSearch ID="EmployeeSearch1" runat="server" Visible="True" />
        </asp:View>
        <asp:View ID="TargetUserSelectView" runat="server">
            <span lang="zh-tw"><span lang="zh-tw">接受權限登入者</span>:</span><br />
            <uc1:EmployeeSearch ID="EmployeeSearch2" runat="server" />
        </asp:View>
        <br />
    </asp:MultiView>
    <br />
</p>

