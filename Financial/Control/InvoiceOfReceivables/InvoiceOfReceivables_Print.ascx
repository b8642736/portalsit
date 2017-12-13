<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InvoiceOfReceivables_Print.ascx.vb" Inherits="Financial.InvoiceOfReceivables_Print" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>


<table class="auto-style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="單據號碼："></asp:Label>
            <asp:TextBox ID="tbInvoice_Number" runat="server"></asp:TextBox>
            &nbsp&nbsp<asp:Button ID="btnPrint" runat="server" Text="列印" style="height: 21px" />

            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>


            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800">
                <LocalReport ReportPath="bin\Control\InvoiceOfReceivables\InvoiceOfReceivables_Report_v2.rdlc">

                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="" Name="DataSet_Main" />
                    </DataSources>

                </LocalReport>
            </rsweb:ReportViewer>



            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

