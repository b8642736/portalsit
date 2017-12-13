<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MasterStock.ascx.vb" Inherits="Business.MasterStock" %>
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
            會計日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>庫存與寄庫:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="Y1">有主庫存</asp:ListItem>
                <asp:ListItem Value="Y2">寄庫非庫存</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>內外銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="HOMESELL">內銷</asp:ListItem>
                <asp:ListItem Value="EXTRASELL">外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>顯示格式:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="DETAIL">顯示鋼捲明細</asp:ListItem>
                <asp:ListItem Value="CUSTOMTOTAL">依客戶加總</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" 
    Font-Names="Verdana" Font-Size="8pt" Height="700px" 
    InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="Controls\MasterStock\MasterStockReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsSearchResult" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search1" TypeName="Business.MasterStock">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry1" Name="SQLString" PropertyName="Value" 
            Type="String" />
        <asp:ControlParameter ControlID="hfOutFormat" Name="OutFormat" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

            <asp:HiddenField ID="hfQry1" runat="server" />
            <asp:HiddenField ID="hfOutFormat" runat="server" />
        

