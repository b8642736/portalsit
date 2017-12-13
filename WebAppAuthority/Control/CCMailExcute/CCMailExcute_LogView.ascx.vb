Imports CompanyORMDB

Public Class CCMailExcute_LogView
    Inherits System.Web.UI.UserControl
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()
        End If
    End Sub

    Private Sub P_Init()
        tb_Rule1.Text = ""
        tb_Rule2.Text = ""
        hfSQL.Value = ""
        tbStartDate.Text = Now.ToShortDateString
        tbEndDate.Text = Now.ToShortDateString
        ddl_logType_SelectedIndexChanged(Nothing, Nothing)
        MakQryStringToControl()
    End Sub
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim retSQL As New StringBuilder
        Dim W_Unit As String = ""
        Dim Sdate As String = tbStartDate.Text
        Dim Edate As String = Convert.ToDateTime(tbEndDate.Text).AddDays(1).ToShortDateString
        
        Try

            Select Case ddl_logType.SelectedValue
                Case "CCmail_Users_Log"
                    retSQL.Append("SELECT [uid_XML] as UID" & vbNewLine)
                    retSQL.Append("      ,[kind] as 來源" & vbNewLine)
                    retSQL.Append("      ,[password_XML] as 預設密碼" & vbNewLine)
                    retSQL.Append("      ,[email_XML] as Email" & vbNewLine)
                    retSQL.Append("      ,[employeeNum_XML] as 工號" & vbNewLine)
                    retSQL.Append("      ,[cn_XML] as 顯示名稱" & vbNewLine)
                    retSQL.Append("      ,[o_XML] as 組織" & vbNewLine)
                    retSQL.Append("      ,[sequence_XML] as 排序" & vbNewLine)
                    retSQL.Append("      ,[status] as 狀態" & vbNewLine)
                    retSQL.Append("      ,[modiDate] as 異動時間" & vbNewLine)
                    retSQL.Append("      ,[executeDate] as 執行時間" & vbNewLine)
                    retSQL.Append("      ,Case when A.stage='sU1' then 'A同步更新前'  " & vbNewLine)
                    retSQL.Append("          when A.stage='sU2' then 'A同步更新後'  " & vbNewLine)
                    retSQL.Append("          when A.stage='sD1' then 'A同步待刪除前'  " & vbNewLine)
                    retSQL.Append("          when A.stage='sD2' then 'A同步待刪除後'         " & vbNewLine)
                    retSQL.Append("          when A.stage='sN' then 'A同步新帳號' " & vbNewLine)
                    retSQL.Append("          when A.stage='eS' then 'B執行前'  " & vbNewLine)
                    retSQL.Append("          when A.stage='eE' then 'B執行後'  " & vbNewLine)
                    retSQL.Append("          else stage  " & vbNewLine)
                    retSQL.Append("          End as 'stage' " & vbNewLine)
                    retSQL.Append(" " & vbNewLine)
                    retSQL.Append("      ,[ModifiedDate] as 本資料同步時間" & vbNewLine)
                    retSQL.Append("  FROM [MIS].[dbo].[CCmail_Users_Log] A " & vbNewLine)
                    retSQL.Append("WHERE 1=1" & vbNewLine)
                    retSQL.Append("AND ModifiedDate BETWEEN '" & Sdate & "' and '" & Edate & "'" & vbNewLine)
                    If Not tb_Rule1.Text.Trim = "" Then
                        retSQL.Append("AND employeeNum_XML = '" & tb_Rule1.Text.Trim & "'" & vbNewLine)
                    End If
                    If Not tb_Rule2.Text.Trim = "" Then
                        retSQL.Append("AND email_XML LIKE '%" & tb_Rule2.Text.Trim & "@%'" & vbNewLine)
                    End If
                    retSQL.Append("order by 本資料同步時間,stage")
                Case "CCmail_PWD_Log"
                    retSQL.Append("SELECT * " & vbNewLine)
                    retSQL.Append("FROM [MIS].[dbo].[CCmail_PWD_Log]" & vbNewLine)
                    retSQL.Append("WHERE 1=1" & vbNewLine)
                    retSQL.Append("AND excuteTime  BETWEEN '" & Sdate & "' and '" & Edate & "'" & vbNewLine)
                    If Not tb_Rule1.Text.Trim = "" Then
                        retSQL.Append("AND uid = '" & tb_Rule1.Text.Trim & "'" & vbNewLine)
                    End If
                    If Not tb_Rule2.Text.Trim = "" Then
                        retSQL.Append("AND excutePeople ='" & tb_Rule2.Text.Trim & "'" & vbNewLine)
                    End If
                    retSQL.Append("order by excuteTime" & vbNewLine)
                Case "CCmail_Excute_Log"
                    retSQL.Append("SELECT * " & vbNewLine)
                    retSQL.Append("FROM [MIS].[dbo].[CCmail_Excute_Log]" & vbNewLine)
                    retSQL.Append("WHERE 1=1" & vbNewLine)
                    retSQL.Append("AND Excute_Date  BETWEEN '" & Sdate & "' and '" & Edate & "'" & vbNewLine)
                    If Not tb_Rule1.Text.Trim = "" Then
                        retSQL.Append("AND Target = '" & tb_Rule1.Text.Trim & "'" & vbNewLine)
                    End If
                    retSQL.Append("order by Excute_Date" & vbNewLine)
            End Select

            Me.hfSQL.Value = retSQL.ToString
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String) As DataTable
        Dim WP_SqlAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Dim ReturnValue As New DataTable
        If String.IsNullOrEmpty(fromSQL) Then
            Return ReturnValue
        End If
        ReturnValue = WP_SqlAdapter.SelectQuery(fromSQL)
        Return ReturnValue
    End Function
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal fromSQL As String) As DataTable
        Dim ReturnValue As New DataTable
        Return ReturnValue
    End Function
