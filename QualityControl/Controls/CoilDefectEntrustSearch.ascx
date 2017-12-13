<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilDefectEntrustSearch.ascx.vb" Inherits="QualityControl.CoilDefectEntrustSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:MultiView ID="MultiView1" runat="server"
    EnableViewState="True" ActiveViewIndex="0">
    <asp:View ID="SearchView" runat="server">
<style type="text/css">
    .style1
    {
        width: 145px;
    }
</style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                鋼種:
                </td>
                    <td><asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
                        (兩個以上以 &#39;,&#39; 分隔 ex:201,301)
                    </td>

            </tr>
            <tr>
            
            
                <td class="style1">
                    缺陷代碼:</td>
                    <td>
                        <asp:TextBox ID="tbBugCode" runat="server" Width="270px"></asp:TextBox>
                        (兩個以上以 &#39;,&#39; 分隔)</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="入廠日期:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbStartDate">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbEndDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="False" Text="產線日期:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbProLineStartDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbProLineStartDate">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="tbProLineEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbProLineEndDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    品檢線別:
                </td>
                <td>
                    <asp:TextBox ID="tbProuctLine" runat="server" Width="344px"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    綜合程度:
                </td>
                <td>
                    <asp:TextBox ID="tbTotalEvent" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)</td>
            </tr>
            <tr>
                <td class="style1">
                    批次:
                </td>
                <td>
                    <asp:TextBox ID="tbLotsNumbers" runat="server"></asp:TextBox>
                    (兩個以上以&nbsp; &#39;,&#39; 分隔 或 &#39;~&#39;指定範圍 2選1)</td>
            </tr>
            <tr>
                <td class="style1">
                    缺陷寬度:
                </td>
                <td>
                    <table>
                        <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True"  Value=">" >大於</asp:ListItem>
                                <asp:ListItem Value="<" >小於</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox ID="tbBugWidth" runat="server" Width="70px"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style1">缺陷面代碼:
                </td>
                <td>
                    <asp:TextBox ID="tbFrontBackCode" runat="server" Height="19px"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔)
                </td>
            </tr>
            <tr>
                <td class="style1">煉鋼異常代碼:</td>
                <td>
                    <asp:TextBox ID="tbSteelBugCodes" runat="server"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)
                </td>
            </tr>
            <tr>
                <td class="style1">密度:</td>
                <td>
                    <asp:TextBox ID="tbDefective" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔) </td>
            </tr>
            <tr>
                <td class="style1">排序:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="lbSort" runat="server" AutoPostBack="True" Width="146px" 
                                Rows="7">
                                <asp:ListItem Value="BWD01">熱軋號碼</asp:ListItem>
                                <asp:ListItem Value="BWD11">批次</asp:ListItem>
                                <asp:ListItem Value="BWD07">鋼胚號碼</asp:ListItem>
                                <asp:ListItem Value="BWD09">鋼捲號碼</asp:ListItem>
                                <asp:ListItem Value="BWD08">入廠產日</asp:ListItem>
                                <asp:ListItem Value="BWD02">鋼種</asp:ListItem>
                                <asp:ListItem Value="BWD19">材質</asp:ListItem>
                            </asp:ListBox>
                            <asp:Button ID="btnSortUp" runat="server" Enabled="False" Text="上移" 
                                Width="80px" />
                            <asp:Button ID="btnSortDown" runat="server" Enabled="False" Text="下移" 
                                Width="80px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" style="height: 21px" />
                    <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View1" runat="server">
        <asp:Button ID="btnBackSearch2" runat="server" Text="返回查詢頁面" Width="108px" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult1" EnableViewState="False" Width="2200px">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="加工業(外購)批次" HeaderText="加工業(外購)批次" 
                    SortExpression="加工業(外購)批次" />
                <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="入廠產日" HeaderText="入廠產日" SortExpression="入廠產日" />
                <asp:BoundField DataField="產線日期" HeaderText="產線日期" SortExpression="產線日期" />
                <asp:BoundField DataField="追蹤線別" HeaderText="追蹤線別" 
                    SortExpression="追蹤線別" />
                <asp:BoundField DataField="公稱厚度" HeaderText="公稱厚度" SortExpression="公稱厚度" />
                <asp:BoundField DataField="缺陷代號" HeaderText="缺陷代號" SortExpression="缺陷代號" />
                <asp:BoundField DataField="程度" HeaderText="程度" SortExpression="程度" />
                <asp:BoundField DataField="分佈" HeaderText="分佈" SortExpression="分佈" />
                <asp:BoundField DataField="直起" HeaderText="直起" SortExpression="直起" />
                <asp:BoundField DataField="直終" HeaderText="直終" SortExpression="直終" />
                <asp:BoundField DataField="橫起" HeaderText="橫起" SortExpression="橫起" />
                <asp:BoundField DataField="橫終" HeaderText="橫終" SortExpression="橫終" />
                <asp:BoundField DataField="正反" HeaderText="正反" SortExpression="正反" />
                <asp:BoundField DataField="密度" HeaderText="密度" SortExpression="密度" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
            SelectMethod="Search" TypeName="QualityControl.CoilDefectEntrustSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfSortFieldsList" Name="OrderFieldList" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfSQLString" runat="server" />
<asp:HiddenField ID="hfSortFieldsList" runat="server" />

