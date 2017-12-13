Imports CompanyORMDB
Imports PublicClassLibrary.MISMail
Imports System.Net.Mail

Public Class CCMailExcute_Synchronize
    Inherits System.Web.UI.UserControl
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter
    Private isError As Boolean = False
    Private mail_Title As String = "[CCMail] 自動同步-AotoSynchronize "
    Private mail_Body As New StringBuilder
    Private mail_Error As New StringBuilder
    Dim newUserCount As Int32 = 0
    Dim removeUserCount As Int32 = 0
    Dim updateUserCount As Int32 = 0
    Dim newDepartmentCount As Int32 = 0
    Dim removeDepartmentCount As Int32 = 0
    Dim updateDepartmentCount As Int32 = 0


    Public Enum 資料來源
        SQL = 0
        AS400 = 1
    End Enum
    Public Enum 資料類型
        使用者 = 0
        部門 = 1
    End Enum
    Public Enum 更新類型
        更新 = 0
        待刪 = 1
    End Enum


    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As 主畫面_Enum)


#Region "ViewState：使用者登入資訊"
    Const C_LoginUserID As String = "LoginUserID"
    Const C_LoginUserUnit As String = "LoginUserUnit"

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

    Public Sub P_reFresh子物件(ByVal fromUserUnit As String, ByVal fromUserID As String)

        Call P_Init()

        WP_LoginUserID = fromUserID
        WP_LoginUserUnit = fromUserUnit
        '調整畫面與權限控管
        '--------------------------------------------------------------------------------------------

        'ListView1
        '--------------------------------------------------------------------------------------------
        'ListView1.DataBind()

        '新增單據後，畫面上呈現此筆資料
        '--------------------------------------------------------------------------------------------

    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()
        End If
    End Sub

    Private Sub P_Init()
        CustomValidator1.Visible = False
        hfSQL.Value = ""
        MakQryStringToControl()
        Try
            If Not Request.QueryString.Item("isAutoSynchronize") = Nothing Then
                Dim isAutoRun As String = Request.QueryString.Item("isAutoSynchronize").ToString.Trim.ToLower
                If isAutoRun.Equals("true") Then
                    AotoSynchronize()
                    MakQryStringToControl()
                Else
                    Response.Write("TRUE or FALSE ?")
                End If
            Else

                If Not Request.QueryString.Count = 0 Then
                    Try
                    Response.Write("接收到的參數為:")
                    For Each par In Request.QueryString
                        Response.Write(par.ToString)
                        Next
                    Catch ex As Exception
                        Response.Write("錯誤!這不是正規GET參數!")
                    End Try
                    Response.Write("</br>")
                    Response.Write("或許您要打</br>")
                    Response.Write("isAutoSynchronize=TRUE")
                End If
            End If
        Catch ex As Exception
            Response.Write("AutoRunMessage : " & ex.ToString)
        End Try
    End Sub

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim retSQL As New StringBuilder
        Me.hfSQL.Value = ""
        Try
            retSQL.Append("SELECT * " & vbNewLine)
            retSQL.Append("FROM [MIS].[dbo].[CCmail_Users]" & vbNewLine)
            retSQL.Append("WHERE 1=1" & vbNewLine)
            retSQL.Append("AND NOT status = 'Y'" & vbNewLine)
            Me.hfSQL.Value = retSQL.ToString & "♒" & Now.ToString

        Catch ex As Exception
            CustomValidator1.Visible = True
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
    End Sub
    Private Function MakQryStringForAutoRun() As String
        Dim retSQL As New StringBuilder
        retSQL.Append("SELECT * " & vbNewLine)
        retSQL.Append("FROM [MIS].[dbo].[CCmail_Users]" & vbNewLine)
        retSQL.Append("WHERE 1=1" & vbNewLine)
        retSQL.Append("AND NOT status = 'Y'" & vbNewLine)
        Return retSQL.ToString
    End Function
    Private Function FS_MakQryString(ByVal uid As String) As String
        Dim retSQL As New StringBuilder
        Try
            retSQL.Append("SELECT * " & vbNewLine)
            retSQL.Append("FROM [MIS].[dbo].[CCmail_Users]" & vbNewLine)
            retSQL.Append("WHERE 1=1" & vbNewLine)
            retSQL.Append("AND NOT status = 'Y'" & vbNewLine)
            retSQL.Append("AND uid_XML = '" & uid & "'" & vbNewLine)

        Catch ex As Exception
            CustomValidator1.Visible = True
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        Return retSQL.ToString
    End Function
