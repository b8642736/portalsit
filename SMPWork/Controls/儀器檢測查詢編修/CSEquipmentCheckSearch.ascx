<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CSEquipmentCheckSearch.ascx.vb" Inherits="SMPWork.CSEquipmentCheckSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">

    .style1
    {
        width: 103px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            樣本編號:</td>
        <td>
            <asp:TextBox ID="tbSampleID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="ldsSearchResult">
    <Columns>
        <asp:BoundField DataField="SampleID" HeaderText="樣本編號" ReadOnly="True" 
            SortExpression="SampleID" />
        <asp:BoundField DataField="C1" HeaderText="碳" SortExpression="C1" />
        <asp:BoundField DataField="S1" HeaderText="硫" SortExpression="S1" />
        <asp:BoundField DataField="日期時間" HeaderText="日期時間" ReadOnly="True" 
            SortExpression="日期時間" />
        <asp:BoundField DataField="MachineID" HeaderText="機器編號" ReadOnly="True" 
            SortExpression="MachineID" />
    </Columns>
</asp:GridView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.SMPDataContext" TableName="標準樣本接收資料CS">
</asp:LinqDataSource>

