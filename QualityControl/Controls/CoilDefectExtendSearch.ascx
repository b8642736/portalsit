<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CoilDefectExtendSearch.ascx.vb" Inherits="QualityControl.CoilDefectExtendSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:MultiView ID="MultiView1" runat="server"
    EnableViewState="True" ActiveViewIndex="0">
    <asp:View ID="SearchView" runat="server">
<style type="text/css">
    .style1
    {
        width: 185px;
        text-align:right;
    }
</style>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                鋼胚編號:
                </td>
                <td>
                    <asp:TextBox ID="tbSLABNumber" runat="server" Width="143px"></asp:TextBox>
                    (萬用字元&#39;*&#39; ex:A*-*40)</td>
            </tr>
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
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="鋼胚日期:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbStartDate">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  
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
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server"  
                        Format="yyyy/MM/dd" TargetControlID="tbProLineStartDate">
                    </cc1:CalendarExtender>
                    ~<asp:TextBox ID="tbProLineEndDate" runat="server" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server"  
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
                    &nbsp; DF:</td>
                <td>
                    <asp:TextBox ID="txDF1" runat="server" Width="85px">-999</asp:TextBox>
                    ~<asp:TextBox ID="txDF2" runat="server" Width="85px">999</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp; MD30</td>
                <td>
                    <asp:TextBox ID="txMD301" runat="server" Width="85px">-999</asp:TextBox>
                    ~<asp:TextBox ID="txMD302" runat="server" Width="85px">999</asp:TextBox>
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
                    熱軋批次:
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
                    <asp:TextBox ID="tbFrontBackCode" runat="server"></asp:TextBox>
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
                <td class="style1">煉鋼備註代碼:</td>
                <td>
                    <asp:TextBox ID="tbQCA33Code" runat="server"></asp:TextBox>(兩個以上以 &#39;,&#39; 分隔)
                </td>
            </tr>
            <tr>
                <td class="style1">
                    成份篩選:</td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="50px">
                                    <asp:ListItem Value="07">C</asp:ListItem>
                                    <asp:ListItem Value="08">SI</asp:ListItem>
                                    <asp:ListItem Value="09">MN</asp:ListItem>
                                    <asp:ListItem Value="10">P</asp:ListItem>
                                    <asp:ListItem Value="11">S</asp:ListItem>
                                    <asp:ListItem Value="12">CR</asp:ListItem>
                                    <asp:ListItem Value="13">NI</asp:ListItem>
                                    <asp:ListItem Value="14">CU</asp:ListItem>
                                    <asp:ListItem Value="15">MO</asp:ListItem>
                                    <asp:ListItem Value="16">CO</asp:ListItem>
                                    <asp:ListItem Value="17">AL</asp:ListItem>
                                    <asp:ListItem Value="18">SN</asp:ListItem>
                                    <asp:ListItem Value="19">PB</asp:ListItem>
                                    <asp:ListItem Value="20">TI</asp:ListItem>
                                    <asp:ListItem Value="21">NB</asp:ListItem>
                                    <asp:ListItem Value="22">V</asp:ListItem>
                                    <asp:ListItem Value="23">W</asp:ListItem>
                                    <asp:ListItem Value="24">O2</asp:ListItem>
                                    <asp:ListItem Value="25">N2</asp:ListItem>
                                    <asp:ListItem Value="16">H2</asp:ListItem>
                                    <asp:ListItem Value="27">B</asp:ListItem>
                                    <asp:ListItem Value="28">Ca</asp:ListItem>
                                    <asp:ListItem Value="29">Mg</asp:ListItem>
                                    <asp:ListItem Value="30">Fe</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="tbElementStartValue" runat="server" Width="50" Text="0"></asp:TextBox>~
                                <asp:TextBox ID="tbElementEndValue" runat="server" Width="50" Text="9"></asp:TextBox>
                                <asp:Button ID="btnAddElement" runat="server" Text="加入篩選" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lbElements" Height="100px" Width="300px" runat="server"></asp:ListBox>
                                <asp:Button ID="btnDeleteElement" runat="server" Text="移除篩選" />
                            </td>
                        </tr>
                    </table>
                </td>
                </tr>
            <tr>
                <td class="style1">密度:</td>
                <td>
                    <asp:TextBox ID="tbDefective" runat="server"></asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔) </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckBox3" runat="server" Checked="False" Text="頭尾缺陷移除:" 
                        TextAlign="Left" />
                </td>
                <td>
                    頭尾<asp:TextBox ID="tbQDS30DelLeng" runat="server" Height="20px" Width="39px">15</asp:TextBox>
                    呎缺陷移除</td>
            </tr>
            <tr>
                <td class="style1">
                    公稱寬度:</td>
                <td>
                    <asp:TextBox ID="tbStartWidth" runat="server" Width="70px">0</asp:TextBox>
                    ~<asp:TextBox ID="tbEndWidth" runat="server" Width="70px">9999</asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="缺限代碼發生次數篩選:" 
                        TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbFrontBackCodeCount" runat="server" Width="35px">2</asp:TextBox>
                    次以上(含)</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckBox5" runat="server" Text="直起直終總長篩選" TextAlign="Left" />
                </td>
                <td>
                    <asp:TextBox ID="tbButTotalMaxVLeng" runat="server" Width="33px">10</asp:TextBox>
                    以上(含)</td>
            </tr>
            <tr>
                <td class="style1">排程線別篩選:</td>
                <td>
                    <asp:TextBox ID="tbSchedualLines" runat="server" Width="322px">AP1H,Z1,Z2,Z3,AP2C,BALC</asp:TextBox>
                    (兩個以上以 &#39;,&#39; 分隔) 注意:產線追踪格式專用 </td>
            </tr>
            <tr>
                <td class="style1">
                    排序:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="lbSort" runat="server" AutoPostBack="True" Rows="5" 
                                Width="146px">
                                <asp:ListItem Value="BLA01">熱軋號碼</asp:ListItem>
                                <asp:ListItem Value="BLA11">熱軋批次</asp:ListItem>
                                <asp:ListItem Value="BLA07">鋼胚號碼</asp:ListItem>
                                <asp:ListItem Value="BLA09">鋼捲號碼</asp:ListItem>
                                <asp:ListItem Value="QCA02">鋼胚產日</asp:ListItem>
                                <asp:ListItem Value="QCA05">鋼種</asp:ListItem>
                                <asp:ListItem Value="QCA06">材質</asp:ListItem>
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
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                    <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
                    <asp:Button ID="btnSearchDownExcel" runat="server" Text="查詢下載Excel" 
                        Width="100px" />
                    <asp:DropDownList ID="ddlOutFormat" runat="server" Width="100px">
                        <asp:ListItem Value="Format0">預設格式</asp:ListItem>
                        <asp:ListItem Value="Format1">格式1</asp:ListItem>
                        <asp:ListItem Value="Format2">產線追踪格式</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View1" runat="server">
        <asp:Button ID="btnBackSearch1" runat="server" Text="返回查詢頁面" Width="108px" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult" EnableViewState="False" 
            EnableModelValidation="True" Width="3100px">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="缺陷代碼" HeaderText="缺陷代碼" SortExpression="缺陷代碼" />
                <asp:BoundField DataField="啟始長度" HeaderText="啟始長度" SortExpression="啟始長度" />
                <asp:BoundField DataField="終止長度" HeaderText="終止長度" SortExpression="終止長度" />
                <asp:BoundField DataField="缺陷面" HeaderText="缺陷面" SortExpression="缺陷面" />
                <asp:BoundField DataField="缺陷程度" HeaderText="缺陷程度" SortExpression="缺陷程度" />
                <asp:BoundField DataField="表面狀況" HeaderText="表面狀況" SortExpression="表面狀況" />
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" />
                <asp:BoundField DataField="DF值" HeaderText="DF值" SortExpression="DF值" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="綜合程度" HeaderText="綜合程度" SortExpression="綜合程度" />
                <asp:BoundField DataField="澆鑄粉" HeaderText="澆鑄粉" SortExpression="澆鑄粉" />
                <asp:BoundField DataField="分鋼槽塗覆" HeaderText="分鋼槽塗覆" SortExpression="分鋼槽塗覆" />
                <asp:BoundField DataField="模液位控制" HeaderText="模液位控制" SortExpression="模液位控制" />
                <asp:BoundField DataField="澆鑄管" HeaderText="澆鑄管" SortExpression="澆鑄管" />
                <asp:BoundField DataField="澆鑄速度" HeaderText="澆鑄速度" SortExpression="澆鑄速度" />
                <asp:BoundField DataField="氣罩" HeaderText="氣罩" SortExpression="氣罩" />
                <asp:BoundField DataField="冷卻水量" HeaderText="冷卻水量" SortExpression="冷卻水量" />
                <asp:BoundField DataField="吹氧次數" HeaderText="吹氧次數" SortExpression="吹氧次數" />
                <asp:BoundField DataField="分鋼槽溫度1" HeaderText="分鋼槽溫度1" 
                    SortExpression="分鋼槽溫度1" />
                <asp:BoundField DataField="分鋼槽溫度2" HeaderText="分鋼槽溫度2" 
                    SortExpression="分鋼槽溫度2" />
                <asp:BoundField DataField="分鋼槽溫度3" HeaderText="分鋼槽溫度3" 
                    SortExpression="分鋼槽溫度3" />
                <asp:BoundField DataField="攪拌時間" HeaderText="攪拌時間" SortExpression="攪拌時間" />
                <asp:BoundField DataField="靜置時間" HeaderText="靜置時間" SortExpression="靜置時間" />
                <asp:BoundField DataField="交接爐TUNDISH重量" HeaderText="交接爐TUNDISH重量" 
                    SortExpression="交接爐TUNDISH重量" />
                <asp:BoundField DataField="攪拌狀況" HeaderText="攪拌狀況" SortExpression="攪拌狀況" />
                <asp:BoundField DataField="渣流動性" HeaderText="渣流動性" SortExpression="渣流動性" />
                <asp:BoundField DataField="攪拌強度" HeaderText="攪拌強度" SortExpression="攪拌強度" />
                <asp:BoundField DataField="分鋼槽內容積" HeaderText="分鋼槽內容積" 
                    SortExpression="分鋼槽內容積" />
                <asp:BoundField DataField="連鑄班別" HeaderText="連鑄班別" SortExpression="連鑄班別" />
                <asp:BoundField DataField="輪班時間" HeaderText="輪班時間" SortExpression="輪班時間" />
                <asp:BoundField DataField="澆鑄管品名" HeaderText="澆鑄管品名" SortExpression="澆鑄管品名" />
                <asp:BoundField DataField="氣罩品名" HeaderText="氣罩品名" SortExpression="氣罩品名" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" 
            TypeName="QualityControl.CoilDefectExtendSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfSortFieldsList" Name="OrderFieldList" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfMinDefectFilterNumber" 
                    Name="FilterDefectNumber" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hfMaxBugTotalVLength" 
                    Name="FilterMaxBugTotalVLength" PropertyName="Value" Type="Double" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:Button ID="btnBackSearch2" runat="server" Text="返回查詢頁面" Width="108px" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult1" EnableViewState="False" Width="3700px" 
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
                <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="鋼胚產日" HeaderText="鋼胚產日" SortExpression="鋼胚產日" />
                <asp:BoundField DataField="追縱線別日期" HeaderText="追縱線別日期" 
                    SortExpression="追縱線別日期" />
                <asp:BoundField DataField="追蹤線別" HeaderText="追蹤線別" 
                    SortExpression="追蹤線別" />
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="缺陷代號" HeaderText="缺陷代號" SortExpression="缺陷代號" />
                <asp:BoundField DataField="缺陷次數" HeaderText="缺陷次數" SortExpression="缺陷次數" />
                <asp:BoundField DataField="程度" HeaderText="程度" SortExpression="程度" />
                <asp:BoundField DataField="分佈" HeaderText="分佈" SortExpression="分佈" />
                <asp:BoundField DataField="直起" HeaderText="直起" SortExpression="直起" />
                <asp:BoundField DataField="直終" HeaderText="直終" SortExpression="直終" />
                <asp:BoundField DataField="橫起" HeaderText="橫起" SortExpression="橫起" />
                <asp:BoundField DataField="橫終" HeaderText="橫終" SortExpression="橫終" />
                <asp:BoundField DataField="正反" HeaderText="正反" SortExpression="正反" />
                <asp:BoundField DataField="密度" HeaderText="密度" SortExpression="密度" />
                <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" />
                <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" />
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
                <asp:BoundField DataField="SI" HeaderText="SI" SortExpression="SI" />
                <asp:BoundField DataField="MN" HeaderText="MN" SortExpression="MN" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="CR" HeaderText="CR" SortExpression="CR" />
                <asp:BoundField DataField="NI" HeaderText="NI" SortExpression="NI" />
                <asp:BoundField DataField="CU" HeaderText="CU" SortExpression="CU" />
                <asp:BoundField DataField="MO" HeaderText="MO" SortExpression="MO" />
                <asp:BoundField DataField="CO" HeaderText="CO" SortExpression="CO" />
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="PB" HeaderText="PB" SortExpression="PB" />
                <asp:BoundField DataField="TI" HeaderText="TI" SortExpression="TI" />
                <asp:BoundField DataField="NB" HeaderText="NB" SortExpression="NB" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" />
                <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
                <asp:BoundField DataField="H2" HeaderText="H2" SortExpression="H2" />
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
                <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
                <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
                <asp:BoundField DataField="澆鑄粉" HeaderText="澆鑄粉" SortExpression="澆鑄粉" />
                <asp:BoundField DataField="分鋼槽塗覆" HeaderText="分鋼槽塗覆" SortExpression="分鋼槽塗覆" />
                <asp:BoundField DataField="模液位控制" HeaderText="模液位控制" SortExpression="模液位控制" />
                <asp:BoundField DataField="澆鑄管" HeaderText="澆鑄管" SortExpression="澆鑄管" />
                <asp:BoundField DataField="澆鑄速度" HeaderText="澆鑄速度" SortExpression="澆鑄速度" />
                <asp:BoundField DataField="氣罩" HeaderText="氣罩" SortExpression="氣罩" />
                <asp:BoundField DataField="冷卻水量" HeaderText="冷卻水量" SortExpression="冷卻水量" />
                <asp:BoundField DataField="吹氧次數" HeaderText="吹氧次數" SortExpression="吹氧次數" />
                <asp:BoundField DataField="分鋼槽溫度1" HeaderText="分鋼槽溫度1" 
                    SortExpression="分鋼槽溫度1" />
                <asp:BoundField DataField="分鋼槽溫度2" HeaderText="分鋼槽溫度2" 
                    SortExpression="分鋼槽溫度2" />
                <asp:BoundField DataField="分鋼槽溫度3" HeaderText="分鋼槽溫度3" 
                    SortExpression="分鋼槽溫度3" />
                <asp:BoundField DataField="攪拌時間" HeaderText="攪拌時間" SortExpression="攪拌時間" />
                <asp:BoundField DataField="靜置時間" HeaderText="靜置時間" SortExpression="靜置時間" />
                <asp:BoundField DataField="交接爐TUNDISH重量" HeaderText="交接爐TUNDISH重量" 
                    SortExpression="交接爐TUNDISH重量" />
                <asp:BoundField DataField="攪拌狀況" HeaderText="攪拌狀況" SortExpression="攪拌狀況" />
                <asp:BoundField DataField="渣流動性" HeaderText="渣流動性" SortExpression="渣流動性" />
                <asp:BoundField DataField="攪拌強度" HeaderText="攪拌強度" SortExpression="攪拌強度" />
                <asp:BoundField DataField="分鋼槽內容積" HeaderText="分鋼槽內容積" 
                    SortExpression="分鋼槽內容積" />
                <asp:BoundField DataField="連鑄班別" HeaderText="連鑄班別" SortExpression="連鑄班別" />
                <asp:BoundField DataField="輪班時間" HeaderText="輪班時間" SortExpression="輪班時間" />
                <asp:BoundField DataField="澆鑄管品名" HeaderText="澆鑄管品名" SortExpression="澆鑄管品名" />
                <asp:BoundField DataField="氣罩品名" HeaderText="氣罩品名" SortExpression="氣罩品名" />
                <asp:BoundField DataField="插入深度" HeaderText="插入深度" SortExpression="插入深度" />
                <asp:BoundField DataField="投料" HeaderText="投料" SortExpression="投料" />
                <asp:BoundField DataField="AOD出鋼量" HeaderText="AOD出鋼量" SortExpression="AOD出鋼量" />
                <asp:BoundField DataField="澆鑄粉用量" HeaderText="澆鑄粉用量" SortExpression="澆鑄粉用量" />
                <asp:BoundField DataField="模溢位波動" HeaderText="模溢位波動" SortExpression="模溢位波動" />
                <asp:BoundField DataField="分鋼槽連鑄完剩餘重量" HeaderText="分鋼槽連鑄完剩餘重量" SortExpression="分鋼槽連鑄完剩餘重量" />
                <asp:BoundField DataField="氣罩內壁夾鐵" HeaderText="氣罩內壁夾鐵" SortExpression="氣罩內壁夾鐵" />
                <asp:BoundField DataField="填充砂品牌" HeaderText="填充砂品牌" SortExpression="填充砂品牌" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" 
            SelectMethod="Search1" TypeName="QualityControl.CoilDefectExtendSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfSortFieldsList" Name="OrderFieldList" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfMinDefectFilterNumber" 
                    Name="FilterDefectNumber" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hfMaxBugTotalVLength" 
                    Name="FilterMaxBugTotalVLength" PropertyName="Value" Type="Double" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="View3" runat="server">
        <asp:Button ID="btnBackSearch3" runat="server" Text="返回查詢頁面" Width="108px" />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsSearchResult2" EnableModelValidation="True" 
            EnableViewState="False" Width="3700px">
            <Columns>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號" />
                <asp:BoundField DataField="鋼捲號碼" HeaderText="鋼捲號碼" SortExpression="鋼捲號碼" />
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="材質" HeaderText="材質" SortExpression="材質" />
                <asp:BoundField DataField="熱軋批次" HeaderText="熱軋批次" SortExpression="熱軋批次" />
                <asp:BoundField DataField="鋼胚號碼" HeaderText="鋼胚號碼" SortExpression="鋼胚號碼" />
                <asp:BoundField DataField="熱軋號碼" HeaderText="熱軋號碼" SortExpression="熱軋號碼" />
                <asp:BoundField DataField="鋼胚產日" HeaderText="鋼胚產日" SortExpression="鋼胚產日" />
                <asp:BoundField DataField="追縱線別日期" HeaderText="追縱線別日期" 
                    SortExpression="追縱線別日期" />
                <asp:BoundField DataField="追蹤線別" HeaderText="追蹤線別" SortExpression="追蹤線別" />
                <asp:BoundField DataField="班別" HeaderText="班別" SortExpression="班別" >
                </asp:BoundField>
                <asp:BoundField DataField="進時間" HeaderText="進時間" SortExpression="進時間" >
                </asp:BoundField>
                <asp:BoundField DataField="出時間" HeaderText="出時間" SortExpression="出時間" >
                </asp:BoundField>
                <asp:BoundField DataField="厚度" HeaderText="厚度" SortExpression="厚度" />
                <asp:BoundField DataField="缺陷代號" HeaderText="缺陷代號" SortExpression="缺陷代號" />
                <asp:BoundField DataField="程度" HeaderText="程度" SortExpression="程度" />
                <asp:BoundField DataField="分佈" HeaderText="分佈" SortExpression="分佈" />
                <asp:BoundField DataField="直起" HeaderText="直起" SortExpression="直起" />
                <asp:BoundField DataField="直終" HeaderText="直終" SortExpression="直終" />
                <asp:BoundField DataField="橫起" HeaderText="橫起" SortExpression="橫起" />
                <asp:BoundField DataField="橫終" HeaderText="橫終" SortExpression="橫終" />
                <asp:BoundField DataField="正反" HeaderText="正反" SortExpression="正反" />
                <asp:BoundField DataField="密度" HeaderText="密度" SortExpression="密度" />
                <asp:BoundField DataField="DF" HeaderText="DF" SortExpression="DF" />
                <asp:BoundField DataField="MD30" HeaderText="MD30" SortExpression="MD30" />
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />
                <asp:BoundField DataField="SI" HeaderText="SI" SortExpression="SI" />
                <asp:BoundField DataField="MN" HeaderText="MN" SortExpression="MN" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="CR" HeaderText="CR" SortExpression="CR" />
                <asp:BoundField DataField="NI" HeaderText="NI" SortExpression="NI" />
                <asp:BoundField DataField="CU" HeaderText="CU" SortExpression="CU" />
                <asp:BoundField DataField="MO" HeaderText="MO" SortExpression="MO" />
                <asp:BoundField DataField="CO" HeaderText="CO" SortExpression="CO" />
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="PB" HeaderText="PB" SortExpression="PB" />
                <asp:BoundField DataField="TI" HeaderText="TI" SortExpression="TI" />
                <asp:BoundField DataField="NB" HeaderText="NB" SortExpression="NB" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="O2" HeaderText="O2" SortExpression="O2" />
                <asp:BoundField DataField="N2" HeaderText="N2" SortExpression="N2" />
                <asp:BoundField DataField="H2" HeaderText="H2" SortExpression="H2" />
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />
                <asp:BoundField DataField="Ca" HeaderText="Ca" SortExpression="Ca" />
                <asp:BoundField DataField="Mg" HeaderText="Mg" SortExpression="Mg" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
                <asp:BoundField DataField="澆鑄粉" HeaderText="澆鑄粉" SortExpression="澆鑄粉" />
                <asp:BoundField DataField="分鋼槽塗覆" HeaderText="分鋼槽塗覆" SortExpression="分鋼槽塗覆" />
                <asp:BoundField DataField="模液位控制" HeaderText="模液位控制" SortExpression="模液位控制" />
                <asp:BoundField DataField="澆鑄管" HeaderText="澆鑄管" SortExpression="澆鑄管" />
                <asp:BoundField DataField="澆鑄速度" HeaderText="澆鑄速度" SortExpression="澆鑄速度" />
                <asp:BoundField DataField="氣罩" HeaderText="氣罩" SortExpression="氣罩" />
                <asp:BoundField DataField="冷卻水量" HeaderText="冷卻水量" SortExpression="冷卻水量" />
                <asp:BoundField DataField="吹氧次數" HeaderText="吹氧次數" SortExpression="吹氧次數" />
                <asp:BoundField DataField="分鋼槽溫度1" HeaderText="分鋼槽溫度1" 
                    SortExpression="分鋼槽溫度1" />
                <asp:BoundField DataField="分鋼槽溫度2" HeaderText="分鋼槽溫度2" 
                    SortExpression="分鋼槽溫度2" />
                <asp:BoundField DataField="分鋼槽溫度3" HeaderText="分鋼槽溫度3" 
                    SortExpression="分鋼槽溫度3" />
                <asp:BoundField DataField="攪拌時間" HeaderText="攪拌時間" SortExpression="攪拌時間" />
                <asp:BoundField DataField="靜置時間" HeaderText="靜置時間" SortExpression="靜置時間" />
                <asp:BoundField DataField="交接爐TUNDISH重量" HeaderText="交接爐TUNDISH重量" 
                    SortExpression="交接爐TUNDISH重量" />
                <asp:BoundField DataField="攪拌狀況" HeaderText="攪拌狀況" SortExpression="攪拌狀況" />
                <asp:BoundField DataField="渣流動性" HeaderText="渣流動性" SortExpression="渣流動性" />
                <asp:BoundField DataField="攪拌強度" HeaderText="攪拌強度" SortExpression="攪拌強度" />
                <asp:BoundField DataField="分鋼槽內容積" HeaderText="分鋼槽內容積" 
                    SortExpression="分鋼槽內容積" />
                <asp:BoundField DataField="連鑄班別" HeaderText="連鑄班別" SortExpression="連鑄班別" />
                <asp:BoundField DataField="輪班時間" HeaderText="輪班時間" SortExpression="輪班時間" />
                <asp:BoundField DataField="澆鑄管品名" HeaderText="澆鑄管品名" SortExpression="澆鑄管品名" />
                <asp:BoundField DataField="氣罩品名" HeaderText="氣罩品名" SortExpression="氣罩品名" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsSearchResult2" runat="server" 
            SelectMethod="Search2" TypeName="QualityControl.CoilDefectExtendSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfDFAndMD30Range" Name="DFAndMD30Range" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfSortFieldsList" Name="OrderFieldList" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfMinDefectFilterNumber" 
                    Name="FilterDefectNumber" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hfMaxBugTotalVLength" 
                    Name="FilterMaxBugTotalVLength" PropertyName="Value" Type="Double" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfSQLString" runat="server" />
<asp:HiddenField ID="hfDFAndMD30Range" runat="server" />
<asp:HiddenField ID="hfSortFieldsList" runat="server" />
<asp:HiddenField ID="hfMinDefectFilterNumber" runat="server" />
<asp:HiddenField ID="hfMaxBugTotalVLength" runat="server" />