#End Region

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of SQLServer.MIS.CCmail_Users)
        Dim ReturnValue As New List(Of SQLServer.MIS.CCmail_Users)
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        SQLString = SQLString.Split("♒")(0)
        ReturnValue = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Return ReturnValue
    End Function
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SQLString As String) As List(Of SQLServer.MIS.CCmail_Users)
        Dim ReturnValue As New List(Of SQLServer.MIS.CCmail_Users)
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Return ReturnValue
    End Function
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub

    Protected Sub Excute(sender As Object, e As EventArgs)
        Dim uid As String = CType(sender, Button).ToolTip
        Excute(uid)
    End Sub
    Protected Sub Excute(ByVal uid As String)
        Dim userObj As SQLServer.MIS.CCmail_Users = Search(FS_MakQryString(uid)).First
        Dim resultXML As String = ""
        Dim errcode As String = ""
        Dim errmsg As String = ""
        Dim mode As String = ""
        Dim isExcuteSucess As Boolean = False
        Try
            If DateTime.Compare(CType(userObj.executeDate, DateTime), Now) < 0 Then

                Select Case userObj.status
                    Case "N"
                        mode = "新增"
                        resultXML = Excute_CCMail_CreateUser(userObj)
                    Case "U"
                        mode = "更新"
                        resultXML = Excute_CCMail_UpdateUser(userObj)
                    Case "D"
                        mode = "刪除"
                        resultXML = Excute_CCMail_DeleteUser(userObj)
                End Select
                errcode = FS_get_errcode(resultXML)
                errmsg = FS_get_errmsg(resultXML)
                isExcuteSucess = CCMail_Model.isExcuteSucess(errcode)
                If Not isExcuteSucess Then
                    isError = True
                End If
                tb_result.Text &= vbNewLine
                tb_result.Text &= mode & " : " & uid & vbNewLine
                tb_result.Text &= "狀態 : " & IIf(isExcuteSucess, "成功", "失敗") & vbNewLine
                tb_result.Text &= "代碼 : " & errcode & vbNewLine
                tb_result.Text &= "訊息 : " & errmsg & vbNewLine

                '========================組合EMAIL內容====================
                mail_Body.Append(vbNewLine)
                mail_Body.Append(mode & " : " & uid & vbNewLine)
                mail_Body.Append("狀態 : " & IIf(isExcuteSucess, "成功", "失敗") & vbNewLine)
                mail_Body.Append("代碼 : " & errcode & vbNewLine)
                mail_Body.Append("訊息 : " & errmsg & vbNewLine)
                mail_Body.Append("回傳結果 : " & vbNewLine)
                mail_Body.Append(resultXML)
            Else
                tb_result.Text &= "尚未到預計執行日期" & vbNewLine
            End If
        Catch ex As Exception
            isError = True
            mail_Body.Append("Exception(" & uid & ") " & ex.ToString)
        End Try
    End Sub
    Private Sub AotoRun()

        Dim L_allList As List(Of SQLServer.MIS.CCmail_Users) = Search(MakQryStringForAutoRun)
        For Each user As SQLServer.MIS.CCmail_Users In L_allList
            Excute(user.uid_XML)
        Next
    End Sub



#End Region

