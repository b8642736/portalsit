<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserAuthority.ascx.vb" Inherits="WebAppAuthority.WebUserAuthority" %>
<%@ Register src="EmployeeSearch.ascx" tagname="EmployeeSearch" tagprefix="uc1" %>
<style type="text/css">


    .style1
    {
        width: 262px;
    }
.TableLeftText
{
	text-align: right;
}</style>
<p>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
               <uc1:EmployeeSearch ID="EmployeeSearch1" runat="server" />
           </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <table style="width:100%;">
                    <tr>
                        <td>
                            <span lang="zh-tw">選擇系統:</span><asp:Label ID="lblSelectSystem" runat="server"></asp:Label>
                        </td>
                        <td>
                            <span lang="zh-tw">未授權功能</span></td>
                        <td>
                            <span lang="zh-tw">已授權功能</span></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinqDataSource ID="LDSWebSystem" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                Select="new (SystemName, SystemCode)" TableName="WebSystem">
                            </asp:LinqDataSource>
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="SystemCode" 
                                DataSourceID="LDSWebSystem">
                                <Columns>
                                    <asp:BoundField DataField="SystemName" HeaderText="系統名稱" ReadOnly="True" 
                                        SortExpression="SystemName" />
                                    <asp:BoundField DataField="SystemCode" HeaderText="系統代碼" 
                                        SortExpression="SystemCode" />
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:LinqDataSource ID="LDSWebSystemFunctionNotAuthority" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                Select="new (FunctionName, FunctionCode)" TableName="WebSystemFunction">
                            </asp:LinqDataSource>
                            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="FunctionCode" 
                                DataSourceID="LDSWebSystemFunctionNotAuthority" Visible="False">
                                <Columns>
                                    <asp:BoundField DataField="FunctionName" HeaderText="功能名稱" ReadOnly="True" 
                                        SortExpression="FunctionName" />
                                    <asp:BoundField DataField="FunctionCode" HeaderText="功能代碼" ReadOnly="True" 
                                        SortExpression="FunctionCode" />
                                    <asp:CommandField ButtonType="Button" SelectText="加入授權" 
                                        ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:LinqDataSource ID="LDSWebSystemFunctionYesAuthority" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                Select="new (FunctionName, FunctionCode)" TableName="WebSystemFunction">
                            </asp:LinqDataSource>
                            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="FunctionCode" 
                                DataSourceID="LDSWebSystemFunctionYesAuthority" Visible="False">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="取消授權" 
                                        ShowSelectButton="True" />
                                    <asp:BoundField DataField="FunctionName" HeaderText="功能名稱" ReadOnly="True" 
                                        SortExpression="FunctionName" />
                                    <asp:BoundField DataField="FunctionCode" HeaderText="功能代碼" ReadOnly="True" 
                                        SortExpression="FunctionCode" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

 </p>
