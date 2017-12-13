<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AgencyStockStatic.ascx.vb" Inherits="StockStatic.AgencyStockStatic" %>
<style type="text/css">
    .style1
    {
        width: 111px;
    }
    .style2
    {
        height: 44px;
    }
</style>
&nbsp; &nbsp; &nbsp;
<table style="width: 808px; height: 1px">
    <%--    <tr>
        <td >
            </td>
        <td >
            </td>
        <td style="width: 111px" />
        <td />
        <td />
    </tr>--%>
    <tr>
        <td class="style1">
            篩選鋼種:</td>
        <td class="style2">
            <%--<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SDSSteelKind" DataTextField="SGA05"
                DataValueField="SGA05" Width="176px">
            </asp:DropDownList></td>--%>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="176px">
            </asp:DropDownList></td>

 </tr>
 <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="澆鑄日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
 </tr>
 <tr>
    <td>輸出格式:</td>
    <td>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">格式1</asp:ListItem>
            <asp:ListItem Value="1">格式2</asp:ListItem>
        </asp:RadioButtonList>
     </td>
 </tr>
 <tr>
       <td class="style1"></td>
       <td><asp:Button ID="btnRefresh" runat="server" Text="統計庫存" Width="103px" />
           <asp:Button ID="tbConvertToExcel" runat="server" Text="下載Excel檔" 
               Width="100px" />
       </td>
 </tr>
</table>
<%--<asp:SqlDataSource ID="SDSSteelKind" runat="server" ConnectionString="<%$ ConnectionStrings:AS400 %>"
    ProviderName="<%$ ConnectionStrings:AS400.ProviderName %>" SelectCommand="Select Distinct SGA05 FROM SMS100LB.SMSSGAPF">
</asp:SqlDataSource>--%>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Height="248px" Width="980px" DataSourceID="odsSearchResult" 
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="鋼種尺寸" HeaderText="鋼種尺寸">
                <ItemStyle HorizontalAlign="Left" Width="120" />
                </asp:BoundField>
                <asp:BoundField DataField="數量小計" HeaderText="塊數小計">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="重量小計" DataFormatString="{0:N0}" HeaderText="重量小計">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="未研磨數量" HeaderText="未研磨塊數">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="未研磨重量" DataFormatString="{0:N0}" HeaderText="未研磨重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="已研磨未繳庫數量" HeaderText="已研磨未繳庫塊數">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="已研磨未繳庫重量" DataFormatString="{0:N0}" 
                    HeaderText="已研磨未繳庫重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="繳庫數量" HeaderText="已研磨繳庫塊數">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="繳庫重量" DataFormatString="{0:N0}" HeaderText="已研磨繳庫重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="中鋼代工數量" HeaderText="中鋼代工數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="中鋼代工重量" DataFormatString="{0:N0}" 
                    HeaderText="中鋼代工重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="燁聯代工數量" HeaderText="燁聯代工數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="燁聯代工重量" DataFormatString="{0:N0}" 
                    HeaderText="燁聯代工重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="其它代工數量" HeaderText="其它代工數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="其它代工重量" DataFormatString="{0:N0}" 
                    HeaderText="其它代工重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle Font-Size="Small" Font-Underline="False" />
            <AlternatingRowStyle ForeColor="Blue" />
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult1" EnableModelValidation="True" Height="248px" 
            Width="980px">
            <Columns>
                <asp:BoundField DataField="尺寸" HeaderText="尺寸" SortExpression="尺寸">
                </asp:BoundField>
                <asp:BoundField DataField="計劃代軋量" HeaderText="計劃代軋量" SortExpression="計劃代軋量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="數量小計" HeaderText="數量小計" SortExpression="數量小計">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="重量小計" HeaderText="重量小計" SortExpression="重量小計">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="未研磨數量" HeaderText="未研磨數量" SortExpression="未研磨數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="未研磨重量" HeaderText="未研磨重量" 
                    SortExpression="未研磨重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="已研磨未繳庫數量" HeaderText="已研磨未繳庫數量" 
                    SortExpression="已研磨未繳庫數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="已研磨未繳庫重量" HeaderText="已研磨未繳庫重量" 
                    SortExpression="已研磨未繳庫重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="繳庫數量" HeaderText="繳庫數量" SortExpression="繳庫數量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="繳庫重量" HeaderText="繳庫重量" SortExpression="繳庫重量">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                
            </Columns>
            <HeaderStyle Font-Size="Small" Font-Underline="False" />
        </asp:GridView>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfQry" runat="server" />
<asp:HiddenField ID="hfCCMQry" runat="server" />
<asp:HiddenField ID="hfSGMQry" runat="server" />
<asp:ObjectDataSource ID="odsSearchResult" runat="server" 
    SelectMethod="Search0" TypeName="StockStatic.AgencyStockStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
    SelectMethod="Search1" TypeName="StockStatic.AgencyStockStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value" 
            Type="String" />
        <asp:ControlParameter ControlID="hfCCMQry" Name="CCMQry" PropertyName="Value" 
            Type="String" />
        <asp:ControlParameter ControlID="hfSGMQry" Name="SGMQry" PropertyName="Value" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--<uc1:AgencyStockStatic_Sub1 ID="AgencyStockStatic_Sub1_1" runat="server" />--%>