#Region "取得人員資料TABLE"
    Public Function FD_UsersTable(ByVal db As 資料來源) As DataTable
        Dim result As String = ""
        Dim querySql As New StringBuilder
        If db = 資料來源.SQL Then
            querySql.Append("SELECT *  " & vbNewLine)
            querySql.Append("FROM [MIS].[dbo].[CCmail_Users] " & vbNewLine)
            querySql.Append("WHERE 1=1" & vbNewLine)
            querySql.Append("AND kind = 'A' " & vbNewLine)
            querySql.Append("AND NOT status = 'D' " & vbNewLine)
        Else
            querySql.Append("EXEC [dbo].[PD_AS400_CCmail_Users]")
        End If
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql.ToString)
        Return dtResult
    End Function
#End Region
#Region "取得部門資料TABLE"
    Public Function FD_Department(ByVal db As 資料來源) As DataTable
        Dim result As String = ""
        Dim querySql As New StringBuilder
        If db = 資料來源.SQL Then
            querySql.Append("SELECT *  " & vbNewLine)
            querySql.Append("FROM [MIS].[dbo].[CCmail_Department] " & vbNewLine)
            querySql.Append("WHERE kind = 'A' " & vbNewLine)
        Else
            querySql.Append("EXEC [dbo].[PD_AS400_CCmail_Department]")
        End If
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql.ToString)
        Return dtResult
    End Function
#End Region
#Region "同步人員資料"
    Protected Sub SynchronizeUsers()
        Dim sqlTable As DataTable = FD_UsersTable(資料來源.SQL)
        Dim as400Table As DataTable = FD_UsersTable(資料來源.AS400)

        isError = False
        '---新增帳號(400有 SQL沒有)
        mail_Body.Append("-----------新增使用者-----------" & vbNewLine)
        For Each dr_400 As DataRow In as400Table.Rows
            Dim result = From dr_sql As DataRow In sqlTable.AsEnumerable
                            Where dr_sql.Item(dc_uid).ToString.Trim = dr_400.Item(dc_uid).ToString.Trim
            If result.Count = 0 Then
                newUserCount += 1
                Insertuser(dr_400)
                write_log(dr_400, "sN", 資料類型.使用者, "N")
            End If
        Next
        tb_result.Text &= "新使用者 : " & newUserCount & "" & vbNewLine
        '---消滅帳號(400沒有 SQL有)
        mail_Body.Append("-----------待刪使用者-----------" & vbNewLine)
        For Each dr_sql As DataRow In sqlTable.Rows
            Dim result = From dr_400 As DataRow In as400Table.AsEnumerable
                            Where dr_400.Item(dc_uid).ToString.Trim = dr_sql.Item(dc_uid).ToString.Trim
            If result.Count = 0 Then
                removeUserCount += 1
                write_log(dr_sql, "sD1", 資料類型.使用者, Nothing)
                Updateuser(dr_sql, 更新類型.待刪)
                write_log(dr_sql, "sD2", 資料類型.使用者, "D")
            End If
        Next
        tb_result.Text &= "待移除使用者 : " & removeUserCount & "" & vbNewLine
        '---更新帳號
        mail_Body.Append("-----------更新使用者-----------" & vbNewLine)
        sqlTable = FD_UsersTable(資料來源.SQL)
        as400Table = FD_UsersTable(資料來源.AS400)
        If isError Then
            tb_result.Text &= "新增\刪除人員發生錯誤，停止更新人員資料，請確認資料來源後再試一次" & vbNewLine
            Exit Sub
        End If
        For Each dr_400 As DataRow In as400Table.Rows
            Dim result = From dr As DataRow In sqlTable.AsEnumerable
                         Where dr.Item(dc_uid).ToString.Trim = dr_400.Item(dc_uid).ToString.Trim

            Dim dr_sql As DataRow = result.First
            If Not matched(dr_400, dr_sql, 資料類型.使用者) Then
                updateUserCount += 1
                write_log(dr_sql, "sU1", 資料類型.使用者, Nothing)
                Updateuser(dr_400, 更新類型.更新)
                write_log(dr_400, "sU2", 資料類型.使用者, "U")
            End If
        Next
        tb_result.Text &= "更新使用者 : " & updateUserCount & " " & vbNewLine
    End Sub
