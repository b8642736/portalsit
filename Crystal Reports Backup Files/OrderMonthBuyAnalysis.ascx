<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderMonthBuyAnalysis.ascx.vb" Inherits="Business.OrderMonthBuyAnalysis" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<style type="text/css">

    .style1
    {
        width: 125px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            發貨年月:</td>
        <td>
            <asp:TextBox ID="tbStartYear1" runat="server" Width="37px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth1" runat="server" Width="37px"></asp:TextBox>
            月</td>
    </tr>
    <tr>
        <td class="style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKinds" runat="server"></asp:TextBox>
&nbsp;(兩個以上以&#39;,&#39;區隔 EX:304,201,202.....)</td>
    </tr>
    <tr>
        <td class="style1">表面:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem>HR</asp:ListItem>
                <asp:ListItem>CR</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">內/外銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem>內銷</asp:ListItem>
                <asp:ListItem>外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="訂單年月:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartYear2" runat="server" Width="37px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth2" runat="server" Width="37px"></asp:TextBox>
            月~<asp:TextBox ID="tbEndYear2" runat="server" Width="37px"></asp:TextBox>
            年<asp:TextBox ID="tbEndMonth2" runat="server" Width="37px"></asp:TextBox>
            月</td>
    </tr>    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:HiddenField ID="hfQry" runat="server" />
            <asp:HiddenField ID="hfQry1" runat="server" />
        </td>
    </tr>

</table>


<rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
    Width="100%" Font-Names="Verdana" Font-Size="8pt" 
    InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\OrderMonthBuyAnalysis\OrderMonthBuyAnalysisReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>





<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.OrderMonthBuyAnalysis">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLQry" PropertyName="Value" 
            Type="String" />
        <asp:ControlParameter ControlID="hfQry1" Name="SQLQry1" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>









