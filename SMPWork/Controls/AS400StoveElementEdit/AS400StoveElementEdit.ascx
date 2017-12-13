<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AS400StoveElementEdit.ascx.vb" Inherits="SMPWork.AS400StoveElementEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 61px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server" Width="97px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" AutoPostBack="True" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" AutoPostBack="True" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                Format="yyyy/MM/dd" TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
        </td>
    </tr>

</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" 
    EnableModelValidation="True" DataKeyNames="QCA01,QCA02,QCA03,QCA04">
    <Columns>
        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
        <asp:BoundField DataField="QCA01" HeaderText="爐號" SortExpression="QCA01" 
            ReadOnly="True" />
        <asp:BoundField DataField="QCA02" HeaderText="日期" SortExpression="QCA02" 
            ReadOnly="True" />
        <asp:BoundField DataField="QCA03" HeaderText="時" SortExpression="QCA03" 
            ReadOnly="True" />
        <asp:BoundField DataField="QCA04" HeaderText="分" SortExpression="QCA04" 
            ReadOnly="True" />
        <asp:BoundField DataField="QCA05" HeaderText="鋼種" SortExpression="QCA05" />
        <asp:BoundField DataField="QCA06" HeaderText="型別" SortExpression="QCA06" />
        <asp:BoundField DataField="QCA07" HeaderText="C" SortExpression="QCA07" />
        <asp:BoundField DataField="QCA08" HeaderText="SI" SortExpression="QCA08" />
        <asp:BoundField DataField="QCA09" HeaderText="MN" SortExpression="QCA09" />
        <asp:BoundField DataField="QCA10" HeaderText="P" SortExpression="QCA10" />
        <asp:BoundField DataField="QCA11" HeaderText="S" SortExpression="QCA11" />
        <asp:BoundField DataField="QCA12" HeaderText="CR" SortExpression="QCA12" />
        <asp:BoundField DataField="QCA13" HeaderText="NI" SortExpression="QCA13" />
        <asp:BoundField DataField="QCA14" HeaderText="CU" SortExpression="QCA14" />
        <asp:BoundField DataField="QCA15" HeaderText="MO" SortExpression="QCA15" />
        <asp:BoundField DataField="QCA16" HeaderText="CO" SortExpression="QCA16" />
        <asp:BoundField DataField="QCA17" HeaderText="AL" SortExpression="QCA17" />
        <asp:BoundField DataField="QCA18" HeaderText="SN" SortExpression="QCA18" />
        <asp:BoundField DataField="QCA19" HeaderText="PB" SortExpression="QCA19" />
        <asp:BoundField DataField="QCA20" HeaderText="TI" SortExpression="QCA20" />
        <asp:BoundField DataField="QCA21" HeaderText="NB" SortExpression="QCA21" />
        <asp:BoundField DataField="QCA22" HeaderText="V" SortExpression="QCA22" />
        <asp:BoundField DataField="QCA23" HeaderText="W" SortExpression="QCA23" />
        <asp:BoundField DataField="QCA24" HeaderText="O2" SortExpression="QCA24" />
        <asp:BoundField DataField="QCA25" HeaderText="N2" SortExpression="QCA25" />
        <asp:BoundField DataField="QCA26" HeaderText="H2" SortExpression="QCA26" />
        <asp:BoundField DataField="QCA27" HeaderText="B" SortExpression="QCA27" />
        <asp:BoundField DataField="Real_QCA28" HeaderText="Ca" 
            SortExpression="Real_QCA28" />
        <asp:BoundField DataField="Real_QCA29" HeaderText="Mg" 
            SortExpression="Real_QCA29" />
        <asp:BoundField DataField="QCA30" HeaderText="Fe" SortExpression="QCA30" />
        <asp:BoundField DataField="QCA31" HeaderText="QCA31" ReadOnly="True" 
            SortExpression="QCA31" />
        <asp:BoundField DataField="QCA32" HeaderText="QCA32" ReadOnly="True" 
            SortExpression="QCA32" />
        <asp:BoundField DataField="QCA33" HeaderText="QCA33" ReadOnly="True" 
            SortExpression="QCA33" />
        <asp:BoundField DataField="QCA34" HeaderText="QCA34" ReadOnly="True" 
            SortExpression="QCA34" />
        <asp:BoundField DataField="QCA35" HeaderText="QCA35" ReadOnly="True" 
            SortExpression="QCA35" />
        <asp:BoundField DataField="QCA36" HeaderText="QCA36" ReadOnly="True" 
            SortExpression="QCA36" />
        <asp:BoundField DataField="QCA37" HeaderText="QCA37" ReadOnly="True" 
            SortExpression="QCA37" />
        <asp:BoundField DataField="QCA38" HeaderText="QCA38" ReadOnly="True" 
            SortExpression="QCA38" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.PPS100LB.PPSQCAPF" SelectMethod="Search" 
    TypeName="SMPWork.AS400StoveElementEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfQryString" runat="server" />


