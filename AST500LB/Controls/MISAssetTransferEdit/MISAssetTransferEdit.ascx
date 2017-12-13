<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MISAssetTransferEdit.ascx.vb" Inherits="AST500LB.MISAssetTransferEdit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        width: 140px;
        text-align:right;
    }
    .auto-style2 {
        width: 115px;
    }
</style>
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width ="100%" style="margin-bottom: 311px" Height="601px">
    <cc1:TabPanel runat="server" HeaderText="資產主檔查詢" ID="TabPanel0">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">資產編號:</td>
                    <td>
                        <asp:TextBox ID="tbNAssetNumber" runat="server" Width="200px"></asp:TextBox>
                        (多筆請以 &#39;,&#39; 分隔)</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        資產名稱:</td>
                    <td>
                        <asp:TextBox ID="tbAssetName" runat="server" Width="200px"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td >
                        <asp:Button ID="btnSearchAsset" runat="server" Text="查詢資產" Width="100px" />
                        <asp:Button ID="btnClearSearchCondiction" runat="server" Text="清除查詢條件" Width="100px" />
                    </td>       
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataSourceID="odsSearchNearAsset" DataKeyNames="number,AboutAST106PF_UseDept">
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="出帳資產" ShowHeader="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="NUMBER" HeaderText="資產編號" SortExpression="NUMBER" />
                    <asp:BoundField DataField="NAME" HeaderText="資產名稱" SortExpression="NAME" />
                    <asp:BoundField DataField="QUANT" HeaderText="數量" SortExpression="QUANT" />
                    <asp:BoundField DataField="AMOUNT" HeaderText="入帳金額" SortExpression="AMOUNT" />
                    <asp:BoundField DataField="DATE" HeaderText="入帳日期" SortExpression="DATE" />
                    <asp:BoundField DataField="USLAFF" HeaderText="使用年限" SortExpression="USLAFF" />
                    <asp:BoundField DataField="DEPR" HeaderText="折舊金額" SortExpression="DEPR" />
                    <asp:BoundField DataField="V7611" HeaderText="殘值金額" SortExpression="V7611" />
                    <asp:BoundField DataField="N7611" HeaderText="殘值重估年限" SortExpression="N7611" />
                    <asp:BoundField DataField="AboutAST106PF_UseDept" HeaderText="使用單位" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfSearchNearAsset" runat="server" />
            <asp:ObjectDataSource ID="odsSearchNearAsset" runat="server" SelectMethod="SearchNearAsset" TypeName="AST500LB.MISAssetTransferEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfSearchNearAsset" Name="SearchSQL" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="移轉查詢編修" ID="TabPanel1">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">資產編號:</td>
                    <td>
                        <asp:TextBox ID="tbNUMBER" runat="server"></asp:TextBox>
                        (多筆請以 &#39;,&#39; 分隔)</td>
                    <td class="auto-style1">資產名稱:</td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">出帳資產編號:</td>
                    <td>
                        <asp:TextBox ID="tbREFORGNUM" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                    <td class="auto-style1">設備使用者姓名:</td>
                    <td>
                        <asp:TextBox ID="tbUSERNAME" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">設備編號:</td>
                    <td>
                        <asp:TextBox ID="tbEQUID" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                    <td class="auto-style1">資訊處設備ID:</td>
                    <td>
                        <asp:TextBox ID="tbMISEQUID" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">移出單位:</td>
                    <td>
                        <asp:TextBox ID="tbOUTDEPT" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                    <td class="auto-style1">移入單位:</td>
                    <td>
                        <asp:TextBox ID="tbINDEPT" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">設備IP:</td>
                    <td>
                        <asp:TextBox ID="tbEQUIP" runat="server"></asp:TextBox>(多筆請以 &#39;,&#39; 分隔)        

                    </td>
                    <td class="auto-style1">印表註記:</td>
                    <td>
                        <asp:TextBox ID="tbPRINTGUPSearch" runat="server"></asp:TextBox>
                        (多筆請以 &#39;,&#39; 分隔)&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">比對轉移狀態:</td>
                    <td>

                        <asp:RadioButtonList ID="rblTransStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="ALL">全部</asp:ListItem>
                            <asp:ListItem Value="NOTRANS">未轉移</asp:ListItem>
                            <asp:ListItem Value="TRANS">正常轉移</asp:ListItem>
                            <asp:ListItem Value="TRANSDIFFDEPT">異常轉移</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="100px" />
                        <asp:Button ID="btnSearchToExcel" runat="server" Text="下載Excel" Width="100px" />
                        <asp:Button ID="btnClearPrintGouptNumber" runat="server" Text="清除印表註記"   OnClientClick ='javascript:return confirm("是否確定清除?")'  Width="120px" />
                    </td>
                </tr>
            </table>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="OUTDEPT,INDEPT,CDATADATE,NUMBER" DataSourceID="ODSSearchResult" InsertItemPosition="LastItem">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick ='javascript:return confirm("是否確定清除?")' />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        </td>
                        <td>
                            <asp:Label ID="OUTDEPTLabel" runat="server" Text='<%# Eval("OUTDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="INDEPTLabel" runat="server" Text='<%# Eval("INDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="About_AST106PF_ASTFSALabel" runat="server" Text='<%# Eval("About_AST106PF_ASTFSA")%>' />
                       </td>
                       <td>
                            <asp:Label ID="CDATADATELabel" runat="server" Text='<%# Eval("CDATADATE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                        </td>
                        <td>
                            <asp:Label ID="KINDLabel" runat="server" Text='<%# Eval("KIND") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="REFORGNUMLabel" runat="server" Text='<%# Eval("REFORGNUM") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TVALUELabel" runat="server" Text='<%# Eval("TVALUE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDEPRLabel" runat="server" Text='<%# Eval("TDEPR") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDUEDAYLabel" runat="server" Text='<%# Eval("TDUEDAY") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EDTUSRIDLabel" runat="server" Text='<%# Eval("EDTUSRID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="USERNAMELabel" runat="server" Text='<%# Eval("USERNAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIDLabel" runat="server" Text='<%# Eval("EQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIPLabel" runat="server" Text='<%# Eval("EQUIP") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MISEQUIDLabel" runat="server" Text='<%# Eval("MISEQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PRINTGUPLabel1" runat="server" Text='<%# Eval("PRINTGUP")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        </td>
                        <td>
                            <asp:TextBox ID="OUTDEPTTextBox" runat="server" Text='<%# Bind("OUTDEPT") %>' Width="30px" ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="INDEPTTextBox" runat="server" Text='<%# Bind("INDEPT") %>' Width="30px" ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="About_AST106PF_ASTFSATextBox" runat="server" Text='<%# Eval("About_AST106PF_ASTFSA")%>' Width="40px" ReadOnly="true" BackColor="Gray"   />
                       </td>
                        <td>
                            <asp:TextBox ID="CDATADATETextBox" runat="server" Text='<%# Bind("CDATADATE") %>' ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' Width="100px" ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="KINDTextBox" runat="server" Text='<%# Bind("KIND") %>' ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>'  ReadOnly="true" BackColor="Gray" />
                        </td>
                        <td>
                            <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' Width="20px" />
                        </td>
                        <td>
                            <asp:TextBox ID="REFORGNUMTextBox" runat="server" Text='<%# Bind("REFORGNUM") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:TextBox ID="TVALUETextBox" runat="server" Text='<%# Bind("TVALUE") %>'  Width="100px"  ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="TDEPRTextBox" runat="server" Text='<%# Bind("TDEPR") %>' Width="100px"   ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="TDUEDAYTextBox" runat="server" Text='<%# Bind("TDUEDAY") %>' Width="80px"   ReadOnly="true" BackColor="Gray"  />
                        </td>
                        <td>
                            <asp:TextBox ID="EDTUSRIDTextBox" runat="server" Text='<%# Bind("EDTUSRID") %>' Width="60px"  ReadOnly="true" BackColor="Gray"   />
                        </td>
                        <td>
                            <asp:TextBox ID="USERNAMETextBox" runat="server" Text='<%# Bind("USERNAME") %>' Width="70px" />
                        </td>
                        <td>
                            <asp:TextBox ID="EQUIDTextBox" runat="server" Text='<%# Bind("EQUID") %>' Width="120px" />
                        </td>
                        <td>
                            <asp:TextBox ID="EQUIPTextBox" runat="server" Text='<%# Bind("EQUIP") %>' Width="80px" />
                        </td>
                        <td>
                            <asp:TextBox ID="MISEQUIDTextBox" runat="server" Text='<%# Bind("MISEQUID") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:TextBox ID="MEMOTextBox" runat="server" Text='<%# Bind("MEMO") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlISWAITPRT" runat="server" SelectedValue='<%# Bind("ISWAITPRT")%>'>                                
                                <asp:ListItem   Selected="True" Value="1">要</asp:ListItem>
                                <asp:ListItem   Value="0">不印</asp:ListItem>                                   
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="PRINTGUPTextBox" runat="server" Text='<%# Bind("PRINTGUP")%>'  ReadOnly="true" />--%>
                        </td>
                    </tr>
                    <tr>
                            <td>訊息:<asp:Label ID="lbMsg" runat="server" Style="text-align:left;color:red;" Text=""  />
                            </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>未傳回資料。</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                        </td>
                        <td>
                            <asp:TextBox ID="OUTDEPTTextBox" runat="server" Text='<%# Bind("OUTDEPT") %>' Width="30px" />
                        </td>
                        <td>
                            <asp:TextBox ID="INDEPTTextBox" runat="server" Text='<%# Bind("INDEPT") %>' Width="30px" />
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="CDATADATETextBox" runat="server" Text='<%# Bind("CDATADATE") %>' />--%>
                            <asp:Label ID="Label1" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                            
                        </td>
                        <td>
                            <asp:TextBox ID="NUMBERTextBox" runat="server" Text='<%# Bind("NUMBER") %>' Width="100px" />
                        </td>
                        <td>
                            <%--<asp:TextBox ID="KINDTextBox" runat="server" Text='<%# Bind("KIND") %>' />--%>
                            <asp:Label ID="Label2" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="NAMETextBox" runat="server" Text='<%# Bind("NAME") %>' />--%>
                            <asp:Label ID="Label3" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="QUANTTextBox" runat="server" Text='<%# Bind("QUANT") %>' Width="20px" />
                        </td>
                        <td>
                            <asp:TextBox ID="REFORGNUMTextBox" runat="server" Text='<%# Bind("REFORGNUM") %>' Width="100px" />
                        </td>
                        <td>
                            <%--<asp:TextBox ID="TVALUETextBox" runat="server" Text='<%# Bind("TVALUE") %>' />--%>
                            <asp:Label ID="Label4" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="TDEPRTextBox" runat="server" Text='<%# Bind("TDEPR") %>' />--%>
                            <asp:Label ID="Label5" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="TDUEDAYTextBox" runat="server" Text='<%# Bind("TDUEDAY") %>' />--%>
                            <asp:Label ID="Label6" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="EDTUSRIDTextBox" runat="server" Text='<%# Bind("EDTUSRID") %>' />--%>
                            <asp:Label ID="Label7" runat="server" Text="(自動給值)" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="USERNAMETextBox" runat="server" Text='<%# Bind("USERNAME") %>' Width="70px" />
                        </td>
                        <td>
                            <asp:TextBox ID="EQUIDTextBox" runat="server" Text='<%# Bind("EQUID") %>' Width="120px" />
                        </td>
                        <td>
                            <asp:TextBox ID="EQUIPTextBox" runat="server" Text='<%# Bind("EQUIP") %>' Width="80px" />
                        </td>
                        <td>
                            <asp:TextBox ID="MISEQUIDTextBox" runat="server" Text='<%# Bind("MISEQUID") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:TextBox ID="MEMOTextBox" runat="server" Text='<%# Bind("MEMO") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlISWAITPRT" runat="server" SelectedValue='<%# Bind("ISWAITPRT")%>'>                                
                                <asp:ListItem   Selected="True" Value="1">要</asp:ListItem>
                                <asp:ListItem   Value="0">不印</asp:ListItem>                                   
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("PRINTGUP")%>' />--%>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  OnClientClick ='javascript:return confirm("是否確定清除?")'  />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        </td>
                        <td>
                            <asp:Label ID="OUTDEPTLabel" runat="server" Text='<%# Eval("OUTDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="INDEPTLabel" runat="server" Text='<%# Eval("INDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="About_AST106PF_ASTFSALabel" runat="server" Text='<%# Eval("About_AST106PF_ASTFSA")%>' />
                        </td>
                        <td>
                            <asp:Label ID="CDATADATELabel" runat="server" Text='<%# Eval("CDATADATE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                        </td>
                        <td>
                            <asp:Label ID="KINDLabel" runat="server" Text='<%# Eval("KIND") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="REFORGNUMLabel" runat="server" Text='<%# Eval("REFORGNUM") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TVALUELabel" runat="server" Text='<%# Eval("TVALUE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDEPRLabel" runat="server" Text='<%# Eval("TDEPR") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDUEDAYLabel" runat="server" Text='<%# Eval("TDUEDAY") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EDTUSRIDLabel" runat="server" Text='<%# Eval("EDTUSRID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="USERNAMELabel" runat="server" Text='<%# Eval("USERNAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIDLabel" runat="server" Text='<%# Eval("EQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIPLabel" runat="server" Text='<%# Eval("EQUIP") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MISEQUIDLabel" runat="server" Text='<%# Eval("MISEQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PRINTGUPLabel1" runat="server" Text='<%# Eval("PRINTGUP")%>' />      
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate >
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server"></th>
                                        <th runat="server">移出單位</th>
                                        <th runat="server">移入單位</th>
                                        <th runat="server">行政處現行單位</th>
                                        <th runat="server">建檔日期</th>
                                        <th runat="server">資產編號</th>
                                        <th runat="server">資產類別</th>
                                        <th runat="server">資產名稱</th>
                                        <th runat="server">數量</th>
                                        <th runat="server">出帳資產編號</th>
                                        <th runat="server">入帳資產總值</th>
                                        <th runat="server">移轉時殘值</th>
                                        <th runat="server">移轉後預估年限</th>
                                        <th runat="server">編修資料工號</th>
                                        <th runat="server">設備使用者姓名</th>
                                        <th runat="server">設備SN</th>
                                        <th runat="server">電腦IP</th>
                                        <th runat="server">資訊處SN</th>
                                        <th runat="server">備註</th>
                                        <th runat="server">印表註記</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>訊息:<asp:Label ID="lbMsg" runat="server" Style="text-align:left;color:red;" Text=""  />
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
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
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除"  />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
                        </td>
                        <td>
                            <asp:Label ID="OUTDEPTLabel" runat="server" Text='<%# Eval("OUTDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="INDEPTLabel" runat="server" Text='<%# Eval("INDEPT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="About_AST106PF_ASTFSALabel" runat="server" Text='<%# Eval("About_AST106PF_ASTFSA")%>' />
                        </td>
                        <td>
                            <asp:Label ID="CDATADATELabel" runat="server" Text='<%# Eval("CDATADATE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NUMBERLabel" runat="server" Text='<%# Eval("NUMBER") %>' />
                        </td>
                        <td>
                            <asp:Label ID="KINDLabel" runat="server" Text='<%# Eval("KIND") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="QUANTLabel" runat="server" Text='<%# Eval("QUANT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="REFORGNUMLabel" runat="server" Text='<%# Eval("REFORGNUM") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TVALUELabel" runat="server" Text='<%# Eval("TVALUE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDEPRLabel" runat="server" Text='<%# Eval("TDEPR") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TDUEDAYLabel" runat="server" Text='<%# Eval("TDUEDAY") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EDTUSRIDLabel" runat="server" Text='<%# Eval("EDTUSRID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="USERNAMELabel" runat="server" Text='<%# Eval("USERNAME") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIDLabel" runat="server" Text='<%# Eval("EQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EQUIPLabel" runat="server" Text='<%# Eval("EQUIP") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MISEQUIDLabel" runat="server" Text='<%# Eval("MISEQUID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="MEMOLabel" runat="server" Text='<%# Eval("MEMO") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ODSSearchResult" runat="server" DataObjectTypeName="CompanyORMDB.AST500LB.AST402PF" DeleteMethod="CDBDelete" InsertMethod="CDBInsert" SelectMethod="Search" TypeName="AST500LB.MISAssetTransferEdit" UpdateMethod="CDBUpdate">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfQryString" Name="QryString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfQryString" runat="server" />
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="移轉單列印">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style2">印表群編號:</td>
                    <td>
                        <asp:TextBox ID="tbPRINTGUP" runat="server"></asp:TextBox>
                        (如不篩選請清為空白)</td>
                </tr>
                <tr>
                    <td class="auto-style2">單位:</td>
                    <td>
                        <asp:TextBox ID="tbDept" runat="server" Width="138px"></asp:TextBox>(包函子單位請以&#39;*&#39;表示 ex:W3*)</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearchPrint" runat="server" Text="查詢印表" Width="100px" />
                    </td>
                </tr>
            </table>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Height="534px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="Controls\MISAssetTransferEdit\MISAssetTransfer.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsPrintDataSource" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="odsPrintDataSource" runat="server" SelectMethod="SearchToPrint" TypeName="AST500LB.MISAssetTransferEdit">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfPrintQry" Name="QryString" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hfPrintQry" runat="server" />
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>


