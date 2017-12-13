﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCClearAndArgEdit.ascx.vb" Inherits="StockStatic.CCClearAndArgEdit" %>
<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 102px;
    }

    .style2
    {
        background: LightGreen;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td class="style1">
            <asp:CheckBox ID="CheckBox1" Text="澆鑄日期" runat="server" Checked="True"
                TextAlign="Left" />
            :</td>
        <td>
            <asp:TextBox ID="tbStartDate" runat="server" Width="100px"></asp:TextBox>
            ~<asp:TextBox ID="tbEndDate" runat="server" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbStartDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="tbEndDate" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">爐號:</td>
        <td>
            <asp:TextBox ID="tbStoveNumber" runat="server" Width="250px"></asp:TextBox>
            (兩爐以上請以&#39;,&#39;區隔或以&#39;~&#39;表示範圍 ex:A0001,A5000~A6000,B0200~B0300)</td>
    </tr>
    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px"
                CausesValidation="False" />
            <asp:Button ID="btnSearchToExcel" runat="server" Text="查詢下載Excel"
                Width="100px" CausesValidation="False" />
        </td>
    </tr>
</table>

<asp:ListView ID="ListView1" runat="server" DataSourceID="odsSearchResult" InsertItemPosition="LastItem"
    DataKeyNames="T1,T2">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="False" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="False" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
            </td>
            <td>
                <asp:Label ID="Label25" runat="server" Text='<%# Eval("T1CDate","{0:yyyy-MM-dd}") %>' />
                <asp:Label ID="T1Label" runat="server" Text='<%# Eval("T1") %>' Style="visibility: hidden; width: 0;" />
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Text='<%# Eval("T25") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label26" runat="server" Text='<%# Eval("T26") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T2Label" runat="server" Text='<%# Eval("T2") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T41Label" runat="server" Text='<%# Eval("T41") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T42Label" runat="server" Text='<%# Eval("T42") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("T31")%>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label12" runat="server" Text='<%# Eval("T21") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label13" runat="server" Text='<%# Eval("T22_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T10Label" runat="server" Text='<%# Eval("T10") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T13Label" runat="server" Text='<%# Eval("T13_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T34Label" runat="server" Text='<%# Eval("T34") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T14Label" runat="server" Text='<%# Eval("T14_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T15Label" runat="server" Text='<%# Eval("T15_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T27Label" runat="server" Text='<%# Eval("T27_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T3Label" runat="server" Text='<%# Eval("T3_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Text='<%# Eval("T32")%>' />
            </td>
            <td>
                <asp:Label ID="Label33" runat="server" Text='<%# Eval("T33_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T4Label" runat="server" Text='<%# Eval("T4_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T5Label" runat="server" Text='<%# Eval("T5_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T6Label" runat="server" Text='<%# Eval("T6_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T28Label" runat="server" Text='<%# Eval("T28_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label29" runat="server" Text='<%# Eval("T30") %>' />
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text='<%# Eval("T23") %>' />
            </td>
            <td>
                <asp:Label ID="Label41" runat="server" Text='<%# Eval("T39_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T7Label" runat="server" Text='<%# Eval("T7_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T8Label" runat="server" Text='<%# Eval("T8_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label37" runat="server" Text='<%# Eval("T37")%>' />
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text='<%# IIf(TextBoxT29Visible(Eval("T24")), Eval("T29"), Eval("T24"))%>' />
            </td>
            <td>
                <asp:Label ID="Label43" runat="server" Text='<%# Eval("T40")%>' />
            </td>
            <td>
                <asp:Label ID="Label91" runat="server" Text='<%# Eval("T38")%>' />
            </td>
            <td>
                <asp:Label ID="Label35" runat="server" Text='<%# Eval("T36_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T9Label" runat="server" Text='<%# Eval("T9_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("T19") %>' />
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("T20_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T35Label" runat="server" Text='<%# Eval("T35") %>' />
            </td>		
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("T16") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("T17") %>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("T18") %>' />
            </td>
            <td>
                <asp:Label ID="T11Label" runat="server" Text='<%# Eval("T11") %>' />
            </td>
            <td>
                <asp:Label ID="T12Label" runat="server" Text='<%# Eval("T12") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" CausesValidation="False" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" CausesValidation="False" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?">
                </cc1:ConfirmButtonExtender>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" Text='<%# Eval("T1CDate","{0:yyyy-MM-dd}") %>' />
                <asp:Label ID="T1Label" runat="server" Text='<%# Eval("T1") %>' Style="visibility: hidden; width: 0;" />
            </td>
            <td>
                <asp:Label ID="Label23" runat="server" Text='<%# Eval("T25") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label27" runat="server" Text='<%# Eval("T26") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T2Label" runat="server" Text='<%# Eval("T2") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T41Label" runat="server" Text='<%# Eval("T41") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T42Label" runat="server" Text='<%# Eval("T42") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("T31")%>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label14" runat="server" Text='<%# Eval("T21") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label15" runat="server" Text='<%# Eval("T22_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T10Label" runat="server" Text='<%# Eval("T10") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T13Label" runat="server" Text='<%# Eval("T13_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T34Label" runat="server" Text='<%# Eval("T34") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T14Label" runat="server" Text='<%# Eval("T14_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T15Label" runat="server" Text='<%# Eval("T15_Descript") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T27Label" runat="server" Text='<%# Eval("T27_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T3Label" runat="server" Text='<%# Eval("T3_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Text='<%# Eval("T32")%>' />
            </td>
            <td>
                <asp:Label ID="Label33" runat="server" Text='<%# Eval("T33_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T4Label" runat="server" Text='<%# Eval("T4_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T5Label" runat="server" Text='<%# Eval("T5_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T6Label" runat="server" Text='<%# Eval("T6_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T28Label" runat="server" Text='<%# Eval("T28_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label29" runat="server" Text='<%# Eval("T30") %>' />
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text='<%# Eval("T23") %>' />
            </td>
            <td>
                <asp:Label ID="Label41" runat="server" Text='<%# Eval("T39_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T7Label" runat="server" Text='<%# Eval("T7_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T8Label" runat="server" Text='<%# Eval("T8_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label38" runat="server" Text='<%# Eval("T37")%>' />
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text='<%# IIf(TextBoxT29Visible(Eval("T24")) , Eval("T29"), Eval("T24"))%>' />
            </td>
            <td>
                <asp:Label ID="Label44" runat="server" Text='<%# Eval("T40")%>' />
            </td>
            <td>
                <asp:Label ID="Label40" runat="server" Text='<%# Eval("T38")%>' />
            </td>
            <td>
                <asp:Label ID="Label36" runat="server" Text='<%# Eval("T36_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T9Label" runat="server" Text='<%# Eval("T9_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("T19") %>' />
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("T20_Descript") %>' />
            </td>
            <td>
                <asp:Label ID="T35Label" runat="server" Text='<%# Eval("T35") %>' />
            </td>		
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("T16") %>' />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("T17") %>' />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("T18") %>' />
            </td>
            <td>
                <asp:Label ID="T11Label" runat="server" Text='<%# Eval("T11") %>' />
            </td>
            <td>
                <asp:Label ID="T12Label" runat="server" Text='<%# Eval("T12") %>' />
            </td>	
        </tr>
    </ItemTemplate>
    <EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" CausesValidation="False" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" CausesValidation="False" />
            </td>
            <td>
                <%--<asp:TextBox ID="TextBox12" runat="server" Text='<%# Eval("T1") %>' style="visibility:hidden;width:0;" />--%>
                <asp:TextBox ID="T1TextBox" runat="server" Text='<%# Eval("T1CDate") %>' Width="80px" ReadOnly="true" BackColor="Gray" />
            </td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("T25") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("T26") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T2TextBox" runat="server" Text='<%# Eval("T2") %>' Width="50px" ReadOnly="true" BackColor="Gray" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T41TextBox" runat="server" Text='<%# Bind("T41")%>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T42TextBox" runat="server" Text='<%# Bind("T42") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("T31")%>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("T21") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownList13" runat="server" SelectedValue='<%# Bind("T22") %>'>
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Value="1">1早</asp:ListItem>
                    <asp:ListItem Value="2">2中</asp:ListItem>
                    <asp:ListItem Value="3">3晚</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <asp:TextBox ID="T10TextBox" runat="server" Text='<%# Bind("T10") %>' Width="30px" />
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T13TextBox" runat="server" Text='<%# Bind("T13") %>' />--%>
                <asp:DropDownList ID="DropDownList8" runat="server" SelectedValue='<%# Bind("T13") %>'>
                    <asp:ListItem Value="1">1成功</asp:ListItem>
                    <asp:ListItem Value="2">2失敗</asp:ListItem>
                    <asp:ListItem Value="3">3壓力大流量小</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="style2">
                <asp:TextBox ID="T34TextBox" runat="server" Text='<%# Bind("T34") %>' Width="30px" />
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T14TextBox" runat="server" Text='<%# Bind("T14") %>' />--%>
                <asp:DropDownList ID="DropDownList9" runat="server" SelectedValue='<%# Bind("T14") %>'>
                    <asp:ListItem Value="1">1稠</asp:ListItem>
                    <asp:ListItem Value="2">2尚可</asp:ListItem>
                    <asp:ListItem Value="3">3佳</asp:ListItem>
                    <asp:ListItem Value="4">4稍清</asp:ListItem>
                    <asp:ListItem Value="5">5清</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T15TextBox" runat="server" Text='<%# Bind("T15") %>' />--%>
                <asp:DropDownList ID="DropDownList10" runat="server" SelectedValue='<%# Bind("T15") %>'>
                    <asp:ListItem Value="1">1大攪拌</asp:ListItem>
                    <asp:ListItem Value="2">2中攪拌</asp:ListItem>
                    <asp:ListItem Value="3">3小攪拌</asp:ListItem>
                    <asp:ListItem Value="4">4微攪拌</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T27TextBox" runat="server" Text='<%# Bind("T27") %>' />--%>
                <asp:DropDownList ID="DropDownList27" OnDataBound="DropDownList27_DataBound" runat="server" SelectedValue='<%# Bind("T27")%>'>
                    <asp:ListItem Value=" "> </asp:ListItem>
                    <asp:ListItem Value="0">無</asp:ListItem>
                    <asp:ListItem Value="1">1次</asp:ListItem>
                    <asp:ListItem Value="2">2次</asp:ListItem>
                    <asp:ListItem Value="3">3次</asp:ListItem>
                    <asp:ListItem Value="4">4次</asp:ListItem>
                    <asp:ListItem Value="5">5次</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T3TextBox" runat="server" Text='<%# Bind("T3") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("T3") %>' Width="75px">
                    <asp:ListItem Value="1">1STE130</asp:ListItem>
                    <asp:ListItem Value="2">2INTOCAST</asp:ListItem>
                    <asp:ListItem Value="3">3STE816</asp:ListItem>
                    <asp:ListItem Value="4">4SL650/ATB</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("T32")%>' Width="50px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList16" runat="server" SelectedValue='<%# Bind("T33")%>' Width="75px">
                    <asp:ListItem Value="0" >0未知</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True" >1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T4TextBox" runat="server" Text='<%# Bind("T4") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("T4") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T5TextBox" runat="server" Text='<%# Bind("T5") %>' />--%>
                <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("T5") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T6TextBox" runat="server" Text='<%# Bind("T6") %>' />--%>
                <asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# Bind("T6") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T28TextBox" runat="server" Text='<%# Bind("T28") %>' />--%>
                <asp:DropDownList ID="DropDownList28" runat="server" SelectedValue='<%# Bind("T28") %>'>
                    <asp:ListItem Value="0">0未知</asp:ListItem>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2加長</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("T30")%>' Width="50px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList15" runat="server" SelectedValue='<%# Bind("T23") %>'>
                    <asp:ListItem Value="">未知</asp:ListItem>
                    <asp:ListItem Value="RHI">RHI</asp:ListItem>
                    <asp:ListItem Value="KR">KR</asp:ListItem>
                    <asp:ListItem Value="VES">VES</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList11" runat="server" SelectedValue='<%# Bind("T39")%>'>
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Value="1">SK</asp:ListItem>
                    <asp:ListItem Value="2">鋼新</asp:ListItem>
                    <asp:ListItem Value="3">ST</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T7TextBox" runat="server" Text='<%# Bind("T7") %>' />--%>
                <asp:DropDownList ID="DropDownList5" runat="server" SelectedValue='<%# Bind("T7") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T8TextBox" runat="server" Text='<%# Bind("T8") %>' />--%>
                <asp:DropDownList ID="DropDownList6" runat="server" SelectedValue='<%# Bind("T8") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList19" runat="server" SelectedValue='<%# Bind("T37")%>'>
                    <asp:ListItem Value="0">無</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList24" runat="server" SelectedValue='<%# Bind("T24") %>' AutoPostBack="True" OnSelectedIndexChanged="DropDownListT24_SelectedIndexChanged">
                    <asp:ListItem Value="">未知</asp:ListItem>
                    <asp:ListItem Value="RHI">RHI</asp:ListItem>
                    <asp:ListItem Value="VES">VES</asp:ListItem>
                    <asp:ListItem Value="OCL">OCL</asp:ListItem>
                    <asp:ListItem Value="RHIS">RHI(S)</asp:ListItem>
                    <asp:ListItem Value="VESS">VES(S)</asp:ListItem>
               </asp:DropDownList>
                <asp:TextBox ID="TextBoxT29" runat="server" Width="50px" Text='<%# Bind("T29") %>' Visible='<%# TextBoxT29Visible(Eval("T24") )%>' />
            </td>
            <td>
                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("T40")%>' Width="50px" />
            </td>	
            <td>
                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("T38") %>' Width="20px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList17" runat="server" SelectedValue='<%# Bind("T36")%>'>
                    <asp:ListItem Value="0">0未知</asp:ListItem>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2夾鐵</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T9TextBox" runat="server" Text='<%# Bind("T9") %>' />--%>
                <asp:DropDownList ID="DropDownList7" runat="server" SelectedValue='<%# Bind("T9") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("T19") %>' Width="20px" />
            </td>
            <td>
                <asp:DropDownList ID="T20DropDownList11" runat="server" SelectedValue='<%# Bind("T20") %>'>
                    <asp:ListItem Value="0">0未知</asp:ListItem>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2加大</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="T35TextBox" runat="server" Text='<%# Bind("T35") %>' Width="30px" />
            </td>	
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("T16") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("T17") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("T18") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="T11TextBox" runat="server" Text='<%# Bind("T11") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="T12TextBox" runat="server" Text='<%# Bind("T12") %>' Width="30px" />
            </td>	
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server"
            style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" Height="50" Width="100%" CausesValidation="True" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" Width="100%" CausesValidation="False" />
            </td>
            <td>
                <asp:TextBox ID="T1TextBox" runat="server" Text='<%# Bind("T1CDate") %>' Width="80px" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="T1TextBox" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("T25") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("T26") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T2TextBox" runat="server" Text='<%# Bind("T2") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T41TextBox" runat="server" Text='<%# Bind("T41") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="T42TextBox" runat="server" Text='<%# Bind("T42") %>' Width="50px" />
            </td>			
            <td class="style2">
                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("T31")%>' Width="50px" />
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("T21") %>' Width="50px" />
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownList14" runat="server" SelectedValue='<%# Bind("T22") %>'>
                    <asp:ListItem Value="1">1早</asp:ListItem>
                    <asp:ListItem Value="2">2中</asp:ListItem>
                    <asp:ListItem Value="3">3晚</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <asp:TextBox ID="T10TextBox" runat="server" Text='<%# Bind("T10") %>' Width="30px" />
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T13TextBox" runat="server" Text='<%# Bind("T13") %>' />--%>
                <asp:DropDownList ID="DropDownList8" runat="server" SelectedValue='<%# Bind("T13") %>'>
                    <asp:ListItem Value="1">1成功</asp:ListItem>
                    <asp:ListItem Value="2">2失敗</asp:ListItem>
                    <asp:ListItem Value="3">3壓力大流量小</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="style2">
                <asp:TextBox ID="T34TextBox" runat="server" Text='<%# Bind("T34") %>' Width="30px" />
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T14TextBox" runat="server" Text='<%# Bind("T14") %>' />--%>
                <asp:DropDownList ID="DropDownList9" runat="server" SelectedValue='<%# Bind("T14") %>'>
                    <asp:ListItem Value="1">1稠</asp:ListItem>
                    <asp:ListItem Value="2">2尚可</asp:ListItem>
                    <asp:ListItem Value="3">3佳</asp:ListItem>
                    <asp:ListItem Value="4">4稍清</asp:ListItem>
                    <asp:ListItem Value="5">5清</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T15TextBox" runat="server" Text='<%# Bind("T15") %>' />--%>
                <asp:DropDownList ID="DropDownList10" runat="server" SelectedValue='<%# Bind("T15") %>'>
                    <asp:ListItem Value="1">1大攪拌</asp:ListItem>
                    <asp:ListItem Value="2">2中攪拌</asp:ListItem>
                    <asp:ListItem Value="3">3小攪拌</asp:ListItem>
                    <asp:ListItem Value="4">4微攪拌</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <%--<asp:TextBox ID="T27TextBox" runat="server" Text='<%# Bind("T27") %>' />--%>
                <asp:DropDownList ID="DropDownList27" runat="server" SelectedValue='<%# Bind("T27")%>'>
                    <asp:ListItem Value="0" Selected="True">無</asp:ListItem>
                    <asp:ListItem Value="1">1次</asp:ListItem>
                    <asp:ListItem Value="2">2次</asp:ListItem>
                    <asp:ListItem Value="3">3次</asp:ListItem>
                    <asp:ListItem Value="4">4次</asp:ListItem>
                    <asp:ListItem Value="5">5次</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T3TextBox" runat="server" Text='<%# Bind("T3") %>' />--%>
                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("T3") %>' Width="75px">
                    <asp:ListItem Value="1">1STE130</asp:ListItem>
                    <asp:ListItem Value="2">2INTOCAST</asp:ListItem>
                    <asp:ListItem Value="3">3STE816</asp:ListItem>
                    <asp:ListItem Value="4">4SL650/ATB</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("T32")%>' Width="50px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList16" runat="server" SelectedValue='<%# Bind("T33")%>' Width="75px">
                    <asp:ListItem Value="1" Selected="True" >1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T4TextBox" runat="server" Text='<%# Bind("T4") %>' />--%>
                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("T4") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T5TextBox" runat="server" Text='<%# Bind("T5") %>' />--%>
                <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("T5") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T6TextBox" runat="server" Text='<%# Bind("T6") %>' />--%>
                <asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# Bind("T6") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T28TextBox" runat="server" Text='<%# Bind("T28") %>' />--%>
                <asp:DropDownList ID="DropDownList28" runat="server" SelectedValue='<%# Bind("T28") %>'>
                    <asp:ListItem Value="0">0未知</asp:ListItem>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2加長</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("T30")%>' Width="50px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList15" runat="server" SelectedValue='<%# Bind("T23") %>'>
                    <asp:ListItem Value="">未知</asp:ListItem>
                    <asp:ListItem Value="RHI">RHI</asp:ListItem>
                    <asp:ListItem Value="KR">KR</asp:ListItem>
                    <asp:ListItem Value="VES">VES</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList11" runat="server" SelectedValue='<%# Bind("T39")%>'>
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Value="1">SK</asp:ListItem>
                    <asp:ListItem Value="2">鋼新</asp:ListItem>
                    <asp:ListItem Value="3">ST</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T7TextBox" runat="server" Text='<%# Bind("T7") %>' />--%>
                <asp:DropDownList ID="DropDownList5" runat="server" SelectedValue='<%# Bind("T7") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T8TextBox" runat="server" Text='<%# Bind("T8") %>' />--%>
                <asp:DropDownList ID="DropDownList6" runat="server" SelectedValue='<%# Bind("T8") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList20" runat="server" SelectedValue='<%# Bind("T37")%>'>
                    <asp:ListItem Value="0">無</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td>
                <asp:DropDownList ID="DropDownList24" runat="server" SelectedValue='<%# Bind("T24") %>' AutoPostBack="True" OnSelectedIndexChanged="DropDownListT24_SelectedIndexChanged">
                    <asp:ListItem Value="">未知</asp:ListItem>
                    <asp:ListItem Value="RHI">RHI</asp:ListItem>
                    <asp:ListItem Value="VES">VES</asp:ListItem>
                    <asp:ListItem Value="OCL">OCL</asp:ListItem>
                    <asp:ListItem Value="RHIS">RHI(S)</asp:ListItem>
                    <asp:ListItem Value="VESS">VES(S)</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxT29" runat="server" Width="50px" Text='<%# Bind("T29") %>' />
            </td>
            <td>
                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("T40")%>' Width="50px" />
            </td>
            <td>
                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("T38")%>' Width="20px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList18" runat="server" SelectedValue='<%# Bind("T36")%>'>
                    <asp:ListItem Value="1" Selected="True">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2夾鐵</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%--<asp:TextBox ID="T9TextBox" runat="server" Text='<%# Bind("T9") %>' />--%>
                <asp:DropDownList ID="DropDownList7" runat="server" SelectedValue='<%# Bind("T9") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2">2異常</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("T19") %>' Width="20px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList12" runat="server" SelectedValue='<%# Bind("T20") %>'>
                    <asp:ListItem Value="1">1正常</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">2加大</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="T35TextBox" runat="server" Text='<%# Bind("T35") %>' Width="30px" />
            </td>		
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("T16") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("T17") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("T18") %>' Width="30px" />
            </td>

            <td>
                <asp:TextBox ID="T11TextBox" runat="server" Text='<%# Bind("T11") %>' Width="30px" />
            </td>
            <td>
                <asp:TextBox ID="T12TextBox" runat="server" Text='<%# Bind("T12") %>' Width="30px" />
            </td>	
        </tr>
        <tr>
            <td>訊息:</td>
            <td colspan="37">
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                <%--<asp:Label ID="lbMessage" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server" style="width: 2000px">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1"
                        style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>
                            <th runat="server">澆鑄日期</th>
                            <th id="Th10" runat="server">起鑄日時分</th>
                            <th id="Th11" runat="server" class="style2">連鑄</th>
                            <th runat="server" class="style2">爐號</th>
                            <th runat="server" class="style2">鋼種</th>
                            <th runat="server" class="style2">寬度</th>
                            <th runat="server" class="style2">AOD出鋼量</th>
                            <th id="Th6" runat="server" class="style2">班別</th>
                            <th id="Th7" runat="server" class="style2">輪班時間</th>
                            <th runat="server" class="style2">攪拌時間(分)</th>
                            <th runat="server" class="style2">攪拌狀況</th>
                            <th id="Th34" runat="server" class="style2">AOD出鋼渣量</th>
                            <th runat="server" class="style2">渣流動性</th>
                            <th runat="server" class="style2">攪拌強度</th>
                            <th id="Th27" runat="server" class="style2">投料</th>
                            <th runat="server">澆鑄粉品牌</th>
                            <th runat="server">澆鑄粉用量</th>
                            <th runat="server">模溢位波動</th>
                            <th runat="server">分鋼槽塗覆</th>
                            <th runat="server">模液位控制</th>
                            <th runat="server">澆鑄管</th>
                            <th id="Th12" runat="server">澆鑄管長度</th>
                            <th id="Th13" runat="server">插入深度</th>
                            <th id="Th8" runat="server">澆鑄管品名</th>
                            <th id="Th15" runat="server">填充砂品牌</th>
                            <th runat="server">澆鑄速度</th>
                            <th runat="server">氣罩</th>
                            <th runat="server">台車編號</th>
                            <th id="Th9" runat="server">氣罩品名</th>
                            <th id="Th116" runat="server">氣罩頸部最大直徑</th>
                            <th id="Th5" runat="server">氣罩使用回數</th>
                            <th id="Th14" runat="server">氣罩內壁夾鐵</th>
                            <th runat="server">冷卻水量</th>
                            <th id="Th4" runat="server">吹氧次數</th>
                            <th id="Th51" runat="server">分鋼槽內容積</th>
                            <th  id="Th35" runat="server">分鋼槽連鑄完剩餘重量</th>
                            <th id="Th1" runat="server">分鋼槽溫度1</th>
                            <th id="Th2" runat="server">分鋼槽溫度2</th>
                            <th id="Th3" runat="server">分鋼槽溫度3</th>
                            <th runat="server">靜置時間(分)</th>
                            <th runat="server">交接爐重量(T)</th>                                                     
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server"
                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            </td>
            <td>
                <asp:Label ID="T1Label" runat="server" Text='<%# Eval("T1CDate") %>' />
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Text='<%# Eval("T25") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label28" runat="server" Text='<%# Eval("T26") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T2Label" runat="server" Text='<%# Eval("T2") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T41Label" runat="server" Text='<%# Eval("T41") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T42Label" runat="server" Text='<%# Eval("T42") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("T31")%>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("T21") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("T22") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T10Label" runat="server" Text='<%# Eval("T10") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T13Label" runat="server" Text='<%# Eval("T13") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T34Label" runat="server" Text='<%# Eval("T34") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T14Label" runat="server" Text='<%# Eval("T14") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T15Label" runat="server" Text='<%# Eval("T15") %>' />
            </td>
            <td class="style2">
                <asp:Label ID="T27Label" runat="server" Text='<%# Eval("T27") %>' />
            </td>
            <td>
                <asp:Label ID="T3Label" runat="server" Text='<%# Eval("T3") %>' />
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Text='<%# Eval("T32")%>' />
            </td>
            <td>
                <asp:Label ID="Label33" runat="server" Text='<%# Eval("T33_Descript")%>' />
            </td>
            <td>
                <asp:Label ID="T4Label" runat="server" Text='<%# Eval("T4") %>' />
            </td>
            <td>
                <asp:Label ID="T5Label" runat="server" Text='<%# Eval("T5") %>' />
            </td>
            <td>
                <asp:Label ID="T6Label" runat="server" Text='<%# Eval("T6") %>' />
            </td>
            <td>
                <asp:Label ID="T28Label" runat="server" Text='<%# Eval("T28") %>' />
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Text='<%# Eval("T30") %>' />
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text='<%# Eval("T23") %>' />
            </td>
            <td>
                <asp:Label ID="Label42" runat="server" Text='<%# Eval("T39")%>' />
            </td>
            <td>
                <asp:Label ID="T7Label" runat="server" Text='<%# Eval("T7") %>' />
            </td>
            <td>
                <asp:Label ID="T8Label" runat="server" Text='<%# Eval("T8") %>' />
            </td>
            <td>
                <asp:Label ID="Label39" runat="server" Text='<%# Eval("T37")%>' />
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text='<%# IIf(TextBoxT29Visible(Eval("T24")) , Eval("T29"), Eval("T24"))%>' />
            </td>
            <td>
                <asp:Label ID="Label45" runat="server" Text='<%# Eval("T40")%>' />
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("T38")%>' />
            </td>
            <td>
                <asp:Label ID="Label34" runat="server" Text='<%# Eval("T36") %>' />
            </td>
            <td>
                <asp:Label ID="T9Label" runat="server" Text='<%# Eval("T9") %>' />
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("T19") %>' />
            </td>
            <td>
                <asp:Label ID="Label81" runat="server" Text='<%# Eval("T20") %>' />
            </td>
            <td>
                <asp:Label ID="T35Label" runat="server" Text='<%# Eval("T35") %>' />
            </td>			
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("T16") %>' />
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("T17") %>' />
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("T18") %>' />
            </td>
            <td>
                <asp:Label ID="T11Label" runat="server" Text='<%# Eval("T11") %>' />
            </td>
            <td>
                <asp:Label ID="T12Label" runat="server" Text='<%# Eval("T12") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:ObjectDataSource ID="odsSearchResult" runat="server"
    DataObjectTypeName="CompanyORMDB.SMS100LB.SMSREGPF" DeleteMethod="CDBDelete"
    InsertMethod="CDBInsert" SelectMethod="Search"
    TypeName="StockStatic.CCClearAndArgEdit" UpdateMethod="CDBUpdate">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfQry" Name="QryString" PropertyName="Value"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfQry" runat="server" />



