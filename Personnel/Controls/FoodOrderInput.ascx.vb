Imports UCAjaxServerControl1

Public Class FoodOrderInput
    Inherits System.Web.UI.UserControl

    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New CompanyORMDB.AS400DateConverter
    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

    Private WP_QueryDate As String
    Private WP_QueryUnit As String
    Private WP_QueryID As String

    Private WP_IsBatchFoodType As Boolean

    Const C_Day_Min As Integer = 1
    Const C_Day_Max As Integer = 31

#Region "ViewState：UnitChange_Input"
    Const C_UnitChange_Input As String = "UnitChange_Input"
    Private ReadOnly Property WP_DataTableOfUnitChange_Input As DataTable
        Get
            If ViewState(C_UnitChange_Input) Is Nothing Then
                ViewState(C_UnitChange_Input) = WP_ClsSystemNote.getLev3("伙食", "單位轉換_輸入")
            End If
            Return ViewState(C_UnitChange_Input)
        End Get
    End Property
#End Region


#Region "ViewState：系統資訊"

    Const C_SysLimitTimeB As String = "SysLimitTimeB"
    Private ReadOnly Property WP_LimitTimeB As String
        Get
            If String.IsNullOrEmpty(ViewState(C_SysLimitTimeB)) = True Then
                ViewState(C_SysLimitTimeB) = WP_ClsSystemNote.getLev4Content("伙食", "訂餐時段限制", "午餐")
            End If
            Return ViewState(C_SysLimitTimeB)
        End Get
    End Property

    Const C_SysLimitTimeC As String = "SysLimitTimeC"
    Private ReadOnly Property WP_LimitTimeC As String
        Get
            If String.IsNullOrEmpty(ViewState(C_SysLimitTimeC)) = True Then
                ViewState(C_SysLimitTimeC) = WP_ClsSystemNote.getLev4Content("伙食", "訂餐時段限制", "晚餐")
            End If
            Return ViewState(C_SysLimitTimeC)
        End Get
    End Property

    Const C_SysLimitTimeHR As String = "SysLimitTimeHR"
    Private ReadOnly Property WP_LimitTimeHR As String
        Get
            If String.IsNullOrEmpty(ViewState(C_SysLimitTimeHR)) = True Then
                ViewState(C_SysLimitTimeHR) = WP_ClsSystemNote.getLev4Content("伙食", "訂餐時段限制", "行政處專用_延遲分鐘")
            End If
            Return ViewState(C_SysLimitTimeHR)
        End Get
    End Property

    Const C_SysLimitTimeHoliday As String = "SysLimitTimeHoliday"
    Private ReadOnly Property WP_LimitTimeHoliday As String
        Get
            If String.IsNullOrEmpty(ViewState(C_SysLimitTimeHoliday)) = True Then
                ViewState(C_SysLimitTimeHoliday) = WP_ClsSystemNote.getLev4Content("伙食", "訂餐時段限制", "國定假日")
            End If
            Return ViewState(C_SysLimitTimeHoliday)
        End Get
    End Property

    Const C_SysSpace As String = "SysSpace"
    Private ReadOnly Property WP_DataTableOfSpace As DataTable
        Get
            If ViewState(C_SysSpace) Is Nothing Then
                Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery("SELECT *  FROM @#FOD100LB.FODPLCPF  ORDER BY LENGTH(fdplc1), fdplc1 ")
                queryDataTable.Columns.Add(WP_ClsSystemNote.Display_Lable, Type.GetType("System.String"), "fdplc1+'：'+ fdplc2")

                ViewState(C_SysSpace) = queryDataTable
            End If
            Return ViewState(C_SysSpace)
        End Get
    End Property

    Const C_SysFoodType As String = "SysFoodType"
    Private ReadOnly Property WP_DataTableOfFoodType As DataTable
        Get
            If ViewState(C_SysFoodType) Is Nothing Then
                ViewState(C_SysFoodType) = WP_AS400Adapter.SelectQuery("SELECT v1.* , fdsup1 || '：' || fdsup2 AS " & WP_ClsSystemNote.Display_Lable & "  FROM @#fod100lb.FODSUPPF v1  WHERE fdsup2<>''")
            End If
            Return ViewState(C_SysFoodType)
        End Get
    End Property

    Const C_SysFoodKind As String = "SysFoodKind"
    Private ReadOnly Property WP_DataTableOfFoodKind As DataTable
        Get
            If ViewState(C_SysFoodKind) Is Nothing Then
                ViewState(C_SysFoodKind) = WP_ClsSystemNote.getLev3("伙食", "餐點餐別")
            End If
            Return ViewState(C_SysFoodKind)
        End Get
    End Property

#End Region

#Region "ViewState：使用者登入資訊"
    Const C_LoginUserName As String = "LoginUserName"
    Const C_LoginUserID As String = "LoginUserID"
    Const C_LoginUserUnit As String = "LoginUserUnit"
    Const C_LoginUserType As String = "LoginUserType"
    Const C_View2btnSearch As String = "View2btnSearch"

    Private Property WP_LoginUserName As String
        Get
            If ViewState(C_LoginUserName) Is Nothing Then
                Return ""
            Else
                Return ViewState(C_LoginUserName).ToString
            End If
        End Get

        Set(value As String)
            ViewState(C_LoginUserName) = value
        End Set
    End Property

    Private Property WP_LoginUserID As String
        Get
            If ViewState(C_LoginUserID) Is Nothing Then
                Return ""
            Else
                Return ViewState(C_LoginUserID).ToString
            End If
        End Get

        Set(value As String)
            ViewState(C_LoginUserID) = value
        End Set
    End Property

    Private Property WP_LoginUserUnit As String
        Get
            If ViewState(C_LoginUserUnit) Is Nothing Then
                Return ""
            Else
                Return ViewState(C_LoginUserUnit).ToString
            End If
        End Get

        Set(value As String)
            ViewState(C_LoginUserUnit) = value
        End Set
    End Property

    Private Property WP_LoginUserType As Integer
        Get
            If ViewState(C_LoginUserType) Is Nothing Then
                Return LoginUserType_Enum.查詢_個人
            Else
                Return ViewState(C_LoginUserType)
            End If
        End Get

        Set(value As Integer)
            ViewState(C_LoginUserType) = value
        End Set
    End Property

    Private Function WP_LoginUserType_Code1() As LoginUserTypeCode1_Enum
        Return WP_LoginUserType \ C_LoginUserTypeCodeFix
    End Function

    Private Function WP_LoginUserType_Code2() As LoginUserTypeCode2_Enum
        Return WP_LoginUserType Mod C_LoginUserTypeCodeFix
    End Function

    Enum LoginUserType_Enum

        查詢_個人 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.個人
        查詢_同單位 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.同單位
        查詢_跨單位_一般 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_一般
        查詢_跨單位_程式人員專用 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_程式人員專用

        查詢_跨單位_行政處專用_一般 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_行政處專用_一般
        查詢_跨單位_行政處專用_特殊 = LoginUserTypeCode1_Enum.查詢 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_行政處專用_特殊



        編修_個人 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.個人
        編修_同單位 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.同單位

        '時間限制：當日當餐『時間期限』前可修改
        編修_跨單位_一般 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_一般
        編修_跨單位_程式人員專用 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_程式人員專用

        '時間限制：當日當餐『時間期限』後加『緩衝時間』可修改
        編修_跨單位_行政處專用_一般 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_行政處專用_一般

        '時間限制：當月『關帳前』可修改
        編修_跨單位_行政處專用_特殊 = LoginUserTypeCode1_Enum.編修 * C_LoginUserTypeCodeFix + LoginUserTypeCode2_Enum.跨單位_行政處專用_特殊
    End Enum

    Const C_LoginUserTypeCodeFix As Integer = 100
    Enum LoginUserTypeCode1_Enum
        查詢 = 1
        編修 = 2
    End Enum

    Enum LoginUserTypeCode2_Enum
        個人 = 1
        同單位 = 2
        跨單位_一般 = 3

        跨單位_行政處專用_一般 = 4
        跨單位_行政處專用_特殊 = 5
        跨單位_程式人員專用 = 6
    End Enum

    Private Function LoginUserType_Name(ByVal fromLoginUserType_Enum As LoginUserType_Enum) As String
        Select Case fromLoginUserType_Enum
            Case LoginUserType_Enum.查詢_個人
                Return "查詢_個人"
            Case LoginUserType_Enum.查詢_同單位
                Return "查詢_同單位"
            Case LoginUserType_Enum.查詢_跨單位_一般
                Return "查詢_跨單位_一般"
            Case LoginUserType_Enum.查詢_跨單位_行政處專用_一般
                Return "查詢_跨單位_行政處專用_一般"
            Case LoginUserType_Enum.查詢_跨單位_行政處專用_特殊
                Return "查詢_跨單位_行政處專用_特殊"
            Case LoginUserType_Enum.查詢_跨單位_程式人員專用
                Return "查詢_跨單位_程式人員專用"

            Case LoginUserType_Enum.編修_個人
                Return "編修_個人"
            Case LoginUserType_Enum.編修_同單位
                Return "編修_同單位"
            Case LoginUserType_Enum.編修_跨單位_一般
                Return "編修_跨單位_一般"
            Case LoginUserType_Enum.編修_跨單位_行政處專用_一般
                Return "編修_跨單位_行政處專用_一般"
            Case LoginUserType_Enum.編修_跨單位_行政處專用_特殊
                Return "編修_跨單位_行政處專用_特殊"
            Case LoginUserType_Enum.編修_跨單位_程式人員專用
                Return "編修_跨單位_程式人員專用"

            Case Else
                Return "UnKnow：" & fromLoginUserType_Enum
        End Select
    End Function
