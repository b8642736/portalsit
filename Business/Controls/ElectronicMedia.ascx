<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ElectronicMedia.ascx.vb" Inherits="Business.ElectronicMedia" %>
<style type="text/css">
    .style1 {
        width: 80px;
    }
</style>

<br />
<p></p>

<table style="width: 100%;">
    <tr>
        <td class="style1">申報年月:</td>
        <td>
            <asp:DropDownList ID="ddEEEMM" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1">發票號碼:</td>
        <td>
            <asp:TextBox ID="txtReceiptNumber" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1">客戶名稱:</td>
        <td>
            <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">客戶編號:</td>
        <td>
            <asp:TextBox ID="txtCustNumber" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="btnClear" runat="server" Text="查詢條件清除" Width="100px" />
        </td>
    </tr>

    <tr>
        <td class="style1">&nbsp;</td>
        <td>

            <asp:HiddenField ID="hfSQL_sl2cuapf" runat="server" />
            <asp:HiddenField ID="hfSQL_sgau10pf1" runat="server" />
            <asp:HiddenField ID="hfSQL_sgau10pf2" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" SelectMethod="Search" TypeName="Business.ElectronicMedia" DataObjectTypeName="CompanyORMDB.SGA600LB.SGAU10PF">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSQL_sl2cuapf" Name="fromSQL_sl2cuapf" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL_sgau10pf1" Name="fromSQL_sgau10pf1" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfSQL_sgau10pf2" Name="fromSQL_sgau10pf2" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>


