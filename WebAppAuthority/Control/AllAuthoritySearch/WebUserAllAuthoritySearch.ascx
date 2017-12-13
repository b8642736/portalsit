<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserAllAuthoritySearch.ascx.vb" Inherits="WebAppAuthority.WebUserAllAuthoritySearch1" %>
<style type="text/css">

        .style1
        {
            width: 102px;
        }
    .style2
    {
        width: 218px;
    }
    .style3
    {
        width: 159px;
    }
    .style4
    {
        width: 74px;
    }
    </style>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    <span lang="zh-tw">登入帳號</span>:</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="style4" />
                    系統名稱:<td />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
    Width="120px" DataSourceID="ldsWebSystem" DataTextField="SystemName" DataValueField="SystemCode">
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="ldsWebSystem" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                TableName="WebSystem">
                            </asp:LinqDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
           </tr>
            <tr>
                <td class="style1">
                    <span lang="zh-tw">顯示名稱 />
                    系統功能:<td />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:D系統功能:<td />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" 
    Width="120px">
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="ldsWebSystemFunction" runat="server" 
                                ContextTypeName="CompanyLINQDB.WebAPPAuthorityDataContext" 
                                TableName="WebSystemFunction">
                            </asp:LinqDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </tr>
            <tr>
                <td class="style1">
                    <span lang="zh-tw">備註1 />
                <td />
          </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" colspan="3">
                    <asp:Button ID="btnSearch" runat="server" Text="查詢使用者" Width="100px" />
                    <asp:Button ID="btnSearchClear" runat="server" Text="清除查詢" Width="100px" />
                </td>
            </tr>
        </table>
    
    