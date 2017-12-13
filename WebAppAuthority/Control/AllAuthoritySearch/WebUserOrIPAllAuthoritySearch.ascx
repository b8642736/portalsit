<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserOrIPAllAuthoritySearch.ascx.vb" Inherits="WebAppAuthority.WebUserOrIPAllAuthoritySearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
        <table style="width:100%;">
        <tr>
        <td />
            查詢角色:<td  colspan="3" />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="USER">使用者</asp:ListItem>
                    <asp:ListItem Value="PC">電腦</asp:ListItem>
                </asp:RadioButtonList>
        </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="使用者登入帳號:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>

                </td>
                <td>
                    系統名稱:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" DataTextField="SystemName" 
    DataValueField="SystemCode" DataSourceID="ldsWebSystem" Width="120px" 
    ID="DropDownList1" AutoPostBack="True">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="使用者顯示名稱:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>

                </td>
                <td>
                    系統功能:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" 
    DataTextField="FunctionName" DataValueField="FunctionCode" 
    DataSourceID="ldsWebSystemFunction" Width="120px" ID="DropDownList2">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="使用者備註1:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>

                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    <asp:Button runat="server" Text="查詢使用者" Width="100px" ID="btnSearch"></asp:Button>

                    <asp:Button runat="server" Text="清除查詢" Width="100px" ID="btnSearchClear"></asp:Button>

                </td>
            </tr>
  
        </table>
<asp:LinqDataSource ID="ldsWebSystem" runat="server" ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" TableName="WebSystem"/>
<asp:LinqDataSource ID="ldsWebSystemFunction" runat="server" ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" TableName="WebSystemFunction" />
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="Search" TypeName="WebAppAuthority.WebUserOrIPAllAuthoritySearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="UserWindowAccount" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBox2" Name="UserDisplayName" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBox3" Name="UserMemo1" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="FindWebSystem" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="FindSystemFunction" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="Window登入帳號" HeaderText="Window登入帳號" 
                    SortExpression="Window登入帳號" />
                <asp:BoundField DataField="Window使用者顯示名稱" HeaderText="Window使用者顯示名稱" 
                    SortExpression="Window使用者顯示名稱" />
                <asp:BoundField DataField="Window使用者備註1" HeaderText="Window使用者備註1" 
                    SortExpression="Window使用者備註1" />
                <asp:BoundField DataField="授權群組" HeaderText="授權群組" SortExpression="授權群組" />
                <asp:BoundField DataField="授權系統" HeaderText="授權系統" SortExpression="授權系統" />
                <asp:BoundField DataField="授權系統功能" HeaderText="授權系統功能" 
                    SortExpression="授權系統功能" />
                <asp:BoundField DataField="授權備註1" HeaderText="授權備註1" SortExpression="授權備註1" />
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult2">
            <Columns>
                <asp:BoundField DataField="電腦IP" HeaderText="電腦IP" SortExpression="電腦IP" />
                <asp:BoundField DataField="電腦名稱" HeaderText="電腦名稱" SortExpression="電腦名稱" />
                <asp:BoundField DataField="電腦備註1" HeaderText="電腦備註1" SortExpression="電腦備註1" />
                <asp:BoundField DataField="授權群組" HeaderText="授權群組" SortExpression="授權群組" />
                <asp:BoundField DataField="授權系統" HeaderText="授權系統" SortExpression="授權系統" />
                <asp:BoundField DataField="授權系統功能" HeaderText="授權系統功能" 
                    SortExpression="授權系統功能" />
                <asp:BoundField DataField="授權備註1" HeaderText="授權備註1" SortExpression="授權備註1" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult2" runat="server" 
            SelectMethod="SearchIP" 
            TypeName="WebAppAuthority.WebUserOrIPAllAuthoritySearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="ClientIP" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TextBox2" Name="ClientDisplayName" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBox3" Name="ClientMemo1" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="FindWebSystem" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="FindSystemFunction" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>


