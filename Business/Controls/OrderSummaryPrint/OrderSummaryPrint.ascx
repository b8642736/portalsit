﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderSummaryPrint.ascx.vb" Inherits="Business.OrderSummaryPrint" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
            月~西元<asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
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
    </tr>
    <tr>
        <td class="style1">合約內/外</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value=" ">合約內</asp:ListItem>
                <asp:ListItem Value="*">合約外</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td  class="style1">印表格式:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">格式一</asp:ListItem>
                <asp:ListItem Value="2">格式二</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>
</table>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="400px" Width="100%" Visible="False">
            <LocalReport ReportPath="Controls\OrderSummaryPrint\OrderSummaryReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsSearchResult" 
                        Name="SLS300LB_OrderSummaryPrint" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="Business.OrderSummaryPrint">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
                    Type="String" />
                <asp:ControlParameter ControlID="hfHRQry" Name="HRSQLString" 
                    PropertyName="Value" Type="String" />
           </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="400px" Width="100%" Visible="False">
            <LocalReport ReportPath="Controls\OrderSummaryPrint\OrderSummaryReportF2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsSearchResult2" 
                        Name="SLS300LB_OrderSummaryPrint" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsSearchResult2" runat="server" 
            SelectMethod="SearchF2" TypeName="Business.OrderSummaryPrint">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" 
                    Type="String" />
                <asp:ControlParameter ControlID="hfHRQry" Name="HRSQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfQry2ForView2" Name="SQL2String" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfQry" runat="server" />
<asp:HiddenField ID="hfHRQry" runat="server" />
<asp:HiddenField ID="hfQry2ForView2" runat="server" />

