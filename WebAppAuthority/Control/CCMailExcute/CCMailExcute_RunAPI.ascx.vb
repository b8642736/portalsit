Imports CompanyORMDB


Public Class CCMailExcute_RunAPI
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()
        End If
    End Sub
    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.Day, -14, W_Date_E)
        CustomValidator1.Visible = False
        hfSQL.Value = ""
        MakQryStringToControl()
        Try
            If Not Request.QueryString.Item("isAutoRun") = Nothing Then
                Dim isAutoRun As String = Request.QueryString.Item("isAutoRun").ToString.Trim.ToLower
                If isAutoRun.Equals("true") Then
                    AotoRun()
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
            Me.hfSQL.Value = retSQL.ToString

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

        ReturnValue = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Return ReturnValue
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub

    Protected Sub Excute(sender As Object, e As EventArgs)
        Dim uid As String = CType(sender, Button).ToolTip

        Dim userObj As SQLServer.MIS.CCmail_Users = Search(FS_MakQryString(uid)).First
        If DateTime.Compare(CType(userObj.executeDate, DateTime), Now) < 0 Then

            Select Case userObj.status
                Case "N"
                    tb_result.Text &= Excute_CCMail_CreateUser(userObj)
                Case "U"
                    tb_result.Text &= Excute_CCMail_UpdateUser(userObj)
                Case "D"
                    tb_result.Text &= Excute_CCMail_DeleteUser(userObj)
            End Select
        Else
            tb_result.Text &= "尚未到預計執行日期" & vbNewLine
        End If
    End Sub
    Protected Sub Excute(ByVal uid As String)
        Dim userObj As SQLServer.MIS.CCmail_Users = Search(FS_MakQryString(uid)).First
        If DateTime.Compare(CType(userObj.executeDate, DateTime), Now) < 0 Then

            Select Case userObj.status
                Case "N"
                    tb_result.Text &= Excute_CCMail_CreateUser(userObj)
                Case "U"
                    tb_result.Text &= Excute_CCMail_UpdateUser(userObj)
                Case "D"
                    tb_result.Text &= Excute_CCMail_DeleteUser(userObj)
            End Select
        Else
            tb_result.Text &= "尚未到預計執行日期" & vbNewLine
        End If
    End Sub
    Private Sub AotoRun()

        Dim L_allList As List(Of SQLServer.MIS.CCmail_Users) = Search(MakQryStringForAutoRun)
        For Each user As SQLServer.MIS.CCmail_Users In L_allList
            Excute(user.uid_XML)
        Next
    End Sub



#End Region

End Class