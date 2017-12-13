<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssetDepreciationForecast.ascx.vb" Inherits="AST500LB.AssetDepreciationForecast" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 80px;
    }
    .style2
    {
        width: 80px;
        height: 23px;
    }
    .style3
    {
        height: 23px;
    }
</style> 

<table style="width:100%;">
            <tr>
                <td class="style1">
                    期間:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
                    年<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    月~<asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
                    年<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    月</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbIsJunkFilter" runat="server" Text="報廢期間:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbJunkStartDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                        TargetControlID="tbJunkStartDate">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="tbJunkEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" 
                        TargetControlID="tbJunkEndDate">
                    </cc1:CalendarExtender>
                    <asp:HiddenField ID="hfJunkStartAndEndDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style2" />
                資產編號:<td class="style3" />
                <asp:TextBox ID="TextBox3" runat="server" Width="204px"></asp:TextBox>
            </tr>
            <tr>
                <TD class="style1" />
                使用單位:<TD />
                <asp:TextBox ID="TextBox4" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                (EX:可輸入D或D11)(多個單位請以&#39;,&#39;分開EX:D11,D13</tr>
            <tr>
                <TD class="style1" />
                資產類別:<TD />
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                (多個資產類別以&#39;,&#39;分開)</tr>
            <tr>
                <TD class="style1" />
                資產狀態<TD /> 
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" 
                    RepeatDirection="Horizontal" Width="207px">
                    <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">閒置</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">出租</asp:ListItem>
                </asp:CheckBoxList>
                <asp:HiddenField ID="hfAssetState" runat="server" />
            </tr>
            <tr>
                <TD class="style1" />
                廠別:<TD />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">SA</asp:ListItem>
                    <asp:ListItem>AA</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>BA</asp:ListItem>
                    <asp:ListItem>QA</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>RA</asp:ListItem>
                    <asp:ListItem>RC</asp:ListItem>
                    <asp:ListItem>RD</asp:ListItem>
                </asp:RadioButtonList>
            </tr>
            <tr>
                <td class="style1">
                    輸出格式:</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">一般格式</asp:ListItem>
                        <asp:ListItem Value="1">期間合計格式</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="折舊估算" Width="100px" />
                    <asp:Button ID="btnSearchDownload" runat="server" Text="估算Excel下載" 
                        Width="100px" />
                </td>
            </tr>
        </table>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsSearchResult" Width="1000px" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="使用單位" HeaderText="使用單位" SortExpression="使用單位" >
        </asp:BoundField>
        <asp:BoundField DataField="資產編號" HeaderText="資產編號" SortExpression="資產編號" />
        <asp:BoundField DataField="資產名稱" HeaderText="資產名稱" SortExpression="資產名稱" />
        <asp:BoundField DataField="入帳年月" HeaderText="入帳年月" 
            SortExpression="入帳年月" >
        </asp:BoundField>
        <asp:BoundField DataField="使用年限" HeaderText="使用年限" SortExpression="使用年限" >
        </asp:BoundField>
        <asp:BoundField DataField="帳面金額" HeaderText="帳面金額" SortExpression="帳面金額" />
        <asp:BoundField DataField="折舊年月" HeaderText="折舊年月" SortExpression="折舊年月" />
        <asp:BoundField DataField="折舊金額" HeaderText="折舊金額" SortExpression="折舊金額" />
        <asp:BoundField DataField="累計折舊金額" HeaderText="累計折舊金額" SortExpression="累計折舊金額" >
        </asp:BoundField>
        <asp:BoundField DataField="殘值" HeaderText="殘值" SortExpression="殘值" >
        </asp:BoundField>
        <asp:BoundField DataField="報廢日期" 
            HeaderText="報廢日期" SortExpression="報廢日期" />
    </Columns>
</asp:GridView>

<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
    TypeName="AST500LB.AssetDepreciationForecast">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="StartYear" PropertyName="Text" 
            Type="Int32" />
        <asp:ControlParameter ControlID="DropDownList1" Name="StartMonth" PropertyName="SelectedValue" 
            Type="Int32" />
        <asp:ControlParameter ControlID="TextBox2" Name="EndYear" PropertyName="Text" 
            Type="Int32" />
        <asp:ControlParameter ControlID="DropDownList2" Name="EndMonth" 
            PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="TextBox3" Name="AssetNumber" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="RadioButtonList1" Name="PlanCode" 
            PropertyName="SelectedValue" Type="String" />
        <asp:ControlParameter ControlID="TextBox4" Name="Units" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="TextBox5" Name="AssetClass" 
            PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="hfAssetState" Name="AssetState" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfJunkStartAndEndDate" 
            Name="JunkStartDateAndEndDate" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult0" Width="1000px" 
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="使用單位" HeaderText="使用單位" SortExpression="使用單位" />
                <asp:BoundField DataField="資產編號" HeaderText="資產編號" SortExpression="資產編號" />
                <asp:BoundField DataField="資產名稱" HeaderText="資產名稱" SortExpression="資產名稱" />
                <asp:BoundField DataField="入帳年月" HeaderText="入帳年月" SortExpression="入帳年月" />
                <asp:BoundField DataField="使用年限" HeaderText="使用年限" SortExpression="使用年限" />
                <asp:BoundField DataField="帳面金額" HeaderText="帳面金額" SortExpression="帳面金額" />
                <asp:BoundField DataField="折舊年月" HeaderText="折舊年月" SortExpression="折舊年月" />
                <asp:BoundField DataField="折舊金額" HeaderText="折舊金額" SortExpression="折舊金額" />
                <asp:BoundField DataField="累計折舊金額" HeaderText="累計折舊金額" 
                    SortExpression="累計折舊金額" />
                <asp:BoundField DataField="殘值" HeaderText="殘值" SortExpression="殘值" />
                <asp:BoundField DataField="報廢日期" HeaderText="報廢日期" SortExpression="報廢日期" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult0" runat="server" 
            SelectMethod="Search1" TypeName="AST500LB.AssetDepreciationForecast">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="StartYear" PropertyName="Text" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList1" Name="StartMonth" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="TextBox2" Name="EndYear" PropertyName="Text" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList2" Name="EndMonth" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="TextBox3" Name="AssetNumber" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="RadioButtonList1" Name="PlanCode" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TextBox4" Name="Units" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TextBox5" Name="AssetClass" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="hfAssetState" Name="AssetState" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfJunkStartAndEndDate" 
                    Name="JunkStartDateAndEndDate" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>



