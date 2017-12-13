<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ContinueInsuranceSearch.ascx.vb" Inherits="AST500LB.ContinueInsuranceSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

    <style type="text/css">
        .style1
        {
            width: 116px;
        }
    </style>

    <table style="width:100%;">
        <tr>
            <td class="style1">
                保險基準日:</td>
            <td>
                <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="tbStartDate" Enabled="True">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style1">
                詢問保險種類:</td>
            <td>
                <asp:CheckBoxList ID="cblInsurceKind" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">火險</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">爆炸險</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                廠別:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">SA</asp:ListItem>
                    <asp:ListItem>AA</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem Value="QA"></asp:ListItem>
                    <asp:ListItem Value="NA"></asp:ListItem>
                    <asp:ListItem Value="RA"></asp:ListItem>
                    <asp:ListItem Value="RC"></asp:ListItem>
                    <asp:ListItem Value="RD"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="查詢印表" Width="100px" />
                <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
                <asp:HiddenField ID="hfQryString" runat="server" />
                <asp:HiddenField ID="hfQryString1" runat="server" />
                <asp:HiddenField ID="hfQAndAArgs" runat="server" />
            </td>
        </tr>
    </table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="500px" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Controls\Insurance\ContinueInsuranceReportV2.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                Name="AST500LBDataSet_InsuranceDataTable" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="Search" TypeName="AST500LB.ContinueInsuranceSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQryString1" Name="QryString1" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQAndAArgs" Name="QAndAArgs" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

