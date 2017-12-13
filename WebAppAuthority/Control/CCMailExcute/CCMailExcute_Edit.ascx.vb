Imports CompanyORMDB

Public Class CCMailExcute_Edit
    Inherits System.Web.UI.UserControl
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()

        End If
    End Sub

    Private Sub P_Init()
        ddl_department.Items.Clear()
        ddl_kind.Items.Clear()
        lb_Message.Text = ""
        tbEmpNum.Text = ""
        tbEmail.Text = ""
        tbName.Text = ""
        hfSQL.Value = ""
        setDepartmentDropDownList(ddl_department)
        setKindDropDownList(ddl_kind)
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
    Private Sub setKindDropDownList(ByRef ddl As WebControls.DropDownList)
        Dim listitem As New WebControls.ListItem()
        listitem.Text = "ALL"
        listitem.Value = "ALL"
        ddl.Items.Add(listitem)
        listitem = New WebControls.ListItem()
        listitem.Text = "A : AS400"
        listitem.Value = "A"
        ddl.Items.Add(listitem)
        listitem = New WebControls.ListItem()
        listitem.Text = "B : 共用帳號"
        listitem.Value = "B"
        ddl.Items.Add(listitem)
        listitem = New WebControls.ListItem()
        listitem.Text = "C : 系統帳號"
        listitem.Value = "C"
        ddl.Items.Add(listitem)

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
            If Not ddl_kind.SelectedValue = "ALL" Then
                retSQL.Append("AND Kind = '" & ddl_kind.SelectedValue & "'" & vbNewLine)
            End If
            Me.hfSQL.Value = retSQL.ToString


        Catch ex As Exception
            lb_Message.Text = ex.Message
        End Try
        lb_Message.Text = ""

    End Sub
#End Region
#Region "CRUD"
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
    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.MIS.CCmail_Users) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.MIS.CCmail_Users) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As SQLServer.MIS.CCmail_Users) As Integer
        Return fromObj.CDBDelete
    End Function
#End Region

    Protected Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim insertObj As New SQLServer.MIS.CCmail_Users
        With insertObj
            .uid_XML = e.Values(dc_uid)
            .kind = e.Values(dc_kind)
            .password_XML = e.Values(dc_password)
            .email_XML = e.Values(dc_email)
            .employeeNum_XML = e.Values(dc_empNum)
            .cn_XML = e.Values(dc_cn)
            .o_XML = e.Values(dc_o)
            .sequence_XML = e.Values(dc_sequence)
            .modiDate = Now
            .executeDate = Now
            .status = "Y"
        End With
        e.Values(dc_modiDate) = Now
        e.Values(dc_excuteDate) = e.Values(dc_modiDate)
        e.Values(dc_status) = "Y"
    End Sub

    Protected Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        Dim insertObj As New SQLServer.MIS.CCmail_Users
        insertObj = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QueryUidString(e.Values(dc_uid))).First
        Dim result As String = Excute_CCMail_CreateUser(insertObj)
        Dim errcode As String = FS_get_errcode(result)
        Dim errmsg As String = FS_get_errmsg(result)
        If isExcuteSucess(errcode) = False Then
            insertObj.CDBDelete()
            tb_result.Text &= "狀態 : " & "新增失敗" & vbNewLine
        Else
            tb_result.Text &= "狀態 : " & "新增成功" & vbNewLine
        End If
        tb_result.Text &= "代碼 : " & errcode & vbNewLine
        tb_result.Text &= "訊息 : " & errmsg & vbNewLine
    End Sub

   
    Protected Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim updateObj As New SQLServer.MIS.CCmail_Users
        With updateObj
            .uid_XML = e.Keys(dc_uid)
            .kind = e.NewValues(dc_kind)
            .password_XML = e.NewValues(dc_password)
            .email_XML = e.NewValues(dc_email)
            .employeeNum_XML = e.NewValues(dc_empNum)
            .cn_XML = e.NewValues(dc_cn)
            .o_XML = e.NewValues(dc_o)
            .sequence_XML = e.NewValues(dc_sequence)
            .modiDate = Now
            .executeDate = Now
            .status = "Y"
        End With
        e.NewValues(dc_modiDate) = Now
        e.NewValues(dc_excuteDate) = Now
        If CCMail_User_isExist(e.Keys(dc_uid)) = True Then
            Dim result As String = Excute_CCMail_UpdateUser(updateObj)
            Dim errcode As String = FS_get_errcode(result)
            Dim errmsg As String = FS_get_errmsg(result)
            If isExcuteSucess(errcode) = False Then
                e.Cancel = True
                tb_result.Text &= "狀態 : " & "更新失敗" & vbNewLine
            Else
                tb_result.Text &= "狀態 : " & "更新成功" & vbNewLine
            End If
            tb_result.Text &= "代碼 : " & errcode & vbNewLine
            tb_result.Text &= "訊息 : " & errmsg & vbNewLine
        Else
            tb_result.Text &= e.Keys(dc_uid) & "不存在MailServer中" & vbNewLine
            tb_result.Text &= "不接受編輯動作" & vbNewLine
        End If
        
    End Sub
    Protected Sub ListView1_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs) Handles ListView1.ItemDeleting
        Dim deleteObj As New SQLServer.MIS.CCmail_Users
        deleteObj = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QueryUidString(e.Keys(dc_uid))).First
        Dim result As String = Excute_CCMail_DeleteUser(deleteObj)
        Dim errcode As String = FS_get_errcode(result)
        Dim errmsg As String = FS_get_errmsg(result)
        If isExcuteSucess(errcode) = False Then
            e.Cancel = True
            tb_result.Text &= "狀態 : " & "刪除失敗" & vbNewLine
        Else
            tb_result.Text &= "狀態 : " & "刪除成功" & vbNewLine
        End If
        tb_result.Text &= "代碼 : " & errcode & vbNewLine
        tb_result.Text &= "訊息 : " & errmsg & vbNewLine
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub

   

End Class