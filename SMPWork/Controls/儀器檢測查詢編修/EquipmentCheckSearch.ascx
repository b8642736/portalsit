<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EquipmentCheckSearch.ascx.vb" Inherits="SMPWork.EquipmentCheckSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<table style="width: 715px; height: 48px">
    <tr>
        <td style="height: 30px">
            起始日:</td>
        <td style="height: 30px">
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>(範例:2007/01/01)<cc1:CalendarExtender 
                ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
        </td>
        <td style="height: 30px">
            終止日:</td>
        <td style="height: 30px">
            <asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>(範例:2007/12/31)<cc1:CalendarExtender 
                ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td>
            查詢爐號:</td>
        <td>
            <asp:TextBox ID="tbFurnaceNumber" runat="server" Height="19px"></asp:TextBox></td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            站 別:</td>
        <td>
            <asp:DropDownList ID="DDLStationName" runat="server" Width="152px" 
                DataTextField="StationName" DataValueField="StationID" Height="20px">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">電爐A</asp:ListItem>
                <asp:ListItem Value="E2">電爐B</asp:ListItem>
                <asp:ListItem Value="A1">AOD</asp:ListItem>
                <asp:ListItem Value="L1">LADLE</asp:ListItem>
                <asp:ListItem Value="C1">TUNISH</asp:ListItem>
            </asp:DropDownList></td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
    <td />
        &nbsp;<td colspan="3" />
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除" Width="100px" />
    </tr>

</table>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataKeyNames="爐號,站別,序號,日期時間,點序" 
    DataSourceID="ldsSearchResult" Width="2048px">
    <Columns>
        <asp:BoundField DataField="爐號" HeaderText="爐號" ReadOnly="True" 
            SortExpression="爐號" />
        <asp:BoundField DataField="站別" HeaderText="站別" ReadOnly="True" 
            SortExpression="站別" />
        <asp:BoundField DataField="序號" HeaderText="序號" ReadOnly="True" 
            SortExpression="序號" />
        <asp:BoundField DataField="日期時間" HeaderText="日期時間" 
            ReadOnly="True" SortExpression="日期時間" />
        <asp:BoundField DataField="點序" HeaderText="點序" ReadOnly="True" 
            SortExpression="點序" />
        <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
        <asp:BoundField DataField="Si" HeaderText="Si" SortExpression="Si" />
        <asp:BoundField DataField="Mn" HeaderText="Mn" SortExpression="Mn" />
        <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
        <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
        <asp:BoundField DataField="Cr" HeaderText="Cr" SortExpression="Cr" />
        <asp:BoundField DataField="Ni" HeaderText="Ni" SortExpression="Ni" />
        <asp:BoundField DataField="Cu" HeaderText="Cu" SortExpression="Cu" />
        <asp:BoundField DataField="Mo" HeaderText="Mo" SortExpression="Mo" />
        <asp:BoundField DataField="Co" HeaderText="Co" SortExpression="Co" />
        <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
        <asp:BoundField DataField="Sn" HeaderText="Sn" SortExpression="Sn" />
        <asp:BoundField DataField="Pb" HeaderText="Pb" SortExpression="Pb" />
        <asp:BoundField DataField="Ti" HeaderText="Ti" SortExpression="Ti" />
        <asp:BoundField DataField="Nb" HeaderText="Nb" SortExpression="Nb" />
        <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
        <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
        <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
        <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
        <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
        <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
        <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" />
        <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" />
        <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" />
        <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" />
        <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" />
        <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
        <asp:BoundField DataField="SampleMark" HeaderText="SampleMark" 
            SortExpression="SampleMark" />
        <asp:BoundField DataField="Sample" HeaderText="Sample" 
            SortExpression="Sample" />
        <asp:BoundField DataField="Comments" HeaderText="Comments" 
            SortExpression="Comments" />
        <asp:BoundField DataField="Task" HeaderText="Task" SortExpression="Task" />
        <asp:BoundField DataField="Method" HeaderText="Method" 
            SortExpression="Method" />
        <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
        <asp:BoundField DataField="Furance" HeaderText="Furance" 
            SortExpression="Furance" />
        <asp:BoundField DataField="Melt" HeaderText="Melt" SortExpression="Melt" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
        <asp:BoundField DataField="DeviceName" HeaderText="儀器名稱" 
            SortExpression="DeviceName" />
        <asp:BoundField DataField="FK_SampleNumber" HeaderText="標準樣本名稱" 
            SortExpression="FK_SampleNumber" />
        <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" />
    </Columns>
</asp:GridView>
<asp:LinqDataSource ID="ldsSearchResult" runat="server" 
    ContextTypeName="CompanyLINQDB.SMPDataContext" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True" TableName="標準樣本接收資料">
</asp:LinqDataSource>