#End Region
#Region "ViewState：Unit"
    Const C_DataTableUnit As String = "DataTableUnit"
    Private Property WP_DataTable_Unit As DataTable
        Get
            If ViewState(C_DataTableUnit) Is Nothing Then
                ViewState(C_DataTableUnit) = FD_Data_Department_Super()
            End If
            Return ViewState(C_DataTableUnit)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableUnit) = value
        End Set

    End Property

#End Region

#Region "From Code：畫面上物件程式碼"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BorgSPM_ShowInfo()

        If IsPostBack = False OrElse WP_LoginUserID = "" Then
            MultiView1.SetActiveView(View1)
        Else

            P_ShowLoginOK_View2(False)
        End If

    End Sub

    Protected Sub btnLoginOK_Click(sender As Object, e As EventArgs) Handles btnLoginOK.Click
        BorgSPM_LogIn()
    End Sub

    Protected Sub btnLoginCancel_Click(sender As Object, e As EventArgs) Handles btnLoginCancel.Click
        BorgSPM_LogOut()
    End Sub

    Private Sub linkBtnLoginInfo_Click(sender As Object, e As EventArgs) Handles linkBtnLoginInfo.Click
        BorgSPM_LogOut()
    End Sub

    Private Sub P_ShowLoginOK_View2(ByVal fromIsInit As Boolean)
        BorgSPM_ShowInfo()

        If fromIsInit = True Then
            If txtQueryDateYYYY.Text = "" Then
                txtQueryDateYYYY.Text = Now.ToString("yyyy/MM")
            End If

            With ddUnit_Search.Items
                .Clear()

                Dim objViewStat As DataTable = WP_DataTable_Unit

                For Each eachItem As DataRow In objViewStat.Rows
                    .Add(eachItem.Item("PQDP1").Trim & "：" & eachItem.Item("PQDP2").Trim)
                Next
            End With

            For II = 0 To ddUnit_Search.Items.Count - 1
                If WP_ClsSystemNote.Fs_GetStrBefor(ddUnit_Search.Items(II).Text, "：") = WP_LoginUserUnit Then
                    ddUnit_Search.SelectedIndex = II
                    Exit For
                End If
            Next

            lbLimitTimeB.Text = WP_LimitTimeB
            lbLimitTimeC.Text = WP_LimitTimeC
            lbLimitTimeHoliday.Text = WP_LimitTimeHoliday
        End If

        MultiView1.SetActiveView(View2)
    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        cvQueryFood_ServerValidate(cvQueryFood, Nothing)
        TabContainer1.Visible = cvQueryFood.IsValid

        If cvQueryFood.IsValid = True Then
            ListView1.EditIndex = -1
            MakeQryStringToControl()

            TabContainer1_ActiveTabChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTabIndex = 1 Then
            Search2Log(Me.hfSQL_Fodm01pf.Value)
        End If
    End Sub


    Protected Sub btnBatch_Click(sender As Object, e As EventArgs)
        Dim listViewItemObj As ListViewItem = ListView1.EditItem


        If Not IsNothing(listViewItemObj) Then
            Dim dropDownListObj As DropDownList
            Dim labelObj As Label

            Dim dayKind As String
            Dim foodKind As String

            dropDownListObj = listViewItemObj.FindControl("ddFDBatch")
            Dim batchFoodType As String = dropDownListObj.SelectedValue

            WP_IsBatchFoodType = True
            batchFoodType = WP_ClsSystemNote.Fs_GetStrBefor(batchFoodType, "：")

            For II As Integer = C_Day_Min To C_Day_Max
                'Step1：取得班別代碼
                labelObj = listViewItemObj.FindControl("FD" & String.Format("{0:00}", II) & "KindLabel")
                dayKind = labelObj.Text.Trim

                'Step2：檢查班別代碼對應餐點碼
                foodKind = (From A In WP_DataTableOfFoodKind Where A.Item(WP_ClsSystemNote.NOTE_ID).ToString.Trim.Equals(dayKind) Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault
                If foodKind = "" Then Continue For
                foodKind = WP_ClsSystemNote.Fs_GetStrBefor(foodKind, "：")

                'Step3：檢查當餐是否已鎖定
                dropDownListObj = listViewItemObj.FindControl("ddFD" & String.Format("{0:00}", II) & foodKind)
                If dropDownListObj.Enabled = True Then
                    P_FoodType_DropDownList_SelectItem(dropDownListObj, batchFoodType)
                End If

            Next

        End If
    End Sub


#End Region

#Region "BorgSPM：登入EIP驗證"
    Private Sub BorgSPM_LogIn()

        Dim adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")
        Dim queryDataTable As DataTable = adapter.SelectQuery("select logonid,username,password,enable from SPM.dbo.[USER] WHERE LOGONID='" & txtLoginUser.Text & "' ")
        If queryDataTable.Rows.Count = 0 Then
            lbLoginMessage.Text = "帳號輸入錯誤..請檢查..!"
            Exit Sub

        Else
            Dim dbEnable As String = queryDataTable.Rows(0).Item("enable").ToUpper
            Dim dbPW As String = ClassBorgSPM.Decrypt(queryDataTable.Rows(0).Item("password"))

            If "Y".Equals(dbEnable) = False Then
                lbLoginMessage.Text = "此帳號已停用..請檢查..!"
                Exit Sub
            End If

            If txtLoginPW.Text.Equals(dbPW) = False Then
                lbLoginMessage.Text = "密碼輸入錯誤..請檢查..!"
                Exit Sub

            Else
                WP_LoginUserID = queryDataTable.Rows(0).Item("logonid").ToString
                WP_LoginUserName = queryDataTable.Rows(0).Item("username").ToString

                txtQueryID.Text = WP_LoginUserID
                Dim adapter2 As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


                Dim queryEEEMM As String = (Integer.Parse(Now.ToString("yyyy")) - 1911) & (Now.ToString("MM"))
                Dim querySQL As String
                Dim queryDataTable2 As DataTable

                querySQL = "select fd005 FROM @#fod100lb.FODM01PF WHERE  fdtym=" & queryEEEMM & " AND  fd001='" & txtLoginUser.Text & "'  FETCH FIRST 1 ROWS ONLY"
                queryDataTable2 = adapter2.SelectQuery(querySQL)
                If queryDataTable2.Rows.Count > 0 Then
                    WP_LoginUserUnit = queryDataTable2.Rows(0).Item("fd005").ToString.Trim
                End If



                WP_LoginUserType = LoginUserType_Enum.查詢_個人
                '查詢特殊身分
                '--------------------------------------------------------------------------------------------
                querySQL = "SELECT fd301 FROM @#fod100lb.FODM03pf WHERE 1=1 AND fd302='" & WP_LoginUserID & "' AND fd303='N' ORDER BY fd301 FETCH FIRST 1 ROWS ONLY"
                queryDataTable2 = adapter2.SelectQuery(querySQL)
                If queryDataTable2.Rows.Count > 0 Then
                    Dim userTypeCode As String = queryDataTable2.Rows(0).Item("fd301").ToString.Trim
                    If userTypeCode.Substring(0, 1) <> ModFood.C_特殊部門代號 Then
                        WP_LoginUserType = LoginUserType_Enum.編修_同單位

                    Else
                        WP_LoginUserUnit = userTypeCode
                        Select Case Integer.Parse(userTypeCode.Substring(1, 1))
                            Case Enum_特殊部門代號清單.程式人員專用
                                WP_LoginUserType = LoginUserType_Enum.編修_跨單位_程式人員專用
                            Case Enum_特殊部門代號清單.行政處專用_一般
                                WP_LoginUserType = LoginUserType_Enum.編修_跨單位_行政處專用_一般
                            Case Enum_特殊部門代號清單.行政處專用_特殊
                                WP_LoginUserType = LoginUserType_Enum.編修_跨單位_行政處專用_特殊
                        End Select
                    End If
                End If

                '調整畫面與權限控管
                '--------------------------------------------------------------------------------------------
                lbLoginUserType.Text = LoginUserType_Name(WP_LoginUserType)
                ddUnit_Search.Enabled = True
                txtQueryID.Enabled = True

                If (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.個人) Then
                    ddUnit_Search.Enabled = False
                    txtQueryID.Enabled = False

                ElseIf (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.同單位) Then
                    ddUnit_Search.Enabled = False
                    txtQueryID.Text = ""

                ElseIf (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_一般) Then
                    txtQueryID.Text = ""
                ElseIf (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_行政處專用_一般) Then
                    txtQueryID.Text = ""
                ElseIf (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_行政處專用_特殊) Then
                    txtQueryID.Text = ""
                ElseIf (WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_程式人員專用) Then
                    txtQueryID.Text = ""
                End If
                '----------------------------------------------

                P_ShowLoginOK_View2(True)

                btnSearch_Click(Nothing, Nothing)
            End If

        End If
    End Sub

    Private Sub BorgSPM_LogOut()
        txtLoginUser.Text = ""
        txtLoginPW.Text = ""
        WP_LoginUserName = ""
        WP_LoginUserID = ""

        txtQueryID.Text = ""
        txtQueryDateYYYY.Text = ""
        txtQueryDateEEE.Text = ""

        BorgSPM_ShowInfo()

        MultiView1.SetActiveView(View1)
    End Sub

    Private Sub BorgSPM_ShowInfo()
        linkBtnLoginInfo.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")

        If String.IsNullOrEmpty(WP_LoginUserName) = True OrElse WP_LoginUserName = "" Then Exit Sub
        linkBtnLoginInfo.Text &= " | " & WP_LoginUserName & " | " & "系統登出"
    End Sub

#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()

        If IsDate(txtQueryDateYYYY.Text & "/01") = False Then
            MsgBox("查詢年月格式錯誤：" & txtQueryDateYYYY.Text)
            Exit Sub
        End If

        Dim queryEEE As String, queryMM As String

        queryEEE = Integer.Parse(txtQueryDateYYYY.Text.Substring(0, 4)) - 1911
        queryMM = txtQueryDateYYYY.Text.Substring(5, 2)
        txtQueryDateEEE.Text = queryEEE & queryMM

        Dim W_QueryDate_Last As String = Integer.Parse(DateAdd(DateInterval.Month, -1, CDate(txtQueryDateYYYY.Text)).ToString("yyyyMM")) - 191100


        Dim queryDate_Before As Date = DateAdd(DateInterval.Month, -1, Date.Parse(txtQueryDateYYYY.Text))
        Dim queryEEE_Before As Integer = Integer.Parse(queryDate_Before.ToString("yyyy")) - 1911
        Dim queryMM_Before As Integer = Integer.Parse(queryDate_Before.ToString("MM"))


        Dim querySql As New StringBuilder
        Dim queryYear As Integer = Integer.Parse(queryEEE)
        Dim queryMonth As Integer = Integer.Parse(queryMM)
        Dim queryUnit_Real As String
        Dim queryUnit_Change As String
        Dim queryUnitChange_Input As List(Of String)

        WP_HolidayTable = getAllHolidayList(queryYear, queryMonth, queryEEE_Before, queryMM_Before)

        querySql.Append("SELECT * " & vbNewLine)
        querySql.Append("FROM @#fod100lb.FODM01PF" & vbNewLine)
        querySql.Append("  WHERE 1=1 " & vbNewLine)
        querySql.Append("  AND FDTYM= " & txtQueryDateEEE.Text & vbNewLine)

        queryUnit_Real = WP_ClsSystemNote.Fs_GetStrBefor(ddUnit_Search.Text, "：")
        If queryUnit_Real.Substring(0, 1) <> ModFood.C_特殊部門代號 Then
            '---------------------------------------------------------------------------------------------------------
            queryUnitChange_Input = (From A In WP_DataTableOfUnitChange_Input
                                                               Where A(WP_ClsSystemNote.CONTENT).ToString.Trim.Equals(queryUnit_Real)
                                                               Select New String(A.Item(WP_ClsSystemNote.NOTE_ID))).ToList
            queryUnit_Change = String.Join("' , '", queryUnitChange_Input.ToArray)
            '---------------------------------------------------------------------------------------------------------

            querySql.Append("  AND ( " & vbNewLine)
            querySql.Append("                         (  fd005 = '" & queryUnit_Real & "' )           " & vbNewLine)
            querySql.Append("                  OR (  fd005 IN ('" & queryUnit_Change & "' )   )        " & vbNewLine)
            querySql.Append("             ) " & vbNewLine)
        End If

        If txtQueryID.Text <> "" Then
            querySql.Append("   AND fd001='" & txtQueryID.Text & "'" & vbNewLine)
        End If

        querySql.Append("ORDER BY fd005,fd001 " & vbNewLine)

        Me.hfSQL_Fodm01pf.Value = querySql.ToString
        Me.hfQueryDate_Last.Value = W_QueryDate_Last
        Me.hfQueryDate_Now.Value = txtQueryDateEEE.Text
        Me.hfQueryUnit.Value = WP_ClsSystemNote.Fs_GetStrBefor(ddUnit_Search.Text, "：")
        Me.hfQueryID.Value = txtQueryID.Text

    End Sub
#End Region

#Region "取得假日與國定假日清單：getAllHolidayList"
    Private WP_QueryYear As Integer, WP_QueryMonth As Integer

    Const C_ViewPqds02pf As String = "ViewPqds02pf"

    Private Property WP_HolidayTable As DataTable
        Get
            If ViewState(C_ViewPqds02pf) Is Nothing Then
                Return New DataTable
            Else
                Return ViewState(C_ViewPqds02pf)
            End If
        End Get

        Set(value As DataTable)
            ViewState(C_ViewPqds02pf) = value
        End Set
    End Property


    Private Function getAllHolidayList(ByVal fromEEE As Integer, ByVal fromMM As Integer, _
                                                                    ByVal fromEEE_Before As Integer, ByVal fromMM_Before As Integer) As DataTable
        If (WP_QueryYear = fromEEE) AndAlso (WP_QueryMonth = fromMM) _
                             AndAlso Not (WP_HolidayTable Is Nothing) AndAlso (WP_HolidayTable.Rows.Count > 0) Then
            Return WP_HolidayTable
        End If

        WP_QueryYear = fromEEE
        WP_QueryMonth = fromMM

        Dim querySql As New StringBuilder
        querySql.Append("SELECT * " & vbNewLine)
        querySql.Append("FROM @#plt000lb.pqds02pf" & vbNewLine)
        querySql.Append("  WHERE 1=1 " & vbNewLine)
        querySql.Append("  AND ( " & vbNewLine)
        querySql.Append("                    (qds20a= " & fromEEE & " AND qds20b= '" & String.Format("{0:00}", fromMM) & "' )" & vbNewLine)
        querySql.Append("                     OR  (qds20a= " & fromEEE_Before & " AND qds20b= '" & String.Format("{0:00}", fromMM_Before) & "' )" & vbNewLine)
        querySql.Append("           ) " & vbNewLine)

        querySql.Append("  AND qds20c='E'" & vbNewLine)
        querySql.Append("  AND qds20d='F'" & vbNewLine)
        querySql.Append("  ORDER BY qds20a, qds20b" & vbNewLine)

        Dim queryTable As DataTable = WP_AS400Adapter.SelectQuery(querySql.ToString)

        Return queryTable
    End Function
#End Region

#Region "Search:Search"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL_Fodm01pf As String, _
                                                  ByVal fromQueryDate_Last As String, ByVal fromQueryDate_Now As String, _
                                                  ByVal fromQueryUnit As String, _
                                                  ByVal fromQueryID As String _
                                                  ) As List(Of FOD100LB.FODM01PF)


        Dim queryObj As New List(Of FOD100LB.FODM01PF)
        If String.IsNullOrEmpty(fromSQL_Fodm01pf) Or fromSQL_Fodm01pf = "" Then
            Return queryObj
        End If

        WP_QueryDate = fromQueryDate_Now
        WP_QueryUnit = fromQueryUnit
        WP_QueryID = fromQueryID


        queryObj = FOD100LB.FODM01PF.CDBSelect(Of FOD100LB.FODM01PF)(fromSQL_Fodm01pf, WP_AS400Adapter)
        Return queryObj

    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As FOD100LB.FODM01PF) As Integer
        Dim W_Step As Integer
        Dim W_Count As Integer

        Dim W_FDSDTE As Integer = fromObj.FDSDTE
        Dim W_FDSTIM As Integer = fromObj.FDSTIM

        fromObj.FDSDTE = (Integer.Parse(Format(Now, "yyyy")) - 1911) & Format(Now, "MMdd")
        fromObj.FDSTIM = Format(Now, "HHmmss")

        Dim sqlUpdate01 As String = fromObj.CDBUpdateSQLString
        Dim sql01Where As String = sqlUpdate01.Substring(sqlUpdate01.ToUpper.IndexOf(" WHERE "))
        Dim sqlUpdate02 As New StringBuilder


        Try
            W_Step = 0
            Dim W_UpdateMsg As String = ""

            'Dim a400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            'Dim sqlUpdate01 As String = fromObj.CDBUpdateSQLString
            'Dim sql01Where As String = sqlUpdate01.Substring(sqlUpdate01.ToUpper.IndexOf(" WHERE "))

            'Dim sqlUpdate02 As New StringBuilder
            sqlUpdate02.Length = 0
            sqlUpdate02.Append("INSERT INTO	@#fod100lb.fodm02pf " & vbNewLine)
            sqlUpdate02.Append("SELECT * FROM @#fod100lb.fodm01pf " & vbNewLine)
            sqlUpdate02.Append(sql01Where)

            'Log
            W_Step = 1
            W_Count = WP_AS400Adapter.ExecuteNonQuery(sqlUpdate02.ToString)
            If W_Count = 0 Then
                Throw New Exception("更新記錄檔錯誤")
            End If

            'Update
            W_Step = 2
            W_Count = WP_AS400Adapter.ExecuteNonQuery(sqlUpdate01)
            If W_Count = 0 Then
                Throw New Exception("更新主檔錯誤")
            End If


            Return W_Count

        Catch ex As Exception

            If W_Step >= 1 Then
                'Log

                sqlUpdate02.Length = 0
                sqlUpdate02.Append("DELETE FROM @#fod100lb.fodm02pf " & vbNewLine)
                sqlUpdate02.Append(sql01Where)
                sqlUpdate02.Append("  AND FDSDTE=" & W_FDSDTE)
                sqlUpdate02.Append("  AND FDSTIM=" & W_FDSTIM)

                W_Count = WP_AS400Adapter.ExecuteNonQuery(sqlUpdate02.ToString)
            End If


            Throw New Exception("更新失敗，請重新再更新一次。<BR>W_Step=" & W_Step & "<BR>" & ex.Message)
        End Try

    End Function

