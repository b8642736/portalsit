<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ElementMoniter.ascx.vb"
    Inherits="SMP.ElementMoniter" %>
<link href="vid:2-2../Control/GridViewStyleSheet.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style2
    {
        width: 700px;
    }
    .style3
    {
        width: 88px;
    }
    .style4
    {
        width: 250px;
    }
    .style5
    {
        width: 1168px;
        height: 24px;
    }
    .style6
    {
        width: 166px;
        text-align: left;
    }
    .hidGridColumns
    {
        display: none;
    }
</style>
<table class="style5">
    <tr>
        <td class="style6" style="width: 400px" colspan="2">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <span style="font-size: 12pt; color: #0000ff; width: 31%; height: 16px;">第一筆資料取樣品質:</span><asp:Label
                        ID="lbFirstSampleState" Style="font-size: 12pt; font-weight: bold; color: #ff0000"
                        runat="server" Text="未知(無資料)!"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <%--<td align="right" class="style3">
             &nbsp;</td>--%>
        <td rowspan="2" class="style2">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="labPCConnectMsg" runat="server"></asp:Label>
                    <asp:Timer ID="Timer2" runat="server" Interval="30000">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="style4">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                AutoPostBack="True" Width="494px">
                <asp:ListItem Value="E1" Selected="True">電爐A</asp:ListItem>
                <asp:ListItem Value="E2" Selected="True">電爐B</asp:ListItem>
                <asp:ListItem Value="A1" Selected="True">AOD</asp:ListItem>
                <asp:ListItem Value="L1" Selected="True">LADLE</asp:ListItem>
                <asp:ListItem Value="C1" Selected="True">TUNISH</asp:ListItem>
                <asp:ListItem Value="S1" Selected="True">SLAB</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">INGOT</asp:ListItem>
            </asp:CheckBoxList>
        </td>
        <%--        <td class="style3">
            &nbsp;</td>--%>
    </tr>
</table>
</span>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGray"
            BorderColor="LightGray" BorderStyle="None" BorderWidth="3px" CellSpacing="2"
            DataSourceID="SDSAnalysisData" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            PageSize="8" Width="1500px" Font-Bold="True" Font-Names="Arial" Font-Size="16pt"
            DataKeyNames="爐號,鋼種,站別,序號" GridLines="None" EnableModelValidation="True">
            <PagerSettings Position="Top" />
            <Columns>
                <asp:BoundField DataField="爐號" HeaderText="爐號" SortExpression="爐號">
                    <HeaderStyle Width="45px" />
                    <ItemStyle Width="45px" />
                    <ControlStyle BorderStyle="None" />
                </asp:BoundField>
                <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種">
                    <HeaderStyle Width="45px" />
                    <ItemStyle Width="45px" />
                </asp:BoundField>
                <asp:BoundField DataField="站別" HeaderText="站別" SortExpression="站別">
                    <HeaderStyle Width="25px" />
                    <ItemStyle Width="25px" />
                </asp:BoundField>
                <asp:BoundField DataField="序號" HeaderText="序號" SortExpression="序號">
                    <HeaderStyle Width="20px" />
                    <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="判定" HeaderText="判定" SortExpression="判定" />
                <asp:BoundField DataField="DF" DataFormatString="{0:F}" HeaderText="DF" SortExpression="DF">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="MD30" DataFormatString="{0:F2}" HeaderText="MD30" SortExpression="MD30">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="C" DataFormatString="{0:F3}" HeaderText="C" SortExpression="C">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Si" DataFormatString="{0:F3}" HeaderText="Si" SortExpression="Si">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Mn" DataFormatString="{0:F3}" HeaderText="Mn" SortExpression="Mn">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="P" DataFormatString="{0:F3}" HeaderText="P" SortExpression="P">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="S" DataFormatString="{0:F3}" HeaderText="S" SortExpression="S">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cr" DataFormatString="{0:F3}" HeaderText="Cr" SortExpression="Cr">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Ni" DataFormatString="{0:F3}" HeaderText="Ni" SortExpression="Ni">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cu" DataFormatString="{0:F3}" HeaderText="Cu" SortExpression="Cu">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Mo" DataFormatString="{0:F3}" HeaderText="Mo" SortExpression="Mo">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Sn" DataFormatString="{0:F3}" HeaderText="Sn" SortExpression="Sn">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Pb" DataFormatString="{0:F3}" HeaderText="Pb" SortExpression="Pb">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="N2" DataFormatString="{0:F3}" HeaderText="N2" SortExpression="N2">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Co" DataFormatString="{0:F3}" HeaderText="Co" SortExpression="Co">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="AL" DataFormatString="{0:F3}" HeaderText="AL" SortExpression="AL">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Ti" DataFormatString="{0:F3}" HeaderText="Ti" SortExpression="Ti">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nb" DataFormatString="{0:F3}" HeaderText="Nb" SortExpression="Nb">
                    <HeaderStyle Height="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="O2" DataFormatString="{0:F3}" HeaderText="O2" SortExpression="O2">
                    <HeaderStyle Height="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="B" DataFormatString="{0:F5}" HeaderText="B" SortExpression="B">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Ca" DataFormatString="{0:F5}" HeaderText="Ca" SortExpression="Ca">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Mg" DataFormatString="{0:F5}" HeaderText="Mg" SortExpression="Mg">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="材質" HeaderText="材質" ReadOnly="True" SortExpression="材質">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="輻射" HeaderText="輻射" SortExpression="輻射" />
                <asp:BoundField DataField="備註1" HeaderText="背景" SortExpression="備註1" />
                <asp:BoundField DataField="INGOT" HeaderText="INGOT" SortExpression="INGOT" HeaderStyle-CssClass="hidGridColumns"
                    ItemStyle-CssClass="hidGridColumns">
                <HeaderStyle CssClass="hidGridColumns" />
                <ItemStyle CssClass="hidGridColumns" />
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="Fe" HeaderText="Fe" SortExpression="Fe" />
                <asp:BoundField DataField="As" HeaderText="As" SortExpression="As" />
                <asp:BoundField DataField="Bi" HeaderText="Bi" SortExpression="Bi" />
                <asp:BoundField DataField="Sb" HeaderText="Sb" SortExpression="Sb" />
                <asp:BoundField DataField="Zn" HeaderText="Zn" SortExpression="Zn" />
                <asp:BoundField DataField="Zr" HeaderText="Zr" SortExpression="Zr" />
                <asp:BoundField DataField="GP" HeaderText="GP" SortExpression="GP" />
                <asp:BoundField DataField="Ta" HeaderText="Ta" SortExpression="Ta" />
                <asp:BoundField DataField="CAndN" HeaderText="CAndN" SortExpression="CAndN" />
                <asp:BoundField DataField="NbAndTa" HeaderText="NbAndTa" SortExpression="NbAndTa" />
            </Columns>




            <PagerStyle HorizontalAlign="Left" />
            <RowStyle BackColor="White" BorderColor="LightGray" BorderStyle="Solid" BorderWidth="2px"
                Font-Size="12pt" ForeColor="Black" Height="40px" HorizontalAlign="Center" Width="10px" />
            <HeaderStyle BackColor="White" Height="40px" />
        </asp:GridView>
        資料最後更新時間(每十秒<span lang="zh-tw">內</span>更新一次):<asp:Label ID="Label1" runat="server"
            Text="Label"></asp:Label>
        <asp:Button ID="btnChangeFirstBackupColor" runat="server" Text="第一筆資料已處理(底色變為白色)"
            BackColor="#99FF99" />
        <asp:Timer ID="Timer1" runat="server" Interval="4000">
        </asp:Timer>
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
        <embed runat="server" id="WaveSound1" hidden="True" height="0" width="0" autostart="False"
            type="audio/wav" loop="False" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:SqlDataSource ID="SDSAnalysisData" runat="server" ConnectionString="<%$ ConnectionStrings:SMP.My.MySettings.DefaultDBConnect %>"
    SelectCommand="SELECT top 8 爐號,  鋼種, 材質, 站別, 序號, 判定, 日期, 時間, 操作員, DF, MD30, C, Si, Mn, P, S, Cr, Ni, Cu, Mo, Co, AL, Sn, Pb, Ti, Nb, V, W,O1 AS O2,N1 AS N2, H2, B, Ca, Mg, Fe,  分光儀編號, 輻射, 備註1 
                ,( SELECT 'Y'
            	            FROM [ForCustomerSteelAndType]
                            WHERE [ForCustomerSteelAndType].[SteelKind]= [分析資料].[鋼種]
                              AND [ForCustomerSteelAndType].[Type]= [分析資料].[材質]                  
                              AND [ForCustomerSteelAndType].[SpecialProcessType]='1'
              ) INGOT
             ,[As],Bi,Sb,Zn,Zr,GP,Ta
              ,([C]+[N1]) AS CAndN, ([NB]+[Ta]) AS NbAndTa
