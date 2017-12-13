Imports CompanyORMDB

Public Class CCMailPWD_Edit
    Inherits System.Web.UI.UserControl

    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter
    Private WP_SYSNOTE As New PublicClassLibrary.ClsSystemNote
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
        If Me.tbEmail.Text <> "" Then
            Call btnSearch_Click(btnSearch, Nothing)
        End If

    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        

        If Not IsPostBack Then
            Call P_Init()
        End If
    End Sub

    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.Day, -14, W_Date_E)

        ddl_department.Items.Clear()
        lb_Message.Text = ""
        tbEmpNum.Text = ""
        tbEmail.Text = ""
        hfSQL.Value = ""
        setDepartmentDropDownList(ddl_department)
        MakQryStringToControl()

    End Sub
    Private Sub setDepartmentDropDownList(ByRef ddl As WebControls.DropDownList)
        Dim listitem As New WebControls.ListItem()
        listitem.Text = "ALL"
        listitem.Value = "ALL"
        ddl.Items.Add(listitem)
        For Each dr As DataRow In FD_getAllDepartment().Rows
            listitem = New WebControls.ListItem()
            listitem.Text = dr.Item(dc_o) & " : " & dr.Item(dc_deptName)
            listitem.Value = dr.Item(dc_o)
            ddl.Items.Add(listitem)
        Next

    End Sub
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim retSQL As New StringBuilder
        Dim W_Unit As String = ""
        Try
            retSQL.Append("SELECT * " & vbNewLine)
            retSQL.Append("FROM [MIS].[dbo].[CCmail_Users]" & vbNewLine)
            retSQL.Append("WHERE 1=1" & vbNewLine)
            If Not tbEmpNum.Text.Trim = "" Then
                retSQL.Append("AND employeeNum_XML = '" & tbEmpNum.Text.Trim & "'" & vbNewLine)
            End If
            If Not tbEmail.Text.Trim = "" Then
                retSQL.Append("AND email_XML LIKE '%" & tbEmail.Text.Trim & "@%'" & vbNewLine)
            End If
            If Not tbName.Text.Trim = "" Then
                retSQL.Append("AND cn_XML LIKE '%" & tbName.Text.Trim & "%'" & vbNewLine)
            End If
            If Not ddl_department.SelectedValue = "ALL" Then
                retSQL.Append("AND o_XML = '" & ddl_department.SelectedValue & "'" & vbNewLine)
            End If
            Me.hfSQL.Value = retSQL.ToString


        Catch ex As Exception
            lb_Message.Text = ex.Message
        End Try
        lb_Message.Text = ""

    End Sub
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

        ReturnValue = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Return ReturnValue
    End Function
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub
    Protected Sub switch_rb(sender As Object, e As EventArgs)
        Dim rb_default As RadioButton = ListView1.EditItem.FindControl("rb_default")
        Dim rb_config As RadioButton = ListView1.EditItem.FindControl("rb_config")
        Dim tb_pwd1 As TextBox = ListView1.EditItem.FindControl("tb_pwd1")
        Dim tb_pwd2 As TextBox = ListView1.EditItem.FindControl("tb_pwd2")
        tb_pwd1.Enabled = rb_config.Checked
        tb_pwd2.Enabled = rb_config.Checked
    End Sub

    Protected Sub DoReset(sender As Object, e As EventArgs)
        Dim ClientPCIP As String = IIf(Me.Request.UserHostAddress.Substring(0, 2) = "::", "127.0.0.1", Me.Request.UserHostAddress)
        Dim uid As String = CType(sender, Button).ToolTip
        Dim pwd As String = S_CCMail_Default_Password
        Dim rb_default As RadioButton = ListView1.EditItem.FindControl("rb_default")
        Dim rb_config As RadioButton = ListView1.EditItem.FindControl("rb_config")
        Dim tb_pwd1 As TextBox = ListView1.EditItem.FindControl("tb_pwd1")
        Dim tb_pwd2 As TextBox = ListView1.EditItem.FindControl("tb_pwd2")
        Dim S_result_XML As String = ""
        tb_result.Text = ""
        If rb_config.Checked Then
            If tb_pwd1.Text = tb_pwd2.Text Then
                pwd = tb_pwd1.Text
                If pwd.Length = 0 Then
                    lb_Message.Text = "密碼不可留白"
                    Exit Sub
                End If
            Else
                lb_Message.Text = "兩次輸入的密碼不同"
                Exit Sub
            End If
        End If
        If pwd.Trim.Length = 0 Then
            lb_Message.Text = "該使用者無預設密碼，請自訂密碼"
            Exit Sub
        End If
        S_result_XML = Excute_CCMail_PWD(uid, pwd, WP_LoginUserID, ClientPCIP)
        Dim errcode As String = FS_get_errcode(S_result_XML)
        Dim errmsg As String = FS_get_errmsg(S_result_XML)
        Dim isExcuteSucess As Boolean = CCMail_Model.isExcuteSucess(errcode)
        tb_result.Text &= "狀態 : " & uid & "密碼變更" & IIf(isExcuteSucess, "成功", "失敗") & vbNewLine
        tb_result.Text &= "代碼 : " & errcode & vbNewLine
        tb_result.Text &= "訊息 : " & errmsg & vbNewLine
        'lb_Message.Text = "密碼變更" & IIf(isExcuteSucess, "成功", "失敗")
        If isExcuteSucess Then
            ListView1.EditIndex = -1
        End If

    End Sub


    Public Function FS_o_name(ByVal oid As String) As String
        Return getChineseDepartmentName(oid)
    End Function

    Protected Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        If Not ListView1.EditIndex = -1 Then
            lb_Message.Text = ""
            tb_result.Text = ""
        End If
    End Sub
End Class