#Region "EditCustomValidator1_ServerValidate"
    Public Sub EditCustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim W_FDTIM1 As String = CType(Me.ListView1.EditItem.FindControl("hfForUpdateFDTIM1"), HiddenField).Value
        Dim W_FDTIM2 As String = CType(Me.ListView1.EditItem.FindControl("hfForUpdateFDTIM2"), HiddenField).Value


        Dim W_ThisMonth_Now As String = showDayFoodKindEdit_Flag_ThisMonth(W_FDTIM1, W_FDTIM2)
        Dim W_ThisMonth_Load As String = CType(Me.ListView1.EditItem.FindControl("hfForUpdateEdit_Flag"), HiddenField).Value

        Dim W_EditFlag_Now As String = W_ThisMonth_Now.Split("|")(0), W_DateTime_Now As String = W_ThisMonth_Now.Split("|")(1)
        Dim W_EditFlag_Load As String = W_ThisMonth_Load.Split("|")(0), W_DateTime_Load As String = W_ThisMonth_Load.Split("|")(1)

        Dim SenderControl As CustomValidator = ListView1.EditItem.FindControl("EditCustomValidator1")
        SenderControl.ErrorMessage = IIf(W_EditFlag_Now.Equals(W_EditFlag_Load), "" _
                                                                , "畫面上資料逾時，超過截止時間，須重新查詢資料後再做編輯。<BR/>畫面：" & W_DateTime_Load & "&nbsp&nbsp&nbsp系統：" & W_DateTime_Now & "<BR/>")


        args.IsValid = String.IsNullOrEmpty(SenderControl.ErrorMessage)
    End Sub

