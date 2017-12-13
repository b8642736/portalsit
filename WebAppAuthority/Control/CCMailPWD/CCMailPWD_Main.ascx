<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CCMailPWD_Main.ascx.vb" Inherits="WebAppAuthority.CCMailPWD_Main" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="CCMailPWD_Edit.ascx" TagName="CCMailPWD_Edit" TagPrefix="uc1" %>


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
                <td class="View1-Left"></td>
                <td class="View1-Right">
                    <asp:Button ID="btnLoginOK" runat="server" Text="登入" Style="height: 21px" />
                    <asp:Button ID="btnLoginCancel" runat="server" Text="取消" />
                </td>
            </tr>
            <tr>
                <td class="View1-Left"></td>
                <td class="View1-Right">
                    <asp:Label ID="lbLoginMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>


    </asp:View>



    <asp:View ID="View2" runat="server">

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" AutoPostBack="true" Width="100%" CssClass="ajax__myTab">

            
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>重設</HeaderTemplate>
            <ContentTemplate>
                <uc1:CCMailPWD_Edit ID="CCMailPWD_Edit1" runat="server"></uc1:CCMailPWD_Edit>
            </ContentTemplate>
            </cc1:TabPanel>                   

        </cc1:TabContainer>


    </asp:View>
</asp:MultiView>


