<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Inventory.ascx.vb" Inherits="AST500LB.Inventory" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<p>
    <table style="width:100%;">
        <tr>
            <td>
                <span lang="zh-tw">廠別:</span></td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem Selected="True">SA</asp:ListItem>
                            <asp:ListItem>AA</asp:ListItem>
                            <asp:ListItem>AB</asp:ListItem>
                            <asp:ListItem>QA</asp:ListItem>
                            <asp:ListItem>NA</asp:ListItem>
                            <asp:ListItem>RA</asp:ListItem>
                            <asp:ListItem>RC</asp:ListItem>
                            <asp:ListItem>RD</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <span lang="zh-tw">單位:</span>
                    </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="16" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                        <asp:Button ID="btnSelectAll" runat="server" Text="全選" Width="80px" />
                        <asp:Button ID="btnClearAll" runat="server" Text="全部清除" Width="80px" />
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="執行查詢印表" />
                <asp:HiddenField ID="hfQryString" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</p>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="511px" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\InventoryReport\InventoryReportV3.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="AST500LBDataSet_InventoryDataTable" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search" TypeName="AST500LB.Inventory">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