#End Region

#End Region

#Region "Show：顯示於畫面上相關程式碼"

    Protected Function showSaveInfo(ByVal fromFDSaveDate As String, ByVal fromFDSaveTime As String _
                                                                     , ByVal fromFDSavePC As String _
                                                                     , ByVal fromFDSaveOper As String) As String

        Dim W_ShowDateTime As String = ""

        If fromFDSaveDate.Length >= 6 Then
            Dim W_Split_1 As String = fromFDSaveDate.Substring(0, IIf(fromFDSaveDate.Length = 6, 2, 3))
            Dim W_Split_2 As String = Microsoft.VisualBasic.Right(fromFDSaveDate, 4)

            W_ShowDateTime = W_Split_1
            W_ShowDateTime &= "/" & W_Split_2.Substring(0, 2)
            W_ShowDateTime &= "/" & W_Split_2.Substring(2, 2)
        End If

        If fromFDSaveTime.Length = 5 Then fromFDSaveTime = "0" & fromFDSaveTime
        If fromFDSaveTime.Length >= 6 Then
            W_ShowDateTime &= ModTools.showSpace(2) & fromFDSaveTime.Substring(0, 2) & ":" & fromFDSaveTime.Substring(2, 2) & ":" & fromFDSaveTime.Substring(4, 2)
        End If
        If W_ShowDateTime = "" Then W_ShowDateTime = ModTools.showSpace(15)
        W_ShowDateTime &= "&nbsp<BR>"


        If WP_LoginUserType_Code2() <> LoginUserTypeCode2_Enum.跨單位_程式人員專用 Then
            fromFDSavePC = ""
        End If

        Return W_ShowDateTime _
                      & fromFDSavePC.Replace(Space(1), "") & "<BR>" _
                      & fromFDSaveOper
    End Function

    Protected Function show出勤資料(ByVal from出勤時間 As String) As String
        If (from出勤時間 Is Nothing) OrElse (from出勤時間.Trim.Equals("")) Then
            Return ModTools.showSpace(9)
        Else
            Return from出勤時間
        End If

    End Function


    Protected Function showQueryYearMonthInfo() As String
        '1040527 by renhsin,使用txtQueryDateYYYY在使用者沒有按查詢直接編輯資料會失真，故改用txtQueryDateEEEE，以下方資料的日期為主
        'Return txtQueryDateYYYY.Text

        ' txtQueryDateYYYY.Text       '畫面上:西元年
        ' txtQueryDateEEE.Text          '隱藏下方資料:民國年
        Dim showQueryDate As Date = WP_AS400DateConverter.StringToDate(txtQueryDateEEE.Text & String.Format("{0:00}", 1))
        Dim retQueryDate As String = showQueryDate.ToString("yyyy/MM")

        Return retQueryDate
    End Function

    Protected Function showDayInfo(ByVal fromDay As Integer) As String
        Dim retMsg As String = fromDay

        Try
            Dim showDate As Date = WP_AS400DateConverter.StringToDate(txtQueryDateEEE.Text & String.Format("{0:00}", fromDay))
            Dim showWeekdayName As String = WeekdayName(Weekday(showDate))

            retMsg = String.Format("{0:00}", fromDay) & "<BR>" & showWeekdayName.Substring(showWeekdayName.Length - 1)

            If fromDay > C_CheckDayFrom Then
                Dim lastDay As Integer = showQueryYearMonthLastDay.ToString("dd")
                If fromDay > lastDay Then retMsg = ""
            End If
        Catch ex As Exception
        End Try

        Return retMsg
    End Function

    Protected C_CheckDayFrom As Integer = 28
    Protected Function showDayVisible(ByVal fromDay As Integer) As Boolean
        Dim retFlag As Boolean = True

        Try
            If fromDay > C_CheckDayFrom Then
                Dim lastDay As Integer = showQueryYearMonthLastDay.ToString("dd")
                retFlag = Not (fromDay > lastDay)
            End If
        Catch ex As Exception

        End Try

        Return retFlag
    End Function

    Protected Function showSpaceEdit_Flag() As Boolean
        Dim retFlag As Boolean

        Select Case WP_LoginUserType_Code2()
            Case LoginUserTypeCode2_Enum.跨單位_行政處專用_特殊, _
                      LoginUserTypeCode2_Enum.跨單位_程式人員專用, _
                      LoginUserTypeCode2_Enum.同單位
                retFlag = True
            Case Else
                retFlag = False
        End Select

        Return retFlag
    End Function

    Const C_Color_Edit_Yes As String = "#FFFFFF"
    Const C_Color_Edit_No As String = "#CCCCCC"
    Protected Function showSpaceEdit_Color() As System.Drawing.Color
        Dim flag As Boolean = showSpaceEdit_Flag()
        Dim retColorString As String = IIf(flag, C_Color_Edit_Yes, C_Color_Edit_No)

        Return System.Drawing.ColorTranslator.FromHtml(retColorString)
    End Function

    Protected Function showDayFoodKindEdit_Color(ByVal fromDay As Integer, ByVal fromLimitType As String, _
                                                                                                 ByVal fromCloseAccountDay_1_25 As Decimal, ByVal fromCloseAccountDay_26 As Decimal) As System.Drawing.Color
        Dim flag As Boolean = showDayFoodKindEdit_Flag(fromDay, fromLimitType, fromCloseAccountDay_1_25, fromCloseAccountDay_26)
        Dim retColorString As String = IIf(flag, C_Color_Edit_Yes, C_Color_Edit_No)

        Return System.Drawing.ColorTranslator.FromHtml(retColorString)
    End Function

    Protected Function showDayFoodKindEdit_Flag(ByVal fromDay As Integer, ByVal fromLimitType As String, _
                                                                                               ByVal fromCloseAccountDay_1_25 As Decimal, ByVal fromCloseAccountDay_26 As Decimal) As Boolean
        Try

            Dim dayFlag As String = getHolidayFlag(fromDay)
            Dim checkIsHoliday As Boolean = ("X".Equals(dayFlag.Substring(0, 1)))
            Dim checkTime As String
            Dim checkDataTime As Date

            If checkIsHoliday = False Then
                checkTime = IIf(fromLimitType.Equals("B"), WP_LimitTimeB, WP_LimitTimeC) & ":00"
                checkDataTime = Date.Parse(showQueryYearMonthInfo() & "/" & fromDay & Space(1) & checkTime)

            Else
                checkTime = WP_LimitTimeHoliday & ":00"
                checkDataTime = Date.Parse(getHolidayBefoureWorkDay(fromDay) & Space(1) & checkTime)
            End If

            Dim pcDataTime As Date = Now
            Dim retFlag As Boolean = (checkDataTime >= pcDataTime)

            If retFlag = True Then
                'Step1：時間區間可以編輯

                'Step2：檢查使用者是否有編輯權限
                retFlag = showThisUserCanEdit()

            Else

                '不能編輯

                'Step1：行政處專用_一般
                If WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_行政處專用_一般 Then
                    Dim checkDataTimeHR As Date = DateAdd(DateInterval.Minute, Double.Parse(WP_LimitTimeHR), checkDataTime)
                    retFlag = (checkDataTimeHR >= pcDataTime)
                End If

                'Step2：行政處專用_特殊
                If WP_LoginUserType_Code2() = LoginUserTypeCode2_Enum.跨單位_行政處專用_特殊 Then
                    If fromDay <= 25 Then
                        retFlag = (fromCloseAccountDay_1_25 = 0)
                    Else
                        retFlag = (fromCloseAccountDay_26 = 0)
                    End If

                End If

            End If

            Return retFlag
        Catch ex As Exception
            Return False
        End Try

    End Function

    Protected Function showDayFoodKindEdit_Flag_ThisMonth(ByVal fromCloseAccountDay_1_25 As Decimal, ByVal fromCloseAccountDay_26 As Decimal) As String
        Dim retFlag As String = ""

        Dim W_Flag As Boolean

        For fromDay As Integer = 1 To 31                             '日期
            For Each eachTimeType As String In {"B", "C"}

                W_Flag = showDayFoodKindEdit_Flag(fromDay, eachTimeType, fromCloseAccountDay_1_25, fromCloseAccountDay_26)
                retFlag &= IIf(W_Flag = True, "T", "F")
            Next
        Next

        retFlag &= "|" & Now.ToString("yyyy/MM/dd HH:mm:ss")

        Return retFlag
    End Function

    Protected Function showThisUserCanEdit() As Boolean
        Return (WP_LoginUserType_Code1() = LoginUserTypeCode1_Enum.編修)
    End Function

    Protected Function showThisMonthCanEdit(ByVal fromCloseAccountDay_1_25 As Decimal, ByVal fromCloseAccountDay_26 As Decimal) As Boolean
        Try

            'V1 
            'Dim checkTime() As String = WP_LimitTimeC.Split(":")
            'Dim checkDataTime As Date = showQueryYearMonthLastDay()
            'checkDataTime = DateAdd(DateInterval.Hour, Integer.Parse(checkTime(0)), checkDataTime)
            'checkDataTime = DateAdd(DateInterval.Minute, Integer.Parse(checkTime(1)), checkDataTime)

            'Dim pcDataTime As Date = Now
            'Dim retFlag As Boolean = (checkDataTime >= pcDataTime)

            'If retFlag = True Then
            '    retFlag = showThisUserCanEdit()
            'End If




            'V2
            '1041015 by renhsin
            Dim W_ThisMonth_Now As String = showDayFoodKindEdit_Flag_ThisMonth(fromCloseAccountDay_1_25, fromCloseAccountDay_26)
            Dim W_EditFlag_Now As String = W_ThisMonth_Now.Split("|")(0), W_DateTime_Now As String = W_ThisMonth_Now.Split("|")(1)
            Dim retFlag As Boolean = IIf(W_EditFlag_Now.IndexOf("T") > -1, True, False)

            Return retFlag
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Function showQueryYearMonthLastDay() As Date
        Dim queryYearMonthLastDay As Date = Date.Parse(showQueryYearMonthInfo() & "/01")
        queryYearMonthLastDay = DateAdd(DateInterval.Month, 1, queryYearMonthLastDay)
        queryYearMonthLastDay = DateAdd(DateInterval.Day, -1, queryYearMonthLastDay)

        Return queryYearMonthLastDay
    End Function



    Protected Function showFoodType(ByVal fromFoodTypeCode As String) As String
        Dim queryCode As String = fromFoodTypeCode.Trim
        Dim display_Label As String
        Dim retMsg As String = queryCode

        If queryCode = "" Then
            Return ModTools.showSpace(7)
        End If


        For Each eachItem As DataRow In WP_DataTableOfFoodType.Rows
            display_Label = eachItem.Item(WP_ClsSystemNote.Display_Lable)

            If display_Label.Substring(0, queryCode.Length).Equals(queryCode) Then
                retMsg = display_Label
                Exit For
            End If
        Next

        Return retMsg
    End Function

    Protected Function show上個月訂購餐別(ByVal from上個月訂購餐別 As String) As String


        Dim W_Split() As String = from上個月訂購餐別.Split(",")
        If UBound(W_Split) < 2 Then
            Return ModTools.showSpace(7)
        Else
            Return W_Split(2)
        End If

    End Function

