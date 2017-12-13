<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NonRadioactive_Search.ascx.vb" Inherits="QualityControl.NonRadioactive_Search" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .auto-style4 {
        width: 69px;
    }
    
    .View2-Table {
        width: 70%;
        border-width: 4px;
        border-style: dotted;
        border-collapse: collapse;
        border-color: #cccccc;
    }

    .View2_TD_B {
        width: 40px;
        border-right-width: 4px;
        border-right-width: 4px;
        border-right-style: dotted;
        border-right-color: #cccccc;
    }

    .View2_TD_A {
        width: 40px;
    }

    .auto-style5 {
        height: 23px;
        width: 559px;
    }
    .auto-style6 {
        width: 559px;
        align-content:center
    }
    .auto-style7 {
        height: 23px;
    }
    .auto-style8 {
        width: 559px;
        align-content: center;
        height: 23px;
    }
    .auto-style12 {
        width: 140px;
        align-content: center;
    }
    .auto-style13 {
        width: 120px;
        align-content: center;
        height: 23px;
    }
    .auto-style14 {
        height: 23px;
        width: 120px;
    }
    .auto-style15 {
        height: 18px;
    }
    .auto-style16 {
        border-right: 4px dotted #cccccc;
        width: 40px;
        height: 18px;
    }
    .auto-style17 {
        width: 559px;
        align-content: center;
        height: 18px;
    }
    </style>


<table class="View2-Table">
    <tr>
        <td colspan="2" class="auto-style15">一、新增單據</td>
        <td class="auto-style16"></td>
        <td class="auto-style15"></td>
        <td class="auto-style17" colspan="2">二、查詢單據</td>
    </tr>
    <tr>
        <td class="View2_TD_A " rowspan="7">&nbsp;</td>
        <td class="View2_TD_A ">&nbsp;</td>
        <td class="View2_TD_B" rowspan="7">&nbsp;</td>
        <td class="View2_TD_A " rowspan="7">&nbsp;</td>
        <td class="auto-style12">
            日期<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label3">：</span>
&nbsp;<asp:CheckBox ID="ckBydate" runat="server" Checked="True" AutoPostBack="True" />

        </td>
        <td class="auto-style6">
            <asp:TextBox ID="tbDateS" runat="server"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateS">
</cc1:CalendarExtender>
            &nbsp;~ <asp:TextBox ID="tbDateE" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="tbDateE">
</cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td class="auto-style12">
            單號<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label4">：</span>


        </td>
        <td class="auto-style6">
            <asp:TextBox ID="tbLabno" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style12">
            客戶名稱<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label5">：</span>


        </td>
        <td class="auto-style8">
            <asp:TextBox ID="tbBuyer" runat="server"></asp:TextBox>


        </td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style12">
            鋼捲號碼<span id="ctl00_ContentPlaceHolder1_InvoiceOfReceivables_Main1_TabContainer1_TabPanel1_InvoiceOfReceivables_Search1_Label6">：</span> </td>
        <td class="auto-style5">
            <asp:TextBox ID="tbCoilno" runat="server"></asp:TextBox>

                    (兩個以上以&nbsp; &#39;,&#39; 分隔)</td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td class="auto-style12"></td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td class="View2_TD_A ">
            <asp:Button ID="btnAdd" runat="server" Text="新增單據" Height="59px" Width="228px" />


        </td>
        <td style="align-self:center " colspan="2">
            <asp:Button ID="btnSearch" runat="server" Height="59px" Text="查詢" Width="228px" />
        </td>
    </tr>
    <tr>
        <td class="View2_TD_A ">&nbsp;</td>
        <td class="auto-style6" colspan="2">
            &nbsp;</td>
    </tr>
</table>


            <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                        

    <asp:ListView ID="ListView1" runat="server" DataSourceID="ods" EnableModelValidation="True" DataKeyNames="LAB_REPORTNO">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td style="text-align:center">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" Visible ="false" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Visible = "false"  />
                    <asp:Button ID="PrintButton" runat="server" Text="列印" ToolTip ='<%# FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2")) %>'  OnClick="btnPrint_Click" /> 
                    <asp:Button ID="ViewButton" runat="server" Text="檢視" ToolTip ='<%# FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2")) %>'  OnClick="btnView_Click" /> 
                </td>
                <td>
                    <asp:Label ID="LAB_REPORTNOLabel" runat="server" Text='<%# FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2")) %>' />
                </td>    
                <td>
                    <asp:Label ID="客戶名稱Label" runat="server" Text='<%# FS_Buyer(Eval("客戶名稱"))%>' />
                </td>                 
                <td>
                    <asp:Label ID="資料日期Label" runat="server" Text='<%# FS_Date(Eval("資料日期"))%>' />
                </td>
                
            </tr>
        </AlternatingItemTemplate>
       
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>未傳回資料。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <%-- --%>
       

        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td style="text-align:center">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" Visible ="false" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton" ConfirmText="是否確定刪除?" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" Visible ="false"/>
                    <asp:Button ID="PrintButton" runat="server" Text="列印" ToolTip ='<%# FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2"))%>'  OnClick="btnPrint_Click" /> 
                    <asp:Button ID="ViewButton" runat="server" Text="檢視" ToolTip ='<%#FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2")) %>'  OnClick="btnView_Click" /> 
                </td>
                <td>
                    <asp:Label ID="LAB_REPORTNOLabel" runat="server" Text='<%# FS_showlabno(Eval("LAB_REPORTNO"), Eval("LAB_REPORTNO2"))%>' />
                </td>
                <td>
                    <asp:Label ID="客戶名稱Label" runat="server" Text='<%# FS_Buyer(Eval("客戶名稱"))%>' />
                </td>  
                <td>
                    <asp:Label ID="資料日期Label" runat="server" Text='<%# FS_Date(Eval("資料日期"))%>' />
                </td>
              
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server" style="width:700px">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="font-size:14pt; background-color:#DCDCDC;color: #000000;">
                                <th runat="server" style ="width:120px"></th>
                                <th runat="server" style ="width:130px">單號</th>
                                <th runat="server" style ="width:280px">客戶名稱</th>
                                <th runat="server" style ="width:160px">存檔日期</th>
                               <%-- 
                                <th runat="server">標題2</th>
                                <th runat="server">原能會字號</th>
                                <th runat="server">檢驗人員字號</th>
                                
                                 <th runat="server">品檢主管</th>
                                <th runat="server">品檢日期_起</th>
                                <th runat="server">品檢日期_迄</th>
                                
                            --%>
                               
                            </tr>
                            <tr id="itemPlaceholder" runat="server" style ="width:0%">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
       
    </asp:ListView>

<asp:ObjectDataSource ID="ods" runat="server" DataObjectTypeName="CompanyORMDB.SQLServer.QCDB01.LabRecordA1_M" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Search" TypeName="QualityControl.NonRadioactive_Search" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL" Name="fromSQL" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
<p>
    <br />
</p>
<asp:HiddenField ID="hfSQL" runat="server" />