#End Region


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        cb_decode.Checked = False
        MakQryStringToControl()
    End Sub




    Protected Sub ddl_logType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_logType.SelectedIndexChanged
        lb_rule1.Text = ""
        lb_rule2.Text = ""
        tb_Rule1.Text = ""
        tb_Rule2.Text = ""
        cb_decode.Visible = False
        cb_hideResult.Visible = False
        Select Case ddl_logType.SelectedValue
            Case "CCmail_Users_Log"
                lb_rule2.Visible = True
                tb_Rule2.Visible = True
                lb_rule1.Text = "帳號 : "
                lb_rule2.Text = "Email : "
            Case "CCmail_PWD_Log"
                lb_rule1.Text = "帳號 : "
                lb_rule2.Text = "修改者工號 : "
                cb_decode.Visible = True
                cb_hideResult.Visible = True
            Case "CCmail_Excute_Log"
                lb_rule1.Text = "帳號 : "
                lb_rule2.Visible = False
                tb_Rule2.Visible = False
        End Select
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Select Case ddl_logType.SelectedValue
            Case "CCmail_Users_Log"

            Case "CCmail_PWD_Log"
                lb_rule1.Text = "帳號 : "
                lb_rule2.Text = "修改者工號 : "
            Case "CCmail_Excute_Log"
                lb_rule1.Text = "帳號 : "
                lb_rule2.Visible = False
                tb_Rule2.Visible = False
        End Select
    End Sub


    Protected Sub cb_decode_CheckedChanged(sender As Object, e As EventArgs) Handles cb_decode.CheckedChanged
        If cb_decode.Checked = True Then
            Try
                For Each dr As GridViewRow In GridView1.Rows
                    dr.Cells(1).Text = UCAjaxServerControl1.ClassBorgSPM.Decrypt(dr.Cells(1).Text)
                Next
            Catch ex As Exception
            End Try
        Else
            Try
                For Each dr As GridViewRow In GridView1.Rows
                    dr.Cells(1).Text = UCAjaxServerControl1.ClassBorgSPM.Encrypt(dr.Cells(1).Text)
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    
    Protected Sub cb_hideResult_CheckedChanged(sender As Object, e As EventArgs) Handles cb_hideResult.CheckedChanged
        If cb_hideResult.Checked = True Then
            GridView1.HeaderRow.Cells(2).Visible = False
            For Each dr As GridViewRow In GridView1.Rows
                dr.Cells(2).Visible = False
            Next
        Else
            GridView1.HeaderRow.Cells(2).Visible = True
            For Each dr As GridViewRow In GridView1.Rows
                dr.Cells(2).Visible = True
            Next
        End If

    End Sub
End Class