#End Region

#Region "Holiday：假日相關程式碼"
    Protected Function getHolidayFlag(ByVal fromDay As Integer) As String
        Dim dayFlag As String = "X"

        If WP_HolidayTable.Rows.Count >= 1 Then
            dayFlag = WP_HolidayTable.Rows(1).Item("qds2" & String.Format("{0:00}", fromDay)).ToString.Trim.ToUpper
        End If

        Return dayFlag
    End Function


    Protected Function getHolidayBefoureWorkDay(ByVal fromDay As Integer) As String
        Dim retYYYYMM As String = ""
        Dim dayFlag As String

        If WP_HolidayTable.Rows.Count > 0 Then
            For JJ_month As Integer = 1 To 0 Step -1
                For II_day As Integer = C_Day_Max To C_Day_Min Step -1

                    If JJ_month = 1 Then
                        If fromDay <= II_day Then Continue For
                    End If

                    dayFlag = WP_HolidayTable.Rows(JJ_month).Item("qds2" & String.Format("{0:00}", II_day)).ToString.Trim.ToUpper
                    If "".Equals(dayFlag) Then Continue For

                    If "X".Equals(dayFlag.Substring(0, 1)) = False Then
                        retYYYYMM = Integer.Parse(WP_HolidayTable.Rows(JJ_month).Item("qds20a")) + 1911
                        retYYYYMM &= "/" & WP_HolidayTable.Rows(JJ_month).Item("qds20b")
                        retYYYYMM &= "/" & II_day

                        Return retYYYYMM
                    End If
                Next
            Next
        End If


        Return retYYYYMM
    End Function

    Protected Function showHolidayColor(ByVal fromDay As Integer) As String
        Dim retBgColor As String = ""
        Dim dayFlag As String = getHolidayFlag(fromDay)

        If dayFlag <> "" Then
            retBgColor = IIf("X".Equals(dayFlag.Substring(0, 1)), " bgcolor=#addaff", "")
        End If

        Return retBgColor
    End Function