#End Region

#Region "同步部門資料"
    Protected Sub SynchronizeDepartment()
        Dim sqlTable As DataTable = FD_Department(資料來源.SQL)
        Dim as400Table As DataTable = FD_Department(資料來源.AS400)

        isError = False
        '---新增部門(400有 SQL沒有)
        mail_Body.Append("-----------新增部門-----------" & vbNewLine)
        For Each dr_400 As DataRow In as400Table.Rows
            Dim result = From dr_sql As DataRow In sqlTable.AsEnumerable
                            Where dr_sql.Item(dc_o).ToString.Trim = dr_400.Item(dc_o).ToString.Trim
            If result.Count = 0 Then
                newDepartmentCount += 1
                InsertDepartment(dr_400)
                write_log(dr_400, "sN", 資料類型.部門, "N")
            End If
        Next
        tb_result.Text &= "新部門 : " & newDepartmentCount & " " & vbNewLine
        '---消滅部門(400沒有 SQL有)
        mail_Body.Append("-----------待刪部門-----------" & vbNewLine)
        For Each dr_sql As DataRow In sqlTable.Rows
            Dim result = From dr_400 As DataRow In as400Table.AsEnumerable
                            Where dr_400.Item(dc_o).ToString.Trim = dr_sql.Item(dc_o).ToString.Trim
            If result.Count = 0 Then
                removeDepartmentCount += 1
                'write_log(dr_sql, "sD1", 資料類型.部門, Nothing)
                'Updateuser(dr_sql, 更新類型.待刪)
                'write_log(dr_sql, "sD2", 資料類型.部門, "D")
            End If
        Next
        tb_result.Text &= "待移除部門 : " & removeDepartmentCount & " " & vbNewLine
        '---更新部門
        mail_Body.Append("-----------更新部門-----------" & vbNewLine)
        If isError Then
            tb_result.Text &= "新增\刪除部門發生錯誤，停止更新部門資料，請確認資料來源後再試一次" & vbNewLine
            Exit Sub
        End If
        sqlTable = FD_Department(資料來源.SQL)
        as400Table = FD_Department(資料來源.AS400)
        For Each dr_400 As DataRow In as400Table.Rows
            Dim result = From dr As DataRow In sqlTable.AsEnumerable
                         Where dr.Item(dc_o).ToString.Trim = dr_400.Item(dc_o).ToString.Trim
            Dim dr_sql As DataRow = result.First
            If Not matched(dr_400, dr_sql, 資料類型.部門) Then
                updateDepartmentCount += 1
                'write_log(dr_sql, "sU1", 資料類型.部門, Nothing)
                'Updateuser(dr_400, 更新類型.更新)
                'write_log(dr_400, "sU2", 資料類型.部門, "U")
            End If
        Next
        tb_result.Text &= "更新部門 : " & updateDepartmentCount & " " & vbNewLine
    End Sub
#End Region

