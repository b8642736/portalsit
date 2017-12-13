<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Print.ascx.vb" Inherits="QualityControl.LabRecordA2_Print" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
       
    .auto-style1 {
        width: 90px;
    }
    .auto-style2 {
        width: 90px;
        height: 20px;
        text-align:right;
    }
       
    .auto-style22 {
        height: 20px;
    }
       
</style>

<table class="print-style1">
    <tr>
        <td style="table-layout: fixed">

        
<table class="print-style1">
    <tr>
        <td class="auto-style1" aria-atomic="False" >
            <asp:TextBox ID="tb_setting_par" runat="server" BorderStyle="None" Height="82px" ReadOnly="True" TextMode="MultiLine" Visible="False"></asp:TextBox>
        </td>
        <td class="print-style3" >

            

            &nbsp;</td>
    </tr>
    <tr>
        <td class="print-style2" aria-atomic="False" colspan="2" >

            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>


            <asp:Panel ID="Panel_detail" runat="server" Height="421px" Width="70%" Visible="False">
                <cc1:TabContainer ID="tabc_showdetail" runat="server" ActiveTabIndex="0" Height="374px" Width="100%" ScrollBars="Both" Font-Size="12pt">                    
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            檢驗項目
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_assay_res_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Font-Size="12pt">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_assay_dat_result" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            附註項目
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_remark_res_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" Font-Size="12pt" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_remark_dat_result" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>

                </cc1:TabContainer>
</asp:Panel>

<asp:Button ID="btn_hideSetting" runat="server" Text="顯示設定" ToolTip='<%# Eval("DELIVERY_NO") %>' Visible="False" />

            <br />

            

            <asp:DropDownList ID="ddl_report" runat="server">
                <asp:ListItem>工作報表</asp:ListItem>
                <asp:ListItem>材質證明</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnPrint" runat="server" Text="載入報表" />

        </td>
    </tr>
    </table>


            

        
                        <rsweb:ReportViewer runat="server" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="669px" Width="100%" ID="ReportViewer1" EnableTheming="True" Font-Names="Verdana" Font-Size="8pt" Visible="False" WaitMessageFont-Strikeout="False" WaitMessageFont-Underline="False">
<LocalReport ReportPath="Controls\LabRecordA2_Edit\report\Report-Main.rdlc" EnableExternalImages="True">
    <DataSources>
        <rsweb:ReportDataSource Name="Colis" DataSourceId="">
        </rsweb:ReportDataSource>
    </DataSources>
</LocalReport>
</rsweb:ReportViewer>


            

        
         </td>
    </tr>
</table>


            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

        



            

        
<p>
            <asp:TextBox ID="tbLabNo" runat="server" Visible="False"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="語系：" Visible="False"></asp:Label>
            <asp:DropDownList ID="ddLangCode" runat="server" Visible="False">
            </asp:DropDownList>
        </p>


        



            

        
