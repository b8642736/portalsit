<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NonRadioactive_Print.ascx.vb" Inherits="QualityControl.NonRadioactive_Print" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<style type="text/css">
    .print-style1 {
        width: 100%;
    }

   
    .print-style2 {
    }
    .print-style3 {
        width: 85%;
        height: 20px;
    }
    

   
    .print-style4 {
        width: 15%;
        height: 20px;
    }
    

   
</style>


<table class="print-style1">
    <tr>
        <td style="table-layout: fixed">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" width="100%" Height ="100%">
                <LocalReport  ReportPath="bin\Controls\NonRadioactiveReport\NonRadioactive_Report.rdlc">        
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="" Name="DataSet_Master" />
                    </DataSources>        
                </LocalReport>
            </rsweb:ReportViewer>
         </td>
    </tr>
</table>


            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

        
<table class="print-style1">
    <tr>
        <td class="print-style4" aria-atomic="False" >
            <asp:Label ID="Label1" runat="server" Text="單據號碼：" Visible="False"></asp:Label>

        </td>
        <td class="print-style3" >
            <asp:TextBox ID="tbLabNo" runat="server" Visible="False"></asp:TextBox>

            <asp:TextBox ID="tb_subno" runat="server" Visible="False"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td class="print-style2" aria-atomic="False" ></td>
        <td class="print-style3" >

            <asp:Button ID="btnPrint" runat="server" Text="列印" Visible="False" />

        </td>
    </tr>
    <tr>
        <td class="print-style2" aria-atomic="False" colspan="2" >

            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>

        </td>
    </tr>
    <tr>
        <td class="print-style2" aria-atomic="False" >
            &nbsp;</td>
        <td class="print-style3" >
            <asp:Label ID="Label2" runat="server" Text="語系：" Visible="False"></asp:Label>
            <asp:DropDownList ID="ddLangCode" runat="server" Visible="False">
            </asp:DropDownList>
        </td>
    </tr>
</table>


            

        
