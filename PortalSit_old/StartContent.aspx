<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PortalSite.Master" CodeBehind="StartContent.aspx.vb" Inherits="PortalSit.StartContent" 
    title="��a���q�����@�~�J�f����" Culture="zh-TW" uiCulture="zh-CHT" %>

<%@ Register src="Control/MessageDisplay.ascx" tagname="MessageDisplay" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StartContent.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 800px;
            height:95%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


          <table class="style2" >
                <tr>
                    <td  align="left" valign="top"  >
                        <uc1:MessageDisplay ID="MessageDisplay1" runat="server" />
                     </td>
                </tr>
            </table>
            
            <asp:HyperLink ID="HyperLink1" NavigateUrl="mailto:kuku@mail.tangeng.com.tw" runat="server">�t�κ޲z��:�j�F�� ����:1319</asp:HyperLink>
            </asp:Content>