#Region "CRUD"
    Protected Sub write_log(ByVal dr As DataRow, ByVal stage As String, ByVal type As 資料類型, ByVal status As String)
        If status = Nothing Then
            status = dr.Item(dc_status)
        End If
        Select Case type
            Case 資料類型.使用者
                Try
                    Dim insertObj As New SQLServer.MIS.CCmail_Users_Log
                    With insertObj
                        .uid_XML = dr.Item(dc_uid)
                        .kind = dr.Item(dc_kind)
                        .password_XML = dr.Item(dc_password)
                        .email_XML = dr.Item(dc_email)
                        .employeeNum_XML = dr.Item(dc_empNum)
                        .cn_XML = dr.Item(dc_cn)
                        .o_XML = dr.Item(dc_o)
                        .sequence_XML = dr.Item(dc_sequence)
                        .modiDate = dr.Item(dc_modiDate)
                        .executeDate = dr.Item(dc_excuteDate)
                        .stage = stage
                        .ModifiedDate = DateTime.Now
                        .status = status
                    End With
                    insertObj.CDBInsert()
                Catch ex As Exception
                    tb_result.Text &= "USER_LOG_錯誤 : " & ex.ToString & vbNewLine
                    isError = True
                End Try
            Case 資料類型.部門
                Try
                    Dim insertObj As New SQLServer.MIS.CCmail_Department_Log
                    With insertObj
                        .o_XML = dr.Item(dc_o)
                        .orgId_XML = dr.Item(dc_orgid)
                        .kind = dr.Item(dc_kind)
                        .sequence_XML = dr.Item(dc_sequence)
                        .displayName_XML = dr.Item(dc_displayName)
                        .parentOrgId_XML = dr.Item(dc_parentOrgId)
                        .deptCode = dr.Item(dc_deptCode)
                        .deptName = dr.Item(dc_deptName)
                        .stage = stage
                        .modiDate = dr.Item(dc_modiDate)
                        .ModifiedDate = DateTime.Now
                        .status = status
                    End With
                    insertObj.CDBInsert()
                Catch ex As Exception
                    tb_result.Text &= "Department_LOG_錯誤 : " & ex.ToString & vbNewLine
                    isError = True
                End Try
            Case Else
        End Select
    End Sub
    Protected Sub Insertuser(ByVal dr As DataRow)
        Try
            mail_Body.Append("新增 : " & dr.Item(dc_cn) & vbNewLine)
            mail_Body.Append("   uid_XML : " & dr.Item(dc_uid) & vbNewLine)
            mail_Body.Append("   kind : " & dr.Item(dc_kind) & vbNewLine)
            mail_Body.Append("   password_XML : " & dr.Item(dc_password) & vbNewLine)
            mail_Body.Append("   email_XML : " & dr.Item(dc_email) & vbNewLine)
            mail_Body.Append("   employeeNum_XML : " & dr.Item(dc_empNum) & vbNewLine)
            mail_Body.Append("   cn_XML : " & dr.Item(dc_cn) & vbNewLine)
            mail_Body.Append("   o_XML : " & dr.Item(dc_o) & vbNewLine)
            mail_Body.Append("   sequence_XML : " & dr.Item(dc_sequence) & vbNewLine)
            mail_Body.Append("   status : " & "N" & vbNewLine)
            mail_Body.Append("   modiDate : " & Now & vbNewLine)
            mail_Body.Append("   executeDate : " & Now & vbNewLine)
            Dim insertObj As New SQLServer.MIS.CCmail_Users
            With insertObj
                .uid_XML = dr.Item(dc_uid)
                .kind = dr.Item(dc_kind)
                .password_XML = dr.Item(dc_password)
                .email_XML = dr.Item(dc_email)
                .employeeNum_XML = dr.Item(dc_empNum)
                .cn_XML = dr.Item(dc_cn)
                .o_XML = dr.Item(dc_o)
                .sequence_XML = dr.Item(dc_sequence)
                .status = "N"
                .modiDate = Now
                .executeDate = Now
            End With
            insertObj.CDBInsert()
            tb_result.Text &= "新增使用者 : " & dr.Item(dc_cn) & vbNewLine
        Catch ex As Exception
            tb_result.Text &= "錯誤 : " & ex.ToString & vbNewLine
            mail_Body.Append("錯誤 : " & ex.ToString)
            mail_Error.Append(dr.Item(dc_cn) & vbNewLine)
            isError = True
        End Try
        mail_Body.Append("------------------------------" & vbNewLine)
    End Sub
    Protected Sub Updateuser(ByVal dr As DataRow, ByVal type As 更新類型)
        Try
            mail_Body.Append(IIf(type = 更新類型.待刪, "待刪", "更新") & " : " & dr.Item(dc_cn) & vbNewLine)
            mail_Body.Append("   uid_XML : " & dr.Item(dc_uid) & vbNewLine)
            mail_Body.Append("   kind : " & dr.Item(dc_kind) & vbNewLine)
            mail_Body.Append("   password_XML : " & dr.Item(dc_password) & vbNewLine)
            mail_Body.Append("   email_XML : " & dr.Item(dc_email) & vbNewLine)
            mail_Body.Append("   employeeNum_XML : " & dr.Item(dc_empNum) & vbNewLine)
            mail_Body.Append("   cn_XML : " & dr.Item(dc_cn) & vbNewLine)
            mail_Body.Append("   o_XML : " & dr.Item(dc_o) & vbNewLine)
            mail_Body.Append("   sequence_XML : " & dr.Item(dc_sequence) & vbNewLine)
            mail_Body.Append("   status : " & IIf(type = 更新類型.待刪, "D", "U") & vbNewLine)
            mail_Body.Append("   modiDate : " & Now & vbNewLine)

            Dim insertObj As New SQLServer.MIS.CCmail_Users
            With insertObj
                .uid_XML = dr.Item(dc_uid)
                .kind = dr.Item(dc_kind)
                .password_XML = dr.Item(dc_password)
                .email_XML = dr.Item(dc_email)
                .employeeNum_XML = dr.Item(dc_empNum)
                .cn_XML = dr.Item(dc_cn)
                .o_XML = dr.Item(dc_o)
                .sequence_XML = dr.Item(dc_sequence)
                .modiDate = DateTime.Now
                If type = 更新類型.待刪 Then
                    .status = "D"
                    .executeDate = DateTime.Now.AddDays(DeleteBufferDay)
                Else
                    .status = "U"
                    .executeDate = DateTime.Now
                End If
                mail_Body.Append("   executeDate : " & .executeDate.ToString & vbNewLine)
            End With
            insertObj.CDBUpdate()
            If type = 更新類型.待刪 Then
                tb_result.Text &= "等待刪除 : " & dr.Item(dc_cn) & vbNewLine
            Else
                tb_result.Text &= "更新使用者 : " & dr.Item(dc_cn) & vbNewLine
            End If
        Catch ex As Exception
            isError = True
            tb_result.Text &= "錯誤 : " & ex.ToString & vbNewLine
            mail_Body.Append("錯誤 : " & ex.ToString)
            mail_Error.Append("使用者 : " & dr.Item(dc_cn) & vbNewLine)
        End Try
        mail_Body.Append("------------------------------" & vbNewLine)
    End Sub

    Protected Sub InsertDepartment(ByVal dr As DataRow)
        Try
            mail_Body.Append("新增 : " & dr.Item(dc_displayName) & vbNewLine)
            mail_Body.Append("   o_XML : " & dr.Item(dc_o) & vbNewLine)
            mail_Body.Append("   orgId_XML : " & dr.Item(dc_orgid) & vbNewLine)
            mail_Body.Append("   kind : " & dr.Item(dc_kind) & vbNewLine)
            mail_Body.Append("   sequence_XML : " & dr.Item(dc_sequence) & vbNewLine)
            mail_Body.Append("   displayName_XML : " & dr.Item(dc_displayName) & vbNewLine)
            mail_Body.Append("   parentOrgId_XML : " & dr.Item(dc_parentOrgId) & vbNewLine)
            mail_Body.Append("   deptCode : " & dr.Item(dc_deptCode) & vbNewLine)
            mail_Body.Append("   deptName : " & dr.Item(dc_deptName) & vbNewLine)
            mail_Body.Append("   status : " & "N" & vbNewLine)
            mail_Body.Append("   modiDate : " & Now & vbNewLine)
            Dim insertObj As New SQLServer.MIS.CCmail_Department
            With insertObj
                .o_XML = dr.Item(dc_o)
                .orgId_XML = dr.Item(dc_orgid)
                .kind = dr.Item(dc_kind)
                .sequence_XML = dr.Item(dc_sequence)
                .displayName_XML = dr.Item(dc_displayName)
                .parentOrgId_XML = dr.Item(dc_parentOrgId)
                .deptCode = dr.Item(dc_deptCode)
                .deptName = dr.Item(dc_deptName)
                .status = "N"
                .modiDate = Now
            End With
            insertObj.CDBInsert()
            tb_result.Text &= "新增部門 : " & dr.Item(dc_displayName) & vbNewLine
        Catch ex As Exception
            tb_result.Text &= "錯誤 : " & ex.ToString & vbNewLine
            isError = True
            mail_Body.Append("錯誤 : " & ex.ToString)
            mail_Error.Append("部門 : " & dr.Item(dc_cn) & vbNewLine)
        End Try
        mail_Body.Append("------------------------------" & vbNewLine)
    End Sub
