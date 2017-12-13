<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SGMBadQualitySearch.ascx.vb" Inherits="StockStatic.SGMBadQualitySearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<table style="width:100%;">
    <tr>
        <td class="style1">
            澆鑄日期:</td>
        <td>
            <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="G1" 
                Text="篩選查詢" />
            <asp:TextBox ID="btSearchDate1" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btSearchDate1">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="btSearchDate2" runat="server" Width="90px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="btSearchDate2">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            熱軋批次:</td>
        <td>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1" Text="篩選查詢" />
            <asp:TextBox ID="btBatch1" runat="server" Width="90px"></asp:TextBox>
            ~<asp:TextBox ID="btBatch2" runat="server" Width="90px"></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td class="style1">
            爐號範圍篩選:</td>
        <td>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="G1" Text="篩選查詢" />
            A爐:<asp:TextBox ID="tbStoveA1" runat="server" Width="90px"></asp:TextBox>
            ~<asp:TextBox ID="tbStoveA2" runat="server" Width="90px"></asp:TextBox>
            　B爐:<asp:TextBox ID="tbStoveB1" runat="server" Width="90px"></asp:TextBox>
            ~<asp:TextBox ID="tbStoveB2" runat="server" Width="90px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>執行查詢:
           </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnResetSearch" runat="server" Text="重設查詢條件" Width="100px" 
                style="height: 21px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="轉換為Excel" 
                Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="odsSearchResult" Height="246px" 
    Width="100%">
    <Columns>
        <asp:BoundField DataField="SGA07DateType" HeaderText="澆鑄日期" 
            SortExpression="SGA07DateType" DataFormatString="{0:d}" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="StoveKindName1" HeaderText="鋼種" 
            SortExpression="StoveKindName1" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="StoveNumber" HeaderText="鋼胚編號" 
            SortExpression="StoveNumber" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="DisplaySize" HeaderText="研磨後尺寸(厚*寬*長)" 
            SortExpression="DisplaySize" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="GrindWeight" HeaderText="研磨重量(公斤)" 
            SortExpression="GrindWeight">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="GrindRate" HeaderText="研磨率" 
            SortExpression="GrindRate" DataFormatString="{0:N3}" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search" TypeName="StockStatic.SGMBadQualitySearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="RadioButton1" Name="IsFilter1" 
            PropertyName="Checked" Type="Boolean" />
        <asp:ControlParameter ControlID="btSearchDate1" Name="Startate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="btSearchDate2" Name="EndDate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="RadioButton2" Name="IsFilter2" 
            PropertyName="Checked" Type="Boolean" />
        <asp:ControlParameter ControlID="btBatch1" Name="StartBatch" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="btBatch2" Name="EndBatch" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="RadioButton3" Name="IsFilter3" 
            PropertyName="Checked" Type="Boolean" />
        <asp:ControlParameter ControlID="tbStoveA1" Name="StartStoveA1" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbStoveA2" Name="StartStoveA2" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbStoveB1" Name="StartStoveB1" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbStoveB2" Name="StartStoveB2" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

