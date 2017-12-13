<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QAPDI.ascx.vb" Inherits="QualityControl.QAPDI" %>
<style type="text/css">
    .auto-style1
    {
        width: 110px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="auto-style1">查詢期間:</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">查詢時間:</td>
        <td>
            <asp:TextBox ID="tbStartTime" runat="server" Width="100px">0000</asp:TextBox>
            ~<asp:TextBox ID="tbEndTime" runat="server" Width="100px">2400</asp:TextBox>
            (時分 ex:0800 ~1700)</td>
    </tr>
    <tr>
        <td class="auto-style1">查詢鋼捲號碼:</td>
        <td>
            <asp:TextBox ID="tbCoilNumbers" runat="server" Width="242px"></asp:TextBox>
            (兩個以上請以&#39;,&#39;區分)</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="清除查詢條件" Width="100px" />
        </td>
    </tr>
</table>


<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult"  EnableModelValidation="True" InsertItemPosition="LastItem" DataKeyNames="CoilFullNumber,CreateMsgDept,CreateMsgTime,MsgType,RunLineName" >
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="CopyInsert" runat="server" CommandName="CopyInsert" Text="複製至新增" CausesValidation="False" />
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CoilFullNumberLabel" runat="server" Text='<%# Bind("CoilFullNumber")%>' />
            </td>
            <%--<td>
                <asp:Label ID="CreateMsgDeptLabel" runat="server" Text='<%# Eval("CreateMsgDept") %>' />
            </td>
            <td>
                <asp:Label ID="CreateMsgTimeLabel" runat="server" Text='<%# Eval("CreateMsgTime") %>' />
            </td>
            <td>
                <asp:Label ID="MsgTypeLabel" runat="server" Text='<%# Eval("MsgType") %>' />
            </td>
            <td>
                <asp:Label ID="MsgTypeNameLabel" runat="server" Text='<%# Eval("MsgTypeName") %>' />
            </td>--%>
            <td>
                <asp:Label ID="QASeparateNameLabel" runat="server" Text='<%# Eval("QASeparateName") %>' />
            </td>
            <td>
                <asp:Label ID="CoilThickLabel" runat="server" Text='<%# Eval("CoilThick") %>' />
            </td>
            <td>
                <asp:Label ID="CoilWidthLabel" runat="server" Text='<%# Eval("CoilWidth", "{0:0.##}")%>' />
            </td>
            <td>
                <asp:Label ID="CoilLengthLabel" runat="server" Text='<%# Eval("CoilLength","{0:0.##}")  %>' />
            </td>
            <td>
                <asp:Label ID="FrontCutBugLabel" runat="server" Text='<%# Eval("FrontCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="FrontCutLengthLabel" runat="server" Text='<%# Eval("FrontCutLength", "{0:0.##}")%>' />
            </td>
            <td>
                <asp:Label ID="TailCutBugLabel" runat="server" Text='<%# Eval("TailCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="TailCutLengthLabel" runat="server" Text='<%# Eval("TailCutLength", "{0:0.##}")%>' />
            </td>
             <td>
                <asp:Label ID="RunLineNameLabel" runat="server" Text='<%# Bind("RunLineName")%>' />
            </td>
             <td>
                <asp:Label ID="ToLineMessageLabel" runat="server" Text='<%# Eval("ToLineMessage")%>' />
            </td>
             <td>
                <asp:Label ID="CreateMsgTimeLabel" runat="server" Text='<%# Bind("CreateMsgTime")%>' />
            </td>
       </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="CopyInsertButton" runat="server" CommandName="CopyInsert" Text="複製到新增" CausesValidation="False" />
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?');" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="CoilFullNumberLabel" runat="server" Text='<%# Bind("CoilFullNumber")%>' />
            </td>
            <%--<td>
                <asp:Label ID="CreateMsgDeptLabel" runat="server" Text='<%# Eval("CreateMsgDept") %>' />
            </td>
            <td>
                <asp:Label ID="CreateMsgTimeLabel" runat="server" Text='<%# Eval("CreateMsgTime") %>' />
            </td>
            <td>
                <asp:Label ID="MsgTypeLabel" runat="server" Text='<%# Eval("MsgType") %>' />
            </td>
            <td>
                <asp:Label ID="MsgTypeNameLabel" runat="server" Text='<%# Eval("MsgTypeName") %>' />
            </td>--%>
            <td>
                <asp:Label ID="QASeparateNameLabel" runat="server" Text='<%# Eval("QASeparateName") %>' />
            </td>
            <td>
                <asp:Label ID="CoilThickLabel" runat="server" Text='<%# Eval("CoilThick") %>' />
            </td>
            <td>
                <asp:Label ID="CoilWidthLabel" runat="server" Text='<%# Eval("CoilWidth", "{0:0.##}")%>' />
            </td>
            <td>
                <asp:Label ID="CoilLengthLabel" runat="server" Text='<%# Eval("CoilLength", "{0:0.##}")%>' />
            </td>
            <td>
                <asp:Label ID="FrontCutBugLabel" runat="server" Text='<%# Eval("FrontCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="FrontCutLengthLabel" runat="server" Text='<%# Eval("FrontCutLength", "{0:0.##}")%>' />
            </td>
            <td>
                <asp:Label ID="TailCutBugLabel" runat="server" Text='<%# Eval("TailCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="TailCutLengthLabel" runat="server" Text='<%# Eval("TailCutLength","{0:0.##}")%>' />
            </td>
             <td>
                <asp:Label ID="RunLineNameLabel" runat="server" Text='<%# Bind("RunLineName")%>' />
            </td>
             <td>
                <asp:Label ID="ToLineMessageLabel" runat="server" Text='<%# Eval("ToLineMessage")%>' />
            </td>
             <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CreateMsgTime")%>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" CausesValidation="false"  />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="CoilFullNumberTextBox" runat="server" Text='<%# Bind("CoilFullNumber")%>' ReadOnly="true" BackColor="LightGray"  Width="80"  />
                <asp:HiddenField ID="hfCreateMsgDept" runat="server" Value='<%# Bind("CreateMsgDept") %>' />
                <asp:HiddenField ID="hfCreateMsgTime" runat="server" Value='<%# Bind("CreateMsgTime","{0:yyyy/MM/dd HH:mm:ss}")%>' />
                <asp:HiddenField ID="hfMsgType" runat="server" Value='<%# Bind("MsgType")%>' />
                <asp:HiddenField ID="hfMsgTypeName" runat="server" Value='<%# Bind("MsgTypeName")%>' />
            </td>
            <td>
                <asp:TextBox ID="QASeparateNameTextBox" runat="server" Text='<%# Bind("QASeparateName") %>' Width="30"  />
                <%--<asp:DropDownList ID="ddlQASeparateName" runat="server" >
                    <asp:ListItem Value="SA" Selected="True" >A捲</asp:ListItem>
                    <asp:ListItem Value="SB">B捲</asp:ListItem>
                    <asp:ListItem Value="SC">C捲</asp:ListItem>
                    <asp:ListItem Value="SD">D捲</asp:ListItem>
                    <asp:ListItem Value="SE">E捲</asp:ListItem>
                    <asp:ListItem Value="SF">F捲</asp:ListItem>
                    <asp:ListItem Value="SG">G捲</asp:ListItem>
                    <asp:ListItem Value="SH">H捲</asp:ListItem>
                    <asp:ListItem Value="SI">I捲</asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:TextBox ID="CoilThickTextBox" runat="server" Text='<%# Bind("CoilThick") %>' Width="60" />
            </td>
            <td>
                <asp:TextBox ID="CoilWidthTextBox" runat="server" Text='<%# Bind("CoilWidth") %>' Width="60"  />
            </td>
            <td>
                <asp:TextBox ID="CoilLengthTextBox" runat="server" Text='<%# Bind("CoilLength") %>' Width="60"  />
            </td>
            <td>
                <asp:TextBox ID="FrontCutBugTextBox" runat="server" Text='<%# Bind("FrontCutBug")%>' Width="60"  />
            </td>
             <td>
                <asp:TextBox ID="FrontCutLengthTextBox" runat="server" Text='<%# Bind("FrontCutLength")%>' Width="60"  />
            </td>
            <td>
                <asp:TextBox ID="TailCutBugTextBox" runat="server" Text='<%# Bind("TailCutBug")%>' Width="60"  />
            </td>
             <td>
                <asp:TextBox ID="TailCutLengthTextBox" runat="server" Text='<%# Bind("TailCutLength")%>' Width="60"  />
            </td>
            <td>
                <asp:DropDownList ID="ddlQARunLineName" runat="server"  SelectedValue='<%# Bind("RunLineName")%>' >
                    <asp:ListItem Value="SBL1" Selected="True" >SBL</asp:ListItem>
                    <asp:ListItem Value="TLL1">TLL</asp:ListItem>
                    <asp:ListItem Value="SPL1">SPL</asp:ListItem>
                    <asp:ListItem Value="CPL1">CPL1</asp:ListItem>
                    <asp:ListItem Value="CPL2">CPL2</asp:ListItem>
                    <asp:ListItem Value="APL1">APL1</asp:ListItem>
                    <asp:ListItem Value="APL2">APL2</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
                <asp:TextBox ID="ToLineMessageTextBox" runat="server" Text='<%# Bind("ToLineMessage")%>' />
            </td>
            <td>
                自動
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
        <tr><td colspan="13" style="text-align:center;background-color:red;font-size:20px;color:wheat;">以下為新增資料輸入區域</td></tr>
        <tr style="background-color:red;">
            <td>
                <asp:Button ID="CopyInsert" runat="server" CommandName="Insert" Text="新增並複製" />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="新增" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="CoilFullNumberTextBox" runat="server" Text='<%# Bind("CoilFullNumber")%>' Width="80" />
                <asp:HiddenField ID="hfCreateMsgDept" runat="server" Value='<%# Bind("CreateMsgDept") %>' />
                <asp:HiddenField ID="hfCreateMsgTime" runat="server" Value='<%# Bind("CreateMsgTime")%>' />
                <asp:HiddenField ID="hfMsgType" runat="server" Value='<%# Bind("MsgType")%>' />
                <asp:HiddenField ID="hfMsgTypeName" runat="server" Value='<%# Bind("MsgTypeName")%>' />
            </td>
            <td>
                <asp:TextBox ID="QASeparateNameTextBox" runat="server" Text='<%# Bind("QASeparateName") %>'  Width="30" />
                <%--<asp:DropDownList ID="ddlQASeparateName" runat="server" >
                    <asp:ListItem Value="SA" Selected="True" >A捲</asp:ListItem>
                    <asp:ListItem Value="SB">B捲</asp:ListItem>
                    <asp:ListItem Value="SC">C捲</asp:ListItem>
                    <asp:ListItem Value="SD">D捲</asp:ListItem>
                    <asp:ListItem Value="SE">E捲</asp:ListItem>
                    <asp:ListItem Value="SF">F捲</asp:ListItem>
                    <asp:ListItem Value="SG">G捲</asp:ListItem>
                    <asp:ListItem Value="SH">H捲</asp:ListItem>
                    <asp:ListItem Value="SI">I捲</asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:TextBox ID="CoilThickTextBox" runat="server" Text='<%# Bind("CoilThick") %>' Width="60" />
            </td>
            <td>
                <asp:TextBox ID="CoilWidthTextBox" runat="server" Text='<%# Bind("CoilWidth") %>' Width="60" />
            </td>
            <td>
                <asp:TextBox ID="CoilLengthTextBox" runat="server" Text='<%# Bind("CoilLength") %>' Width="60" />
            </td>
            <td>
                <asp:TextBox ID="FrontCutBugTextBox" runat="server" Text='<%# Bind("FrontCutBug")%>' Width="60" />
            </td>
             <td>
                <asp:TextBox ID="FrontCutLengthTextBox" runat="server" Text='<%# Bind("FrontCutLength")%>' Width="60" />
            </td>
            <td>
                <asp:TextBox ID="TailCutBugTextBox" runat="server" Text='<%# Bind("TailCutBug")%>' Width="60" />
            </td>
             <td>
                <asp:TextBox ID="TailCutLengthTextBox" runat="server" Text='<%# Bind("TailCutLength")%>'  Width="60"/>
            </td>
            <td>
                <asp:DropDownList ID="ddlQARunLineName" runat="server" SelectedValue='<%# Bind("RunLineName")%>' >
                    <asp:ListItem Value="SBL1" Selected="True" >SBL</asp:ListItem>
                    <asp:ListItem Value="TLL1">TLL</asp:ListItem>
                    <asp:ListItem Value="SPL1">SPL</asp:ListItem>
                    <asp:ListItem Value="CPL1">CPL1</asp:ListItem>
                    <asp:ListItem Value="CPL2">CPL2</asp:ListItem>
                    <asp:ListItem Value="APL1">APL1</asp:ListItem>
                    <asp:ListItem Value="APL2">APL2</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
                <asp:TextBox ID="ToLineMessageTextBox" runat="server" Text='<%# Bind("ToLineMessage")%>' />
            </td>
            <td>
                自動
            </td>
        </tr>
        <tr>
            <td>訊息:</td>
            <td colspan="12">
                <asp:CustomValidator ID="InsertCustomValidator1" runat="server" 
                    OnServerValidate="InsertCustomValidator1_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>


    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000">
                            <th runat="server"></th>
                            <th runat="server">鋼捲編號</th>
                            <%--<th runat="server">CreateMsgDept</th>
                            <th runat="server">CreateMsgTime</th>
                            <th runat="server">MsgType</th>
                            <th runat="server">MsgTypeName</th>--%>
                            <th runat="server">分捲</th>
                            <th runat="server">厚度</th>
                            <th runat="server">寬度</th>
                            <th runat="server">長度</th>
                            <th runat="server">前切缺陷</th>
                            <th runat="server">前切長度</th>
                            <th runat="server">後切缺陷</th>
                            <th runat="server">後切長度</th>
                            <th runat="server">線別</th>
                            <th runat="server">注意事項</th>
                            <th runat="server">時間</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="20">
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
            <%--<td>
                <asp:Label ID="CoilFnullNumberLabel" runat="server" Text='<%# Eval("CoilFnullNumber")%>' />
            </td>
            <td>
                <asp:Label ID="CreateMsgDeptLabel" runat="server" Text='<%# Eval("CreateMsgDept") %>' />
            </td>
            <td>
                <asp:Label ID="CreateMsgTimeLabel" runat="server" Text='<%# Eval("CreateMsgTime") %>' />
            </td>
            <td>
                <asp:Label ID="MsgTypeLabel" runat="server" Text='<%# Eval("MsgType") %>' />
            </td>--%>
            <td>
                <asp:Label ID="MsgTypeNameLabel" runat="server" Text='<%# Eval("MsgTypeName") %>' />
            </td>
            <td>
                <asp:Label ID="QASeparateNameLabel" runat="server" Text='<%# Eval("QASeparateName") %>' />
            </td>
            <td>
                <asp:Label ID="CoilThickLabel" runat="server" Text='<%# Eval("CoilThick") %>' />
            </td>
            <td>
                <asp:Label ID="CoilWidthLabel" runat="server" Text='<%# Eval("CoilWidth") %>' />
            </td>
            <td>
                <asp:Label ID="CoilLengthLabel" runat="server" Text='<%# Eval("CoilLength") %>' />
            </td>
            <td>
                <asp:Label ID="FrontCutBugLabel" runat="server" Text='<%# Eval("FrontCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="FrontCutLengthLabel" runat="server" Text='<%# Eval("FrontCutLength")%>' />
            </td>
            <td>
                <asp:Label ID="TailCutBugLabel" runat="server" Text='<%# Eval("TailCutBug")%>' />
            </td>
             <td>
                <asp:Label ID="TailCutLengthLabel" runat="server" Text='<%# Eval("TailCutLength")%>' />
            </td>
             <td>
                <asp:Label ID="RunLineNameLabel" runat="server" Text='<%# Bind("RunLineName")%>' />
            </td>
             <td>
                <asp:Label ID="ToLineMessageLabel" runat="server" Text='<%# Eval("ToLineMessage")%>' />
            </td>
             <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CreateMsgTime")%>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>

<asp:ObjectDataSource ID="odsSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.PPS100LB.PDI" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="QualityControl.QAPDI" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="SQLString" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />


