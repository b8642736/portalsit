<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TakeGoodSearch.ascx.vb" Inherits="Business.TakeGoodSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 84px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style1">報表格式:</td>
        <td>
            <asp:DropDownList ID="ddlReportFormat" runat="server" Width="400px" AutoPostBack="true">
                <asp:ListItem Value="1">格式1:訂單量與提貨量清單</asp:ListItem>
              <%--  <asp:ListItem Value="3">格式3:訂單量與提貨量清單&鋼捲資料_依報價單統計</asp:ListItem>--%>
                <asp:ListItem Value="4">格式4:訂單量與提貨量清單&鋼捲資料_依提貨單統計</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="lbSearchDateMode" runat="server">查詢日期</asp:Label>
        </td>
        <td>
            <asp:RadioButtonList ID="rbSearchDateMode" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">報價日期</asp:ListItem>
                <asp:ListItem>提貨日期</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td class="style1">年/月:</td>
        <td>西元<asp:TextBox
            ID="tbStartYear" runat="server" Width="50px"></asp:TextBox>
            年<asp:DropDownList ID="ddlStartMonth" runat="server" Width="42px">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            月~<asp:TextBox ID="tbEndYear" runat="server" Width="50px"></asp:TextBox>
            年<asp:DropDownList ID="ddlEndMonth" runat="server" Width="42px">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            月</td>
    </tr>
    <tr>
        <td class="style1">內/外 銷:</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                <asp:ListItem Value="HOMESELL">內銷</asp:ListItem>
                <asp:ListItem Value="EXPORTSELL">外銷</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">鋼種:
        </td>
        <td>
            <asp:TextBox ID="tbSteelKind" runat="server" Width="325px"></asp:TextBox>
            (兩個以上以 &#39;,&#39; 分隔 ex:201,301)
        </td>
    </tr>
    <tr>
        <td class="style1">表面:</td>
        <td>
            <asp:TextBox ID="tbFace" runat="server"></asp:TextBox>(多個以下請以','分區 EX:2D,2B,BA...)</td>
    </tr>
    <tr>
        <td class="style1">厚度:</td>
        <td>
            <asp:TextBox ID="tbStartThick" runat="server" Width="70px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndThick" runat="server" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除" Width="100px" />
            <asp:Button ID="btnDownLoadExcel" runat="server" Text="下載Excel" Width="100px" />

            <asp:HiddenField ID="hfArgs" runat="server" />
        </td>
    </tr>
</table>

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:ObjectDataSource ID="odsSearchResult1" runat="server" SelectMethod="Search1"
            TypeName="Business.TakeGoodSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry1" Name="SQLString" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="hfArgs" Name="Args"
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hfQry1" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AutoGenerateColumns="False" DataSourceID="odsSearchResult1" PageSize="40"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="年月" HeaderText="年月" SortExpression="年月" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="客戶" HeaderText="客戶" SortExpression="客戶"></asp:BoundField>
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種"></asp:BoundField>
                <asp:BoundField DataField="合約內(外)" HeaderText="合約內(外)" SortExpression="合約內(外)"></asp:BoundField>
                <asp:BoundField DataField="CR訂單量" HeaderText="CR訂單量" SortExpression="CR訂單量"></asp:BoundField>
                <asp:BoundField DataField="CR提貨量" HeaderText="CR提貨量" SortExpression="CR提貨量"></asp:BoundField>
                <asp:BoundField DataField="CR厚度" HeaderText="CR厚度" SortExpression="CR厚度" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="CR厚度提貨量" HeaderText="CR厚度<BR>提貨量" SortExpression="CR厚度提貨量" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="CR寬度" HeaderText="CR寬度" SortExpression="CR寬度" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="HR訂單量" HeaderText="HR訂單量" SortExpression="HR訂單量"></asp:BoundField>
                <asp:BoundField DataField="HR提貨量" HeaderText="HR提貨量" SortExpression="HR提貨量"></asp:BoundField>
                <asp:BoundField DataField="HR厚度" HeaderText="HR厚度" SortExpression="HR厚度" HtmlEncode="false" />
                <asp:BoundField DataField="HR厚度提貨量" HeaderText="HR厚度<BR>提貨量" SortExpression="HR厚度提貨量" HtmlEncode="false" />
                <asp:BoundField DataField="HR寬度" HeaderText="HR寬度" SortExpression="HR寬度" HtmlEncode="false" />
                <asp:BoundField DataField="其它訂單量" HeaderText="其它訂單量" SortExpression="其它訂單量" />
                <asp:BoundField DataField="其它提貨量" HeaderText="其它提貨量" SortExpression="其它提貨量" />
                <asp:BoundField DataField="內外銷" HeaderText="內外銷" SortExpression="內外銷" />
            </Columns>
        </asp:GridView>
    </asp:View>


    <asp:View ID="View3" runat="server">
        <asp:ObjectDataSource ID="odsSearchResult3" runat="server" SelectMethod="Search3"
            TypeName="Business.TakeGoodSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry3" Name="SQLString" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="hfArgs" Name="Args"
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hfQry3" runat="server" />
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True"
            AutoGenerateColumns="False" DataSourceID="odsSearchResult3" PageSize="40"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="客戶Display" HeaderText="客戶" SortExpression="客戶" HtmlEncode="false" />
                <asp:BoundField DataField="鋼種Display" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="合約內(外)Display" HeaderText="合約內(外)" SortExpression="合約內(外)" />
                <asp:BoundField DataField="報表統計月份" HeaderText="報價單月份" SortExpression="報表統計月份" />
                <asp:BoundField DataField="CR訂單量Display" HeaderText="CR訂單量" SortExpression="CR訂單量" />
                <asp:BoundField DataField="CR提貨量Display" HeaderText="CR提貨量" SortExpression="CR提貨量" />
                <asp:BoundField DataField="CR厚度" HeaderText="CR厚度" SortExpression="CR厚度" HtmlEncode="false" />
                <asp:BoundField DataField="CR厚度提貨量" HeaderText="CR厚度<BR>提貨量" SortExpression="CR厚度提貨量" HtmlEncode="false" />
                <asp:BoundField DataField="CR報價單號碼" HeaderText="CR報價單號碼" SortExpression="CR報價單號碼" HtmlEncode="false" />
                <asp:BoundField DataField="CR寬度" HeaderText="CR寬度" SortExpression="CR寬度" HtmlEncode="false" />
                <asp:BoundField DataField="CR鋼捲號碼" HeaderText="CR鋼捲號碼" SortExpression="CR鋼捲號碼" HtmlEncode="false" />
                <asp:BoundField DataField="CR淨重" HeaderText="CR淨重" SortExpression="CR淨重" HtmlEncode="false" />
                <asp:BoundField DataField="CR一級重量" HeaderText="CR<BR>一級重量" SortExpression="CR一級重量" HtmlEncode="false" />
                <asp:BoundField DataField="CR二級重量" HeaderText="CR<BR>二級重量" SortExpression="CR二級重量" HtmlEncode="false" />
                <asp:BoundField DataField="CR三級重量" HeaderText="CR<BR>三級重量" SortExpression="CR三級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR訂單量Display" HeaderText="HR訂單量" SortExpression="HR訂單量" />
                <asp:BoundField DataField="HR提貨量Display" HeaderText="HR提貨量" SortExpression="HR提貨量" />
                <asp:BoundField DataField="HR厚度" HeaderText="HR厚度" SortExpression="HR厚度" HtmlEncode="false" />
                <asp:BoundField DataField="HR厚度提貨量" HeaderText="HR厚度<BR>提貨量" SortExpression="HR厚度提貨量" HtmlEncode="false" />
                <asp:BoundField DataField="HR報價單號碼" HeaderText="HR報價單號碼" SortExpression="HR報價單號碼" HtmlEncode="false" />
                <asp:BoundField DataField="HR寬度" HeaderText="HR寬度" SortExpression="HR寬度" HtmlEncode="false" />
                <asp:BoundField DataField="HR鋼捲號碼" HeaderText="HR鋼捲號碼" SortExpression="HR鋼捲號碼" HtmlEncode="false" />
                <asp:BoundField DataField="HR淨重" HeaderText="HR淨重" SortExpression="HR淨重" HtmlEncode="false" />
                <asp:BoundField DataField="HR一級重量" HeaderText="HR<BR>一級重量" SortExpression="HR一級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR二級重量" HeaderText="HR<BR>二級重量" SortExpression="HR二級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR三級重量" HeaderText="HR<BR>三級重量" SortExpression="HR三級重量" HtmlEncode="false" />
            </Columns>

        </asp:GridView>
    </asp:View>

    <asp:View ID="View4" runat="server">
        <asp:ObjectDataSource ID="odsSearchResult4" runat="server" SelectMethod="Search4"
            TypeName="Business.TakeGoodSearch">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfQry4" Name="SQLString" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="hfArgs" Name="Args"
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hfQryParam4" Name="fromSQLParam"
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hfQry4" runat="server" />
        <asp:HiddenField ID="hfQryParam4" runat="server" />
        <asp:GridView ID="GridView4" runat="server" AllowPaging="True"
            AutoGenerateColumns="False" DataSourceID="odsSearchResult4" PageSize="40"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="客戶Display" HeaderText="客戶" SortExpression="客戶" HtmlEncode="false" />
                <asp:BoundField DataField="鋼種Display" HeaderText="鋼種" SortExpression="鋼種" />
                <asp:BoundField DataField="合約內(外)Display" HeaderText="合約內(外)" SortExpression="合約內(外)" />
                <asp:BoundField DataField="報表統計月份" HeaderText="提貨單月份" SortExpression="報表統計月份" />
                <asp:BoundField DataField="CR訂單量Display" HeaderText="CR訂單量" SortExpression="CR訂單量" />
                <asp:BoundField DataField="CR提貨量Display" HeaderText="CR提貨量" SortExpression="CR提貨量" />
                <asp:BoundField DataField="CR厚度" HeaderText="CR厚度" SortExpression="CR厚度" HtmlEncode="false" />
                <asp:BoundField DataField="CR厚度提貨量" HeaderText="CR厚度<BR>提貨量" SortExpression="CR厚度提貨量" HtmlEncode="false" />
                <asp:BoundField DataField="CR報價單號碼" HeaderText="CR報價單號碼" SortExpression="CR報價單號碼" HtmlEncode="false" />
                <asp:BoundField DataField="CR寬度" HeaderText="CR寬度" SortExpression="CR寬度" HtmlEncode="false" />
                <asp:BoundField DataField="CR鋼捲號碼" HeaderText="CR鋼捲號碼" SortExpression="CR鋼捲號碼" HtmlEncode="false" />
                <asp:BoundField DataField="CR淨重" HeaderText="CR淨重" SortExpression="CR淨重" HtmlEncode="false" />
                <asp:BoundField DataField="CR一級重量" HeaderText="CR<BR>一級重量" SortExpression="CR一級重量" HtmlEncode="false" />
                <asp:BoundField DataField="CR二級重量" HeaderText="CR<BR>二級重量" SortExpression="CR二級重量" HtmlEncode="false" />
                <asp:BoundField DataField="CR三級重量" HeaderText="CR<BR>三級重量" SortExpression="CR三級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR訂單量Display" HeaderText="HR訂單量" SortExpression="HR訂單量" />
                <asp:BoundField DataField="HR提貨量Display" HeaderText="HR提貨量" SortExpression="HR提貨量" />
                <asp:BoundField DataField="HR厚度" HeaderText="HR厚度" SortExpression="HR厚度" HtmlEncode="false" />
                <asp:BoundField DataField="HR厚度提貨量" HeaderText="HR厚度<BR>提貨量" SortExpression="HR厚度提貨量" HtmlEncode="false" />
                <asp:BoundField DataField="HR報價單號碼" HeaderText="HR報價單號碼" SortExpression="HR報價單號碼" HtmlEncode="false" />
                <asp:BoundField DataField="HR寬度" HeaderText="HR寬度" SortExpression="HR寬度" HtmlEncode="false" />
                <asp:BoundField DataField="HR鋼捲號碼" HeaderText="HR鋼捲號碼" SortExpression="HR鋼捲號碼" HtmlEncode="false" />
                <asp:BoundField DataField="HR淨重" HeaderText="HR淨重" SortExpression="HR淨重" HtmlEncode="false" />
                <asp:BoundField DataField="HR一級重量" HeaderText="HR<BR>一級重量" SortExpression="HR一級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR二級重量" HeaderText="HR<BR>二級重量" SortExpression="HR二級重量" HtmlEncode="false" />
                <asp:BoundField DataField="HR三級重量" HeaderText="HR<BR>三級重量" SortExpression="HR三級重量" HtmlEncode="false" />
            </Columns>

        </asp:GridView>
    </asp:View>
</asp:MultiView>
