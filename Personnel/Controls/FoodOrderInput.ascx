<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FoodOrderInput.ascx.vb" Inherits="Personnel.FoodOrderInput" %>
<%@ Import Namespace="PublicClassLibrary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .DivShowInfo {
        text-align: right;
        width: 90%;
        margin: 0px auto;
    }



    .View1-ALL {
        width: 60%;
        margin: 0px auto;
        border-style: dotted;
    }

    .View1-Left {
        width: 30%;
        height :35px;
    }

    .View1-Right {
        width: 70%;
    }



    .View2-ALL {
        width: 90%;
        margin: 0px auto;
    }

    .View2-Table2 {
        line-height: 150%;
        /*font-size:11pt;*/
        color: #333333;
        border-bottom-width: 1px;
        border-bottom-style: dashed;
        border-bottom-color: #999;
    }


    .View2-Table {
        width: 60%;
        margin: 0px auto;
        border-style: dotted;
    }

    .auto-style1 {
        width: 50%;
    }


    .auto-style2 {
        width: 30%;
    }

    .auto-style3 {
        width: 20%;
        height: 23px;
    }

    .auto-style4 {
        width: 30%;
        height: 23px;
    }


    .divCss01 {
        margin: 3px;
        width: 100%;
        border-bottom: #000000 1px dotted;
    }

    .divCss02 {
        margin: 3px;
    }



    .divCss03A {
        margin: 3px;
        width: 100%;
        text-align: center;
        /*border-bottom: #000000 1px Dashed;*/
        /*border-left: #000000 1px Solid;*/
        background-color: #DCDCDC;
    }

    .divCss03B {
        margin: 3px;
        width: 100%;
        text-align: center;
        /*border-bottom: #000000 1px Dashed;*/
        /*border-left: #000000 1px Solid;*/
        background-color: #FFF8DC;
    }



    .auto-style5 {
        height: 20px;
    }

    .auto-style6 {
        width: 30%;
        height: 20px;
        background-color: #addaff;
    }
</style>

<script lang="javascript">
    function onCalendarShown() {

        var cal = $find("calendar1");
        //Setting the default mode to month
        cal._switchMode("months", true);

        //Iterate every month Item and attach click event to it
        if (cal._monthsBody) {
            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                var row = cal._monthsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }
    }

    function onCalendarHidden() {
        var cal = $find("calendar1");
        //Iterate every month Item and remove click event from it
        if (cal._monthsBody) {
            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                var row = cal._monthsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }

    }

    function call(eventElement) {
        var target = eventElement.target;
        switch (target.mode) {
            case "month":
                var cal = $find("calendar1");
                cal._visibleDate = target.date;
                cal.set_selectedDate(target.date);
                cal._switchMonth(target.date);
                cal._blur.post(true);
                cal.raiseDateSelectionChanged();
                break;
        }
    }


</script>

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />

<div class="DivShowInfo">
    <asp:LinkButton ID="linkBtnLoginInfo" runat="server"></asp:LinkButton><br />
    <br />
</div>


<asp:MultiView ID="MultiView1" runat="server">

    <asp:View ID="View1" runat="server">

        <table class="View1-ALL">
            <tr>
                <td class="View1-Left" colspan="2"><strong>EIP登入</strong></td>
            </tr>
            <tr>
                <td class="View1-Left">職編：</td>
                <td class="View1-Right">
                    <asp:TextBox ID="txtLoginUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="View1-Left">密碼：</td>
                <td class="View1-Right">
                    <asp:TextBox ID="txtLoginPW" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="View1-Left">&nbsp;</td>
                <td class="View1-Right">
                    <asp:Button ID="btnLoginOK" runat="server" Text="登入" Style="height: 50px; width :100px" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnLoginCancel" runat="server" Text="取消" Style="height: 50px; width :100px" />
                </td>
            </tr>
            <tr>
                <td class="View1-Left">&nbsp;</td>
                <td class="View1-Right">
                    <asp:Label ID="lbLoginMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>


    </asp:View>


    <asp:View ID="View2" runat="server">
        <table class="View2-Table">
            <tr>
                <td>年月：
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtQueryDateEEE" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtQueryDateYYYY" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtQueryDateYYYY_CalendarExtender" runat="server" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" BehaviorID="calendar1"
                        Enabled="True" TargetControlID="txtQueryDateYYYY" Format="yyyy/MM">
                    </cc1:CalendarExtender>
                </td>
                <td class="auto-style2" rowspan="5">
                    <asp:Button ID="btnSearch" runat="server" Height="50px" Text="查詢" Width="100%" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">單位代號：
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddUnit_Search" runat="server" Width="100%" />
                </td>

            </tr>
            <tr>
                <td>職編：
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtQueryID" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>權限：</td>
                <td class="auto-style1">
                    <asp:Label ID="lbLoginUserType" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    <asp:CustomValidator ID="cvQueryFood" runat="server" ErrorMessage="驗證查詢Food是否有輸入條件"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td></td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>截止時間：</td>
                <td class="auto-style1">午餐：<asp:Label ID="lbLimitTimeB" runat="server" Text="00:00"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 晚餐：<asp:Label ID="lbLimitTimeC" runat="server" Text="00:00"></asp:Label>
                    <br />
                </td>
                <td></td>
            </tr>

            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">假日：前一工作日<asp:Label ID="lbLimitTimeHoliday" runat="server" Text="00:00"></asp:Label>
                </td>
                <td class="auto-style5"></td>
            </tr>

        </table>

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" AutoPostBack="True" CssClass="ajax__myTab">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>訂餐輸入</HeaderTemplate>

                <ContentTemplate>

                    <%--FoodOrderInputForm_Excel產生ListView程式碼.xlsm ------------------------------------------------------------------------------%>
                    <%--Excel檔產生 Start ------------------------------------------------------------------------------%>


<asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataKeyNames="FD001" DataSourceID="odsSearchResult">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯"  Enabled ='<%# showThisMonthCanEdit(Eval("FDTIM1"), Eval("FDTIM2")) %>'/>
                        </td>

                        <td>
                            <asp:Label ID="FD005Label" runat="server" Text='<%# Eval("FD005") %>' />
                            <BR><asp:Label ID="FD004Label" runat="server" Text='<%# Eval("FD004") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                            <BR><asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") + ModTools.showSpace(4) %>' />
                            <BR><asp:Label ID="FDLastFoodLabel" runat="server" Text='<%#  show上個月訂購餐別( Eval("上個月訂購餐別") )  %>' />
                        </td>

                        <td>
                            <asp:Label ID="FDSaveInfoLabel" runat="server" Text='<%# showSaveInfo(Eval("FDSDTE"), Eval("FDSTIM"), Eval("FDSDEV"), Eval("FDSOPR") ) %>' />
                        </td>

                        <td>
                            
                        </td>

                        <td>
                            <div id='id00' class='divCss01'><asp:Label ID="FD00Label" runat="server" Text="出勤" /></div >
                            <div id='id00B' class='divCss01'><asp:Label ID="FD00BLabel" runat="server" Text="午餐" /></div >
                            <div id='id00C' class='divCss02'><asp:Label ID="FD00CLabel" runat="server" Text="晚餐" /></div >
                        </td>

                        <td <%#  showHolidayColor(01)%>>
                            <div id='id01' class='divCss01'>
                                      <asp:Label ID="FD01KindLabel" runat="server" Text='<%#  Eval("出勤班別01")%>'  Visible ="false" />
                                      <asp:Label ID="FD01TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間01"))%>' />
                             </div >
                            <div id='id01B' class='divCss01'><asp:Label ID="FD01BLabel" runat="server" Text='<%# showFoodType(Eval("FD01B")) %>' /></div >
                            <div id='id01C' class='divCss02'><asp:Label ID="FD01CLabel" runat="server" Text='<%# showFoodType(Eval("FD01C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(02)%>>
                            <div id='id02' class='divCss01'>
                                      <asp:Label ID="FD02KindLabel" runat="server" Text='<%#  Eval("出勤班別02")%>'  Visible ="false" />
                                      <asp:Label ID="FD02TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間02"))%>' />
                             </div >
                            <div id='id02B' class='divCss01'><asp:Label ID="FD02BLabel" runat="server" Text='<%# showFoodType(Eval("FD02B")) %>' /></div >
                            <div id='id02C' class='divCss02'><asp:Label ID="FD02CLabel" runat="server" Text='<%# showFoodType(Eval("FD02C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(03)%>>
                            <div id='id03' class='divCss01'>
                                      <asp:Label ID="FD03KindLabel" runat="server" Text='<%#  Eval("出勤班別03")%>'  Visible ="false" />
                                      <asp:Label ID="FD03TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間03"))%>' />
                             </div >
                            <div id='id03B' class='divCss01'><asp:Label ID="FD03BLabel" runat="server" Text='<%# showFoodType(Eval("FD03B")) %>' /></div >
                            <div id='id03C' class='divCss02'><asp:Label ID="FD03CLabel" runat="server" Text='<%# showFoodType(Eval("FD03C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(04)%>>
                            <div id='id04' class='divCss01'>
                                      <asp:Label ID="FD04KindLabel" runat="server" Text='<%#  Eval("出勤班別04")%>'  Visible ="false" />
                                      <asp:Label ID="FD04TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間04"))%>' />
                             </div >
                            <div id='id04B' class='divCss01'><asp:Label ID="FD04BLabel" runat="server" Text='<%# showFoodType(Eval("FD04B")) %>' /></div >
                            <div id='id04C' class='divCss02'><asp:Label ID="FD04CLabel" runat="server" Text='<%# showFoodType(Eval("FD04C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(05)%>>
                            <div id='id05' class='divCss01'>
                                      <asp:Label ID="FD05KindLabel" runat="server" Text='<%#  Eval("出勤班別05")%>'  Visible ="false" />
                                      <asp:Label ID="FD05TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間05"))%>' />
                             </div >
                            <div id='id05B' class='divCss01'><asp:Label ID="FD05BLabel" runat="server" Text='<%# showFoodType(Eval("FD05B")) %>' /></div >
                            <div id='id05C' class='divCss02'><asp:Label ID="FD05CLabel" runat="server" Text='<%# showFoodType(Eval("FD05C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(06)%>>
                            <div id='id06' class='divCss01'>
                                      <asp:Label ID="FD06KindLabel" runat="server" Text='<%#  Eval("出勤班別06")%>'  Visible ="false" />
                                      <asp:Label ID="FD06TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間06"))%>' />
                             </div >
                            <div id='id06B' class='divCss01'><asp:Label ID="FD06BLabel" runat="server" Text='<%# showFoodType(Eval("FD06B")) %>' /></div >
                            <div id='id06C' class='divCss02'><asp:Label ID="FD06CLabel" runat="server" Text='<%# showFoodType(Eval("FD06C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(07)%>>
                            <div id='id07' class='divCss01'>
                                      <asp:Label ID="FD07KindLabel" runat="server" Text='<%#  Eval("出勤班別07")%>'  Visible ="false" />
                                      <asp:Label ID="FD07TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間07"))%>' />
                             </div >
                            <div id='id07B' class='divCss01'><asp:Label ID="FD07BLabel" runat="server" Text='<%# showFoodType(Eval("FD07B")) %>' /></div >
                            <div id='id07C' class='divCss02'><asp:Label ID="FD07CLabel" runat="server" Text='<%# showFoodType(Eval("FD07C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(08)%>>
                            <div id='id08' class='divCss01'>
                                      <asp:Label ID="FD08KindLabel" runat="server" Text='<%#  Eval("出勤班別08")%>'  Visible ="false" />
                                      <asp:Label ID="FD08TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間08"))%>' />
                             </div >
                            <div id='id08B' class='divCss01'><asp:Label ID="FD08BLabel" runat="server" Text='<%# showFoodType(Eval("FD08B")) %>' /></div >
                            <div id='id08C' class='divCss02'><asp:Label ID="FD08CLabel" runat="server" Text='<%# showFoodType(Eval("FD08C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(09)%>>
                            <div id='id09' class='divCss01'>
                                      <asp:Label ID="FD09KindLabel" runat="server" Text='<%#  Eval("出勤班別09")%>'  Visible ="false" />
                                      <asp:Label ID="FD09TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間09"))%>' />
                             </div >
                            <div id='id09B' class='divCss01'><asp:Label ID="FD09BLabel" runat="server" Text='<%# showFoodType(Eval("FD09B")) %>' /></div >
                            <div id='id09C' class='divCss02'><asp:Label ID="FD09CLabel" runat="server" Text='<%# showFoodType(Eval("FD09C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(10)%>>
                            <div id='id10' class='divCss01'>
                                      <asp:Label ID="FD10KindLabel" runat="server" Text='<%#  Eval("出勤班別10")%>'  Visible ="false" />
                                      <asp:Label ID="FD10TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間10"))%>' />
                             </div >
                            <div id='id10B' class='divCss01'><asp:Label ID="FD10BLabel" runat="server" Text='<%# showFoodType(Eval("FD10B")) %>' /></div >
                            <div id='id10C' class='divCss02'><asp:Label ID="FD10CLabel" runat="server" Text='<%# showFoodType(Eval("FD10C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(11)%>>
                            <div id='id11' class='divCss01'>
                                      <asp:Label ID="FD11KindLabel" runat="server" Text='<%#  Eval("出勤班別11")%>'  Visible ="false" />
                                      <asp:Label ID="FD11TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間11"))%>' />
                             </div >
                            <div id='id11B' class='divCss01'><asp:Label ID="FD11BLabel" runat="server" Text='<%# showFoodType(Eval("FD11B")) %>' /></div >
                            <div id='id11C' class='divCss02'><asp:Label ID="FD11CLabel" runat="server" Text='<%# showFoodType(Eval("FD11C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(12)%>>
                            <div id='id12' class='divCss01'>
                                      <asp:Label ID="FD12KindLabel" runat="server" Text='<%#  Eval("出勤班別12")%>'  Visible ="false" />
                                      <asp:Label ID="FD12TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間12"))%>' />
                             </div >
                            <div id='id12B' class='divCss01'><asp:Label ID="FD12BLabel" runat="server" Text='<%# showFoodType(Eval("FD12B")) %>' /></div >
                            <div id='id12C' class='divCss02'><asp:Label ID="FD12CLabel" runat="server" Text='<%# showFoodType(Eval("FD12C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(13)%>>
                            <div id='id13' class='divCss01'>
                                      <asp:Label ID="FD13KindLabel" runat="server" Text='<%#  Eval("出勤班別13")%>'  Visible ="false" />
                                      <asp:Label ID="FD13TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間13"))%>' />
                             </div >
                            <div id='id13B' class='divCss01'><asp:Label ID="FD13BLabel" runat="server" Text='<%# showFoodType(Eval("FD13B")) %>' /></div >
                            <div id='id13C' class='divCss02'><asp:Label ID="FD13CLabel" runat="server" Text='<%# showFoodType(Eval("FD13C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(14)%>>
                            <div id='id14' class='divCss01'>
                                      <asp:Label ID="FD14KindLabel" runat="server" Text='<%#  Eval("出勤班別14")%>'  Visible ="false" />
                                      <asp:Label ID="FD14TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間14"))%>' />
                             </div >
                            <div id='id14B' class='divCss01'><asp:Label ID="FD14BLabel" runat="server" Text='<%# showFoodType(Eval("FD14B")) %>' /></div >
                            <div id='id14C' class='divCss02'><asp:Label ID="FD14CLabel" runat="server" Text='<%# showFoodType(Eval("FD14C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(15)%>>
                            <div id='id15' class='divCss01'>
                                      <asp:Label ID="FD15KindLabel" runat="server" Text='<%#  Eval("出勤班別15")%>'  Visible ="false" />
                                      <asp:Label ID="FD15TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間15"))%>' />
                             </div >
                            <div id='id15B' class='divCss01'><asp:Label ID="FD15BLabel" runat="server" Text='<%# showFoodType(Eval("FD15B")) %>' /></div >
                            <div id='id15C' class='divCss02'><asp:Label ID="FD15CLabel" runat="server" Text='<%# showFoodType(Eval("FD15C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(16)%>>
                            <div id='id16' class='divCss01'>
                                      <asp:Label ID="FD16KindLabel" runat="server" Text='<%#  Eval("出勤班別16")%>'  Visible ="false" />
                                      <asp:Label ID="FD16TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間16"))%>' />
                             </div >
                            <div id='id16B' class='divCss01'><asp:Label ID="FD16BLabel" runat="server" Text='<%# showFoodType(Eval("FD16B")) %>' /></div >
                            <div id='id16C' class='divCss02'><asp:Label ID="FD16CLabel" runat="server" Text='<%# showFoodType(Eval("FD16C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(17)%>>
                            <div id='id17' class='divCss01'>
                                      <asp:Label ID="FD17KindLabel" runat="server" Text='<%#  Eval("出勤班別17")%>'  Visible ="false" />
                                      <asp:Label ID="FD17TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間17"))%>' />
                             </div >
                            <div id='id17B' class='divCss01'><asp:Label ID="FD17BLabel" runat="server" Text='<%# showFoodType(Eval("FD17B")) %>' /></div >
                            <div id='id17C' class='divCss02'><asp:Label ID="FD17CLabel" runat="server" Text='<%# showFoodType(Eval("FD17C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(18)%>>
                            <div id='id18' class='divCss01'>
                                      <asp:Label ID="FD18KindLabel" runat="server" Text='<%#  Eval("出勤班別18")%>'  Visible ="false" />
                                      <asp:Label ID="FD18TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間18"))%>' />
                             </div >
                            <div id='id18B' class='divCss01'><asp:Label ID="FD18BLabel" runat="server" Text='<%# showFoodType(Eval("FD18B")) %>' /></div >
                            <div id='id18C' class='divCss02'><asp:Label ID="FD18CLabel" runat="server" Text='<%# showFoodType(Eval("FD18C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(19)%>>
                            <div id='id19' class='divCss01'>
                                      <asp:Label ID="FD19KindLabel" runat="server" Text='<%#  Eval("出勤班別19")%>'  Visible ="false" />
                                      <asp:Label ID="FD19TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間19"))%>' />
                             </div >
                            <div id='id19B' class='divCss01'><asp:Label ID="FD19BLabel" runat="server" Text='<%# showFoodType(Eval("FD19B")) %>' /></div >
                            <div id='id19C' class='divCss02'><asp:Label ID="FD19CLabel" runat="server" Text='<%# showFoodType(Eval("FD19C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(20)%>>
                            <div id='id20' class='divCss01'>
                                      <asp:Label ID="FD20KindLabel" runat="server" Text='<%#  Eval("出勤班別20")%>'  Visible ="false" />
                                      <asp:Label ID="FD20TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間20"))%>' />
                             </div >
                            <div id='id20B' class='divCss01'><asp:Label ID="FD20BLabel" runat="server" Text='<%# showFoodType(Eval("FD20B")) %>' /></div >
                            <div id='id20C' class='divCss02'><asp:Label ID="FD20CLabel" runat="server" Text='<%# showFoodType(Eval("FD20C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(21)%>>
                            <div id='id21' class='divCss01'>
                                      <asp:Label ID="FD21KindLabel" runat="server" Text='<%#  Eval("出勤班別21")%>'  Visible ="false" />
                                      <asp:Label ID="FD21TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間21"))%>' />
                             </div >
                            <div id='id21B' class='divCss01'><asp:Label ID="FD21BLabel" runat="server" Text='<%# showFoodType(Eval("FD21B")) %>' /></div >
                            <div id='id21C' class='divCss02'><asp:Label ID="FD21CLabel" runat="server" Text='<%# showFoodType(Eval("FD21C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(22)%>>
                            <div id='id22' class='divCss01'>
                                      <asp:Label ID="FD22KindLabel" runat="server" Text='<%#  Eval("出勤班別22")%>'  Visible ="false" />
                                      <asp:Label ID="FD22TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間22"))%>' />
                             </div >
                            <div id='id22B' class='divCss01'><asp:Label ID="FD22BLabel" runat="server" Text='<%# showFoodType(Eval("FD22B")) %>' /></div >
                            <div id='id22C' class='divCss02'><asp:Label ID="FD22CLabel" runat="server" Text='<%# showFoodType(Eval("FD22C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(23)%>>
                            <div id='id23' class='divCss01'>
                                      <asp:Label ID="FD23KindLabel" runat="server" Text='<%#  Eval("出勤班別23")%>'  Visible ="false" />
                                      <asp:Label ID="FD23TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間23"))%>' />
                             </div >
                            <div id='id23B' class='divCss01'><asp:Label ID="FD23BLabel" runat="server" Text='<%# showFoodType(Eval("FD23B")) %>' /></div >
                            <div id='id23C' class='divCss02'><asp:Label ID="FD23CLabel" runat="server" Text='<%# showFoodType(Eval("FD23C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(24)%>>
                            <div id='id24' class='divCss01'>
                                      <asp:Label ID="FD24KindLabel" runat="server" Text='<%#  Eval("出勤班別24")%>'  Visible ="false" />
                                      <asp:Label ID="FD24TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間24"))%>' />
                             </div >
                            <div id='id24B' class='divCss01'><asp:Label ID="FD24BLabel" runat="server" Text='<%# showFoodType(Eval("FD24B")) %>' /></div >
                            <div id='id24C' class='divCss02'><asp:Label ID="FD24CLabel" runat="server" Text='<%# showFoodType(Eval("FD24C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(25)%>>
                            <div id='id25' class='divCss01'>
                                      <asp:Label ID="FD25KindLabel" runat="server" Text='<%#  Eval("出勤班別25")%>'  Visible ="false" />
                                      <asp:Label ID="FD25TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間25"))%>' />
                             </div >
                            <div id='id25B' class='divCss01'><asp:Label ID="FD25BLabel" runat="server" Text='<%# showFoodType(Eval("FD25B")) %>' /></div >
                            <div id='id25C' class='divCss02'><asp:Label ID="FD25CLabel" runat="server" Text='<%# showFoodType(Eval("FD25C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(26)%>>
                            <div id='id26' class='divCss01'>
                                      <asp:Label ID="FD26KindLabel" runat="server" Text='<%#  Eval("出勤班別26")%>'  Visible ="false" />
                                      <asp:Label ID="FD26TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間26"))%>' />
                             </div >
                            <div id='id26B' class='divCss01'><asp:Label ID="FD26BLabel" runat="server" Text='<%# showFoodType(Eval("FD26B")) %>' /></div >
                            <div id='id26C' class='divCss02'><asp:Label ID="FD26CLabel" runat="server" Text='<%# showFoodType(Eval("FD26C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(27)%>>
                            <div id='id27' class='divCss01'>
                                      <asp:Label ID="FD27KindLabel" runat="server" Text='<%#  Eval("出勤班別27")%>'  Visible ="false" />
                                      <asp:Label ID="FD27TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間27"))%>' />
                             </div >
                            <div id='id27B' class='divCss01'><asp:Label ID="FD27BLabel" runat="server" Text='<%# showFoodType(Eval("FD27B")) %>' /></div >
                            <div id='id27C' class='divCss02'><asp:Label ID="FD27CLabel" runat="server" Text='<%# showFoodType(Eval("FD27C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(28)%>>
                            <div id='id28' class='divCss01'>
                                      <asp:Label ID="FD28KindLabel" runat="server" Text='<%#  Eval("出勤班別28")%>'  Visible ="false" />
                                      <asp:Label ID="FD28TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間28"))%>' />
                             </div >
                            <div id='id28B' class='divCss01'><asp:Label ID="FD28BLabel" runat="server" Text='<%# showFoodType(Eval("FD28B")) %>' /></div >
                            <div id='id28C' class='divCss02'><asp:Label ID="FD28CLabel" runat="server" Text='<%# showFoodType(Eval("FD28C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(29)%>>
                            <div id='id29' class='divCss01'>
                                      <asp:Label ID="FD29KindLabel" runat="server" Text='<%#  Eval("出勤班別29")%>'  Visible ="false" />
                                      <asp:Label ID="FD29TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間29"))%>' />
                             </div >
                            <div id='id29B' class='divCss01'><asp:Label ID="FD29BLabel" runat="server" Text='<%# showFoodType(Eval("FD29B")) %>' /></div >
                            <div id='id29C' class='divCss02'><asp:Label ID="FD29CLabel" runat="server" Text='<%# showFoodType(Eval("FD29C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(30)%>>
                            <div id='id30' class='divCss01'>
                                      <asp:Label ID="FD30KindLabel" runat="server" Text='<%#  Eval("出勤班別30")%>'  Visible ="false" />
                                      <asp:Label ID="FD30TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間30"))%>' />
                             </div >
                            <div id='id30B' class='divCss01'><asp:Label ID="FD30BLabel" runat="server" Text='<%# showFoodType(Eval("FD30B")) %>' /></div >
                            <div id='id30C' class='divCss02'><asp:Label ID="FD30CLabel" runat="server" Text='<%# showFoodType(Eval("FD30C")) %>' /></div >
                        </td>
                        <td <%#  showHolidayColor(31)%>>
                            <div id='id31' class='divCss01'>
                                      <asp:Label ID="FD31KindLabel" runat="server" Text='<%#  Eval("出勤班別31")%>'  Visible ="false" />
                                      <asp:Label ID="FD31TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間31"))%>' />
                             </div >
                            <div id='id31B' class='divCss01'><asp:Label ID="FD31BLabel" runat="server" Text='<%# showFoodType(Eval("FD31B")) %>' /></div >
                            <div id='id31C' class='divCss02'><asp:Label ID="FD31CLabel" runat="server" Text='<%# showFoodType(Eval("FD31C")) %>' /></div >
                        </td>

                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #008A8C; color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        </td>

                        <td>
                            <asp:Label ID="FD005TextBox" runat="server" Text='<%# Bind("FD005") %>' />
                            <asp:HiddenField ID="FD004HiddenField" runat="server" Value='<%# Eval("FD004") %>' />
                            <BR><asp:DropDownList ID="ddFD004" runat="server"  Enabled='<%# showSpaceEdit_Flag()%>' BackColor='<%# showSpaceEdit_Color()   %>'  />
                        </td>

                        <td>
                            <asp:Label ID="FD001TextBox" runat="server" Text='<%# Bind("FD001") %>' />

