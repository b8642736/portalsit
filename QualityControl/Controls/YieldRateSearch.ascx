<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YieldRateSearch.ascx.vb" Inherits="QualityControl.YieldRateSearch" %>
<style type="text/css">
    .style1
    {
        width: 106px;
    }
</style>
<table style="width:100%;">
   <tr>
        <td class="style1">
            日期類別:</td>
        <td>
            <asp:DropDownList ID="ddsSearchDateMode" runat="server">
                <asp:ListItem>會計日期</asp:ListItem>
                <asp:ListItem>繳庫日期</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" style="margin-bottom: 0px" 
                Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style1">查詢模式:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">依表面合計</asp:ListItem>
                <asp:ListItem Value="1">鋼捲細目</asp:ListItem>
                <asp:ListItem Value="2">依表面合計格式2</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbSearchToExcel" runat="server" Text="Excel查詢下載" 
                Width="100px" />
        </td>
    </tr>

</table>


<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSSearchResult" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="投入量" HeaderText="投入量" SortExpression="投入量" />
                <asp:BoundField DataField="產出量" HeaderText="產出量" SortExpression="產出量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="一級品率" HeaderText="一級品率" SortExpression="一級品率" />
                <asp:BoundField DataField="熱軋投入量" HeaderText="熱軋投入量" SortExpression="熱軋投入量" />
                <asp:BoundField DataField="熱軋產出量" HeaderText="熱軋產出量" SortExpression="熱軋產出量" />
                <asp:BoundField DataField="熱軋產出率" HeaderText="熱軋產出率" SortExpression="熱軋產出率" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSSearchResult" runat="server" SelectMethod="Search" 
            TypeName="QualityControl.YieldRateSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSSearchResult0" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="投入量" HeaderText="投入量" SortExpression="投入量" />
                <asp:BoundField DataField="產出量" HeaderText="產出量" SortExpression="產出量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="一級品率" HeaderText="一級品率" SortExpression="一級品率" />
                <asp:BoundField DataField="熱軋投入量" HeaderText="熱軋投入量" SortExpression="熱軋投入量" />
                <asp:BoundField DataField="熱軋產出量" HeaderText="熱軋產出量" SortExpression="熱軋產出量" />
                <asp:BoundField DataField="熱軋產出率" HeaderText="熱軋產出率" SortExpression="熱軋產出率" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSSearchResult0" runat="server" 
            SelectMethod="Search0" TypeName="QualityControl.YieldRateSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View3" runat="server">

        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ODSSearchResult2" Width="100%" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
                <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
                <asp:BoundField DataField="投入量" HeaderText="投入量" SortExpression="投入量" />
                <asp:BoundField DataField="產出量" HeaderText="產出量" SortExpression="產出量" />
                <asp:BoundField DataField="產出率" HeaderText="產出率" SortExpression="產出率" />
                <asp:BoundField DataField="一級品率" HeaderText="一級品率" SortExpression="一級品率" />
                <asp:BoundField DataField="熱軋投入量" HeaderText="熱軋投入量" SortExpression="熱軋投入量" />
                <asp:BoundField DataField="熱軋產出量" HeaderText="熱軋產出量" SortExpression="熱軋產出量" />
                <asp:BoundField DataField="熱軋產出率" HeaderText="熱軋產出率" SortExpression="熱軋產出率" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSSearchResult2" runat="server" SelectMethod="Search2" TypeName="QualityControl.YieldRateSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </asp:View>
</asp:MultiView>



<asp:HiddenField ID="hfSQLString" runat="server" />