<br />
<asp:ListView ID="ListView1" runat="server" DataKeyNames="U1000,U1001,U1007,U1008,U1091" DataSourceID="ObjectDataSource1" EnableModelValidation="True">
    <AlternatingItemTemplate>
        <tr style="background-color: #FFF8DC;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"
                    OnClientClick='<%# CreateConfirmation(Eval("U1007"), Eval("U1008"), Eval("U1091"))%>' />

                <asp:HiddenField ID="hfU1000" runat="server" Value='<%# Eval("U1000")%>' />
                <asp:HiddenField ID="hfU1001" runat="server" Value='<%# Eval("U1001")%>' />
                <asp:HiddenField ID="hfU1007" runat="server" Value='<%# Eval("U1007")%>' />
                <asp:HiddenField ID="hfU1008" runat="server" Value='<%# Eval("U1008")%>' />
            </td>


            <td>
                <asp:Label ID="U100708Label" runat="server" Text='<%# Eval("U1007") & Eval("U1008")%>' />
            </td>

            <td>
                <asp:Label ID="U1091Label" runat="server" Text='<%# Eval("U1091") %>' />
            </td>

            <td>
                <asp:Label ID="U1005Label" runat="server" Text='<%# Eval("U1005") %>' />
            </td>

            <td>
                <asp:Label ID="U1009Label" runat="server" Text='<%# showMoneyFormat(Eval("U1009"))%>' />
            </td>

            <td>
                <asp:Label ID="U1011Label" runat="server" Text='<%# showMoneyFormat(Eval("U1011"))%>' />
            </td>

        </tr>
    </AlternatingItemTemplate>
    <%--<EditItemTemplate>
        <tr style="background-color: #008A8C; color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            <td>
                <asp:TextBox ID="U1000TextBox" runat="server" Text='<%# Bind("U1000") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1001TextBox" runat="server" Text='<%# Bind("U1001") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1002TextBox" runat="server" Text='<%# Bind("U1002") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1003TextBox" runat="server" Text='<%# Bind("U1003") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1004TextBox" runat="server" Text='<%# Bind("U1004") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1005TextBox" runat="server" Text='<%# Bind("U1005") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1006TextBox" runat="server" Text='<%# Bind("U1006") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1007TextBox" runat="server" Text='<%# Bind("U1007") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1008TextBox" runat="server" Text='<%# Bind("U1008") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1009TextBox" runat="server" Text='<%# Bind("U1009") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1010TextBox" runat="server" Text='<%# Bind("U1010") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1011TextBox" runat="server" Text='<%# Bind("U1011") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1012TextBox" runat="server" Text='<%# Bind("U1012") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1013TextBox" runat="server" Text='<%# Bind("U1013") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1014TextBox" runat="server" Text='<%# Bind("U1014") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1015TextBox" runat="server" Text='<%# Bind("U1015") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1091TextBox" runat="server" Text='<%# Bind("U1091") %>' />
            </td>

        </tr>
    </EditItemTemplate>--%>
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
            <tr>
                <td>未傳回資料。</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <%--<InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            </td>
            <td>
                <asp:TextBox ID="U1000TextBox" runat="server" Text='<%# Bind("U1000") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1001TextBox" runat="server" Text='<%# Bind("U1001") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1002TextBox" runat="server" Text='<%# Bind("U1002") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1003TextBox" runat="server" Text='<%# Bind("U1003") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1004TextBox" runat="server" Text='<%# Bind("U1004") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1005TextBox" runat="server" Text='<%# Bind("U1005") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1006TextBox" runat="server" Text='<%# Bind("U1006") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1007TextBox" runat="server" Text='<%# Bind("U1007") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1008TextBox" runat="server" Text='<%# Bind("U1008") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1009TextBox" runat="server" Text='<%# Bind("U1009") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1010TextBox" runat="server" Text='<%# Bind("U1010") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1011TextBox" runat="server" Text='<%# Bind("U1011") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1012TextBox" runat="server" Text='<%# Bind("U1012") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1013TextBox" runat="server" Text='<%# Bind("U1013") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1014TextBox" runat="server" Text='<%# Bind("U1014") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1015TextBox" runat="server" Text='<%# Bind("U1015") %>' />
            </td>
            <td>
                <asp:TextBox ID="U1091TextBox" runat="server" Text='<%# Bind("U1091") %>' />
            </td>

        </tr>
    </InsertItemTemplate>--%>
    <ItemTemplate>
        <tr style="background-color: #DCDCDC; color: #000000;">
            <td>

                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"
                    OnClientClick='<%# CreateConfirmation(Eval("U1007"), Eval("U1008"), Eval("U1091"))%>' />
                <asp:Label ID="lbSpace" runat ="server" Text='<%# showSpaceChar(10)%>' />

                <asp:HiddenField ID="hfU1000" runat="server" Value='<%# Eval("U1000")%>' />
                <asp:HiddenField ID="hfU1001" runat="server" Value='<%# Eval("U1001")%>' />
                <asp:HiddenField ID="hfU1007" runat="server" Value='<%# Eval("U1007")%>' />
                <asp:HiddenField ID="hfU1008" runat="server" Value='<%# Eval("U1008")%>' />
            </td>



            <td>
                <asp:Label ID="U100708Label" runat="server" Text='<%# Eval("U1007") & Eval("U1008") & showSpaceChar(10)%>' />
            </td>

            <td>
                <asp:Label ID="U1091Label" runat="server" Text='<%# Eval("U1091") & showSpaceChar(10)%>' />
            </td>

            <td>
                <asp:Label ID="U1005Label" runat="server" Text='<%# Eval("U1005") & showSpaceChar(10)%>' />
            </td>

            <td>
                <asp:Label ID="U1009Label" runat="server" Text='<%# showMoneyFormat(Eval("U1009")) & showSpaceChar(10)%>' />
            </td>

            <td>
                <asp:Label ID="U1011Label" runat="server" Text='<%# showMoneyFormat(Eval("U1011")) & showSpaceChar(10)%>' />
            </td>

        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server"></th>

                            <th runat="server">發票號碼</th>
                            <th runat="server">序號</th>
                            <th runat="server">客戶統一編號</th>
                            <th runat="server">銷售金額</th>
                            <th runat="server">營業稅額</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />

                <asp:HiddenField ID="hfU1000" runat="server" Value='<%# Eval("U1000")%>' />
                <asp:HiddenField ID="hfU1001" runat="server" Value='<%# Eval("U1001")%>' />
                <asp:HiddenField ID="hfU1007" runat="server" Value='<%# Eval("U1007")%>' />
                <asp:HiddenField ID="hfU1008" runat="server" Value='<%# Eval("U1008")%>' />
            </td>


            <td>
                <asp:Label ID="U100708Label" runat="server" Text='<%# Eval("U1007") & Eval("U1008")%>' />
            </td>

            <td>
                <asp:Label ID="U1091Label" runat="server" Text='<%# Eval("U1091") %>' />
            </td>

            <td>
                <asp:Label ID="U1005Label" runat="server" Text='<%# Eval("U1005") %>' />
            </td>

            <td>
                <asp:Label ID="U1009Label" runat="server" Text='<%# showMoneyFormat(Eval("U1009"))%>' />
            </td>

            <td>
                <asp:Label ID="U1011Label" runat="server" Text='<%# showMoneyFormat(Eval("U1011"))%>' />
            </td>


        </tr>
    </SelectedItemTemplate>
</asp:ListView>