<%--                 *************** 以下隱藏欄位在畫面上未顯示，所以需用欄位暫存  ***************--%>
                            <asp:HiddenField ID="hfForUpdateFDTYM" runat="server" Value='<%# Bind("FDTYM")%>' />
                            <asp:HiddenField ID="hfForUpdateFD003" runat="server" Value='<%# Bind("FD003")%>' />
                            <asp:HiddenField ID="hfForUpdateFD006" runat="server" Value='<%# Bind("FD006")%>' />
                            <asp:HiddenField ID="hfForUpdateFD007" runat="server" Value='<%# Bind("FD007")%>' />
                            <asp:HiddenField ID="hfForUpdateFD008" runat="server" Value='<%# Bind("FD008")%>' />
                            <asp:HiddenField ID="hfForUpdateFD009" runat="server" Value='<%# Bind("FD009")%>' />
                            <asp:HiddenField ID="hfForUpdateFD010" runat="server" Value='<%# Bind("FD010")%>' />
                            <asp:HiddenField ID="hfForUpdateFD01A" runat="server" Value='<%# Bind("FD01A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD02A" runat="server" Value='<%# Bind("FD02A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD03A" runat="server" Value='<%# Bind("FD03A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD04A" runat="server" Value='<%# Bind("FD04A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD05A" runat="server" Value='<%# Bind("FD05A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD06A" runat="server" Value='<%# Bind("FD06A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD07A" runat="server" Value='<%# Bind("FD07A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD08A" runat="server" Value='<%# Bind("FD08A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD09A" runat="server" Value='<%# Bind("FD09A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD10A" runat="server" Value='<%# Bind("FD10A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD11A" runat="server" Value='<%# Bind("FD11A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD12A" runat="server" Value='<%# Bind("FD12A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD13A" runat="server" Value='<%# Bind("FD13A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD14A" runat="server" Value='<%# Bind("FD14A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD15A" runat="server" Value='<%# Bind("FD15A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD16A" runat="server" Value='<%# Bind("FD16A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD17A" runat="server" Value='<%# Bind("FD17A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD18A" runat="server" Value='<%# Bind("FD18A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD19A" runat="server" Value='<%# Bind("FD19A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD20A" runat="server" Value='<%# Bind("FD20A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD21A" runat="server" Value='<%# Bind("FD21A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD22A" runat="server" Value='<%# Bind("FD22A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD23A" runat="server" Value='<%# Bind("FD23A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD24A" runat="server" Value='<%# Bind("FD24A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD25A" runat="server" Value='<%# Bind("FD25A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD26A" runat="server" Value='<%# Bind("FD26A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD27A" runat="server" Value='<%# Bind("FD27A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD28A" runat="server" Value='<%# Bind("FD28A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD29A" runat="server" Value='<%# Bind("FD29A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD30A" runat="server" Value='<%# Bind("FD30A")%>' />
                            <asp:HiddenField ID="hfForUpdateFD31A" runat="server" Value='<%# Bind("FD31A")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1A" runat="server" Value='<%# Bind("FDT1A")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1B" runat="server" Value='<%# Bind("FDT1B")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1C" runat="server" Value='<%# Bind("FDT1C")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTPY" runat="server" Value='<%# Bind("FDTPY")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTSB" runat="server" Value='<%# Bind("FDTSB")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTNP" runat="server" Value='<%# Bind("FDTNP")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTIM1" runat="server" Value='<%# Bind("FDTIM1")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1A2" runat="server" Value='<%# Bind("FDT1A2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1B2" runat="server" Value='<%# Bind("FDT1B2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDT1C2" runat="server" Value='<%# Bind("FDT1C2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTPY2" runat="server" Value='<%# Bind("FDTPY2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTSB2" runat="server" Value='<%# Bind("FDTSB2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTNP2" runat="server" Value='<%# Bind("FDTNP2")%>' />
                            <asp:HiddenField ID="hfForUpdateFDTIM2" runat="server" Value='<%# Bind("FDTIM2")%>' />

                            <asp:HiddenField ID="hfForUpdateEdit_Flag" runat="server" Value='<%# showDayFoodKindEdit_Flag_ThisMonth(Eval("FDTIM1"), Eval("FDTIM2"))%>' />
                            <asp:HiddenField ID="hfForUpdateFDSDTE" runat="server" Value='<%# Bind("FDSDTE")%>' />
                            <asp:HiddenField ID="hfForUpdateFDSTIM" runat="server" Value='<%# Bind("FDSTIM")%>' />
                            <asp:HiddenField ID="hfForUpdateFDSDEV" runat="server" Value='<%# Bind("FDSDEV")%>' />
                            <asp:HiddenField ID="hfForUpdateFDSOPR" runat="server" Value='<%# Bind("FDSOPR")%>' />
