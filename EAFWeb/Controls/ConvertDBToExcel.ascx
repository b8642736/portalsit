<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ConvertDBToExcel.ascx.vb" Inherits="EAFWeb.ConvertDBToExcel" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 116px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <span lang="zh-tw">篩選條件建立:</span></td>
        <td>
            <asp:Button ID="btnClear" runat="server" Text="清除篩選條件" />
        </td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="轉換成Excel" />
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
        
            <span lang="zh-tw">爐別:<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" Width="262px">
                <asp:ListItem Value="0" Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="1">A爐</asp:ListItem>
                <asp:ListItem Value="2">B爐</asp:ListItem>
            </asp:RadioButtonList>
            </span>
        
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
        
            <span lang="zh-tw">
            <asp:Panel ID="Panel1" runat="server" Width="501px">
                <span lang="zh-tw">資料期間:</span><asp:TextBox ID="btStartDataDate" runat="server" 
                    AutoPostBack="True" Width="136px"></asp:TextBox>
                ~<asp:TextBox ID="btEndDataDate" runat="server" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" 
                    TargetControlID="btStartDataDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="btEndDataDate">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    Mask="9999/99/99" MaskType="Date" TargetControlID="btStartDataDate" 
                    UserDateFormat="YearMonthDay">
                </cc1:MaskedEditExtender>
                <span lang="zh-tw">
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                    Mask="9999/99/99" MaskType="Date" TargetControlID="btEndDataDate" 
                    UserDateFormat="YearMonthDay">
                </cc1:MaskedEditExtender>
                </span>
            </asp:Panel>
            </span>
        
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
        
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
        
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
        
        </td>
    </tr>
</table>
