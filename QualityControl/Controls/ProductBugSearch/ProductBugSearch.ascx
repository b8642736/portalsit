<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductBugSearch.ascx.vb" Inherits="QualityControl.ProductBugSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 100px;
    }
    .style2
    {
        width: 100px;
        height: 20px;
    }
    .style3
    {
        height: 20px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <label for="ctl00_ContentPlaceHolder1_HomeSellReview1_CheckBox1">
            會計時段:</label></td>
        <td>
            <asp:TextBox ID="tbStartDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate1_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate1" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate1">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            缺限代碼:</td>
        <td>
            <asp:TextBox ID="tbBugCode" runat="server" Width="250px"></asp:TextBox>
            (二個以上請以&#39;,&#39;隔開 Ex:11,22,33,.....)</td>
    </tr>
    <tr>
        <td class="style2">
            鋼種:</td>
        <td class="style3">
            <asp:TextBox ID="tbSteelKindType" runat="server" Width="250px"></asp:TextBox>
            (二個以上請以&#39;,&#39;隔開 Ex:201,304L,....)</td>
    </tr>
    <tr>
        <td class="style2">
            表面:</td>
        <td class="style3">
            <asp:TextBox ID="tbFace" runat="server" Width="250px"></asp:TextBox>
            (二個以上請以&#39;,&#39;隔開 Ex:2B,2D,....)</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" 
                Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="缺陷代碼" HeaderText="缺陷代碼" SortExpression="缺陷代碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="鋼捲編號" HeaderText="鋼捲編號" SortExpression="鋼捲編號" />
        <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
        <asp:BoundField DataField="長度" HeaderText="長度" SortExpression="長度" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="淨重" HeaderText="淨重" SortExpression="淨重" />
        <asp:BoundField DataField="一級重量" HeaderText="一級重量" SortExpression="一級重量" />
        <asp:BoundField DataField="二級重量" HeaderText="二級重量" SortExpression="二級重量" />
        <asp:BoundField DataField="三級重量" HeaderText="三級重量" SortExpression="三級重量" />
        <asp:BoundField DataField="頭尾重量" HeaderText="頭尾重量" SortExpression="頭尾重量" />
        <asp:BoundField DataField="邊切重量" HeaderText="邊切重量" SortExpression="邊切重量" />
        <asp:BoundField DataField="廢料重量" HeaderText="廢料重量" SortExpression="廢料重量" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.ProductBugSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfBugFilters" Name="BugsFilter" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />


<asp:HiddenField ID="hfBugFilters" runat="server" />