#End Region

#Region "ListView1：Updating / PreRender"


    Private Sub ListView1_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListView1.ItemDataBound
        Dim listViewOjb As ListView = CType(sender, ListView)

        If listViewOjb.EditIndex > -1 Then
            Dim dataitemObj As ListViewDataItem = CType(e.Item, ListViewDataItem)
            If dataitemObj.DisplayIndex <> listViewOjb.EditIndex Then
                e.Item.Visible = False
            End If

        End If
    End Sub

    Private Sub ListView1_ItemUpdated(sender As Object, e As ListViewUpdatedEventArgs) Handles ListView1.ItemUpdated

        If e.Exception Is Nothing Then
            '更新資料成功，畫面回到查詢畫面
            'Dim listViewObj As ListView = CType(sender, ListView)
            'listViewObj.SelectedIndex = listViewObj.EditIndex

        Else
            '更新資料失敗，畫面停在編輯畫面
            Dim W_ErrMsg As String = IIf(e.Exception.InnerException Is Nothing, e.Exception.Message, e.Exception.InnerException.Message)

            Dim CVObj As CustomValidator = ListView1.EditItem.FindControl("EditCustomValidator1")
            CVObj.ErrorMessage = W_ErrMsg
            CVObj.IsValid = False

            e.KeepInEditMode = True
            e.ExceptionHandled = True
        End If
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim listView As ListView = CType(sender, ListView)
        Dim colName As String
        Dim ddObj As DropDownList

        'Step1：隱藏資料
        'DB欄位資料用HiddenField物件Bind，系統自動會做匹配
        'Const C_hfForUpdate As String = "hfForUpdate"
        'For Each eachControl As Control In listView.EditItem.Controls
        '    If TypeOf eachControl Is HiddenField Then
        '        If eachControl.ID.Length >= C_hfForUpdate.Length AndAlso eachControl.ID.Substring(0, C_hfForUpdate.Length) = C_hfForUpdate Then
        '            colName = eachControl.ID.Substring(C_hfForUpdate.Length)
        '            e.NewValues(colName) = CType(eachControl, HiddenField).Value
        '        End If
        '    End If
        'Next

        'Step2：畫面上輸入
        For II As Integer = C_Day_Min To C_Day_Max
            For Each eachTimeType As String In {"B", "C"}
                colName = "FD" & String.Format("{0:00}", II) & eachTimeType
                ddObj = CType(listView.EditItem.FindControl("dd" & colName), DropDownList)
                e.NewValues(colName) = ddObj.SelectedValue.Split("：")(0)
            Next
        Next

        '置放單位
        colName = "FD004"
        ddObj = CType(listView.EditItem.FindControl("ddFD004"), DropDownList)
        e.NewValues(colName) = ddObj.SelectedValue.Split("：")(0)


        'Step3：存檔資訊
        e.NewValues("FDSOPR") = WP_LoginUserID

        '1040716 
        '改到存檔時再更新這兩個欄位
        'e.NewValues("FDSDTE") = (Integer.Parse(Format(Now, "yyyy")) - 1911) & Format(Now, "MMdd")
        'e.NewValues("FDSTIM") = Format(Now, "HHmmss")


        If HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR") <> "" Then
            e.NewValues("FDSDEV") = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        Else
            e.NewValues("FDSDEV") = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
        End If

    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As ListViewItem = ListView1.EditItem
        Dim fiddenFieldObj As HiddenField

        If Not IsNothing(listViewItemObj) Then

            If WP_IsBatchFoodType = True Then
                WP_IsBatchFoodType = False
                Exit Sub
            End If

            Dim dropDownListObj As DropDownList
            '置放單位
            dropDownListObj = listViewItemObj.FindControl("ddFD004")
            fiddenFieldObj = listViewItemObj.FindControl("FD004HiddenField")

            P_Space_DropDownList_AddItem(dropDownListObj)
            P_FoodType_DropDownList_SelectItem(dropDownListObj, fiddenFieldObj.Value.Trim)


            '批次處理
            dropDownListObj = listViewItemObj.FindControl("ddFDBatch")
            P_FoodType_DropDownList_AddItem(dropDownListObj)


            '每日
            For II As Integer = C_Day_Min To C_Day_Max
                For JJ As Integer = 66 To 67        'B :午餐      C:晚餐
                    dropDownListObj = listViewItemObj.FindControl("ddFD" & String.Format("{0:00}", II) & Chr(JJ))
                    fiddenFieldObj = listViewItemObj.FindControl("FD" & String.Format("{0:00}", II) & Chr(JJ) & "HiddenField")

                    P_FoodType_DropDownList_AddItem(dropDownListObj)
                    P_FoodType_DropDownList_SelectItem(dropDownListObj, fiddenFieldObj.Value.Trim)

                Next JJ

            Next II

        End If

    End Sub