<%--                 ******************************--%>
                            <BR><asp:Label ID="FD002TextBox" runat="server" Text='<%# Bind("FD002") %>' />
                            <BR><asp:Label ID="FDLastFoodLabel" runat="server" Text='<%#  show上個月訂購餐別( Eval("上個月訂購餐別") )  %>' />
                        </td>

                        <td>
                            <asp:Label ID="FDSaveInfoLabel" runat="server" Text='<%# showSaveInfo(Eval("FDSDTE"), Eval("FDSTIM"), Eval("FDSDEV"), Eval("FDSOPR") ) %>' />
                        </td>

                        <td>
                            <asp:DropDownList ID="ddFDBatch" runat="server"  Enabled="true"/>
                            <asp:Button ID="btnBatch" runat ="server" Text ="調整" OnClick="btnBatch_Click" CommandName="myBatch"  />
                        </td>

                        <td>
                            <div id='id00' class='divCss01'><asp:Label ID="FD00Label" runat="server" Text="出勤" /></div>
                            <div id='id00B' class='divCss01'><asp:Label ID="FD00BLabel" runat="server" Text="午餐" /></div>
                            <div id='id00C' class='divCss02'><asp:Label ID="FD00CLabel" runat="server" Text="晚餐" /></div>
                        </td>

                        <td <%#  showHolidayColor(01)%>>
                            <div id='id01' class='divCss01'>
                                      <asp:Label ID="FD01KindLabel" runat="server" Text='<%#  Eval("出勤班別01")%>'   Visible ="false" />
                                      <asp:Label ID="FD01TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間01"))%>' />
                            </div>
                            <asp:HiddenField ID="FD01BHiddenField" runat="server" Value='<%# Eval("FD01B") %>' />
                            <asp:HiddenField ID="FD01CHiddenField" runat="server" Value='<%# Eval("FD01C") %>' />
                            <div id='id01B' class='divCss01'><asp:DropDownList ID="ddFD01B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(1, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(1, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id01C' class='divCss01'><asp:DropDownList ID="ddFD01C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(1, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(1, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(02)%>>
                            <div id='id02' class='divCss01'>
                                      <asp:Label ID="FD02KindLabel" runat="server" Text='<%#  Eval("出勤班別02")%>'   Visible ="false" />
                                      <asp:Label ID="FD02TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間02"))%>' />
                            </div>
                            <asp:HiddenField ID="FD02BHiddenField" runat="server" Value='<%# Eval("FD02B") %>' />
                            <asp:HiddenField ID="FD02CHiddenField" runat="server" Value='<%# Eval("FD02C") %>' />
                            <div id='id02B' class='divCss01'><asp:DropDownList ID="ddFD02B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(2, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(2, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id02C' class='divCss01'><asp:DropDownList ID="ddFD02C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(2, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(2, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(03)%>>
                            <div id='id03' class='divCss01'>
                                      <asp:Label ID="FD03KindLabel" runat="server" Text='<%#  Eval("出勤班別03")%>'   Visible ="false" />
                                      <asp:Label ID="FD03TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間03"))%>' />
                            </div>
                            <asp:HiddenField ID="FD03BHiddenField" runat="server" Value='<%# Eval("FD03B") %>' />
                            <asp:HiddenField ID="FD03CHiddenField" runat="server" Value='<%# Eval("FD03C") %>' />
                            <div id='id03B' class='divCss01'><asp:DropDownList ID="ddFD03B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(3, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(3, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id03C' class='divCss01'><asp:DropDownList ID="ddFD03C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(3, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(3, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(04)%>>
                            <div id='id04' class='divCss01'>
                                      <asp:Label ID="FD04KindLabel" runat="server" Text='<%#  Eval("出勤班別04")%>'   Visible ="false" />
                                      <asp:Label ID="FD04TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間04"))%>' />
                            </div>
                            <asp:HiddenField ID="FD04BHiddenField" runat="server" Value='<%# Eval("FD04B") %>' />
                            <asp:HiddenField ID="FD04CHiddenField" runat="server" Value='<%# Eval("FD04C") %>' />
                            <div id='id04B' class='divCss01'><asp:DropDownList ID="ddFD04B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(4, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(4, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id04C' class='divCss01'><asp:DropDownList ID="ddFD04C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(4, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(4, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(05)%>>
                            <div id='id05' class='divCss01'>
                                      <asp:Label ID="FD05KindLabel" runat="server" Text='<%#  Eval("出勤班別05")%>'   Visible ="false" />
                                      <asp:Label ID="FD05TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間05"))%>' />
                            </div>
                            <asp:HiddenField ID="FD05BHiddenField" runat="server" Value='<%# Eval("FD05B") %>' />
                            <asp:HiddenField ID="FD05CHiddenField" runat="server" Value='<%# Eval("FD05C") %>' />
                            <div id='id05B' class='divCss01'><asp:DropDownList ID="ddFD05B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(5, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(5, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id05C' class='divCss01'><asp:DropDownList ID="ddFD05C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(5, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(5, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(06)%>>
                            <div id='id06' class='divCss01'>
                                      <asp:Label ID="FD06KindLabel" runat="server" Text='<%#  Eval("出勤班別06")%>'   Visible ="false" />
                                      <asp:Label ID="FD06TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間06"))%>' />
                            </div>
                            <asp:HiddenField ID="FD06BHiddenField" runat="server" Value='<%# Eval("FD06B") %>' />
                            <asp:HiddenField ID="FD06CHiddenField" runat="server" Value='<%# Eval("FD06C") %>' />
                            <div id='id06B' class='divCss01'><asp:DropDownList ID="ddFD06B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(6, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(6, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id06C' class='divCss01'><asp:DropDownList ID="ddFD06C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(6, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(6, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(07)%>>
                            <div id='id07' class='divCss01'>
                                      <asp:Label ID="FD07KindLabel" runat="server" Text='<%#  Eval("出勤班別07")%>'   Visible ="false" />
                                      <asp:Label ID="FD07TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間07"))%>' />
                            </div>
                            <asp:HiddenField ID="FD07BHiddenField" runat="server" Value='<%# Eval("FD07B") %>' />
                            <asp:HiddenField ID="FD07CHiddenField" runat="server" Value='<%# Eval("FD07C") %>' />
                            <div id='id07B' class='divCss01'><asp:DropDownList ID="ddFD07B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(7, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(7, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id07C' class='divCss01'><asp:DropDownList ID="ddFD07C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(7, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(7, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(08)%>>
                            <div id='id08' class='divCss01'>
                                      <asp:Label ID="FD08KindLabel" runat="server" Text='<%#  Eval("出勤班別08")%>'   Visible ="false" />
                                      <asp:Label ID="FD08TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間08"))%>' />
                            </div>
                            <asp:HiddenField ID="FD08BHiddenField" runat="server" Value='<%# Eval("FD08B") %>' />
                            <asp:HiddenField ID="FD08CHiddenField" runat="server" Value='<%# Eval("FD08C") %>' />
                            <div id='id08B' class='divCss01'><asp:DropDownList ID="ddFD08B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(8, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(8, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id08C' class='divCss01'><asp:DropDownList ID="ddFD08C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(8, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(8, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(09)%>>
                            <div id='id09' class='divCss01'>
                                      <asp:Label ID="FD09KindLabel" runat="server" Text='<%#  Eval("出勤班別09")%>'   Visible ="false" />
                                      <asp:Label ID="FD09TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間09"))%>' />
                            </div>
                            <asp:HiddenField ID="FD09BHiddenField" runat="server" Value='<%# Eval("FD09B") %>' />
                            <asp:HiddenField ID="FD09CHiddenField" runat="server" Value='<%# Eval("FD09C") %>' />
                            <div id='id09B' class='divCss01'><asp:DropDownList ID="ddFD09B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(9, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(9, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id09C' class='divCss01'><asp:DropDownList ID="ddFD09C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(9, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(9, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(10)%>>
                            <div id='id10' class='divCss01'>
                                      <asp:Label ID="FD10KindLabel" runat="server" Text='<%#  Eval("出勤班別10")%>'   Visible ="false" />
                                      <asp:Label ID="FD10TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間10"))%>' />
                            </div>
                            <asp:HiddenField ID="FD10BHiddenField" runat="server" Value='<%# Eval("FD10B") %>' />
                            <asp:HiddenField ID="FD10CHiddenField" runat="server" Value='<%# Eval("FD10C") %>' />
                            <div id='id10B' class='divCss01'><asp:DropDownList ID="ddFD10B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(10, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(10, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id10C' class='divCss01'><asp:DropDownList ID="ddFD10C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(10, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(10, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(11)%>>
                            <div id='id11' class='divCss01'>
                                      <asp:Label ID="FD11KindLabel" runat="server" Text='<%#  Eval("出勤班別11")%>'   Visible ="false" />
                                      <asp:Label ID="FD11TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間11"))%>' />
                            </div>
                            <asp:HiddenField ID="FD11BHiddenField" runat="server" Value='<%# Eval("FD11B") %>' />
                            <asp:HiddenField ID="FD11CHiddenField" runat="server" Value='<%# Eval("FD11C") %>' />
                            <div id='id11B' class='divCss01'><asp:DropDownList ID="ddFD11B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(11, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(11, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id11C' class='divCss01'><asp:DropDownList ID="ddFD11C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(11, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(11, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(12)%>>
                            <div id='id12' class='divCss01'>
                                      <asp:Label ID="FD12KindLabel" runat="server" Text='<%#  Eval("出勤班別12")%>'   Visible ="false" />
                                      <asp:Label ID="FD12TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間12"))%>' />
                            </div>
                            <asp:HiddenField ID="FD12BHiddenField" runat="server" Value='<%# Eval("FD12B") %>' />
                            <asp:HiddenField ID="FD12CHiddenField" runat="server" Value='<%# Eval("FD12C") %>' />
                            <div id='id12B' class='divCss01'><asp:DropDownList ID="ddFD12B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(12, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(12, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id12C' class='divCss01'><asp:DropDownList ID="ddFD12C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(12, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(12, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(13)%>>
                            <div id='id13' class='divCss01'>
                                      <asp:Label ID="FD13KindLabel" runat="server" Text='<%#  Eval("出勤班別13")%>'   Visible ="false" />
                                      <asp:Label ID="FD13TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間13"))%>' />
                            </div>
                            <asp:HiddenField ID="FD13BHiddenField" runat="server" Value='<%# Eval("FD13B") %>' />
                            <asp:HiddenField ID="FD13CHiddenField" runat="server" Value='<%# Eval("FD13C") %>' />
                            <div id='id13B' class='divCss01'><asp:DropDownList ID="ddFD13B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(13, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(13, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id13C' class='divCss01'><asp:DropDownList ID="ddFD13C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(13, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(13, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(14)%>>
                            <div id='id14' class='divCss01'>
                                      <asp:Label ID="FD14KindLabel" runat="server" Text='<%#  Eval("出勤班別14")%>'   Visible ="false" />
                                      <asp:Label ID="FD14TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間14"))%>' />
                            </div>
                            <asp:HiddenField ID="FD14BHiddenField" runat="server" Value='<%# Eval("FD14B") %>' />
                            <asp:HiddenField ID="FD14CHiddenField" runat="server" Value='<%# Eval("FD14C") %>' />
                            <div id='id14B' class='divCss01'><asp:DropDownList ID="ddFD14B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(14, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(14, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id14C' class='divCss01'><asp:DropDownList ID="ddFD14C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(14, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(14, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(15)%>>
                            <div id='id15' class='divCss01'>
                                      <asp:Label ID="FD15KindLabel" runat="server" Text='<%#  Eval("出勤班別15")%>'   Visible ="false" />
                                      <asp:Label ID="FD15TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間15"))%>' />
                            </div>
                            <asp:HiddenField ID="FD15BHiddenField" runat="server" Value='<%# Eval("FD15B") %>' />
                            <asp:HiddenField ID="FD15CHiddenField" runat="server" Value='<%# Eval("FD15C") %>' />
                            <div id='id15B' class='divCss01'><asp:DropDownList ID="ddFD15B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(15, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(15, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id15C' class='divCss01'><asp:DropDownList ID="ddFD15C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(15, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(15, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(16)%>>
                            <div id='id16' class='divCss01'>
                                      <asp:Label ID="FD16KindLabel" runat="server" Text='<%#  Eval("出勤班別16")%>'   Visible ="false" />
                                      <asp:Label ID="FD16TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間16"))%>' />
                            </div>
                            <asp:HiddenField ID="FD16BHiddenField" runat="server" Value='<%# Eval("FD16B") %>' />
                            <asp:HiddenField ID="FD16CHiddenField" runat="server" Value='<%# Eval("FD16C") %>' />
                            <div id='id16B' class='divCss01'><asp:DropDownList ID="ddFD16B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(16, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(16, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id16C' class='divCss01'><asp:DropDownList ID="ddFD16C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(16, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(16, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(17)%>>
                            <div id='id17' class='divCss01'>
                                      <asp:Label ID="FD17KindLabel" runat="server" Text='<%#  Eval("出勤班別17")%>'   Visible ="false" />
                                      <asp:Label ID="FD17TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間17"))%>' />
                            </div>
                            <asp:HiddenField ID="FD17BHiddenField" runat="server" Value='<%# Eval("FD17B") %>' />
                            <asp:HiddenField ID="FD17CHiddenField" runat="server" Value='<%# Eval("FD17C") %>' />
                            <div id='id17B' class='divCss01'><asp:DropDownList ID="ddFD17B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(17, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(17, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id17C' class='divCss01'><asp:DropDownList ID="ddFD17C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(17, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(17, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(18)%>>
                            <div id='id18' class='divCss01'>
                                      <asp:Label ID="FD18KindLabel" runat="server" Text='<%#  Eval("出勤班別18")%>'   Visible ="false" />
                                      <asp:Label ID="FD18TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間18"))%>' />
                            </div>
                            <asp:HiddenField ID="FD18BHiddenField" runat="server" Value='<%# Eval("FD18B") %>' />
                            <asp:HiddenField ID="FD18CHiddenField" runat="server" Value='<%# Eval("FD18C") %>' />
                            <div id='id18B' class='divCss01'><asp:DropDownList ID="ddFD18B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(18, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(18, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id18C' class='divCss01'><asp:DropDownList ID="ddFD18C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(18, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(18, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(19)%>>
                            <div id='id19' class='divCss01'>
                                      <asp:Label ID="FD19KindLabel" runat="server" Text='<%#  Eval("出勤班別19")%>'   Visible ="false" />
                                      <asp:Label ID="FD19TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間19"))%>' />
                            </div>
                            <asp:HiddenField ID="FD19BHiddenField" runat="server" Value='<%# Eval("FD19B") %>' />
                            <asp:HiddenField ID="FD19CHiddenField" runat="server" Value='<%# Eval("FD19C") %>' />
                            <div id='id19B' class='divCss01'><asp:DropDownList ID="ddFD19B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(19, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(19, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id19C' class='divCss01'><asp:DropDownList ID="ddFD19C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(19, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(19, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(20)%>>
                            <div id='id20' class='divCss01'>
                                      <asp:Label ID="FD20KindLabel" runat="server" Text='<%#  Eval("出勤班別20")%>'   Visible ="false" />
                                      <asp:Label ID="FD20TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間20"))%>' />
                            </div>
                            <asp:HiddenField ID="FD20BHiddenField" runat="server" Value='<%# Eval("FD20B") %>' />
                            <asp:HiddenField ID="FD20CHiddenField" runat="server" Value='<%# Eval("FD20C") %>' />
                            <div id='id20B' class='divCss01'><asp:DropDownList ID="ddFD20B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(20, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(20, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id20C' class='divCss01'><asp:DropDownList ID="ddFD20C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(20, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(20, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(21)%>>
                            <div id='id21' class='divCss01'>
                                      <asp:Label ID="FD21KindLabel" runat="server" Text='<%#  Eval("出勤班別21")%>'   Visible ="false" />
                                      <asp:Label ID="FD21TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間21"))%>' />
                            </div>
                            <asp:HiddenField ID="FD21BHiddenField" runat="server" Value='<%# Eval("FD21B") %>' />
                            <asp:HiddenField ID="FD21CHiddenField" runat="server" Value='<%# Eval("FD21C") %>' />
                            <div id='id21B' class='divCss01'><asp:DropDownList ID="ddFD21B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(21, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(21, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id21C' class='divCss01'><asp:DropDownList ID="ddFD21C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(21, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(21, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(22)%>>
                            <div id='id22' class='divCss01'>
                                      <asp:Label ID="FD22KindLabel" runat="server" Text='<%#  Eval("出勤班別22")%>'   Visible ="false" />
                                      <asp:Label ID="FD22TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間22"))%>' />
                            </div>
                            <asp:HiddenField ID="FD22BHiddenField" runat="server" Value='<%# Eval("FD22B") %>' />
                            <asp:HiddenField ID="FD22CHiddenField" runat="server" Value='<%# Eval("FD22C") %>' />
                            <div id='id22B' class='divCss01'><asp:DropDownList ID="ddFD22B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(22, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(22, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id22C' class='divCss01'><asp:DropDownList ID="ddFD22C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(22, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(22, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(23)%>>
                            <div id='id23' class='divCss01'>
                                      <asp:Label ID="FD23KindLabel" runat="server" Text='<%#  Eval("出勤班別23")%>'   Visible ="false" />
                                      <asp:Label ID="FD23TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間23"))%>' />
                            </div>
                            <asp:HiddenField ID="FD23BHiddenField" runat="server" Value='<%# Eval("FD23B") %>' />
                            <asp:HiddenField ID="FD23CHiddenField" runat="server" Value='<%# Eval("FD23C") %>' />
                            <div id='id23B' class='divCss01'><asp:DropDownList ID="ddFD23B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(23, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(23, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id23C' class='divCss01'><asp:DropDownList ID="ddFD23C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(23, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(23, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(24)%>>
                            <div id='id24' class='divCss01'>
                                      <asp:Label ID="FD24KindLabel" runat="server" Text='<%#  Eval("出勤班別24")%>'   Visible ="false" />
                                      <asp:Label ID="FD24TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間24"))%>' />
                            </div>
                            <asp:HiddenField ID="FD24BHiddenField" runat="server" Value='<%# Eval("FD24B") %>' />
                            <asp:HiddenField ID="FD24CHiddenField" runat="server" Value='<%# Eval("FD24C") %>' />
                            <div id='id24B' class='divCss01'><asp:DropDownList ID="ddFD24B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(24, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(24, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id24C' class='divCss01'><asp:DropDownList ID="ddFD24C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(24, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(24, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(25)%>>
                            <div id='id25' class='divCss01'>
                                      <asp:Label ID="FD25KindLabel" runat="server" Text='<%#  Eval("出勤班別25")%>'   Visible ="false" />
                                      <asp:Label ID="FD25TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間25"))%>' />
                            </div>
                            <asp:HiddenField ID="FD25BHiddenField" runat="server" Value='<%# Eval("FD25B") %>' />
                            <asp:HiddenField ID="FD25CHiddenField" runat="server" Value='<%# Eval("FD25C") %>' />
                            <div id='id25B' class='divCss01'><asp:DropDownList ID="ddFD25B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(25, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(25, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id25C' class='divCss01'><asp:DropDownList ID="ddFD25C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(25, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(25, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(26)%>>
                            <div id='id26' class='divCss01'>
                                      <asp:Label ID="FD26KindLabel" runat="server" Text='<%#  Eval("出勤班別26")%>'   Visible ="false" />
                                      <asp:Label ID="FD26TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間26"))%>' />
                            </div>
                            <asp:HiddenField ID="FD26BHiddenField" runat="server" Value='<%# Eval("FD26B") %>' />
                            <asp:HiddenField ID="FD26CHiddenField" runat="server" Value='<%# Eval("FD26C") %>' />
                            <div id='id26B' class='divCss01'><asp:DropDownList ID="ddFD26B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(26, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(26, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id26C' class='divCss01'><asp:DropDownList ID="ddFD26C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(26, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(26, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(27)%>>
                            <div id='id27' class='divCss01'>
                                      <asp:Label ID="FD27KindLabel" runat="server" Text='<%#  Eval("出勤班別27")%>'   Visible ="false" />
                                      <asp:Label ID="FD27TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間27"))%>' />
                            </div>
                            <asp:HiddenField ID="FD27BHiddenField" runat="server" Value='<%# Eval("FD27B") %>' />
                            <asp:HiddenField ID="FD27CHiddenField" runat="server" Value='<%# Eval("FD27C") %>' />
                            <div id='id27B' class='divCss01'><asp:DropDownList ID="ddFD27B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(27, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(27, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id27C' class='divCss01'><asp:DropDownList ID="ddFD27C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(27, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(27, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(28)%>>
                            <div id='id28' class='divCss01'>
                                      <asp:Label ID="FD28KindLabel" runat="server" Text='<%#  Eval("出勤班別28")%>'   Visible ="false" />
                                      <asp:Label ID="FD28TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間28"))%>' />
                            </div>
                            <asp:HiddenField ID="FD28BHiddenField" runat="server" Value='<%# Eval("FD28B") %>' />
                            <asp:HiddenField ID="FD28CHiddenField" runat="server" Value='<%# Eval("FD28C") %>' />
                            <div id='id28B' class='divCss01'><asp:DropDownList ID="ddFD28B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(28, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(28, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  /></div>
                            <div id='id28C' class='divCss01'><asp:DropDownList ID="ddFD28C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(28, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(28, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  /></div>
                        </td>
                        <td <%#  showHolidayColor(29)%>>
                            <div id='id29' class='divCss01'>
                                      <asp:Label ID="FD29KindLabel" runat="server" Text='<%#  Eval("出勤班別29")%>'   Visible ="false" />
                                      <asp:Label ID="FD29TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間29"))%>' />
                            </div>
                            <asp:HiddenField ID="FD29BHiddenField" runat="server" Value='<%# Eval("FD29B") %>' />
                            <asp:HiddenField ID="FD29CHiddenField" runat="server" Value='<%# Eval("FD29C") %>' />
                            <div id='id29B' class='divCss01'><asp:DropDownList ID="ddFD29B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(29, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(29, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  Visible ='<%# showDayVisible(29)%>'/></div>
                            <div id='id29C' class='divCss01'><asp:DropDownList ID="ddFD29C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(29, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(29, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  Visible ='<%# showDayVisible(29)%>'/></div>
                        </td>
                        <td <%#  showHolidayColor(30)%>>
                            <div id='id30' class='divCss01'>
                                      <asp:Label ID="FD30KindLabel" runat="server" Text='<%#  Eval("出勤班別30")%>'   Visible ="false" />
                                      <asp:Label ID="FD30TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間30"))%>' />
                            </div>
                            <asp:HiddenField ID="FD30BHiddenField" runat="server" Value='<%# Eval("FD30B") %>' />
                            <asp:HiddenField ID="FD30CHiddenField" runat="server" Value='<%# Eval("FD30C") %>' />
                            <div id='id30B' class='divCss01'><asp:DropDownList ID="ddFD30B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(30, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(30, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  Visible ='<%# showDayVisible(30)%>'/></div>
                            <div id='id30C' class='divCss01'><asp:DropDownList ID="ddFD30C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(30, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(30, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  Visible ='<%# showDayVisible(30)%>'/></div>
                        </td>
                        <td <%#  showHolidayColor(31)%>>
                            <div id='id31' class='divCss01'>
                                      <asp:Label ID="FD31KindLabel" runat="server" Text='<%#  Eval("出勤班別31")%>'   Visible ="false" />
                                      <asp:Label ID="FD31TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間31"))%>' />
                            </div>
                            <asp:HiddenField ID="FD31BHiddenField" runat="server" Value='<%# Eval("FD31B") %>' />
                            <asp:HiddenField ID="FD31CHiddenField" runat="server" Value='<%# Eval("FD31C") %>' />
                            <div id='id31B' class='divCss01'><asp:DropDownList ID="ddFD31B" runat="server"  Enabled='<%# showDayFoodKindEdit_Flag(31, "B", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(31, "B", Eval("FDTIM1"), Eval("FDTIM2")  ) %>'  Visible ='<%# showDayVisible(31)%>'/></div>
                            <div id='id31C' class='divCss01'><asp:DropDownList ID="ddFD31C" runat="server" Enabled='<%# showDayFoodKindEdit_Flag(31, "C", Eval("FDTIM1"), Eval("FDTIM2"))%>' BackColor='<%# showDayFoodKindEdit_Color(31, "C", Eval("FDTIM1"), Eval("FDTIM2") ) %>'  Visible ='<%# showDayVisible(31)%>'/></div>
                        </td>

                    </tr>

                     <tr>
                                <td>訊息:</td>
                                <td colspan="36" >
                                            <asp:CustomValidator ID="EditCustomValidator1" runat="server" OnServerValidate="EditCustomValidator1_ServerValidate"></asp:CustomValidator>
                                </td>
                     </tr>   
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
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
                            <asp:TextBox ID="FD005TextBox" runat="server" Text='<%# Bind("FD005") %>' />
                            <BR><asp:TextBox ID="FD004TextBox" runat="server" Text='<%# Bind("FD004") %>' />
                        </td>

                        <td>
                            <asp:TextBox ID="FD001TextBox" runat="server" Text='<%# Bind("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Bind("CDBMemberName")%>' />
                            <BR><asp:TextBox ID="FD002TextBox" runat="server" Text='<%# Bind("FD002") %>' />
                        </td>

                        <td>

                        </td>

                        <td>
                            
                        </td>

                        <td>
                            <asp:Label ID="FD00Label" runat="server" Text="出勤" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="午餐" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="晚餐" />
                        </td>
                        <td <%#  showHolidayColor(01)%>>
                            <asp:Label ID="FD01KindLabel" runat="server" Text='<%# Eval("出勤班別01")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD01TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間01"))%>' /><br>
                            <asp:TextBox ID="FD01BTextBox" runat="server" Text='<%# Bind("FD01B") %>' /><br>
                            <asp:TextBox ID="FD01CTextBox" runat="server" Text='<%# Bind("FD01C") %>' />
                        </td>
                        <td <%#  showHolidayColor(02)%>>
                            <asp:Label ID="FD02KindLabel" runat="server" Text='<%# Eval("出勤班別02")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD02TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間02"))%>' /><br>
                            <asp:TextBox ID="FD02BTextBox" runat="server" Text='<%# Bind("FD02B") %>' /><br>
                            <asp:TextBox ID="FD02CTextBox" runat="server" Text='<%# Bind("FD02C") %>' />
                        </td>
                        <td <%#  showHolidayColor(03)%>>
                            <asp:Label ID="FD03KindLabel" runat="server" Text='<%# Eval("出勤班別03")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD03TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間03"))%>' /><br>
                            <asp:TextBox ID="FD03BTextBox" runat="server" Text='<%# Bind("FD03B") %>' /><br>
                            <asp:TextBox ID="FD03CTextBox" runat="server" Text='<%# Bind("FD03C") %>' />
                        </td>
                        <td <%#  showHolidayColor(04)%>>
                            <asp:Label ID="FD04KindLabel" runat="server" Text='<%# Eval("出勤班別04")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD04TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間04"))%>' /><br>
                            <asp:TextBox ID="FD04BTextBox" runat="server" Text='<%# Bind("FD04B") %>' /><br>
                            <asp:TextBox ID="FD04CTextBox" runat="server" Text='<%# Bind("FD04C") %>' />
                        </td>
                        <td <%#  showHolidayColor(05)%>>
                            <asp:Label ID="FD05KindLabel" runat="server" Text='<%# Eval("出勤班別05")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD05TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間05"))%>' /><br>
                            <asp:TextBox ID="FD05BTextBox" runat="server" Text='<%# Bind("FD05B") %>' /><br>
                            <asp:TextBox ID="FD05CTextBox" runat="server" Text='<%# Bind("FD05C") %>' />
                        </td>
                        <td <%#  showHolidayColor(06)%>>
                            <asp:Label ID="FD06KindLabel" runat="server" Text='<%# Eval("出勤班別06")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD06TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間06"))%>' /><br>
                            <asp:TextBox ID="FD06BTextBox" runat="server" Text='<%# Bind("FD06B") %>' /><br>
                            <asp:TextBox ID="FD06CTextBox" runat="server" Text='<%# Bind("FD06C") %>' />
                        </td>
                        <td <%#  showHolidayColor(07)%>>
                            <asp:Label ID="FD07KindLabel" runat="server" Text='<%# Eval("出勤班別07")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD07TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間07"))%>' /><br>
                            <asp:TextBox ID="FD07BTextBox" runat="server" Text='<%# Bind("FD07B") %>' /><br>
                            <asp:TextBox ID="FD07CTextBox" runat="server" Text='<%# Bind("FD07C") %>' />
                        </td>
                        <td <%#  showHolidayColor(08)%>>
                            <asp:Label ID="FD08KindLabel" runat="server" Text='<%# Eval("出勤班別08")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD08TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間08"))%>' /><br>
                            <asp:TextBox ID="FD08BTextBox" runat="server" Text='<%# Bind("FD08B") %>' /><br>
                            <asp:TextBox ID="FD08CTextBox" runat="server" Text='<%# Bind("FD08C") %>' />
                        </td>
                        <td <%#  showHolidayColor(09)%>>
                            <asp:Label ID="FD09KindLabel" runat="server" Text='<%# Eval("出勤班別09")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD09TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間09"))%>' /><br>
                            <asp:TextBox ID="FD09BTextBox" runat="server" Text='<%# Bind("FD09B") %>' /><br>
                            <asp:TextBox ID="FD09CTextBox" runat="server" Text='<%# Bind("FD09C") %>' />
                        </td>
                        <td <%#  showHolidayColor(10)%>>
                            <asp:Label ID="FD10KindLabel" runat="server" Text='<%# Eval("出勤班別10")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD10TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間10"))%>' /><br>
                            <asp:TextBox ID="FD10BTextBox" runat="server" Text='<%# Bind("FD10B") %>' /><br>
                            <asp:TextBox ID="FD10CTextBox" runat="server" Text='<%# Bind("FD10C") %>' />
                        </td>
                        <td <%#  showHolidayColor(11)%>>
                            <asp:Label ID="FD11KindLabel" runat="server" Text='<%# Eval("出勤班別11")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD11TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間11"))%>' /><br>
                            <asp:TextBox ID="FD11BTextBox" runat="server" Text='<%# Bind("FD11B") %>' /><br>
                            <asp:TextBox ID="FD11CTextBox" runat="server" Text='<%# Bind("FD11C") %>' />
                        </td>
                        <td <%#  showHolidayColor(12)%>>
                            <asp:Label ID="FD12KindLabel" runat="server" Text='<%# Eval("出勤班別12")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD12TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間12"))%>' /><br>
                            <asp:TextBox ID="FD12BTextBox" runat="server" Text='<%# Bind("FD12B") %>' /><br>
                            <asp:TextBox ID="FD12CTextBox" runat="server" Text='<%# Bind("FD12C") %>' />
                        </td>
                        <td <%#  showHolidayColor(13)%>>
                            <asp:Label ID="FD13KindLabel" runat="server" Text='<%# Eval("出勤班別13")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD13TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間13"))%>' /><br>
                            <asp:TextBox ID="FD13BTextBox" runat="server" Text='<%# Bind("FD13B") %>' /><br>
                            <asp:TextBox ID="FD13CTextBox" runat="server" Text='<%# Bind("FD13C") %>' />
                        </td>
                        <td <%#  showHolidayColor(14)%>>
                            <asp:Label ID="FD14KindLabel" runat="server" Text='<%# Eval("出勤班別14")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD14TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間14"))%>' /><br>
                            <asp:TextBox ID="FD14BTextBox" runat="server" Text='<%# Bind("FD14B") %>' /><br>
                            <asp:TextBox ID="FD14CTextBox" runat="server" Text='<%# Bind("FD14C") %>' />
                        </td>
                        <td <%#  showHolidayColor(15)%>>
                            <asp:Label ID="FD15KindLabel" runat="server" Text='<%# Eval("出勤班別15")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD15TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間15"))%>' /><br>
                            <asp:TextBox ID="FD15BTextBox" runat="server" Text='<%# Bind("FD15B") %>' /><br>
                            <asp:TextBox ID="FD15CTextBox" runat="server" Text='<%# Bind("FD15C") %>' />
                        </td>
                        <td <%#  showHolidayColor(16)%>>
                            <asp:Label ID="FD16KindLabel" runat="server" Text='<%# Eval("出勤班別16")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD16TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間16"))%>' /><br>
                            <asp:TextBox ID="FD16BTextBox" runat="server" Text='<%# Bind("FD16B") %>' /><br>
                            <asp:TextBox ID="FD16CTextBox" runat="server" Text='<%# Bind("FD16C") %>' />
                        </td>
                        <td <%#  showHolidayColor(17)%>>
                            <asp:Label ID="FD17KindLabel" runat="server" Text='<%# Eval("出勤班別17")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD17TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間17"))%>' /><br>
                            <asp:TextBox ID="FD17BTextBox" runat="server" Text='<%# Bind("FD17B") %>' /><br>
                            <asp:TextBox ID="FD17CTextBox" runat="server" Text='<%# Bind("FD17C") %>' />
                        </td>
                        <td <%#  showHolidayColor(18)%>>
                            <asp:Label ID="FD18KindLabel" runat="server" Text='<%# Eval("出勤班別18")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD18TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間18"))%>' /><br>
                            <asp:TextBox ID="FD18BTextBox" runat="server" Text='<%# Bind("FD18B") %>' /><br>
                            <asp:TextBox ID="FD18CTextBox" runat="server" Text='<%# Bind("FD18C") %>' />
                        </td>
                        <td <%#  showHolidayColor(19)%>>
                            <asp:Label ID="FD19KindLabel" runat="server" Text='<%# Eval("出勤班別19")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD19TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間19"))%>' /><br>
                            <asp:TextBox ID="FD19BTextBox" runat="server" Text='<%# Bind("FD19B") %>' /><br>
                            <asp:TextBox ID="FD19CTextBox" runat="server" Text='<%# Bind("FD19C") %>' />
                        </td>
                        <td <%#  showHolidayColor(20)%>>
                            <asp:Label ID="FD20KindLabel" runat="server" Text='<%# Eval("出勤班別20")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD20TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間20"))%>' /><br>
                            <asp:TextBox ID="FD20BTextBox" runat="server" Text='<%# Bind("FD20B") %>' /><br>
                            <asp:TextBox ID="FD20CTextBox" runat="server" Text='<%# Bind("FD20C") %>' />
                        </td>
                        <td <%#  showHolidayColor(21)%>>
                            <asp:Label ID="FD21KindLabel" runat="server" Text='<%# Eval("出勤班別21")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD21TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間21"))%>' /><br>
                            <asp:TextBox ID="FD21BTextBox" runat="server" Text='<%# Bind("FD21B") %>' /><br>
                            <asp:TextBox ID="FD21CTextBox" runat="server" Text='<%# Bind("FD21C") %>' />
                        </td>
                        <td <%#  showHolidayColor(22)%>>
                            <asp:Label ID="FD22KindLabel" runat="server" Text='<%# Eval("出勤班別22")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD22TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間22"))%>' /><br>
                            <asp:TextBox ID="FD22BTextBox" runat="server" Text='<%# Bind("FD22B") %>' /><br>
                            <asp:TextBox ID="FD22CTextBox" runat="server" Text='<%# Bind("FD22C") %>' />
                        </td>
                        <td <%#  showHolidayColor(23)%>>
                            <asp:Label ID="FD23KindLabel" runat="server" Text='<%# Eval("出勤班別23")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD23TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間23"))%>' /><br>
                            <asp:TextBox ID="FD23BTextBox" runat="server" Text='<%# Bind("FD23B") %>' /><br>
                            <asp:TextBox ID="FD23CTextBox" runat="server" Text='<%# Bind("FD23C") %>' />
                        </td>
                        <td <%#  showHolidayColor(24)%>>
                            <asp:Label ID="FD24KindLabel" runat="server" Text='<%# Eval("出勤班別24")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD24TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間24"))%>' /><br>
                            <asp:TextBox ID="FD24BTextBox" runat="server" Text='<%# Bind("FD24B") %>' /><br>
                            <asp:TextBox ID="FD24CTextBox" runat="server" Text='<%# Bind("FD24C") %>' />
                        </td>
                        <td <%#  showHolidayColor(25)%>>
                            <asp:Label ID="FD25KindLabel" runat="server" Text='<%# Eval("出勤班別25")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD25TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間25"))%>' /><br>
                            <asp:TextBox ID="FD25BTextBox" runat="server" Text='<%# Bind("FD25B") %>' /><br>
                            <asp:TextBox ID="FD25CTextBox" runat="server" Text='<%# Bind("FD25C") %>' />
                        </td>
                        <td <%#  showHolidayColor(26)%>>
                            <asp:Label ID="FD26KindLabel" runat="server" Text='<%# Eval("出勤班別26")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD26TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間26"))%>' /><br>
                            <asp:TextBox ID="FD26BTextBox" runat="server" Text='<%# Bind("FD26B") %>' /><br>
                            <asp:TextBox ID="FD26CTextBox" runat="server" Text='<%# Bind("FD26C") %>' />
                        </td>
                        <td <%#  showHolidayColor(27)%>>
                            <asp:Label ID="FD27KindLabel" runat="server" Text='<%# Eval("出勤班別27")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD27TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間27"))%>' /><br>
                            <asp:TextBox ID="FD27BTextBox" runat="server" Text='<%# Bind("FD27B") %>' /><br>
                            <asp:TextBox ID="FD27CTextBox" runat="server" Text='<%# Bind("FD27C") %>' />
                        </td>
                        <td <%#  showHolidayColor(28)%>>
                            <asp:Label ID="FD28KindLabel" runat="server" Text='<%# Eval("出勤班別28")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD28TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間28"))%>' /><br>
                            <asp:TextBox ID="FD28BTextBox" runat="server" Text='<%# Bind("FD28B") %>' /><br>
                            <asp:TextBox ID="FD28CTextBox" runat="server" Text='<%# Bind("FD28C") %>' />
                        </td>
                        <td <%#  showHolidayColor(29)%>>
                            <asp:Label ID="FD29KindLabel" runat="server" Text='<%# Eval("出勤班別29")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD29TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間29"))%>' /><br>
                            <asp:TextBox ID="FD29BTextBox" runat="server" Text='<%# Bind("FD29B") %>' /><br>
                            <asp:TextBox ID="FD29CTextBox" runat="server" Text='<%# Bind("FD29C") %>' />
                        </td>
                        <td <%#  showHolidayColor(30)%>>
                            <asp:Label ID="FD30KindLabel" runat="server" Text='<%# Eval("出勤班別30")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD30TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間30"))%>' /><br>
                            <asp:TextBox ID="FD30BTextBox" runat="server" Text='<%# Bind("FD30B") %>' /><br>
                            <asp:TextBox ID="FD30CTextBox" runat="server" Text='<%# Bind("FD30C") %>' />
                        </td>
                        <td <%#  showHolidayColor(31)%>>
                            <asp:Label ID="FD31KindLabel" runat="server" Text='<%# Eval("出勤班別31")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD31TimeLabel" runat="server" Text='<%# show出勤資料(Eval("出勤時間31"))%>' /><br>
                            <asp:TextBox ID="FD31BTextBox" runat="server" Text='<%# Bind("FD31B") %>' /><br>
                            <asp:TextBox ID="FD31CTextBox" runat="server" Text='<%# Bind("FD31C") %>' />
                        </td>

                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯"  Enabled ='<%# showThisMonthCanEdit(Eval("FDTIM1"), Eval("FDTIM2")) %>'/>
                        </td>

                        <td>
                            <asp:Label ID="FD005Label" runat="server" Text='<%# Eval("FD005") %>' />
                            <BR><asp:Label ID="FD004Label" runat="server" Text='<%# Eval("FD004")  + ModTools.showSpace(4) %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                            <BR><asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") + ModTools.showSpace(4)%>' />
                            <BR><asp:Label ID="FDLastFoodLabel" runat="server" Text='<%#  show上個月訂購餐別( Eval("上個月訂購餐別")+ ModTools.showSpace(7)  )  %>' />
                        </td>

                        <td>
                            <asp:Label ID="FDSaveInfoLabel" runat="server" Text='<%# showSaveInfo(Eval("FDSDTE"), Eval("FDSTIM"), Eval("FDSDEV"), Eval("FDSOPR") ) %>' />
                        </td>

                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# ModTools.showSpace(15)%>' />
                        </td>

                       <td> 
                            <div id='id00' class='divCss01'><asp:Label ID="FD00Label" runat="server" Text="出勤"/></div>
                            <div id='id00B' class='divCss01'><asp:Label ID="FD00BLabel" runat="server" Text="午餐" /></div>
                            <div id='id00C' class='divCss02'><asp:Label ID="FD00CLabel" runat="server" Text="晚餐" /></div>
                        </td>
                        <td <%#  showHolidayColor(01)%>>
                            <div id='id01' class='divCss01'>
                                      <asp:Label ID="FD01KindLabel" runat="server" Text='<%# Eval("出勤班別01")%>'   Visible ="false" />
                                      <asp:Label ID="FD01TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間01"))%>' />
                             </div>
                            <div id='id01B' class='divCss01'><asp:Label ID="FD01BLabel" runat="server" Text='<%# showFoodType(Eval("FD01B"))%>' /></div>
                            <div id='id01C' class='divCss02'><asp:Label ID="FD01CLabel" runat="server" Text='<%# showFoodType(Eval("FD01C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(02)%>>
                            <div id='id02' class='divCss01'>
                                      <asp:Label ID="FD02KindLabel" runat="server" Text='<%# Eval("出勤班別02")%>'   Visible ="false" />
                                      <asp:Label ID="FD02TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間02"))%>' />
                             </div>
                            <div id='id02B' class='divCss01'><asp:Label ID="FD02BLabel" runat="server" Text='<%# showFoodType(Eval("FD02B"))%>' /></div>
                            <div id='id02C' class='divCss02'><asp:Label ID="FD02CLabel" runat="server" Text='<%# showFoodType(Eval("FD02C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(03)%>>
                            <div id='id03' class='divCss01'>
                                      <asp:Label ID="FD03KindLabel" runat="server" Text='<%# Eval("出勤班別03")%>'   Visible ="false" />
                                      <asp:Label ID="FD03TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間03"))%>' />
                             </div>
                            <div id='id03B' class='divCss01'><asp:Label ID="FD03BLabel" runat="server" Text='<%# showFoodType(Eval("FD03B"))%>' /></div>
                            <div id='id03C' class='divCss02'><asp:Label ID="FD03CLabel" runat="server" Text='<%# showFoodType(Eval("FD03C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(04)%>>
                            <div id='id04' class='divCss01'>
                                      <asp:Label ID="FD04KindLabel" runat="server" Text='<%# Eval("出勤班別04")%>'   Visible ="false" />
                                      <asp:Label ID="FD04TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間04"))%>' />
                             </div>
                            <div id='id04B' class='divCss01'><asp:Label ID="FD04BLabel" runat="server" Text='<%# showFoodType(Eval("FD04B"))%>' /></div>
                            <div id='id04C' class='divCss02'><asp:Label ID="FD04CLabel" runat="server" Text='<%# showFoodType(Eval("FD04C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(05)%>>
                            <div id='id05' class='divCss01'>
                                      <asp:Label ID="FD05KindLabel" runat="server" Text='<%# Eval("出勤班別05")%>'   Visible ="false" />
                                      <asp:Label ID="FD05TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間05"))%>' />
                             </div>
                            <div id='id05B' class='divCss01'><asp:Label ID="FD05BLabel" runat="server" Text='<%# showFoodType(Eval("FD05B"))%>' /></div>
                            <div id='id05C' class='divCss02'><asp:Label ID="FD05CLabel" runat="server" Text='<%# showFoodType(Eval("FD05C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(06)%>>
                            <div id='id06' class='divCss01'>
                                      <asp:Label ID="FD06KindLabel" runat="server" Text='<%# Eval("出勤班別06")%>'   Visible ="false" />
                                      <asp:Label ID="FD06TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間06"))%>' />
                             </div>
                            <div id='id06B' class='divCss01'><asp:Label ID="FD06BLabel" runat="server" Text='<%# showFoodType(Eval("FD06B"))%>' /></div>
                            <div id='id06C' class='divCss02'><asp:Label ID="FD06CLabel" runat="server" Text='<%# showFoodType(Eval("FD06C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(07)%>>
                            <div id='id07' class='divCss01'>
                                      <asp:Label ID="FD07KindLabel" runat="server" Text='<%# Eval("出勤班別07")%>'   Visible ="false" />
                                      <asp:Label ID="FD07TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間07"))%>' />
                             </div>
                            <div id='id07B' class='divCss01'><asp:Label ID="FD07BLabel" runat="server" Text='<%# showFoodType(Eval("FD07B"))%>' /></div>
                            <div id='id07C' class='divCss02'><asp:Label ID="FD07CLabel" runat="server" Text='<%# showFoodType(Eval("FD07C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(08)%>>
                            <div id='id08' class='divCss01'>
                                      <asp:Label ID="FD08KindLabel" runat="server" Text='<%# Eval("出勤班別08")%>'   Visible ="false" />
                                      <asp:Label ID="FD08TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間08"))%>' />
                             </div>
                            <div id='id08B' class='divCss01'><asp:Label ID="FD08BLabel" runat="server" Text='<%# showFoodType(Eval("FD08B"))%>' /></div>
                            <div id='id08C' class='divCss02'><asp:Label ID="FD08CLabel" runat="server" Text='<%# showFoodType(Eval("FD08C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(09)%>>
                            <div id='id09' class='divCss01'>
                                      <asp:Label ID="FD09KindLabel" runat="server" Text='<%# Eval("出勤班別09")%>'   Visible ="false" />
                                      <asp:Label ID="FD09TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間09"))%>' />
                             </div>
                            <div id='id09B' class='divCss01'><asp:Label ID="FD09BLabel" runat="server" Text='<%# showFoodType(Eval("FD09B"))%>' /></div>
                            <div id='id09C' class='divCss02'><asp:Label ID="FD09CLabel" runat="server" Text='<%# showFoodType(Eval("FD09C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(10)%>>
                            <div id='id10' class='divCss01'>
                                      <asp:Label ID="FD10KindLabel" runat="server" Text='<%# Eval("出勤班別10")%>'   Visible ="false" />
                                      <asp:Label ID="FD10TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間10"))%>' />
                             </div>
                            <div id='id10B' class='divCss01'><asp:Label ID="FD10BLabel" runat="server" Text='<%# showFoodType(Eval("FD10B"))%>' /></div>
                            <div id='id10C' class='divCss02'><asp:Label ID="FD10CLabel" runat="server" Text='<%# showFoodType(Eval("FD10C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(11)%>>
                            <div id='id11' class='divCss01'>
                                      <asp:Label ID="FD11KindLabel" runat="server" Text='<%# Eval("出勤班別11")%>'   Visible ="false" />
                                      <asp:Label ID="FD11TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間11"))%>' />
                             </div>
                            <div id='id11B' class='divCss01'><asp:Label ID="FD11BLabel" runat="server" Text='<%# showFoodType(Eval("FD11B"))%>' /></div>
                            <div id='id11C' class='divCss02'><asp:Label ID="FD11CLabel" runat="server" Text='<%# showFoodType(Eval("FD11C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(12)%>>
                            <div id='id12' class='divCss01'>
                                      <asp:Label ID="FD12KindLabel" runat="server" Text='<%# Eval("出勤班別12")%>'   Visible ="false" />
                                      <asp:Label ID="FD12TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間12"))%>' />
                             </div>
                            <div id='id12B' class='divCss01'><asp:Label ID="FD12BLabel" runat="server" Text='<%# showFoodType(Eval("FD12B"))%>' /></div>
                            <div id='id12C' class='divCss02'><asp:Label ID="FD12CLabel" runat="server" Text='<%# showFoodType(Eval("FD12C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(13)%>>
                            <div id='id13' class='divCss01'>
                                      <asp:Label ID="FD13KindLabel" runat="server" Text='<%# Eval("出勤班別13")%>'   Visible ="false" />
                                      <asp:Label ID="FD13TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間13"))%>' />
                             </div>
                            <div id='id13B' class='divCss01'><asp:Label ID="FD13BLabel" runat="server" Text='<%# showFoodType(Eval("FD13B"))%>' /></div>
                            <div id='id13C' class='divCss02'><asp:Label ID="FD13CLabel" runat="server" Text='<%# showFoodType(Eval("FD13C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(14)%>>
                            <div id='id14' class='divCss01'>
                                      <asp:Label ID="FD14KindLabel" runat="server" Text='<%# Eval("出勤班別14")%>'   Visible ="false" />
                                      <asp:Label ID="FD14TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間14"))%>' />
                             </div>
                            <div id='id14B' class='divCss01'><asp:Label ID="FD14BLabel" runat="server" Text='<%# showFoodType(Eval("FD14B"))%>' /></div>
                            <div id='id14C' class='divCss02'><asp:Label ID="FD14CLabel" runat="server" Text='<%# showFoodType(Eval("FD14C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(15)%>>
                            <div id='id15' class='divCss01'>
                                      <asp:Label ID="FD15KindLabel" runat="server" Text='<%# Eval("出勤班別15")%>'   Visible ="false" />
                                      <asp:Label ID="FD15TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間15"))%>' />
                             </div>
                            <div id='id15B' class='divCss01'><asp:Label ID="FD15BLabel" runat="server" Text='<%# showFoodType(Eval("FD15B"))%>' /></div>
                            <div id='id15C' class='divCss02'><asp:Label ID="FD15CLabel" runat="server" Text='<%# showFoodType(Eval("FD15C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(16)%>>
                            <div id='id16' class='divCss01'>
                                      <asp:Label ID="FD16KindLabel" runat="server" Text='<%# Eval("出勤班別16")%>'   Visible ="false" />
                                      <asp:Label ID="FD16TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間16"))%>' />
                             </div>
                            <div id='id16B' class='divCss01'><asp:Label ID="FD16BLabel" runat="server" Text='<%# showFoodType(Eval("FD16B"))%>' /></div>
                            <div id='id16C' class='divCss02'><asp:Label ID="FD16CLabel" runat="server" Text='<%# showFoodType(Eval("FD16C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(17)%>>
                            <div id='id17' class='divCss01'>
                                      <asp:Label ID="FD17KindLabel" runat="server" Text='<%# Eval("出勤班別17")%>'   Visible ="false" />
                                      <asp:Label ID="FD17TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間17"))%>' />
                             </div>
                            <div id='id17B' class='divCss01'><asp:Label ID="FD17BLabel" runat="server" Text='<%# showFoodType(Eval("FD17B"))%>' /></div>
                            <div id='id17C' class='divCss02'><asp:Label ID="FD17CLabel" runat="server" Text='<%# showFoodType(Eval("FD17C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(18)%>>
                            <div id='id18' class='divCss01'>
                                      <asp:Label ID="FD18KindLabel" runat="server" Text='<%# Eval("出勤班別18")%>'   Visible ="false" />
                                      <asp:Label ID="FD18TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間18"))%>' />
                             </div>
                            <div id='id18B' class='divCss01'><asp:Label ID="FD18BLabel" runat="server" Text='<%# showFoodType(Eval("FD18B"))%>' /></div>
                            <div id='id18C' class='divCss02'><asp:Label ID="FD18CLabel" runat="server" Text='<%# showFoodType(Eval("FD18C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(19)%>>
                            <div id='id19' class='divCss01'>
                                      <asp:Label ID="FD19KindLabel" runat="server" Text='<%# Eval("出勤班別19")%>'   Visible ="false" />
                                      <asp:Label ID="FD19TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間19"))%>' />
                             </div>
                            <div id='id19B' class='divCss01'><asp:Label ID="FD19BLabel" runat="server" Text='<%# showFoodType(Eval("FD19B"))%>' /></div>
                            <div id='id19C' class='divCss02'><asp:Label ID="FD19CLabel" runat="server" Text='<%# showFoodType(Eval("FD19C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(20)%>>
                            <div id='id20' class='divCss01'>
                                      <asp:Label ID="FD20KindLabel" runat="server" Text='<%# Eval("出勤班別20")%>'   Visible ="false" />
                                      <asp:Label ID="FD20TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間20"))%>' />
                             </div>
                            <div id='id20B' class='divCss01'><asp:Label ID="FD20BLabel" runat="server" Text='<%# showFoodType(Eval("FD20B"))%>' /></div>
                            <div id='id20C' class='divCss02'><asp:Label ID="FD20CLabel" runat="server" Text='<%# showFoodType(Eval("FD20C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(21)%>>
                            <div id='id21' class='divCss01'>
                                      <asp:Label ID="FD21KindLabel" runat="server" Text='<%# Eval("出勤班別21")%>'   Visible ="false" />
                                      <asp:Label ID="FD21TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間21"))%>' />
                             </div>
                            <div id='id21B' class='divCss01'><asp:Label ID="FD21BLabel" runat="server" Text='<%# showFoodType(Eval("FD21B"))%>' /></div>
                            <div id='id21C' class='divCss02'><asp:Label ID="FD21CLabel" runat="server" Text='<%# showFoodType(Eval("FD21C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(22)%>>
                            <div id='id22' class='divCss01'>
                                      <asp:Label ID="FD22KindLabel" runat="server" Text='<%# Eval("出勤班別22")%>'   Visible ="false" />
                                      <asp:Label ID="FD22TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間22"))%>' />
                             </div>
                            <div id='id22B' class='divCss01'><asp:Label ID="FD22BLabel" runat="server" Text='<%# showFoodType(Eval("FD22B"))%>' /></div>
                            <div id='id22C' class='divCss02'><asp:Label ID="FD22CLabel" runat="server" Text='<%# showFoodType(Eval("FD22C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(23)%>>
                            <div id='id23' class='divCss01'>
                                      <asp:Label ID="FD23KindLabel" runat="server" Text='<%# Eval("出勤班別23")%>'   Visible ="false" />
                                      <asp:Label ID="FD23TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間23"))%>' />
                             </div>
                            <div id='id23B' class='divCss01'><asp:Label ID="FD23BLabel" runat="server" Text='<%# showFoodType(Eval("FD23B"))%>' /></div>
                            <div id='id23C' class='divCss02'><asp:Label ID="FD23CLabel" runat="server" Text='<%# showFoodType(Eval("FD23C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(24)%>>
                            <div id='id24' class='divCss01'>
                                      <asp:Label ID="FD24KindLabel" runat="server" Text='<%# Eval("出勤班別24")%>'   Visible ="false" />
                                      <asp:Label ID="FD24TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間24"))%>' />
                             </div>
                            <div id='id24B' class='divCss01'><asp:Label ID="FD24BLabel" runat="server" Text='<%# showFoodType(Eval("FD24B"))%>' /></div>
                            <div id='id24C' class='divCss02'><asp:Label ID="FD24CLabel" runat="server" Text='<%# showFoodType(Eval("FD24C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(25)%>>
                            <div id='id25' class='divCss01'>
                                      <asp:Label ID="FD25KindLabel" runat="server" Text='<%# Eval("出勤班別25")%>'   Visible ="false" />
                                      <asp:Label ID="FD25TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間25"))%>' />
                             </div>
                            <div id='id25B' class='divCss01'><asp:Label ID="FD25BLabel" runat="server" Text='<%# showFoodType(Eval("FD25B"))%>' /></div>
                            <div id='id25C' class='divCss02'><asp:Label ID="FD25CLabel" runat="server" Text='<%# showFoodType(Eval("FD25C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(26)%>>
                            <div id='id26' class='divCss01'>
                                      <asp:Label ID="FD26KindLabel" runat="server" Text='<%# Eval("出勤班別26")%>'   Visible ="false" />
                                      <asp:Label ID="FD26TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間26"))%>' />
                             </div>
                            <div id='id26B' class='divCss01'><asp:Label ID="FD26BLabel" runat="server" Text='<%# showFoodType(Eval("FD26B"))%>' /></div>
                            <div id='id26C' class='divCss02'><asp:Label ID="FD26CLabel" runat="server" Text='<%# showFoodType(Eval("FD26C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(27)%>>
                            <div id='id27' class='divCss01'>
                                      <asp:Label ID="FD27KindLabel" runat="server" Text='<%# Eval("出勤班別27")%>'   Visible ="false" />
                                      <asp:Label ID="FD27TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間27"))%>' />
                             </div>
                            <div id='id27B' class='divCss01'><asp:Label ID="FD27BLabel" runat="server" Text='<%# showFoodType(Eval("FD27B"))%>' /></div>
                            <div id='id27C' class='divCss02'><asp:Label ID="FD27CLabel" runat="server" Text='<%# showFoodType(Eval("FD27C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(28)%>>
                            <div id='id28' class='divCss01'>
                                      <asp:Label ID="FD28KindLabel" runat="server" Text='<%# Eval("出勤班別28")%>'   Visible ="false" />
                                      <asp:Label ID="FD28TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間28"))%>' />
                             </div>
                            <div id='id28B' class='divCss01'><asp:Label ID="FD28BLabel" runat="server" Text='<%# showFoodType(Eval("FD28B"))%>' /></div>
                            <div id='id28C' class='divCss02'><asp:Label ID="FD28CLabel" runat="server" Text='<%# showFoodType(Eval("FD28C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(29)%>>
                            <div id='id29' class='divCss01'>
                                      <asp:Label ID="FD29KindLabel" runat="server" Text='<%# Eval("出勤班別29")%>'   Visible ="false" />
                                      <asp:Label ID="FD29TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間29"))%>' />
                             </div>
                            <div id='id29B' class='divCss01'><asp:Label ID="FD29BLabel" runat="server" Text='<%# showFoodType(Eval("FD29B"))%>' /></div>
                            <div id='id29C' class='divCss02'><asp:Label ID="FD29CLabel" runat="server" Text='<%# showFoodType(Eval("FD29C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(30)%>>
                            <div id='id30' class='divCss01'>
                                      <asp:Label ID="FD30KindLabel" runat="server" Text='<%# Eval("出勤班別30")%>'   Visible ="false" />
                                      <asp:Label ID="FD30TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間30"))%>' />
                             </div>
                            <div id='id30B' class='divCss01'><asp:Label ID="FD30BLabel" runat="server" Text='<%# showFoodType(Eval("FD30B"))%>' /></div>
                            <div id='id30C' class='divCss02'><asp:Label ID="FD30CLabel" runat="server" Text='<%# showFoodType(Eval("FD30C")) %>' /></div>
                        </td>
                        <td <%#  showHolidayColor(31)%>>
                            <div id='id31' class='divCss01'>
                                      <asp:Label ID="FD31KindLabel" runat="server" Text='<%# Eval("出勤班別31")%>'   Visible ="false" />
                                      <asp:Label ID="FD31TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間31"))%>' />
                             </div>
                            <div id='id31B' class='divCss01'><asp:Label ID="FD31BLabel" runat="server" Text='<%# showFoodType(Eval("FD31B"))%>' /></div>
                            <div id='id31C' class='divCss02'><asp:Label ID="FD31CLabel" runat="server" Text='<%# showFoodType(Eval("FD31C")) %>' /></div>
                        </td>

                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                        <th runat="server"><%=showQueryYearMonthInfo()%></th>
                                        <th runat="server">單位/<br/>置放 </th>
                                        <th runat="server">職編/<BR>姓名/<BR>上月訂餐</th>
                                        <th runat="server">修改紀錄</th>
                                        <th runat="server">批次處理<br/>工作日當餐</th>
                                        <th runat="server"><%= ModTools.showSpace(9)%></th>

                                        <th runat="server" ><% = showDayInfo(1)%></th>
                                        <th runat="server" ><% = showDayInfo(2)%></th>
                                        <th runat="server" ><% = showDayInfo(3)%></th>
                                        <th runat="server" ><% = showDayInfo(4)%></th>
                                        <th runat="server" ><% = showDayInfo(5)%></th>
                                        <th runat="server" ><% = showDayInfo(6)%></th>
                                        <th runat="server" ><% = showDayInfo(7)%></th>
                                        <th runat="server" ><% = showDayInfo(8)%></th>
                                        <th runat="server" ><% = showDayInfo(9)%></th>
                                        <th runat="server" ><% = showDayInfo(10)%></th>
                                        <th runat="server" ><% = showDayInfo(11)%></th>
                                        <th runat="server" ><% = showDayInfo(12)%></th>
                                        <th runat="server" ><% = showDayInfo(13)%></th>
                                        <th runat="server" ><% = showDayInfo(14)%></th>
                                        <th runat="server" ><% = showDayInfo(15)%></th>
                                        <th runat="server" ><% = showDayInfo(16)%></th>
                                        <th runat="server" ><% = showDayInfo(17)%></th>
                                        <th runat="server" ><% = showDayInfo(18)%></th>
                                        <th runat="server" ><% = showDayInfo(19)%></th>
                                        <th runat="server" ><% = showDayInfo(20)%></th>
                                        <th runat="server" ><% = showDayInfo(21)%></th>
                                        <th runat="server" ><% = showDayInfo(22)%></th>
                                        <th runat="server" ><% = showDayInfo(23)%></th>
                                        <th runat="server" ><% = showDayInfo(24)%></th>
                                        <th runat="server" ><% = showDayInfo(25)%></th>
                                        <th runat="server" ><% = showDayInfo(26)%></th>
                                        <th runat="server" ><% = showDayInfo(27)%></th>
                                        <th runat="server" ><% = showDayInfo(28)%></th>
                                        <th runat="server" ><% = showDayInfo(29)%></th>
                                        <th runat="server" ><% = showDayInfo(30)%></th>
                                        <th runat="server" ><% = showDayInfo(31)%></th>

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
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯"  Enabled ='<%# showThisMonthCanEdit(Eval("FDTIM1"), Eval("FDTIM2")) %>'/>
                        </td>

                        <td>
                            <asp:Label ID="FD005Label" runat="server" Text='<%# Eval("FD005") %>' />
                            <BR><asp:Label ID="FD004Label" runat="server" Text='<%# Eval("FD004") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FD001Label" runat="server" Text='<%# Eval("FD001") %>' />
                            <asp:HiddenField ID="hfCDBMemberName" runat="server" Value='<%# Eval("CDBMemberName")%>' />
                            <BR><asp:Label ID="FD002Label" runat="server" Text='<%# Eval("FD002") %>' />
                        </td>

                        <td>
                            <asp:Label ID="FDSaveInfoLabel" runat="server" Text='<%# showSaveInfo(Eval("FDSDTE"), Eval("FDSTIM"), Eval("FDSDEV"), Eval("FDSOPR") ) %>' />
                        </td>

                        <td>
                            
                        </td>

                        <td>
                            <asp:Label ID="FD00Label" runat="server" Text="出勤" /><br>
                            <asp:Label ID="FD00BLabel" runat="server" Text="午餐" /><br>
                            <asp:Label ID="FD00CLabel" runat="server" Text="晚餐" />
                        </td>

                        <td <%#  showHolidayColor(01)%>>
                            <asp:Label ID="FD01KindLabel" runat="server" Text='<%# Eval("出勤班別01")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD01TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間01"))%>' /><br>
                            <asp:Label ID="FD01BLabel" runat="server" Text='<%# Eval("FD01B") %>' /><br>
                            <asp:Label ID="FD01CLabel" runat="server" Text='<%# Eval("FD01C") %>' />
                        </td>
                        <td <%#  showHolidayColor(02)%>>
                            <asp:Label ID="FD02KindLabel" runat="server" Text='<%# Eval("出勤班別02")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD02TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間02"))%>' /><br>
                            <asp:Label ID="FD02BLabel" runat="server" Text='<%# Eval("FD02B") %>' /><br>
                            <asp:Label ID="FD02CLabel" runat="server" Text='<%# Eval("FD02C") %>' />
                        </td>
                        <td <%#  showHolidayColor(03)%>>
                            <asp:Label ID="FD03KindLabel" runat="server" Text='<%# Eval("出勤班別03")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD03TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間03"))%>' /><br>
                            <asp:Label ID="FD03BLabel" runat="server" Text='<%# Eval("FD03B") %>' /><br>
                            <asp:Label ID="FD03CLabel" runat="server" Text='<%# Eval("FD03C") %>' />
                        </td>
                        <td <%#  showHolidayColor(04)%>>
                            <asp:Label ID="FD04KindLabel" runat="server" Text='<%# Eval("出勤班別04")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD04TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間04"))%>' /><br>
                            <asp:Label ID="FD04BLabel" runat="server" Text='<%# Eval("FD04B") %>' /><br>
                            <asp:Label ID="FD04CLabel" runat="server" Text='<%# Eval("FD04C") %>' />
                        </td>
                        <td <%#  showHolidayColor(05)%>>
                            <asp:Label ID="FD05KindLabel" runat="server" Text='<%# Eval("出勤班別05")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD05TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間05"))%>' /><br>
                            <asp:Label ID="FD05BLabel" runat="server" Text='<%# Eval("FD05B") %>' /><br>
                            <asp:Label ID="FD05CLabel" runat="server" Text='<%# Eval("FD05C") %>' />
                        </td>
                        <td <%#  showHolidayColor(06)%>>
                            <asp:Label ID="FD06KindLabel" runat="server" Text='<%# Eval("出勤班別06")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD06TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間06"))%>' /><br>
                            <asp:Label ID="FD06BLabel" runat="server" Text='<%# Eval("FD06B") %>' /><br>
                            <asp:Label ID="FD06CLabel" runat="server" Text='<%# Eval("FD06C") %>' />
                        </td>
                        <td <%#  showHolidayColor(07)%>>
                            <asp:Label ID="FD07KindLabel" runat="server" Text='<%# Eval("出勤班別07")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD07TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間07"))%>' /><br>
                            <asp:Label ID="FD07BLabel" runat="server" Text='<%# Eval("FD07B") %>' /><br>
                            <asp:Label ID="FD07CLabel" runat="server" Text='<%# Eval("FD07C") %>' />
                        </td>
                        <td <%#  showHolidayColor(08)%>>
                            <asp:Label ID="FD08KindLabel" runat="server" Text='<%# Eval("出勤班別08")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD08TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間08"))%>' /><br>
                            <asp:Label ID="FD08BLabel" runat="server" Text='<%# Eval("FD08B") %>' /><br>
                            <asp:Label ID="FD08CLabel" runat="server" Text='<%# Eval("FD08C") %>' />
                        </td>
                        <td <%#  showHolidayColor(09)%>>
                            <asp:Label ID="FD09KindLabel" runat="server" Text='<%# Eval("出勤班別09")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD09TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間09"))%>' /><br>
                            <asp:Label ID="FD09BLabel" runat="server" Text='<%# Eval("FD09B") %>' /><br>
                            <asp:Label ID="FD09CLabel" runat="server" Text='<%# Eval("FD09C") %>' />
                        </td>
                        <td <%#  showHolidayColor(10)%>>
                            <asp:Label ID="FD10KindLabel" runat="server" Text='<%# Eval("出勤班別10")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD10TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間10"))%>' /><br>
                            <asp:Label ID="FD10BLabel" runat="server" Text='<%# Eval("FD10B") %>' /><br>
                            <asp:Label ID="FD10CLabel" runat="server" Text='<%# Eval("FD10C") %>' />
                        </td>
                        <td <%#  showHolidayColor(11)%>>
                            <asp:Label ID="FD11KindLabel" runat="server" Text='<%# Eval("出勤班別11")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD11TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間11"))%>' /><br>
                            <asp:Label ID="FD11BLabel" runat="server" Text='<%# Eval("FD11B") %>' /><br>
                            <asp:Label ID="FD11CLabel" runat="server" Text='<%# Eval("FD11C") %>' />
                        </td>
                        <td <%#  showHolidayColor(12)%>>
                            <asp:Label ID="FD12KindLabel" runat="server" Text='<%# Eval("出勤班別12")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD12TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間12"))%>' /><br>
                            <asp:Label ID="FD12BLabel" runat="server" Text='<%# Eval("FD12B") %>' /><br>
                            <asp:Label ID="FD12CLabel" runat="server" Text='<%# Eval("FD12C") %>' />
                        </td>
                        <td <%#  showHolidayColor(13)%>>
                            <asp:Label ID="FD13KindLabel" runat="server" Text='<%# Eval("出勤班別13")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD13TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間13"))%>' /><br>
                            <asp:Label ID="FD13BLabel" runat="server" Text='<%# Eval("FD13B") %>' /><br>
                            <asp:Label ID="FD13CLabel" runat="server" Text='<%# Eval("FD13C") %>' />
                        </td>
                        <td <%#  showHolidayColor(14)%>>
                            <asp:Label ID="FD14KindLabel" runat="server" Text='<%# Eval("出勤班別14")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD14TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間14"))%>' /><br>
                            <asp:Label ID="FD14BLabel" runat="server" Text='<%# Eval("FD14B") %>' /><br>
                            <asp:Label ID="FD14CLabel" runat="server" Text='<%# Eval("FD14C") %>' />
                        </td>
                        <td <%#  showHolidayColor(15)%>>
                            <asp:Label ID="FD15KindLabel" runat="server" Text='<%# Eval("出勤班別15")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD15TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間15"))%>' /><br>
                            <asp:Label ID="FD15BLabel" runat="server" Text='<%# Eval("FD15B") %>' /><br>
                            <asp:Label ID="FD15CLabel" runat="server" Text='<%# Eval("FD15C") %>' />
                        </td>
                        <td <%#  showHolidayColor(16)%>>
                            <asp:Label ID="FD16KindLabel" runat="server" Text='<%# Eval("出勤班別16")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD16TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間16"))%>' /><br>
                            <asp:Label ID="FD16BLabel" runat="server" Text='<%# Eval("FD16B") %>' /><br>
                            <asp:Label ID="FD16CLabel" runat="server" Text='<%# Eval("FD16C") %>' />
                        </td>
                        <td <%#  showHolidayColor(17)%>>
                            <asp:Label ID="FD17KindLabel" runat="server" Text='<%# Eval("出勤班別17")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD17TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間17"))%>' /><br>
                            <asp:Label ID="FD17BLabel" runat="server" Text='<%# Eval("FD17B") %>' /><br>
                            <asp:Label ID="FD17CLabel" runat="server" Text='<%# Eval("FD17C") %>' />
                        </td>
                        <td <%#  showHolidayColor(18)%>>
                            <asp:Label ID="FD18KindLabel" runat="server" Text='<%# Eval("出勤班別18")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD18TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間18"))%>' /><br>
                            <asp:Label ID="FD18BLabel" runat="server" Text='<%# Eval("FD18B") %>' /><br>
                            <asp:Label ID="FD18CLabel" runat="server" Text='<%# Eval("FD18C") %>' />
                        </td>
                        <td <%#  showHolidayColor(19)%>>
                            <asp:Label ID="FD19KindLabel" runat="server" Text='<%# Eval("出勤班別19")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD19TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間19"))%>' /><br>
                            <asp:Label ID="FD19BLabel" runat="server" Text='<%# Eval("FD19B") %>' /><br>
                            <asp:Label ID="FD19CLabel" runat="server" Text='<%# Eval("FD19C") %>' />
                        </td>
                        <td <%#  showHolidayColor(20)%>>
                            <asp:Label ID="FD20KindLabel" runat="server" Text='<%# Eval("出勤班別20")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD20TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間20"))%>' /><br>
                            <asp:Label ID="FD20BLabel" runat="server" Text='<%# Eval("FD20B") %>' /><br>
                            <asp:Label ID="FD20CLabel" runat="server" Text='<%# Eval("FD20C") %>' />
                        </td>
                        <td <%#  showHolidayColor(21)%>>
                            <asp:Label ID="FD21KindLabel" runat="server" Text='<%# Eval("出勤班別21")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD21TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間21"))%>' /><br>
                            <asp:Label ID="FD21BLabel" runat="server" Text='<%# Eval("FD21B") %>' /><br>
                            <asp:Label ID="FD21CLabel" runat="server" Text='<%# Eval("FD21C") %>' />
                        </td>
                        <td <%#  showHolidayColor(22)%>>
                            <asp:Label ID="FD22KindLabel" runat="server" Text='<%# Eval("出勤班別22")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD22TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間22"))%>' /><br>
                            <asp:Label ID="FD22BLabel" runat="server" Text='<%# Eval("FD22B") %>' /><br>
                            <asp:Label ID="FD22CLabel" runat="server" Text='<%# Eval("FD22C") %>' />
                        </td>
                        <td <%#  showHolidayColor(23)%>>
                            <asp:Label ID="FD23KindLabel" runat="server" Text='<%# Eval("出勤班別23")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD23TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間23"))%>' /><br>
                            <asp:Label ID="FD23BLabel" runat="server" Text='<%# Eval("FD23B") %>' /><br>
                            <asp:Label ID="FD23CLabel" runat="server" Text='<%# Eval("FD23C") %>' />
                        </td>
                        <td <%#  showHolidayColor(24)%>>
                            <asp:Label ID="FD24KindLabel" runat="server" Text='<%# Eval("出勤班別24")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD24TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間24"))%>' /><br>
                            <asp:Label ID="FD24BLabel" runat="server" Text='<%# Eval("FD24B") %>' /><br>
                            <asp:Label ID="FD24CLabel" runat="server" Text='<%# Eval("FD24C") %>' />
                        </td>
                        <td <%#  showHolidayColor(25)%>>
                            <asp:Label ID="FD25KindLabel" runat="server" Text='<%# Eval("出勤班別25")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD25TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間25"))%>' /><br>
                            <asp:Label ID="FD25BLabel" runat="server" Text='<%# Eval("FD25B") %>' /><br>
                            <asp:Label ID="FD25CLabel" runat="server" Text='<%# Eval("FD25C") %>' />
                        </td>
                        <td <%#  showHolidayColor(26)%>>
                            <asp:Label ID="FD26KindLabel" runat="server" Text='<%# Eval("出勤班別26")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD26TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間26"))%>' /><br>
                            <asp:Label ID="FD26BLabel" runat="server" Text='<%# Eval("FD26B") %>' /><br>
                            <asp:Label ID="FD26CLabel" runat="server" Text='<%# Eval("FD26C") %>' />
                        </td>
                        <td <%#  showHolidayColor(27)%>>
                            <asp:Label ID="FD27KindLabel" runat="server" Text='<%# Eval("出勤班別27")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD27TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間27"))%>' /><br>
                            <asp:Label ID="FD27BLabel" runat="server" Text='<%# Eval("FD27B") %>' /><br>
                            <asp:Label ID="FD27CLabel" runat="server" Text='<%# Eval("FD27C") %>' />
                        </td>
                        <td <%#  showHolidayColor(28)%>>
                            <asp:Label ID="FD28KindLabel" runat="server" Text='<%# Eval("出勤班別28")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD28TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間28"))%>' /><br>
                            <asp:Label ID="FD28BLabel" runat="server" Text='<%# Eval("FD28B") %>' /><br>
                            <asp:Label ID="FD28CLabel" runat="server" Text='<%# Eval("FD28C") %>' />
                        </td>
                        <td <%#  showHolidayColor(29)%>>
                            <asp:Label ID="FD29KindLabel" runat="server" Text='<%# Eval("出勤班別29")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD29TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間29"))%>' /><br>
                            <asp:Label ID="FD29BLabel" runat="server" Text='<%# Eval("FD29B") %>' /><br>
                            <asp:Label ID="FD29CLabel" runat="server" Text='<%# Eval("FD29C") %>' />
                        </td>
                        <td <%#  showHolidayColor(30)%>>
                            <asp:Label ID="FD30KindLabel" runat="server" Text='<%# Eval("出勤班別30")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD30TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間30"))%>' /><br>
                            <asp:Label ID="FD30BLabel" runat="server" Text='<%# Eval("FD30B") %>' /><br>
                            <asp:Label ID="FD30CLabel" runat="server" Text='<%# Eval("FD30C") %>' />
                        </td>
                        <td <%#  showHolidayColor(31)%>>
                            <asp:Label ID="FD31KindLabel" runat="server" Text='<%# Eval("出勤班別31")%>'   Visible ="false" /><br>
                            <asp:Label ID="FD31TimeLabel" runat="server" Text='<%# show出勤資料( Eval("出勤時間31"))%>' /><br>
                            <asp:Label ID="FD31BLabel" runat="server" Text='<%# Eval("FD31B") %>' /><br>
                            <asp:Label ID="FD31CLabel" runat="server" Text='<%# Eval("FD31C") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>


































                    <%--Excel檔產生 End ------------------------------------------------------------------------------%>
                </ContentTemplate>

            </cc1:TabPanel>

            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Width="100%">
                <HeaderTemplate>修改紀錄</HeaderTemplate>

                <ContentTemplate>
                    <asp:Table BorderWidth="1px" ID="tableFoodLog" runat="server" />
                </ContentTemplate>

            </cc1:TabPanel>
        </cc1:TabContainer>


    </asp:View>

