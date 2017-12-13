<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilLevelWeightSearch.ascx.vb" Inherits="QualityControl.CoilLevelWeightSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            等級:</td>
        <td>
            <asp:TextBox ID="tbLevels" runat="server"></asp:TextBox>
            (兩個以上請以&#39;,&#39;分隔)</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="重量:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartWeight" runat="server" Width="80px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndWeight" runat="server" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnDownToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" EnableModelValidation="True"  Width="3600px" >
    <Columns>
        <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面" />
        <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
        <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度" />
        <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" />
        <asp:BoundField DataField="裁邊" HeaderText="裁邊" SortExpression="裁邊" />
        <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="料別" />
        <asp:BoundField DataField="淨重" HeaderText="淨重" SortExpression="淨重" />
        <asp:BoundField DataField="等級" HeaderText="等級" SortExpression="等級" />
        <asp:BoundField DataField="一級品百分比" HeaderText="一級品百分比" 
            SortExpression="一級品百分比" />
        <asp:BoundField DataField="產出百分比" HeaderText="產出百分比" SortExpression="產出百分比" />
        <asp:BoundField DataField="一級重量" HeaderText="一級重量" SortExpression="一級重量" />
        <asp:BoundField DataField="一級X重量" HeaderText="一級X重量" SortExpression="一級X重量" />
        <asp:BoundField DataField="二級重量" HeaderText="二級重量" 
            SortExpression="二級重量" />
        <asp:BoundField DataField="三級重量" HeaderText="三級重量" SortExpression="三級重量" />
        <asp:BoundField DataField="頭尾重量" HeaderText="頭尾重量" 
            SortExpression="頭尾重量" />
        <asp:BoundField DataField="邊切重量" HeaderText="邊切重量" 
            SortExpression="邊切重量" />
        <asp:BoundField DataField="廢鋼重量" HeaderText="廢鋼重量" 
            SortExpression="廢鋼重量" />
        <asp:BoundField DataField="一級X缺陷" HeaderText="一級X缺陷" 
            SortExpression="一級X缺陷" />
        <asp:BoundField DataField="二級缺陷1" HeaderText="二級缺陷1" 
            SortExpression="二級缺陷1" />
        <asp:BoundField DataField="二級缺陷1重量" HeaderText="二級缺陷1重量" 
            SortExpression="二級缺陷1重量" />
        <asp:BoundField DataField="二級缺陷2" HeaderText="二級缺陷2" 
            SortExpression="二級缺陷2" />
        <asp:BoundField DataField="二級缺陷2重量" HeaderText="二級缺陷2重量" 
            SortExpression="二級缺陷2重量" />
        <asp:BoundField DataField="二級缺陷3" HeaderText="二級缺陷3" 
            SortExpression="二級缺陷3" />
        <asp:BoundField DataField="二級缺陷3重量" HeaderText="二級缺陷3重量" 
            SortExpression="二級缺陷3重量" />
        <asp:BoundField DataField="二級缺陷4" HeaderText="二級缺陷4" 
            SortExpression="二級缺陷4" />
        <asp:BoundField DataField="二級缺陷4重量" HeaderText="二級缺陷4重量" 
            SortExpression="二級缺陷4重量" />
        <asp:BoundField DataField="三級缺陷1" HeaderText="三級缺陷1" 
            SortExpression="三級缺陷1" />
        <asp:BoundField DataField="三級缺陷1重量" HeaderText="三級缺陷1重量" 
            SortExpression="三級缺陷1重量" />
        <asp:BoundField DataField="三級缺陷2" HeaderText="三級缺陷2" SortExpression="三級缺陷2" />
        <asp:BoundField DataField="三級缺陷2重量" HeaderText="三級缺陷2重量" 
            SortExpression="三級缺陷2重量" />
        <asp:BoundField DataField="三級缺陷3" HeaderText="三級缺陷3" SortExpression="三級缺陷3" />
        <asp:BoundField DataField="三級缺陷3重量" HeaderText="三級缺陷3重量" 
            SortExpression="三級缺陷3重量" />
        <asp:BoundField DataField="三級缺陷4" HeaderText="三級缺陷4" SortExpression="三級缺陷4" />
        <asp:BoundField DataField="三級缺陷4重量" HeaderText="三級缺陷4重量" SortExpression="三級缺陷4重量" />
        <asp:BoundField DataField="頭尾缺陷" HeaderText="頭尾缺陷" SortExpression="頭尾缺陷" />
        <asp:BoundField DataField="邊切缺陷" HeaderText="邊切缺陷" SortExpression="邊切缺陷" />
        <asp:BoundField DataField="廢鋼缺陷" HeaderText="廢鋼缺陷" SortExpression="廢鋼缺陷" />
        <asp:BoundField DataField="原因說明" HeaderText="原因說明" SortExpression="原因說明" />
        <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
        <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
        <asp:BoundField DataField="熱軋批號" HeaderText="熱軋批號" 
            SortExpression="熱軋批號" />
        <asp:BoundField DataField="黑皮重" HeaderText="黑皮重" 
            SortExpression="黑皮重" />
        <asp:BoundField DataField="黑皮厚度" HeaderText="黑皮厚度" SortExpression="黑皮厚度" />
        <asp:BoundField DataField="繳庫切除頭尾重" HeaderText="繳庫切除頭尾重" SortExpression="繳庫切除頭尾重" />
        <asp:BoundField DataField="繳庫切除頭尾缺陷" HeaderText="繳庫切除頭尾缺陷" SortExpression="繳庫切除頭尾缺陷" />
        <asp:BoundField DataField="客戶編號" HeaderText="客戶編號" SortExpression="客戶編號" />
        <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.CoilLevelWeightSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="HFQry" Name="SQLString" PropertyName="Value" 
            Type="String" />
        <asp:ControlParameter ControlID="HFQry0" Name="AllPPSSHASQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="HFQry" runat="server" />


<asp:HiddenField ID="HFQry0" runat="server" />


