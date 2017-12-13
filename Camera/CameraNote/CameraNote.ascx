<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CameraNote.ascx.vb" Inherits="WebCamera.Camera1Note" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }

        .auto-title
        {
            font-size: x-large;
            height: 37px;
        }

        .auto-style5
        {
            width: 50px;
        }

    </style>

<body>
    <br /><br /><br /><br />
        <div>

            <table class="auto-style1">

                <tr>
                    <td class="auto-title" colspan="2">1：將Client電腦的IP加入監視器的Switch允許清單中</td>
                </tr>
                                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-title" colspan="2">2：新增近端內部網路網段&nbsp; http://10.1.5.*</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                      <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ac01.jpg" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-title" colspan="2">3：修改近端內部網路安全性</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/ac02-1.jpg" />
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/ac02-2.jpg" />
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-title" colspan="2">4：安裝Google Chrome 
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/images/ChromeStandaloneSetup.exe">離線安裝檔</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-title" colspan="2">5：煉鋼場監視系統ActiveX控制項安裝 (監視系統有三台主機,所以Cleint電腦需分別安裝三次)</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td><asp:Image ID="Image4" runat="server" ImageUrl="~/images/bc01.jpg" /><br /><br /><br /><br />
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/bc02.jpg" /><br /><br /><br /><br />
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/bc03.jpg" /></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
</body>
</html>