<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LaboratoryReportMaker.ascx.vb" Inherits="SMPWork.LaboratoryReportMaker" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1 {
        width: 107px;
    }

    .style2 {
        width: 107px;
        height: 24px;
    }

    .style3 {
        height: 24px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style2">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="時間:" TextAlign="Left"
                Checked="True" />
        </td>
        <td class="style3">
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server"
                TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server"
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">是否已列印過:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Value="ALL">全部</asp:ListItem>
                <asp:ListItem Selected="True" Value="NO">未列印</asp:ListItem>
                <asp:ListItem Value="YES">已列印</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">驗收料:</td>
        <td>
            <!-- <asp:ListItem Value="Y">是驗收料</asp:ListItem>  1030305 嚴孝真 -->

            <asp:RadioButtonList ID="RadioButtonList2" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Value="ALL" Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="Y">廢不銹鋼全融</asp:ListItem>
                <asp:ListItem Value="YA">合金捲料</asp:ListItem>
                <asp:ListItem Value=" ">非驗收料</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel"
                Width="100px" />
            <asp:HiddenField ID="hfQry" runat="server" />
            <asp:HiddenField ID="hfPrintQry" runat="server" />
            <asp:HiddenField ID="hfPrintDate" runat="server" />
            <asp:ObjectDataSource runat="server" SelectMethod="DisplaySearch"
                TypeName="SMPWork.LaboratoryReportMaker" ID="odsSearchResult">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQry" PropertyName="Value" Name="SqlQry"
                        Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server" SelectMethod="Search"
                TypeName="SMPWork.LaboratoryReportMaker" ID="odsSearchResult1">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfPrintQry" PropertyName="Value" Name="SqlQry" Type="String"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="hfPrintDate" PropertyName="Value" Name="fromPrintDate" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>

</table>

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
    Width="100%" Height="810px">
    <cc1:TabPanel runat="server" ID="TabPanel1">
        <HeaderTemplate>查詢結果</HeaderTemplate>
        <ContentTemplate>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%"
                DataKeyNames="爐號,站別,序號,日期">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="轉至列印畫面"
                        ShowSelectButton="True" />
                    <asp:TemplateField HeaderText="列印日期">
                        <ItemTemplate>
                            <asp:TextBox ID="tbPrintDate" runat="server" Text='<%# FS_DATE_Now()%>' Width="80px" />
                            <cc1:CalendarExtender ID="tbPrintDate_CalendarExtender" runat="server"
                                TargetControlID="tbPrintDate" Format="yyyy/MM/dd">
                            </cc1:CalendarExtender>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
                    <asp:BoundField DataField="站別" HeaderText="站別" SortExpression="站別" />
                    <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                    <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                    <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
                    <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
                    <asp:BoundField DataField="Si" HeaderText="Si" SortExpression="Si" />
                    <asp:BoundField DataField="Mn" HeaderText="Mn" SortExpression="Mn" />
                    <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                    <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                    <asp:BoundField DataField="Cr" HeaderText="Cr" SortExpression="Cr" />
                    <asp:BoundField DataField="Ni" HeaderText="Ni" SortExpression="Ni" />
                    <asp:BoundField DataField="Cu" HeaderText="Cu" SortExpression="Cu" />
                    <asp:BoundField DataField="Mo" HeaderText="Mo" SortExpression="Mo" />
                    <asp:BoundField DataField="Co" HeaderText="Co" SortExpression="Co" />
                    <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                    <asp:BoundField DataField="Sn" HeaderText="Sn" SortExpression="Sn" />
                    <asp:BoundField DataField="Pb" HeaderText="Pb" SortExpression="Pb" />
                    <asp:BoundField DataField="Ti" HeaderText="Ti" SortExpression="Ti" />
                    <asp:BoundField DataField="Nb" HeaderText="Nb" SortExpression="Nb" />
                    <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                    <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />


                    <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" />
                    <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" />
                    <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" />
                    <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" />
                    <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" />
                    <asp:BoundField DataField="GP" HeaderText="GP" SortExpression="GP" />
                    <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" />






                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server">
        <HeaderTemplate>列印</HeaderTemplate>
        <ContentTemplate>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"
                Font-Size="8pt" Height="600px" InteractiveDeviceInfos="(集合)"
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="Controls\LaboratoryReport\LaboratoryReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsSearchResult1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>