</asp:MultiView>


<asp:HiddenField ID="hfLoginUser" runat="server" />
<asp:HiddenField ID="hfSQL_Fodm01pf" runat="server" />
<asp:HiddenField ID="hfQueryDate_Last" runat="server" />
<asp:HiddenField ID="hfQueryDate_Now" runat="server" />
<asp:HiddenField ID="hfQueryUnit" runat="server" />
<asp:HiddenField ID="hfQueryID" runat="server" />


<asp:ObjectDataSource ID="odsSearchResult" runat="server" SelectMethod="Search" TypeName="Personnel.FoodOrderInput" UpdateMethod="Update" DataObjectTypeName="CompanyORMDB.FOD100LB.FODM01PF">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL_Fodm01pf" Name="fromSQL_Fodm01pf" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQueryDate_Last" Name="fromQueryDate_Last" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQueryDate_Now" Name="fromQueryDate_Now" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQueryUnit" Name="fromQueryUnit" PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="hfQueryID" Name="fromQueryID" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>



<asp:ObjectDataSource ID="odsSearchResult2Log" runat="server" SelectMethod="Search2Log" TypeName="Personnel.FoodOrderInput">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQL_Fodm01pf" Name="fromSQL_Fodm01pf" PropertyName="Value" Type="String" />
    </SelectParameters>

</asp:ObjectDataSource>

