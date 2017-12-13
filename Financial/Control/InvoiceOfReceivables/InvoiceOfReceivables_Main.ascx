<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InvoiceOfReceivables_Main.ascx.vb" Inherits="Financial.InvoiceOfReceivables_Main" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="InvoiceOfReceivables_Edit.ascx" TagName="InvoiceOfReceivables_Edit" TagPrefix="uc1" %>
<%@ Register Src="InvoiceOfReceivables_Search.ascx" TagName="InvoiceOfReceivables_Search" TagPrefix="uc2" %>
<%@ Register Src="InvoiceOfReceivables_Print.ascx" TagName="InvoiceOfReceivables_Print" TagPrefix="uc3" %>

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .DivShowInfo {
        text-align: right;
        width: 90%;
        margin: 0px auto;
    }



    .View1-ALL {
        width: 50%;
        margin: 3px auto;   

        border-width: 4px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

    .View1-Left {
        width: 30%;        
    }

    .View1-Right {
        width: 70%;   
    }


</style>


<div class="DivShowInfo">
    <asp:LinkButton ID="linkBtnLoginInfo" runat="server"></asp:LinkButton><br />
    
</div>

<asp:MultiView ID="MultiView1" runat="server">

    <asp:View ID="View1" runat="server">

        <table class="View1-ALL">
            <tr>
                <td colspan="2"><strong>EIP登入</strong></td>
            </tr>
            <tr>
                <td class="View1-Left">職編：</td>
                <td class="View1-Right">
                    <asp:TextBox ID="txtLoginUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="View1-Left">密碼：</td>
                <td class="View1-Right">
                    <asp:TextBox ID="txtLoginPW" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="View1-Left">&nbsp;</td>
                <td class="View1-Right">
                    <asp:Button ID="btnLoginOK" runat="server" Text="登入" Style="height: 21px" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnLoginCancel" runat="server" Text="取消" />
                </td>
            </tr>
            <tr>
                <td class="View1-Left">&nbsp;</td>
                <td class="View1-Right">
                    <asp:Label ID="lbLoginMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>


    </asp:View>



    <asp:View ID="View2" runat="server">

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" AutoPostBack="true" Width="100%" CssClass="ajax__myTab">



            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>查詢
            </HeaderTemplate>
            <ContentTemplate>
                <uc2:InvoiceOfReceivables_Search ID="InvoiceOfReceivables_Search1" runat="server" />
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>編修
            </HeaderTemplate>
            <ContentTemplate>
                <uc1:InvoiceOfReceivables_Edit ID="InvoiceOfReceivables_Edit1" runat="server"></uc1:InvoiceOfReceivables_Edit>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3"><HeaderTemplate>列印
            </HeaderTemplate>
            <ContentTemplate>
                <uc3:InvoiceOfReceivables_Print ID="InvoiceOfReceivables_Print1" runat="server" />
            </ContentTemplate>
            </cc1:TabPanel>

        </cc1:TabContainer>


    </asp:View>
</asp:MultiView>





