#End Region

    '' TODO DBNull需例外處理 105/10/24
    Protected Function matched(ByVal dr_A As DataRow, ByVal dr_B As DataRow, ByVal type As 資料類型) As Boolean

        Select Case type
            Case 資料類型.使用者
                If dr_A.Item(dc_empNum) = "30327" Then
                    '測試用中斷點
                    'tb_result.Text &= "STOP")
                End If
                If Not (dr_A.Item(dc_email) = dr_B.Item(dc_email) And _
                       dr_A.Item(dc_empNum) = dr_B.Item(dc_empNum) And _
                       dr_A.Item(dc_cn) = dr_B.Item(dc_cn) And _
                       dr_A.Item(dc_o) = dr_B.Item(dc_o) And _
                       dr_A.Item(dc_sequence) = dr_B.Item(dc_sequence)) Then
                    Return False
                Else
                    Return True
                End If
            Case 資料類型.部門
                If dr_A.Item(dc_orgid) = "H3" Then
                    '測試用中斷點
                    'tb_result.Text &= "STOP")
                End If
                If Not (dr_A.Item(dc_parentOrgId) = dr_B.Item(dc_parentOrgId) And _
                      dr_A.Item(dc_displayName) = dr_B.Item(dc_displayName) And _
                      dr_A.Item(dc_orgid) = dr_B.Item(dc_orgid) And _
                      dr_A.Item(dc_sequence) = dr_B.Item(dc_sequence)) Then
                    Return False
                Else
                    Return True
                End If
            Case Else
        End Select


    End Function

    Protected Sub btSynchronize_Click(sender As Object, e As EventArgs) Handles btSynchronize.Click
        SynchronizeUsers()
        SynchronizeDepartment()
        MakQryStringToControl()
    End Sub
    Private Sub AotoSynchronize()
        Dim resutleTitle As String = ""
        mail_Body.Append(Now.ToString & "    CCMail 自動同步結果" & vbNewLine)
        mail_Body.Append("♒" & vbNewLine)
        mail_Body.Append("##人員同步結果" & vbNewLine)
        SynchronizeUsers()
        mail_Body.Append("##部門同步結果" & vbNewLine)
        SynchronizeDepartment()

        Response.Write(tb_result.Text)


        '====產生結果字串====
        Dim result As New StringBuilder
        result.Append("新帳號 : " & newUserCount & vbNewLine)
        result.Append("待刪帳號 : " & removeUserCount & vbNewLine)
        result.Append("更新帳號 : " & updateUserCount & vbNewLine)
        result.Append("新部門 : " & newDepartmentCount & vbNewLine)
        result.Append("待刪部門 : " & removeDepartmentCount & vbNewLine)
        result.Append("更新部門 : " & updateDepartmentCount & vbNewLine)
        result.Append("-----------錯誤清單-----------" & vbNewLine)
        result.Append(mail_Error)
        result.Append("------------------------------" & vbNewLine)

        mail_Body.Append(vbNewLine)
        mail_Body.Append(vbNewLine)
        mail_Body.Append("##人員執行結果" & vbNewLine)
        AotoRun()

        Dim address() As String = S_CCMail_ReportEmailAdd

        If isError Then
            mail_Title &= "錯誤"
        Else
            mail_Title &= "成功"
        End If

        QuickSendMail(mail_Title, mail_Body.ToString.Replace("♒", result.ToString), address)
    End Sub

    Protected Sub btn_clear_msg_Click(sender As Object, e As EventArgs) Handles btn_clear_msg.Click
        tb_result.Text = ""
    End Sub
End Class