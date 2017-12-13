Imports UCAjaxServerControl1

Public Class CCMailPWD_Main
    Inherits System.Web.UI.UserControl
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Dim WP_System_Type As String = "CCMail"
    Dim dot_NOTE_Type As String = "重設密碼人員"


    Private Sub P_reFresh父物件(from主畫面_ActiveTabIndex As 主畫面_Enum) Handles CCMailPWD_Edit1.Event_reFresh父物件

        TabContainer1.ActiveTabIndex = from主畫面_ActiveTabIndex

        Select Case from主畫面_ActiveTabIndex
            Case 主畫面_Enum.編修
                CCMailPWD_Edit1.P_reFresh子物件(WP_LoginUserUnit, WP_LoginUserID)
        End Select

        TabContainer1_Visible(from主畫面_ActiveTabIndex)
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
        CCMailPWD_Edit1.P_reFresh子物件(WP_LoginUserUnit, WP_LoginUserID)
        TabContainer1_Visible(TabContainer1.ActiveTabIndex)
    End Sub

    Private Sub TabContainer1_Visible(from主畫面_ActiveTabIndex As 主畫面_Enum)
        'TabContainer1.Controls(主畫面_Enum.查詢).Visible = True
        'TabContainer1.Controls(主畫面_Enum.編修).Visible = (主畫面_Enum.編修 = from主畫面_ActiveTabIndex)
        'TabContainer1.Controls(主畫面_Enum.列印).Visible = (主畫面_Enum.列印 = from主畫面_ActiveTabIndex)
    End Sub

#Region "ViewState：Employee"
    Private Property WP_DataTable_Employee As DataTable
        Get
            If ViewState(C_DataTableEmployee) Is Nothing Then
                ViewState(C_DataTableEmployee) = FD_Data_Employee_Now()
            End If
            Return ViewState(C_DataTableEmployee)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableEmployee) = value
        End Set
    End Property
#End Region

#Region "ViewState：使用者登入資訊"
    Const C_LoginUserName As String = "LoginUserName"
    Const C_LoginUserID As String = "LoginUserID"
    Const C_LoginUserUnit As String = "LoginUserUnit"

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
            TabContainer1.ActiveTabIndex = 主畫面_Enum.查詢
            TabContainer1_ActiveTabChanged(TabContainer1, Nothing)
        End If
        MultiView1.SetActiveView(View2)
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

                WP_LoginUserUnit = showEmployeeUserUnit(WP_DataTable_Employee, txtLoginUser.Text)

                Dim ControlUser As New DataTable
                ControlUser = WP_ClsSystemNote.getLev3(WP_System_Type, dot_NOTE_Type)
                Dim isInList = From dr As DataRow In ControlUser
                               Where dr.Item("NOTE_ID") = txtLoginUser.Text
                If isInList.Count > 0 Then
                    P_ShowLoginOK_View2(True)
                Else
                    lbLoginMessage.Text = "此帳號無權限使用本系統"
                End If




                'btnSearch_Click(Nothing, Nothing)
            End If

        End If
    End Sub

    Private Sub BorgSPM_LogOut()
        txtLoginUser.Text = ""
        txtLoginPW.Text = ""
        WP_LoginUserName = ""
        WP_LoginUserID = ""

        BorgSPM_ShowInfo()

        MultiView1.SetActiveView(View1)
    End Sub

    Private Sub BorgSPM_ShowInfo()
        linkBtnLoginInfo.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")

        If String.IsNullOrEmpty(WP_LoginUserName) = True OrElse WP_LoginUserName = "" Then Exit Sub
        linkBtnLoginInfo.Text &= " | " & WP_LoginUserName & " | " & "系統登出"
    End Sub

#End Region


End Class