#End Region

#Region "P_DropDownList_AddItem"
    Private Sub P_Space_DropDownList_AddItem(ByRef fromDropDownList As DropDownList)
        P_DropDownList_AddItem(fromDropDownList, WP_DataTableOfSpace, WP_ClsSystemNote.Display_Lable)
    End Sub

    Private Sub P_FoodType_DropDownList_AddItem(ByRef fromDropDownList As DropDownList)
        P_DropDownList_AddItem(fromDropDownList, WP_DataTableOfFoodType, WP_ClsSystemNote.Display_Lable)
    End Sub

    Protected Sub P_DropDownList_AddItem(ByRef fromDropDownList As DropDownList, _
                                                                                  ByRef fromDataTable As DataTable, _
                                                                                  ByVal fromItemColumnName As String)
        fromDropDownList.Items.Clear()
        fromDropDownList.Items.Add("")

        For Each eachItem As DataRow In fromDataTable.Rows
            fromDropDownList.Items.Add(eachItem.Item(fromItemColumnName))
        Next

    End Sub

    Private Sub P_FoodType_DropDownList_SelectItem(ByRef fromDropDownList As DropDownList, ByVal fromItemName As String)
        For II As Integer = 0 To fromDropDownList.Items.Count - 1
            If WP_ClsSystemNote.Fs_GetStrBefor(fromDropDownList.Items(II).Text, "：") = fromItemName Then
                fromDropDownList.SelectedIndex = II
                Exit For
            End If
        Next II

    End Sub

#End Region

#Region "驗證使用者輸入資料：CustomValidator"

    Protected Sub cvQueryFood_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvQueryFood.ServerValidate
        Dim SenderControl As CustomValidator = source
        SenderControl.ErrorMessage = ""

        If ddUnit_Search.Text.Substring(0, 1) = ModFood.C_特殊部門代號 AndAlso txtQueryID.Text = "" Then
            SenderControl.ErrorMessage = "職編不可為空白!"
        End If
        SenderControl.IsValid = String.IsNullOrEmpty(SenderControl.ErrorMessage)

    End Sub
#End Region


