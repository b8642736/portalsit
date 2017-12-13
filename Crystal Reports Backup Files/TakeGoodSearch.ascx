<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TakeGoodSearch.ascx.vb" Inherits="Business.TakeGoodSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 84px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            年/月:</td>
        <td>
            西元<asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
            年<asp:DropDownList ID="DropDownList1" runat="server" Width="42px">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            內/外 銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="HOMESELL">內銷</asp:ListItem>
                <asp:ListItem Value="EXPORTSELL">外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除" Width="100px" />
            <asp:Button ID="btnDownLoadExcel" runat="server" Text="下載Excel" Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" PageSize="40">
    <Columns>
        <asp:BoundField DataField="年月" HeaderText="年/月" SortExpression="年月" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="客戶" HeaderText="客戶" SortExpression="客戶" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="CR訂單量" HeaderText="CR訂單量" SortExpression="CR訂單量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="CR提貨量" HeaderText="CR提貨量" SortExpression="CR提貨量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="HR訂單量" HeaderText="HR訂單量" SortExpression="HR訂單量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="HR提貨量" HeaderText="HR提貨量" SortExpression="HR提貨量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="其它訂單量" HeaderText="其它訂單量" SortExpression="其它訂單量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="其它提貨量" HeaderText="其它提貨量" SortExpression="其它提貨量" 
            DataFormatString="{0:0.###}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="Business.TakeGoodSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="Year" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="DropDownList1" Name="Month" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="RadioButtonList1" Name="SellArea" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

