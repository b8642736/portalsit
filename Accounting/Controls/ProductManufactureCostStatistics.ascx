<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductManufactureCostStatistics.ascx.vb" Inherits="Accounting.ProductManufactureCostStatistics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }

    .auto-style2
    {
        width: 79px;
    }
   
</style>

<table class="auto-style1">

    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td class="auto-style2"></td>
        <td >
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" /></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>       </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" DataSourceID="odsSearchResult" EnableModelValidation="True">
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search"
    TypeName="Accounting.ProductManufactureCostStatistics">
    <SelectParameters>

        <asp:ControlParameter ControlID="hfSQL_acsrm1pf" Name="fromSQL_acsrm1pf" PropertyName="Value"
                    Type="String" />
        <asp:ControlParameter ControlID="hfSQL_sl2cicpf" Name="fromSQL_sl2cicpf" PropertyName="Value"
                    Type="String" />
        <asp:ControlParameter ControlID="hfSQL_ppsciapf" Name="fromSQL_ppsciapf" PropertyName="Value"
                    Type="String" />	
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfSQL_acsrm1pf" runat="server" />
<asp:HiddenField ID="hfSQL_sl2cicpf" runat="server" />
<asp:HiddenField ID="hfSQL_ppsciapf" runat="server" />
<asp:HiddenField ID="hfSearchDate" runat="server" />