#Region "動態產生Table：Log"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Sub Search2Log(ByVal fromSQL_Fodm01pf As String)
        Dim retTable As Table = tableFoodLog

        If String.IsNullOrEmpty(fromSQL_Fodm01pf) Or fromSQL_Fodm01pf = "" Then
            Exit Sub
        End If

        retTable.BorderStyle = BorderStyle.None
        retTable.Rows.Clear()

        Dim cnt1 As Integer

        Dim sqlSelect01 As String = fromSQL_Fodm01pf
        Dim sqlSelect02 As String = fromSQL_Fodm01pf.Replace("FODM01PF", "FODM02PF")

        'Try
        Dim queryList01M As List(Of FOD100LB.FODM01PF) = FOD100LB.FODM01PF.CDBSelect(Of FOD100LB.FODM01PF)(sqlSelect01, WP_AS400Adapter)
        Dim queryList02D As List(Of FOD100LB.FODM02PF) = FOD100LB.FODM01PF.CDBSelect(Of FOD100LB.FODM02PF)(sqlSelect02, WP_AS400Adapter)
        Dim queryList02S As List(Of FOD100LB.FODM02PF) = Nothing

        cnt1 = -1
        Search2Log_AddRow(retTable, cnt1, Search2Log_GetText(Nothing, 0))

        cnt1 = 0
        For Each each01 As FOD100LB.FODM01PF In queryList01M

            Search2Log_AddRow(retTable, cnt1, Search2Log_GetText(each01, 1))

            queryList02S = (From B In queryList02D Where B.FDTYM = each01.FDTYM AndAlso _
                                             B.FD001 = each01.FD001 _
                                             Order By B.FDSDTE Descending, B.FDSTIM Descending
                                             Select B).ToList

            For Each each02 As FOD100LB.FODM02PF In queryList02S

                Search2Log_AddRow(retTable, cnt1, Search2Log_GetText(each02, 2))
            Next

            cnt1 += 1

        Next


        'Catch ex As Exception
        '    Debug.Print(ex.Message)
        'End Try


    End Sub

    Private Function Search2Log_GetText(ByRef fromClass As CompanyORMDB.ORMBaseClass.ClassDB, _
                                                                          ByVal fromMode As Integer) As String()

        Dim retStringArray As New ArrayList
        Dim fixName As String = "FD"


        If fromMode = 0 Then
            retStringArray.Add("單位代號")
            retStringArray.Add("職編")
            retStringArray.Add("姓名")
            retStringArray.Add("資料類別")
            retStringArray.Add("修改紀錄")
            retStringArray.Add("置放代號")
        Else
            If fromMode = 1 Then
                retStringArray.Add(GetClassFieldValue(fromClass, fixName & "005") & ModTools.showSpace(12))
                retStringArray.Add(GetClassFieldValue(fromClass, fixName & "001") & ModTools.showSpace(2))
                retStringArray.Add(GetClassFieldValue(fromClass, fixName & "002") & ModTools.showSpace(15))
                retStringArray.Add(ModTools.showSpace(16))
                'retStringArray.Add(GetClassFieldValue(fromClass, fixName & "004") & ModTools.showSpace(12))
            ElseIf fromMode = 2 Then
                retStringArray.Add("")
                retStringArray.Add("")
                retStringArray.Add("")
                retStringArray.Add("L：紀錄")
                'retStringArray.Add(GetClassFieldValue(fromClass, fixName & "004") & ModTools.showSpace(12))
            End If

            retStringArray.Add(showSaveInfo(GetClassFieldValue(fromClass, "FDSDTE").ToString, GetClassFieldValue(fromClass, "FDSTIM"), GetClassFieldValue(fromClass, "FDSDEV"), GetClassFieldValue(fromClass, "FDSOPR")))
            retStringArray.Add(GetClassFieldValue(fromClass, fixName & "004") & ModTools.showSpace(12))

        End If

        For II As Integer = C_Day_Min To C_Day_Max
            For Each eachFoodType As String In {"B", "C"}

                If fromMode = 0 Then
                    retStringArray.Add(String.Format("{0:00}", II) & eachFoodType)
                Else
                    retStringArray.Add(GetClassFieldValue(fromClass, fixName & String.Format("{0:00}", II) & eachFoodType))
                End If

            Next

        Next

        Return retStringArray.ToArray(GetType(String))
    End Function


    Private Function GetClassFieldValue(ByRef fromClass As CompanyORMDB.ORMBaseClass.ClassDB, _
                                                                                                               ByVal FieldName As String) As Object
        '設定資料庫類別所有'屬性'之值
        Dim myPropertyInfo As System.Reflection.PropertyInfo = Nothing
        For Each EachItem As System.Reflection.PropertyInfo In fromClass.GetType.GetProperties
            If EachItem.Name = FieldName Then
                myPropertyInfo = EachItem
                Exit For
            End If
        Next
        If myPropertyInfo Is Nothing Then
            Return ""
        End If

        Try
            Return myPropertyInfo.GetValue(fromClass, Nothing)
        Catch ex As Exception
            Return False
        End Try

    End Function



    Private Sub Search2Log_AddRow(ByRef fromTable As Table, _
                                                                      ByVal fromCnt1 As Integer, _
                                                                      ByVal ParamArray fromParam() As String)
        Dim itemRow As TableRow
        Dim itemCell As TableCell
        Dim itemIsNumeric As Boolean
        Dim itemDisplayText As String = "", itemDisplayLast As String = ""

        If fromCnt1 = -1 Then
            '標題列
            For II As Integer = 1 To 2
                itemRow = New TableRow

                For Each eachParam As String In fromParam
                    itemCell = New TableCell
                    itemIsNumeric = IsNumeric(eachParam.Substring(0, 1))

                    If itemIsNumeric = True Then
                        If II = 1 Then
                            itemDisplayText = eachParam.Substring(0, 2)
                            itemCell.ColumnSpan = 2

                            If "".Equals(itemDisplayLast) = False Then
                                If itemDisplayLast.Equals(itemDisplayText) Then Continue For
                            End If
                            itemDisplayLast = itemDisplayText

                        ElseIf II = 2 Then
                            itemDisplayText = IIf(eachParam.Substring(2, 1) = "B", "午", "晚")
                            itemDisplayText = ModTools.showSpace(2) & itemDisplayText & ModTools.showSpace(2)

                            itemCell.ColumnSpan = 1
                        End If

                    Else
                        If II = 2 Then Continue For
                        itemDisplayText = eachParam
                        itemCell.RowSpan = 2
                    End If

                    itemCell.Text = itemDisplayText


                    itemCell.CssClass = "divCss03" & Chr(65)
                    itemRow.Cells.Add(itemCell)
                Next

                fromTable.Rows.Add(itemRow)
            Next

        Else
            '內容

            itemRow = New TableRow
            For Each eachParam As String In fromParam
                itemCell = New TableCell
                itemCell.Text = eachParam

                itemCell.CssClass = "divCss03" & Chr(65 + (fromCnt1 Mod 2))
                itemRow.Cells.Add(itemCell)
            Next

            fromTable.Rows.Add(itemRow)

        End If
    End Sub

#End Region

#Region "MsgBox：彈跳訊息"
    ''' <summary>
    ''' 彈出提示訊息。
    ''' </summary>
    ''' <param name="Message">訊息文字。</param>
    Public Sub MsgBox(ByVal Message As String)
        Dim sScript As String
        Dim sMessage As String

        sMessage = Strings.Replace(Message, "'", "\'") '處理單引號
        sMessage = Strings.Replace(sMessage, vbNewLine, "\n") '處理換行
        sScript = String.Format("alert('{0}');", sMessage)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", sScript, True)
    End Sub
#End Region




End Class