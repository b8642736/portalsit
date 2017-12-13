Public Class AS400SQLQueryRecord
    Inherits CompanyORMDB.AS400SQLQueryAdapter
    'Inherits CompanyLINQDB.AS400SQLQuery

    Dim DBDataCotext As New CompanyLINQDB.OtherOperatorDataContext

#Region "SQLSelect查詢 方法:SelectQuery"
    ''' <summary>
    ''' SQLSelect查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectQueryAndRecord(ByVal SourceWebPage As System.Web.UI.Page, Optional ByVal SetSourceQueryString As String = Nothing) As DataTable
        Dim ClientIP As System.Net.IPAddress = Nothing
        Dim ClientPCIP As String = IIf(SourceWebPage.Request.UserHostAddress.Substring(0, 2) = "::", "127.0.0.1", SourceWebPage.Request.UserHostAddress)
        If Not System.Net.IPAddress.TryParse(ClientPCIP, ClientIP) Then
            Throw New Exception("用戶端來源IP不合法!(您的IP為:" & ClientIP.ToString & ")")
        End If
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        If Me.QueryType <> QueryTypeEnum.SelectType Then
            Throw New Exception("您的查詢條件非合法(必需為Select ....)!")
        End If
        Dim QueryRecord As New CompanyLINQDB.AS400QueryRecord
        With QueryRecord
            .QueryType = Me.QueryType
            .RunTime = Now
            .RunPCIP = ClientIP.ToString

            '20160621 by JiaRong
            .RunUser = CurrentWindowsLoginEmployeeNumber2(SourceWebPage.Request.ServerVariables("LOGON_USER"))
            '.RunUser = WebAppAuthority.ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber


            .QueryString = Me.SourceQueryString
            .IsRunSuccess = False
            .ModifyRecordCount = 0
        End With
        DBDataCotext.AS400QueryRecord.InsertOnSubmit(QueryRecord)
        DBDataCotext.SubmitChanges()
        Dim ReturnValue As DataTable = Nothing
        Try
            ReturnValue = MyBase.SelectQuery(SetSourceQueryString)
            With QueryRecord
                .IsRunSuccess = True
                .ModifyRecordCount = ReturnValue.Rows.Count
            End With
            DBDataCotext.SubmitChanges()
        Catch ex As Exception
            DBDataCotext.AS400QueryRecord.DeleteOnSubmit(QueryRecord)
            DBDataCotext.SubmitChanges()
            Throw ex
        End Try
        Return ReturnValue
    End Function

#End Region

#Region "SQLExecute查詢 方法:ExecuteNonQuery"
    ''' <summary>
    ''' SQLExecute查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteNonQueryAndRecord(ByVal SourceWebPage As System.Web.UI.Page, Optional ByVal SetSourceQueryString As String = Nothing) As Integer
        Dim ClientIP As System.Net.IPAddress = Nothing
        Dim ClientPCIP As String = IIf(SourceWebPage.Request.UserHostAddress.Substring(0, 2) = "::", "127.0.0.1", SourceWebPage.Request.UserHostAddress)
        If Not System.Net.IPAddress.TryParse(ClientPCIP, ClientIP) Then
            Throw New Exception("用戶端來源IP不合法或來源IP不可為127.0.0.1!(您的IP為:" & ClientIP.ToString & ")")
        End If
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        If Me.QueryType <> QueryTypeEnum.InsertType AndAlso Me.QueryType <> QueryTypeEnum.UpdateType AndAlso Me.QueryType <> QueryTypeEnum.DeleteType Then
            Throw New Exception("您的查詢條件非合法(必需為Insert或Update或Delete ....)!")
        End If
        Dim QueryRecord As New CompanyLINQDB.AS400QueryRecord
        With QueryRecord
            .QueryType = Me.QueryType
            .RunTime = Now
            .RunPCIP = ClientIP.ToString
            '20160621 by JiaRong
            .RunUser = CurrentWindowsLoginEmployeeNumber2(SourceWebPage.Request.ServerVariables("LOGON_USER"))
            '.RunUser = WebAppAuthority.ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber

            .QueryString = Me.SourceQueryString
            .IsRunSuccess = False
            .ModifyRecordCount = 0
        End With
        DBDataCotext.AS400QueryRecord.InsertOnSubmit(QueryRecord)
        DBDataCotext.SubmitChanges()
        Dim ReturnValue As Integer = 0
        Try
            ReturnValue = MyBase.ExecuteNonQuery(SetSourceQueryString)
            With QueryRecord
                .IsRunSuccess = True
                .ModifyRecordCount = ReturnValue
            End With
            DBDataCotext.SubmitChanges()
        Catch ex As Exception
            DBDataCotext.AS400QueryRecord.DeleteOnSubmit(QueryRecord)
            DBDataCotext.SubmitChanges()
            Throw ex
        End Try
        Return ReturnValue
    End Function

#End Region

    '20160621 by JiaRong
    ''雙胞胎在WebAppAuthority.ValidAuthorityModule
#Region "FS_UserName : 取得使用者ID"
    Private Function CurrentWindowsLoginEmployeeNumber2(ByVal formString As String) As String

        If String.IsNullOrEmpty(formString) Then
            Return ""
        End If
        Dim DomainUserString() As String = formString.Split("\")
        If DomainUserString.Length < 2 And DomainUserString(0).ToUpper <> "DOMAIN" And DomainUserString(0).ToUpper <> "TESSCO" Then
            Return ""
        End If
        Return DomainUserString(1)

    End Function
#End Region

End Class