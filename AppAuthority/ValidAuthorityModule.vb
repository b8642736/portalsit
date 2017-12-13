Public Module ValidAuthorityModule
    Dim DBDataContext As New CompanyLINQDB.WebAPPAuthorityDataContext

#Region "驗證是否可通過授權系統 方法:IsCanValidAuthoritySystem"
    ''' <summary>
    ''' 驗證是否可通過授權系統
    ''' </summary>
    ''' <param name="WebSystemCode"></param>
    ''' <param name="WebSystemFunctionCode"></param>
    ''' <param name="ValidClientPCIP">增加使用者IP授權</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCanValidAuthoritySystem(ByVal WebSystemCode As String, Optional ByVal WebSystemFunctionCode As String = Nothing, Optional ByVal ValidClientPCIP As String = Nothing) As Boolean

        Static Mut As New Threading.Mutex
        Mut.WaitOne()
        '取得CurrentWindowsLoginEmployeeNumber By JiaRong 1050624
        Dim LoginWindowAccount As String = ""
        If String.IsNullOrEmpty(My.User.Name) Then
            LoginWindowAccount = Nothing
        End If
        Dim DomainUserString() As String = My.User.Name.Split("\")
        If DomainUserString.Length < 2 And DomainUserString(0).ToUpper <> "DOMAIN" And DomainUserString(0).ToUpper <> "TESSCO" Then
            LoginWindowAccount = Nothing
        End If
        LoginWindowAccount = DomainUserString(1)
        '個別方式授權

        If Not IsNothing(IsNothing(LoginWindowAccount)) AndAlso (From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = LoginWindowAccount And A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A).Any Then
            Mut.ReleaseMutex()
            Return True
        End If
        '群組方式授權
        Dim WebSystemFunctionForWebGroupAuthority_GroupCodes As List(Of String) = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A.GroupCode).ToList
        If Not IsNothing(IsNothing(LoginWindowAccount)) AndAlso (From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.WindowLoginName = LoginWindowAccount And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
            Mut.ReleaseMutex()
            Return True
        End If

        Dim ClientIP As System.Net.IPAddress = Nothing
        If Not IsNothing(ValidClientPCIP) AndAlso System.Net.IPAddress.TryParse(ValidClientPCIP, ClientIP) Then
            '個別方式授權
            If (From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = ValidClientPCIP And A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A).Any Then
                Mut.ReleaseMutex()
                Return True
            End If
            '群組方式授權
            If (From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Where A.ClientIP = ValidClientPCIP And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
                Mut.ReleaseMutex()
                Return True
            End If
        End If
        Mut.ReleaseMutex()
    End Function


#End Region
End Module
