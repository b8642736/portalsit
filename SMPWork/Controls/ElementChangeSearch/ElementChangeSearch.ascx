<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ElementChangeSearch.ascx.vb" Inherits="SMPWork.ElementChangeSearch" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 77px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            查詢爐號:</td>
        <td>
            <asp:TextBox ID="tbFurnaceNumber" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1">
            站 別:</td>
        <td>
            <asp:DropDownList ID="DDLStationName" runat="server" Width="152px" DataTextField="StationName" DataValueField="StationID">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">電爐A</asp:ListItem>
                <asp:ListItem Value="E2">電爐B</asp:ListItem>
                <asp:ListItem Value="A1">AOD</asp:ListItem>
                <asp:ListItem Value="L1">LADLE</asp:ListItem>
                <asp:ListItem Value="C*">TUNISH</asp:ListItem>
                <asp:ListItem Value="S1">SLAB</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
<asp:Button ID="btnSearch" runat="server" Text="查詢" Width="88px" />
<asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除" Width="88px" /></td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="PreChange爐號" HeaderText="爐號" 
            SortExpression="PreChange爐號" />
        <asp:BoundField DataField="PreChange站別" HeaderText="站別" 
            SortExpression="PreChange站別" />
        <asp:BoundField DataField="PreChange序號" HeaderText="序號" 
            SortExpression="PreChange序號" />
        <asp:BoundField DataField="PreChange日期" HeaderText="日期" 
            SortExpression="PreChange日期" />
        <asp:BoundField DataField="RecChangeReasonText" HeaderText="變更原因" 
            SortExpression="RecChangeReasonText" />
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
        <asp:BoundField DataField="站別" HeaderText="站別" SortExpression="站別" />
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="判定" HeaderText="判定" SortExpression="判定" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
        <asp:BoundField DataField="RecChangeTime" HeaderText="資料異動日期時間" 
            SortExpression="RecChangeTime" />
        <asp:BoundField DataField="操作員" HeaderText="操作員" SortExpression="操作員" />
        <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" />
        <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" />
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
        <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" />
        <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
        <asp:BoundField DataField="H2" HeaderText="H2" SortExpression="H2" />
        <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
        <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
        <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
        <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
        <asp:BoundField DataField="N1" HeaderText="N1" SortExpression="N1" />
        <asp:BoundField DataField="O1" HeaderText="O1" SortExpression="O1" />
        <asp:BoundField DataField="C2" HeaderText="C2" SortExpression="C2" />
        <asp:BoundField DataField="S2" HeaderText="S2" SortExpression="S2" />
        <asp:BoundField DataField="分光儀編號" HeaderText="分光儀編號" SortExpression="分光儀編號" />
        <asp:BoundField DataField="輻射" HeaderText="輻射" SortExpression="輻射" />
        <asp:BoundField DataField="連鑄爐次" HeaderText="連鑄爐次" SortExpression="連鑄爐次" />
        <asp:BoundField DataField="最後爐" HeaderText="最後爐" SortExpression="最後爐" />
        <asp:BoundField DataField="驗收料" HeaderText="驗收料" SortExpression="驗收料" />
        <asp:BoundField DataField="備註1" HeaderText="備註1" SortExpression="備註1" />
        <asp:BoundField DataField="資料異動者" HeaderText="資料異動者" SortExpression="資料異動者" />

        <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" />
        <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" />
        <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" />
        <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" />
        <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" />
        <asp:BoundField DataField="GP" HeaderText="GP" SortExpression="GP" />
        <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" />

    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="SMPWork.ElementChangeSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfArg0" Name="IsButtonClick" 
            PropertyName="Value" Type="Boolean" />
        <asp:ControlParameter ControlID="hfArg1" Name="StoveNumber" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfArg2" Name="StationName" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:HiddenField ID="hfArg1" runat="server" />
<asp:HiddenField ID="hfArg2" runat="server" />
<asp:HiddenField ID="hfArg0" runat="server" />



