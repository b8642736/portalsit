<asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataKeyNames="FD001" DataSourceID="odsSearchResult">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="�s��" />
                        </td>
                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                        </td>
                        <td>
                            <asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD00Label" runat="server" Text="�X��" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="���\" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="���\" />
                        </td>

                        <td>
                            <asp:Label ID="FD01Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O01"), Eval("�X�Ԯɶ�01"))%>' /><br>
                            <asp:Label ID="FD01BLabel" runat="server" Text='<%# showFoodType(Eval("FD01B")) %>' /><br>
                            <asp:Label ID="FD01CLabel" runat="server" Text='<%# Eval("FD01C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD02Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O02"), Eval("�X�Ԯɶ�02"))%>' /><br>
                            <asp:Label ID="FD02BLabel" runat="server" Text='<%# showFoodType(Eval("FD02B")) %>' /><br>
                            <asp:Label ID="FD02CLabel" runat="server" Text='<%# Eval("FD02C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD03Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O03"), Eval("�X�Ԯɶ�03"))%>' /><br>
                            <asp:Label ID="FD03BLabel" runat="server" Text='<%# showFoodType(Eval("FD03B")) %>' /><br>
                            <asp:Label ID="FD03CLabel" runat="server" Text='<%# Eval("FD03C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD04Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O04"), Eval("�X�Ԯɶ�04"))%>' /><br>
                            <asp:Label ID="FD04BLabel" runat="server" Text='<%# showFoodType(Eval("FD04B")) %>' /><br>
                            <asp:Label ID="FD04CLabel" runat="server" Text='<%# Eval("FD04C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD05Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O05"), Eval("�X�Ԯɶ�05"))%>' /><br>
                            <asp:Label ID="FD05BLabel" runat="server" Text='<%# showFoodType(Eval("FD05B")) %>' /><br>
                            <asp:Label ID="FD05CLabel" runat="server" Text='<%# Eval("FD05C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD06Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O06"), Eval("�X�Ԯɶ�06"))%>' /><br>
                            <asp:Label ID="FD06BLabel" runat="server" Text='<%# showFoodType(Eval("FD06B")) %>' /><br>
                            <asp:Label ID="FD06CLabel" runat="server" Text='<%# Eval("FD06C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD07Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O07"), Eval("�X�Ԯɶ�07"))%>' /><br>
                            <asp:Label ID="FD07BLabel" runat="server" Text='<%# showFoodType(Eval("FD07B")) %>' /><br>
                            <asp:Label ID="FD07CLabel" runat="server" Text='<%# Eval("FD07C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD08Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O08"), Eval("�X�Ԯɶ�08"))%>' /><br>
                            <asp:Label ID="FD08BLabel" runat="server" Text='<%# showFoodType(Eval("FD08B")) %>' /><br>
                            <asp:Label ID="FD08CLabel" runat="server" Text='<%# Eval("FD08C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD09Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O09"), Eval("�X�Ԯɶ�09"))%>' /><br>
                            <asp:Label ID="FD09BLabel" runat="server" Text='<%# showFoodType(Eval("FD09B")) %>' /><br>
                            <asp:Label ID="FD09CLabel" runat="server" Text='<%# Eval("FD09C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD10Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O10"), Eval("�X�Ԯɶ�10"))%>' /><br>
                            <asp:Label ID="FD10BLabel" runat="server" Text='<%# showFoodType(Eval("FD10B")) %>' /><br>
                            <asp:Label ID="FD10CLabel" runat="server" Text='<%# Eval("FD10C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD11Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O11"), Eval("�X�Ԯɶ�11"))%>' /><br>
                            <asp:Label ID="FD11BLabel" runat="server" Text='<%# showFoodType(Eval("FD11B")) %>' /><br>
                            <asp:Label ID="FD11CLabel" runat="server" Text='<%# Eval("FD11C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD12Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O12"), Eval("�X�Ԯɶ�12"))%>' /><br>
                            <asp:Label ID="FD12BLabel" runat="server" Text='<%# showFoodType(Eval("FD12B")) %>' /><br>
                            <asp:Label ID="FD12CLabel" runat="server" Text='<%# Eval("FD12C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD13Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O13"), Eval("�X�Ԯɶ�13"))%>' /><br>
                            <asp:Label ID="FD13BLabel" runat="server" Text='<%# showFoodType(Eval("FD13B")) %>' /><br>
                            <asp:Label ID="FD13CLabel" runat="server" Text='<%# Eval("FD13C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD14Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O14"), Eval("�X�Ԯɶ�14"))%>' /><br>
                            <asp:Label ID="FD14BLabel" runat="server" Text='<%# showFoodType(Eval("FD14B")) %>' /><br>
                            <asp:Label ID="FD14CLabel" runat="server" Text='<%# Eval("FD14C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD15Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O15"), Eval("�X�Ԯɶ�15"))%>' /><br>
                            <asp:Label ID="FD15BLabel" runat="server" Text='<%# showFoodType(Eval("FD15B")) %>' /><br>
                            <asp:Label ID="FD15CLabel" runat="server" Text='<%# Eval("FD15C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD16Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O16"), Eval("�X�Ԯɶ�16"))%>' /><br>
                            <asp:Label ID="FD16BLabel" runat="server" Text='<%# showFoodType(Eval("FD16B")) %>' /><br>
                            <asp:Label ID="FD16CLabel" runat="server" Text='<%# Eval("FD16C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD17Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O17"), Eval("�X�Ԯɶ�17"))%>' /><br>
                            <asp:Label ID="FD17BLabel" runat="server" Text='<%# showFoodType(Eval("FD17B")) %>' /><br>
                            <asp:Label ID="FD17CLabel" runat="server" Text='<%# Eval("FD17C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD18Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O18"), Eval("�X�Ԯɶ�18"))%>' /><br>
                            <asp:Label ID="FD18BLabel" runat="server" Text='<%# showFoodType(Eval("FD18B")) %>' /><br>
                            <asp:Label ID="FD18CLabel" runat="server" Text='<%# Eval("FD18C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD19Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O19"), Eval("�X�Ԯɶ�19"))%>' /><br>
                            <asp:Label ID="FD19BLabel" runat="server" Text='<%# showFoodType(Eval("FD19B")) %>' /><br>
                            <asp:Label ID="FD19CLabel" runat="server" Text='<%# Eval("FD19C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD20Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O20"), Eval("�X�Ԯɶ�20"))%>' /><br>
                            <asp:Label ID="FD20BLabel" runat="server" Text='<%# showFoodType(Eval("FD20B")) %>' /><br>
                            <asp:Label ID="FD20CLabel" runat="server" Text='<%# Eval("FD20C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD21Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O21"), Eval("�X�Ԯɶ�21"))%>' /><br>
                            <asp:Label ID="FD21BLabel" runat="server" Text='<%# showFoodType(Eval("FD21B")) %>' /><br>
                            <asp:Label ID="FD21CLabel" runat="server" Text='<%# Eval("FD21C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD22Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O22"), Eval("�X�Ԯɶ�22"))%>' /><br>
                            <asp:Label ID="FD22BLabel" runat="server" Text='<%# showFoodType(Eval("FD22B")) %>' /><br>
                            <asp:Label ID="FD22CLabel" runat="server" Text='<%# Eval("FD22C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD23Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O23"), Eval("�X�Ԯɶ�23"))%>' /><br>
                            <asp:Label ID="FD23BLabel" runat="server" Text='<%# showFoodType(Eval("FD23B")) %>' /><br>
                            <asp:Label ID="FD23CLabel" runat="server" Text='<%# Eval("FD23C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD24Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O24"), Eval("�X�Ԯɶ�24"))%>' /><br>
                            <asp:Label ID="FD24BLabel" runat="server" Text='<%# showFoodType(Eval("FD24B")) %>' /><br>
                            <asp:Label ID="FD24CLabel" runat="server" Text='<%# Eval("FD24C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD25Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O25"), Eval("�X�Ԯɶ�25"))%>' /><br>
                            <asp:Label ID="FD25BLabel" runat="server" Text='<%# showFoodType(Eval("FD25B")) %>' /><br>
                            <asp:Label ID="FD25CLabel" runat="server" Text='<%# Eval("FD25C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD26Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O26"), Eval("�X�Ԯɶ�26"))%>' /><br>
                            <asp:Label ID="FD26BLabel" runat="server" Text='<%# showFoodType(Eval("FD26B")) %>' /><br>
                            <asp:Label ID="FD26CLabel" runat="server" Text='<%# Eval("FD26C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD27Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O27"), Eval("�X�Ԯɶ�27"))%>' /><br>
                            <asp:Label ID="FD27BLabel" runat="server" Text='<%# showFoodType(Eval("FD27B")) %>' /><br>
                            <asp:Label ID="FD27CLabel" runat="server" Text='<%# Eval("FD27C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD28Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O28"), Eval("�X�Ԯɶ�28"))%>' /><br>
                            <asp:Label ID="FD28BLabel" runat="server" Text='<%# showFoodType(Eval("FD28B")) %>' /><br>
                            <asp:Label ID="FD28CLabel" runat="server" Text='<%# Eval("FD28C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD29Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O29"), Eval("�X�Ԯɶ�29"))%>' /><br>
                            <asp:Label ID="FD29BLabel" runat="server" Text='<%# showFoodType(Eval("FD29B")) %>' /><br>
                            <asp:Label ID="FD29CLabel" runat="server" Text='<%# Eval("FD29C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD30Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O30"), Eval("�X�Ԯɶ�30"))%>' /><br>
                            <asp:Label ID="FD30BLabel" runat="server" Text='<%# showFoodType(Eval("FD30B")) %>' /><br>
                            <asp:Label ID="FD30CLabel" runat="server" Text='<%# Eval("FD30C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD31Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O31"), Eval("�X�Ԯɶ�31"))%>' /><br>
                            <asp:Label ID="FD31BLabel" runat="server" Text='<%# showFoodType(Eval("FD31B")) %>' /><br>
                            <asp:Label ID="FD31CLabel" runat="server" Text='<%# Eval("FD31C") %>' />
                        </td>

                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #008A8C; color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="��s" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="����" />
                        </td>
                        <td>
                            <asp:Label ID="FD001TextBox" runat="server" Text='<%# Bind("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Bind("CDBMemberName")%>' />
                        </td>
                        <td>
                            <asp:Label ID="FD002TextBox" runat="server" Text='<%# Bind("FD002") %>' />
                        </td>

                        <td style ="width :500px;">
                            <asp:Label ID="FD00Label" runat="server" Text="�X��" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="���\" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="���\" />
                        </td>

                        <td>
                            <asp:Label ID="FD01Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O01"), Eval("�X�Ԯɶ�01"))%>' /><br>
                            <asp:TextBox ID="FD01BTextBox" runat="server" Text='<%# Eval("FD01B") %>' /><br>
                            <asp:TextBox ID="FD01CTextBox" runat="server" Text='<%# Eval("FD01C") %>' />


                            <asp:DropDownList ID="ddFD01B" runat="server"/><br>
                            <asp:DropDownList ID="ddFD01C" runat="server"/>

                        </td>
                        <td>
                            <asp:Label ID="FD02Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O02"), Eval("�X�Ԯɶ�02"))%>' /><br>
                            <asp:TextBox ID="FD02BTextBox" runat="server" Text='<%# Eval("FD02B") %>' /><br>
                            <asp:TextBox ID="FD02CTextBox" runat="server" Text='<%# Eval("FD02C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD03Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O03"), Eval("�X�Ԯɶ�03"))%>' /><br>
                            <asp:TextBox ID="FD03BTextBox" runat="server" Text='<%# Eval("FD03B") %>' /><br>
                            <asp:TextBox ID="FD03CTextBox" runat="server" Text='<%# Eval("FD03C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD04Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O04"), Eval("�X�Ԯɶ�04"))%>' /><br>
                            <asp:TextBox ID="FD04BTextBox" runat="server" Text='<%# Eval("FD04B") %>' /><br>
                            <asp:TextBox ID="FD04CTextBox" runat="server" Text='<%# Eval("FD04C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD05Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O05"), Eval("�X�Ԯɶ�05"))%>' /><br>
                            <asp:TextBox ID="FD05BTextBox" runat="server" Text='<%# Eval("FD05B") %>' /><br>
                            <asp:TextBox ID="FD05CTextBox" runat="server" Text='<%# Eval("FD05C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD06Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O06"), Eval("�X�Ԯɶ�06"))%>' /><br>
                            <asp:TextBox ID="FD06BTextBox" runat="server" Text='<%# Eval("FD06B") %>' /><br>
                            <asp:TextBox ID="FD06CTextBox" runat="server" Text='<%# Eval("FD06C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD07Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O07"), Eval("�X�Ԯɶ�07"))%>' /><br>
                            <asp:TextBox ID="FD07BTextBox" runat="server" Text='<%# Eval("FD07B") %>' /><br>
                            <asp:TextBox ID="FD07CTextBox" runat="server" Text='<%# Eval("FD07C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD08Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O08"), Eval("�X�Ԯɶ�08"))%>' /><br>
                            <asp:TextBox ID="FD08BTextBox" runat="server" Text='<%# Eval("FD08B") %>' /><br>
                            <asp:TextBox ID="FD08CTextBox" runat="server" Text='<%# Eval("FD08C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD09Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O09"), Eval("�X�Ԯɶ�09"))%>' /><br>
                            <asp:TextBox ID="FD09BTextBox" runat="server" Text='<%# Eval("FD09B") %>' /><br>
                            <asp:TextBox ID="FD09CTextBox" runat="server" Text='<%# Eval("FD09C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD10Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O10"), Eval("�X�Ԯɶ�10"))%>' /><br>
                            <asp:TextBox ID="FD10BTextBox" runat="server" Text='<%# Eval("FD10B") %>' /><br>
                            <asp:TextBox ID="FD10CTextBox" runat="server" Text='<%# Eval("FD10C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD11Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O11"), Eval("�X�Ԯɶ�11"))%>' /><br>
                            <asp:TextBox ID="FD11BTextBox" runat="server" Text='<%# Eval("FD11B") %>' /><br>
                            <asp:TextBox ID="FD11CTextBox" runat="server" Text='<%# Eval("FD11C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD12Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O12"), Eval("�X�Ԯɶ�12"))%>' /><br>
                            <asp:TextBox ID="FD12BTextBox" runat="server" Text='<%# Eval("FD12B") %>' /><br>
                            <asp:TextBox ID="FD12CTextBox" runat="server" Text='<%# Eval("FD12C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD13Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O13"), Eval("�X�Ԯɶ�13"))%>' /><br>
                            <asp:TextBox ID="FD13BTextBox" runat="server" Text='<%# Eval("FD13B") %>' /><br>
                            <asp:TextBox ID="FD13CTextBox" runat="server" Text='<%# Eval("FD13C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD14Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O14"), Eval("�X�Ԯɶ�14"))%>' /><br>
                            <asp:TextBox ID="FD14BTextBox" runat="server" Text='<%# Eval("FD14B") %>' /><br>
                            <asp:TextBox ID="FD14CTextBox" runat="server" Text='<%# Eval("FD14C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD15Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O15"), Eval("�X�Ԯɶ�15"))%>' /><br>
                            <asp:TextBox ID="FD15BTextBox" runat="server" Text='<%# Eval("FD15B") %>' /><br>
                            <asp:TextBox ID="FD15CTextBox" runat="server" Text='<%# Eval("FD15C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD16Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O16"), Eval("�X�Ԯɶ�16"))%>' /><br>
                            <asp:TextBox ID="FD16BTextBox" runat="server" Text='<%# Eval("FD16B") %>' /><br>
                            <asp:TextBox ID="FD16CTextBox" runat="server" Text='<%# Eval("FD16C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD17Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O17"), Eval("�X�Ԯɶ�17"))%>' /><br>
                            <asp:TextBox ID="FD17BTextBox" runat="server" Text='<%# Eval("FD17B") %>' /><br>
                            <asp:TextBox ID="FD17CTextBox" runat="server" Text='<%# Eval("FD17C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD18Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O18"), Eval("�X�Ԯɶ�18"))%>' /><br>
                            <asp:TextBox ID="FD18BTextBox" runat="server" Text='<%# Eval("FD18B") %>' /><br>
                            <asp:TextBox ID="FD18CTextBox" runat="server" Text='<%# Eval("FD18C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD19Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O19"), Eval("�X�Ԯɶ�19"))%>' /><br>
                            <asp:TextBox ID="FD19BTextBox" runat="server" Text='<%# Eval("FD19B") %>' /><br>
                            <asp:TextBox ID="FD19CTextBox" runat="server" Text='<%# Eval("FD19C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD20Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O20"), Eval("�X�Ԯɶ�20"))%>' /><br>
                            <asp:TextBox ID="FD20BTextBox" runat="server" Text='<%# Eval("FD20B") %>' /><br>
                            <asp:TextBox ID="FD20CTextBox" runat="server" Text='<%# Eval("FD20C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD21Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O21"), Eval("�X�Ԯɶ�21"))%>' /><br>
                            <asp:TextBox ID="FD21BTextBox" runat="server" Text='<%# Eval("FD21B") %>' /><br>
                            <asp:TextBox ID="FD21CTextBox" runat="server" Text='<%# Eval("FD21C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD22Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O22"), Eval("�X�Ԯɶ�22"))%>' /><br>
                            <asp:TextBox ID="FD22BTextBox" runat="server" Text='<%# Eval("FD22B") %>' /><br>
                            <asp:TextBox ID="FD22CTextBox" runat="server" Text='<%# Eval("FD22C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD23Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O23"), Eval("�X�Ԯɶ�23"))%>' /><br>
                            <asp:TextBox ID="FD23BTextBox" runat="server" Text='<%# Eval("FD23B") %>' /><br>
                            <asp:TextBox ID="FD23CTextBox" runat="server" Text='<%# Eval("FD23C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD24Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O24"), Eval("�X�Ԯɶ�24"))%>' /><br>
                            <asp:TextBox ID="FD24BTextBox" runat="server" Text='<%# Eval("FD24B") %>' /><br>
                            <asp:TextBox ID="FD24CTextBox" runat="server" Text='<%# Eval("FD24C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD25Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O25"), Eval("�X�Ԯɶ�25"))%>' /><br>
                            <asp:TextBox ID="FD25BTextBox" runat="server" Text='<%# Eval("FD25B") %>' /><br>
                            <asp:TextBox ID="FD25CTextBox" runat="server" Text='<%# Eval("FD25C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD26Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O26"), Eval("�X�Ԯɶ�26"))%>' /><br>
                            <asp:TextBox ID="FD26BTextBox" runat="server" Text='<%# Eval("FD26B") %>' /><br>
                            <asp:TextBox ID="FD26CTextBox" runat="server" Text='<%# Eval("FD26C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD27Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O27"), Eval("�X�Ԯɶ�27"))%>' /><br>
                            <asp:TextBox ID="FD27BTextBox" runat="server" Text='<%# Eval("FD27B") %>' /><br>
                            <asp:TextBox ID="FD27CTextBox" runat="server" Text='<%# Eval("FD27C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD28Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O28"), Eval("�X�Ԯɶ�28"))%>' /><br>
                            <asp:TextBox ID="FD28BTextBox" runat="server" Text='<%# Eval("FD28B") %>' /><br>
                            <asp:TextBox ID="FD28CTextBox" runat="server" Text='<%# Eval("FD28C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD29Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O29"), Eval("�X�Ԯɶ�29"))%>' /><br>
                            <asp:TextBox ID="FD29BTextBox" runat="server" Text='<%# Eval("FD29B") %>' /><br>
                            <asp:TextBox ID="FD29CTextBox" runat="server" Text='<%# Eval("FD29C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD30Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O30"), Eval("�X�Ԯɶ�30"))%>' /><br>
                            <asp:TextBox ID="FD30BTextBox" runat="server" Text='<%# Eval("FD30B") %>' /><br>
                            <asp:TextBox ID="FD30CTextBox" runat="server" Text='<%# Eval("FD30C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD31Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O31"), Eval("�X�Ԯɶ�31"))%>' /><br>
                            <asp:TextBox ID="FD31BTextBox" runat="server" Text='<%# Eval("FD31B") %>' /><br>
                            <asp:TextBox ID="FD31CTextBox" runat="server" Text='<%# Eval("FD31C") %>' />
                        </td>

                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>���Ǧ^��ơC</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="���J" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="�M��" />
                        </td>
                        <td>
                            <asp:TextBox ID="FD001TextBox" runat="server" Text='<%# Bind("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Bind("CDBMemberName")%>' />
                        </td>
                        <td>
                            <asp:TextBox ID="FD002TextBox" runat="server" Text='<%# Bind("FD002") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD00Label" runat="server" Text="�X��" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="���\" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="���\" />
                        </td>
                        <td>
                            <asp:Label ID="FD01Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O01"), Eval("�X�Ԯɶ�01"))%>' /><br>
                            "
                            <asp:TextBox ID="FD01BTextBox" runat="server" Text='<%# Bind("FD01B") %>' /><br>
                            <asp:TextBox ID="FD01CTextBox" runat="server" Text='<%# Bind("FD01C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD02Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O02"), Eval("�X�Ԯɶ�02"))%>' /><br>
                            "
                            <asp:TextBox ID="FD02BTextBox" runat="server" Text='<%# Bind("FD02B") %>' /><br>
                            <asp:TextBox ID="FD02CTextBox" runat="server" Text='<%# Bind("FD02C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD03Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O03"), Eval("�X�Ԯɶ�03"))%>' /><br>
                            "
                            <asp:TextBox ID="FD03BTextBox" runat="server" Text='<%# Bind("FD03B") %>' /><br>
                            <asp:TextBox ID="FD03CTextBox" runat="server" Text='<%# Bind("FD03C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD04Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O04"), Eval("�X�Ԯɶ�04"))%>' /><br>
                            "
                            <asp:TextBox ID="FD04BTextBox" runat="server" Text='<%# Bind("FD04B") %>' /><br>
                            <asp:TextBox ID="FD04CTextBox" runat="server" Text='<%# Bind("FD04C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD05Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O05"), Eval("�X�Ԯɶ�05"))%>' /><br>
                            "
                            <asp:TextBox ID="FD05BTextBox" runat="server" Text='<%# Bind("FD05B") %>' /><br>
                            <asp:TextBox ID="FD05CTextBox" runat="server" Text='<%# Bind("FD05C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD06Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O06"), Eval("�X�Ԯɶ�06"))%>' /><br>
                            "
                            <asp:TextBox ID="FD06BTextBox" runat="server" Text='<%# Bind("FD06B") %>' /><br>
                            <asp:TextBox ID="FD06CTextBox" runat="server" Text='<%# Bind("FD06C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD07Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O07"), Eval("�X�Ԯɶ�07"))%>' /><br>
                            "
                            <asp:TextBox ID="FD07BTextBox" runat="server" Text='<%# Bind("FD07B") %>' /><br>
                            <asp:TextBox ID="FD07CTextBox" runat="server" Text='<%# Bind("FD07C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD08Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O08"), Eval("�X�Ԯɶ�08"))%>' /><br>
                            "
                            <asp:TextBox ID="FD08BTextBox" runat="server" Text='<%# Bind("FD08B") %>' /><br>
                            <asp:TextBox ID="FD08CTextBox" runat="server" Text='<%# Bind("FD08C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD09Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O09"), Eval("�X�Ԯɶ�09"))%>' /><br>
                            "
                            <asp:TextBox ID="FD09BTextBox" runat="server" Text='<%# Bind("FD09B") %>' /><br>
                            <asp:TextBox ID="FD09CTextBox" runat="server" Text='<%# Bind("FD09C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD10Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O10"), Eval("�X�Ԯɶ�10"))%>' /><br>
                            "
                            <asp:TextBox ID="FD10BTextBox" runat="server" Text='<%# Bind("FD10B") %>' /><br>
                            <asp:TextBox ID="FD10CTextBox" runat="server" Text='<%# Bind("FD10C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD11Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O11"), Eval("�X�Ԯɶ�11"))%>' /><br>
                            "
                            <asp:TextBox ID="FD11BTextBox" runat="server" Text='<%# Bind("FD11B") %>' /><br>
                            <asp:TextBox ID="FD11CTextBox" runat="server" Text='<%# Bind("FD11C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD12Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O12"), Eval("�X�Ԯɶ�12"))%>' /><br>
                            "
                            <asp:TextBox ID="FD12BTextBox" runat="server" Text='<%# Bind("FD12B") %>' /><br>
                            <asp:TextBox ID="FD12CTextBox" runat="server" Text='<%# Bind("FD12C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD13Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O13"), Eval("�X�Ԯɶ�13"))%>' /><br>
                            "
                            <asp:TextBox ID="FD13BTextBox" runat="server" Text='<%# Bind("FD13B") %>' /><br>
                            <asp:TextBox ID="FD13CTextBox" runat="server" Text='<%# Bind("FD13C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD14Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O14"), Eval("�X�Ԯɶ�14"))%>' /><br>
                            "
                            <asp:TextBox ID="FD14BTextBox" runat="server" Text='<%# Bind("FD14B") %>' /><br>
                            <asp:TextBox ID="FD14CTextBox" runat="server" Text='<%# Bind("FD14C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD15Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O15"), Eval("�X�Ԯɶ�15"))%>' /><br>
                            "
                            <asp:TextBox ID="FD15BTextBox" runat="server" Text='<%# Bind("FD15B") %>' /><br>
                            <asp:TextBox ID="FD15CTextBox" runat="server" Text='<%# Bind("FD15C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD16Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O16"), Eval("�X�Ԯɶ�16"))%>' /><br>
                            "
                            <asp:TextBox ID="FD16BTextBox" runat="server" Text='<%# Bind("FD16B") %>' /><br>
                            <asp:TextBox ID="FD16CTextBox" runat="server" Text='<%# Bind("FD16C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD17Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O17"), Eval("�X�Ԯɶ�17"))%>' /><br>
                            "
                            <asp:TextBox ID="FD17BTextBox" runat="server" Text='<%# Bind("FD17B") %>' /><br>
                            <asp:TextBox ID="FD17CTextBox" runat="server" Text='<%# Bind("FD17C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD18Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O18"), Eval("�X�Ԯɶ�18"))%>' /><br>
                            "
                            <asp:TextBox ID="FD18BTextBox" runat="server" Text='<%# Bind("FD18B") %>' /><br>
                            <asp:TextBox ID="FD18CTextBox" runat="server" Text='<%# Bind("FD18C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD19Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O19"), Eval("�X�Ԯɶ�19"))%>' /><br>
                            "
                            <asp:TextBox ID="FD19BTextBox" runat="server" Text='<%# Bind("FD19B") %>' /><br>
                            <asp:TextBox ID="FD19CTextBox" runat="server" Text='<%# Bind("FD19C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD20Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O20"), Eval("�X�Ԯɶ�20"))%>' /><br>
                            "
                            <asp:TextBox ID="FD20BTextBox" runat="server" Text='<%# Bind("FD20B") %>' /><br>
                            <asp:TextBox ID="FD20CTextBox" runat="server" Text='<%# Bind("FD20C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD21Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O21"), Eval("�X�Ԯɶ�21"))%>' /><br>
                            "
                            <asp:TextBox ID="FD21BTextBox" runat="server" Text='<%# Bind("FD21B") %>' /><br>
                            <asp:TextBox ID="FD21CTextBox" runat="server" Text='<%# Bind("FD21C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD22Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O22"), Eval("�X�Ԯɶ�22"))%>' /><br>
                            "
                            <asp:TextBox ID="FD22BTextBox" runat="server" Text='<%# Bind("FD22B") %>' /><br>
                            <asp:TextBox ID="FD22CTextBox" runat="server" Text='<%# Bind("FD22C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD23Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O23"), Eval("�X�Ԯɶ�23"))%>' /><br>
                            "
                            <asp:TextBox ID="FD23BTextBox" runat="server" Text='<%# Bind("FD23B") %>' /><br>
                            <asp:TextBox ID="FD23CTextBox" runat="server" Text='<%# Bind("FD23C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD24Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O24"), Eval("�X�Ԯɶ�24"))%>' /><br>
                            "
                            <asp:TextBox ID="FD24BTextBox" runat="server" Text='<%# Bind("FD24B") %>' /><br>
                            <asp:TextBox ID="FD24CTextBox" runat="server" Text='<%# Bind("FD24C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD25Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O25"), Eval("�X�Ԯɶ�25"))%>' /><br>
                            "
                            <asp:TextBox ID="FD25BTextBox" runat="server" Text='<%# Bind("FD25B") %>' /><br>
                            <asp:TextBox ID="FD25CTextBox" runat="server" Text='<%# Bind("FD25C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD26Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O26"), Eval("�X�Ԯɶ�26"))%>' /><br>
                            "
                            <asp:TextBox ID="FD26BTextBox" runat="server" Text='<%# Bind("FD26B") %>' /><br>
                            <asp:TextBox ID="FD26CTextBox" runat="server" Text='<%# Bind("FD26C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD27Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O27"), Eval("�X�Ԯɶ�27"))%>' /><br>
                            "
                            <asp:TextBox ID="FD27BTextBox" runat="server" Text='<%# Bind("FD27B") %>' /><br>
                            <asp:TextBox ID="FD27CTextBox" runat="server" Text='<%# Bind("FD27C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD28Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O28"), Eval("�X�Ԯɶ�28"))%>' /><br>
                            "
                            <asp:TextBox ID="FD28BTextBox" runat="server" Text='<%# Bind("FD28B") %>' /><br>
                            <asp:TextBox ID="FD28CTextBox" runat="server" Text='<%# Bind("FD28C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD29Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O29"), Eval("�X�Ԯɶ�29"))%>' /><br>
                            "
                            <asp:TextBox ID="FD29BTextBox" runat="server" Text='<%# Bind("FD29B") %>' /><br>
                            <asp:TextBox ID="FD29CTextBox" runat="server" Text='<%# Bind("FD29C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD30Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O30"), Eval("�X�Ԯɶ�30"))%>' /><br>
                            "
                            <asp:TextBox ID="FD30BTextBox" runat="server" Text='<%# Bind("FD30B") %>' /><br>
                            <asp:TextBox ID="FD30CTextBox" runat="server" Text='<%# Bind("FD30C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD31Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O31"), Eval("�X�Ԯɶ�31"))%>' /><br>
                            "
                            <asp:TextBox ID="FD31BTextBox" runat="server" Text='<%# Bind("FD31B") %>' /><br>
                            <asp:TextBox ID="FD31CTextBox" runat="server" Text='<%# Bind("FD31C") %>' />
                        </td>

                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="�s��" />
                        </td>
                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                        </td>
                        <td>
                            <asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") %>' />
                        </td>

                      <td>
                            <asp:Label ID="FD00Label" runat="server" Text= '<%# "�X��"%>' /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="���\" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="���\" />
                        </td>
                        <td>
                            <asp:Label ID="FD01Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O01"), Eval("�X�Ԯɶ�01"))%>' /><br>
                            <asp:Label ID="FD01BLabel" runat="server" Text='<%# showFoodType(Eval("FD01B"))%>' /><br>
                            <asp:Label ID="FD01CLabel" runat="server" Text='<%# Eval("FD01C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD02Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O02"), Eval("�X�Ԯɶ�02"))%>' /><br>
                            <asp:Label ID="FD02BLabel" runat="server" Text='<%# showFoodType(Eval("FD02B"))%>' /><br>
                            <asp:Label ID="FD02CLabel" runat="server" Text='<%# Eval("FD02C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD03Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O03"), Eval("�X�Ԯɶ�03"))%>' /><br>
                            <asp:Label ID="FD03BLabel" runat="server" Text='<%# showFoodType(Eval("FD03B"))%>' /><br>
                            <asp:Label ID="FD03CLabel" runat="server" Text='<%# Eval("FD03C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD04Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O04"), Eval("�X�Ԯɶ�04"))%>' /><br>
                            <asp:Label ID="FD04BLabel" runat="server" Text='<%# showFoodType(Eval("FD04B"))%>' /><br>
                            <asp:Label ID="FD04CLabel" runat="server" Text='<%# Eval("FD04C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD05Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O05"), Eval("�X�Ԯɶ�05"))%>' /><br>
                            <asp:Label ID="FD05BLabel" runat="server" Text='<%# showFoodType(Eval("FD05B"))%>' /><br>
                            <asp:Label ID="FD05CLabel" runat="server" Text='<%# Eval("FD05C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD06Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O06"), Eval("�X�Ԯɶ�06"))%>' /><br>
                            <asp:Label ID="FD06BLabel" runat="server" Text='<%# showFoodType(Eval("FD06B"))%>' /><br>
                            <asp:Label ID="FD06CLabel" runat="server" Text='<%# Eval("FD06C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD07Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O07"), Eval("�X�Ԯɶ�07"))%>' /><br>
                            <asp:Label ID="FD07BLabel" runat="server" Text='<%# showFoodType(Eval("FD07B"))%>' /><br>
                            <asp:Label ID="FD07CLabel" runat="server" Text='<%# Eval("FD07C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD08Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O08"), Eval("�X�Ԯɶ�08"))%>' /><br>
                            <asp:Label ID="FD08BLabel" runat="server" Text='<%# showFoodType(Eval("FD08B"))%>' /><br>
                            <asp:Label ID="FD08CLabel" runat="server" Text='<%# Eval("FD08C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD09Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O09"), Eval("�X�Ԯɶ�09"))%>' /><br>
                            <asp:Label ID="FD09BLabel" runat="server" Text='<%# showFoodType(Eval("FD09B"))%>' /><br>
                            <asp:Label ID="FD09CLabel" runat="server" Text='<%# Eval("FD09C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD10Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O10"), Eval("�X�Ԯɶ�10"))%>' /><br>
                            <asp:Label ID="FD10BLabel" runat="server" Text='<%# showFoodType(Eval("FD10B"))%>' /><br>
                            <asp:Label ID="FD10CLabel" runat="server" Text='<%# Eval("FD10C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD11Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O11"), Eval("�X�Ԯɶ�11"))%>' /><br>
                            <asp:Label ID="FD11BLabel" runat="server" Text='<%# showFoodType(Eval("FD11B"))%>' /><br>
                            <asp:Label ID="FD11CLabel" runat="server" Text='<%# Eval("FD11C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD12Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O12"), Eval("�X�Ԯɶ�12"))%>' /><br>
                            <asp:Label ID="FD12BLabel" runat="server" Text='<%# showFoodType(Eval("FD12B"))%>' /><br>
                            <asp:Label ID="FD12CLabel" runat="server" Text='<%# Eval("FD12C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD13Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O13"), Eval("�X�Ԯɶ�13"))%>' /><br>
                            <asp:Label ID="FD13BLabel" runat="server" Text='<%# showFoodType(Eval("FD13B"))%>' /><br>
                            <asp:Label ID="FD13CLabel" runat="server" Text='<%# Eval("FD13C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD14Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O14"), Eval("�X�Ԯɶ�14"))%>' /><br>
                            <asp:Label ID="FD14BLabel" runat="server" Text='<%# showFoodType(Eval("FD14B"))%>' /><br>
                            <asp:Label ID="FD14CLabel" runat="server" Text='<%# Eval("FD14C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD15Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O15"), Eval("�X�Ԯɶ�15"))%>' /><br>
                            <asp:Label ID="FD15BLabel" runat="server" Text='<%# showFoodType(Eval("FD15B"))%>' /><br>
                            <asp:Label ID="FD15CLabel" runat="server" Text='<%# Eval("FD15C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD16Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O16"), Eval("�X�Ԯɶ�16"))%>' /><br>
                            <asp:Label ID="FD16BLabel" runat="server" Text='<%# showFoodType(Eval("FD16B"))%>' /><br>
                            <asp:Label ID="FD16CLabel" runat="server" Text='<%# Eval("FD16C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD17Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O17"), Eval("�X�Ԯɶ�17"))%>' /><br>
                            <asp:Label ID="FD17BLabel" runat="server" Text='<%# showFoodType(Eval("FD17B"))%>' /><br>
                            <asp:Label ID="FD17CLabel" runat="server" Text='<%# Eval("FD17C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD18Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O18"), Eval("�X�Ԯɶ�18"))%>' /><br>
                            <asp:Label ID="FD18BLabel" runat="server" Text='<%# showFoodType(Eval("FD18B"))%>' /><br>
                            <asp:Label ID="FD18CLabel" runat="server" Text='<%# Eval("FD18C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD19Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O19"), Eval("�X�Ԯɶ�19"))%>' /><br>
                            <asp:Label ID="FD19BLabel" runat="server" Text='<%# showFoodType(Eval("FD19B"))%>' /><br>
                            <asp:Label ID="FD19CLabel" runat="server" Text='<%# Eval("FD19C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD20Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O20"), Eval("�X�Ԯɶ�20"))%>' /><br>
                            <asp:Label ID="FD20BLabel" runat="server" Text='<%# showFoodType(Eval("FD20B"))%>' /><br>
                            <asp:Label ID="FD20CLabel" runat="server" Text='<%# Eval("FD20C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD21Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O21"), Eval("�X�Ԯɶ�21"))%>' /><br>
                            <asp:Label ID="FD21BLabel" runat="server" Text='<%# showFoodType(Eval("FD21B"))%>' /><br>
                            <asp:Label ID="FD21CLabel" runat="server" Text='<%# Eval("FD21C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD22Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O22"), Eval("�X�Ԯɶ�22"))%>' /><br>
                            <asp:Label ID="FD22BLabel" runat="server" Text='<%# showFoodType(Eval("FD22B"))%>' /><br>
                            <asp:Label ID="FD22CLabel" runat="server" Text='<%# Eval("FD22C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD23Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O23"), Eval("�X�Ԯɶ�23"))%>' /><br>
                            <asp:Label ID="FD23BLabel" runat="server" Text='<%# showFoodType(Eval("FD23B"))%>' /><br>
                            <asp:Label ID="FD23CLabel" runat="server" Text='<%# Eval("FD23C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD24Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O24"), Eval("�X�Ԯɶ�24"))%>' /><br>
                            <asp:Label ID="FD24BLabel" runat="server" Text='<%# showFoodType(Eval("FD24B"))%>' /><br>
                            <asp:Label ID="FD24CLabel" runat="server" Text='<%# Eval("FD24C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD25Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O25"), Eval("�X�Ԯɶ�25"))%>' /><br>
                            <asp:Label ID="FD25BLabel" runat="server" Text='<%# showFoodType(Eval("FD25B"))%>' /><br>
                            <asp:Label ID="FD25CLabel" runat="server" Text='<%# Eval("FD25C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD26Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O26"), Eval("�X�Ԯɶ�26"))%>' /><br>
                            <asp:Label ID="FD26BLabel" runat="server" Text='<%# showFoodType(Eval("FD26B"))%>' /><br>
                            <asp:Label ID="FD26CLabel" runat="server" Text='<%# Eval("FD26C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD27Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O27"), Eval("�X�Ԯɶ�27"))%>' /><br>
                            <asp:Label ID="FD27BLabel" runat="server" Text='<%# showFoodType(Eval("FD27B"))%>' /><br>
                            <asp:Label ID="FD27CLabel" runat="server" Text='<%# Eval("FD27C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD28Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O28"), Eval("�X�Ԯɶ�28"))%>' /><br>
                            <asp:Label ID="FD28BLabel" runat="server" Text='<%# showFoodType(Eval("FD28B"))%>' /><br>
                            <asp:Label ID="FD28CLabel" runat="server" Text='<%# Eval("FD28C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD29Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O29"), Eval("�X�Ԯɶ�29"))%>' /><br>
                            <asp:Label ID="FD29BLabel" runat="server" Text='<%# showFoodType(Eval("FD29B"))%>' /><br>
                            <asp:Label ID="FD29CLabel" runat="server" Text='<%# Eval("FD29C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD30Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O30"), Eval("�X�Ԯɶ�30"))%>' /><br>
                            <asp:Label ID="FD30BLabel" runat="server" Text='<%# showFoodType(Eval("FD30B"))%>' /><br>
                            <asp:Label ID="FD30CLabel" runat="server" Text='<%# Eval("FD30C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD31Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O31"), Eval("�X�Ԯɶ�31"))%>' /><br>
                            <asp:Label ID="FD31BLabel" runat="server" Text='<%# showFoodType(Eval("FD31B"))%>' /><br>
                            <asp:Label ID="FD31CLabel" runat="server" Text='<%# Eval("FD31C") %>' />
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
                                        <th runat="server">¾�s</th>
                                        <th runat="server">�m�W<%= showSpaceChar(7)%></th>
                                        <th runat="server"><%= showSpaceChar(9)%></th>

                                        <th runat="server"><% = showDayInfo(1)%></th>
                                        <th runat="server"><% = showDayInfo(2)%></th>
                                        <th runat="server"><% = showDayInfo(3)%></th>
                                        <th runat="server"><% = showDayInfo(4)%></th>
                                        <th runat="server"><% = showDayInfo(5)%></th>
                                        <th runat="server"><% = showDayInfo(6)%></th>
                                        <th runat="server"><% = showDayInfo(7)%></th>
                                        <th runat="server"><% = showDayInfo(8)%></th>
                                        <th runat="server"><% = showDayInfo(9)%></th>
                                        <th runat="server"><% = showDayInfo(10)%></th>
                                        <th runat="server"><% = showDayInfo(11)%></th>
                                        <th runat="server"><% = showDayInfo(12)%></th>
                                        <th runat="server"><% = showDayInfo(13)%></th>
                                        <th runat="server"><% = showDayInfo(14)%></th>
                                        <th runat="server"><% = showDayInfo(15)%></th>
                                        <th runat="server"><% = showDayInfo(16)%></th>
                                        <th runat="server"><% = showDayInfo(17)%></th>
                                        <th runat="server"><% = showDayInfo(18)%></th>
                                        <th runat="server"><% = showDayInfo(19)%></th>
                                        <th runat="server"><% = showDayInfo(20)%></th>
                                        <th runat="server"><% = showDayInfo(21)%></th>
                                        <th runat="server"><% = showDayInfo(22)%></th>
                                        <th runat="server"><% = showDayInfo(23)%></th>
                                        <th runat="server"><% = showDayInfo(24)%></th>
                                        <th runat="server"><% = showDayInfo(25)%></th>
                                        <th runat="server"><% = showDayInfo(26)%></th>
                                        <th runat="server"><% = showDayInfo(27)%></th>
                                        <th runat="server"><% = showDayInfo(28)%></th>
                                        <th runat="server"><% = showDayInfo(29)%></th>
                                        <th runat="server"><% = showDayInfo(30)%></th>
                                        <th runat="server"><% = showDayInfo(31)%></th>

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
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="�s��" />
                        </td>
                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                        </td>
                        <td>
                            <asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD00Label" runat="server" Text="�X��" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="���\" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="���\" />
                        </td>

                        <td>
                            <asp:Label ID="FD01Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O01"), Eval("�X�Ԯɶ�01"))%>' /><br>
                            <asp:Label ID="FD01BLabel" runat="server" Text='<%# Eval("FD01B") %>' /><br>
                            <asp:Label ID="FD01CLabel" runat="server" Text='<%# Eval("FD01C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD02Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O02"), Eval("�X�Ԯɶ�02"))%>' /><br>
                            <asp:Label ID="FD02BLabel" runat="server" Text='<%# Eval("FD02B") %>' /><br>
                            <asp:Label ID="FD02CLabel" runat="server" Text='<%# Eval("FD02C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD03Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O03"), Eval("�X�Ԯɶ�03"))%>' /><br>
                            <asp:Label ID="FD03BLabel" runat="server" Text='<%# Eval("FD03B") %>' /><br>
                            <asp:Label ID="FD03CLabel" runat="server" Text='<%# Eval("FD03C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD04Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O04"), Eval("�X�Ԯɶ�04"))%>' /><br>
                            <asp:Label ID="FD04BLabel" runat="server" Text='<%# Eval("FD04B") %>' /><br>
                            <asp:Label ID="FD04CLabel" runat="server" Text='<%# Eval("FD04C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD05Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O05"), Eval("�X�Ԯɶ�05"))%>' /><br>
                            <asp:Label ID="FD05BLabel" runat="server" Text='<%# Eval("FD05B") %>' /><br>
                            <asp:Label ID="FD05CLabel" runat="server" Text='<%# Eval("FD05C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD06Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O06"), Eval("�X�Ԯɶ�06"))%>' /><br>
                            <asp:Label ID="FD06BLabel" runat="server" Text='<%# Eval("FD06B") %>' /><br>
                            <asp:Label ID="FD06CLabel" runat="server" Text='<%# Eval("FD06C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD07Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O07"), Eval("�X�Ԯɶ�07"))%>' /><br>
                            <asp:Label ID="FD07BLabel" runat="server" Text='<%# Eval("FD07B") %>' /><br>
                            <asp:Label ID="FD07CLabel" runat="server" Text='<%# Eval("FD07C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD08Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O08"), Eval("�X�Ԯɶ�08"))%>' /><br>
                            <asp:Label ID="FD08BLabel" runat="server" Text='<%# Eval("FD08B") %>' /><br>
                            <asp:Label ID="FD08CLabel" runat="server" Text='<%# Eval("FD08C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD09Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O09"), Eval("�X�Ԯɶ�09"))%>' /><br>
                            <asp:Label ID="FD09BLabel" runat="server" Text='<%# Eval("FD09B") %>' /><br>
                            <asp:Label ID="FD09CLabel" runat="server" Text='<%# Eval("FD09C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD10Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O10"), Eval("�X�Ԯɶ�10"))%>' /><br>
                            <asp:Label ID="FD10BLabel" runat="server" Text='<%# Eval("FD10B") %>' /><br>
                            <asp:Label ID="FD10CLabel" runat="server" Text='<%# Eval("FD10C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD11Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O11"), Eval("�X�Ԯɶ�11"))%>' /><br>
                            <asp:Label ID="FD11BLabel" runat="server" Text='<%# Eval("FD11B") %>' /><br>
                            <asp:Label ID="FD11CLabel" runat="server" Text='<%# Eval("FD11C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD12Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O12"), Eval("�X�Ԯɶ�12"))%>' /><br>
                            <asp:Label ID="FD12BLabel" runat="server" Text='<%# Eval("FD12B") %>' /><br>
                            <asp:Label ID="FD12CLabel" runat="server" Text='<%# Eval("FD12C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD13Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O13"), Eval("�X�Ԯɶ�13"))%>' /><br>
                            <asp:Label ID="FD13BLabel" runat="server" Text='<%# Eval("FD13B") %>' /><br>
                            <asp:Label ID="FD13CLabel" runat="server" Text='<%# Eval("FD13C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD14Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O14"), Eval("�X�Ԯɶ�14"))%>' /><br>
                            <asp:Label ID="FD14BLabel" runat="server" Text='<%# Eval("FD14B") %>' /><br>
                            <asp:Label ID="FD14CLabel" runat="server" Text='<%# Eval("FD14C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD15Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O15"), Eval("�X�Ԯɶ�15"))%>' /><br>
                            <asp:Label ID="FD15BLabel" runat="server" Text='<%# Eval("FD15B") %>' /><br>
                            <asp:Label ID="FD15CLabel" runat="server" Text='<%# Eval("FD15C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD16Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O16"), Eval("�X�Ԯɶ�16"))%>' /><br>
                            <asp:Label ID="FD16BLabel" runat="server" Text='<%# Eval("FD16B") %>' /><br>
                            <asp:Label ID="FD16CLabel" runat="server" Text='<%# Eval("FD16C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD17Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O17"), Eval("�X�Ԯɶ�17"))%>' /><br>
                            <asp:Label ID="FD17BLabel" runat="server" Text='<%# Eval("FD17B") %>' /><br>
                            <asp:Label ID="FD17CLabel" runat="server" Text='<%# Eval("FD17C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD18Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O18"), Eval("�X�Ԯɶ�18"))%>' /><br>
                            <asp:Label ID="FD18BLabel" runat="server" Text='<%# Eval("FD18B") %>' /><br>
                            <asp:Label ID="FD18CLabel" runat="server" Text='<%# Eval("FD18C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD19Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O19"), Eval("�X�Ԯɶ�19"))%>' /><br>
                            <asp:Label ID="FD19BLabel" runat="server" Text='<%# Eval("FD19B") %>' /><br>
                            <asp:Label ID="FD19CLabel" runat="server" Text='<%# Eval("FD19C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD20Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O20"), Eval("�X�Ԯɶ�20"))%>' /><br>
                            <asp:Label ID="FD20BLabel" runat="server" Text='<%# Eval("FD20B") %>' /><br>
                            <asp:Label ID="FD20CLabel" runat="server" Text='<%# Eval("FD20C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD21Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O21"), Eval("�X�Ԯɶ�21"))%>' /><br>
                            <asp:Label ID="FD21BLabel" runat="server" Text='<%# Eval("FD21B") %>' /><br>
                            <asp:Label ID="FD21CLabel" runat="server" Text='<%# Eval("FD21C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD22Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O22"), Eval("�X�Ԯɶ�22"))%>' /><br>
                            <asp:Label ID="FD22BLabel" runat="server" Text='<%# Eval("FD22B") %>' /><br>
                            <asp:Label ID="FD22CLabel" runat="server" Text='<%# Eval("FD22C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD23Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O23"), Eval("�X�Ԯɶ�23"))%>' /><br>
                            <asp:Label ID="FD23BLabel" runat="server" Text='<%# Eval("FD23B") %>' /><br>
                            <asp:Label ID="FD23CLabel" runat="server" Text='<%# Eval("FD23C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD24Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O24"), Eval("�X�Ԯɶ�24"))%>' /><br>
                            <asp:Label ID="FD24BLabel" runat="server" Text='<%# Eval("FD24B") %>' /><br>
                            <asp:Label ID="FD24CLabel" runat="server" Text='<%# Eval("FD24C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD25Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O25"), Eval("�X�Ԯɶ�25"))%>' /><br>
                            <asp:Label ID="FD25BLabel" runat="server" Text='<%# Eval("FD25B") %>' /><br>
                            <asp:Label ID="FD25CLabel" runat="server" Text='<%# Eval("FD25C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD26Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O26"), Eval("�X�Ԯɶ�26"))%>' /><br>
                            <asp:Label ID="FD26BLabel" runat="server" Text='<%# Eval("FD26B") %>' /><br>
                            <asp:Label ID="FD26CLabel" runat="server" Text='<%# Eval("FD26C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD27Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O27"), Eval("�X�Ԯɶ�27"))%>' /><br>
                            <asp:Label ID="FD27BLabel" runat="server" Text='<%# Eval("FD27B") %>' /><br>
                            <asp:Label ID="FD27CLabel" runat="server" Text='<%# Eval("FD27C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD28Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O28"), Eval("�X�Ԯɶ�28"))%>' /><br>
                            <asp:Label ID="FD28BLabel" runat="server" Text='<%# Eval("FD28B") %>' /><br>
                            <asp:Label ID="FD28CLabel" runat="server" Text='<%# Eval("FD28C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD29Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O29"), Eval("�X�Ԯɶ�29"))%>' /><br>
                            <asp:Label ID="FD29BLabel" runat="server" Text='<%# Eval("FD29B") %>' /><br>
                            <asp:Label ID="FD29CLabel" runat="server" Text='<%# Eval("FD29C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD30Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O30"), Eval("�X�Ԯɶ�30"))%>' /><br>
                            <asp:Label ID="FD30BLabel" runat="server" Text='<%# Eval("FD30B") %>' /><br>
                            <asp:Label ID="FD30CLabel" runat="server" Text='<%# Eval("FD30C") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FD31Label" runat="server" Text='<%# show�X�Ը��(Eval("�X�ԯZ�O31"), Eval("�X�Ԯɶ�31"))%>' /><br>
                            <asp:Label ID="FD31BLabel" runat="server" Text='<%# Eval("FD31B") %>' /><br>
                            <asp:Label ID="FD31CLabel" runat="server" Text='<%# Eval("FD31C") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>