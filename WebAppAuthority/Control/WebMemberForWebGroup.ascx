<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebMemberForWebGroup.ascx.vb" Inherits="WebAppAuthority.WebMemberForWebGroup" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="GroupSearch.ascx" tagname="GroupSearch" tagprefix="uc1" %>
<%@ Register src="EmployeeSearch.ascx" tagname="EmployeeSearch" tagprefix="uc2" %>
<%@ Register src="ClientPCSearch.ascx" tagname="ClientPCSearch" tagprefix="uc3" %>
<p>
    <br />
</p>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
    Height="800px" Width="100%" AutoPostBack="True">
    <cc1:TabPanel runat="server" HeaderText="選擇群組" ID="TabPanel1">
    <ContentTemplate>
        <uc1:GroupSearch ID="GroupSearch1" runat="server" />
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" Enabled="false"  runat="server" HeaderText="選擇用戶端PC成員">
     <ContentTemplate>
         <table style="width:100%;">
             <tr>
                 <td>
                     <span lang="zh-tw">搜尋並選擇加入</span></td>
                 <td>
                     <span lang="zh-tw">已加入成員</span></td>
             </tr>
             <tr>
                 <td>
                     <uc3:ClientPCSearch ID="ClientPCSearch1" runat="server">
                         
                     </uc3:ClientPCSearch>
                 </td>
                 <td>
                     <asp:LinqDataSource ID="LDSClientPC_Member" runat="server" 
                         ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                         Select="new (ClientIP, PCName,Memo1)" TableName="WebClientPCAccount">
                     </asp:LinqDataSource>
                     <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                         AutoGenerateColumns="False" DataSourceID="LDSClientPC_Member" 
                         DataKeyNames="ClientIP" EnableModelValidation="True">
                         <Columns>
                             <asp:CommandField ShowSelectButton="True" ButtonType="Button" 
                                 SelectText="移除成員" />
                             <asp:BoundField DataField="ClientIP" HeaderText="用戶端IP" ReadOnly="True" 
                                 SortExpression="ClientIP" />
                             <asp:BoundField DataField="PCName" HeaderText="電腦名稱" ReadOnly="True" 
                                 SortExpression="PCName" />
                             <asp:BoundField DataField="Memo1" HeaderText="備註1" SortExpression="Memo1" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
    </ContentTemplate>
   </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3" Enabled="false" runat="server" HeaderText="選擇登入者成員">
      <ContentTemplate>
          <table style="width:100%;">
              <tr>
                  <td>
                      <span lang="zh-tw">搜尋並選擇加入</span></td>
                  <td>
                      <span lang="zh-tw">已加入成員</span></td>
              </tr>
              <tr>
                  <td>
                      <uc2:EmployeeSearch ID="EmployeeSearch1" runat="server" />
                  </td>
                  <td>
                      <asp:LinqDataSource ID="LDSEmployee_Member" runat="server" 
                          ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                          Select="new (WindowLoginName, DisplayName)" TableName="WebLoginAccount">
                      </asp:LinqDataSource>
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                          DataSourceID="LDSEmployee_Member" DataKeyNames="WindowLoginName" 
                          EnableModelValidation="True">
                          <Columns>
                              <asp:CommandField ButtonType="Button" SelectText="移除成員" 
                                  ShowSelectButton="True" />
                              <asp:BoundField DataField="WindowLoginName" HeaderText="WindowLoginName" 
                                  ReadOnly="True" SortExpression="WindowLoginName" />
                              <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" 
                                  ReadOnly="True" SortExpression="DisplayName" />
                          </Columns>
                      </asp:GridView>
                  </td>
              </tr>
          </table>
    </ContentTemplate>
  </cc1:TabPanel>
</cc1:TabContainer>
