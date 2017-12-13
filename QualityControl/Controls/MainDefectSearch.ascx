<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MainDefectSearch.ascx.vb" Inherits="QualityControl.MainDefectSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style2
    {
        height: 129px;
    }
    .style4
    {
        width: 39px;
    }
     .style9
    {
        width: 85px;
    }
   .style10
    {
        width: 85px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td colspan="2" class="style2">
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Width="324%">
                <cc1:TabPanel runat="server" ID="TabPanel1">
                <HeaderTemplate>手動輸入</HeaderTemplate>
                <ContentTemplate>
                    <table class="style1" width="100%">
                        <tr>
                            <td class="style9">提貨單日期:
                            </td>
                            <td>
                                <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>~<asp:TextBox ID="tbEndDate"
                                    runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td class="style9" >公司代碼:
                            </td>
                            <td>
                                <asp:TextBox ID="tbCompanyCode" runat="server"></asp:TextBox>
                                (兩個以上以 &#39;,&#39; 分隔)</td>
                        </tr>
                        <tr>
                            <td class="style9">鋼捲號碼:
                            </td>
                            <td>
                                <asp:TextBox ID="tbCoilNumbers" runat="server" Width="248px"></asp:TextBox>
                                (兩個以上以 &#39;,&#39; 分隔)</td>
                        </tr>
                    </table>
                </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server" ID="TabPanel2">
                <HeaderTemplate>檔案輸入</HeaderTemplate>
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td class="style10">
                                輸入檔案:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="200px" />
                            </td>
                        </tr>
                         <tr>
                            <td class="style10">
                                
                                檔案範本:</td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    NavigateUrl="~/Controls/輸入資料範本.txt">參考</asp:HyperLink>
                            </td>
                        </tr>
                         <tr>
                            <td class="style10">
                                
                            </td>
                            <td>
                            </td>
                        </tr>
                   </table>
                </ContentTemplate>
               </cc1:TabPanel>
            </cc1:TabContainer>
        
        </td>
    </tr>
    <tr>
        <td class="style4"></td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" Width="100%">
    <Columns>
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="等級" HeaderText="等級" SortExpression="等級" />
        <asp:BoundField DataField="主要缺陷" HeaderText="主要缺陷" SortExpression="主要缺陷" />
        <asp:BoundField DataField="長度" HeaderText="長度" SortExpression="長度" />
        <asp:BoundField DataField="程度" HeaderText="程度" SortExpression="程度" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQryWhere" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.MainDefectSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryWhere" Name="QryWhereAfterString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

