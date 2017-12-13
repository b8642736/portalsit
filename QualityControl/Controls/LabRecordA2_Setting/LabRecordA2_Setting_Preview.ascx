<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Setting_Preview.ascx.vb" Inherits="QualityControl.LabRecordA2_Setting_Preview" %>

<link href="CSS/LabRecordA2_Setting_CSS.css" rel="stylesheet" type="text/css" />

<table id="HtmlTab1" class="myTab1">
    <tr>
        <td style="width: 95%">
            <%--HtmlTab1_A-------------------------------------------------------%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table id="HtmlTab1_A" class="myTab1" style="width: 100%">

                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="鋼種：" />
                            </td>
                            <td>
                                <asp:CheckBox ID="queryKey3CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey3DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                            <td>
                                <asp:Label ID="Label1" runat="server" Text="材質：" />
                            </td>
                            <td>
                                <asp:CheckBox ID="queryKey4CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey4DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>
                        </tr>


                        <tr>
                            <td style="width: 10%">
                                <asp:Label ID="Label6" runat="server" Text="參照規範：" />
                            </td>
                            <td style="width: 30%">
                                <asp:CheckBox ID="queryKey1CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey1DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                            <td style="width: 10%">
                                <asp:Label ID="Label5" runat="server" Text="表面類別：" />
                            </td>
                            <td style="width: 30%; font-weight: 700;">
                                <asp:CheckBox ID="queryKey2CheckBox" runat="server" />
                                <asp:DropDownList ID="queryKey2DropDownList" runat="server" OnSelectedIndexChanged="queryKeyDropDownList_SelectedIndexChanged" AutoPostBack="True" />
                            </td>

                        </tr>



                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td />
                            <td colspan="3">
                                <h1 >                                 
                                    <asp:HyperLink ID="HyperLink1" ForeColor ="Blue"  runat="server" />
                                </h1>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>

            </asp:UpdatePanel>
            <%--HtmlTab1_A-------------------------------------------------------%>
        </td>

        <td>
            <%--HtmlTab1_B-------------------------------------------------------%>
            <asp:Button ID="btnSerach" runat="server" Height="35px" Text="查詢" Width="143px" />
            <%--HtmlTab1_B-------------------------------------------------------%>
            
        </td>
    </tr>
</table>
<br />
