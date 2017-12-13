<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PCashVerificationReportMaker.ascx.vb" Inherits="Accounting.PCashVerificationReportMaker" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%">
    <cc1:TabPanel runat="server" HeaderText="報銷支票查詢" ID="TabPanel1">
    <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td>
                    年度:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    號數:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查詢報銷單" />
                    <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="RecDate,Number" 
            DataSourceID="LDSSearchResult" PageSize="30">
            <PagerSettings PageButtonCount="30" Position="Top" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="選取列印" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RecDate" DataFormatString="{0:d}" HeaderText="日期" 
                    ReadOnly="True" SortExpression="RecDate" />
                <asp:BoundField DataField="Number" HeaderText="號數" ReadOnly="True" 
                    SortExpression="Number" />
                <asp:BoundField DataField="TicketNumber" HeaderText="支票號碼" 
                    SortExpression="TicketNumber" />
                <asp:BoundField DataField="ToCashDateTime" DataFormatString="{0:d}" 
                    HeaderText="兌現時間" SortExpression="ToCashDateTime" />
                <asp:CheckBoxField DataField="IsToCashed" HeaderText="是否已兌現" 
                    SortExpression="IsToCashed" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LDSSearchResult" runat="server" 
            ContextTypeName="CompanyLINQDB.PCashDataContext" 
            OrderBy="IsToCashed, Number, RecDate desc" TableName="PCash2">
        </asp:LinqDataSource>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="報銷支票撥補清單報表" ID="TabPanel2" Visible="False" >
        <ContentTemplate>
            <asp:HiddenField ID="HFSetRecDate" runat="server" />
            <asp:HiddenField ID="HFSetNumber" runat="server" />
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" Width="100%">
                <LocalReport ReportPath="PCash\PCashVerivication.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="LDSPrintDataSource" 
                            Name="PCash1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:LinqDataSource ID="LDSPrintDataSource" runat="server" 
                ContextTypeName="CompanyLINQDB.PCashDataContext" TableName="PCash1">
            </asp:LinqDataSource>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
