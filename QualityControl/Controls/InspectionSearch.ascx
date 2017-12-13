<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InspectionSearch.ascx.vb" Inherits="QualityControl.InspectionSearch" %>
<style type="text/css">
    .auto-style1 {
        width: 132px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumber" runat="server" Width="300px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td  class="auto-style1">內外銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value=" ">內銷</asp:ListItem>
                <asp:ListItem Value="X">外銷</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td class="auto-style1">表面:</td>
        <td>
            <asp:TextBox ID="tbFace" runat="server" Width="119px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">鋼種:</td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="300px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server" Width="300px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">參照規範:</td>
        <td>
            <asp:TextBox ID="tbSpec" runat="server" Width="300px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">訂單號碼:</td>
        <td>
            <asp:TextBox ID="tbOrderNumber" runat="server" Width="300px"></asp:TextBox>
            (兩筆資料以上請以 &#39;,&#39; 區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="odsSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="訂單編號" HeaderText="訂單編號" SortExpression="訂單編號" />
        <asp:BoundField DataField="本單編號" HeaderText="本單編號" SortExpression="本單編號" />
        <asp:BoundField DataField="產品編號" HeaderText="產品編號" SortExpression="產品編號" />
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="產品型態" HeaderText="產品型態" SortExpression="產品型態" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
        <asp:BoundField DataField="產品尺寸" HeaderText="產品尺寸" SortExpression="產品尺寸" />
        <asp:BoundField DataField="淨重" HeaderText="淨重" SortExpression="淨重" />
        <asp:BoundField DataField="參照規範" HeaderText="參照規範" SortExpression="參照規範" />
        <asp:BoundField DataField="成份C" HeaderText="成份C" SortExpression="成份C" />
        <asp:BoundField DataField="成份Si" HeaderText="成份Si" SortExpression="成份Si" />
        <asp:BoundField DataField="成份Mn" HeaderText="成份Mn" SortExpression="成份Mn" />
        <asp:BoundField DataField="成份P" HeaderText="成份P" SortExpression="成份P" />
        <asp:BoundField DataField="成份S" HeaderText="成份S" SortExpression="成份S" />
        <asp:BoundField DataField="成份Cr" HeaderText="成份Cr" SortExpression="成份Cr" />
        <asp:BoundField DataField="成份Ni" HeaderText="成份Ni" SortExpression="成份Ni" />
        <asp:BoundField DataField="成份N" HeaderText="成份N" SortExpression="成份N" />
        <asp:BoundField DataField="成份Cu" HeaderText="成份Cu" SortExpression="成份Cu" />
        <asp:BoundField DataField="抗拉強度" HeaderText="抗拉強度" SortExpression="抗拉強度" />
        <asp:BoundField DataField="降伏強度" HeaderText="降伏強度" SortExpression="降伏強度" />
        <asp:BoundField DataField="伸長率" HeaderText="伸長率" SortExpression="伸長率" />
        <asp:BoundField DataField="硬度" HeaderText="硬度" SortExpression="硬度" />
        <asp:BoundField DataField="Rp" HeaderText="Rp" SortExpression="Rp" />
        <asp:BoundField DataField="出口國別" HeaderText="出口國別" SortExpression="出口國別" />
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hfQryString" runat="server" />
<%--<asp:HiddenField ID="hfQryFilterCoilNumber" runat="server" />
<asp:HiddenField ID="hfQryFilterHeat" runat="server" />
<asp:HiddenField ID="hfQryFilterFinish" runat="server" />
<asp:HiddenField ID="hfQryFilterGrade" runat="server" />--%>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="QualityControl.InspectionSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="SQLString" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="tbCoilNumber" Name="FilterCoilNumber" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbStoveNumber" Name="FilterHeat" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbFace" Name="FilterFinish" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbSteelKind" Name="FilterGrade" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>


