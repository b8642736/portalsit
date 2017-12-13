<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MessageDisplay.ascx.vb" Inherits="PortalSit.MessageDisplay" %>
<style type="text/css">
    .style1
    {
        width: 81px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            重要訊息:
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:BulletedList ID="BulletedList1" runat="server" 
                        DataSourceID="LDSMessageBoard" DataTextField="MessageContent" 
                        DataValueField="ID">
                    </asp:BulletedList>
                    <asp:Timer ID="Timer1" runat="server">
                    </asp:Timer>
                    <asp:LinqDataSource ID="LDSMessageBoard" runat="server" 
                        ContextTypeName="CompanyLINQDB.OtherOperatorDataContext" 
                        TableName="MessageBoard">
                    </asp:LinqDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
