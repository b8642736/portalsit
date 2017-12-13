<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SiteGroupToSiteEdit.ascx.vb" Inherits="IM.SiteGroupToSiteEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 114px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            站台群組名稱:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            站台名稱:</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>訊息:
        </td>
        <td>
            <asp:Label ID="lbMsg" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClearSearch" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Width="100%">
    <cc1:TabPanel runat="server"  ID="TabPanel1">
    <HeaderTemplate>將站台加入群組</HeaderTemplate>
    <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td>
                    選擇站台群組
                </td>
                <td>
                    未加入站台
                </td>
            </tr>
            <tr>
                <td>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="ID" DataSourceID="ldsSearchResult1" AllowPaging="True">
                         <Columns>
                             <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                             <asp:BoundField DataField="GroupName" HeaderText="群組名稱" 
                                 SortExpression="GroupName" />
                             <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                 SortExpression="ID" />
                         </Columns>
                         <SelectedRowStyle BackColor="#CCFFCC" />
                    </asp:GridView>
               </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ID" DataSourceID="ldsSearchResult2" AllowPaging="True" 
                        Enabled="False">
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" 
                                SelectText="加入站台群組" />
                            <asp:BoundField DataField="SiteName" HeaderText="站台名稱" 
                                SortExpression="SiteName" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                SortExpression="ID" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:LinqDataSource ID="ldsSearchResult1" runat="server" 
            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="SiteGroup">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="ldsSearchResult2" runat="server" 
            ContextTypeName="CompanyLINQDB.IMDataContext" TableName="Site">
        </asp:LinqDataSource>
        </ContentTemplate>
        </asp:UpdatePanel>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server">
     <HeaderTemplate>將站台自群組中移除</HeaderTemplate>
     <ContentTemplate>
     
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
             DataKeyNames="FK_SiteGroupID,FK_SiteID" DataSourceID="ldsSearchResult3" 
             AllowPaging="True">
             <Columns>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                             CommandName="Delete" Text="刪除" />
                         <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button1"  ConfirmText="是否確定刪除?" >
                         </cc1:ConfirmButtonExtender>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="SiteGroup_GroupName" HeaderText="群組名稱" 
                     ReadOnly="True" SortExpression="SiteGroup_GroupName" />
                 <asp:BoundField DataField="Site_SiteName" HeaderText="站台名稱" ReadOnly="True" 
                     SortExpression="Site_SiteName" />
                 <asp:BoundField DataField="FK_SiteGroupID" HeaderText="SiteGroupID" 
                     ReadOnly="True" SortExpression="FK_SiteGroupID" />
                 <asp:BoundField DataField="FK_SiteID" HeaderText="SiteID" ReadOnly="True" 
                     SortExpression="FK_SiteID" />
             </Columns>
         </asp:GridView>
         <asp:LinqDataSource ID="ldsSearchResult3" runat="server" 
             ContextTypeName="CompanyLINQDB.IMDataContext" EnableDelete="True" 
             TableName="SiteGroupToSite">
         </asp:LinqDataSource>
     
     </ContentTemplate>
   </cc1:TabPanel>
</cc1:TabContainer>