FROM 分析資料 
WHERE 
            站別 = @SetST1 OR
            站別 = @SetST2 OR
            站別 = @SetST3 OR
            站別 = @SetST4 OR
            站別 = @SetST5 OR
            站別 = @SetST6 OR @SetHFSETALL='TRUE'  OR
            (@SetST7='TRUE' AND EXISTS (
                            SELECT 1 
            	            FROM [ForCustomerSteelAndType]
                            WHERE [ForCustomerSteelAndType].[SteelKind]= [分析資料].[鋼種]
                                AND [ForCustomerSteelAndType].[Type]= [分析資料].[材質]                  
                                AND [ForCustomerSteelAndType].[SpecialProcessType]='1')
            )
ORDER BY 日期 DESC,時間 DESC" ProviderName="<%$ ConnectionStrings:SMP.My.MySettings.DefaultDBConnect.ProviderName %>"
    SqlCacheDependency="QCdb01:分析資料" CacheDuration="60" EnableCaching="True">
    <SelectParameters>
        <asp:ControlParameter ControlID="HFST1" Name="SetST1" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST2" Name="SetST2" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST3" Name="SetST3" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST4" Name="SetST4" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST5" Name="SetST5" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST6" Name="SetST6" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFST7" Name="SetST7" PropertyName="Value" />
        <asp:ControlParameter ControlID="HFSETALL" Name="SetHFSETALL" PropertyName="Value" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:HiddenField ID="HFST1" runat="server" Value="E1" />
<asp:HiddenField ID="HFST2" runat="server" Value="E2" />
<asp:HiddenField ID="HFST3" runat="server" Value="A1" />
<asp:HiddenField ID="HFST4" runat="server" Value="L1" />
<asp:HiddenField ID="HFST5" runat="server" Value="C1" />
<asp:HiddenField ID="HFST6" runat="server" Value="S1" />
<asp:HiddenField ID="HFST7" runat="server" Value="TRUE" />
<asp:HiddenField ID="HFSETALL" runat="server" Value="TRUE" />
<asp:LinqDataSource ID="LDSNotOnLinePCs" runat="server">
</asp:LinqDataSource>
&nbsp; 