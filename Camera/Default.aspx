<%--<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="WebCamera._Default" %>--%>

<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="Default.aspx.vb" Inherits="WebCamera._Default" ValidateRequest="false" AspCompat="true" %>

<%@ Register Assembly="UCAjaxServerControl1" Namespace="UCAjaxServerControl1" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1
        {
            width: 800px;
        }

        .auto-style2
        {
            width: 200px;
            height: 46px;
        }
        .auto-style3
        {
            font-size: x-large;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br /><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CameraNoteForm.aspx" >執行環境安裝說明</asp:HyperLink>
    <br />
    <br />
    <br />

    <table class="auto-style1">

        <tr>
            <td colspan="5"><span class="auto-style3">行政區監視系統</span>&nbsp;                   
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="5">
                <cc1:ucAuthorizeButton ID="ucBtnServer1" runat="server"
                    CssClass="ButtonCamera" Text="Camera" />

                <asp:Button ID="displayBtnServer1" runat="server"
                    CssClass="ButtonCamera" Text="Camera" />

            </td>
        </tr>

        <tr>
            <td colspan="5">
                <br />
                <br />
                <br />
            </td>
        </tr>


        <tr>
            <td colspan="5"><span class="auto-style3">煉鋼場監視系統</span>
            </td>
        </tr>
        <tr>

            <td>
                <cc1:ucAuthorizeButton ID="ucBtnServer2_1" runat="server" CssClass="ButtonCamera" Text="Camera 1~16" />
                <asp:Button ID="displayBtnServer2_1" runat="server" CssClass="ButtonCamera" Text="Camera 1~16" />
            </td>
            <td></td>
            <td>
                <cc1:ucAuthorizeButton ID="ucbtnServer2_2" runat="server" CssClass="ButtonCamera" Text="Camera 17~32" />
                <asp:Button ID="displayBtnServer2_2" runat="server" CssClass="ButtonCamera" Text="Camera 17~32" />
            </td>
            <td></td>
            <td>
                <cc1:ucAuthorizeButton ID="ucbtnServer2_3" runat="server" CssClass="ButtonCamera" Text="Camera 33~48" />
                <asp:Button ID="displayBtnServer2_3" runat="server" CssClass="ButtonCamera" Text="Camera 33~48" />
            </td>
        </tr>
    </table>

    &nbsp&nbsp&nbsp&nbsp&nbsp  
</asp:Content>


