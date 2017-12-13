<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QABugRecordEdit.ascx.vb" Inherits="QualityControl.QABugRecordEdit" %>
<style type="text/css">
    .auto-style1 {
        width: 149px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="345px"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分,Ex:A0001,A0002,...)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="報表日期:" TextAlign="Left" />
        </td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">線別:</td>
        <td>
            <asp:CheckBoxList ID="cblLines" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">APL1</asp:ListItem>
                <asp:ListItem Selected="True">APL2</asp:ListItem>
                <asp:ListItem Selected="True">BAL</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">版次:</td>
        <td>
            <asp:TextBox ID="tbDateVersion" runat="server"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分,Ex:1,2,3,...)</td>
    </tr>
    <tr>
        <td class="auto-style1">缺陷代號:</td>
        <td>
            <asp:TextBox ID="tbBugCodes" runat="server" Width="345px"></asp:TextBox>
            (兩個以上請以 &#39;,&#39; 區分,Ex:10,11,12,...)
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel" Width="100px" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="CoilNumber,DataDate,StationName,Version,DataCreateTime" DataSourceID="odsSearchResult" EnableModelValidation="True" InsertItemPosition="LastItem">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?')" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CoilNumberLabel" runat="server" Text='<%# Eval("CoilNumber") %>' />
            </td>
            <td>
                <asp:Label ID="DataDateLabel" runat="server" Text='<%# Eval("DataDate", "{0:yyyy/MM/dd}")%>' />
            </td>
            <td>
                <asp:Label ID="StationNameLabel" runat="server" Text='<%# Eval("StationName") %>' />
            </td>
            <td>
                <asp:Label ID="VersionLabel" runat="server" Text='<%# Eval("Version") %>' />
            </td>
            <td>
                <asp:Label ID="DataCreateTimeLabel" runat="server" Text='<%# Eval("DataCreateTime") %>' />
            </td>
            <td>
                <asp:Label ID="QABug_NumberLabel" runat="server" Text='<%# Eval("QABug_Number") %>' />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree") %>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition") %>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionTypeName")%>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd") %>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNegName")%>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density") %>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle") %>' />
            </td>
            <td>
                <asp:Label ID="EditEmployeeIDLabel" runat="server" Text='<%# Eval("EditEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="RunClientIPLabel" runat="server" Text='<%# Eval("RunClientIP") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="CoilNumberTextBox" runat="server" Text='<%# Bind("CoilNumber") %>'  Width="80px"  ReadOnly="true" BackColor="LightGray" />
            </td>
            <td>
                <asp:TextBox ID="DataDateTextBox" runat="server" Text='<%# Bind("DataDate", "{0:yyyy/MM/dd}")%>'  Width="100px"  ReadOnly="true" BackColor="LightGray"  />
            </td>
            <td>
                <%--<asp:TextBox ID="StationNameTextBox" runat="server" Text='<%# Bind("StationName") %>' />--%>
                <asp:DropDownList ID="RadioButtonList1" runat="server"  Width="50px" 
                    RepeatDirection="Horizontal"  SelectedValue='<%#Bind("StationName")%>' Enabled="false" ReadOnly="true" BackColor="LightGray"  >
                    <asp:ListItem Selected="True" Value="APL1 " >APL1</asp:ListItem>
                    <asp:ListItem Value="APL2 ">APL2</asp:ListItem>
                    <asp:ListItem Value="BAL ">BAL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="VersionTextBox" runat="server" Text='<%# Bind("Version") %>' Width="30px" ReadOnly="true" BackColor="LightGray"  />
            </td>
            <td>
                <asp:TextBox ID="DataCreateTimeTextBox" runat="server" Text='<%# Bind("DataCreateTime", "{0:yyyy/MM/dd HH:mm:ss}")%>' Width="130px" ReadOnly="true" BackColor="LightGray"  />
            </td>
            <td>
                <asp:TextBox ID="QABug_NumberTextBox" runat="server" Text='<%# Bind("QABug_Number") %>' Width="40px" />
            </td>
            <td>
                <asp:TextBox ID="DegreeTextBox" runat="server" Text='<%# Bind("Degree") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="StartPositionTextBox" runat="server" Text='<%# Bind("StartPosition") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="EndPositionTextBox" runat="server" Text='<%# Bind("EndPosition") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="DPositionTypeTextBox" runat="server" Text='<%# Bind("DPositionType") %>' />--%>
                <asp:DropDownList ID="RadioButtonList2" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("DPositionType")%>' >
                    <asp:ListItem Selected="True" Value="0" >全</asp:ListItem>
                    <asp:ListItem Value="1">內</asp:ListItem>
                    <asp:ListItem Value="2">中</asp:ListItem>
                    <asp:ListItem Value="3">外</asp:ListItem>
                    <asp:ListItem Value="4">雙</asp:ListItem>
                    <asp:ListItem Value="5">無</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="DPositionStartTextBox" runat="server" Text='<%# Bind("DPositionStart") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="DPositionEndTextBox" runat="server" Text='<%# Bind("DPositionEnd") %>' Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="PosOrNegTextBox" runat="server" Text='<%# Bind("PosOrNeg") %>' Width="50px" />--%>
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("PosOrNeg")%>' >
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">正</asp:ListItem>
                    <asp:ListItem Value="2">反</asp:ListItem>
                    <asp:ListItem Value="3">雙</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="DensityTextBox" runat="server" Text='<%# Bind("Density") %>' Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="CycleTextBox" runat="server" Text='<%# Bind("Cycle") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="EditEmployeeIDTextBox" runat="server" Text='<%# Bind("EditEmployeeID") %>' Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="RunClientIPTextBox" runat="server" Text='<%# Bind("RunClientIP") %>' Width="90px" ReadOnly="true" BackColor="LightGray" />
            </td>
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="CoilNumberTextBox" runat="server" Text='<%# Bind("CoilNumber") %>' Width="80px" />
            </td>
            <td>
                <asp:TextBox ID="DataDateTextBox" runat="server" Text='<%# Bind("DataDate") %>' Width="100px"  />
            </td>
            <td>
                <%--<asp:TextBox ID="StationNameTextBox" runat="server" Text='<%# Bind("StationName") %>' Width="50px"  />--%>
                <asp:DropDownList ID="RadioButtonList1" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("StationName")%>' >
                    <asp:ListItem Selected="True" Value="APL1" >APL1</asp:ListItem>
                    <asp:ListItem Value="APL2">APL2</asp:ListItem>
                    <asp:ListItem Value="BAL">BAL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="VersionTextBox" runat="server" Text='<%# Bind("Version") %>'  Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="DataCreateTimeTextBox" runat="server" Text='<%# Bind("DataCreateTime") %>' Width="130px"  />
            </td>
            <td>
                <asp:TextBox ID="QABug_NumberTextBox" runat="server" Text='<%# Bind("QABug_Number") %>'  Width="40px"  />
            </td>
            <td>
                <asp:TextBox ID="DegreeTextBox" runat="server" Text='<%# Bind("Degree") %>'  Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="StartPositionTextBox" runat="server" Text='<%# Bind("StartPosition") %>'  Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="EndPositionTextBox" runat="server" Text='<%# Bind("EndPosition") %>'  Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="DPositionTypeTextBox" runat="server" Text='<%# Bind("DPositionType") %>'  Width="30px"  />--%>
                <asp:DropDownList ID="RadioButtonList2" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("DPositionType")%>' >
                    <asp:ListItem Selected="True" Value="0" >全</asp:ListItem>
                    <asp:ListItem Value="1">內</asp:ListItem>
                    <asp:ListItem Value="2">中</asp:ListItem>
                    <asp:ListItem Value="3">外</asp:ListItem>
                    <asp:ListItem Value="4">雙</asp:ListItem>
                    <asp:ListItem Value="5">無</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="DPositionStartTextBox" runat="server" Text='<%# Bind("DPositionStart") %>'   Width="70px" />
            </td>
            <td>
                <asp:TextBox ID="DPositionEndTextBox" runat="server" Text='<%# Bind("DPositionEnd") %>'   Width="70px" />
            </td>
            <td>
                <%--<asp:TextBox ID="PosOrNegTextBox" runat="server" Text='<%# Bind("PosOrNeg") %>'  Width="50px"  />--%>
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="50px"
                    RepeatDirection="Horizontal"  SelectedValue='<%# Bind("PosOrNeg")%>' >
                    <asp:ListItem Selected="True" Value="1" >正</asp:ListItem>
                    <asp:ListItem Value="2">反</asp:ListItem>
                    <asp:ListItem Value="3">雙</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="DensityTextBox" runat="server" Text='<%# Bind("Density") %>'  Width="50px"  />
            </td>
            <td>
                <asp:TextBox ID="CycleTextBox" runat="server" Text='<%# Bind("Cycle") %>'  Width="30px"  />
            </td>
            <td>
                <asp:TextBox ID="EditEmployeeIDTextBox" runat="server" Text='<%# Bind("EditEmployeeID") %>'  Width="70px"  />
            </td>
            <td>
                <asp:TextBox ID="RunClientIPTextBox" runat="server" Text='<%# Bind("RunClientIP") %>' BackColor="LightGray"  ReadOnly="true" Width="90px"  />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick="javascript:return confirm('是否確定刪除?')" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CoilNumberLabel" runat="server" Text='<%# Eval("CoilNumber") %>' />
            </td>
            <td>
                <asp:Label ID="DataDateLabel" runat="server" Text='<%# Eval("DataDate","{0:yyyy/MM/dd}") %>' />
            </td>
            <td>
                <asp:Label ID="StationNameLabel" runat="server" Text='<%# Eval("StationName") %>' />
            </td>
            <td>
                <asp:Label ID="VersionLabel" runat="server" Text='<%# Eval("Version") %>' />
            </td>
            <td>
                <asp:Label ID="DataCreateTimeLabel" runat="server" Text='<%# Eval("DataCreateTime") %>' />
            </td>
            <td>
                <asp:Label ID="QABug_NumberLabel" runat="server" Text='<%# Eval("QABug_Number") %>' />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree") %>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition") %>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionTypeName") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd") %>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNegName")%>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density") %>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle") %>' />
            </td>
            <td>
                <asp:Label ID="EditEmployeeIDLabel" runat="server" Text='<%# Eval("EditEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="RunClientIPLabel" runat="server" Text='<%# Eval("RunClientIP") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">鋼捲編號</th>
                            <th runat="server">資料日期</th>
                            <th runat="server">站別</th>
                            <th runat="server">版本</th>
                            <th runat="server">建檔日期</th>
                            <th runat="server">缺陷代碼</th>
                            <th runat="server">程度</th>
                            <th runat="server">長度啟始</th>
                            <th runat="server">長度終止</th>
                            <th runat="server">分佈型態</th>
                            <th runat="server">分佈啟始</th>
                            <th runat="server">分佈終止</th>
                            <th runat="server">正反</th>
                            <th runat="server">密度</th>
                            <th runat="server">周期</th>
                            <th runat="server">員工編號</th>
                            <th runat="server">電腦IP</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CoilNumberLabel" runat="server" Text='<%# Eval("CoilNumber") %>' />
            </td>
            <td>
                <asp:Label ID="DataDateLabel" runat="server" Text='<%# Eval("DataDate") %>' />
            </td>
            <td>
                <asp:Label ID="StationNameLabel" runat="server" Text='<%# Eval("StationName") %>' />
            </td>
            <td>
                <asp:Label ID="VersionLabel" runat="server" Text='<%# Eval("Version") %>' />
            </td>
            <td>
                <asp:Label ID="DataCreateTimeLabel" runat="server" Text='<%# Eval("DataCreateTime") %>' />
            </td>
            <td>
                <asp:Label ID="QABug_NumberLabel" runat="server" Text='<%# Eval("QABug_Number") %>' />
            </td>
            <td>
                <asp:Label ID="DegreeLabel" runat="server" Text='<%# Eval("Degree") %>' />
            </td>
            <td>
                <asp:Label ID="StartPositionLabel" runat="server" Text='<%# Eval("StartPosition") %>' />
            </td>
            <td>
                <asp:Label ID="EndPositionLabel" runat="server" Text='<%# Eval("EndPosition") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionTypeLabel" runat="server" Text='<%# Eval("DPositionType") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionStartLabel" runat="server" Text='<%# Eval("DPositionStart") %>' />
            </td>
            <td>
                <asp:Label ID="DPositionEndLabel" runat="server" Text='<%# Eval("DPositionEnd") %>' />
            </td>
            <td>
                <asp:Label ID="PosOrNegLabel" runat="server" Text='<%# Eval("PosOrNeg") %>' />
            </td>
            <td>
                <asp:Label ID="DensityLabel" runat="server" Text='<%# Eval("Density") %>' />
            </td>
            <td>
                <asp:Label ID="CycleLabel" runat="server" Text='<%# Eval("Cycle") %>' />
            </td>
            <td>
                <asp:Label ID="EditEmployeeIDLabel" runat="server" Text='<%# Eval("EditEmployeeID") %>' />
            </td>
            <td>
                <asp:Label ID="RunClientIPLabel" runat="server" Text='<%# Eval("RunClientIP") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.QABugRecord" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="QualityControl.QABugRecordEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQryString" runat="server" />


