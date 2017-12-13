<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetDeclareMemoEdit.ascx.vb" Inherits="AST500LB.AssetDeclareMemoEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 86px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            資產編號:</td>
        <td>
            <asp:TextBox ID="tbNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            資產名稱:</td>
        <td>
            <asp:TextBox ID="tbAssetName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">報廢期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbStartDate_CalendarExtender" runat="server" 
                TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" 
                TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">狀態關鍵字:</td>
        <td>
            <asp:TextBox ID="tbStationKeyWords" runat="server" Width="210px"></asp:TextBox>
            (多個關鍵字請以&#39;@&#39;分割,例: 報廢@變賣)</td>
    </tr>
    <tr>
        <td class="style1">備註關鍵字:</td>
        <td>
            <asp:TextBox ID="tbMemoKeyWords" runat="server" Width="210px"></asp:TextBox>
            (多個關鍵字請以&#39;@&#39;分割)</td>
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
    DataSourceID="odsSearchResult" EnableModelValidation="True" Width="100%" 
    AllowPaging="True" DataKeyNames="NUMBER,DATEC">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <EditItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="更新" />
                &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" 
                    CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="編輯" />
                &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="清除備註" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="Button2" ConfirmText="是否確定清除?" runat="server">
                </cc1:ConfirmButtonExtender>            
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="NUMBER" HeaderText="資產編號" ReadOnly="True"  SortExpression="NUMBER" />
        <asp:BoundField DataField="About_ASTB03PF_Name" HeaderText="資產名稱" 
            ReadOnly="True" SortExpression="About_ASTB03PF_Name" />
        <asp:BoundField DataField="Quantity" HeaderText="數量" ReadOnly="True" 
            SortExpression="Quantity">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="UseDept" HeaderText="使用單位" ReadOnly="True" 
            SortExpression="UseDept">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="DATEC" HeaderText="報廢年月" ReadOnly="True" 
            SortExpression="DATEC" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="MEMO1" HeaderText="簽准報廢品處理方式" 
            SortExpression="MEMO1" />
        <asp:BoundField DataField="STATION" HeaderText="處理結果" 
            SortExpression="STATION" />
    </Columns>
</asp:GridView>


<asp:HiddenField ID="hfQryString" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    DataObjectTypeName="CompanyORMDB.AST500LB.ASTB05PF" DeleteMethod="CDBDelete" 
    SelectMethod="Search" TypeName="AST500LB.AssetDeclareMemoEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>



