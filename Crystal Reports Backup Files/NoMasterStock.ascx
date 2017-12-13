<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NoMasterStock.ascx.vb" Inherits="Business.NoMasterStock" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">
    .style1
    {
        width: 76px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            內/外 銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="HOMESELL">內銷</asp:ListItem>
                <asp:ListItem Value="EXPORTSELL">外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <TD class="style1" />
            會計日期:
        <TD>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="FALSE">不篩選</asp:ListItem>
                <asp:ListItem Value="TRUE">篩選</asp:ListItem>
            </asp:RadioButtonList>
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
            月~<asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
            年<asp:DropDownList ID="DropDownList2" runat="server" Width="42px">
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
        </TD>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:HiddenField ID="hfQry" runat="server" />
        </td>
    </tr>
  </table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="800px" Width="100%" EnableTheming="True">
    <LocalReport ReportPath="Controls\NoMasterStock\NoMasterStockReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="SLS300LB_NoMasterStockPrint" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.NoMasterStock">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

