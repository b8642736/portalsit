<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SampleStatusDetailSearch.ascx.vb" Inherits="SMPWork.SampleStatusDetailSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">

    .style1
    {
        width: 41px;
    }
</style>
<table style="width:1200px;">
    <tr>
        <td class="style1">
            站別:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="E1">E1</asp:ListItem>
                <asp:ListItem Value="E2">E2</asp:ListItem>
                <asp:ListItem>A1</asp:ListItem>
                <asp:ListItem>L1</asp:ListItem>
                <asp:ListItem>C1</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            日期:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbStartDate">
            </cc1:CalendarExtender>
            ~<asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                TargetControlID="tbEndDate">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1" />
            缺陷:</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btAllSelect" runat="server" Text="全選" Width="60px" />
                    <asp:Button ID="btAllNotSelect" runat="server" Text="清除" Width="60px" />
                    <asp:HiddenField ID="hfSelectItems" runat="server" />
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">正常</asp:ListItem>
                        <asp:ListItem Value="2">太短</asp:ListItem>
                        <asp:ListItem Value="3">夾渣(輕)</asp:ListItem>
                        <asp:ListItem Value="4">夾渣(中)</asp:ListItem>
                        <asp:ListItem Value="5">夾渣(重)</asp:ListItem>
                        <asp:ListItem Value="6">裂痕(輕)</asp:ListItem>
                        <asp:ListItem Value="7">裂痕(中)</asp:ListItem>
                        <asp:ListItem Value="8">裂痕(重)</asp:ListItem>
                        <asp:ListItem Value="9">氣孔(輕)</asp:ListItem>
                        <asp:ListItem Value="10">氣孔(中)</asp:ListItem>
                        <asp:ListItem Value="11">氣孔(重)</asp:ListItem>
                        <asp:ListItem Value="12">重取</asp:ListItem>
                        <asp:ListItem Value="13">樣品異型</asp:ListItem>
                        <asp:ListItem Value="14">直徑太小</asp:ListItem>
                        <asp:ListItem Value="15">分析差異過大</asp:ListItem>
                        <asp:ListItem Value="16">收樣已冷卻</asp:ListItem>
                        <asp:ListItem Value="17">輸送設備異常</asp:ListItem>
                    </asp:CheckBoxList>
                </ContentTemplate>
            </asp:UpdatePanel>
         </td>
   </tr>
   <tr>
        <td class="style1">爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumbers" runat="server" Width="250px"></asp:TextBox>
            (兩爐以上請以&#39;,&#39;分割)</td>
   </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchClear" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" Width="100%" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號" />
        <asp:BoundField DataField="站別" HeaderText="站別" SortExpression="站別" />
        <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
        <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
        <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
        <asp:BoundField DataField="取樣品質說明" HeaderText="取樣品質說明" 
            SortExpression="取樣品質說明" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="SMPWork.SampleStatusDetailSearch">
    <SelectParameters>
        <asp:ControlParameter ControlID="RadioButtonList2" Name="SearchStation" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="tbStartDate" Name="StartDate" 
            PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="tbEndDate" Name="EndDate" PropertyName="Text" 
            Type="DateTime" />
        <asp:ControlParameter ControlID="hfSelectItems" Name="BugFieltItems" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="tbStoveNumbers" Name="StoveNumbers" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
