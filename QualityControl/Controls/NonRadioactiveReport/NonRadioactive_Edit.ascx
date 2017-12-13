<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NonRadioactive_Edit.ascx.vb" Inherits="QualityControl.NonRadioactive_Edit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!-- CSS --------------------------------------------------------->
<style type="text/css">
    .styleTable1 {
        width: 100%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

        .styleTable1 td {
            height: 30px;
            border-width: 2px;
            border-style: dotted;
            border-collapse: collapse;
            border-color: #cccccc;
        }

    .edit-style4 {
        height: 15%;
    }

    .edit-style5 {
        width: 85%;
    }

    .edit-style6 {
        width: 80%;
    }

    .auto-style3 {
        height: 15%;
        width: 15px;
    }

    .auto-style4 {
        height: 30px;
    }
</style>

<!--  --------------------------------------------------------->

<asp:MultiView ID="MultiView1" runat="server">

    <!--  View1 --------------------------------------------------------->
    <asp:View ID="View1" runat="server">

        <table id="Table1" class="styleTable1">
            <tr>
                <td class="edit-style4" colspan="3">
                    <asp:Label ID="Label3" runat="server" Text="一、新增鋼捲清單"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="edit-style4">
                    <asp:Label ID="Label2" runat="server" Text="查詢模式："></asp:Label>
                </td>
                <td class="edit-style5">
                    <asp:DropDownList ID="ddSearchType" runat="server" Enabled="False" Width="200px" />
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="edit-style4">
                    <asp:Label ID="Label1" runat="server" Text="號碼："></asp:Label>
                </td>
                <td class="edit-style5">
                    <asp:TextBox ID="tbLabNo" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                    (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
            </tr>
            <tr>
                <td class="edit-style4" colspan="2">&nbsp;</td>
                <td class="edit-style5">
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Height="35px" Width="200px" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="width: 200px" colspan="3">
                    <asp:Label ID="Label10" runat="server" Text="二、已加入鋼捲清單"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="edit-style4" colspan="2">
                    <asp:Label ID="lbBuyer" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="Cornsilk" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="提貨編號" HeaderText="提貨編號" SortExpression="DELIVERY_NUM">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="訂單號" HeaderText="訂單號" SortExpression="ORDER_NUM">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="客戶代號" HeaderText="客戶代號" SortExpression="CUST_NUM">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="COIL_NUM">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="HEAT_NO">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="爐號編號2" HeaderText="爐號編號2" SortExpression="CAST_NO">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="產品型態" HeaderText="產品型態" SortExpression="PRODUCT">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="鋼種名稱" HeaderText="鋼種名稱" SortExpression="STEEL_GRAGE">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="FINISH">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="料別" HeaderText="料別" SortExpression="CATEGORY">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="THICKNESS">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="WIDTH">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="淨重" HeaderText="淨重" SortExpression="NETWEIGHT">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="參照規範" HeaderText="參照規範" SortExpression="SPECIFCATION">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <EmptyDataRowStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <FooterStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <HeaderStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" HorizontalAlign="Center" Wrap="True" />
                        <RowStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <SelectedRowStyle BackColor="#CE5D5A" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="Black" />
                    </asp:GridView>
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="852px">
                        <AlternatingRowStyle BackColor="Cornsilk" />
                        <Columns>
                            <asp:BoundField DataField="LAB_REPORTNO" HeaderText="單號" SortExpression="LAB_REPORTNO">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="表面" HeaderText="表面" SortExpression="表面">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="寬度" HeaderText="寬度" SortExpression="寬度">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量">
                            <HeaderStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#DCDCDC" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#DCDCDC" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="Black" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="edit-style4" colspan="2">&nbsp;</td>
                <td class="edit-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="edit-style4" colspan="3">
                    <asp:Label ID="Label5" runat="server" Text="三、細項設定"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="edit-style4">&nbsp;</td>
                <td class="edit-style4">
                    <asp:Label ID="Label6" runat="server" Text="語系："></asp:Label>
                </td>
                <td class="edit-style5">
                    <asp:DropDownList ID="ddLanguage" runat="server" AutoPostBack="True" Enabled="False" Width="200px" />
                </td>
            </tr>
            <tr>
                <td class="edit-style4">&nbsp;</td>
                <td class="edit-style4">
                    <asp:CheckBox ID="cb_splitlab" runat="server" AutoPostBack="True" Text="拆單" />
                </td>
                <td class="edit-style5">
                    每<asp:TextBox ID="tb_splitnum" runat="server" Enabled="False" Height="16px" MaxLength="2" Width="24px" Wrap="False"></asp:TextBox>
                    顆鋼捲一份</td>
            </tr>
            <tr>
                <td class="edit-style4" colspan="2">&nbsp;</td>
                <td class="edit-style5">
                    <% PublicClassLibrary.ModTools.showSpace(5)%>
                    &nbsp;<asp:Label ID="lb_Err" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="edit-style4" colspan="2">&nbsp;</td>
                <td class="edit-style5">
                    <asp:Button ID="btnSave" runat="server" Enabled="False" Height="35px" Text="存檔" Width="200px" />
                    <% PublicClassLibrary.ModTools.showSpace(5)%>
                    <asp:Button ID="btnCancel" runat="server" Enabled="False" Height="35px" Text="取消" Width="200px" />
                </td>
            </tr>
        </table>
    </asp:View>

    <!--  View2 --------------------------------------------------------->
    <asp:View ID="View2" runat="server">
        <table id="Table2" class="styleTable1">
            <tr>
                <td class="edit-style5" style="text-align: center">
                    <asp:Label ID="Label9" runat="server" Text="新增鋼捲清單"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="edit-style5">
                    <asp:Button ID="btnSelectAll" runat="server" Text="全選" />
                    <asp:Button ID="btnClearAll" runat="server" Text="清除" />
                    (僅接受同一客戶代號的鋼捲且鋼捲不得重複)<br />
                    <asp:Label ID="lbSearchType" runat="server" ForeColor="Black"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataSourceID="odsSearchResult" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="Cornsilk" />
                        <Columns>
                            <asp:TemplateField HeaderText="加入">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DELIVERY_NUM" HeaderText="提貨編號" SortExpression="DELIVERY_NUM">
                                <FooterStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ORDER_NUM" HeaderText="訂單號" SortExpression="ORDER_NUM">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CUST_NUM" HeaderText="客戶代號" SortExpression="CUST_NUM">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COIL_NUM" HeaderText="鋼捲號碼" SortExpression="COIL_NUM">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HEAT_NO" HeaderText="爐號" SortExpression="HEAT_NO">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CAST_NO" HeaderText="爐號編號2" SortExpression="CAST_NO">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PRODUCT" HeaderText="產品型態" SortExpression="PRODUCT">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STEEL_GRAGE" HeaderText="鋼種名稱" SortExpression="STEEL_GRAGE">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FINISH" HeaderText="表面" SortExpression="FINISH">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CATEGORY" HeaderText="料別" SortExpression="CATEGORY">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="THICKNESS" HeaderText="厚度" SortExpression="THICKNESS">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WIDTH" HeaderText="寬度" SortExpression="WIDTH">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETWEIGHT" HeaderText="淨重" SortExpression="NETWEIGHT">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPECIFCATION" HeaderText="參照規範" SortExpression="SPECIFCATION">
                                <HeaderStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                <ItemStyle BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <HeaderStyle BackColor="#DCDCDC" />
                        <PagerStyle BackColor="#DCDCDC" ForeColor="Black" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <RowStyle BackColor="#DCDCDC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="Black" />
                    </asp:GridView>
                    <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="edit-style5">
                    <asp:Button ID="btnView2Confrim" runat="server" Height="35px" Text="確定" Width="200px" />
                    <% PublicClassLibrary.ModTools.showSpace(5)%>
                    <asp:Button ID="btnView2Cencel" runat="server" Height="35px" Text="取消" Width="200px" />
                    &nbsp;</td>
            </tr>
        </table>
    </asp:View>

    <!--  View3 --------------------------------------------------------->
    <asp:View ID="View3" runat="server">
        <asp:Label ID="LabelView3" runat="server" Text="LabelView3"></asp:Label>
    </asp:View>
</asp:MultiView>
<br />
<asp:ObjectDataSource ID="odsSearchResult" runat="server"
    SelectMethod="Search" TypeName="QualityControl.NonRadioactive_Edit">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL"
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQL" runat="server" />
<asp:ObjectDataSource ID="odsInsert" runat="server"
    SelectMethod="Search" TypeName="QualityControl.NonRadioactive_Edit">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL"
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfInsrtSQL" runat="server" />
<br />














