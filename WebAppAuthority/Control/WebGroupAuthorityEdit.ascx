<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebGroupAuthorityEdit.ascx.vb" Inherits="WebAppAuthority.WebGroupAuthorityEdit" %>
<%@ Register src="GroupSearch.ascx" tagname="GroupSearch" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">

    .style2
    {
        height: 103px;
    }
</style>
<p>

    <uc1:GroupSearch ID="GroupSearch1" runat="server" />

</p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <table style="width:100%;">
                    <tr>
                        <td class="style2">
                            <span lang="zh-tw">選擇系統:</span><asp:Label ID="lblSelectSystem" runat="server"></asp:Label>
                        </td>
                        <td class="style2">
                            <span lang="zh-tw">未授權功能</span></td>
                        <td class="style2">
                            <span lang="zh-tw">已授權功能</span></td>
                        <td class="style2">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinqDataSource ID="LDSWebSystem" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                Select="new (SystemName, SystemCode)" TableName="WebSystem">
                            </asp:LinqDataSource>
                            <asp:GridView ID="GridView2" runat="server" 
                                AutoGenerateColumns="False" DataKeyNames="SystemCode" 
                                DataSourceID="LDSWebSystem" EnableModelValidation="True">
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
                            <asp:GridView ID="GridView3" runat="server" 
                                AutoGenerateColumns="False" DataKeyNames="FunctionCode" 
                                DataSourceID="LDSWebSystemFunctionNotAuthority" Visible="False" 
                                EnableModelValidation="True">
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
                            <asp:GridView ID="GridView4" runat="server" 
                                AutoGenerateColumns="False" DataKeyNames="FunctionCode" 
                                DataSourceID="LDSWebSystemFunctionYesAuthority" Visible="False" 
                                EnableModelValidation="True">
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
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                                TargetControlID="btnClearAllSysAuthority" ConfirmText="是否確定移除?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnClearAllSysAuthority" runat="server" Text="移除所有系統所有授權" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnClearAllSysFunAuthority" runat="server" Enabled="False" 
                                Text="移除此系統所有授權" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" 
                                TargetControlID="btnClearAllSysFunAuthority" ConfirmText="是否確定移除?">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

            