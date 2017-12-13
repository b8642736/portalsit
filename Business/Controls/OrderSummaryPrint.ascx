<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderSummaryPrint.ascx.vb" Inherits="Business.OrderSummaryPrint" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">

    .style1
    {
        width: 84px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            年/月:</td>
        <td>
            西元<asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
            年<asp:DropDownList ID="DropDownList1" runat="server" Width="42px">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="400px" Width="100%" Visible="False">
    <LocalReport ReportPath="Controls\OrderSummaryReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="SLS300LB_OrderSummaryPrint" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.OrderSummaryPrint">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="Year" PropertyName="Text" 
            Type="Int32" />
        <asp:ControlParameter ControlID="DropDownList1" Name="Month" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
