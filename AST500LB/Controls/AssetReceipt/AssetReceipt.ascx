<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetReceipt.ascx.vb" Inherits="AST500LB.AssetReceipt" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 83px;
    }
</style>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Height="615px" Width="100%">
    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
    <HeaderTemplate>資料查詢</HeaderTemplate>
    <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsDataPreView" EnableModelValidation="True" 
            DataKeyNames="NUMBER,DEPT">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="選取列印" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="CODE" HeaderText="增減代碼" SortExpression="CODE" />
                <asp:BoundField DataField="NUMBER" HeaderText="資產編號" SortExpression="NUMBER" />
                <asp:BoundField DataField="NAME" HeaderText="資產名稱" SortExpression="NAME" />
                <asp:BoundField DataField="UNIT" HeaderText="單位" SortExpression="UNIT" />
                <asp:BoundField DataField="QUANT" HeaderText="數量" SortExpression="QUANT" />
                <asp:BoundField DataField="TAMOUN" HeaderText="總價" SortExpression="TAMOUN" />
                <asp:BoundField DataField="DATE" HeaderText="入帳年月" SortExpression="DATE" />
                <asp:BoundField DataField="USLAFF" HeaderText="耐用年限" SortExpression="USLAFF" />
                <asp:BoundField DataField="DEPT" HeaderText="部門" SortExpression="DEPT" />
                <asp:BoundField DataField="PRICE" HeaderText="單價" SortExpression="PRICE" />
            </Columns>
            <SelectedRowStyle BackColor="#99FF99" BorderStyle="None" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsDataPreView" runat="server" 
            SelectMethod="DataPreViewSearch" TypeName="AST500LB.AssetReceipt"></asp:ObjectDataSource>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
    <HeaderTemplate>列印</HeaderTemplate>
    <ContentTemplate>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="600px" InteractiveDeviceInfos="(集合)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Controls\AssetReceipt\AssetReceiptV2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="AST500LB.AssetReceipt">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hfQry" runat="server" />
    </ContentTemplate>

    </cc1:TabPanel>
</cc1:TabContainer>




<asp:HiddenField ID="hfPrintKeys" runat="server" />




