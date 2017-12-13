<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WeightProcess2.ascx.vb" Inherits="Business.WeightProcess2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
         width: 125px;
    }
    .auto-style3 {
        width: 125px;
        height: 20px;
    }
    .auto-style4 {
        height: 20px;
    }
</style>

<p/>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">線別:</td>
        <td>
            <asp:DropDownList ID="ddLine" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">起迄日期:</td>
        <td>
            <asp:TextBox ID="tbDateStart" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateStart_CalendarExtender" runat="server" TargetControlID="tbDateStart"  Format ="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
            <asp:TextBox ID="tbDateEnd" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="tbDateEnd_CalendarExtender" runat="server" TargetControlID="tbDateEnd" Format ="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">磅序:</td>
        <td class="auto-style4">
            
            <asp:TextBox ID="tbSerNo" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="(兩個以上以  ',' 分隔及以'~'指定範圍 Ex:1,2,3,7~8,...)"></asp:Label>
            
        </td>
    </tr>
        <tr>
        <td class="auto-style3">鋼捲編號:</td>
        <td class="auto-style4">
            
            <asp:TextBox ID="tbCoilNo" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="(兩個以上以  ',' 分隔及以'~'指定範圍 Ex:M3303A,M7967A~M7967C,...)"></asp:Label>
            
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                <asp:Button ID="tbClearSearchCondiction" runat="server" Text="清除查詢條件" 
                Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
        <asp:HiddenField ID="hfSQLString" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Search" TypeName="Business.WeightProcess2">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

<p/>
<asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" EnableModelValidation="True">
</asp:GridView>


