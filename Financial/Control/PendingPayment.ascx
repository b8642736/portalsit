<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PendingPayment.ascx.vb" Inherits="Financial.PendingPayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<p />
<table class="auto-style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="編票日期"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbDateStart" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateStart_CalendarExtender" runat="server" TargetControlID="tbDateStart">
            </cc1:CalendarExtender>

            <asp:Label ID="Label2" runat="server" Text="~"></asp:Label>

            <asp:TextBox ID="tbDateEnd" runat="server"></asp:TextBox>

            <cc1:CalendarExtender ID="tbDateEnd_CalendarExtender" runat="server" TargetControlID="tbDateEnd">
            </cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" Height="40px" Style="margin-right: 0px" />

            &nbsp;
            
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" Height="40px" />

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:HiddenField ID="hfParam" runat="server" />
            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="Financial.PendingPayment">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfParam" Name="fromParam" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>






<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearch" EnableModelValidation="True">
    <RowStyle Height="40px" />
    <AlternatingRowStyle Height="40px" />
    <HeaderStyle Height ="40px"  />
</asp:GridView>



