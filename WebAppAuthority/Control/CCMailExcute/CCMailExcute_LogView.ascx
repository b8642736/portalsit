<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCMailExcute_LogView.ascx.vb" Inherits="WebAppAuthority.CCMailExcute_LogView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="WebAppAuthority" %>

<style type="text/css">
    
    .View2-Table {
        border: 4px dotted #cccccc;
width: 58%;
        border-collapse: collapse;
        }

    .View2_TD_A {
        width: 40px;
    }

    .View2_TD_B {
        width: 40px;
        border-right-width: 4px;
        border-right-width: 4px;
        border-right-style: dotted;
        border-right-color: #cccccc;
    }

    .auto-style9 {
        height: 30px;
    }
    .auto-style10 {
        width: 16px;
    }
    .auto-style11 {
        height: 23px;
    }
    .auto-style12 {
        width: 16px;
        height: 28px;
    }
    .auto-style13 {
        height: 28px;
    }

    </style>




<table style="width: 800px; height: 48px">
    <tr>
        <td class="auto-style11" colspan="5">一、查詢Log</td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td>查詢Log :
        </td>
        <td>
            <asp:DropDownList ID="ddl_logType" runat="server" Width="152px" DataTextField="StationName"
                DataValueField="StationID" AutoPostBack="True">                
                <asp:ListItem Value="CCmail_PWD_Log">密碼變更紀錄</asp:ListItem>
                <asp:ListItem Value="CCmail_Users_Log">帳號異動紀錄</asp:ListItem>
                <asp:ListItem Value="CCmail_Excute_Log">執行紀錄(XML)</asp:ListItem>                
            </asp:DropDownList>
        </td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td style="height: 30px">起始日:
        </td>
        <td style="height: 30px">
            <asp:TextBox ID="tbStartDate" runat="server" AutoPostBack="True"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="tbStartDate">
</cc1:CalendarExtender>
            (範例:2007/01/01)
        </td>
        <td style="height: 30px">終止日:
        </td>
        <td style="height: 30px">
            <asp:TextBox ID="tbEndDate" runat="server" AutoPostBack="True"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="tbEndDate">
</cc1:CalendarExtender>
            (範例:2007/12/31)
        </td>
    </tr>
    <tr>
        <td class="auto-style12">
        </td>
        <td class="auto-style13"><asp:Label ID="lb_rule1" runat="server" Text="Email帳號："></asp:Label>


        </td>
        <td class="auto-style13">
            <asp:TextBox ID="tb_Rule1" runat="server"></asp:TextBox>


        </td>
        <td class="auto-style13"></td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style10">&nbsp;</td>
        <td><asp:Label ID="lb_rule2" runat="server" Text="Email帳號："></asp:Label>


        </td>
        <td>
            <asp:TextBox ID="tb_Rule2" runat="server"></asp:TextBox>


        </td>
        <td>
                        <asp:Button ID="btnSearch" runat="server" Height="24px" Text="查詢" Width="60px" />


        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">&nbsp;</td>
        <td> <a href ="http://10.1.4.12/WebAppAuthority/CCMailExcuteForm.aspx" target ="_blank">跳脫EIP框架</a></td>
        <td>
            <asp:CheckBox ID="cb_decode" runat="server" AutoPostBack="True" Text="顯示明文密碼" />
            <asp:CheckBox ID="cb_hideResult" runat="server" AutoPostBack="True" Text="隱藏Result欄位" />
        </td>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>




            <asp:HiddenField ID="hfSQL" runat="server" />
            <asp:ObjectDataSource ID="odsSearch" runat="server" SelectMethod="Search" TypeName="WebAppAuthority.CCMailExcute_LogView" UpdateMethod="Update">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="fromSQL" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>


        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="odsSearch" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="80%">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
</asp:GridView>














