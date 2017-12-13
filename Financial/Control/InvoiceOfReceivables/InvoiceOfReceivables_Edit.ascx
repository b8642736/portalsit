<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InvoiceOfReceivables_Edit.ascx.vb" Inherits="Financial.InvoiceOfReceivables_Edit" %>
<style type="text/css">
    .styleTableEdit {
        width: 90%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

        .styleTableEdit TD {
            border-width: 2px;
            border-style: dotted;
            border-collapse: collapse;
            border-color: #cccccc;
        }

    .styleTableButton {
        width: 80%;
        border-width: 2px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

        .styleTableButton TD {
            border-width: 2px;
            border-style: dotted;
            border-collapse: collapse;
            border-color: #cccccc;
        }


    .styleTableButton1b, .styleTableButton2b {
        width: 50%;
        border: 1px solid black;
    }

    .styleTableEditCol1a {
        text-align: center;
        width: 69%;
    }

    .styleTableEditCol2a {
        width: 31%;
    }

    .styleTableEditCol1b {
        height: 33px;
        border: 1px solid black;
    }

    .styleTableEditCol3b {
        width: 50%;
        height: 33px;
        border: 1px solid black;
    }

    .styleTableEditCol3bb {
        /*width: 25%;*/
        border: 0px solid black;
    }

    .styleTableEditCol2b {
        width: 20%;
        height: 33px;
        border: 1px solid black;
    }
</style>

<p />



<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">

        <table id="tableEdit1" class="styleTableEdit">
            <tr>
                <td class="styleTableEditCol1a">
                    <asp:Label ID="Label5" runat="server" Text="收　款　通　知　單" Font-Bold="True" Font-Size="X-Large" />
                    <br />
                </td>
                <td class="styleTableEditCol2a">
                    <asp:Label ID="Label12" runat="server" Text="單據號碼："></asp:Label>
                    <asp:TextBox ID="_tbInvoice_Number" runat="server" BackColor="#CCCCCC" Enabled="False"></asp:TextBox>
                    <br /><asp:Label ID="Label14" runat="server" Text="購案編號："></asp:Label>
                    <asp:TextBox ID="tbPurchase_Number" runat="server"  ></asp:TextBox>
                </td>
            </tr>



        </table>

        <%--  <table id="tableEdit2" class="styleTableEdit"
            border="1" style="border-collapse: collapse; border-color: black;">--%>

        <table id="tableEdit2" class="styleTableEdit" runat="server">


            <tr>
                <td class="styleTableEditCol1b" style="text-align: center;">
                    <asp:Label ID="Label9" runat="server" Text="摘　　　要"></asp:Label>
                </td>
                <td class="styleTableEditCol2b" style="text-align: center;">
                    <asp:Label ID="Label10" runat="server" Text="金　　額"></asp:Label>
                </td>
                <td class="styleTableEditCol3b" style="text-align: center;">
                    <asp:Label ID="Label11" runat="server" Text="備　　　註"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="styleTableEditCol1b">
                    <asp:Button ID="btSystemNote1" runat="server" Text="片語" Width="15%" Style="height: 21px" />
                    &nbsp<asp:TextBox ID="tbItem1" runat="server" Width="78%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol2b">
                    <asp:TextBox ID="tbAmount1" runat="server" Width="96%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol3b">
                    <asp:TextBox ID="tbMemo1" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="styleTableEditCol1b">
                    <asp:Button ID="btSystemNote2" runat="server" Text="片語" Width="15%" />
                    &nbsp<asp:TextBox ID="tbItem2" runat="server" Width="78%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol2b">
                    <asp:TextBox ID="tbAmount2" runat="server" Width="96%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol3b">
                    <asp:TextBox ID="tbMemo2" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="styleTableEditCol1b">
                    <asp:Button ID="btSystemNote3" runat="server" Text="片語" Width="15%" />
                    &nbsp<asp:TextBox ID="tbItem3" runat="server" Width="78%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol2b">
                    <asp:TextBox ID="tbAmount3" runat="server" Width="96%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol3b">
                    <asp:TextBox ID="tbMemo3" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="styleTableEditCol1b">
                    <asp:Button ID="btSystemNote4" runat="server" Text="片語" Width="15%" />
                    &nbsp<asp:TextBox ID="tbItem4" runat="server" Width="78%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol2b">
                    <asp:TextBox ID="tbAmount4" runat="server" Width="96%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol3b">
                    <asp:TextBox ID="tbMemo4" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="styleTableEditCol1b">
                    <asp:Button ID="btSystemNote5" runat="server" Text="片語" Width="15%" />
                    &nbsp<asp:TextBox ID="tbItem5" runat="server" Width="78%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol2b">
                    <asp:TextBox ID="tbAmount5" runat="server" Width="96%"></asp:TextBox>
                </td>
                <td class="styleTableEditCol3b">
                    <asp:TextBox ID="tbMemo5" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>

        </table>




        <table id="tableEdit3" class="styleTableEdit">
            <tr>
                <td class="styleTableEditCol1b" rowspan="6" style="text-align: center;">
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="合　　　計"></asp:Label>
                </td>
                <td class="styleTableEditCol2b" rowspan="6">
                    <asp:TextBox ID="_tbAmount0" runat="server" BackColor="#CCCCCC" Width="96%"></asp:TextBox>
                </td>

                <td class="styleTableEditCol3bb" style="width: 50%">
                    <asp:RadioButton ID="rbPlayMethodA" runat="server" Text="支票" GroupName="rbG01" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="票號"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_A_1" runat="server" Width="28%"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="付款行"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_A_2" runat="server" Width="28%"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="styleTableEditCol3bb" style="width: 35%">
                    <asp:RadioButton ID="rbPlayMethodB" runat="server" Text="現金" GroupName="rbG01" />&nbsp;</td>
            </tr>
            <tr>
                <td class="styleTableEditCol3bb" style="width: 35%">
                    <asp:RadioButton ID="rbPlayMethodC" runat="server" Text="匯台銀鼓山" GroupName="rbG01" />&nbsp;</td>
            </tr>
            <tr>
                <td class="styleTableEditCol3bb" style="width: 35%">
                    <asp:RadioButton ID="rbPlayMethodD" runat="server" Text="其他" GroupName="rbG01" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbrbPlayMethod_D_1" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="styleTableEditCol3bb" style="width: 35%">
                    <asp:RadioButton ID="rbPlayMethodE" runat="server" Text="定存單" GroupName="rbG01" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="票號"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_E_1" runat="server" Width="28%"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="銀行"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_E_2" runat="server" Width="28%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td class="styleTableEditCol3bb" style="width: 35%">
                    <asp:RadioButton ID="rbPlayMethodF" runat="server" Text="保證函" GroupName="rbG01" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="票號"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_F_1" runat="server" Width="28%"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="銀行"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbrbPlayMethod_F_2" runat="server" Width="28%"></asp:TextBox>
                </td>
            </tr>
        </table>

        <br />
        <%--<table class="styleTableButton"
            border="1" style="border-collapse: collapse; border-color: black;">--%>
        <table class="styleTableButton">
            <tr>
                <td class="styleTableButton1b" colspan="2">                    
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ForeColor="#FF0000" Font-Bold="False"></asp:CustomValidator>
                    <br />
                    <asp:HiddenField ID="hfTableRowCount" runat="server" />
                    
                    <asp:Button ID="btnAddRow" runat="server" Text="增加輸入資料列" Height="30px" Width="150px" />
                    &nbsp &nbsp
                    <asp:Button ID="_btData_Submit" runat="server" Text="存檔" Width="10%" Height="30px" />
                    &nbsp&nbsp
        <asp:Button ID="_btData_Cancel" runat="server" Text="取消" Width="10%" Height="30px" />

                </td>
            </tr>

            <tr>
                <td class="styleTableButton1b" style="text-align: center;">繳款單位</td>
                <td class="styleTableButton2b" style="text-align: center;">
                    <asp:Label ID="Label17" runat="server" Text="收款單位"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="styleTableButton1b">
                    <asp:Label ID="Label18" runat="server" Text="日期時間："></asp:Label>
                    <asp:TextBox ID="_tbKeyIn_Date" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label19" runat="server" Text="人　　員："></asp:Label>
                    <asp:TextBox ID="_tbKeyIn_Operator" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label22" runat="server" Text="單　　位："></asp:Label>
                    <asp:TextBox ID="_tbKeyIn_Unit" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                </td>
                <td class="styleTableButton2b">

                    <asp:Label ID="Label20" runat="server" Text="日期時間："></asp:Label>
                    <asp:TextBox ID="_tbInvoice_Date" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="人　　員："></asp:Label>
                    <asp:TextBox ID="_tbInvoice_Operator" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                    <asp:HiddenField ID="_hfInvoice_Operator" runat="server" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="單　　位："></asp:Label>
                    <asp:TextBox ID="_tbInvoice_Unit" runat="server" BackColor="#CCCCCC" Width="50%"></asp:TextBox>
                    <asp:HiddenField ID="_hfInvoice_Unit" runat="server" />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="單據狀態："></asp:Label>
                    <asp:DropDownList ID="ddInvoice_Status" runat="server" Width="60%" />
                </td>
            </tr>

        </table>




    </asp:View>


    <asp:View ID="View2" runat="server">
        <asp:Label ID="Label25" runat="server" Text="片語" Font-Bold="True" Font-Size="X-Large" />
        <p />
        <asp:Label ID="Label23" runat="server" Text="摘要："></asp:Label>
        <asp:DropDownList ID="ddItem" runat="server" Width="40%" AutoPostBack="true">
        </asp:DropDownList>

        <p />
        <asp:Label ID="Label24" runat="server" Text="備註："></asp:Label>
        <asp:DropDownList ID="ddMemo" runat="server" Width="40%">
        </asp:DropDownList>

        <p />
        <asp:Button ID="btSystemNote_Submit" runat="server" Text="確定" Width="10%" Height="30px" />
        &nbsp&nbsp
        <asp:Button ID="btSystemNote_Cancel" runat="server" Text="取消" Width="10%" Height="30px" />


    </asp:View>


</asp:MultiView>








<p>
    
</p>











